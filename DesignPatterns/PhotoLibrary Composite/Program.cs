using Composite;
using System;
using System.IO;

namespace PhotoLibrary_Composite
{
	internal class Program
    {
	    private static void Main()
        {
	        IComponent<string> album = new Composite<string>("Album");
	        var point = album;

	        const string fileName = "Composite.txt";
	        var path = Path.Combine(Environment.CurrentDirectory, @"Data\", fileName);
	        var instream = new StreamReader(path);

	        var command = "";
	        do
	        {
		        var line = instream.ReadLine();
		        Console.WriteLine($"\t\t\t\t{line}");
		        if (line != null)
		        {
			        var parameters = line.Split();
			        command = parameters[0];

			        var parameter = parameters.Length > 1 ? parameters[1] : null;

			        switch (command)
			        {
				        case "AddSet":
					        var composite = new Composite<string>(parameter);
					        point.Add(composite);
					        point = composite;
					        break;
				        case "AddPhoto":
					        point.Add(new Component<string>(parameter));
					        break;
				        case "Remove":
					        point = point.Remove(parameter);
					        break;
				        case "Find":
					        point = album.Find(parameter);
					        break;
				        case "Display":
					        Console.WriteLine(album.Display((0)));
					        break;
				        case "Quit":
					        break;
			        }
		        }
	        } while (!command.Equals("Quit"));
        }
    }
}
