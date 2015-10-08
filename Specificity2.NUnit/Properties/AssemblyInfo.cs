// <copyright file="AssemblyInfo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Specificity2.NUnit")]
[assembly: AssemblyProduct("Specificity2.NUnit")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("3cebd6a9-525a-42a3-ae59-e6c1480af195")]

// Analyzer Suppressions
[assembly: SuppressMessage("Microsoft.Performance", "CA1812:AvoidUninstantiatedInternalClasses", Scope = "type", Target = "Testing.Specificity2.SpecifyAdapter", Justification = "Class created through late-bound reflection.")]