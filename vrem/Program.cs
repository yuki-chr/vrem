// See https://aka.ms/new-console-template for more information
using vrem;
using System;
using System.IO;
using System.Numerics;

if (args.Length < 1)
{
    Console.WriteLine("Usage: vrem <key> <file path> OR vrem <file path>");
    return;
}

string filePath;
string? key;

if (args.Length == 1)
{
    filePath = args[0];
    if (!File.Exists(filePath))
    {
        Console.WriteLine($"File not found: {filePath}");
        return;
    }

    Console.Write("Enter key: ");
    key = Console.ReadLine();
    if (key == null)
    {
        Console.WriteLine("Please provide a key");
        return;
    }

    Machine m = new(key);

    byte[] fileContent = File.ReadAllBytes(filePath);
    byte[] encryptedContent = m.Process(fileContent);

    File.WriteAllBytes(filePath, encryptedContent);
}
else
{
    key = args[0]; //key shouldn't be able to be null here because otherwise it wouldn't count as argument i think
    filePath = args[1];

    Machine m = new(key);

    if (!File.Exists(filePath))
    {
        Console.WriteLine($"File not found: {filePath}");
        return;
    }

    byte[] fileContent = File.ReadAllBytes(filePath);
    byte[] encryptedContent = m.Process(fileContent);

    File.WriteAllBytes(filePath, encryptedContent);
}

Environment.Exit(0);