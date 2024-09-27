using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4272_ZombieSurvival
{
    class Obstacle : Element
    {
        public Obstacle(int posX, int posY)  : base(posX, posY)
        {
            _symbol = '#';
        }        
    }
}
