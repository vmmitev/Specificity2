# Specificity2

Extensible fluent API for unit test assertions.

## License

[Microsoft Public License (Ms-PL)](https://specificity.codeplex.com/license)

## Installing

Specifity is generally installed into a project using NuGet. The base package can be installed
from the Package Manager Console with the following command.

    PM> Install-Package Specificity2

Usually Specificity2 will be installed with framework specific NuGet packages for MSTest, NUnit and xUnit.
From the Package Manager Console these can be installed with one of the following commands.

    PM> Install-Package Specificity2.MSTest
    PM> Install-Package Specificity2.NUnit
    PM> Install-Package Specificity2.xUnit

Specificity2 includes support for "auto mocking" using the Microsoft Fakes framework by installing
the Specificity2.Fakes package. You can install this from the Package Manager Console with the
following command.

    PM> Install-Package Specificity2.Fakes

## Development

Specificity2 builds are dependent on several third party packages. Here's the dependencies currently
used by the project developers.

### NuGet

NuGet is used for package management. NuGet.exe is included in the source tree so NuGet is required
only if you need to add, remove or update packages. NuGet is installed with Visual Studio for those
scenarios, though you should use ExtensionManager to ensure you're up to date.

### StyleCop

StyleCop is used to ensure source code follows style conventions. This is integrated into the
projects' analyzers collection and is installed by the NuGet package restore process. Nothing needs to
be installed by the developer.

### NUnit Test Adapter

Specificity2 includes some unit tests written using the NUnit testing framework. In order to run these
tests with the Visual Studio test runner (used by the Text Explorer in Visual Studio) you must have this
extension installed. It can be installed via "Tools | Extensions and Updates..." in Visual Studio.

### NuGet Packages

Several NuGet packages are used in Specificity2, including, but not limited to, xUnit and NUnit. These
packages are installed via NuGet package restore, which can be run either by building within Visual
Studio.