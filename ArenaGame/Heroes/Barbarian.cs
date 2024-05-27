using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame.Heroes
{
    public class Barbarian : Hero
    {
        public Barbarian(string name, double armor, double strength, IWeapon weapon)
            : base(name, armor, strength, weapon)
        {
        }

        public override double Attack()
        {
            double damage = base.Attack();
            if (random.NextDouble() < 0.1)
            {
                // 10% chance for a berserk attack that deals triple damage
                damage *= 3;
            }
            return damage;
        }

        public override double Defend(double damage)
        {
            // Barbarian has a rage mode, reducing damage by a fixed percentage
            double rageReduction = damage * 0.2;
            return base.Defend(damage - rageReduction);
        }
    }
}
