using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.CharClass
{
    public class Knight : Character
    {
        public Knight(string name) : base(name)
        {
            HP = 150;
        }

        public override string GetRole() => "Knight (High defense and low mobility with melee attacks)";
    }
}
