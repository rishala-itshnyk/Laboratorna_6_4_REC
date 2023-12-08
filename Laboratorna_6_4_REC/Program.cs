using System;

namespace Laboratorna_6_4_REC
{
    public class Program
    {
        static void FillArrayRecursive(int[] arr, int n, int currentIndex = 0)
        {
            if (currentIndex < n)
            {
                Console.Write($"Element {currentIndex + 1}: ");
                arr[currentIndex] = int.Parse(Console.ReadLine());
                FillArrayRecursive(arr, n, currentIndex + 1);
            }
        }

        static void PrintArrayRecursive(int[] arr, int n, int currentIndex = 0)
        {
            if (currentIndex < n)
            {
                Console.Write($"{arr[currentIndex]} ");
                PrintArrayRecursive(arr, n, currentIndex + 1);
            }
            else
            {
                Console.WriteLine();
            }
        }

        public static int FindMaxIndexRecursive(int[] arr, int n, int currentIndex = 1, int maxIndex = 0)
        {
            if (currentIndex < n)
            {
                if (arr[currentIndex] > arr[maxIndex])
                {
                    maxIndex = currentIndex;
                }

                return FindMaxIndexRecursive(arr, n, currentIndex + 1, maxIndex);
            }

            return maxIndex;
        }

        public static int CalculateProductBetweenZerosRecursive(int[] arr, int n, int currentIndex = 0, int firstZeroIndex = -1, int secondZeroIndex = -1)
        {
            if (currentIndex < n)
            {
                if (arr[currentIndex] == 0)
                {
                    if (firstZeroIndex == -1)
                    {
                        firstZeroIndex = currentIndex;
                    }
                    else
                    {
                        secondZeroIndex = currentIndex;
                    }
                }

                return CalculateProductBetweenZerosRecursive(arr, n, currentIndex + 1, firstZeroIndex, secondZeroIndex);
            }

            if (firstZeroIndex != -1 && secondZeroIndex != -1)
            {
                int product = 1;
                for (int i = firstZeroIndex + 1; i < secondZeroIndex; ++i)
                {
                    product *= arr[i];
                }

                return product;
            }

            return -1;
        }

        public static void TransformArrayRecursive(int[] arr, int n, int currentIndex = 0, int tempIndex = 0)
        {
            if (currentIndex < n)
            { 
                if (currentIndex % 2 == 1)
                {
                    int temp = arr[currentIndex];
                    for (int j = currentIndex; j > tempIndex; j--)
                    {
                        arr[j] = arr[j - 1];
                    }
                    arr[tempIndex] = temp;
                    tempIndex++;
                }
                TransformArrayRecursive(arr, n, currentIndex + 1, tempIndex);
            }
        }

        static void Main() 
        {
            Console.Write("Enter the size of the array: ");
            if (!int.TryParse(Console.ReadLine(), out int n) || n <= 0)
            {
                Console.Error.WriteLine("Invalid array size");
                return;
            }

            int[] arr = new int[n]; 

            FillArrayRecursive(arr, n);
            PrintArrayRecursive(arr, n);

            int maxIndex = FindMaxIndexRecursive(arr, n);
            Console.WriteLine($"Index of the maximum element: {maxIndex}");

            int productBetweenZeros = CalculateProductBetweenZerosRecursive(arr, n);
            if (productBetweenZeros == -1)
            {
                Console.WriteLine("Error: Two zeros are not found in the array.");
            }
            else
            {
                Console.WriteLine($"Product between elements with two zeros: {productBetweenZeros}");
            }

            TransformArrayRecursive(arr, n);
            Console.WriteLine("Transformed Array:");
            PrintArrayRecursive(arr, n);
        }
    }
}
