using System.ComponentModel;
using Xunit.Sdk;
using Xunit.v3;
using Xunit;
using Xunit.Internal;

namespace Avalonia.Headless.XUnit.v3;
/// <summary>
/// Identifies an xunit theory that starts on Avalonia Dispatcher
/// such that awaited expressions resume on the test's "main thread".
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
[XunitTestCaseDiscoverer(typeof(AvaloniaTheoryDiscoverer))]
public sealed class AvaloniaTheoryAttribute : TheoryAttribute
{
}

[EditorBrowsable(EditorBrowsableState.Never)]
internal sealed class AvaloniaTheoryDiscoverer : TheoryDiscoverer
{
    protected override ValueTask<IReadOnlyCollection<IXunitTestCase>> CreateTestCasesForDataRow(
        ITestFrameworkDiscoveryOptions discoveryOptions,
        IXunitTestMethod testMethod,
        ITheoryAttribute theoryAttribute,
        ITheoryDataRow dataRow,
        object?[] testMethodArguments)
    {
        Guard.ArgumentNotNull(discoveryOptions);
        Guard.ArgumentNotNull(testMethod);
        Guard.ArgumentNotNull(theoryAttribute);
        Guard.ArgumentNotNull(dataRow);
        Guard.ArgumentNotNull(testMethodArguments);

        var details = TestIntrospectionHelper.GetTestCaseDetailsForTheoryDataRow(discoveryOptions, testMethod, theoryAttribute, dataRow, testMethodArguments);
        var traits = TestIntrospectionHelper.GetTraits(testMethod, dataRow);

        var testCase = new AvaloniaTestCase(
            details.ResolvedTestMethod,
            details.TestCaseDisplayName,
            details.UniqueID,
            details.Explicit,
            details.SkipExceptions,
            details.SkipReason,
            details.SkipType,
            details.SkipUnless,
            details.SkipWhen,
            traits,
            testMethodArguments,
            timeout: details.Timeout
        );

#pragma warning disable IDE0300 // Changes the semantics
        return new(new[] { testCase });
#pragma warning restore IDE0300
    }

    protected override ValueTask<IReadOnlyCollection<IXunitTestCase>> CreateTestCasesForTheory(
        ITestFrameworkDiscoveryOptions discoveryOptions,
        IXunitTestMethod testMethod,
        ITheoryAttribute theoryAttribute)
    {
        Guard.ArgumentNotNull(discoveryOptions);
        Guard.ArgumentNotNull(testMethod);
        Guard.ArgumentNotNull(theoryAttribute);

        var details = TestIntrospectionHelper.GetTestCaseDetails(discoveryOptions, testMethod, theoryAttribute);
        IXunitTestCase? testCase;

        if (details.SkipReason is not null && details.SkipUnless is null && details.SkipWhen is null)
            testCase = new AvaloniaTestCase(
                    details.ResolvedTestMethod,
                    details.TestCaseDisplayName,
                    details.UniqueID,
                    details.Explicit,
                    details.SkipExceptions,
                    details.SkipReason,
                    details.SkipType,
                    details.SkipUnless,
                    details.SkipWhen,
                    testMethod.Traits.ToReadWrite(StringComparer.OrdinalIgnoreCase),
                    timeout: details.Timeout
                );
        else 
            testCase = new AvaloniaDelayEnumeratedTheoryTestCase(
                    details.ResolvedTestMethod,
                    details.TestCaseDisplayName,
                    details.UniqueID,
                    details.Explicit,
                    theoryAttribute.SkipTestWithoutData,
                    details.SkipExceptions,
                    details.SkipReason,
                    details.SkipType,
                    details.SkipUnless,
                    details.SkipWhen,
                    testMethod.Traits.ToReadWrite(StringComparer.OrdinalIgnoreCase),
                    timeout: details.Timeout
                );

#pragma warning disable IDE0300 // Changes the semantics
        return new(new[] { testCase });
#pragma warning restore IDE0300
    }
}