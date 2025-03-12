using Xunit.Internal;
using Xunit.Sdk;
using Xunit.v3;

namespace Avalonia.Headless.XUnit.v3;
internal class AvaloniaDelayEnumeratedTheoryTestCase : XunitDelayEnumeratedTheoryTestCase, ISelfExecutingXunitTestCase
{
    /// <summary>
    /// Called by the de-serializer; should only be called by deriving classes for de-serialization purposes
    /// </summary>
    [Obsolete("Called by the de-serializer; should only be called by deriving classes for de-serialization purposes")]
    public AvaloniaDelayEnumeratedTheoryTestCase()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="XunitDelayEnumeratedTheoryTestCase"/> class.
    /// </summary>
    /// <param name="testMethod">The test method this test case belongs to.</param>
    /// <param name="testCaseDisplayName">The display name for the test case.</param>
    /// <param name="uniqueID">The optional unique ID for the test case; if not provided, will be calculated.</param>
    /// <param name="explicit">Indicates whether the test case was marked as explicit.</param>
    /// <param name="skipTestWithoutData">Set to <c>true</c> to skip if the test has no data, rather than fail.</param>
    /// <param name="skipReason">The value from <see cref="IFactAttribute.Skip"/></param>
    /// <param name="skipType">The value from <see cref="IFactAttribute.SkipType"/> </param>
    /// <param name="skipUnless">The value from <see cref="IFactAttribute.SkipUnless"/></param>
    /// <param name="skipWhen">The value from <see cref="IFactAttribute.SkipWhen"/></param>
    /// <param name="traits">The optional traits list.</param>
    /// <param name="sourceFilePath">The optional source file in where this test case originated.</param>
    /// <param name="sourceLineNumber">The optional source line number where this test case originated.</param>
    /// <param name="timeout">The optional timeout for the test case (in milliseconds).</param>
    public AvaloniaDelayEnumeratedTheoryTestCase(
        IXunitTestMethod testMethod,
        string testCaseDisplayName,
        string uniqueID,
        bool @explicit,
        bool skipTestWithoutData,
        Type[]? skipExceptions,
        string? skipReason = null,
        Type? skipType = null,
        string? skipUnless = null,
        string? skipWhen = null,
        Dictionary<string, HashSet<string>>? traits = null,
        string? sourceFilePath = null,
        int? sourceLineNumber = null,
        int? timeout = null)
        : base(testMethod, testCaseDisplayName, uniqueID, @explicit, skipTestWithoutData, skipExceptions, skipReason, skipType, skipUnless, skipWhen, traits, sourceFilePath, sourceLineNumber, timeout)
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
