using System;
using System.Collections.Generic;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin!");

            // Console.WriteLine(l3_2_PermMissingElem(new int[] { 1, 2, 3 }));
            // Console.WriteLine(l4_1_FrogRiverOne(5, new int[] { 1, 2, 4, 3, 5 }));
            // Console.WriteLine(l4_2_PermCheck(new int[] { 1, 2, 2, 3 }));
            // int[] counters;
            // counters = l4_3_MaxCounters(5, new int[] { 3, 4, 4, 6, 1, 4, 4 });

            // for (int i = 0; i < counters.Length; i++)
            // {
            //     Console.Write(counters[i] + ", ");
            // }
            // Console.WriteLine();

            // Console.WriteLine(l4_4_MissingInteger(new int[] { -1, -1, -1, 0, 1, 1, 1, 2 }));
            // Console.WriteLine(l4_4_MissingInteger(new int[] { -1 }));
            // Console.WriteLine(l4_4_MissingInteger(new int[] { 0 }));
            // Console.WriteLine(l4_4_MissingInteger(new int[] { 1 }));
            // Console.WriteLine(l4_4_MissingInteger(new int[] { 1, 3, 6, 4, 1, 2 }));
            // Console.WriteLine(l4_4_MissingInteger(new int[] { 99, 101 }));
            // Console.WriteLine(l5_1_PassingCars(new int[] { 0, 1, 0, 1, 1, 0, 1 }));
            // Console.WriteLine(l6_1_Distinct(new int[] { 2, 1, 1, 2, 3, 1 }));

            // Console.WriteLine(l5_2_ExampleSolution(6, 11, 2));
            // Console.WriteLine(l5_3_GenomicRangeQuery("CAGCCTA", new int[] { 2, 5, 0 }, new int[] { 4, 5, 6 }));
            // Console.WriteLine(l5_3_GenomicRangeQuery("CAGCCTA", new int[] { 0 }, new int[] { 0 }));
            // Console.WriteLine(l5_3_GenomicRangeQuery("AA", new int[] { 0 }, new int[] { 1 }));

            Console.WriteLine(l5_4_MinAvgTwoSlice(new int[] { 1,5,1 }));
        }


        public static int l3_2_PermMissingElem(int[] A)
        {
            Array.Sort(A);

            int current = 0;
            int next = 0;

            //corner cases
            //the array always starts with one
            //so if the array is empty 1 is missing
            if (A.Length == 0)
            {
                return 1;
            }
            //simmilarly
            //if the first value isn't 1, 1 is missing
            if (A[0] != 1)
            {
                return 1;
            }

            for (int i = 0; i < A.Length; i++)
            {
                if (i + 1 > A.Length - 1)
                {//if next 
                    return A[i] + 1;
                }

                current = A[i];
                next = A[i + 1];

                if (next - current != 1)
                {
                    return A[i] + 1;
                }
            }

            return -1;
        }

        public static int l4_1_FrogRiverOne(int X, int[] A)
        {
            HashSet<int> set = new HashSet<int>();//initialise our hashset, a hashset is a super quick table of unique elements

            for (int i = 0; i < A.Length; i++)
            {
                //for each value in A
                if (A[i] <= X)
                {//if current value is less that OR equal to X
                    set.Add(A[i]);//add value to hashset, duplicate values are not added because elements must be unique
                }

                if (set.Count == X)
                {//if the number of elements in the set equals X, we know that we have a set of unique values between 1 and X, in otherwords: a permutation (!)
                    return i;//return i, which represents the earliest second at which a permutation (or frog leaf bridge, whatever) is achieved
                }
            }

            return -1;//if no permutation found, return -1
        }

        public static int l4_2_PermCheck(int[] A)
        {
            HashSet<int> set = new HashSet<int>();
            int highValue = 0;


            for (int i = 0; i < A.Length; i++)
            {//for each value in array
                set.Add(A[i]);//add value to hash set

                if (A[i] > highValue)
                {//if value is the highest value so far, record it
                    highValue = A[i];
                }
            }

            //if set.count equals the highest value we know there are enough unique values in A[] for a permutation
            //however
            //A[] could have contained dupicate numbers that didn't make it into set, obvs that would fuck up a permutation so we compare their respective lengths
            if (set.Count == highValue && set.Count == A.Length)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public static int[] l4_3_MaxCounters(int N, int[] A)
        {

            int[] operations = A;
            int currentOperation = 0;

            int numberOfCounters = N;
            int[] counters = new int[numberOfCounters];

            int highestValue = 0;
            int currentMaxValue = 0;

            for (int i = 0; i < N; i++)
            {
                counters[i] = 0;
            }

            for (int i = 0; i < operations.Length; i++)
            {

                currentOperation = operations[i];

                if (currentOperation > numberOfCounters)
                {
                    //do maximise
                    currentMaxValue = highestValue;

                }
                else
                {
                    //do increase one
                    currentOperation--;

                    if (counters[currentOperation] < currentMaxValue)
                    {//if counter value not maxxed, maximise it
                        counters[currentOperation] = currentMaxValue;
                    }

                    counters[currentOperation] += 1;

                    if (counters[currentOperation] > highestValue)
                    {//if counter value is highest so far, record it
                        highestValue = counters[currentOperation];
                    }



                }
            }


            //maximise unmaxxed values
            for (int i = 0; i < counters.Length; i++)
            {
                if (counters[i] < currentMaxValue)
                {
                    counters[i] = currentMaxValue;
                }
            }

            return counters;
        }

        public static int[] L4_3_exampleSolution(int N, int[] A)


        {
            int maxValue = 0;
            int minValue = 0;

            int[] counters = new int[N];

            for (int i = 0; i < A.Length; i++)
            {
                int operation = A[i];

                if (operation == N + 1)
                {
                    //maximise all
                    minValue = maxValue;
                }
                else
                {
                    //increase 1
                    operation--;
                    counters[operation] = Math.Max(counters[operation] + 1, minValue + 1);
                    maxValue = Math.Max(maxValue, counters[operation]);
                }
            }


            for (int i = 0; i < counters.Length; i++)
            {
                counters[i] = Math.Max(counters[i], minValue);
            }

            return counters;
        }

        public static int l4_4_MissingInteger(int[] A)
        {
            HashSet<int> nums = new HashSet<int>();

            for (int i = 1; i <= A.Length + 1; i++)
            {
                nums.Add(i);
            }

            foreach (int a in A)
            {
                nums.Remove(a);
            }

            foreach (int a in nums)
            {
                return a;
            }

            return 1;
        }

        public static int l5_1_PassingCars(int[] A)
        {
            int carsGoingEast = 0;
            int carsPassing = 0;

            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] == 0)
                {
                    carsGoingEast++;
                }
                else
                {
                    carsPassing += carsGoingEast;

                    if (carsPassing > 1000000000)
                    {//this check is here because if you allow the int to count up in extreme cases it will overflow
                        return -1;
                    }
                }
            }

            return carsPassing;//then if you check it down here it's going to be negative and you're going to be fucked
        }

        public static int l6_1_Distinct(int[] A)
        {
            HashSet<int> set = new HashSet<int>();

            for (int i = 0; i < A.Length; i++)
            {
                set.Add(A[i]);
            }

            return set.Count;
        }

        public static int l5_2_CountDiv(int A, int B, int K)//slow as fuck!
        {
            int cleanlyDivisibleValues = 0;

            for (int i = A; i < B + 1; i++)
            {
                if (i % K == 0)
                {
                    cleanlyDivisibleValues++;
                }
            }

            return cleanlyDivisibleValues;
        }

        public static int l5_2_ExampleSolution(int A, int B, int K)//spooky (as in witchcraft) fast
        {
            int myBase = (int)Math.Ceiling((double)A / K);

            myBase *= K;

            B -= myBase;

            int count = (int)Math.Floor((double)B / K);
            count++;

            return count;
        }


        public static int[] l5_3_GenomicRangeQuery(string S, int[] P, int[] Q)
        {
            int[] A = new int[S.Length + 1];
            int[] C = new int[S.Length + 1];
            int[] G = new int[S.Length + 1];
            int[] T = new int[S.Length + 1];

            int aCount = 0;
            int cCount = 0;
            int gCount = 0;
            int tCount = 0;

            int[] results = new int[P.Length];

            for (int i = 0; i < S.Length; i++)//for each character in DNA string
            {
                switch (S[i])
                {
                    case 'A':
                        aCount++;
                        break;
                    case 'C':
                        cCount++;
                        break;
                    case 'G':
                        gCount++;
                        break;
                    case 'T':
                        tCount++;
                        break;
                    default:
                        break;
                }

                A[i + 1] = aCount;//add the total number of characters encountered at the current index to their own array
                C[i + 1] = cCount;
                G[i + 1] = gCount;
                T[i + 1] = tCount;
                //should end up looking a bit like this
                //A[0,0,1,1,1,1,1,2]
                //C[0,1,1,1,1,2,3,3]
                //G[0,0,0,1,1,1,1,1]
                //T[0,0,0,0,0,0,1,1]
                //note the extra 0 at position 0, this helps us later
            }


            for (int i = 0; i < P.Length; i++)//for each query pair
            {
                int startIndex = P[i];
                int endIndex = Q[i] + 1;//get the start and end of the segment

                //if there is a difference between the total number of individual characters detected at the segment start index and the segment end index then we know that that character is present in that segment
                //we check for this below

                if (A[startIndex] != A[endIndex])
                {
                    results[i] = 1;
                }

                else if (C[startIndex] != C[endIndex])
                {
                    results[i] = 2;
                }

                else if (G[startIndex] != G[endIndex])
                {
                    results[i] = 3;
                }

                else if (T[startIndex] != T[endIndex])//maybe not neccesary
                {
                    results[i] = 4;
                }
            }

            return results;
        }

        public static int l5_4_MinAvgTwoSlice(int[] A)
        {
            int[] values = A;
            double[] prefixSumValues = new double[A.Length];
            int sum = 0;

            double avg2SliceValue = 9999999.0;
            double avg3SliceValue = 9999999.0;

            double currentLowest2SliceValue = 9999999.0;
            double currentLowest3SliceValue = 9999999.0;

            int startingPosition = 0;

            for (int i = 0; i < values.Length; i++)
            {
                sum += values[i];
                prefixSumValues[i] = (double)sum;
            }

            for (int i = 0; i < prefixSumValues.Length; i++)
            {
                avg2SliceValue = 9999999.0;
                avg3SliceValue = 9999999.0;

                try
                {
                    avg2SliceValue = (prefixSumValues[i] - prefixSumValues[i - 2]) / 2;
                }
                catch
                {

                }

                try
                {
                    avg3SliceValue = (prefixSumValues[i] - prefixSumValues[i - 3]) / 3;
                }
                catch
                {

                }



                if (i == 1)
                {
                    avg2SliceValue = prefixSumValues[i] / 2;
                }

                if (i == 2)
                {
                    avg3SliceValue = prefixSumValues[i] / 3;
                }



                if (avg2SliceValue < currentLowest2SliceValue && avg2SliceValue < currentLowest3SliceValue)
                {
                    startingPosition = i - 1;
                    currentLowest2SliceValue = avg2SliceValue;
                }

                if(avg3SliceValue < currentLowest3SliceValue && avg3SliceValue < currentLowest2SliceValue){
                    startingPosition = i - 2;
                    currentLowest3SliceValue = avg3SliceValue;
                }


            }

            return startingPosition;
        }
    }


}
