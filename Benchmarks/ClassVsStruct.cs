using BenchmarkDotNet.Attributes;

namespace Benchmark.Benchmarks
{
  public class ClassVsStruct
  {
    public class PointClass
    {
      public int Type { get; set; }
      public int X { get; set; }
      public int Y { get; set; }
    }

    public struct PointStruct
    {
      public int Type { get; set; }
      public int X { get; set; }
      public int Y { get; set; }
    }

    //private readonly List<PointClass> classes = new List<PointClass>(1000000);
    //private readonly List<PointStruct> structs = new List<PointStruct>(1000000);

    [GlobalSetup]
    public void Setup()
    {
      //for (int i = 0; i < classes.Count; i++)
      //  classes.Add(new PointClass() { X = i, Y = i, Type = (ShapeType)(i % 2) });
      //for (int i = 0; i < classes.Count; i++)
      //  structs.Add(new PointStruct() { X = i, Y = i, Type = (ShapeType)(i % 2) });
    }

    [Benchmark(Baseline = true)]
    public void ListOfClassesTest()
    {
      const int length = 1000000;

      var items = new List<PointClass>(length);

      for (int i = 0; i < length; i++)
        items.Add(new PointClass() { X = i, Y = i, Type = i % 2 });

      int sum = 0;
      for (int i = 0; i < items.Count; i++)
        sum += items[i].X + items[i].Y;
    }

    [Benchmark]
    public void ListOfStructsTest()
    {
      const int length = 1000000;

      var items = new List<PointStruct>(length);

      for (int i = 0; i < length; i++)
        items.Add(new PointStruct() { X = i, Y = i, Type = i % 2 });

      int sum = 0;
      for (int i = 0; i < items.Count; i++)
        sum += items[i].X + items[i].Y;
    }
  }
}
