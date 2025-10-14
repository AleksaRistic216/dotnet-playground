using BenchmarkDotNet.Attributes;
namespace Benchmarks;

public class NullOrEmptyVSNullOrWhiteSpace {
    static string str = "     ";
    
    [Benchmark]
    public void IsNullOrWhiteSpace_100_000_Times() {
        for(var i = 0; i < 100_000; i++)
            string.IsNullOrWhiteSpace(str);
    }

    [Benchmark]
    public void IsNullOrEmpty_100_000_Times() {
        for(var i = 0; i < 100_000; i++)
            string.IsNullOrEmpty(str);
    }
}