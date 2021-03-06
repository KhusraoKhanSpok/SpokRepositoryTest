using System;
using System.Collections.Generic;
using System.Text;

namespace Utilities
{
    /// <summary>
    /// Methods to manipulate arrays.
    /// </summary>
    public static class ArrayUtilities
    {
        /// <summary>
        /// Gets the list from enumerable.
        /// </summary>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns></returns>
        public static List<T> GetListFromEnumerable<T>(IEnumerable<T> enumerable)
        {
            List<T> result = new List<T>();
            foreach (T t in enumerable)
            {
                result.Add(t);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <returns></returns>
        public static T[] ConvertToArray<T>(ICollection<T> list)
        {
            if (list == null)
            {
                return null;
            }
            T[] result = new T[list.Count];
            list.CopyTo(result, 0);
            return result;
        }

        /// <summary>
        /// Appends the list.
        /// </summary>
        /// <param name="destination">The destination.</param>
        /// <param name="list">The list.</param>
        public static void AppendList<T>(IList<T> destination, IList<T> list)
        {
            List<T> shortcut = destination as List<T>;
            if (shortcut != null)
            {
                shortcut.AddRange(list);
            }
            else
            {
                foreach (T t in list)
                {
                    destination.Add(t);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        /// <param name="insert">The insert.</param>
        /// <returns></returns>
        public static T[] InsertReplace<T>(T[] array, int index, T[] insert)
        {
            int newLength = array.Length + insert.Length - 1;
            Array.Resize<T>(ref array, newLength);
            // Shift all the elements from the index up to the end
            int offset = (insert.Length - 1);
            for (int i = array.Length - 1; i >= index; i--)
            {
                if (i - offset < 0)
                {
                    break;
                }
                array[i] = array[i - offset];
            }

            // Now put all the insert elements starting at index
            for (int j = 0; j < insert.Length; j++)
            {
                array[index++] = insert[j];
            }
            return array;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public static T[] Remove<T>(ref T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            else if (index < 0 || index >= array.Length)
            {
                throw new IndexOutOfRangeException("Cannot remove element at index " + index);
            }

            // Crush the elemnts from the end down to the index
            for (int i = index; i < array.Length - 1; i++)
            {
                array[i] = array[i + 1];
            }

            Array.Resize<T>(ref array, array.Length - 1);
            return array;
        }

        /// <summary>
        /// Adds the item.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="val">The val.</param>
        public static void AddItem<T>(ref T[] list, T val)
        {
            Array.Resize<T>(ref list, list.Length + 1);
            list[list.Length - 1] = val;
        }

        /// <summary>
        /// Removes the duplicates.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <returns></returns>
        public static int RemoveDuplicates<T>(IList<T> list)
        {
            return RemoveDuplicates<T>(list, null);
        }

        /// <summary>
        /// Removes the duplicates. <paramref name="comparison"/> is optional and defaults
        /// to <see cref="Utilities.GenericUtilities.EqualsComparison"/>
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns></returns>
        public static int RemoveDuplicates<T>(IList<T> list, Comparison<T> comparison)
        {
            if (list == null)
            {
                throw new ArgumentNullException("list");
            }
            if (comparison == null)
            {
                comparison = GenericUtilities.EqualsComparison<T>;
            }

            int numRemoved = 0;
            // Iterate over the entire list, checking the rest of the list for matches,
            // which are removed
            for (int i = 0; i < list.Count; i++)
            {
                for (int j = i + 1; j < list.Count; j++)
                {
                    if (comparison(list[i], list[j]) == 0)
                    {
                        // They are the same, so remove them
                        list.RemoveAt(j);
                        j--;
                        numRemoved++;
                    }
                }
            }
            return numRemoved;
        }
    }
}
