using System;
using System.Collections.Generic;
using System.Linq;

namespace CannonLoader
{
    public class CannonLoaderSolution
    {
        private IEnumerable<int> PickIndexes(int[] A)
        {
            for (var i = 1; i < A.Length - 1; i++)
            {
                if (A[i] > A[i - 1] && A[i] > A[i + 1])
                    yield return i;
            }
        }

        private bool CanGetLargerDistances(int[] indexes, int distance)
        {
            var totalDistances = 1;
            var currentDistance = 0;
            for (var i = 0; i < indexes.Length - 1; i++)
            {
                currentDistance += indexes[i + 1] - indexes[i];
                if (currentDistance >= distance)
                {
                    totalDistances++;
                    currentDistance = 0;
                    if (totalDistances == distance)
                        return true;
                }
            }

            return totalDistances >= distance;
        }

        public int Solution(int[] A)
        {
            if (A == null || A.Length == 0)
                throw new ArgumentException("Picks array not valid");

            var picks = PickIndexes(A).ToArray();
            if (picks.Length == 0)
                throw new ArgumentException("No picks found");

            // Minimum iterations cannons number guess
            int min = 0, max = picks.Length + 1;
            while (min + 1 < max)
            {
                var guess = (min + max) / 2;
                if (CanGetLargerDistances(picks, guess))
                {
                    min = guess;
                }
                else
                {
                    max = guess;
                }
            }

            return min;
        }
    }
}