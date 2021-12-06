using System;
using System.Collections.Generic;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin!");

            // Console.WriteLine(L3_2_PermMissingElem(new int[]{1,2,3}));
            // Console.WriteLine(L4_1_FrogRiverOne(5, new int[]{1,2,4,3,5}));
            Console.WriteLine(L4_2_PermCheck(new int[]{1,2,2,3}));

        }


        public static int L3_2_PermMissingElem(int[] A){
            Array.Sort(A);

            int current = 0;
            int next = 0;

            //corner cases
            //the array always starts with one
            //so if the array is empty 1 is missing
            if(A.Length == 0){
                return 1;
            }
            //simmilarly
            //if the first value isn't 1, 1 is missing
            if(A[0] != 1){
                return 1;
            }
            
            for(int i = 0; i < A.Length; i++){
                if(i + 1 > A.Length - 1){//if next 
                    return A[i] + 1;
                }

                current = A[i];
                next = A[i + 1];

                if(next - current != 1){
                    return A[i] + 1; 
                }
            }

            return -1;
        }

        public static int L4_1_FrogRiverOne(int X, int[] A){
            HashSet<int> set = new HashSet<int>();//initialise our hashset, a hashset is a super quick table of unique elements

            for(int i = 0; i < A.Length; i++){
                //for each value in A
                if(A[i] <= X){//if current value is less that OR equal to X
                    set.Add(A[i]);//add value to hashset, duplicate values are not added because elements must be unique
                }

                if(set.Count == X){//if the number of elements in the set equals X, we know that we have a set of unique values between 1 and X, in otherwords: a permutation (!)
                    return i;//return i, which represents the earliest second at which a permutation (or frog leaf bridge, whatever) is achieved
                }
            }

            return -1;//if no permutation found, return -1
        }

        public static int L4_2_PermCheck(int [] A){
            HashSet<int> set = new HashSet<int>();
            int highValue = 0;
            
    
            for(int i = 0; i < A.Length; i++){//for each value in array
                set.Add(A[i]);//add value to hash set

                if(A[i] > highValue){//if value is the highest value so far, record it
                    highValue = A[i];
                }
            }

            //if set.count equals the highest value we know there are enough unique values in A[] for a permutation
            //however
            //A[] could have contained dupicate numbers that didn't make it into set, obvs that would fuck up a permutation so we compare their respective lengths
            if(set.Count == highValue && set.Count == A.Length){
                return 1;
            } else {
                return 0;
            }
        }
    }
}
