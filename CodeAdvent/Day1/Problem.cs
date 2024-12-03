namespace CodeAdvent.Day1;


internal static class Problem
{

    public static (List<int> left, List<int> right) GetInput()
    {
        var left = new List<int>();
        var right = new List<int>();
        foreach (var line in File.ReadAllLines("Day1/input.txt"))
        {
            var str = line.Split("   ");
            left.Add( int.Parse(str[0]));
            right.Add(int.Parse(str[1]));
        }
        return (left, right);
    }

    public static int GetOffDistance(List<int> leftIds, List<int> rightIds)
    {
        leftIds.Sort();
        rightIds.Sort();

        var maxId = Math.Min(leftIds.Count, rightIds.Count);

        var sum = 0;
        for (int i = 0; i < maxId; i++)
        {
            sum += Math.Max(rightIds[i] - leftIds[i], leftIds[i] - rightIds[i]);
        }
        return sum;
    }

    public static int SimilarityScore(List<int> leftIds, List<int> rightIds)
    {
        var rightCounts = rightIds.Aggregate(new Dictionary<int, int>(), (dict, nr) =>
        {
            if (dict.ContainsKey(nr))
            {
                dict[nr]++;
            }
            else
            {
                dict[nr] = 1;
            }
            return dict;
        });
        var sum = 0;
        for (int i = 0; i < leftIds.Count; i++)
        {
            var left = leftIds[i];
            sum += left * (rightCounts.ContainsKey(left) ? rightCounts[left] : 0);
        }

        return sum;
    }
}
