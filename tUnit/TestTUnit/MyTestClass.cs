using TestTUnit;
using TUnit.Assertions;
using TUnit.Assertions.Extensions;
using TUnit.Core;

namespace TestTUnit;

public class MyTestClass
{
    [Test]
    [Arguments(1, 1, 2)]
    [Arguments(1, 2, 3)]
    [Arguments(2, 2, 4)]
    [Arguments(4, 3, 7)]
    [Arguments(5, 5, 10)]
    public async Task MyTest(int value1, int value2, int expectedResult)
    {
        var result = Add(value1, value2);

        await Assert.That(result).IsEqualTo(expectedResult);
    }

    private int Add(int x, int y)
    {
        return x + y;
    }
}

public record AdditionTestData(int Value1, int Value2, int ExpectedResult);

public static class MyTestDataSources
{
    public static AdditionTestData AdditionTestData()
    {
        return new AdditionTestData(1, 2, 3);
    }
}

public class MyTestClassWithMethodDataSource
{
    [Test]
    [MethodDataSource(typeof(MyTestDataSources), nameof(MyTestDataSources.AdditionTestData))]
    public async Task MyTest(AdditionTestData additionTestData)
    {
        var result = Add(additionTestData.Value1, additionTestData.Value2);

        await Assert.That(result).IsEqualTo(additionTestData.ExpectedResult);
    }

    private int Add(int x, int y)
    {
        return x + y;
    }
}

// Tuples

public static class MyTestDataSourcesWithTuples
{
    public static (int, int, int) AdditionTestData()
    {
        return (1, 2, 3);
    }
}

public class MyTestClassWithTuples
{
    [Test]
    [MethodDataSource(typeof(MyTestDataSourcesWithTuples), nameof(MyTestDataSourcesWithTuples.AdditionTestData))]
    public async Task MyTest(int value1, int value2, int expectedResult)
    {
        var result = Add(value1, value2);

        await Assert.That(result).IsEqualTo(expectedResult);
    }

    private int Add(int x, int y)
    {
        return x + y;
    }
}

// Enumerable

public static class MyTestDataSourcesEnumerable
{
    public static IEnumerable<AdditionTestData> AdditionTestData()
    {
        yield return new AdditionTestData(1, 2, 3);
        yield return new AdditionTestData(2, 2, 4);
        yield return new AdditionTestData(5, 5, 10);
    }
}

public class MyTestClassWithEnumerableDataSource
{
    [Test]
    [MethodDataSource(typeof(MyTestDataSourcesEnumerable), nameof(MyTestDataSourcesEnumerable.AdditionTestData))]
    public async Task MyTest(AdditionTestData additionTestData)
    {
        var result = Add(additionTestData.Value1, additionTestData.Value2);

        await Assert.That(result).IsEqualTo(additionTestData.ExpectedResult);
    }

    private int Add(int x, int y)
    {
        return x + y;
    }
}

// Tuples

public static class MyTestDataSourcesTuples
{
    public static IEnumerable<(int, int, int)> AdditionTestData()
    {
        yield return (1, 2, 3);
        yield return (2, 2, 4);
        yield return (5, 5, 10);
    }
}

public class MyTestClassTuples
{
    [Test]
    [MethodDataSource(typeof(MyTestDataSourcesTuples), nameof(MyTestDataSourcesTuples.AdditionTestData))]
    public async Task MyTest(int value1, int value2, int expectedResult)
    {
        var result = Add(value1, value2);

        await Assert.That(result).IsEqualTo(expectedResult);
    }

    private int Add(int x, int y)
    {
        return x * y;
    }
}