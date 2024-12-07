using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.CharClass
{
    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            HP = 80;
        }

        public override string GetRole() => "Mage (Low defense and high mobility with ranged attacks)";
    }
}
