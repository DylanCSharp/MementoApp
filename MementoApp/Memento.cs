using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoApp
{
    public class Memento
    {
        public Memento(string state)
        {
            State = state;
        }

        public string State { get; set; }
    }
}
