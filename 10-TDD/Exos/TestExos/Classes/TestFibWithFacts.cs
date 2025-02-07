using Exos.Classes;
using Xunit;

namespace TestExos.Classes;

// XUnit
public class TestFibWithFacts
{
    [Fact]
    public void TestGetFibSeries_CheckEmptiness()
    {
        Fib fib = new(1);
        List<int> result = fib.GetFibSeries();
        Assert.NotEmpty(result);
    }

    [Fact]
    public void TestGetFibSeries_CheckCount_ShouldReturn6()
    {
        Fib fib = new(6);
        int result = fib.GetFibSeries().Count;
        Assert.Equal(6, result);
    }
    
    [Theory]
    [InlineData(1, 0)]
    [InlineData(6,3)]
    public void TestGetFibSeries_CheckContainOneValue(int range, int valueExpected)
    {
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();

        Assert.Contains(valueExpected, result);
    }

    [Theory]
    [InlineData(1, new int[] { 0 })]
    [InlineData(6, new int[] { 3 })]
    [InlineData(6, new int[] { 0, 1, 1, 2, 3, 5 })]
    public void TestGetFibSeries_CheckContainMultipleValues(int range, int[] valuesExpected)
    {
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();

        foreach (var value in valuesExpected)
        {
            Assert.Contains(value, result);
            result.Remove(value);
        }
    }

    [Theory]
    [InlineData(6, new int[] { 4 })]
    public void TestGetFibSeries_CheckNotContainMultipleValues(int range, int[] valuesNotExpected)
    {
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();

        foreach (var value in valuesNotExpected)
        {
            Assert.DoesNotContain(value, result);
        }
    }
    
    /*
     [Theory]
    [InlineData(range, array of int)]
    public void TestGetFibSeries_CheckNotContainMultipleValues(int range, int[] valuesNotExpected)
    {
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();

        foreach (var value in valuesNotExpected)
        {
            Assert.DoesNotContain(value, result);
        }
    }
    */

    [Theory]
    [InlineData(6)]
    public void TestGetFibSeries_CheckListOrder(int range)
    {
        List<int> expected;
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();

        expected = result.OrderBy(x => x).ToList();

        Assert.Equivalent(expected, result);
    }
}