using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace LA_320_4272_ZombieSurvival
{
    internal class Game
    {
        private bool ACTION_TRIGGERED = true;
        private World _world = new World(20, 80);


        // CREATE WORLD
        public void Start()
        {
            _world.InitializeGameElements();
            while (_world.IsGameOver == false)
            {
                HandleInput();
                _world.UpdateWorld();
            }
        }

        // HANDLE PLAYER INPUTS
        private void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey();
            _world.HandlePlayerInputs(key.KeyChar);
        }


    }
}
