// See https://aka.ms/new-console-template for more information
using vrem;
using System;
using System.IO;
using System.Numerics;

//Console.WriteLine("testing...");

//TestMachine m = new("xyz");
/*
using (StreamWriter outWriter = new("encrypted.txt")){
    outWriter.WriteLine(m.Process("everything comes out as it goes in..."));
}
*/

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

string fileContent = File.ReadAllText(filePath, System.Text.Encoding.UTF8);
string encryptedContent = m.Process(fileContent);

File.WriteAllText(filePath, encryptedContent, System.Text.Encoding.UTF8);

/*test
string test1 = "229 246 229 242 249 244 232 233 238 231 160 227 239 237 229 243 160 239 245 244 160 225 243 160 233 244 160 231 239 229 243 160 233 238 174 174 174";
string test2 = "68 49 64 49 40 43 53 50 43 48 117 48 34 34 40 24 105 24 16 15 97 30 10 91 16 3 85 12 2 10 250 75 0 249 55 53 51";
string test3 = "97 97 97";
string test4 = "200 198 196";
Console.WriteLine(m.Process(test2));*/