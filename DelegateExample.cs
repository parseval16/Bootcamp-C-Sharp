using System;

//public delegate <ReturnType> <CommandClassName>(ArgumentList)
public delegate void SortCommand(string[] items);
/* public class SortCommand{
 
    public void Invoke(){}
}*/
 
public class Program
{
    public static  void BubbleSort(string[] items){ Console.WriteLine("Bubble Sort");}
    public static void QuickSort(string[] items){Console.WriteLine("Quick Sort"); }

    public static void BinarySearch(string[] items, string key ,SortCommand funObj){

        funObj.Invoke(items);
    }
    public static void Main()
    {
        string[] items={"abc","pqrs","abcde","test"};
        Console.WriteLine("Hello World");
        SortCommand bubbleSortFunObj=new SortCommand(Program.BubbleSort);
        Program.BinarySearch(items,"abc",bubbleSortFunObj);
        SortCommand quickSortFunObj=new SortCommand(Program.QuickSort);
        Program.BinarySearch(items,"pqrs",quickSortFunObj);
    }
}