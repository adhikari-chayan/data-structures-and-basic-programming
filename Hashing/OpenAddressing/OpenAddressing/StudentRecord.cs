using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenAddressing
{
    public class StudentRecord
    {
        //-1 is not a valid student id
        public StudentRecord(int id,string name)
        {
            StudentId = id;
            StudentName = name;

        }
        public int StudentId { get; set; }
        public string StudentName { get; set; }
    }
}
