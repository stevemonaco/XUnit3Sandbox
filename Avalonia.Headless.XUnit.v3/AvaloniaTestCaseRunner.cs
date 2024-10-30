using Avalonia.Threading;
using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;

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

        testMethodArguments = ResolveTestMethodArguments(testCase, testMethodArguments);

        await using var ctxt = new XunitTestCaseRunnerContext<IXunitTestCase>(testCase, messageBus, aggregator, cancellationTokenSource, displayName, skipReason, explicitOption, constructorArguments, testMethodArguments);
        await ctxt.InitializeAsync();

        var result = await session.Dispatch(async () => await RunAsync(ctxt), cancellationTokenSource.Token);
        Dispatcher.UIThread.RunJobs();
        return result;
    }
}