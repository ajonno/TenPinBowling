# TenPinBowling

This app was written in C# (Console app), using Visual Studio 2015 (Update 1). Note that there's some placeholder code in Program.cs for testing to the console if needed.

TASK:
To help with the club, we have engaged you to program a scoring system.

The features on the system are:

* One player only
* In each frame, the bowler has 2 tries to knock down all the pins
* If in 2 tries, the bowler fails to knock down all the pins, their score is the sum of the number of pins they've knocked down in the 2 attempts
E.g, if a bowler rolls, 4,4, then their score is 8.
* If in 2 tries, the bowler knocks down all the pins, it is a spare. The scoring of a spare is the sum of the number of pins knocked down plus the number of pins knocked down in the next bowl.

E.g, if a bowler rolls, 4,6 | 5,0, then their score is 20 = (4 + 6 + 5) + (5 + 0).
* If in one try, the bowler knocks down all the pins, it is a strike. The scoring of a strike is the sum of the number of pins knocked down plus the number of pins knocked down in the next two bowls.

E.g, if a bowler rolls, 10 | 5, 4, then their score is 28 = (10 + 5 + 4) + (5 + 4).
* There are 10 pins in a frame
* There are 10 frames in a match

The interface should look like this;

bowlingGame.roll(noOfPins);

bowlingGame.score();
