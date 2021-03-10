using System;
using System.Collections.Generic;
using System.Text;

namespace Vlad3D
{
    class Engine : IScreen
    {
        Map map;
        Player player;
        Renderer renderer;

        public void Open()
        {
            Console.Clear();

            Run();
        }

        public void Run()
        {
            while (true)
            {
                renderer.Render();
            }
        }
    }
}
