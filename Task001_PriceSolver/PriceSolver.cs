namespace Task001_PriceSolver;

public sealed class PriceSolver
{
    public int[] Solve(int[] array)
    {
        var bestTrackedMaxIdx = 0;
        var bestTrackedMinIdx = 0;

        var resMaxI = 0;
        var resMaxJ = 1;

        var resMinI = 0;
        var resMinJ = 1;

        var max = array[resMaxI] - array[resMaxJ];
        var min = array[resMinI] - array[resMinJ];

        for (var j = 1; j < array.Length; j++)
        {
            var maxDiff = array[bestTrackedMaxIdx] - array[j];

            if (maxDiff > max)
            {
                max = maxDiff;
                resMaxI = bestTrackedMaxIdx;
                resMaxJ = j;
            }

            if (array[bestTrackedMaxIdx] < array[j])
            {
                bestTrackedMaxIdx = j;
            }

            var minDiff = array[bestTrackedMinIdx] - array[j];

            if (minDiff < min)
            {
                min = minDiff;
                resMinI = bestTrackedMinIdx;
                resMinJ = j;
            }

            if (array[bestTrackedMinIdx] > array[j])
            {
                bestTrackedMinIdx = j;
            }
        }

        return [resMaxI + 1, resMaxJ + 1, resMinI + 1, resMinJ + 1];
    }
}