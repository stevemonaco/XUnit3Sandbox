using CommunityToolkit.Mvvm.ComponentModel;

namespace XUnit3Sandbox.ViewModels;
public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty] private string? _inputText;

    [ObservableProperty] private int? _first = 0;
    [ObservableProperty] private int? _second = 0;
    [ObservableProperty] private int? _addResult = 0;

    partial void OnFirstChanged(int? value)
    {
        if (First.HasValue && Second.HasValue)
            AddResult = First.Value + Second.Value;
    }

    partial void OnSecondChanged(int? value)
    {
        if (First.HasValue && Second.HasValue)
            AddResult = First.Value + Second.Value;
    }
}
