using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Mage : Hero
    {
        public Mage(string name, double armor, double strength, IWeapon weapon)
            : base(name, armor, strength, weapon)
        {
        }

        public override double Attack()
        {
            double damage = base.Attack();
            double probability = random.NextDouble();
            if (probability < 0.2)
            {
                // 20% chance to cast a powerful spell
                damage *= 2;
            }
            return damage;
        }

        public override double Defend(double damage)
        {
            double reducedDamage = base.Defend(damage);
            if (random.NextDouble() < 0.15)
            {
                // 15% chance to create a magic shield that nullifies damage
                reducedDamage = 0;
            }
            return reducedDamage;
        }
    }
}

