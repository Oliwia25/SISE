//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Zadanie1
//{

//    class AStart
//    {
//        public List<int> game = new List<int>();
//        public List<AStart> children = new List<AStart>();
       
        
//        public AStart(List<int> gameNode) 
//        {
//            for(int i = 0;  i < gameNode.Count; i++)
//            {
//                game[i] = gameNode[i];
//            }
//        }

       

//        public List<string> goalBoard()
//        {
//            List<int> currentNode = new List<int>();
//            List<int> childindex = new List<int>();
//            bool hIsZero = true;
//            int g = 0;

//            CopyBoard(currentNode,game);
//            while (hIsZero)
//            {
//                List<int> allF = new List<int>();
//                int f = 0;
               
//                //int currentH = CompareBoards(currentNode);

//                AllMovesCheck(currentNode);
//                g++;
//                for(int i = 0; i < children.Count; i++)
//                {
//                    int currentH =  CompareBoards(children[i]); // Może jednak zrobić klase Node (która będzie miała tylko listę root i dzieci
//                    if(currentH == 0)
//                    {
//                        hIsZero = true;
//                        // tu zamienić na string i zwrócić go 
//                    }
//                    f = g + currentH;
//                    allF.Add(f);
//                }
//                int minF = allF[0];
//                for (int i = 1; i < allF.Count; i++)
//                {
//                    if(allF[i] < minF)
//                    {
//                        minF = allF[i];
//                    }
//                }
//                // JAKOŚ ŻEBY TO DZIECKO DO KTÓREGO NALEŻY TO F BYŁO currentNode

//            }

           
//        }

//        public int CompareBoards(List<int> gameNode)
//        {
//            int h = 0; // count Numbers On Wrong Positions
//            int number = gameNode[0];
//            for (int i = 1; i < gameNode.Count; i++)
//            {
//                if (number > gameNode[i])
//                {
//                    h += 1;
//                }
//                number = gameNode[i];
//            }
//            return h;
//        }

//        public void AllMovesCheck(List<int> gameNode)
//        {
//            for(int i = 0; i < gameNode.Count; i++)
//            {
//                if(game[i] == 0)
//                {
//                    MoveRight(gameNode,i);
//                    MoveLeft(gameNode, i);
//                    MoveUp(gameNode, i);
//                    MoveDown(gameNode, i);
//                }
//            }
//        }

//        public void CopyBoard(List<int> list1, List<int> list2)
//        {
//            for(int i = 0; i < list2.Count; i++)
//            {
//                list1[i] = list2[i];
//            }
//        }

//        public void MoveRight(List<int> gameNode, int index)
//        {
//            if(index % 4 < 3)
//            {
//                List<int> potentialMove = new List<int>();
//                CopyBoard(potentialMove, gameNode);

//                int swap = potentialMove[index+1];
//                potentialMove[index + 1] = potentialMove[index];
//                potentialMove[index] = swap;

//                AStart child = new AStart(potentialMove);
//                children.Add(child);
//            }
//        }
//        public void MoveLeft(List<int> gameNode, int index)
//        {
//            if (index % 4 > 0)
//            {
//                List<int> potentialMove = new List<int>();
//                CopyBoard(potentialMove, gameNode);

//                int swap = potentialMove[index - 1];
//                potentialMove[index - 1] = potentialMove[index];
//                potentialMove[index] = swap;

//                AStart child = new AStart(potentialMove);
//                children.Add(child);
//            }
//        }

//        public void MoveUp(List<int> gameNode, int index)
//        {
//            if (index - 4 >= 0)
//            {
//                List<int> potentialMove = new List<int>();
//                CopyBoard(potentialMove, gameNode);

//                int swap = potentialMove[index - 3];
//                potentialMove[index - 3] = potentialMove[index];
//                potentialMove[index] = swap;

//                AStart child = new AStart(potentialMove);
//                children.Add(child);
//            }
//        }

//        public void MoveDown(List<int> gameNode, int index)
//        {
//            if (index + 4 < game.Count)
//            {
//                List<int> potentialMove = new List<int>();
//                CopyBoard(potentialMove, gameNode);

//                int swap = potentialMove[index + 3];
//                potentialMove[index + 3] = potentialMove[index];
//                potentialMove[index] = swap;

//                AStart child = new AStart(potentialMove);
//                children.Add(child);
//            }
//        }
//    }
//}
