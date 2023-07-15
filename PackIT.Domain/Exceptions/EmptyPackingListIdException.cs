using PackIT.SharedAbstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    internal class EmptyPackingListIdException : PackItException
    {
        public EmptyPackingListIdException() : base("Packing list id can not be empty!")
        {
        }
    }
}
