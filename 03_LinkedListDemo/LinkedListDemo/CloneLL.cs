using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedListDemo
{
    partial class LinkedList
    {
        public static Node CloneJustNext(Node head)
        {
            Node cloneHead = null;
            Node cloneTail = null;
            Node cur = head;
            while(cur != null)
            {
                Node tmp = new Node();
                tmp.data = cur.data;
                if (cloneHead == null)
                {
                    // clone is empty
                    cloneHead = tmp;
                }
                else
                {
                    cloneTail.next = tmp;
                }
                cloneTail = tmp;
                cur = cur.next;
            }
            return cloneHead;
        }

        public static Node CloneLL(Node head)
        {
            Node clone = CloneJustNext(head);
            // 3, 2, 1      head
            // 3', 2', 1'   clone

            // just need to set random pointers/refernces
            Dictionary<Node, Node> map = new Dictionary<Node, Node>(); // 2, 2'
            Node curMain = head;
            Node curClone = clone;
            while(curMain != null)
            {
                map[curMain] = curClone;
                curClone = curClone.next;
                curMain = curMain.next;
            }

            // now set the randoms
            curMain = head;
            curClone = clone;
            while(curMain != null)
            {
                curClone.random = map[curMain.random];  // 1, 1'
                curMain = curMain.next;
                curClone = curClone.next;
            }
            return clone;
        }
    }
}
