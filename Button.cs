using System;
using System.Collections.Generic;
using System.Text;

namespace Vlad3D
{
    class Button
    {
        private Vector position;

        IScreen window;

        private string name;
        private int nameLenght => name.Length;

        private bool isActive;

        public Button(Vector position, string name, IScreen window)
        {
            this.position = position;
            this.name = name;
            this.window = window;
        }

        public void Draw()
        {
            Console.SetCursorPosition(position.X, position.Y);

            DrawLine();

            MoveX();
            Console.Write("| " + name + " |\n");

            DrawLine();
        }

        private void DrawLine()
        {
            if (isActive)
            {
                Console.ForegroundColor = ConsoleColor.Red;
            }

            MoveX();

            Console.Write("+-");

            for (int i = 0; i < nameLenght; i++)
            {
                Console.Write("-");
            }

            Console.Write("-+ \n");

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void MoveX()
        {
            Console.SetCursorPosition(position.X, Console.CursorTop);
        }

        public void OpenWindow()
        {
            window.Open();
        }

        public void SetActive(bool value)
        {
            isActive = value;
        }
    }
}
