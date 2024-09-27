using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4272_ZombieSurvival
{
    internal class Player : Element
    {
        private int _health;
        private int _worldMaxX;
        private int _worldMaxY;
        private int _damage = 1;

        public int Damage { get { return _damage; } }
        public bool IsDead { get { return _health <= 0; } }
        public Player(int posX, int posY, int maxHealth, int worldMaxX, int worldMaxY) : base(posX, posY) 
        {
            _posX = posX;
            _posY = posY;
            _health = maxHealth;
            _worldMaxX = worldMaxX;
            _worldMaxY = worldMaxY;
            _symbol = '£';
        }

        public override void Update()
        {
            // currently handled in World, not optimal change in the future
        }

        public void TakeDamage(int damage)
        {
            _health -= damage;
        }
        public void Move(int x, int y)
        {
            _posX += x;
            _posY += y;
        }
    }
}
