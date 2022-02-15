using System;
using System.Collections;
using System.Text;

namespace Task2
{
    internal abstract class Car
    {
        private string _name;
        private int _releaseYear;

        public Car(string name, int year)
        {
            _name = name;
            _releaseYear = year;
        }

        public string Name => _name;
        public int ReleaseYear => _releaseYear;

        public virtual void Ride()
        {
            Console.WriteLine("Car.Ride");
        }

        public override string ToString()
        {
            return $"{Name} {ReleaseYear}";
        }
    }

    internal class SportCar : Car
    {
        public SportCar(string name, int year) : base(name, year)
        {
        }

        public override void Ride()
        {
            Console.WriteLine($"Fast ride from SportCar {Name}");
        }

        public override string ToString()
        {
            return base.ToString() + $" ({this.GetType().Name})";
        }
    }

    internal class JustCar : Car
    {
        public JustCar(string name, int year) : base(name, year)
        {
        }

        public override void Ride()
        {
            Console.WriteLine($"Ordinary ride from JustCar: {Name}");
        }

        public override string ToString()
        {
            return base.ToString() + $" ({this.GetType().Name})";
        }
    }

    interface IReadOnlyCollection<out T>
    {
        T this[int index] { get; }
        T GetElement(int index);
    }

    internal class CarCollection<T> : IReadOnlyCollection<T>
    {
        T[] collection;

        public CarCollection(T[] collection)
        {
            this.collection = collection;
        }

        public void Add(T element)
        {
            if (collection == null)
                collection = new T[0];
            T[] temp = new T[collection.Length + 1];
            for (int i = 0; i < collection.Length; i++)
            {
                temp[i] = collection[i];
            }
            temp[collection.Length] = element;
            collection = temp;
        }

        public T this[int index]
        {
            get
            {
                if (index < collection.Length)
                    return collection[index];
                else
                {
                    Console.WriteLine("Not found");
                    return default(T);
                }
            }
        }

        public int NumberOfElements => collection.Length;

        public void RemoveAllElemnts()
        {
            collection = null;
        }

        public override string ToString()
        {
            if (this.collection != null)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append($"List of {this.GetType()}\n");
                for (int i = 0; i < collection.Length; i++)
                {
                    sb.Append($"\t{i + 1}. - {collection[i].ToString()}\n");
                }
                return sb.ToString();
            }
            return "No elemnts in collection";
        }

        public T GetElement(int index)
        {
            return this[index];
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            JustCar[] justCars = new JustCar[]
            {
                new JustCar("Honda Accord", 2022),
                new JustCar("Audi Q8", 2020)
            };

            CarCollection<JustCar> myCarCollection = new CarCollection<JustCar>(justCars);
            CarCollection<Car> cars = new CarCollection<Car>(justCars);
            cars[0].Ride();
            cars[1].Ride();

            Console.WriteLine(cars[0]);

            Console.WriteLine($"cars.NumberOfElements = {cars.NumberOfElements}");

            cars.RemoveAllElemnts();
            Console.WriteLine(cars);

            cars.Add(new JustCar("Honda Accord", 2022));
            Console.WriteLine(cars);

        }
    }
}
