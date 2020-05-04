using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL
{
    public class Handler_Bubble:Handler_For_Sorts
    {
        //Objects objects = new Objects();
        Sorts sorts = new Sorts();
        public override void HandleRequest(int request)
        {
            if (request == 1)
            {
                int[] rez = sorts.Bubble_Sort(Objects.array);
                Objects.array = rez;
            }else if (Successor!=null)
            {
                Successor.HandleRequest(request);
            }
        }
    }
}
