using System;
using System.Collections.Generic;

// int gammaRate;
// int episolonRate;

// int powerConsumption = gammaRate * episolonRate;

// 10110 == 22

List<string> binaryNumbers = new List<string>
{
    "00100",
    "11110",
    "10110",
    "10111",
    "10101",
    "01111",
    "00111",
    "11100",
    "10000",
    "11001",
    "00010",
    "01010"
};

CalculateGammaRate(binaryNumbers);


int CalculateGammaRate(List<string> values)
{
    if (values.Count == 0)
    {
        return 0;
    }

    // Find number of digits in number. This assumes all numbers in the list
    // are the same length.
    int numberOfDigits = values[0].Length;

    int[] onesBitCount = new int[numberOfDigits];
    int[] zeroesBitCount = new int[numberOfDigits];

    foreach (string value in values)
    {
        for (int i = 0; i < value.Length; i++)
        {
            if (value[i].Equals('0'))
            {
                zeroesBitCount[i] += 1;
            }
            else
            {
                onesBitCount[i] += 1;
            }
        }
    }
    
    string gammaRate = string.Empty;
    for (int i = 0; i < numberOfDigits; i++)
    {
        int zeroValue = Convert.ToInt32(zeroesBitCount[i]);
        int oneValue = Convert.ToInt32(onesBitCount[i]);
        if (zeroValue > oneValue)
        {
            gammaRate += "0";
        }
        else
        {
            gammaRate += "1";
        }
    }

    Console.WriteLine(gammaRate);
    return 2;
}