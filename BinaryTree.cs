using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCustom
{
    internal class BinaryTree<T>: IComparable<BinaryTree<T>> where T: IComparable<T>
    {
        public BinaryTree<T> parent;
        public BinaryTree<T> leftChild;
        public BinaryTree<T> rightChild;

        public T value;

        public BinaryTree(T value)
        {
            this.value = value;
            this.parent = null;
            this.leftChild = null;
            this.rightChild = null;
        }
        public override string ToString()
        {
            return this.value.ToString();
        }
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }
        public int CompareTo(BinaryTree<T> other)
        {
            return this.value.CompareTo(other.value);

        }
        public override bool Equals(object obj)
        {
            BinaryTree<T> other = (BinaryTree<T>)obj;
            return this.CompareTo(other) == 0;
        }
    }
}
