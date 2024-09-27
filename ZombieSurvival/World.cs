using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA_320_4272_ZombieSurvival
{
    internal class World
    {
        private int SIZE_X;
        private int SIZE_Y;
        private char[,] _buffer;
        private bool _isGameOver = false;
        private bool _isLastPrintBeforeGameOver = false;
        private Player _player;
        private List<Element> _elements = new List<Element>();
        private Random _random = new Random();

        public bool IsGameOver {  get { return _isGameOver; } }

        public World(int size_x, int size_y) 
        {
            SIZE_X = size_x;
            SIZE_Y = size_y;
            _buffer = new char[size_x, size_y];
            _player = new Player(15, 15, 10, SIZE_X, SIZE_Y);
        }

        public void HandlePlayerInputs(char key)
        {
            (int X, int Y) _directionToMove;
            bool _playerIsAttacking = false;

            // set the move direction
            switch (key)
            {
                case 'w':
                    _directionToMove = (1, 0);
                    break;
                case 's':
                    _directionToMove = (-1, 0);
                    break;
                case 'a':
                    _directionToMove = (0, -1);
                    break;
                case 'd':
                    _directionToMove = (0, 1);
                    break;
                case '1':
                    _directionToMove = (0, 0);
                    _playerIsAttacking = true;
                    break;
                default:
                    _directionToMove = (0, 0);
                    break;
            }

            // move the player
            if (_directionToMove.X == -1)
            {
                if (_player.Position.x + 1 < SIZE_X && PeekAt(_player.Position.x + 1, _player.Position.y) != '#')
                {
                    _player.Move(1, 0);
                }
            }
            if (_directionToMove.X == 1)
            {
                if (_player.Position.x - 1 > 0 && PeekAt(_player.Position.x - 1, _player.Position.y) != '#')
                {
                    _player.Move(-1, 0);
                }
            }

            if (_directionToMove.Y == 1)
            {
                if (_player.Position.y + 1 < SIZE_Y && PeekAt(_player.Position.x, _player.Position.y + 1) != '#')
                {
                    _player.Move(0, 1);
                }
            }
            if (_directionToMove.Y == -1)
            {
                if (_player.Position.y - 1 > 0 && PeekAt(_player.Position.x, _player.Position.y - 1) != '#')
                {
                    _player.Move(0, -1);
                }
            }

            (int, int)[] nextToPlayer = [(0, 1), (1, 0), (0, -1), (-1, 0), (0, 0)]; // all positions next to and on the player

            char[] proximityDamagingEnemies = ['0', 'Z']; // all Symbol chars that damaging enemies use

            // check for enemies, their damage and the players damage if he is attacking
           foreach (Element element in _elements.ToList())
           {
                if (nextToPlayer.Contains((element.Position.x - _player.Position.x, element.Position.y - _player.Position.y)))
                {
                    if (element.GetType() == typeof(Mine)) // Handle Mine
                    {
                        ((Mine)element).Explode();
                        _player.TakeDamage(((Mine)element).Damage);
                        _elements.Remove(element);

                    } else if (element.GetType() == typeof(Zombie)) // Handle Zombie
                    {
                        if (_playerIsAttacking)
                        {
                            ((Zombie)element).TakeDamage(_player.Damage);
                        }

                        // delete the zombie if he is dead
                        if (((Zombie)element).IsDead)
                        {
                            _elements.Remove(element);
                        }

                        // Player takes damage
                        _player.TakeDamage(((Zombie)element).Damage);
                    }
                    if (_player.IsDead)
                    {
                        GameOver();
                    }
                }
           } 
        }
        public void InitializeGameElements()
        {
            _elements.Clear();
            _elements.Add(_player);
            for (int i = 0; i < 40; i++)
            {
                _elements.Add(new Obstacle(_random.Next(1, SIZE_X), _random.Next(1, SIZE_Y)));
            }
            for (int i = 0; i < 20; i++)
            {
                _elements.Add(new Mine(_random.Next(1, SIZE_X), _random.Next(1, SIZE_Y)));
            }
            _elements.Add(new Zombie(_random.Next(1, SIZE_X), _random.Next(1, SIZE_Y), _player));
        }

        public void UpdateWorld()
        {
            BlankWorld();

            UpdateElements();

            WriteElementsToBuffer();

            PrintBuffer();
        }

        private void BlankWorld()
        {
            for (int i = 0; i < SIZE_X; i++)
            {
                for (int j = 0; j < SIZE_Y; j++)
                {
                    _buffer[i, j] = ' ';
                }
            }
        }

        private void UpdateElements()
        {
            foreach (Element element in _elements)
            {
                element.Update();
            }
        }

        private void WriteElementsToBuffer()
        {
            foreach (Element element in _elements)
            {
                WriteToBuffer(element.Symbol, element.Position);
            }
        }

        private void WriteToBuffer(char charToWrite, int posX, int posY)
        {
            _buffer[posX, posY] = charToWrite;
        }
        public void WriteToBuffer(char charToWrite, (int posX, int posY) position)
        {
            _buffer[position.posX, position.posY] = charToWrite;
        }

        private void PrintBuffer()
        {
            if (_isGameOver == false)
            {
                for (int i = 0; i < SIZE_X; i++)
                {
                    for (int j = 0; j < SIZE_Y; j++)
                    {
                        Console.Write(_buffer[i, j]);
                    }
                    Console.WriteLine();
                }
                if (_isLastPrintBeforeGameOver == false)
                {
                    Console.SetCursorPosition(0, 0);
                }
            }
        }

        private char PeekAt(int x, int y)
        {
            return _buffer[x, y];
        }

        private void GameOver()
        {
            BlankWorld();
            PrintBuffer();
            WriteElementsToBuffer();
            WriteGameOverToBuffer();
            _isLastPrintBeforeGameOver = true;
            PrintBuffer();
            _isGameOver = true;
        }

        public void WriteGameOverToBuffer()
        {
            int start_X = SIZE_X / 2;
            int start_Y = (SIZE_Y / 2) -  4;
            char[] gameOverChars = "GAME OVER".ToCharArray();

            for (int i = 0; i < gameOverChars.Length; i++)
            {
                _buffer[start_X, start_Y + i] = gameOverChars[i];
            }
            
        }
    }
}
