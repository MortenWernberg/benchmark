namespace Benchmark.Model.Polymorphism
{
  internal class Triangle : Shape
  {
    public int Width { get; set; }
    public int Height { get; set; }

    public Triangle(int width, int height)
    {
      Width = width;
      Height = height;
    }

    public override double CalcArea()
    {
      return Width * Height / 2.0;
    }
  }
}
