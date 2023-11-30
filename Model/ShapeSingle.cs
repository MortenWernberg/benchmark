using Benchmark.Model.Enum;

namespace Benchmark.Model
{
  internal class ShapeSingle
  {
    public ShapeType Type { get; set; }
    public int Width { get; set; }
    public int Height { get; set; }

    public double CalcArea()
    {
      return Type switch
      {
        ShapeType.Square => Width * Height,
        ShapeType.Triangle => Height * Width * 0.5,
        _ => 0,
      };
    }
  }
}
