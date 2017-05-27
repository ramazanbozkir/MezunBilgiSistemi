using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class Heap
    {
        public HeapNode[] heapArray;
        private int maxSize;
        public int currentSize { get; private set; }
        public Heap(int maxHeapSize)
        {
            maxSize = maxHeapSize;
            currentSize = 0;
            heapArray = new HeapNode[maxSize];
        }
        public bool IsEmpty()
        {
            return currentSize == 0;
        }
        public bool Insert(Person Value)
        {
            if (currentSize == maxSize)
                return false;
            HeapNode newHeapNode= new HeapNode(Value);
            heapArray[currentSize] = newHeapNode;
            MoveToUp(currentSize++);
            return true;
        }
        public void MoveToUp(int index)
        {
            int parent = (index - 1) / 2;
            HeapNode bottom = heapArray[index];

            while (index > 0 && (heapArray[parent].Value.Name).CompareTo(bottom.Value.Name) < 0)//çevirmek
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;
            }
            heapArray[index] = bottom;
        }
        public HeapNode Remove(int index) 
        {
            HeapNode root = heapArray[index];
            heapArray[index] = heapArray[--currentSize];
            MoveToDown(index);
            return root;
        }
        public void MoveToDown(int index)
        {
            int largerChild;
            HeapNode top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if (rightChild < currentSize && (heapArray[leftChild].Value.Name).CompareTo(heapArray[rightChild].Value.Name) > 0)
                    largerChild = rightChild;
                else
                    largerChild = leftChild;
                if ((top.Value.Name).CompareTo(heapArray[largerChild].Value.Name) <= 0)
                    break;
                heapArray[index] = heapArray[largerChild];
                index = largerChild;
            }
            heapArray[index] = top;
        }
        
        public bool ControlApplication(Person person)
        {
            bool control = false;
            for (int m = 0; m < currentSize; m++)
            {
                if (heapArray[m] != null)
                {
                    if (person == heapArray[m].Value)
                    {
                        control = true;
                        break;
                    }
                }
            }
            return control;
        }
        public void RemovePerson(string NamePerson)
        {
            int m;
            for (m = 0; m < currentSize; m++)
            {
                if (heapArray[m] != null)
                {
                    if (NamePerson == heapArray[m].Value.Name)
                        break;
                }
            }
            Remove(m);
        }
    }
}
