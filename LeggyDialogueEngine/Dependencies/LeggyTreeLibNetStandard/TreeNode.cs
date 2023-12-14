using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;

namespace LeggyTreeLib
{
    public class TreeNode<T> : ITreeNode<T>
    {
        protected List<ITreeNode<T>> _children = new List<ITreeNode<T>>();
        public ITreeNode<T>[] Children 
        {
            get
            {
                return _children.ToArray();
            }
        }

        protected ITreeNode<T>? _parent;
        public ITreeNode<T>? Parent
        {
            get
            {
                return _parent;
            }
        }
        protected T _value;
        public T Value
        {
            get { return _value; }
        }

        public TreeNode(T value)
        {
            _value = value;
        }

        public TreeNode(T value, ITreeNode<T> parent)
        {
            _value = value;
            _parent = parent;
        }

        virtual public void AddChild(T child)
        {
            _children.Add(new TreeNode<T>(child, this));
        }

        public T[] ToArray()
        {
            T[] output = new T[1] { Value };
            foreach (var child in _children)
            {
                output = output.Concat(child.ToArray()).ToArray();
            }
            return output;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T item in ToArray())
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool RemoveChild(ITreeNode<T> child)
        {
            return _children.Remove(child);
        }

        public ITreeNode<T>[] ToNodeArray()
        {
            ITreeNode<T>[] array = new TreeNode<T>[1]{ this };
            foreach (ITreeNode<T> child in _children)
            {
                array = array.Concat(child.ToNodeArray()).ToArray();
            }

            return array;
        }

    }
}
