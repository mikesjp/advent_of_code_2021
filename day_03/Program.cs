using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

List<string> binaryNumbers = File.ReadAllLines("./data.txt").ToList();

(string gammaValue, string epsilonValue) = CalculateDecimalValue(binaryNumbers);

int g = Convert.ToInt32(gammaValue, 2);
int e = Convert.ToInt32(epsilonValue, 2);

// int epsilon = ~gamma & 0x0000000F; // This didn't work :(

Console.WriteLine($"Power Consumption = {g * e}");

(string, string) CalculateDecimalValue(List<string> values)
{
    int count = values[0].Length;
    int counter = 0;
    string gamma = string.Empty;
    string epsilon = string.Empty;

    while (counter != count)
    {
        var sigma = values
            .Select(v => new { Value = v, Index = counter }) // loop each value in list, looking at index from 0 - value.Length.
            .GroupBy(c => c.Value[counter]) // Re-work value to read first index of first value, then first index of second value etc.
            .Select(c => new { Char = c.Key, Count = c.Count() })
            .Aggregate((a, b) => a.Count > b.Count ? a : b);

        gamma += sigma.Char;
        epsilon += sigma.Char.Equals('0') ? 1 : 0;
        counter++;
    }

    return (gamma, epsilon);
}