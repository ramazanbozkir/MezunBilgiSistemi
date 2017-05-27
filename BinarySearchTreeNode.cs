using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MezunBilgiSistemi
{
    public class BinarySearchTreeNode
    {
        public Person Data;
        public BinarySearchTreeNode Left;
        public BinarySearchTreeNode Right;
        public BinarySearchTreeNode()
        {

        }
        public BinarySearchTreeNode(Person Data)
        {
            this.Data = Data;
            Left = null;
            Right = null;
        }
    }
}
