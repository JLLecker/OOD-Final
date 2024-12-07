using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOD_Final.EnemyClass
{
    public abstract class Enemy
    {
        public string Name { get; set; }
        public int HP { get; set; }

        public Enemy(string name, int health)
        {
            Name = name;
            HP = health;
        }

        public abstract string GetDescription();

        public void TakeDamage(int damage)
        {
            HP -= damage;
            if (HP < 0) HP = 0;
        }

        public bool IsAlive()
        {
            return HP > 0;
        }
    }

}
