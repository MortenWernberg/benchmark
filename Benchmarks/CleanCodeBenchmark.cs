using Benchmark.Model;
using Benchmark.Model.Enum;
using Benchmark.Model.Polymorphism;
using BenchmarkDotNet.Attributes;
using Bogus;

namespace Benchmark.Benchmarks
{
  [MemoryDiagnoser(false)]
  public class CleanCodeBenchmark
  {
    private List<ShapeSingle> shapesSingle = null!;
    private List<ShapeSingleNoSwitch> shapesSingleNoSwitch = null!;
    private readonly List<Shape> shapesPolymorphism = null!;
    private List<ShapeStruct> structs = null!;

    [GlobalSetup]
    public void GlobalSetup()
    {
      var shapesSingleFaker = new Faker<ShapeSingle>()
        .RuleFor(x => x.Width, x => x.Random.Int(1, 100))
        .RuleFor(x => x.Height, x => x.Random.Int(1, 100))
        .RuleFor(x => x.Type, x => (ShapeType)x.Random.Int(0, 1));

      shapesSingle = shapesSingleFaker.GenerateBetween(10000, 10000);

      shapesSingleNoSwitch = shapesSingle.ConvertAll(s => new ShapeSingleNoSwitch { Width = s.Width, Height = s.Height, Type = s.Type });

      structs = shapesSingle.ConvertAll(s => new ShapeStruct { Height = s.Height, Width = s.Width, Type = (int)s.Type });

      //shapesPolymorphism = shapesSingle.ConvertAll<Shape>(s =>
      //{
      //  if (s.Type == ShapeType.Square)
      //    return new Square(s.Width, s.Height);
      //  return new Triangle(s.Width, s.Height);
      //});
    }

    //[Benchmark(Baseline = true)]
    public double CleanCode()
    {
      return shapesPolymorphism.Sum(s => s.CalcArea());
    }

    //[Benchmark]
    public double NoLinq()
    {
      double sum = 0;
      foreach (var shape in shapesPolymorphism)
        sum += shape.CalcArea();
      return sum;
    }

    //[Benchmark]
    public double SingleClass()
    {
      double sum = 0;
      foreach (var shape in shapesSingle)
        sum += shape.CalcArea();
      return sum;
    }

    [Benchmark]
    public double NoSwitch()
    {
      double sum = 0;
      foreach (var shape in shapesSingleNoSwitch)
        sum += shape.CalcArea();
      return sum;
    }

    [Benchmark]
    public double Struct()
    {
      double sum = 0;
      for (int i = 0; i < structs.Count; i++)
        sum += CalcArea(structs[i]);
      return sum;
    }

    private static readonly double[] multiplier = { 1.0, 0.5 };
    private double CalcArea(ShapeStruct shape)
    {

      return shape.Width * shape.Height * multiplier[shape.Type];
    }
  }
}
