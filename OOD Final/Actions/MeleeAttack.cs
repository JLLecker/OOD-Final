using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OOD_Final.Interfaces;

namespace OOD_Final.Actions
{
    public class MeleeAttack : IAction
    {
        public string Attack() => "Performs a strong melee attack!";
    }
}
