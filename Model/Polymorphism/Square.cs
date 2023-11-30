namespace Benchmark.Model.Polymorphism
{
  internal class Square : Shape
  {
    public int Width { get; set; }
    public int Height { get; set; }

    public Square(int width, int height)
    {
      Width = width;
      Height = height;
    }

    public override double CalcArea()
    {
      return Width * Height;
    }
  }
}
