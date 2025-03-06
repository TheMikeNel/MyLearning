using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetanitTrainings
{
    internal class Variations
    {

    }

    public class Animal
    {
        string Name {  get; set; }

        public Animal(string name) 
        {
            Name = name;
        }
    }

    interface IAnimal<out T> where T : Animal 
    { 
        T Value { get; }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }
    }

    public class Bird : Animal
    {
        public Bird(string name) : base(name) { }
    }

    public class Kiwi : IAnimal<Bird>
    {
        public Bird Value 
        {
            get { return new Bird("KiwiBird"); }
        }
    }
}
