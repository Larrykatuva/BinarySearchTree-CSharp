using System;

namespace BinaryTreeCustom
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree<string> tree = new BinarySearchTree<string>();
            tree.Insert("Telerik");
            tree.Insert("Google");
            tree.Insert("Microsoft");
            tree.PrintTreeDFS(); // Google Microsoft Telerik
            Console.WriteLine(tree.Contains("Telerik")); // True
            Console.WriteLine(tree.Contains("IBM")); // False
            tree.Remove("Telerik");
            Console.WriteLine(tree.Contains("Telerik")); // False
            tree.PrintTreeDFS(); // Google Microsoft

        }
    }
}
