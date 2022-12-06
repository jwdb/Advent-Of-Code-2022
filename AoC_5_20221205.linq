<Query Kind="Program" />

void Main()
{
	var input = File.ReadAllLines(@"C:\Users\Jan-Willem\Downloads\input5.txt").ToList();
	
	var stacks = new List<List<string>>() {
		new List<string>() { "R","N","F","V","L","J","S","M" },
		new List<string>() { "P","N","D","Z","F","J","W","H" },
		new List<string>() { "W","R","C","D","G" },
		new List<string>() { "N","B","S" },
		new List<string>() { "M","Z","W","P","C","B","F","N" },
		new List<string>() { "P","R","M","W" },
		new List<string>() { "R","T","N","G","L","S","W" },
		new List<string>() { "Q","T","H","F","N","B","V"},
		new List<string>() { "L","M","H","Z","N","F"},
	};
	var index = input.FindIndex(c => string.IsNullOrWhiteSpace(c));
	input = input.Skip(index + 1).ToList();
	
		var regex = new Regex(@"move (\d+) from (\d+) to (\d+)");
	foreach (var line in input) {
		
		var matches = regex.Match(line);
		
		var count = int.Parse(matches.Groups[1].Value);
		var from = int.Parse(matches.Groups[2].Value);
		var to = int.Parse(matches.Groups[3].Value);
		
		stacks[to - 1].AddRange(TakeLast(stacks[from - 1],count));
		for(var i = count; i > 0; i--) {
			stacks[from - 1].RemoveAt(stacks[from - 1].Count - i);
		}
	}
	
	stacks.Select( c=> c.Last()).Dump();
}

// You can define other methods, fields, classes and namespaces here
public string pop (List<string> myList) {
    // first assign the  last value to a seperate string 
    string extractedString = myList[myList.Count - 1];
    // then remove it from list
    myList.RemoveAt(myList.Count - 1);
    // then return the value 
    return extractedString;
}

public static IEnumerable<T> TakeLast<T>(IEnumerable<T> source, int N)
{
    return source.Skip(Math.Max(0, source.Count() - N));
}