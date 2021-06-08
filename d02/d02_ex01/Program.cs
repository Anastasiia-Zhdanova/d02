using System;
using System.Collections;
using System.Collections.Generic;
using d02_ex01;
using d02_ex01.Sources;

if (args.Length != 4)
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return;
}

int parseSecondArg;
int parseFirstArg;

if (Int32.TryParse(args[1], out parseFirstArg) == false || Int32.TryParse(args[3], out parseSecondArg) == false)
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return;
}

List<IConfigurationSource> sources = new();
sources.Add(new JsonSource(args[0], parseFirstArg));
sources.Add(new YamlSource(args[2], parseSecondArg));

Configuration config = new (sources);

Hashtable hashMap = config.parseSources();

if (hashMap == null)
{
    Console.WriteLine("Invalid data. Check your input and try again.");
    return;
}

foreach (DictionaryEntry entry in hashMap)
{
    Console.WriteLine($"{entry.Key}: {entry.Value}");
}