using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.CharClass
{
    public class Thief : Character
    {
        public Thief(string name) : base(name)
        {
            HP = 100;
        }

        public override string GetRole() => "Thief (Low defense and medium mobility with melee attacks)";
    }
}
