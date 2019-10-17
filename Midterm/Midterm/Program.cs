using System;

namespace Midterm
{
    class Program
    {
        static int[] array = { 0, 1, 1, 1, 0, -1, 1, -4, 10 };
        static string preOrder = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        static string inOrder = "EFDGIHCJKBLAMPQORNSUTZYXWV";

        static void Main(string[] args)
        {
            //Console.WriteLine("The array is ");
            //for (int i = 0; i < array.Length; i++)
            //{
            //    Console.Write("I[{0}]={1}", i, array[i]);
            //}

            //Console.WriteLine("Maximum consequtive integer is : ");

            //Console.ReadKey();
            //Console.Clear();
            //Console.WriteLine("InOrder is :" + inOrder);
            //Console.WriteLine("PreOrder is : " + preOrder);

            Node Tree = new Node(preOrder, inOrder, null);
            Console.ReadKey();
        }
    }

    public class Node
    {
        public Node Parent;
        public char character;
        public Node LeftNode;
        public Node RightNode;

        public Node(string preOrder, string inOrder, Node parent)
        {
            Parent = parent;
            character = preOrder[0];
            int CharIndexInOrder = inOrder.IndexOf(character);
            int SplitCharIndexPreOrder = 0;
            if (CharIndexInOrder == 0)
            {
                // Has no left child
            }
            else
            {
                char CharLeftOfInOrderSplit = inOrder[CharIndexInOrder - 1];
                SplitCharIndexPreOrder = preOrder.IndexOf(CharLeftOfInOrderSplit);
                LeftNode = new Node(preOrder.Substring(1, SplitCharIndexPreOrder), inOrder.Substring(0, CharIndexInOrder), this);
            }
            RightNode = new Node(preOrder.Substring(SplitCharIndexPreOrder + 1, preOrder.Length), inOrder.Substring(CharIndexInOrder + 1, inOrder.Length), this);
        }
    }
}