//-----------------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Specificity2.Tests")]
[assembly: AssemblyProduct("Specificity2.Tests")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
[assembly: CLSCompliant(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("530d70b7-1849-426b-8855-065e7a323366")]

// Analyzer Suppressions
[assembly: SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "AnyTime", Scope = "member", Target = "Testing.Specificity2.Tests.ObjectFactoryTests.#AnyTimeSpanShouldReturnRandomTimeSpan()", Justification = "Used as compound in 'Any TimeSpan'.")]