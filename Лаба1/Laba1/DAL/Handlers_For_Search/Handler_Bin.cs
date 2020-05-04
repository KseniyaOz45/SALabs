using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL.Handlers_For_Search
{
    public class Handler_Bin : Handler_For_Search
    {

        Search_s search_ = new Search_s();

        public override void HandleRequest(int request, int key)
        {
            if (request == 2)
            {
                int res = search_.Bin_Search(Objects.array, key);
                Objects.res_search = res;
            }
            else if (Successor != null)
            {
                Successor.HandleRequest(request, key);
            }
            //return res;
        }
    }
}
