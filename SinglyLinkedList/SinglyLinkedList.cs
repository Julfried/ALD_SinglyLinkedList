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

    public class SinglyLinkedList<T> : IEnumerable, IEnumerator<T>
    {
        Node<T> m_head { get; set; }
        Node<T> m_last { get; set; }
        int m_cnt { get; set; }

        private Node<T> m_currentNode;

        public object Current { get { return Current; } }

        T IEnumerator<T>.Current { get { return m_currentNode.m_data; } }

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

            if(index < m_cnt)
            {
                for (Node<T> i = m_head; i != null; i = i.m_next)
                {
                    if (index == counter)
                    {
                        return i.m_data;
                    }
                    counter++;
                }
            }

            throw new IndexOutOfRangeException("index");
        }

        public int Count()
        {
            return m_cnt;
        }

        public void Clear()
        {
            // Reset internal Counter
            m_cnt = 0;

            // Reset Pointers to First and Last element
            m_head = null;
            m_last = null;
        }

        public IEnumerator GetEnumerator()
        {
            return this;
        }

        public bool MoveNext()
        {
            // If List is empty ==> return false
            if (m_head == null)
            {
                return false;
            }

            // Current Node null ==> first Iteration
            if (m_currentNode == null) 
            {
                m_currentNode = m_head;
                return true;
            }

            // Get Next Node
            m_currentNode = m_currentNode.m_next;

            //If CurrentNode is last element ==> return false
            return m_currentNode != null;
        }

        public void Reset()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            // Nothing todo in here
        }
    }
}
