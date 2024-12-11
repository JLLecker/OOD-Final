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
        public string Attack() // returns atk details
        {
            return "You throw a ball of fire toward the enemy!";
        }
    }
}
