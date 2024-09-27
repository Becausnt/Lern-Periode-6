using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4272_ZombieSurvival
{
    abstract internal class Element
    {
        protected int _posX = -1;
        protected int _posY = -1;
        protected char _symbol;

        public char Symbol {  get { return _symbol; } }

        public (int x, int y) Position { get => (_posX, _posY); }

        public virtual void Update()
        {
            
        }
        public Element(int posX, int posY)
        {
            _posX = posX;
            _posY = posY;
        }

    }
}
