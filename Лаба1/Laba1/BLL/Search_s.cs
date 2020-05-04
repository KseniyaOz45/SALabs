using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Search_s
    {
        static void Main(string[] args)
        {

        }
        public int Lin_Search(int[] array, int bs)
        {
            int rez = 0;
            if (bs == 1)
            {
                int min = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] < min) min = array[i];
                }
                rez = min;
            }
            else if (bs == 2)
            {
                int max = array[0];
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] > max) max = array[i];
                }
                rez = max;
            }
            return rez;
        }

        public int Bin_Search(int[] array, int bs)
        {
            //int l = 0;
            //int r = array.Length - 1;
            //int middle;
            //int find = 0;

            //for (int i = 0; i < array.Length; i++)
            //{
            //    middle = (l + r) / 2;
            //    if (array[middle] == key)
            //    {
            //        find = array[middle];
            //        return find;
            //    }
            //    if (array[middle] > key)
            //        r = middle - 1;
            //    else l = middle + 1;
            //}
            int rez = 0;
            if (bs == 1)
                rez = array[0];
            else if (bs == 2)
                rez = array[array.Length-1];
            return rez;

        }

        public int Inter_Search(int[] array, int bs)
        {
            //int middle, l = 0, r = array.Length - 1;
            //while (array[l] <= key && array[r] >= key)
            //{
            //    middle = l + ((key - array[l]) * (r - l)) / (array[r] - array[l]);
            //    if (array[middle] < key)
            //        l = middle + 1;
            //    if (array[middle] > key)
            //        r = middle - 1;
            //    else
            //        return middle;
            //}
            //if (array[l] == key)
            //{
            //    return l;
            //}
            //else
            //    return -1;
            int rez = 0;
            if (bs == 1)
                rez = array.Min();
            else if (bs == 2)
                rez = array.Max();
            return rez;
        }

    }
}
