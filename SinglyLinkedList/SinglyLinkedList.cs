using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinglyLinkedList
{
    internal class Node<T>
    {
        //ctor
        public Node(T item)
        {
          m_data = item;
        }

        public Node<T> m_next { get; set; }

        public T m_data { get; set; }
    }

    public class SinglyLinkedList<T>
    {
        Node<T> m_head { get; set; }
        Node<T> m_last { get; set; }
        int m_cnt { get; set; }

        public void Add(T item)
        {
            m_cnt++; //increment counter

            Node<T> tmp = new Node<T>(item); //create new node
            if(m_head == null)
            {
            //in case SSL is empty so far
            m_head = tmp;
            m_last = tmp;
            return;
            }

            //else append at the end
            m_last.m_next = tmp;
            m_last = tmp;
        }

        public bool Contains(T item)
        {
            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                if (i.m_data.Equals(item))
                return true;
            }

            return false;
        }

        public bool Remove(T item) 
        {
            Node<T> prev = m_head;
            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                if (i.m_data.Equals(item))
                {
                    prev.m_next = i.m_next;
                    m_cnt--;
                    return true;
                }
                prev = i;
            }

            return false;
        }

        public bool IsObjectAtIndex(T value, int index)
        {
            if(EqualityComparer<T>.Default.Equals(FindByIndex(index), value))
            {
                return true;
            }

            return false;
        }

        public T FindByIndex(int index)
        {
            int counter = 0;
            T returnnode = default(T);

            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                if (index == counter)
                {
                    returnnode = i.m_data;
                }
                counter++;
            }

            return returnnode;
        }

        public int Count()
        {
            int counter = 0;

            for (Node<T> i = m_head; i != null; i = i.m_next)
            {
                counter++;
            }
            
            return counter;
        }

        public void Clear()
        {
            // Pointer to Next Node
            Node<T> next_Node = null;

            for (Node<T> i = m_head; i != null; i = next_Node)
            {   
                // Safe the pointer to the next node
                next_Node = i.m_next;

                // Delete the current Node
                i.m_next = null;
                i.m_data = default(T);
            }

            // Reset internal Counter
            m_cnt = 0;
        }
    }
}
