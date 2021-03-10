using System;
using System.Collections.Generic;
using System.Text;

namespace Vlad3D
{
    class Cursor
    {
        private Vector position;
        private Vector mapDimentions;

        public Vector Position => position;

        public Cursor(Vector position, Vector mapDimentions)
        {
            this.position = position;
            this.mapDimentions = mapDimentions;
        }

        public void Move(Vector translation)
        {
            position.X += translation.X;

            if (position.X >= mapDimentions.X)
            {
                position.X = mapDimentions.X - 1;
            }
            if (position.X < 0)
            {
                position.X = 0;
            }

            position.Y += translation.Y;

            if (position.Y >= mapDimentions.Y)
            {
                position.Y = mapDimentions.Y - 1;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
        }
    }
}
