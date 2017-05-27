using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class HeapNode
    {
        public Person Value { get; set; }
        public HeapNode(Person Value)
        {
            this.Value = Value;
        }
    }
}
