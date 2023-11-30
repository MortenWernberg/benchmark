using Benchmark.Model.Enum;

namespace Benchmark.Model
{
  internal class ShapeSingleNoSwitch
  {
    private static readonly double[] multiplier = { 1.0, 0.5 };

    public ShapeType Type { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public double CalcArea()
    {
      return Width * Height * multiplier[(int)Type];
    }
  }
}
