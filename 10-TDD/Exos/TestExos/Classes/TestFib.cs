using Exos.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using Assert = Xunit.Assert;

namespace TestExos.Classes;

// XUnit
public class TestFib
{
    [Theory]
    [InlineData(1)]
    public void TestGetFibSeries_CheckEmptiness(int range)
    {
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();
        Assert.NotEmpty(result);
    }

    [Theory]
    [InlineData(6, 6)]
    public void TestGetFibSeries_CheckCount(int range, int countExpected)
    {
        Fib fib = new(range);
        int result = fib.GetFibSeries().Count;
        Assert.Equal(countExpected, result);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(6, 3)]
    public void TestGetFibSeries_CheckContainOneValue(int range, int valueExpected)
    {
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();

        Assert.Contains(valueExpected, result);
    }

    [Theory]
    [InlineData(6, new int[] { 0, 1, 1, 2, 3, 5 })]
    public void TestGetFibSeries_CheckContainMultipleValues(int range, int[] valuesExpected)
    {
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();
        
        CollectionAssert.AreEquivalent(valuesExpected, result);
    }

    [Theory]
    [InlineData(6, 4)]
    public void TestGetFibSeries_CheckNotContainOneValue(int range, int valueNotExpected)
    {
        Fib fib = new(range);
        List<int> result = fib.GetFibSeries();

        Assert.DoesNotContain(valueNotExpected, result);
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