using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;

namespace DAL
{
    
    public class Objects:Container
    {
        public static int[] array { get; set; }
        public static int res_search;

        public Objects(int size)
        {
            array = new int[size];
        }

        public Objects()
        {

        }
        
        public Iterator getIterator()
        {
            return new intIterator();
        }

        public static bool Add()
        {
            return true;
        }

        public static bool Del()
        {
            return true;
        }
        
        static void Main(string[] args)
        {

        }

        //public int[] Bubble_Sort()
        //{
        //    array = BLL.Sorts.Bubble_Sort(array);
        //    return array;
        //}

        //public int[] Choise_Sort()
        //{
        //    array = BLL.Sorts.Choise_Sort(array);
        //    return array;
        //}

        //public int[] Insert_Sort()
        //{
        //    array = BLL.Sorts.Insert_Sort(array);
        //    return array;
        //}

        //public int[] Shell_Sort()
        //{
        //    array = BLL.Sorts.Shell_Sort(array);
        //    return array;
        //}

        //public int[] Quick_Sort()
        //{
        //    array = BLL.Sorts.Quick_Sort(array,0,array.Length-1);
        //    return array;
        //}

        ////-------------------------------------------------------

        //public bool Lin_Search(int key)
        //{
        //    bool find = BLL.Search_s.Lin_Search(array,key);
        //    return find;
        //}

        //public bool Bin_Search(int key)
        //{
        //    bool find = BLL.Search_s.Bin_Search(array, key);
        //    return find;
        //}

        //public bool Interpolation_Search(int key)
        //{
        //    bool find = false;
        //    int rez = BLL.Search_s.Inter_Search(array, key);
        //    if (rez!=-1)
        //    {
        //        find = true;
        //    }
        //    return find;
        //}
    }
}
