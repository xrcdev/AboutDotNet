using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenenicVarianceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //Cat<int> cat = new Animal<int>();

            Animal<int, string> animal = new Cat<int, string>();
            animal.Walk(5);
            animal.Drive(20, "bike");
            Console.ReadLine();
        }
    }

    interface IMove<in SpeedT, in vehicleT>
    {
        void Walk(SpeedT speed);
        string Drive(SpeedT speed, vehicleT vType);
    }
    // new() 可以作用到 datatime ,是引用类型?
    //public class Animal<SpeedT, vehicleT> : IWalk<SpeedT, vehicleT> where vehicleT : new()
    public class Animal<SpeedT, vehicleT> : IMove<SpeedT, vehicleT>
    {
        //public Animal()
        //{
        //}

        public string Name { get; set; }

        //public void Walk(T speed)
        //{
        //    System.Diagnostics.Debug.WriteLine($"Animal:{Name} walk speed: {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
        //}
        //public void Drive<S>(T speed, S s)
        //{
        //    System.Diagnostics.Debug.WriteLine($"Animal:{Name} rides a {s} on the road at a speed of {speed}km/h! This Type:{this.GetType()} , obj Type {speed.GetType()}, S Type {s.GetType()}");
        //}

        //public vehicleT Walk(SpeedT speed)
        //{
        //    System.Diagnostics.Debug.WriteLine($"Animal:{Name} walk speed: {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
        //    return new vehicleT();
        //}

        //public vehicleT Drive<V>(SpeedT t, V vehicleType)
        //{
        //    System.Diagnostics.Debug.WriteLine($"Animal:{Name} rides a {s} on the road at a speed of {speed}km/h! This Type:{this.GetType()} , obj Type {speed.GetType()}, S Type {s.GetType()}");
        //    return vehicleType;
        //}



        //public void Drive(SpeedT speed)
        //{
        //    System.Diagnostics.Debug.WriteLine($"Animal:{Name} walk speed: {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
        //}

        //public void IMove<SpeedT, vehicleT>.Walk(SpeedT speed)
        public void Walk(SpeedT speed)
        {
            System.Diagnostics.Debug.WriteLine($"Animal:{Name} walk speed: {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
        }

        public string Drive(SpeedT speed, vehicleT vType)
        {
            System.Diagnostics.Debug.WriteLine($"Animal:{Name} rides a {vType} on the road at a speed of {speed}km/h! This Type:{this.GetType()} , speed Type {speed.GetType()}, vType Type {vType.GetType()}");
            return vType.ToString() + speed.ToString();
        }
    }

    public class Cat<SpeedT, vehicleT> : Animal<SpeedT, vehicleT>
    {
        public string Name { get; set; }

        //public new void Walk(T speed)
        //{
        //    System.Diagnostics.Debug.WriteLine($"Cat :{Name} walk spend : {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
        //}

        //public new void Drive<S>(T speed, S s)
        //{
        //    System.Diagnostics.Debug.WriteLine($"Cat:{Name} rides a {s} on the road at a speed of {speed}km/h! This Type:{this.GetType()} , obj Type {speed.GetType()}, S Type {s.GetType()}");
        //}

        public void Walk(SpeedT speed)
        {
            System.Diagnostics.Debug.WriteLine($"Cat:{Name} walk speed: {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
        }

        public string Drive(SpeedT speed, vehicleT vType)
        {
            System.Diagnostics.Debug.WriteLine($"Cat:{Name} rides a {vType} on the road at a speed of {speed}km/h! This Type:{this.GetType()} , speed Type {speed.GetType()}, vType Type {vType.GetType()}");
            return vType.ToString() + speed.ToString();
        }
    }


}
