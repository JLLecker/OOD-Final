using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final
{
    public abstract class Character
    {
        public int HP { get; set; }

        public string Name { get; set;  }

        protected Character(string name) 
        {
            Name = name;
        }

        public abstract string GetRole();

        public virtual void Display()
        {
            Console.WriteLine($"{Name} is a {GetRole()} with {HP} HP.");
        }
    }
}
