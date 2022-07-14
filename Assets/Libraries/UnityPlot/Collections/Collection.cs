using System;
using System.Collections;
using System.Collections.Generic;

namespace UnityPlot.Core
{
    public abstract class Collection<T> : IEnumerable<T>
    {
        public T this[int index]
        {
            get
            {
                if (index >= Count)
                    throw new IndexOutOfRangeException();
                return array[index];
            }
        }
        public int Count { get; private set; }

        protected T[] array;

        public Collection()
        {
            array = new T[1];
            Count = 0;
        }

        public virtual void Add(T value)
        {
            if (Count >= array.Length)
                Array.Resize(ref array, 2 * array.Length);

            array[Count] = value;
            Count += 1;
        }

        public void Clear()
        {
            Count = 0;
        }

        public virtual void RemoveLast()
        {
            if (Count > 0)
                Count -= 1;
        }

        public List<T> FindAll(Predicate<T> match)
        {
            if (Count == 0)
                return new List<T>();
            return new List<T>(Array.FindAll(array, match));
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new CollectionEnumerator(array, Count);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new CollectionEnumerator(array, Count);
        }

        #region CollectionEnumerator
        private class CollectionEnumerator : IEnumerator<T>
        {
            private int index;
            private int count;
            private T[] array;

            public CollectionEnumerator(T[] array, int count)
            {
                this.array = array;
                this.count = count;
                index = -1;
            }

            public object Current
            {
                get { return array[index]; }
            }

            T IEnumerator<T>.Current
            {
                get { return array[index]; }
            }

            public void Dispose() { }

            public bool MoveNext()
            {
                if (index >= count - 1)
                    return false;

                index += 1;
                return true;
            }

            public void Reset()
            {
                index -= 1;
            }
        }
        #endregion
    }
}
