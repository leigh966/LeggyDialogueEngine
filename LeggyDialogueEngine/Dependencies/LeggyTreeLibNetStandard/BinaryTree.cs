using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeggyTreeLib
{
    public class BinaryTree
    {
        public BinaryNode? root = null;

        public bool Contains(int value)
        {
            if (root == null)
            {
                return false;
            }
            return root.CanFind(value);
        }

        public void Insert(int value)
        {
            if(root == null)
            {
                root = new BinaryNode(value);
                return;
            }
            root.AddChild(value);
        }
    }
}
