using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.CharClass
{
    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            HP = 120;
        }

        public override string GetRole() => "Warrior (Medium defense and medium mobility with melee attacks)";
    }
}
