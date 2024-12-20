using Avalonia.Threading;
using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;
using static System.Net.Mime.MediaTypeNames;

namespace Avalonia.Headless.XUnit.v3;
internal sealed class AvaloniaTestCaseRunner : XunitTestCaseRunner
{
    private AvaloniaTestCaseRunner()
    {
    }

    public new static AvaloniaTestCaseRunner Instance { get; } = new();

    public async ValueTask<RunSummary> RunDispatcherAsync(
        HeadlessUnitTestSession session,
        IXunitTestCase testCase,
        IMessageBus messageBus,
        ExceptionAggregator aggregator,
        CancellationTokenSource cancellationTokenSource,
        string displayName,
        string? skipReason,
        ExplicitOption explicitOption,
        object?[] constructorArguments,
        object?[] testMethodArguments)
    {
        Guard.ArgumentNotNull(session);
        Guard.ArgumentNotNull(testCase);
        Guard.ArgumentNotNull(displayName);
        Guard.ArgumentNotNull(constructorArguments);

        var tests = await aggregator.RunAsync(testCase.CreateTests, []);

        if (aggregator.ToException() is Exception ex)
        {
            if (ex.Message.StartsWith(DynamicSkipToken.Value, StringComparison.Ordinal))
                return XunitRunnerHelper.SkipTestCases(
                    messageBus,
                    cancellationTokenSource,
                    [testCase],
                    ex.Message.Substring(DynamicSkipToken.Value.Length),
                    sendTestCaseMessages: false
                );
            else
                return XunitRunnerHelper.FailTestCases(
                    messageBus,
                    cancellationTokenSource,
                    [testCase],
                    ex,
                    sendTestCaseMessages: false
                );
        }

        await using var ctxt = new XunitTestCaseRunnerContext(testCase, tests, messageBus, aggregator, cancellationTokenSource, displayName, skipReason, explicitOption, constructorArguments);
        await ctxt.InitializeAsync();

        var result = await session.Dispatch(async () => await Run(ctxt), cancellationTokenSource.Token);
        Dispatcher.UIThread.RunJobs();
        return result;
    }
}