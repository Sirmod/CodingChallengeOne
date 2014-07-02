namespace CodingChallengeOne
{
    using System;

    public class InstructionProcessor
    {
        public void Execute(string input)
        {
            var parser = new SequenceParser();
            var sequence = new InstructionSequence(parser.Parse(input), new ModuloHelper());
            var step = 1;
            while (!sequence.Stopped)
            {
                Console.WriteLine("{0}. {1}", step++, sequence);
                sequence.ExecuteNextStep();
            }
        }
    }
}