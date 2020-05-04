using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IObserver
    {
        int Update_PC(Object ob);
        int Update_Mobile(Object ob);
        int Update_Console(Object ob);
    }
}
