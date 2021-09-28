using System;

public class Program
{
    public static void Test(){}
    public static void NewTest(int x){}
    public static void FooTest(int x,int y){}
    public static void FunTest(string  x,string  y){}
    public static bool EnoughTest(int  x,string  y){ return true;}
    public static string TestAdd(string  x,string  y){ return x+y;}
 
    public static void FunctioAsAnArgument(
        Action funObj1,
        Action<int> funObj2,
        Action<int,int> funObj3,
        Action<string,string> funObj4,
        Func<int,string,bool> funObj5,
        Func<string,string,string> funObj6){
    }
    public static void Main()
    {
        Console.WriteLine("Hello World");
        Action funcObj1=new Action(Program.Test);
        Action<int> funcObj2=new Action<int>(Program.NewTest);
        Action<int,int> funcObj3=new Action<int,int>(Program.FooTest);
        Action<string,string> funcObj4=new Action<string,string>(Program.FunTest);
        Func<int,string,bool> funcObj5=new Func<int,string,bool>(Program.EnoughTest);
        Func<string,string,string> funcObj6=new Func<string,string,string>(Program.TestAdd);
        Program.FunctioAsAnArgument(funcObj1,funcObj2,funcObj3,funcObj4,funcObj5,funcObj6);
    }
}