namespace RoomProblem.Machine
{
    public interface LearnProblem
    {
        int NumberStates { get; }
        int NumberActions { get; }
        int[] GetActions(int currentState);
        double GetReward(int currentState, int action);
        bool GoalStateReached(int currentState);
    }
}
