<Query Kind="Statements" />

var input = File.ReadAllLines(@"input.txt");
var backpacks = new List<(string entire, string compartment1, string compartment2)>();
foreach (var element in input)
{
	var l = element.Length / 2;
	var compartment1 = element[..l];
	var compartment2 = element[l..];
	backpacks.Add((element, compartment1, compartment2));
}

var dupes = backpacks.SelectMany(backpack => backpack.compartment1.Intersect(backpack.compartment2)).ToList();

var nonCapitalScores = Enumerable.Range(97, 26).Select((i, index) => (index + 1, (char)i));
var capitalScores = Enumerable.Range(65, 26).Select((i,index) => (index+27,(char)i));

var scores = nonCapitalScores.Concat(capitalScores).ToDictionary(c => c.Item2, c => c.Item1);

dupes.Select(dupe => scores[dupe]).Sum().Dump();


input.Chunk(3).SelectMany(c => c[0].Intersect(c[1]).Intersect(c[2])).Select(dupe => scores[dupe]).Sum().Dump();