using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Handler_For_Sorts
    {
        public Handler_For_Sorts Successor { get; set; }
        public abstract void HandleRequest(int request);
    }
}
