using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.SharedAbstractions.Domain;

namespace PackIT.Domain.Entities
{
    public class PackingList: AggregateRoot<PackingListId>
    {
        public PackingListId Id { private set; get; }
        private PackingListName _name;
        private Localization _localization;
        private readonly LinkedList<PackingItem> _items = new();

        //internal PackingList(PackingListId id, PackingListName name, Localization localization, LinkedList<PackingItem> items)
        //    : this(id, name, localization)
        //{
        //    // Jest to zrobione tak a nie konstruktorem aby za każdym razem (nawet przy inicjalizacji, wywoływany był event informujący o dodaniu nowych itemów)
        //    // Jedynym problemem tego rozwiązania jest to, że na pewnym etapie ten konstruktor może być wywołany przez ORM wykonując niepotrzebne walidacje
              // W celu naprawienia tego "błedu" skorzystamy z fabryki
        //    AddItems(items);
        //}

        internal PackingList(PackingListId id, PackingListName name, Localization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        public void AddItem(PackingItem item)
        {
            var alreadyExists = _items.Any(i => i.Name == item.Name);

            if(alreadyExists)
            {
                throw new PackingItemAlreadyExistsException(_name, item.Name);
            }

            _items.AddLast(item);
            AddEvent(new PackingItemAdded(this, item));
        }

        public void AddItems(IEnumerable<PackingItem> items)
        {
            foreach (var item in items)
            {
                AddItem(item);
            }
        }

        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true };

            _items.Find(item).Value = packedItem;
            AddEvent(new PackingItemPacked(this, item));
        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);
            _items.Remove(item);
            AddEvent(new PackingItemRemoved(this, item));
        }

        private PackingItem GetItem(string itemName)
        {
            var item = _items.SingleOrDefault(i => i.Name == itemName);

            if(item == null)
            {
                throw new PackingItemNotFoundException(itemName);
            }

            return item;
        }
    }
}
