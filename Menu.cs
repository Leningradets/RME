using System;
using System.Collections.Generic;
using System.Text;

namespace Vlad3D
{
    class Menu : IScreen
    {
        private int currentButton = 0;

        private int CurrentButton 
        { 
            get => currentButton;
            set
            {
                if (value >= buttons.Length)
                {
                    currentButton = 0;
                }
                else if (value < 0)
                {
                    currentButton = buttons.Length - 1;
                }
                else
                {
                    currentButton = value;
                }
            }
        }

        private Button[] buttons;
        private int buttonsCount => buttons.Length;

        private Engine engine = new Engine();
        private MapEditor editor = new MapEditor();

        public Menu(Button[] buttons)
        {
            this.buttons = buttons;
        }

        public void Open()
        {
            buttons[CurrentButton].SetActive(true);

            Draw();
            Run();
        }

        public void Run()
        {
            while (true)
            {
                ConsoleKey key = Console.ReadKey().Key;

                buttons[CurrentButton].SetActive(false);

                switch (key)
                {
                    case ConsoleKey.DownArrow:
                    case ConsoleKey.RightArrow:
                        CurrentButton++;
                        break;

                    case ConsoleKey.UpArrow:
                    case ConsoleKey.LeftArrow:
                        CurrentButton--;
                        break;

                    case ConsoleKey.Enter:
                        if(CurrentButton == buttons.Length - 1)
                        {
                            Environment.Exit(0);
                        }
                        buttons[CurrentButton].OpenWindow();
                        break;
                }


                buttons[CurrentButton].SetActive(true);

                Console.Clear();
                Draw();
            }
        }

        public void Draw()
        {
            foreach (var button in buttons)
            {
                button.Draw();
            }
        }
    }
}
