using System.ComponentModel;
using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;

namespace Avalonia.Headless.XUnit.v3;
internal sealed class AvaloniaTestCase : XunitTestCase, ISelfExecutingXunitTestCase
{
    public AvaloniaTestCase(IXunitTestMethod testMethod, 
        string testCaseDisplayName, string uniqueID, 
        bool @explicit, string? skipReason = null, 
        Type? skipType = null, 
        string? skipUnless = null, 
        string? skipWhen = null, 
        Dictionary<string, HashSet<string>>? traits = null, 
        object?[]? testMethodArguments = null, 
        string? sourceFilePath = null, 
        int? sourceLineNumber = null, 
        int? timeout = null)
        : base(testMethod, testCaseDisplayName, uniqueID, @explicit, skipReason, skipType, skipUnless, skipWhen, traits, testMethodArguments, sourceFilePath, sourceLineNumber, timeout)
    {
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("Called by the de-serializer; should only be called by deriving classes for de-serialization purposes")]
    public AvaloniaTestCase()
    {
    }

    public ValueTask<RunSummary> Run(
        ExplicitOption explicitOption,
        IMessageBus messageBus, object?[]
        constructorArguments, ExceptionAggregator
        aggregator, CancellationTokenSource cancellationTokenSource)
    {
        Guard.ArgumentNotNull(messageBus);
        Guard.ArgumentNotNull(constructorArguments);
        Guard.ArgumentNotNull(cancellationTokenSource);

        var session = HeadlessUnitTestSession.GetOrStartForAssembly(TestMethod.Method.DeclaringType?.Assembly);

        // We need to block the XUnit thread to ensure its concurrency throttle is effective.
        // See https://github.com/AArnott/Xunit.StaFact/pull/55#issuecomment-826187354 for details.
        return Task.Run(() => AvaloniaTestCaseRunner.Instance.RunDispatcherAsync(
            session,
            this,
            messageBus,
            aggregator.Clone(),
            cancellationTokenSource,
            TestCaseDisplayName,
            SkipReason,
            explicitOption,
            constructorArguments,
            TestMethodArguments))
        .GetAwaiter()
        .GetResult();
    }
}