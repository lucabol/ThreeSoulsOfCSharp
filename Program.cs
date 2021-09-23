using static System.Diagnostics.Trace;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using BenchmarkDotNet.Order;

[MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class ArmyBenchmark {
  [Params(100, 10_000, 1_000_000)]
  public int N;

  ObjectOriented.WarSystem oo = null!;
  Functional.WarSystem fun = null!;
  DataOriented.WarSystem dat = null!;

  [GlobalSetup]
  public void Setup() {
    oo = new(N * 3);
    fun = new(N * 3);
    dat = new(N * 3);

    // Assert to make sure they perform the same actions
    int datValue = dat.ValueArmy();
    int funValue = fun.ValueArmy();
    int ooValue = oo.ValueArmy();

    Assert(ooValue == funValue);
    Assert(ooValue == datValue);
  }
  [Benchmark] public int ObjectOriented() => oo.ValueArmy();
  [Benchmark] public int Functional() => fun.ValueArmy();
  [Benchmark(Baseline = true)] public int DataOriented() => dat.ValueArmy();
}

public class Program {
        public static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<ArmyBenchmark>();
        }
}
