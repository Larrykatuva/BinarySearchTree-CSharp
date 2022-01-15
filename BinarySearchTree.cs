using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeCustom
{
    class BinarySearchTree<T> where T: IComparable<T>
    {
        public BinaryTree<T> root;

        public BinarySearchTree()
        {
            this.root = null;
        }

        public void Insert(T value)
        {
            this.root = Insert(value, null, this.root);
        }

        // Value to insert is value
        // parentNode is current of the tree
        // node is the node to be inserted
        private BinaryTree<T> Insert(T value, BinaryTree<T> parentNode, BinaryTree<T> node)
        {
            if(node == null)
            {
                node = new BinaryTree<T>(value);
                node.parent = parentNode;
            }
            else
            {
                int compareTo = value.CompareTo(node.value);
                if(compareTo < 0)
                {
                    node.leftChild = Insert(value, node, node.leftChild);
                }
                else if(compareTo > 0)
                {
                    node.rightChild = Insert(value, node, node.rightChild);
                }
            }
            return node;
        }

        private BinaryTree<T> Find(T value)
        {
            BinaryTree<T> currentNode = this.root;
            while(currentNode != null)
            {
                int compareTo = value.CompareTo(currentNode.value);
                if(compareTo < 0)
                {
                    currentNode = currentNode.leftChild;
                }
                else if(compareTo > 0)
                {
                    currentNode = currentNode.rightChild;
                }
                else
                {
                    break;
                }
            }
            return currentNode;
        }

        public bool Contains(T value)
        {
            return this.Find(value) != null;
        }

        public void Remove(T value)
        {
            BinaryTree<T> nodeToRemove = this.Find(value);
            if(nodeToRemove != null)
            {
                this.Remove(nodeToRemove);
            }
        }

        private void Remove(BinaryTree<T> nodeToRemove)
        {
            // If the nodeToRemove has two children
            if(nodeToRemove.leftChild != null && nodeToRemove.rightChild != null)
            {
                BinaryTree<T> replacement = nodeToRemove.rightChild;
                while(replacement.leftChild != null)
                {
                    replacement = replacement.leftChild;
                }
                nodeToRemove.value = replacement.value;
                nodeToRemove = replacement;
            }

            // If the nodeToRemove has one child
            BinaryTree<T> theChild = nodeToRemove.leftChild != null ? nodeToRemove.leftChild : nodeToRemove.rightChild;
            if(theChild != null)
            {
                theChild.parent = nodeToRemove.parent;
                if(nodeToRemove.parent == null)
                {
                    this.root = theChild;
                }
                else
                {
                    if(nodeToRemove.parent.leftChild == nodeToRemove)
                    {
                        nodeToRemove.parent.leftChild = theChild;
                    }
                    else
                    {
                        nodeToRemove.parent.rightChild = theChild;
                    }
                }
            }
            else
            {
                if(nodeToRemove.parent == null)
                {
                    this.root = null;
                }
                else
                {
                    if(nodeToRemove.parent.leftChild == nodeToRemove)
                    {
                        nodeToRemove.parent.leftChild = null;
                    }
                    else
                    {
                        nodeToRemove.parent.rightChild = null;
                    }
                }
            }
        }

        public void PrintTreeDFS()
        {
            this.PrintDFS(this.root);
            Console.WriteLine();
        }
    
        private void PrintDFS(BinaryTree<T> treeNode)
        {
            if(treeNode != null)
            {
                this.PrintDFS(treeNode.leftChild);
                Console.WriteLine(treeNode.value + " ");
                this.PrintDFS(treeNode.rightChild);
            }
        }
    }
}
