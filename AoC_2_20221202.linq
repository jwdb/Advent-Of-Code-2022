<Query Kind="Statements" />

var lines = File.ReadAllLines(@"C:\Users\Jan-Willem\Downloads\input1.txt");
var elves = new List<int>() { 0 };
foreach (var line in lines) {
	var opponentThrow = line.Split(' ')[0];
	var myThrow = line.Split(' ')[1];
	int score = 0;
	if (myThrow == "X") {
			score += 0;	
			
		if (opponentThrow == "A") {
			score += 3;
		} else if (opponentThrow == "B") {
			score += 1;
		} else if (opponentThrow == "C") {
			score += 2;
		}
	} else if (myThrow == "Y") {
		score += 3;	
		
		if (opponentThrow == "A") {
			score += 1;
		} else if (opponentThrow == "B") {
			score += 2;
		} else if (opponentThrow == "C") {
			score += 3;
		}
	} else if (myThrow == "Z") {
		score += 6;	
		
		if (opponentThrow == "A") {
			score += 2;
		} else if (opponentThrow == "B") {
			score += 3;
		} else if (opponentThrow == "C") {
			score += 1;
		}
	}
	elves.Add(score);
}

elves.Sum().Dump();