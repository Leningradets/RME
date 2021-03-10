using System;
using System.Collections.Generic;
using System.Text;

namespace Vlad3D
{
    class MapEditor : IScreen
    {
        private Map map;
        private Vector mapDimentions;
        private Cursor cursor;

        public void Open()
        {
            mapDimentions = new Vector(20, 20);
            map = new Map(mapDimentions);
            cursor = new Cursor(new Vector(0, 0), mapDimentions);

            Console.SetCursorPosition(0, 0);

            DrawMap();

            Run();
        }

        public void Run()
        {
            bool isRunning = true;

            while (isRunning)
            {
                Vector cursorTranslation = new Vector(0, 0);

                var key = Console.ReadKey().Key;

                switch (key)
                {
                    case ConsoleKey.K:
                        SaveMap();
                        break;

                    case ConsoleKey.L:
                        LoadMap();
                        break;

                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;

                    case ConsoleKey.Enter:
                        map.ChangeCell(cursor.Position);
                        break;

                    case ConsoleKey.W:
                    case ConsoleKey.UpArrow:
                        cursorTranslation.Y--;
                        break;

                    case ConsoleKey.S:
                    case ConsoleKey.DownArrow:
                        cursorTranslation.Y++;
                        break;

                    case ConsoleKey.D:
                    case ConsoleKey.RightArrow:
                        cursorTranslation.X++;
                        break;

                    case ConsoleKey.A:
                    case ConsoleKey.LeftArrow:
                        cursorTranslation.X--;
                        break;
                }

                cursor.Move(cursorTranslation);

                DrawMap();
            }
        }

        public void DrawMap()
        {
            Console.Clear();
            map.Draw(cursor.Position);

            Console.WriteLine("Arrows or WASD - move\nEnter - change cell type\nK - save\nL - load");
        }

        public void SaveMap()
        {
            map.Save();
        }

        public void LoadMap()
        {            
            map = map.Load();
        }
    }
}
