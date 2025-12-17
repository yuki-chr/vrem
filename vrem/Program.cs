// See https://aka.ms/new-console-template for more information
using vrem;
using System;
using System.IO;
using System.Numerics;

if (args.Length < 2)
{
    Console.WriteLine("Usage: vrem <key> <file path>");
    return;
}

string key = args[0];
string filePath = args[1];

Machine m = new(key);

if (!File.Exists(filePath))
{
    Console.WriteLine($"File not found: {filePath}");
    return;
}

byte[] fileContent = File.ReadAllBytes(filePath);
byte[] encryptedContent = m.Process(fileContent);

File.WriteAllBytes(filePath, encryptedContent);

Environment.Exit(0);