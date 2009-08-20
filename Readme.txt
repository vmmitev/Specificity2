Specificity
===========

Extensible fluent API for unit test assertions.

License
=======

License: Microsoft Public License (Ms-PL)
http://specificity.codeplex.com/license

Development
===========

There are several solutions in the Specificity source tree. Specificity.sln is the main solution
that will typically be used by developers. This solution contains the projects to build Specificity for
use with the MSTest unit testing framework, as well as a Banking sample to illustrate how to use the
library. If you're using one of the other supported unit test frameworks (csUnit, MbUnit, NUnit or xUnit),
then there is a Specificity.XXX.sln where XXX is the framework name. These solutions are similar to the
Specificity.sln, but build Specificity for use with the specified unit test framework. Finally, there's
a SpecificityFull.sln solution which builds Specificity for all of the supported frameworks, including
the various Banking sample applications, as well as building the help documentation and the installation
package for Specificity. Due to the number of projects and the length of time it takes to build the
documentation, this solution will probably be used only by the project developers to build releases.

Specificity builds are dependent on several third party packages. Depending on which solution you're
building there will be a dependence on some third party unit testing framework, as well as a dependence
on several other tools. Here's the dependencies and versions currently used by the project developers.
Newer (or even older) versions of a library or tool may work, but have not been tested.

Specificity.sln
---------------
VisualStudio 2008 which includes the MSTest libraries and runner.

Specificity.csUnit.sln
----------------------
VisualStudio 2008
csUnit 2.6 - http://www.csunit.org/

Specificity.MbUnit.sln
----------------------
VisualStudio 2008
Gallio 3.0.6.787 - http://www.gallio.org/Downloads.aspx

Specificity.NUnit.sln
---------------------
VisualStudio 2008
NUnit 2.5.2.9222 - http://www.nunit.org/index.php?p=download

Specificity.xUnit.sln
---------------------
VisualStudio 2008
xUnit 1.1 - http://www.codeplex.com/xunit
   Since xUnit doesn't provide an installer or register it's libraries with VisualStudio, you need
   to copy it's assemblies to the Specificity/References directory in order to build.

SpecificityFull.sln
-------------------
All of the requirements from the above solutions as well as...
SandCastle documentation compiler May 2009 release - http://www.codeplex.com/Sandcastle
DocProject 1.11.0 - http://www.codeplex.com/DocProject
Wix (Windows Installer XML) 3.5 - http://wix.sourceforge.net/

In addition to the solutions, a 'build.proj' MSBuild project file is included in the source stream.
This build project file builds SpecificityFull.sln into a single output directory and packages
everything for deployment.