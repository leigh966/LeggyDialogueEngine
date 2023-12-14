using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LeggyTreeLib
{
    public class BinaryNode : TreeNode<int>
    {
        public BinaryNode(int value) : base(value) 
        {
            
        }
        public BinaryNode(int value, BinaryNode parent) : base(value, parent) { }

        private BinaryNode? _left = null, _right=null;
        public BinaryNode? Left
        {
            get
            {
                return _left;
            }
        }
        public BinaryNode? Right
        {
            get
            {
                return _right;
            }
        }

        private BinaryNode? leftOrRight(int value)
        {
            if (value < Value) return _left;
            if (value > Value) return _right;
            return null;
        }

        public bool CanFind(int value)
        {
            if(value == Value) return true;
            BinaryNode? nextNode = leftOrRight(value);
            if(nextNode == null) return false;
            return nextNode.CanFind(value);
        }

        public override void AddChild(int child)
        {
            if (child == Value) return;
            BinaryNode? nextNode = leftOrRight(child);
            if(nextNode == null)
            {
                BinaryNode newNode = new BinaryNode(child, this);
                _children.Add(newNode);
                if(child < Value)
                {
                    _left = newNode;
                }
                else if (child > Value)
                {
                    _right = newNode;
                }
                return;
            }
            nextNode.AddChild(child);
        }
    }
}
