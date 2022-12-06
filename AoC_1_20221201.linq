<Query Kind="Statements" />

var lines = File.ReadAllLines(@"C:\Users\Jan-Willem\Downloads\input.txt");
var elves = new List<int>() { 0 };
foreach (var line in lines) {
	if (string.IsNullOrEmpty(line)) {
		elves.Add(0);
	} else {
		elves[elves.Count-1]+=int.Parse(line);
	}
}

var max = elves.OrderByDescending(c => c);
max.Take(3).Sum().Dump();