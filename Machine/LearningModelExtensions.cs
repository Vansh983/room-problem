using System;
using System.Text;

namespace RoomProblem.Machine
{
    public static class LearningExtensions
    {
        public static double[][] NormalizeMatrix(this double[][] matrix)
        {
            var max = matrix.GetMax();

            var normalizedMatrix = new double[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                normalizedMatrix[i] = new double[matrix[i].Length];
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] != 0)
                        normalizedMatrix[i][j] = Math.Round((matrix[i][j] * 100) / max, 0);
                }
            }
            return normalizedMatrix;
        }

        public static double GetMax(this double[][] matrix)
        {
            double max = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] > max)
                        max = matrix[i][j];
                }
            }
            return max;
        }

        public static string Print(this double[][] matrix)
        {
            var sb = new StringBuilder();
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    sb.Append(string.Format("{0}   ", matrix[i][j]));
                }
                sb.AppendLine(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
