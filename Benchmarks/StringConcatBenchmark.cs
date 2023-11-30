using BenchmarkDotNet.Attributes;
using Bogus;
using System.Text;

namespace Benchmark.Benchmarks
{
  [MemoryDiagnoser]
  public class StringConcatBenchmark
  {
    private class Person
    {
      public string FirstName { get; set; }
      public string LastName { get; set; }
    }

    private List<Person> persons;

    [GlobalSetup]
    public void GlobalSetup()
    {
      var personFaker = new Faker<Person>()
        .RuleFor(x => x.FirstName, x => x.Person.FirstName)
        .RuleFor(x => x.LastName, x => x.Person.LastName)
      ;

      persons = personFaker.GenerateBetween(10000, 10000);
    }

    //[GlobalCleanup]
    //public void GlobalCleanup()
    //{
    //}

    [Benchmark(Baseline = true)]
    public void SingleLineString()
    {
      for (int i = 0; i < persons.Count; i++)
      {
        var query = $"FirstName={persons[i].FirstName}&LastName={persons[i].LastName}";
      }
    }

    [Benchmark]
    public void MultiLineString()
    {
      for (int i = 0; i < persons.Count; i++)
      {
        var query = $"FirstName={persons[i].FirstName}" +
        $"LastName={persons[i].LastName}";
      }
    }

    [Benchmark]
    public void Verbatim()
    {
      for (int i = 0; i < persons.Count; i++)
      {
        var query = @$"FirstName={persons[i].FirstName}&
        LastName={persons[i].LastName}";
      }
    }

    //[Benchmark]
    //public string[] StringConcat()
    //{
    //  string[] strings = new string[persons.Count];
    //  for (int i = 0; i < persons.Count; i++)
    //  {
    //    strings[i] = string.Concat("Full Name: ", persons[i].LastName, ", ", persons[i].FirstName);
    //  }
    //  return strings;
    //}

    //[Benchmark]
    //public void CompositeFormatting()
    //{
    //  string[] strings = new string[persons.Count];
    //  for (int i = 0; i < persons.Count; i++)
    //  {
    //    strings[i] = string.Format("{0}, {1}", persons[i].LastName, persons[i].FirstName);
    //  }
    //}

    //[Benchmark]
    //public string[] StringInterpolation()
    //{
    //  string[] strings = new string[persons.Count];
    //  for (int i = 0; i < persons.Count; i++)
    //  {
    //    strings[i] = $"Full Name: {persons[i].LastName}, {persons[i].FirstName}";
    //  }
    //  return strings;
    //}

    [Benchmark]
    public string[] StringBuilder()
    {
      string[] strings = new string[persons.Count];
      for (int i = 0; i < persons.Count; i++)
      {
        StringBuilder sb = new StringBuilder("Full Name: ");
        //sb.Append("Full Name: ");
        sb.Append(persons[i].LastName);
        sb.Append(", ");
        sb.Append(persons[i].FirstName);
        strings[i] = sb.ToString();
        //sb.Clear();
      }
      return strings;
    }
  }
}
