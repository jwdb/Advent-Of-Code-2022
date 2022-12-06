<Query Kind="Statements" />

var input = File.ReadAllLines("../Downloads/input.txt");
var sets = new List<(string item, List<int> set1, List<int> set2)>();
var counter = 0;
foreach (var line in input) {
    var first = line.Split(',')[0];
    var second = line.Split(',')[1];
    var firstStart = int.Parse(first.Split('-')[0]);
    var firstEnd = int.Parse(first.Split('-')[1]);
    var secondStart = int.Parse(second.Split('-')[0]);
    var secondEnd = int.Parse(second.Split('-')[1]);


    var firstList = Enumerable.Range(firstStart, firstEnd - firstStart + 1).ToList();
    var secondList = Enumerable.Range(secondStart, secondEnd - secondStart + 1).ToList();
    sets.Add((line,firstList, secondList));
}

foreach (var set in sets) {
    if (set.set1.Any(c => set.set2.Any(g => g == c))) {
        counter++;
    } else if (set.set2.Any(c => set.set1.Any(g => g == c))) {
        counter++;
    }
}

Console.WriteLine(counter);