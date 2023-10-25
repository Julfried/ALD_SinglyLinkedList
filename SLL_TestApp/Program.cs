using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SLL_TestApp
{

    internal class Helicopter
    {
        int id;
        public Helicopter(int id)
        {
            this.id = id;
        }

        public override bool Equals(object obj)
        {
            var heli = obj as Helicopter;
            if (heli == null) return false;

            return heli.id == this.id;
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Test Add Method
            SinglyLinkedList.SinglyLinkedList<int> myList = new SinglyLinkedList.SinglyLinkedList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(3);
            myList.Add(4);

            foreach (int i in myList)
            {
                Console.WriteLine(i);
            }

            // Test Contains Method
            bool exist = myList.Contains(3);

            // Test Remove
            while (myList.Remove(3)) {}

            exist = myList.Contains(3);

            // Create new List of Helicopters
            SinglyLinkedList.SinglyLinkedList<Helicopter> helis = new SinglyLinkedList.SinglyLinkedList<Helicopter>();
            Helicopter a = new Helicopter(1);
            Helicopter b = new Helicopter(2);
            Helicopter c = new Helicopter(3);
            Helicopter d = new Helicopter(4);

            // Add new helis
            helis.Add(a);
            helis.Add(b);
            helis.Add(c);
            helis.Add(d);

            Helicopter e = new Helicopter(1);

            // Test Contains Method
            var heliExist = helis.Contains(e);

            // Test Count Method
            var helicount = helis.Count();

            // Test FindByIndex Method
            var heliAtIndex1 = helis.FindByIndex(1);

            // Test IsObjectAtIndex Method
            var IsHeliAtIndex = helis.IsObjectAtIndex(e, 0);

            // Test Clear Method
            helis.Clear();

            Console.ReadLine();
        }
    }
}
