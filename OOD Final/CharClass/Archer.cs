using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOD_Final.CharClass
{
    public class Archer : Character
    {
        public Archer(string name) : base(name)
        {
            HP = 80;
        }

        public override string GetRole() => "Archer (Low defense and high mobility with ranged attacks)";
    }
}
