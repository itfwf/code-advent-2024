using System.Text.RegularExpressions;

namespace CodeAdvent.Day3;

internal static class Problem
{

    public static string ParseInput()
    {
        return File.ReadAllText("Day3/input.txt");
    }

    const string mul = "mul(";
    public static long MulResult(string input)
    {
        var pairs = new List<(long, long)>();

        for (int i = 0; i < input.Length; i++)
        {
            try
            {
                var pair = GetPairStartingIdx(input, ref i);
                if (pair == null)
                {
                    continue;
                }
                pairs.Add((pair.Value.Item1, pair.Value.Item2));
            }
            catch (Exception e)
            {
                break;
            }
        }

        //string pattern = @"mul\((\d+),(\d+)\)";
        //var pairs2 =new List<(long, long)>();
        //var matches=Regex.Matches(input, pattern);
        //foreach (Match match in matches)
        //{
        //    pairs2.Add((long.Parse(match.Groups[1].Value), long.Parse(match.Groups[2].Value)));
        //}
        //var notIn = pairs2.Except(pairs).ToList();

        //notIn.ForEach(p =>
        //{
        //    Console.WriteLine($"{p} ");
        //});
        return pairs.Sum(p => p.Item1 * p.Item2);
    }

    public static long MulMostRecent(string input)
    {
        var pairs = new List<(long, long)>();

        var lastValue = true;
        var isEnabled = lastValue;
        for (int i = 0; i < input.Length; i++)
        {
            try
            {
                isEnabled = GetIsEnabled(input, isEnabled, i);

                var pair = GetPairStartingIdx(input, isEnabled, ref i);

                if (pair == null)
                {
                    continue;
                }
                pairs.Add((pair.Value.Item1, pair.Value.Item2));
            }
            catch (Exception e)
            {
                break;
            }
        }

        //string pattern = @"mul\((\d+),(\d+)\)";
        //var pairs2 =new List<(long, long)>();
        //var matches=Regex.Matches(input, pattern);
        //foreach (Match match in matches)
        //{
        //    pairs2.Add((long.Parse(match.Groups[1].Value), long.Parse(match.Groups[2].Value)));
        //}
        //var notIn = pairs2.Except(pairs).ToList();

        //notIn.ForEach(p =>
        //{
        //    Console.WriteLine($"{p} ");
        //});
        return pairs.Sum(p => p.Item1 * p.Item2);
    }

    private static bool GetIsEnabled(string input, bool lastValue, int i)
    {
        var enStr = "do()";
        var disabledStr = "don't()";

        var enIdx = input[0..i].LastIndexOf(enStr);
        var disIdx = input[0..i].LastIndexOf(disabledStr);

        if (enIdx < 0 && disIdx < 0) {

            return true;
        }

        if (enIdx > 0 && enIdx > disIdx)
        {

            return true;
        }
        if(disIdx>0 && disIdx > enIdx)
        {
            return false;
        }

        return false;//???
    }
    private static (long, long)? GetPairStartingIdx(string input, bool isEnabled, ref int startIdx)
    {
        var idx = input.IndexOf(mul, startIdx);
        if (idx < 0)
        {
            throw new Exception();
        }

        var colonIdx = input.IndexOf(",", idx + mul.Length);
        if (colonIdx < 0)
        {
            throw new Exception();
        }
        var firstNumber = input[(idx + mul.Length)..colonIdx];

        if (!long.TryParse(firstNumber, out var firstNr))
        {
            startIdx = idx + mul.Length;
            return null;
        }

        var endIdx = input.IndexOf(")", colonIdx + 1);

        if (endIdx < 0)
        {
            throw new Exception();
        }

        var lastNumber = input[(colonIdx + 1)..endIdx];

        if (!long.TryParse(lastNumber, out var lastNr))
        {
            startIdx = idx + mul.Length;
            return null;
        }

        startIdx = idx + mul.Length;
        if (!isEnabled)
        {
            return null;
        }
        return (firstNr, lastNr);
    }

    public (int, int) GetNextValidStartEnd(string input)
    {

    }
    private static (long, long)? GetPairStartingIdx(string input, ref int startIdx)
    {
        var idx = input.IndexOf(mul, startIdx);
        if (idx < 0)
        {
            throw new Exception();
        }

        var colonIdx = input.IndexOf(",", idx + mul.Length);
        if (colonIdx < 0)
        {
            throw new Exception();
        }
        var firstNumber = input[(idx + mul.Length)..colonIdx];

        if (!long.TryParse(firstNumber, out var firstNr))
        {
            startIdx = idx + mul.Length;
            return null;
        }

        var endIdx = input.IndexOf(")", colonIdx + 1);

        if (endIdx < 0)
        {
            throw new Exception();
        }

        var lastNumber = input[(colonIdx + 1)..endIdx];

        if (!long.TryParse(lastNumber, out var lastNr))
        {
            startIdx = idx + mul.Length;
            return null;
        }

        startIdx = idx + mul.Length;

        return (firstNr, lastNr);
    }
}
