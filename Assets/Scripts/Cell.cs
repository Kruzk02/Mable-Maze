
public class Cell
{
    public int X { get; }
    public int Z { get; }
    
    public bool Visited { get; set; }
    public bool Top { get; set; } = true;
    public bool Bottom { get; set; } = true;
    public bool Left { get; set; } = true;
    public bool Right { get; set; } = true;

    public Cell(int x , int z)
    {
        X = x;
        Z = z;
    }
}
