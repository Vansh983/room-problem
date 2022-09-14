using RoomProblem.Machine.LearningModelInterface;
using System.Collections.Generic;

namespace RoomProblem
{
    class RoomsProblem : LearninngModelInterface
    {
        private double[][] rewardMatrix = new double[6][]
            {
                new double[]{-1, -1, -1, -1,  0, -1 },
                new double[]{-1, -1, -1,  0, -1, 100},
                new double[]{-1, -1, -1,  0, -1, -1},
                new double[]{-1,  0,  0, -1,  0, -1},
                new double[]{ 0, -1, -1,  0, -1, -1},
                new double[]{-1,  0, -1, -1, -1, -1}
            };

        public int NumberStates => 6;

        public int NumberActions => 6;

        public double GetReward(int currentState, int action)
        {
            return rewardMatrix[currentState][action];
        }

        public int[] GetActions(int currentState)
        {
            List<int> validActions = new List<int>();
            for (int i = 0; i < rewardMatrix[currentState].Length; i++)
            {
                if (rewardMatrix[currentState][i] != -1)
                    validActions.Add(i);
            }
            return validActions.ToArray();
        }

        public bool GoalStateReached(int currentState)
        {
            return currentState == 5;
        }
    }
}
