// See https://aka.ms/new-console-template for more information
using CodeAdvent.Day1;
using CodeAdvent.Day2;

Console.WriteLine("Hello, World!");

#region Day 1
//Console.WriteLine(Problem.SimilarityScore(

//    new List<int>()
//    {
//        3,4,2,1,3,3
//    },
//    new List<int>() {
//        4,3,5,3,9,3
//    })
//    );
//part 1
var inputs = CodeAdvent.Day1.Problem.GetInput();
Console.WriteLine(CodeAdvent.Day1.Problem.GetOffDistance(inputs.left, inputs.right));
//part 2
Console.WriteLine(CodeAdvent.Day1.Problem.SimilarityScore(inputs.left, inputs.right));

#endregion


#region Day 2
Console.WriteLine("Day 2");

var reports = new List<List<int>>()
{
    new List<int>{7, 6, 4, 2, 1 },
    new List<int>{1, 2, 7, 8, 9 },
    new List<int>{9, 7, 6, 2, 1},
    new List<int>{1, 3, 2, 4, 5},
    new List<int>{8, 6, 4, 4, 1},
    new List<int>{1, 3, 6, 7, 9}
};

Console.WriteLine("Input result: " + CodeAdvent.Day2.Problem.Test(CodeAdvent.Day2.Problem.ParseInput()));



#endregion


#region Day 3

var input = "xmul(2,4)%&mul[3,7]!@^do_not_mul(5,5)+mul(32,64]then(mul(11,8)mul(8,5))";
//Console.WriteLine("Res: " + CodeAdvent.Day3.Problem.MulResult(input));
//Console.WriteLine("Res: " + CodeAdvent.Day3.Problem.MulResult("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"));
//Console.WriteLine("Res: " + CodeAdvent.Day3.Problem.MulResult(CodeAdvent.Day3.Problem.ParseInput()));
Console.WriteLine("Res: " + CodeAdvent.Day3.Problem.MulMostRecent("xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))"));
Console.WriteLine("Res: " + CodeAdvent.Day3.Problem.MulMostRecent(CodeAdvent.Day3.Problem.ParseInput()));
//-- 90669332
#endregion