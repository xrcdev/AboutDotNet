using System;
using System.Collections.Generic;
using System.IO;
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

            IEnumerable<Animal<int, string>> animals = new List<Cat<int, string>>();
            //List<Animal<int, string>> animals2 = new List<Cat<int, string>>();

            IContainer<Material, double, double> gBottle1 = new Bottle<Glass, double, double>();
            IContainer<Material, Glass, double> gBottle2 = new Bottle<Glass, Material, double>();

            //Ball<int, Inch, Material> ball = new Ball<int, Inch, Glass>();


            //Size<double, MeasureUnit> size = new GenenicVarianceTest.Size<double, Inch>();
            //MeasureUnit<FileStream> measure = new MeasureUnit<Stream>();

            IMeasureUnit<IDisposable> measure = new MeasureUnit<FileStream>();
            IMeasureUnit<IP> measure2 = new MeasureUnit<ISub>();

            //LengthInfo<MeasureUnit<int>> lengthInfo = new LengthInfo<Inch<int>>();
            //LengthInfo<Inch<int>> lengthInfo = new LengthInfo<MeasureUnit<int>>();
            Console.ReadLine();
        }
    }

    #region IContainer
    //interface IContainer<in MAT, in FillT, out CurrentCapacityT>
    interface IContainer<out CurrentCapacityT, in MAT, in FillT>
    {
        CurrentCapacityT Fill(MAT m, FillT f);
    }

    //internal class Bottle<MAT, FillT, CurrentCapacityT> : IContainer<MAT, FillT, CurrentCapacityT>
    internal class Bottle<CurrentCapacityT, MAT, FillT> : IContainer<CurrentCapacityT, MAT, FillT>
    {
        //public CurrentCapacityT Fill(MAT m, FillT f)
        public CurrentCapacityT Fill(MAT m, FillT f)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

    interface IP { }
    interface ISub : IP { }

    public interface IMaterial<Mat> { string MeterialName { get; set; } };
    public class Material<Mat> : IMaterial<Mat>
    {
        public string MeterialName { get; set; }
    }
    public class IGlass : Material
    {
        public string MeterialName { get; set; }
    }
    public class IPlastic : Material
    {
        public string MeterialName { get; set; }
    }



    public interface IMeasureUnit<out T>
    {
        string UnitName { get; set; }
    }
    public class MeasureUnit<T> : IMeasureUnit<T>
    {
        public string UnitName { get; set; }
        public void PrintUnitName(T measureUnit)
        {
            Console.WriteLine($"[MeasureUnit.PrintUnitName] T Type:{measureUnit.GetType()}");
        }
    }

    public class Inch<T> : IMeasureUnit<T>
    {
        public string UnitName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public new void PrintUnitName(T measureUnit)
        {
            Console.WriteLine($"[MeasureUnit.PrintUnitName] T Type:{measureUnit.GetType()}");
        }
    }
    public class Meter<T> : IMeasureUnit<T>
    {
        public string UnitName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        //string IMeasureUnit.UnitName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    public class LengthInfo<T> : IMeasureUnit<T>
    {
        public string UnitName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        void PrintLength(T measureUnit)
        {
            Console.WriteLine($"T Type:{measureUnit.GetType()}");
        }
    }
    public interface ISize<in valT, out MeasureUnitT>
    {
        MeasureUnitT GetMeasureUnitType();
        void PrintSize();
    }

    public class Size<valT, MeasureUnitT> : ISize<valT, MeasureUnitT>
    {
        public string UnitName { get; set; }

        public MeasureUnitT GetMeasureUnitType()
        {
            throw new NotImplementedException();
        }

        public void PrintSize()
        {
            throw new NotImplementedException();
        }
    }

    public interface IBal<valT, MeasureUnitT, Mat> : ISize<valT, MeasureUnitT>, IMaterial<Mat> { }

    public class Ball<valT, MeasureUnitT, Mat> : IBal<valT, MeasureUnitT, Mat>
    {
        public string MeterialName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MeasureUnitT GetMeasureUnitType()
        {
            throw new NotImplementedException();
        }

        public void PrintSize()
        {
            throw new NotImplementedException();
        }
    }
    public class Basketball<valT, MeasureUnitT, Mat> : Ball<valT, MeasureUnitT, Mat>
    {
        public string MeterialName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MeasureUnitT GetMeasureUnitType()
        {
            throw new NotImplementedException();
        }

        public void PrintSize()
        {
            throw new NotImplementedException();
        }
    }
    public class PingPang<valT, MeasureUnitT, Mat> : Ball<valT, MeasureUnitT, Mat>
    {
        public string MeterialName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MeasureUnitT GetMeasureUnitType()
        {
            throw new NotImplementedException();
        }

        public void PrintSize()
        {
            throw new NotImplementedException();
        }
    }

    public class Material
    {
        public string MeterialName { get; set; }
    }

    public class Glass : Material
    {
        public string MeterialName { get; set; }
    }
    public class Plastic : Material
    {
        public string MeterialName { get; set; }
    }

    #region Animal cat

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

    #endregion

}
