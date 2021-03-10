using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;

namespace Vlad3D
{
    [Serializable]
    class Map
    {
        private char[,] cells;
        public Vector Dimentions => new Vector(cells.GetLength(1), cells.GetLength(0));

        public Map(Vector dimentions)
        {
            cells = new char[dimentions.X, dimentions.Y];

            InitMap();
        }

        private void InitMap()
        {
            for (int x = 0; x < Dimentions.X; x++)
            {
                cells[x, 0] = '#';
                cells[x, Dimentions.Y - 1] = '#';
            }

            for (int y = 1; y < Dimentions.Y - 1; y++)
            {
                cells[0, y] = '#';
                cells[Dimentions.X - 1, y] = '#';
            }

            for (int x = 1; x < Dimentions.X - 1; x++)
            {
                for (int y = 1; y < Dimentions.Y - 1; y++)
                {
                    cells[x, y] = '.';
                }
            }
        }

        public void ChangeCell(Vector cellCoords)
        {
            if (cells[cellCoords.X, cellCoords.Y] == '.')
            {
                cells[cellCoords.X, cellCoords.Y] = '#';
            }
            else
            {
                cells[cellCoords.X, cellCoords.Y] = '.';
            }
        }

        public void Save()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream("maps.db", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fileStream, this);
            }
        }

        public void Draw(Vector cursor, ConsoleColor mapColor = ConsoleColor.White, ConsoleColor cursorColor = ConsoleColor.Red)
        {
            for (int y = 0; y < Dimentions.Y; y++)
            {
                for (int x = 0; x < Dimentions.X; x++)
                {
                    if (cursor.X == x && cursor.Y == y)
                    {
                        Console.ForegroundColor = cursorColor;
                        Console.Write(cells[x, y] + " ");
                        Console.ForegroundColor = mapColor;
                    }
                    
                    Console.Write(cells[x, y] + " ");
                }

                Console.Write("\n");
            }
        }

        public void Draw(ConsoleColor mapColor = ConsoleColor.White)
        {
            Console.ForegroundColor = mapColor;

            for (int y = 0; y < Dimentions.Y; y++)
            {
                for (int x = 0; x < Dimentions.X; x++)
                {
                    Console.Write(cells[x, y] + " ");
                }

                Console.Write("\n");
            }
        }

        public Map Load()
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fileStream = new FileStream("maps.db", FileMode.OpenOrCreate))
            {
                return (Map)formatter.Deserialize(fileStream);
            }
        }
    }
}
