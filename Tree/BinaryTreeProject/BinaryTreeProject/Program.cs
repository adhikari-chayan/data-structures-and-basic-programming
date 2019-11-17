using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeProject
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryTree bt = new BinaryTree();
            bt.CreateTree();

            bt.Display();
            

            Console.WriteLine("Preorder Traversal: ");
            bt.Preorder();

            Console.WriteLine("Inorder Traversal: ");
            bt.Inorder();

            Console.WriteLine("Level order Traversal");
            bt.LevelOrder();

            Console.WriteLine($"Height of Tree is: {bt.Height()}");

            Console.ReadKey();
        }
    }
}
