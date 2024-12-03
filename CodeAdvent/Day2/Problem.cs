
namespace CodeAdvent.Day2;

internal static class Problem
{
    public static List<List<int>> ParseInput()
    {
        var lines = new List<List<int>>();
        foreach (var line in File.ReadAllLines("Day2/input.txt"))
        {
            List<int> numbers = new List<int>();
            foreach (string part in line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
            {
                numbers.Add(int.Parse(part));
            }

            lines.Add(numbers);
        }
        return lines;
    }


    public static int Test(List<List<int>> reports)
    {
        return reports.Where(r => IsValidReport(r) || IsValidWithoutOne(r)).Count();
    }

    private static bool IsValidWithoutOne(List<int> r)
    {
        for (int i = 0; i < r.Count; i++)
        {
            if (IsValidReport(r.Where((_, idx) => idx != i).ToList()))
            {
                return true;
            }
        }
        return false;
    }

    private static bool IsValidReport(List<int> r)
    {
        return IsAcendingValidLine(r) || IsDescendingValidLine(r);
    }

    private static bool IsAcendingValidLine(List<int> r)
    {
        var diffs = new List<int>();
        for (int i = 0; i < r.Count - 1; i++)
        {
            diffs.Add(r[i + 1] - r[i]);
        }

        return diffs.All(a => a > 0 && a <= 3);
    }

    private static bool IsDescendingValidLine(List<int> r)
    {
        var diffs = new List<int>();
        for (int i = 0; i < r.Count - 1; i++)
        {
            diffs.Add(r[i] - r[i + 1]);
        }

        return diffs.All(a => a > 0 && a <= 3);
    }

}
