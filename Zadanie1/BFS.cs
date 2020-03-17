using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie1
{

    class Vertex
    {
        public List<Vertex> children = new List<Vertex>();
        public Vertex parent;
        public List<int> game = new List<int>();       

        public Vertex(List<int> g)
        {
            SetPuzzle(g);
        }

        public void  SetPuzzle(List<int> g)
        {
            for(int i = 0; i < game.Count; i++)
            {
                game[i] = g[i];
            }
        }

        public void Move(List<int> g, int index, int i1, int i2)
        {
            List<int> searchedBoardMove = new List<int>();
            for(int i = 0; i < g.Count; i++)
            {
                searchedBoardMove[i] = g[i]; // Kopiujemy bo każdy ruch to kolejna nowa tablica
            }
            int tmp = searchedBoardMove[i1];
            searchedBoardMove[i1] = searchedBoardMove[i2];
            searchedBoardMove[i2] = tmp;

            Vertex child = new Vertex(searchedBoardMove);
            children.Add(child);
            child.parent = this;
        }

        public void MoveUp(List<int> g, int index)
        {
            if(index - 4 >= 0)
            {
                Move(g, index, index - 3, index);
            }
        }

        public void MoveDown(List<int> g, int index)
        {
            if(index + 4 < game.Count)
            {
                Move(g, index, index + 3, index);
            }
        }

        public void MoveLeft(List<int> g, int index)
        {
            if(index % 4 > 0)
            {
                Move(g, index, index - 1, index);
            }
        }

        public void MoveRight(List<int> g, int index)
        {
            if(index % 4 < 3)
            {
                Move(g, index, index + 1, index);
            }
        }
        
        public void UseMove()
        {
            for(int i = 0; i< game.Count; i++)
            {
                if(game[i] == 0)
                {
                    MoveUp(game, i);
                    MoveDown(game, i);
                    MoveRight(game, i);
                    MoveLeft(game, i);
                }
            }
        }

        public bool GoalCheck()
        {
            bool isBoardGoal = true;
            int goalNumber = game[0];
            for(int i = 1; i < game.Count; i++)
            {
                if(goalNumber > game[i])
                {
                    isBoardGoal = false;
                }
                goalNumber = game[i];
            }

            return isBoardGoal;
        }

    }

    class BFS
    {
        //actual BFS algorithm
    }
}
