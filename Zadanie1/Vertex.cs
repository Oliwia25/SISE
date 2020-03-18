using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{
    class Vertex
    {
        public int columnsNumber;
        public int rowsNumber;

        public List<Vertex> children = new List<Vertex>();
        public Vertex parent;
        public List<int> game = new List<int>();
        public int emptyTile = 0;

        public Vertex(List<int> g)
        {
            for (int i = 0; i < game.Count; i++)
            {
                game[i] = g[i];
            }
        }

        public void Move(List<int> g, int i1, int i2)
        {
            List<int> newBoard = new List<int>();
            CopyBoard(newBoard, g);

            int tmp = newBoard[i1];
            newBoard[i1] = newBoard[i2];
            newBoard[i2] = tmp;

            Vertex child = new Vertex(newBoard);
            children.Add(child);
            child.parent = this;
        }

        public void CopyBoard(List<int> a, List<int> b)
        {
            for (int i = 0; i < b.Count; i++)
            {
                a[i] = b[i]; // Kopiujemy bo każdy ruch to kolejna nowa tablica
            }
        }

        public void MoveUp(List<int> g, int index)
        {
            if (index - columnsNumber >= 0)
            {
                Move(g, index - columnsNumber, index);
            }
        }

        public void MoveDown(List<int> g, int index)
        {
            if (index + columnsNumber < game.Count)
            {
                Move(g, index + columnsNumber, index);
            }
        }

        public void MoveLeft(List<int> g, int index)
        {
            if (index % columnsNumber > 0)
            {
                Move(g, index - 1, index);
            }
        }

        public void MoveRight(List<int> g, int index)
        {
            if (index % columnsNumber < columnsNumber - 1)
            {
                Move(g, index + 1, index);
            }
        }

        public void UseMove()
        {
            for (int i = 0; i < game.Count; i++)
            {
                if (game[i] == 0)
                {
                    emptyTile = i;
                }
            }
            MoveUp(game, emptyTile);
            MoveDown(game, emptyTile);
            MoveRight(game, emptyTile);
            MoveLeft(game, emptyTile);
        }

        public bool GoalCheck()
        {
            bool isBoardGoal = true;
            int tileNumber = game[0];
            for (int i = 1; i < game.Count; i++)
            {
                if (tileNumber > game[i])
                {
                    isBoardGoal = false;
                }
                tileNumber = game[i];
            }
            return isBoardGoal;
        }

        public void PrintBoard()
        {
            Console.WriteLine();
            int index = 0;
            for(int i = 0; i < columnsNumber; i++)
            {
                for (int j = 0; j < columnsNumber; j++)
                {
                    Console.Write(game[index] + " ");
                    index++;
                }
                Console.WriteLine();
            }

        }

        public bool IsBoardRepeated(List<int> b)
        {
            bool repeated = true;
            for(int i = 0; i < b.Count; i++)
            {
                if(game[i] != b[i])
                {
                    repeated = false;
                }
            }
            return repeated;
        }
    }
}
