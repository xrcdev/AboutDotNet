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

            Animal<int, DateTime> animal = new Animal<int, DateTime>();
            animal.Walk(5);
            animal.Drive<string>(20, "bike");
            Console.ReadLine();
        }
    }

    interface IWalk<in SpeedT, out vehicleT> where vehicleT : new()
    {
        void Walk(SpeedT speed);
        vehicleT Drive(SpeedT t);
    }

    public class Animal<SpeedT, vehicleT> : IWalk<SpeedT, vehicleT> where vehicleT : new()
    {
        public Animal()
        {
        }

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

        void IWalk<SpeedT, vehicleT>.Walk(SpeedT speed)
        {
            System.Diagnostics.Debug.WriteLine($"Animal:{Name} walk speed: {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
        }

        public vehicleT Drive(SpeedT t)
        {
            System.Diagnostics.Debug.WriteLine($"Animal:{Name} walk speed: {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
        }
    }

    //public class Cat<T> : Animal<T>
    //{
    //    public string Name { get; set; }

    //    public new void Walk(T speed)
    //    {
    //        System.Diagnostics.Debug.WriteLine($"Cat :{Name} walk spend : {speed}km/h ! This Type:{this.GetType()} , obj Type {speed.GetType()}");
    //    }

    //    public new void Drive<S>(T speed, S s)
    //    {
    //        System.Diagnostics.Debug.WriteLine($"Cat:{Name} rides a {s} on the road at a speed of {speed}km/h! This Type:{this.GetType()} , obj Type {speed.GetType()}, S Type {s.GetType()}");
    //    }
    //}


}
