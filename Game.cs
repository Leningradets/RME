using System;

namespace Vlad3D
{
    struct Vector
    {
        public int X;
        public int Y;

        public Vector (int X = 0, int Y = 0)
        {
            this.X = X;
            this.Y = Y;
        }
    }

    class Game
    {
        Menu menu;
        Player player;
        Map map;
        static Engine engine;
        static MapEditor editor;

        static void Main()
        {
            Vector consoleSize = new Vector(160, 45);
            Console.SetWindowSize(consoleSize.X, consoleSize.Y);
            Console.SetBufferSize(consoleSize.X, consoleSize.Y);

            Console.CursorVisible = false;
            Console.SetCursorPosition(0, 0);

            engine = new Engine();
            editor = new MapEditor();

            var menu = new Menu(new Button[3] {new Button(new Vector(73, 17), "Play", engine),
                    new Button(new Vector(73, 20), "Editor", editor),
                    new Button(new Vector(73, 23), "Exit", null) });
            menu.Open();
        }

        private void Run()
        {
            while (true)
            {

            }
        }
    }
}
