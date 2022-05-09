using System;
using System.Collections.Generic;

namespace Iterator
{
    abstract class Iterator
    {   
        public abstract string GetNext();
        public abstract bool HasMore();
    }

    class ListIterator: Iterator
    {   
        private List<string> _collection;
        private int _position = -1; 

        public ListIterator(List<string> collection)
        {
            _collection = collection;
        }

        public override string GetNext()
        {   
            _position++;

            return _collection[_position];
        }

        public override bool HasMore()
        {   
            if ( _collection.Count <= (_position + 1) )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }

    abstract class IterableCollection
    {
        public abstract Iterator CreateIterator();
    }

    class ListCollection: IterableCollection
    {   
        private List<string> _collection;

        public ListCollection(List<string> collection)
        {
            _collection = collection;
        }

        public override Iterator CreateIterator()
        {
            return new ListIterator(_collection);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {   
            List<string> weapons = new List<string>() { "Knife", "Gun", "Rifle","Shotgun", "Grenade" };

            IterableCollection weaponsCollection = new ListCollection(weapons);
            Iterator iterator = weaponsCollection.CreateIterator();

            while (iterator.HasMore())
            {
                Console.WriteLine(iterator.GetNext());
            }

            Console.ReadLine();
        }
    }
}
