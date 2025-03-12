using Avalonia.Controls;
using Avalonia.Headless;
using XUnit3Sandbox.ViewModels;
using XUnit3Sandbox.Views;

namespace XUnit3Sandbox.Tests;
public class FormTestBase
{
    protected readonly CoreFixture _coreFixture;

    public FormTestBase(CoreFixture coreFixture)
    {
        _coreFixture = coreFixture;
    }

    protected async Task TextInput()
    {
        var window = _coreFixture.GetRequiredService<MainWindow>();
        window.DataContext = _coreFixture.GetRequiredService<MainWindowViewModel>();
        window.Show();

        await Task.Delay(1500);

        var textBox = window.inputText;
        var textBlock = window.outputText;

        var input = "Testing some text";
        textBox.Focus();
        window.KeyTextInput(input);

        Assert.Equal(input, textBox.Text);
        Assert.Equal(input, textBlock.Text);
    }

    protected async Task<int> AddInput(int first, int second)
    {
        var window = _coreFixture.GetRequiredService<MainWindow>();
        window.DataContext = _coreFixture.GetRequiredService<MainWindowViewModel>();
        window.Show();

        var firstBox = window.firstAddText;
        var secondBox = window.secondAddText;
        var addBlock = window.addResultText;

        firstBox.Focus();
        firstBox.SelectAll();
        window.KeyTextInput(first.ToString());
        await Task.Delay(200);

        secondBox.Focus();
        secondBox.SelectAll();
        window.KeyTextInput(second.ToString());

        return int.Parse(addBlock.Text!);
    }
}
