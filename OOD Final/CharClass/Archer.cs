using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using OOD_Final.Actions;
using OOD_Final.Interfaces;

namespace OOD_Final.CharClass
{
    public class Archer : Character
    {
        public Archer(string name, string classType, int health, int attackPower, IAction primaryAttack, IAction secondaryAttack)
            : base(name, classType, health, attackPower, primaryAttack, secondaryAttack)
        {
        }
    }
}
