using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class intIterator:Iterator
    {
        public int index;

        public bool hasNext()
        {
            if (index<Objects.array.Length)
            {
                return true;
            }
            return false;
        }

        public int next()
        {
            if (this.hasNext())
            {
                return Objects.array[index++];
            }
            return 0;
        }
    }
}
