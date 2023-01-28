using Data_Structures.DataStructures.Tree.Algorithms;

public class Program
{
    public static void Main(string[] args)
    {
        int[] arr = { 54, 65, 24, 64, 34, 98 };

        Sort.SelectionSort(arr);

        foreach (var item in arr)
            Console.Write(item + " ");
        Console.WriteLine();

        Int32 x = 5;
        Sort.d(x);

        Console.WriteLine(x);    
    }
}
