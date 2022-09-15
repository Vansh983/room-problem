using RoomProblem.Machine;
using RoomProblem;
using System;

namespace RoomProblem {
    public class Program {
        static void Main() {
            var qLearning = new LearningModel(0.8, new RoomsProblem());
            Console.WriteLine("Let the Machine Learn...");
            qLearning.Training(2000);

            Console.WriteLine("Machine is ready to solve your problem!");
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
            do {
                Console.WriteLine($"Where do you want to start? Number between 0 and the number of states. Enter 'q' to exit...");
                int initialState = 0;
                if (!int.TryParse(Console.ReadLine(), out initialState)) break;

                try {
                    var qLearningStats = qLearning.Run(initialState);
                    Console.WriteLine(qLearningStats.ToString());

                } catch (Exception ex) {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
            while (true);
        }
    }
}
