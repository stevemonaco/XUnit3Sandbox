Unofficial example implementation of xunit.v3 preview for Avalonia Headless Platform. Ports `[AvaloniaFact]` and `[AvaloniaTheory]` from the official v2 implementation. Focuses on using MS Testing Platform. Not well-tested. Not intended for production.

Currently targets xunit.v3 1.0.0.

What Works:

* Test discovery in IDE
* Running tests in IDE
* Running tests via test executable: `.\XUnit3Sandbox.Tests.exe`
* Running tests via `dotnet test`

What doesn't work:

* Running test DLL via `dotnet test .\XUnit3Sandbox.Tests.dll`:

```
Failed XUnit3Sandbox.Tests.FormTheoryTests.AddInput_AsExpected [< 1 ms]
Error Message:
 System.InvalidOperationException : The test method expected 3 parameter values, but 0 parameter values were provided.
```

This is despite `dotnet test .\XUnit3Sandbox.Tests.dll --list-tests` detecting parameters:

```
XUnit3Sandbox.Tests.FormTheoryTests.AddInput_AsExpected(first: 5, second: 10, expected: 15)
```

Limitations:

Headless tests cannot run in parallel. Instead of enforcing this through several levels of customized xunit types, JSON configuration is used:

`xunit.runner.json`
```js
{
  "$schema": "https://xunit.net/schema/v3.0-alpha-1/xunit.runner.schema.json",
  "parallelizeAssembly": false,
  "parallelizeTestCollections": false,
  "maxParallelThreads": 1
}
```
