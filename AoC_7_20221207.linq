<Query Kind="Program" />

void Main()
{
	var input = File.ReadAllLines(@"C:\Users\Jan-Willem\Downloads\input7.txt");
	var root = new DirectoryInfo() { Name = "/" };
	root.Parent = root;
	var current = root;
	foreach (var line in input) {
		if (line.StartsWith("$")) {
			if (line.StartsWith("$ cd")) {
				var newPath = line.Split(" ")[2];
				if (newPath == "..") {
					current = current.Parent;
				} else if(newPath == "/") {
					current = root;
				} else {
					if (!current.Children.Any(c => c.Name == newPath && c is DirectoryInfo)) {
						current.Children.Add(new DirectoryInfo() { Name = newPath, Parent = current });
					}
					current = current.Children.First(c => c.Name == newPath && c is DirectoryInfo) as DirectoryInfo;
				}
			}
		} else {
			if (line.StartsWith("dir ")) {
					current.Children.Add(new DirectoryInfo() { Name = line.Split(' ')[1], Parent = current });
			} else {
				var fileSize = long.Parse(line.Split(' ')[0]);
				var fileName = line.Split(' ')[1];
				current.Children.Add(new FileInfo() { Name = fileName, Size = fileSize });
			}
		}
	}
	ChallengeOne(root).Dump("Challenge 1");	
	ChallengeTwo(root).Dump("Challenge 2");	
}

public long ChallengeOne(DirectoryInfo root) {
	long total = 0;
	DirectoryInfo current = root;
	Stack<DirectoryInfo> toProcess = new Stack<DirectoryInfo>();
	toProcess.Push(root);
	do {
		current = toProcess.Pop();
		if (current.Children.Any(c => c is DirectoryInfo)) {
			current.Children.Where(c => c is DirectoryInfo).ToList().ForEach( c=> toProcess.Push(c as DirectoryInfo));
		}
		if (current.Size <= 100000) {
			total += current.Size;
		}
	} while (toProcess.Count > 0);
	return total;
}

public long ChallengeTwo(DirectoryInfo root) {
	long spaceToFree = 30000000 - (70000000 - root.Size);
	spaceToFree.Dump();
	long currentSmallest = root.Size;
	DirectoryInfo current = root;
	Stack<DirectoryInfo> toProcess = new Stack<DirectoryInfo>();
	toProcess.Push(root);
	do {
		current = toProcess.Pop();
		if (current.Children.Any(c => c is DirectoryInfo)) {
			current.Children.Where(c => c is DirectoryInfo).ToList().ForEach( c=> toProcess.Push(c as DirectoryInfo));
		}
		if (current.Size >= spaceToFree && currentSmallest > current.Size) {
			currentSmallest = current.Size;
		}
	} while (toProcess.Count > 0);
	return currentSmallest;
}

// You can define other methods, fields, classes and namespaces here
public interface IFileInfo {
	public string Name { get; set; }
	public long Size { get; }
}

public class DirectoryInfo : IFileInfo {
	public string Name { get; set; }
	public DirectoryInfo Parent { get; set; }
	public List<IFileInfo> Children { get; set; } = new List<IFileInfo>();
	public long Size => Children.Select(c => c.Size).Sum();
}

public class FileInfo : IFileInfo {
	public string Name { get; set; }
	public long Size { get; set; }
}