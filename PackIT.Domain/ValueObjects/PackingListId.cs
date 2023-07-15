using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public record PackingListId
    {
        public Guid Value { get; }

        public PackingListId(Guid value)
        { 
            if(Value == Guid.Empty)
            {
                throw new EmptyPackingListIdException();
            }
            Value = value;
        }


        public static implicit operator Guid(PackingListId packingListName) => packingListName.Value;

        public static implicit operator PackingListId(Guid packingListName) => new(packingListName);
    }
}
