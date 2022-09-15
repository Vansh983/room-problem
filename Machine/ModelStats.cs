using System.Text;
namespace RoomProblem.Machine {
    public class ModelStats {
        public int InitialState { get; set; }
        public int Final { get; set; }
        public int StepCount { get; set; }
        public int[]? Steps { get; set; }

        public override string ToString() {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Number of steps to find solution: {StepCount}");
            sb.AppendLine($"Started at: {InitialState}");
            foreach (var step in Steps)
                sb.AppendLine($"Step: {step}");
            sb.AppendLine($"Final: {Final}");
            return sb.ToString();
        }
    }
}
