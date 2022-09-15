using System;
using System.Collections.Generic;
using System.Linq;
using RoomProblem.Machine;

namespace RoomProblem.Machine {
    public class LearningModel {
        private Random _random = new Random();
        private double _energy;
        public double Energy { get => _energy; }

        private double[][] _qTable;
        public double[][] QTable { get => _qTable; }

        private LearningModelInterface _qLearningProblem;

        public LearningModel(double energy, LearningModelInterface qLearningProblem) {
            _qLearningProblem = qLearningProblem;
            _energy = energy;
            _qTable = new double[qLearningProblem.NumberStates][];
            for (int i = 0; i < qLearningProblem.NumberStates; i++)
                _qTable[i] = new double[qLearningProblem.NumberActions];
        }

        public void Training(int numberOfIterations) {
            for (int i = 0; i < numberOfIterations; i++) {
                int initialState = SetInitialState(_qLearningProblem.NumberStates);
                StartingSome(initialState);
            }
        }

        public ModelStats Run(int initialState) {
            if (initialState < 0 || initialState > _qLearningProblem.NumberStates) throw new ArgumentException($"Only 0-5 allowed for start [0-{_qLearningProblem.NumberStates}", nameof(initialState));

            var result = new ModelStats();
            result.InitialState = initialState;
            int state = initialState;
            List<int> actions = new List<int>();
            while (true) {
                result.StepCount += 1;
                int action = _qTable[state].ToList().IndexOf(_qTable[state].Max());
                state = action;
                actions.Add(action);
                if (_qLearningProblem.IsStateReached(action)) {
                    result.Final = action;
                    break;
                }
            }
            result.Steps = actions.ToArray();
            return result;
        }

        private void StartingSome(int initialState) {
            int currentState = initialState;
            while (true) {
                currentState = Work(currentState);
                if (_qLearningProblem.IsStateReached(currentState)) break;
            }
        }

        private int Work(int currentState) {
            var validActions = _qLearningProblem.GetActions(currentState);
            int randomIndexAction = _random.Next(0, validActions.Length);
            int action = validActions[randomIndexAction];

            double saReward = _qLearningProblem.GetReward(currentState, action);
            double nsReward = _qTable[action].Max();
            double qCurrentState = saReward + (_energy * nsReward);
            _qTable[currentState][action] = qCurrentState;
            int newState = action;
            return newState;
        }

        private int SetInitialState(int numberOfStates) {
            return _random.Next(0, numberOfStates);
        }
    }
}
