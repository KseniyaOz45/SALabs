using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public abstract class Handler_For_Search
    {
        public Handler_For_Search Successor { get; set; }
        public abstract void HandleRequest(int request,int key);
    }
}
