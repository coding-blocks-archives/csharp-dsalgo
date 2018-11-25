using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heaps
{
    public class Heap
    {
        private int[] _arr;
        private int _lastIdx;

        private int Left(int idx) { return idx * 2; }
        private int Right(int idx) { return idx * 2 + 1; }
        private int Parent(int idx) { return idx / 2; }

        private void Swap(ref int a, ref int b)
        {
            int tmp = a;
            a = b;
            b = tmp;
        }

        public Heap()
        {
            _arr = new int[100];
            _lastIdx = 0;
        }

        public void Add(int element)
        {
            _lastIdx++;
            _arr[_lastIdx] = element;
            int idx = _lastIdx;
            while (Parent(idx) > 0 && _arr[Parent(idx)] > _arr[idx])
            {
                Swap(ref _arr[Parent(idx)], ref _arr[idx]);
                idx = Parent(idx);
            }
        }

        public int Peek()
        {
            if (_lastIdx == 0) return 1000000;  // invalid value because my heap is empty
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
            if (Left(idx) <= _lastIdx && _arr[Left(idx)] < _arr[minIdx])
            {
                minIdx = Left(idx);
            }

            if (Right(idx) <= _lastIdx && _arr[Right(idx)] < _arr[minIdx])
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

    public class TestHeap
    {
        public static void MyMain()
        {
            Heap h = new Heap();
            h.Add(5);
            h.Add(4);
            h.Add(32);
            Console.WriteLine(h.Peek());        // 4
            h.Pop();
            Console.WriteLine(h.Peek()); // 5
            h.Pop();
            h.Add(-100);     // -100
            Console.WriteLine(h.Peek());
        }
    }

}
