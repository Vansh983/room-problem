using RoomProblem.Machine;
using RoomProblem;
using System;

namespace RoomProblem
{
    public class Program
    {

        static void Main()
        {
            var qLearning = new LearningModel(0.8, new RoomsProblem());
            Console.WriteLine("Training Agent...");
            qLearning.Training(2000);

            Console.WriteLine("Training is Done!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            do
            {
                Console.WriteLine($"Enter initial state. Number between 0 and the number of states. Press 'q' to exit...");
                int initialState = 0;
                if (!int.TryParse(Console.ReadLine(), out initialState)) break;

                try
                {
                    var qLearningStats = qLearning.Run(initialState);
                    Console.WriteLine(qLearningStats.ToString());

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            while (true);
        }
    }
}
