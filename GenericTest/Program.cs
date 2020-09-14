using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Animal[] animals = new Cat[5];
            //Cat[] cats1 = new Cat[3];
            //cats1[0] = (Cat)new Animal();

            //animals[0] = new Turtle();
            //List<Animal> cats = new List<Animal>();

            IEnumerable<Animal> animals = new List<Cat>();


            Animal animal = new Animal();
            animal.Move(1);
            animal.Move<int>(1);
            animal.MoveWrapper(2);
            animal.MoveWrapper(2.1);

            Animal<int> animal2 = new Animal<int>();
            animal2.Move(2);
            animal2.Move1(3);
            animal2.MoveWrapper(2);

            Animal<double> animal3 = new Turtle<double>();
            animal3.Move(2);//调用的是 Animal 的方法,而不是Turtle的 方法
            animal3.Move1(3.1);
            animal3.MoveWrapper(2);

            //Type td = typeof(Animal<double>);
            //foreach (MethodInfo minfo in td.GetMethods())
            //{
            //    System.Diagnostics.Debug.WriteLine($"method name: {minfo.Name}, IsGenericMethod:{minfo.IsGenericMethod},IsGenericMethodDefinition: {minfo.IsGenericMethodDefinition}");
            //}
        }

        public static void DisplayGenericType(Type t, string caption)
        {
            Console.WriteLine("\n{0}", caption);
            Console.WriteLine("    Type: {0}", t);

            Console.WriteLine("\t            IsGenericType: {0}",
                t.IsGenericType);
            Console.WriteLine("\t  IsGenericTypeDefinition: {0}",
                t.IsGenericTypeDefinition);
            Console.WriteLine("\tContainsGenericParameters: {0}",
                t.ContainsGenericParameters);
            Console.WriteLine("\t       IsGenericParameter: {0}",
                t.IsGenericParameter);
        }
    }
    public class Animal
    {
        public string Name { get; set; }
        public void Move(int speed)
        {
            System.Diagnostics.Debug.WriteLine($"Name:{Name} is { (speed > 1 ? "running" : "walking") } ! Type:{this.GetType()}");
        }
        public void Move<T>(T speed)
        {
            //System.Diagnostics.Debug.WriteLine($"[Generic Method] Name:{Name} is moving ! Type:{this.GetType()}");
        }
        public void MoveWrapper<T>(T s)
        {
            Move(s);
            Move<T>(s);
        }

        public void MoveWrapper(int s)
        {
            Move(100);
            Move<int>(100);
        }
    }

    public class Animal<T>
    {
        public void Move1(T speed)
        {
            System.Diagnostics.Debug.WriteLine($"Animal [Generic Method] Name:{Name} is moving ! Type:{this.GetType()}");
        }
        public void Move2<S>(S speedT)
        {
            System.Diagnostics.Debug.WriteLine($"Animal [Generic Method]2 Name:{Name} is moving ! Type:{this.GetType()}");
        }
        public void Move(int speed)
        {
            System.Diagnostics.Debug.WriteLine($"Animal Name:{Name} is { (speed > 1 ? "running" : "walking") } ! Type:{this.GetType()}");
        }
        public string Name { get; set; }

        //public void Move<T>(T speedT)
        //{
        //    System.Diagnostics.Debug.WriteLine($"[Generic Method] Name:{Name} is moving ! Type:{this.GetType()}");
        //}
        //覆盖测试
        public void MoveWrapper<VT>(VT s)
        {
            Move2(s);
        }
    }

    public class Turtle<T> : Animal<T>
    {
        public void Move(int speed)
        {
            System.Diagnostics.Debug.WriteLine($"Turtle Name2:{Name} is { (speed > 1 ? "running" : "walking") } ! Type:{this.GetType()}");
        }
        public new void Move2<S>(S speed)
        {
            System.Diagnostics.Debug.WriteLine($"Turtle [Generic Method]2 Name:{Name} is moving ! Type:{this.GetType()}");
        }
        public void MoveWrapper<T>(T s)
        {
            Move2(s);
        }
    }

    public class Cat : Animal
    {

    }


}
