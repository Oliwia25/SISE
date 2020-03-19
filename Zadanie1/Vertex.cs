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
        public int size;

        public List<Vertex> children = new List<Vertex>();
        public Vertex parent;
        public string moveLetter;
        public int depth;
        public int[] game;
        public int emptyTile = 0;

        public Vertex(int[] g)
        {
            this.rowsNumber = g[0];
            this.columnsNumber = g[1];
            this.size = rowsNumber * columnsNumber;
            this.depth = 0;
            game = new int[this.size];

            for (int i = 2; i < game.Length + 2; i++)
            {
                game[i - 2] = g[i];
            }
        }

        public Vertex(int[] g, int col, int row)
        {
            this.rowsNumber = row;
            this.columnsNumber = col;
            this.size = rowsNumber * columnsNumber;
            game = new int[this.size];

            for (int i = 0; i < game.Length; i++)
            {
                game[i] = g[i];
            }
        }

        public void Move(int[] g, int i1, int i2, string letter)
        {
            int[] newBoard = new int[size];
            CopyBoard(newBoard, g);

            int tmp = newBoard[i1];
            newBoard[i1] = newBoard[i2];
            newBoard[i2] = tmp;

            Vertex child = new Vertex(newBoard, columnsNumber, rowsNumber);
            child.moveLetter = letter;
            child.parent = this;
            child.depth = this.depth + 1;
            children.Add(child);
            Console.WriteLine();
            child.PrintBoard();
        }

        public void CopyBoard(int[] a, int[] b)
        {
            for (int i = 0; i < b.Length; i++)
            {
                a[i] = b[i];
            }
        }

        public void MoveUp(int[] g, int index)
        {
            if (index - columnsNumber >= 0)
            {
                Move(g, index - columnsNumber, index, "U");
            }
        }

        public void MoveDown(int[] g, int index)
        {
            if (index + columnsNumber < game.Length)
            {
                Move(g, index + columnsNumber, index, "D");
            }
        }

        public void MoveLeft(int[] g, int index)
        {
            if (index % columnsNumber > 0)
            {
                Move(g, index - 1, index, "L");
            }
        }

        public void MoveRight(int[] g, int index)
        {
            if (index % columnsNumber < columnsNumber - 1)
            {
                Move(g, index + 1, index, "R");
            }
        }

        public void MakeChildren()
        {
            for (int i = 0; i < game.Length; i++)
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
            int tileValue = game[0];
            for (int i = 1; i < game.Length - 1; i++)
            {
                if (tileValue > game[i])
                {
                    isBoardGoal = false;
                }
                tileValue = game[i];
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

        public bool IsBoardRepeated(int[] b)
        {
            bool repeated = true;
            for(int i = 0; i < b.Length; i++)
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
