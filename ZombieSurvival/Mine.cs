using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4272_ZombieSurvival
{
    internal class Mine : Element
    {
        private int _damage = 5;
        public int Damage { get { return _damage;  } }
        public Mine(int PosX, int PosY) : base(PosX, PosY)
        {
            _symbol = '0';
        }

        public void Explode()
        {
            // Maybe add animation
        }
    }
}
