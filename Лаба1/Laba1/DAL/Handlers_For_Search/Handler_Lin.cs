using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL.Handlers_For_Search
{
    public class Handler_Lin : Handler_For_Search
    {
        //Objects objects = new Objects();
        Search_s search_ = new Search_s();
        public override void HandleRequest(int request,int key)
        {

            if (request == 1)
            {
                int rez = search_.Lin_Search(Objects.array,key);
                Objects.res_search = rez;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(request,key);
            }
            
            //return rez;
        }
    }
}
