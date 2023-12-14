using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeggyTreeLib
{
    public interface ITreeNode<T> : IEnumerable<T>
    {
        public ITreeNode<T>[] Children { get; }
        public ITreeNode<T>? Parent { get; }
        public T Value { get; }
        abstract public void AddChild(T child);
        public bool RemoveChild(ITreeNode<T> child);
        public T[] ToArray();

        public ITreeNode<T>[] ToNodeArray();
    }
}
