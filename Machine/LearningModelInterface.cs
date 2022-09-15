namespace RoomProblem.Machine
{
    public interface LearningModelInterface
    {
        int NumberStates { get; }
        int NumberActions { get; }
        int[] GetActions(int currentState);
        double GetReward(int currentState, int action);
        bool IsStateReached(int currentState);
    }
}
