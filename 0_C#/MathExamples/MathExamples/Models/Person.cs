using System;
using System.Collections.Generic;
using System.Text;

namespace MathExamples.Models
{
    public class Person : IDisposable
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        private int age;
        private int ssn;
        public string Name { get; set;}

        public int Age
        {
            get => age;
            set => age = value;
        }

        public int Ssn
        {
            get => ssn;
            set => ssn = value;
        }

        public Person()
        {
            
        }

        public override string ToString()
        {
            return Name + " " + ssn.ToString() + " " + age.ToString();
        }

        public Person(string name)
        {
            Name = name;
        }

        public Person(int age, int ssn, string name)
        {
            this.age = age;
            this.ssn = ssn;
            Name = name;
            
        }

    }


}
