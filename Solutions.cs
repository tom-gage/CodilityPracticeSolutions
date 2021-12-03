using System;

namespace Codility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Begin!");

            Console.WriteLine(L3_2_PermMissingElem(new int[]{1,2,3}));
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
    }
}
