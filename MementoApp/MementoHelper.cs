using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoApp
{
    public class MementoHelper
    {
        private readonly Stack<Memento> mementoStack = new();
        private readonly Queue<Memento> mementoQueue = new();

        public void Add(Memento state)
        {
            mementoStack.Push(state);
            Console.WriteLine($"Memento state saved at {DateTime.Now.ToShortDateString()} at {DateTime.Now.ToShortTimeString()}");
        }

        public void AddQueue(Memento state)
        {
            mementoQueue.Enqueue(state);
        }

        public Memento PullQueue()
        {
            return mementoQueue.Dequeue();
        }

        public Memento GetMemento()
        {
            return mementoStack.Pop();
        }
    }
}
