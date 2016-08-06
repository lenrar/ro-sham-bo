import os
import sys
import random

def clear():
    os.system('cls' if os.name == 'nt' else 'clear')

moves = ["Paper", "Rock", "Scissors"]

class MainMenu(object):        
    wins = 0
    losses = 0
    ties = 0
    
    def menu(self, menuItems):
        for i in range(0, len(menuItems)):
            print(str(i + 1) + ": " + menuItems[i])
        selection = input()
        try:
            item = int(selection) - 1
            print(item)
            clear()
            return menuItems[item]
        except ValueError:
            clear()
            print("Invalid input")
            return;

    def resolve(self, p1, p2):
        result = abs(p1 - p2)
        if p1 is p2:
            return 2
        if result % 2 == 0:
            if p1 > p2:
                return 0
            else:
                return 1
        else:
            if p1 > p2:
                return 1
            else:
                return 0

    def statistics(self):
        total = self.wins + self.losses + self.ties
        if total != 0:
            winloss = self.wins + self.losses
            wlr =  self.wins / winloss
            wr = self.wins / total
            print("Statistics")
            print("Total Wins: %d" % self.wins)
            print("Total Losses: %d" % self.losses)
            print("Total Ties: %d" % self.ties)
            print("Win Percentage: %.2f" % wr)
            print("Win-Loss Percentage: %.2f" % wlr)
        else:
            print("No statistics yet. Play some games!")            
        input("Press any key to exit")            
            
    def newgame(self):
        player = ""
        while player != "B":
            ai = random.randint(0, 2)            
            player = input("(R)ock, (P)aper, or (S)cissors, or (B)ack")
            player = player.upper()
            if player == "B":
                break
            print(player)
            pnum = 0;
            if player == "P":
                pnum = 0
            elif player == "R":
                pnum = 1
            elif player == "S":
                pnum = 2
            else:
                print("Invalid input")

            result = self.resolve(pnum, ai)
            if (result == 0):
                print(moves[pnum] + " beats " + moves[ai])
                self.wins += 1
                print("Player wins")
            elif (result == 1):
                print(moves[ai] + " beats " + moves[pnum])
                self.losses += 1
                print("CPU wins")
            else:
                print(moves[pnum] + " ties " + moves[ai])
                self.ties += 1
                print("Tie")
            input("Press any key to continue")
            clear()
        clear()
        
    def start(self):
        print("Welcome to Ro-Sham-Bo")
        input("Press any key to continue");    
        clear()
        menuItems = ["New Game", "Statistics", "Exit"]
        selection = self.menu(menuItems)
        while selection != menuItems[2]:
            if selection is menuItems[0]:
                print("New Game")
                self.newgame()
            elif selection is menuItems[1]:
                self.statistics()
                print("Statistics")
            elif selection is menuItems[2]:
                sys.exit()
            else:
                print("Invalid input")
            clear()
            selection = self.menu(menuItems)
        
def main():
    menu = MainMenu()
    menu.start()
    
if __name__ == "__main__": main()
