using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    public class GenericHeap<T> where T : IComparable<T>
    {
        private T[] _arr;
        private int _lastIdx;

        private int Left(int idx) { return idx * 2; }
        private int Right(int idx) { return idx * 2 + 1; }
        private int Parent(int idx) { return idx / 2; }

        private void Swap(ref T a, ref T b)
        {
            T tmp = a;
            a = b;
            b = tmp;
        }

        public GenericHeap()
        {
            _arr = new T[100];
            _lastIdx = 0;
        }

        public void Add(T element)
        {
            _lastIdx++;
            _arr[_lastIdx] = element;
            int idx = _lastIdx;
            while (Parent(idx) > 0 && _arr[Parent(idx)].CompareTo(_arr[idx]) > 0)
            {
                // _arr[Parent(idx)] > _arr[idx]: if parent is greater than child, swap 
                Swap(ref _arr[Parent(idx)], ref _arr[idx]);
                idx = Parent(idx);
            }
        }

        public T Peek()
        {
            if (_lastIdx == 0) return default(T);  // invalid value because my heap is empty
            return _arr[1];
        }

        public void Pop()
        {
            if (_lastIdx == 0) return;  // invalid value because my heap is empty
            Swap(ref _arr[1], ref _arr[_lastIdx]);
            _lastIdx--;
            Heapify(1);
        }

        private void Heapify(int idx)
        {
            int minIdx = idx;
            if (Left(idx) <= _lastIdx && _arr[Left(idx)].CompareTo(_arr[minIdx]) < 0)
            {
                // _arr[Left(idx)] < _arr[minIdx] : if left is smaller than minIdx
                minIdx = Left(idx);
            }

            if (Right(idx) <= _lastIdx && _arr[Right(idx)].CompareTo(_arr[minIdx]) < 0)
            {
                minIdx = Right(idx);
            }
            if (idx != minIdx)
            {
                Swap(ref _arr[minIdx], ref _arr[idx]);
                Heapify(minIdx);
            }

        }
    }

    public class Elephant : IComparable<Elephant>
    {
        int weight { get; set; }
        string name { get; set; }

        public Elephant(string name, int w)
        {
            this.name = name;
            weight = w;
        }

        public int CompareTo(Elephant other)
        {
            if (this.weight > other.weight)
            {
                return -1;  // Jiska weight is greater that has the higher priority
            }
            else
            {
                return 1;
            }
        }

        public void print()
        {
            Console.WriteLine("{0} {1}", name, weight);
        }
    }

    public class TestGenericHeap
    {
        public static void MyMain()
        {
            //GenericHeap<string> h = new GenericHeap<string>();
            //h.Add("5");                         // 5 4 32 -100
            //h.Add("4");
            //h.Add("32");
            //Console.WriteLine(h.Peek());        // 4        32
            //h.Pop();
            //Console.WriteLine(h.Peek());        // 5        4
            //h.Pop();
            //h.Add("-100");                      // -100    - is < 5 then -100 
            //Console.WriteLine(h.Peek());

            GenericHeap<Elephant> pq = new GenericHeap<Elephant>();
            Elephant e1 = new Elephant("Jumbo", 100);
            Elephant e2 = new Elephant("Rani", 200);
            Elephant e3 = new Elephant("Jack", 150);
            pq.Add(e1);
            pq.Add(e2);
            pq.Add(e3);
            pq.Peek().print();
            pq.Pop();
            pq.Peek().print();

        }
    }

}
