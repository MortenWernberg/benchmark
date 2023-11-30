using Benchmark.Benchmarks;
using BenchmarkDotNet.Running;

//int sizeOfInt = sizeof(int);
//int sizeOfDouble = sizeof(double);
//int sizeOfFloat = sizeof(float);
//int sizeOfEnum = sizeof(ShapeType);
//Console.WriteLine(sizeOfInt + " " + sizeOfDouble + " " + sizeOfFloat + " " + sizeOfEnum);
//Console.WriteLine("SizeOf = " + Marshal.SizeOf(new ShapeStruct()));
//Polymorphism test = new Polymorphism();
//test.GlobalSetup();

//Console.WriteLine("SizeOf = " + Marshal.SizeOf(new ShapeStruct()));

BenchmarkRunner.Run<StringConcatBenchmark>();

//BenchmarkRunner.Run<ClassVsStruct>();
