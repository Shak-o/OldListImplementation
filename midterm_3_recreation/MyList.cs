using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace midterm_3_recreation
{
    public class MyList<T> : IEnumerable<T>
    {

        private T[] array = new T[0];

        private int _counter = 0;

        public int Counter
        {
            get
            {
                return _counter;
            }
        }

        public T this[int index]
        {
            get
            {
                if (index > array.Length)
                {
                    throw new MyListExceptions("index is out of range");
                }
                else
                {
                    return array[index];
                }
            }

            set
            {
                if (value == null)
                {
                    var exc = new MyListExceptions("value is null ");
                    Console.WriteLine(exc.StackTrace);
                    throw exc;
                }
                else
                {
                    try
                    {
                        array[index] = (T) value;
                    }
                    catch
                    {
                        throw new MyListExceptions("not compatible type");
                    }
                }
            }
        }

        private bool TypeCheck(object item)
        {
            return ((item is T) || (item == null && default(T) == null));
        }

        public void Add(T item)
        {
            if (!TypeCheck(item)) return;

            int len = array.Length + 1;
            T[] updatedArray = new T[len];
            for (int i = 0; i < array.Length; i++)
            {
                updatedArray[i] = array[i];
            }

            updatedArray[len - 1] = item;
            array = updatedArray;
            _counter += 1;
        }

        public void Remove(T item)
        {
            
            T[] updatedArray = new T[array.Length - 1];
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if ((object)item != (object)array[i])
                {
                    updatedArray[counter] = array[i];
                    counter++;
                }
            }

            array = updatedArray;
            _counter = counter;
        }

        public void Remove(Func<T, bool> func)
        {
            int counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!func.Invoke(array[i]))
                {
                    counter++;
                }
            }
            T[] updatedArray = new T[counter];
            counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (!func.Invoke(array[i]))
                {
                    updatedArray[counter] = array[i];
                    counter++;
                }
            }

            _counter = counter;
            array = updatedArray;
        }

        public void AddRange(T[] items)
        {
            int len = array.Length + items.Length;
            T[] updatedArray = new T[len];
            for (int i = 0; i < array.Length; i++)
            {
                updatedArray[i] = array[i];
            }

            for (int i = 0; i < items.Length; i++)
            {
                updatedArray[array.Length +i] = items[i];
            }

            array = updatedArray;
        }

        public void RemoveRange(int index, int count)
        {
            T[] updatedArray = new T[array.Length-count];
            int localCount = 0;
            int skipsCount = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i <= index)
                {
                    updatedArray[i] = array[i];
                    localCount++;
                }
                else if (i > index && skipsCount >= count)
                {
                    updatedArray[localCount] = array[i];
                    localCount++;
                    skipsCount++;
                }
                else
                {
                    skipsCount++;
                }
            }

            _counter = updatedArray.Length;
            array = updatedArray;
        }

        public T[] Where(Func<T, bool> predicate)
        {
            int updatedLength = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    updatedLength++;
                }
            }

            int itemCount = 0;
            T[] updatedArray = new T[updatedLength];
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    updatedArray[itemCount] = array[i];
                    itemCount++;
                }
            }

            _counter = updatedLength;
            return updatedArray;

        }

        public T Single(Func<T, bool> predicate)
        {
            int count = 0;
            T itemFound = default(T);
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    count++;
                    itemFound = array[i];
                }
            }

            if (count > 1)
            {
                throw new Exception("found more than one item with that options");
            }
            else
            {
                return itemFound;
            }
        }

        public T SingleOrDefault(Func<T, bool> predicate)
        {
            int count = 0;
            T itemFound = default(T);
            for (int i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                {
                    count++;
                    itemFound = array[i];
                }
            }

            if (count > 1)
            {
                throw new Exception("found more than one item with that options");
            }
            else if (count == 0)
            {
                return itemFound;
            }
            else
            {
                return itemFound;
            }
        }

        public IEnumerator<T> GetEnumerator()
         {
            for (int i = 0 ; i < array.Length; i++)
            {
                yield return array[i];
            }
         }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
