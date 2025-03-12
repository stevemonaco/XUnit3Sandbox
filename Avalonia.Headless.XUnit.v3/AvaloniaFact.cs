using System.ComponentModel;
using Xunit.Sdk;
using Xunit.v3;
using Xunit;
using Xunit.Internal;

namespace Avalonia.Headless.XUnit.v3;
/// <summary>
/// Identifies an xunit test that starts on Avalonia Dispatcher
/// such that awaited expressions resume on the test's "main thread".
/// </summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
[XunitTestCaseDiscoverer(typeof(AvaloniaUIFactDiscoverer))]
public sealed class AvaloniaFactAttribute : FactAttribute
{
}

[EditorBrowsable(EditorBrowsableState.Never)]
internal sealed class AvaloniaUIFactDiscoverer : FactDiscoverer
{
    protected override IXunitTestCase CreateTestCase(ITestFrameworkDiscoveryOptions discoveryOptions, IXunitTestMethod testMethod, IFactAttribute factAttribute)
    {
        Guard.ArgumentNotNull(discoveryOptions);
        Guard.ArgumentNotNull(testMethod);
        Guard.ArgumentNotNull(factAttribute);
        Guard.ArgumentValid($"{nameof(AvaloniaUIFactDiscoverer)} received a FactAttribute of '{factAttribute.GetType()}'", factAttribute is AvaloniaFactAttribute);

        var details = TestIntrospectionHelper.GetTestCaseDetails(discoveryOptions, testMethod, factAttribute);

        return new AvaloniaTestCase(
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
    }
}