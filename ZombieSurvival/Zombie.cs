using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4272_ZombieSurvival
{
    internal class Zombie : Element
    {
        private Element _target;
        private int _damage = 4;
        private int _health = 2;
        public bool IsDead { get { return _health <= 0; } }
        public int Health { get { return _health; } }
        public int Damage { get { return _damage; } }
        public Zombie(int posX, int posY, Element target) : base(posX, posY) 
        {
            _symbol = 'Z';
            _target = target;
        }

        public override void Update()
        {
            (int x, int y) directionToMove;
            // set X
            if ((_target.Position.x - _posX) >= 1)
            {
                directionToMove.x = 1;
            } else if ((_target.Position.x - _posX) == 0)
            {
                directionToMove.x = 0;
            } else {
                directionToMove.x = -1;
            }

            // set Y
            if ((_target.Position.y - _posY) >= 1)
            {
                directionToMove.y = 1;
            }
            else if ((_target.Position.x - _posY) == 0)
            {
                directionToMove.y = 0;
            }
            else
            {
                directionToMove.y = -1;
            }

            // move
            Move(directionToMove);
        }

        public void Move(int x, int y) 
        {
            _posX += x;
            _posY += y;
        }

        public void Move((int x, int y) direction)
        {
            _posX += direction.x;
            _posY += direction.y;
        }
        public void TakeDamage(int damage)
        {
            _health -= damage;
        }
    }
}
