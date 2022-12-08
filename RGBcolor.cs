namespace ConsoleApp1;

public class RGBcolor
{
    private readonly int red;
    private readonly int green;
    private readonly int blue;
    private readonly int bitDepth;

    private static int[] counter = new[] { 0, 0, 0, 0 };

    public int Red => red;
    public int Green => green;
    public int Blue => blue;
    public int BitDepth => bitDepth;

    public RGBcolor(int bitDepth, int red, int green, int blue)
    {
        //assign bitsdepth
        if (bitDepth > 31 || bitDepth < 1)
        {
            throw new bitexception("Depth must be in [1:31] range");
        }
        else
        {
            this.bitDepth = bitDepth;
        }
        //assign red
        if (red > (Math.Pow(2, bitDepth) - 1))
        {
            throw new bitexception("color bits must be less than 2^bithdepth  -1 ");
        }
        else
        {
            this.red = red;
        }
        //assign green
        if (green > (Math.Pow(2, bitDepth) - 1))
        {
            throw new bitexception("color bits must be less than 2^bithdepth  -1 ");
        }
        else
        {
            this.green = green;
        }
        //assign blue
        if (blue > (Math.Pow(2, bitDepth) - 1))
        {
            throw new bitexception("color bits must be less than 2^bithdepth  -1 ");
        }
        else
        {
            this.blue = blue;
        }
    }

    public RgbColor8Bit ToRgbColor8BIt()
    {
        return ToRgbAcc();
    }

    protected RgbColor8Bit ToRgbAcc()
    {
        if (this.bitDepth == 8)
        {
            return new RgbColor8Bit(Red, Green, Blue);
        }
        else
        {
            int redto8bit = Valuteto8bit(Red);
            int blueto8bit = Valuteto8bit(Blue);
            int greento8bit = Valuteto8bit(Green);
            return new RgbColor8Bit(redto8bit, greento8bit, blueto8bit);
        }
    }

    public int Valuteto8bit(int val)
    {
        if (bitDepth > 8)
        {
            int tmp = val / Convert.ToInt16(Math.Pow(2, BitDepth - 9));
            int final = Math.Min(((tmp / 2) + (tmp % 2)), (Convert.ToInt16(Math.Pow(2, 8)) - 1));
            return final;
        }
        else if (bitDepth < 8)
        {
            int newval = val;
            int left = 8 - BitDepth;
            while (left != 0)
            {
                int shift = Math.Min(bitDepth, left);
                newval = newval * Convert.ToInt16(Math.Pow(2, shift)) +
                         val / Convert.ToInt16(Math.Pow(2, bitDepth - shift));
                left -= shift;
            }

            return newval;
        }

        return val;
    }
}