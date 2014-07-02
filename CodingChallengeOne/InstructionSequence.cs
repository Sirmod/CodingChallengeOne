namespace CodingChallengeOne
{
    using System;

    public class InstructionSequence
    {
        private readonly int[] sequence;
        private readonly ModuloHelper moduloHelper;
        private readonly Action[] instructions;
        private int direction;

        public InstructionSequence(int[] sequence, ModuloHelper moduloHelper)
        {
            this.sequence = sequence;
            this.moduloHelper = moduloHelper;
            CurrentIndex = 0;
            direction = 1;

            // This array is used for switchless implementation of ExecuteStep().
            instructions = new Action[]
                           {
                               Stop,
                               DoNothing,
                               IncrementPreviousInstruction,
                               DecrementPreviousInstruction,
                               ReverseDirection
                           };
        }

        public bool Stopped { get; set; }

        public int CurrentIndex { get; set; }

        public int CurrentInstruction
        {
            get { return sequence[CurrentIndex]; }
        }

        public int PreviousIndex
        {
            get { return GetIndexWithModulo(); }
        }

        public int PreviousInstruction
        {
            get { return sequence[PreviousIndex]; }
            set { sequence[PreviousIndex] = value; }
        }

        public void ExecuteNextStep()
        {
            MoveToNextStep();
            ExecuteStep();
        }

        public override string ToString()
        {
            return String.Join("", sequence);
        }

        private int GetIndexWithModulo()
        {
            return moduloHelper.Modulo(CurrentIndex - direction, sequence.Length);
        }

        private void MoveToNextStep()
        {
            CurrentIndex = moduloHelper.Modulo(CurrentIndex + direction, sequence.Length);
        }

        private void ExecuteStep()
        {
            instructions[CurrentInstruction].Invoke();

            // Switches aren't really that nice, so you can replace with the above!
//            switch (CurrentInstruction)
//            {
//                case 0:
//                    Stop();
//                    break;
//                case 1:
//                    DoNothing();
//                    break;
//                case 2:
//                    IncrementPreviousInstruction();
//                    break;
//                case 3:
//                    DecrementPreviousInstruction();
//                    break;
//                case 4:
//                    ReverseDirection();
//                    break;
//                default:
//                    throw new InvalidOperationException();
//            }
        }

        private void Stop()
        {
            Stopped = true;
        }

        private void DoNothing() {}

        private void IncrementPreviousInstruction()
        {
            ModifyPreviousInstruction(+1);
        }

        private void DecrementPreviousInstruction()
        {
            ModifyPreviousInstruction(-1);
        }

        private void ModifyPreviousInstruction(int difference)
        {
            PreviousInstruction = moduloHelper.Modulo(PreviousInstruction + difference, instructions.Length);
        }

        private void ReverseDirection()
        {
            direction = -direction;
        }
    }
}