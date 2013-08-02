# Specificity

Extensible fluent API for unit test assertions.

## License

[Microsoft Public License (Ms-PL)](http://specificity.codeplex.com/license)

## Installing

Specifity is generally installed into a project using NuGet. The base package can be installed
from the Package Manager Console with the following command.

    PM> Install-Package Specificity

Usually Specificity will be installed with framework specific NuGet packages for MSTest, NUnit and xUnit.
From the Package Manager Console these can be installed with one of the following commands.

    PM> Install-Package Specificity.MSTest
    PM> Install-Package Specificity.NUnit
    PM> Install-Package Specificity.xUnit

Once Specificity is installed via NuGet you can install documentation into the Help Viewer
by running the following command from the Package Manager Console.

    PM> Install-SpecificityDocumentation

You can uninstall the documentation by running the following command.

    PM> Uninstall-SpecificityDocumentation

Specificity includes support for "auto mocking" using the Microsoft Fakes framework by installing
the Specificity.Fakes package. You can install this from the Package Manager Console with the
following command.

    PM> Install-Package Specificity.Fakes

## Development

There are two solutions in the Specificity source tree. Specificity.sln is the main solution, and
contains the projects used to build Specificity. Documentation.sln found in the 'documentation'
folder is used to build the help files after you've build the main solution. A build.proj MSBuild
project file is also included, and is used to build all of the assets of the project. Targets
supported by build.proj include:

- Restore - Restores NuGet packages. This should be run by itself before running any other targets.
- Version - Updates the version number used by all assets.
- Clean - Cleans up all files produced by previous builds.
- Build - Builds Specificity.sln.
- Rebuild - Rebuilds Specificity.sln.
- Test - Runs all the unit tests.
- Documentation - Builds Documentation.sln to produce the help files.
- Package - Creates NuGet packages.

Unless otherwise specified, build.proj sets Configuration=Release.

Specificity builds are dependent on several third party packages. Here's the dependencies currently
used by the project developers.

### NuGet

NuGet is used for package management. NuGet.exe is included in the source tree so NuGet is required
only if you need to add, remove or update packages. NuGet is installed with Visual Studio for those
scenarios, though you should use ExtensionManager to ensure you're up to date.

### StyleCop

StyleCop is used to ensure source code follows style conventions. This is integrated into the
MSBuild projects and is installed by the NuGet package restore process. Nothing needs to be
installed by the developer.

### NUnit Test Adapter

Specificity includes some unit tests written using the NUnit testing framework. In order to run these
tests with the Visual Studio test runner (used both by the Text Explorer in Visual Studio and from the
build.proj MSBuild project) you must have this extension installed. It can be installed via
"Tools | Extensions and Updates..." in Visual Studio.

### xUnit.net runner for Visual Studio 2012 and 2013

Specificity includes some unit tests written using the xUnit testing framework. In order to run these
tests with the Visual Studio test runner (used both by the Text Explorer in Visual Studio and from the
build.proj MSBuild project) you must have this extension installed. It can be installed via
"Tools | Extensions and Updates..." in Visual Studio.

### TeamCity

TeamCity is used for CI builds. The build.proj MSBuild project has hooks into this system, but these
hooks are ignored on developer machines, which produce "developer" branded assets. When producing
production branded assets inside TeamCity there is a dependence on the TeamCity Test Logger for VS2012,
which can be installed via "Tools | Extensions and Updates..." in Visual Studio.

### NuGet Packages

Several NuGet packages are used in Specificity, including, but not limited to, xUnit and NUnit. These
packages are installed via NuGet package restore, which can be run either by building within Visual
Studio or by running the "Restore" target in build.proj.