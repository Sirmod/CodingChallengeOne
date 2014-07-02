namespace CodingChallengeOne
{
    using System;

    public class Program
    {
        public static void Main()
        {
            Console.Write("Input: ");
            var input = Console.ReadLine();
            var processor = new InstructionProcessor();
            processor.Execute(input);
        }
    }
}