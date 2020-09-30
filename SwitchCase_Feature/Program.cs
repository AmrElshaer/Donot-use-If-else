using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace TestUI
{
    public enum Color { 
    Red,Green,BLack
    }
    public class Car {
        public Color Color { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var mycar = new Car() { Color=Color.Green,Name="Toyta"};
            #region Matching pattern
            // using If else 17 Line
            if (mycar.Color==Color.Green)
            {
                Console.WriteLine("Green");
            }
            else if (mycar.Color==Color.BLack)
            {
                Console.WriteLine("Black");
            }
            else if (mycar.Color == Color.Red)
            {
                Console.WriteLine("Red");
            }
            else
            {
                Console.WriteLine("Other");
            }
            // using C# 8 Switch Expressions with Pattern Matching 1 Line or Recursive Pattern Matching or 
            Console.WriteLine((mycar.Color) switch { (Color.BLack) => "Black", Color.Green => "Green", Color.Red => "Red", _ => "Other" });
            // you can do this in  C# 7 using Declaration Pattern and Case Guards(when)
            switch (mycar)
            {
                case null:
                    throw new ArgumentNullException();
                case Car car when car.Color == Color.BLack:
                    Console.WriteLine("Car is black");
                    break;
                case Car car when car.Color == Color.Green:
                    Console.WriteLine("Car is Green");
                    break;
                case Car car when car.Color == Color.Red:
                    Console.WriteLine("Car is Red");
                    break;
                default:
                    Console.WriteLine("Other Color");
                    break;

            }
            #endregion
            #region Declartion Pattern and Var Pattern
            // using if else 
            if (mycar!=null)
            {
                if (mycar.Name!=null)
                {
                    Console.WriteLine(mycar.Name);
                }
               
            }
            else
            {
                Console.WriteLine("NO Car");
            }
            //using switch with Declartion Pattern and Var Pattern
            // using Var Pattern insead of default
            // you can use  var Pattern Insead of default
            // you can use DisCard pattern insead of default
            switch (mycar)
            {
                case Car car when !string.IsNullOrEmpty(car.Name):
                    Console.WriteLine(car.Name);
                    break;
                case null:
                    Console.WriteLine("No Car");
                    break;
                    // var pattern instead of Defult
                case var obj :
                    Console.WriteLine("Other Type{0}",obj.ToString());
                    break;
            }
            // you can use DisCard pattern insead of default
            switch (mycar)
            {
                case Car car when !string.IsNullOrEmpty(car.Name):
                    Console.WriteLine(car.Name);
                    break;
                case null:
                    Console.WriteLine("No Car");
                    break;
                // DisCard pattern instead of default
                _:
                    Console.WriteLine("Other Type");
                   
            }
            #endregion
            Console.ReadKey();
        }
       
    }
}
