using Avalonia.Headless.XUnit.v3;

namespace XUnit3Sandbox.Tests;
public class FormTheoryTests : FormTestBase
{
    public FormTheoryTests(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests2 : FormTestBase
{
    public FormTheoryTests2(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests3 : FormTestBase
{
    public FormTheoryTests3(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests4 : FormTestBase
{
    public FormTheoryTests4(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests5 : FormTestBase
{
    public FormTheoryTests5(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests6 : FormTestBase
{
    public FormTheoryTests6(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests7 : FormTestBase
{
    public FormTheoryTests7(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests8 : FormTestBase
{
    public FormTheoryTests8(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests9 : FormTestBase
{
    public FormTheoryTests9(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}

public class FormTheoryTests10 : FormTestBase
{
    public FormTheoryTests10(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaTheory]
    [InlineData(5, 10, 15)]
    [InlineData(1050, 50, 1100)]
    [InlineData(0, -5, -5)]
    public async Task AddInput_AsExpected(int first, int second, int expected)
    {
        var actual = await AddInput(first, second);
        Assert.Equal(expected, actual);
    }
}
