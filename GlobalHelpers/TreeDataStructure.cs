// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this

using System;
using System.Collections.Generic;

namespace GlobalHelpers
{
    public class Tree<T>
    {
        public Node<T> Root { get; }

        public Tree(T rootValue)
        {
            Root = new Node<T>(rootValue);
        }

        public void Add(T value)
        {
            if (Root.Left == null)
            {
                Root.Left = new Node<T>(value);
                return;
            }

            if (Root.Right == null)
            {
                Root.Right = new Node<T>(value);
                return;
            }
            
            var stack = new Stack<Node<T>>();
            stack.Push(Root.Left);
            stack.Push(Root.Right);

            while (stack.Count > 0)
            {
                var current = stack.Pop();
                if (current.Left == null)
                {
                    current.Left = new Node<T>(value);
                    return;
                }
                if (current.Right == null)
                {
                    current.Right = new Node<T>(value);
                    return;
                }
                stack.Push(current.Right);
                stack.Push(current.Left);
            }
        }
        
        public void Traverse(Node<T> node, Action<T> action)
        {
            if (node == null) return;

            action(node.Value);
            Traverse(node.Left, action);
            Traverse(node.Right, action);
        }
    }

    public class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T value)
        {
            Value = value;
            Left = null;
            Right = null;
        }
    }
}
