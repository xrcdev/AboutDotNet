using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace AboutCSharpLanguage.Model
{
    public class Program
    {
        static void Main1(string[] args)
        {
            var gc = new GenericTypeDemo.GenericClassDemo<Student>();
            Student s = new Student();
            s.Name = "x1";
            gc.SayHello(s);
            gc.SayHelloG(s);//Test Generic 
            Student s2 = new Student();
            s2.Name = "x2";
            List<Student> sList = new List<Student>();
            sList.Add(s);
            sList.Add(s2);
            sList.Sort();
            Cat c = new Cat();
            c.Name = "box";
            //var gclass=
            //var t1 = ObjTransExpression<Student, Dog>.GetType();
            //var t2 = ObjTransExpression<Person, Dog>.GetType();

            var d = ObjTransExpression<Student, Dog>.Trans(s2);
            var d5 = ObjTransExpression<Person, Dog>.Trans(s2);
            var d2 = ObjTransExpression<Cat, Dog>.Trans(c);
            var d4 = ObjTransExpression<Student, Dog>.Trans(s2);



        }
    }
}
