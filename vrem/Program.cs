// See https://aka.ms/new-console-template for more information
using vrem;
using System;
using System.IO;
using System.Numerics;

Console.WriteLine("testing...");

TestMachine m = new("xyz");
/*
using (StreamWriter outWriter = new("encrypted.txt")){
    outWriter.WriteLine(m.Process("everything comes out as it goes in..."));
}
*/


//test
string test1 = "229 246 229 242 249 244 232 233 238 231 160 227 239 237 229 243 160 239 245 244 160 225 243 160 233 244 160 231 239 229 243 160 233 238 174 174 174";
string test2 = "101 118 101 114 121 116 104 105 110 103 32 99 111 109 101 115 32 111 117 116 32 97 115 32 105 116 32 103 111 101 115 32 105 110 46 46 46";
Console.WriteLine(m.Process(test2));