using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.Actions;
using OOD_Final.Interfaces;

namespace OOD_Final.CharClass
{
    public class Knight : Character
    {
        public Knight(string name, string classType, int health, int attackPower, IAction primaryAttack, IAction secondaryAttack)
            : base(name, classType, health, attackPower, primaryAttack, secondaryAttack)
        {
        }
    }
}
