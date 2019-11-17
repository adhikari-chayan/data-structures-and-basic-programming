using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAddressing
{
   public class HashTable
    {
        private StudentRecord[] array;
        private int m; //size of array
        private int n;//number of records

        public HashTable():this(11)
        {

        }

        public HashTable(int tableSize)
        {
            m = tableSize;
            n = 0;
            array = new StudentRecord[m];
        }

        private int hash(int key)
        {
            return (key % m);
        }

        public void Insert(StudentRecord newRecord)
        {
            int key = newRecord.StudentId;
            int h = hash(key);

            int location = h;

            for(var i=1;i<m;i++)
            {
                if(array[location]==null || array[location].StudentId==-1)
                {
                    array[location] = newRecord;
                    n++;
                    return;
                }
                if(array[location].StudentId==newRecord.StudentId)
                {
                    throw new InvalidOperationException("Duplicate Key");
                }

                location = (h + i) % m;
            }
            Console.WriteLine("Table is full: Record cannot be inserted.");
        }

        public StudentRecord Search(int key)
        {
            int h = hash(key);
            int location = h;

            for(var i=1;i<m;i++)
            {
                if (array[location] == null)
                    return null;
                if (array[location].StudentId == key)
                    return array[location];

                location = (h + i) % m;
            }

            return null;
        }

        public StudentRecord Delete(int key)
        {
            int h = hash(key);
            int location = h;

            for (var i = 1; i < m; i++)
            {
                if (array[location] == null)
                    return null;
                if (array[location].StudentId == key)
                {
                    StudentRecord temp = array[location];
                    array[location].StudentId = -1;
                    n--;
                    return temp;
                }

                location = (h + i) % m;
            }

            return null;
        }
    }
}
