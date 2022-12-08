namespace ConsoleApp1;

public class bitexception : Exception
{
    public bitexception(String a)
    {
        Console.WriteLine(a);
    }
}