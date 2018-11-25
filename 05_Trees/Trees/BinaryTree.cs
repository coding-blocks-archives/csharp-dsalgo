using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trees
{
    class TreeNode
    {
        public int data;
        public TreeNode left;
        public TreeNode right;
        public TreeNode next;
        public TreeNode(int d)
        {
            data = d;
        }
    }

    class BinaryTree
    {
        public static TreeNode createTree()
        {
            Console.WriteLine("Enter the root");
            int rootVal = int.Parse(Console.ReadLine());
            if (rootVal != -1)
            {
                TreeNode root = new TreeNode(rootVal);
                // create the left subtree
                Console.WriteLine("Enter Left child of {0}", rootVal);
                root.left = createTree();
                Console.WriteLine("Enter right child of {0}", rootVal);
                root.right = createTree();
                return root;
            }
            else
            {
                return null;
            }
        }

        public static void Inorder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Inorder(root.left);
            Console.Write(root.data + ", ");
            Inorder(root.right);
        }

        public static TreeNode CreateTreeLevelWise()
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            int rootVal = int.Parse(Console.ReadLine());
            if (rootVal == -1) return null;
            TreeNode root = new TreeNode(rootVal);
            q.Enqueue(root);

            while(q.Count != 0)
            {
                TreeNode curParent = q.Dequeue();
                //Console.Write("Enter Left child of {0}", curParent.data);
                int leftChild = int.Parse(Console.ReadLine());
                if (leftChild != -1)
                {
                    TreeNode left = new TreeNode(leftChild);
                    curParent.left = left;
                    q.Enqueue(left);
                }
                //Console.Write("Enter Right child of {0}", curParent.data);
                int rightChild = int.Parse(Console.ReadLine());
                if (rightChild != -1)
                {
                    TreeNode right = new TreeNode(rightChild);
                    curParent.right = right;
                    q.Enqueue(right);
                }
            }
            return root;
        }

        public static void PrintLevelWise(TreeNode root)
        {
            Queue<TreeNode> q = new Queue<TreeNode>();
            if (root == null) return;
            const TreeNode MARKER = null;
            q.Enqueue(root);
            q.Enqueue(MARKER);
            while(q.Count != 0)
            {
                TreeNode curParent = q.Dequeue();
                if (curParent == MARKER)
                {
                    // time to print an enter
                    Console.WriteLine();
                    if (q.Count != 0)
                    {
                        // I have some more levels to process
                        q.Enqueue(MARKER);
                    }
                    continue;
                }
                
                Console.Write(curParent.data + "(");
                Console.Write(curParent.next == null ? -1 : curParent.next.data);
                Console.Write(") ");
                if (curParent.left != null)
                {
                    q.Enqueue(curParent.left);
                }
                if (curParent.right != null)
                {
                    q.Enqueue(curParent.right);
                }
            }
        }

        public static void ConnectLevels(TreeNode root)
        {
            if (root == null) return;
            Queue<TreeNode> q = new Queue<TreeNode>();
            const TreeNode MARKER = null;
            q.Enqueue(root);
            q.Enqueue(MARKER);
            while (q.Count != 0)
            {
                TreeNode curParent = q.Dequeue();
                if (curParent == MARKER)
                {
                    // time to print an enter
                    Console.WriteLine();
                    if (q.Count != 0)
                    {
                        // I have some more levels to process
                        q.Enqueue(MARKER);
                    }
                    continue;
                }
                //Console.Write(curParent.data + " ");
                curParent.next = q.Peek();
                if (curParent.left != null)
                {
                    q.Enqueue(curParent.left);
                }
                if (curParent.right != null)
                {
                    q.Enqueue(curParent.right);
                }
            }
        }

        public static void PrintRootToLeafPaths(TreeNode root, List<TreeNode> pathSoFar)
        {
            if (root == null)
            {
                return;
            }
            if (root.left == null && root.right == null)
            {
                pathSoFar.Add(root);
                foreach(var node in pathSoFar)
                {
                    Console.Write(node.data + " ");
                }
                Console.WriteLine();
                pathSoFar.RemoveAt(pathSoFar.Count - 1);
                return;
            }

            // it means root is not a leaf
            pathSoFar.Add(root);
            PrintRootToLeafPaths(root.left, pathSoFar);
            PrintRootToLeafPaths(root.right, pathSoFar);
            pathSoFar.RemoveAt(pathSoFar.Count - 1);
        }



        public static void MyMain()
        {
            //TreeNode root = createTree();
            TreeNode root = CreateTreeLevelWise();
            //Inorder(root);
            //ConnectLevels(root);
            //PrintLevelWise(root);

            List<TreeNode> pathSoFar = new List<TreeNode>();
            PrintRootToLeafPaths(root, pathSoFar);
        }
    }
}
