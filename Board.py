from copy import deepcopy
from os import system
from queue import Queue


class Board:
    f_contents = []

    def __init__(self):
        self.goal = [[" 1", " 2", " 3", " 4"],
                     [" 5", " 6", " 7", " 8"],
                     [" 9", "10", "11", "12"],
                     ["13", "14", "15", "__"]]

    def open(self, filename):
        with open(filename) as f:
            for line in f:
                row = line.split(",")
                self.f_contents.append(row)
            print(self.f_contents)

    def write(self, filename):
        with open(filename, 'w') as f:
            for item in self.f_contents:
                f.write("%s\n" % item)
