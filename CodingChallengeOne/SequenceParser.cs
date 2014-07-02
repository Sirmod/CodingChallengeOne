namespace CodingChallengeOne
{
    using System;
    using System.Linq;

    public class SequenceParser
    {
        public int[] Parse(string input)
        {
            return input.Select(x => (int)Char.GetNumericValue(x)).ToArray();

            // The above code uses LINQ to do what this for loop does.

//            var sequence = new int[input.Length];
//            for (var i = 0; i < input.Length; i++)
//            {
//                sequence[i] = (int)Char.GetNumericValue(input[i]);
//            }
//            return sequence;
        }
    }
}