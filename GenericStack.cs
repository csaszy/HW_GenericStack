using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_GenericStack
{
    public class GenericStack<T>
    {
        private List<T> elements = new List<T>();
        public void Push(T item)
        {
            elements.Add(item);
        }
        public T Pop()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            T item = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return item;
        }
        public T Peek()
        {
            if (elements.Count == 0)
            {
                throw new InvalidOperationException("The stack is empty.");
            }
            return elements[elements.Count - 1];
        }
        public bool IsEmpty()
        {
            return elements.Count == 0;
        }

        public Stack<T> slice(int start, int end)
        {
            //handling invalid input
            if(end <= start) throw new InvalidOperationException("End must be bigger than start");
            if(end < 0 || end >= this.elements.Count) throw new InvalidOperationException("End is out of range");
            if(start < 0 || start >= this.elements.Count) throw new InvalidOperationException("Start is out of range");

            //main stuff
            var stack = new Stack<T>();
            for (int i = start; i < end; i++)
            {
                stack.Push(elements[i]);
            }
            return stack;
        }
        public GenericStack<T> splice(int start, int count, IEnumerable<T> items)
        {
            var stack = new GenericStack<T>();
            this.elements.ForEach(e => { stack.Push(e); }); 
            stack.elements.RemoveRange(start, count);
            stack.elements.InsertRange(start, items);
            return stack;
        }
        public T shift()
        {
            if (this.IsEmpty()) throw new Exception();

            T temp = this.elements[0];
            this.elements.RemoveAt(0);
            return temp;
        }
        public void unshift(T item)
        {
            this.elements.Insert(0, item);
        }

        //for debugging purposes
        public override string ToString()
        {
            return string.Join("\t", this.elements);
        }
    }
}
