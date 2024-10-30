using Avalonia.Headless.XUnit.v3;

namespace XUnit3Sandbox.Tests;
public class FormFactTests : FormTestBase
{

    public FormFactTests(CoreFixture coreFixture) : base(coreFixture)
    {
    }

    [AvaloniaFact]
    public async Task TextInput_AsExpected()
    {
        await TextInput();
    }

    [AvaloniaFact]
    public async Task TextInput_AsExpected2()
    {
        await TextInput();
    }

    [AvaloniaFact]
    public async Task TextInput_AsExpected3()
    {
        await TextInput();
    }

    [AvaloniaFact]
    public async Task TextInput_AsExpected4()
    {
        await TextInput();
    }

    [AvaloniaFact]
    public async Task TextInput_AsExpected5()
    {
        await TextInput();
    }
}
