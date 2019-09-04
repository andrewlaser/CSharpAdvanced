using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public class MyList<T>
    {
        private T[] items;

        public int Count { get; private set; }
        public int Capacity { get; private set; }

        public T this[int index]
        {
            get { return items[index]; }
            set { items[index] = value; }
        }

        public MyList()
        {
            items = new T[2];
            Capacity = 2;
            Count = 0;
        }

        public void Add(T item)
        {
            if (Capacity == Count)
            {
                T[] clone = (T[]) items.Clone();
                Capacity *= 2;
                items = new T[Capacity];
                Array.Copy(clone, items, clone.Count());
            }
            items[Count] = item;
            Count++;
        }

        public void Remove(int index)
        {
            for (int i = index; i < Count-1; i++)
            {
                items[i] = items[i + 1];
            }
            Count--;
        }

        public override string ToString()
        {
            string res = String.Empty;
            for(int i = 0; i< Count; i++)
            {
                res = res + ", " + items[i];
            }
            return res;
        }

        public static MyList<T> operator +(MyList<T> l1, MyList<T>l2)
        {
            MyList<T> result = new MyList<T>();
            result.Capacity = l1.Capacity;
            result.Count = l1.Count;
            result.items = (T[])l1.items.Clone();
            foreach (var element in l2.items)
            {
                result.Add(element);
            }
            return result;
        }
    }
}
