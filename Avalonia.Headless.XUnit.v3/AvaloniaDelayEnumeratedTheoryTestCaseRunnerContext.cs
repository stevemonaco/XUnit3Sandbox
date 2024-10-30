using Xunit.Sdk;
using Xunit.v3;

namespace Avalonia.Headless.XUnit.v3;
internal class AvaloniaDelayEnumeratedTheoryTestCaseRunnerContext : XunitTestCaseRunnerContext<IXunitTestCase>
{
    public HeadlessUnitTestSession Session { get; }

    public AvaloniaDelayEnumeratedTheoryTestCaseRunnerContext(
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
        : base(testCase, messageBus, aggregator, cancellationTokenSource, displayName, skipReason, explicitOption, constructorArguments, testMethodArguments)
    {
        Session = session;
    }
}
