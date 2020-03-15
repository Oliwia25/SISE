from copy import deepcopy
from os import system
from queue import Queue

MAX_COL = 4
MAX_ROW = 4


class Board:
    def __init__(self):
        self.goal = [[" 1", " 2", " 3", " 4"],
                     [" 5", " 6", " 7", " 8"],
                     [" 9", "10", "11", "12"],
                     ["13", "14", "15", "__"]]

        self.board = deepcopy(self.goal)

        self.empty_loc = [MAX_ROW - 1, MAX_COL - 1]

    def __repr__(self):
        for i in range(MAX_ROW):
            for j in range(MAX_COL):
                print(self.board[i][j], end=" ")
            print()

        # repr must return something
        return ""

    def refresh(self):
        system("clear")
        print("Welcome to the game")
        print(self)

        if self.board == self.goal:
            print("\nYou Won")
            return False
        return True

    def solve(self):
        """Solves with bfs algorithm"""

        def successors(board, e_loc):
            b_lst = [deepcopy(board), deepcopy(board), deepcopy(board), deepcopy(board)]
            e_loc_lst = [list(e_loc), list(e_loc), list(e_loc), list(e_loc)]
            b_lst[0], e_loc_lst[0] = self.move_up(b_lst[0], e_loc_lst[0])
            b_lst[0], e_loc_lst[0] = self.move_right(b_lst[1], e_loc_lst[1])
            b_lst[0], e_loc_lst[0] = self.move_down(b_lst[2], e_loc_lst[2])
            b_lst[0], e_loc_lst[0] = self.move_left(b_lst[3], e_loc_lst[3])

            return [[], [], [], []]

        searched = []  # states that already were
        fringe = Queue()  # nodes that we still want to check out
        root = self.board

        fringe.put({"board": root, "e_loc": self.e_loc, "path": []})
        # start searching the tree
        while True:
            # quit if no solution is found
            if fringe.empty():
                return []

            node = fringe.get()  # inspect current node

            # quit if node contains the goal
            if node["board"] == self.goal:
                return node["path"]  # solve -> return the list of steps that we need to take

            # add current node to search set; put children in the fringe
            if node["board"] not in searched:
                searched.append(node["board"])
               # for child in successors():

