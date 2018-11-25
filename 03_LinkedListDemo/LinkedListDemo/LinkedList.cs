using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDemo
{
    class Node
    {
        public int data;
        public Node next;
        public Node random;
    }
    partial class LinkedList
    {
        public static Node Insert(Node head, int data)
        {
            if (head == null)
            {
                Node newNode = new Node();
                newNode.data = data;
                return newNode;
            }
            else
            {
                Node newNode = new Node();
                newNode.data = data;
                newNode.next = head;
                return newNode;
            }
        }

        public static void PrintLL(Node head)
        {
            Node cur = head;
            while (cur != null)
            {
                Console.Write(cur.data + "(" + cur.random.data + ")" +  "-->");
                cur = cur.next;
            }
        }

        public static Node RemoveFrmLL(Node head, int keyToDelete)
        {
            Node prvNode = null;
            Node cur = head;
            while (cur != null)
            {
                // I have some node to process
                if (cur.data == keyToDelete)
                {
                    if (prvNode != null)
                    {
                        prvNode.next = cur.next;
                        // I have not covered the case when prvNode can be null
                        // when head is to be deleted
                    }
                    else
                    {
                        // head needs to be deleted
                        head = cur.next;
                    }
                    break;
                }
                else
                {
                    prvNode = cur;
                    cur = cur.next;
                }
            }
            return head;
        }

        public static Node InsertAtEnd(Node head, Node toInsert)
        {
            Node cur = null;
            for (cur = head; cur != null && cur.next != null; cur = cur.next) ;
            if (cur != null)
            {
                cur.next = toInsert;    // Can cur be null
            }
            else
            {
                // it means that my list was empty 
                head = toInsert;
            }
            return head;
        }

        public static Node ReverseLLRecursive(Node head)
        {
            if (head == null || head.next == null)
            {
                return head;
            }

            Node smallHead = ReverseLLRecursive(head.next); // recursion 
            head.next.next = head;
            head.next = null;
            //head.next = null;
            //smallHead = InsertAtEnd(smallHead, head);
            return smallHead;
        }

        public static Node ReverseLLIterative(Node head)
        {
            Node cur = head;
            Node prv = null;

            while (cur != null)
            {
                // I have some node(s) to process
                Node ahead = cur.next;
                cur.next = prv;
                prv = cur;
                cur = ahead;
            }
            // loop will exit when cur is null
            // prev will be pointing to the last node which is my head
            return prv;
        }

        public static bool DetectCycle(Node head)
        {
            Node slow = head;
            Node fast = head;
            while (slow != null && /* I am being verbose */
                   fast != null &&
                   fast.next != null)
            {
                slow = slow.next;
                fast = fast.next.next;
                //if (slow == fast) return true;
                if (slow == fast)
                {
                    // cycle detected
                    slow = head;
                    while(slow.next != fast.next)
                    {
                        slow = slow.next;
                        fast = fast.next;
                    }
                    fast.next = null;
                    return true;
                }
            }
            return false;
        }
    }

    class LinkedListTest
    {
        public static void LLMain()
        {
            Node head = null;
            head = LinkedList.Insert(head, 1);
            head = LinkedList.Insert(head, 2);
            head = LinkedList.Insert(head, 3);
            //LinkedList.PrintLL(head);
            //Console.WriteLine();

            //head = LinkedList.RemoveFrmLL(head, 3);
            //LinkedList.PrintLL(head);
            //Console.WriteLine();

            //head = LinkedList.ReverseLLRecursive(head);
            //head = LinkedList.ReverseLLIterative(head);
            //LinkedList.PrintLL(head);

            //head.next.next.next = head.next;

            //var ans = LinkedList.DetectCycle(head);
            //Console.WriteLine(ans);
            //LinkedList.PrintLL(head);

            head.random = head.next.next;
            head.next.random = head;
            head.next.next.random = head;
            LinkedList.PrintLL(head);
            Console.WriteLine();
            Node clone = LinkedList.CloneLL(head);
            LinkedList.PrintLL(clone);
        }
    }
}
