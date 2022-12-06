<Query Kind="Statements" />

var input = File.ReadAllText(@"C:\Users\Jan-Willem\Downloads\input6.txt");
var buffer = new char[14];
var bufferIndex = 0;
for (int i = 0; i < input.Length; i++) {
	if (bufferIndex >= 14) {
		bufferIndex = 0;
	}
	
	buffer[bufferIndex] = input[i];
	bufferIndex++;
	if (buffer.Distinct().Count() == 14 && !buffer.Any(c => c == '\0')) {
		Console.WriteLine(i+1);
		break;
	}
}