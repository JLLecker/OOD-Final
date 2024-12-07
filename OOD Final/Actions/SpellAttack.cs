using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.Interfaces;

namespace OOD_Final.Actions
{
    public class SpellAttack : IAction
    {
        public string Attack() => "Throws a ball of fire toward the enemy!";
    }
}
