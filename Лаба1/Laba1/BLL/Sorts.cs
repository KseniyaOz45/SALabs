using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Sorts
    {
        public int[] Bubble_Sort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] < array[i])
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        public int[] Choise_Sort(int[] array)
        {
            int temp, min;
            for (int i=0;i<array.Length;i++)
            {
                min = i;
                for (int j=i+1;j<array.Length;j++)
                {
                    if (array[j]<array[min])
                    {
                        min = j;
                    }
                }
                temp = array[i];
                array[i] = array[min];
                array[min] = temp;
            }
            return array;
        }

        public int[] Insert_Sort(int[] array)
        {
            int curr;
            for (int i=0;i<array.Length;i++)
            {
                curr = array[i];
                int j = i;
                while (j>0&&curr<array[j-1])
                {
                    array[j] = array[j - 1];
                    j--;
                }
                array[j] = curr;
            }
            return array;
        }

        public int[] Shell_Sort(int[] array)
        {
            int step, i, j;
            int temp;
            for (step = array.Length / 2; step > 0; step /= 2)
            {
                for (i = step; i < array.Length; i++)
                {
                    temp = array[i];
                    for (j = i; j >= step; j -= step)
                    {
                        if (temp < array[j - step])
                            array[j] = array[j - step];
                        else
                            break;
                    }
                    array[j] = temp;
                }
            }
            return array;
        }

        public int[] Quick_Sort(int[] array,int start,int end)
        {
            int i = start, j = end;
            int temp;
            int x = array[(start + end) / 2];

            do
            {
                while (array[i] < x)
                    i++;
                while (array[j] > x)
                    j--;

                if (i <= j)
                {
                    if (i < j)
                    {
                        temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < end)
                Quick_Sort(array, i, end);
            if (start < j)
                Quick_Sort(array, start, j);
            return array;
        }


    }
}
