namespace ConsoleApp1;

public class Rgbacolor : RGBcolor
{
    private readonly int a;

    public Rgbacolor(int bitDepth, int red, int green, int blue, int a) : base(bitDepth, red, green, blue)
    {
        if (a > Math.Pow(2, base.BitDepth) - 1)
        {
            throw new bitexception("Color value must be less than 2^bitdepth -1 ");
        }
        else
        {
            this.a = a;
        }
    }

    public int A => a;
}