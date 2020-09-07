using System;
using System.Collections.Generic;
using System.Text;

namespace AboutCSharpLanguage.Model
{
    public class Student : Person, IComparable<Student>
    {
        public string ClassName { get; set; }

        public int CompareTo(Student s)
        {
            return Name.CompareTo(s.Name);
        }

        public int CompareTo(object s)
        {
            var student = s as Student;
            return Name.CompareTo(student.Name);
        }
    }
}
