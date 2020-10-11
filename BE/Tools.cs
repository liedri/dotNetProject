using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public static class Tools
    {
        public static string ToStringProperty<T>(this T t)
        {
            string str = "";
            foreach (PropertyInfo item in t.GetType().GetProperties())
                str += /*"\n" +*/ item.Name + ":" + item.GetValue(t, null) + "\n";
            return str;
        }
        public static T[] Flatten<T>(this T[,] arr)
        {
            int rows = arr.GetLength(0);
            int columns = arr.GetLength(1);
            T[] arrFlattened = new T[rows * columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns ; j++)

                {
                    var v = arr[i, j];
                    arrFlattened[i * rows + j] = arr[i, j];
                }
            }
            return arrFlattened;
        }

        public static T[,] Expand<T>(this T[] arr, int rows)
        {
            int lenght = arr.GetLength(0);
            int columns = lenght / rows;
            T[,] arrExpand = new T[rows, columns];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    arrExpand[i, j] = arr[i * rows + j];
                }
            }
            return arrExpand;
        }

        //public static T[] Flatten<T>(this T[,] arr)
        //{
        //    int rows = arr.GetLength(0);
        //    int columns = arr.GetLength(1);
        //    T[] arrFlattened = new T[rows * columns];
        //    for (int j = 0; j < rows; j++)
        //    {
        //        for (int i = 0; i < columns; i++)
        //        {
        //            var v = arr[i, j];
        //            arrFlattened[i * rows + j] = arr[i, j];
        //        }
        //    }
        //    return arrFlattened;
        //}

        //public static T[,] Expand<T>(this T[] arr, int rows)
        //{
        //    int lenght = arr.GetLength(0);
        //    int columns = lenght / rows;
        //    T[,] arrExpand = new T[rows, columns];
        //    for (int j = 0; j < rows; j++)
        //    {
        //        for (int i = 0; i < columns; i++)
        //        {
        //            arrExpand[i, j] = arr[i * rows + j];
        //        }
        //    }
        //    return arrExpand;
        //}
    }
}