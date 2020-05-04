using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL.Handlers_For_Sorts
{
    public class Handler_Quick : Handler_For_Sorts
    {
        //Objects objects = new Objects();
        Sorts sorts = new Sorts();
        public override void HandleRequest(int request)
        {
            if (request == 5)
            {
                int[] rez = sorts.Quick_Sort(Objects.array,0,Objects.array.Length-1);
                Objects.array = rez;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(request);
            }
        }
    }
}
