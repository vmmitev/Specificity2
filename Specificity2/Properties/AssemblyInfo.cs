//-----------------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="William E. Kempf">
//     Copyright (c) William E. Kempf.
// </copyright>
//-----------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("Specificity2")]
[assembly: AssemblyProduct("Specificity2")]
[assembly: NeutralResourcesLanguage("en-US")]
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
[assembly: Guid("5cec2c43-8c4c-4991-b679-391680488ec8")]

[assembly: InternalsVisibleTo("Specificity2.MSTest")]
[assembly: InternalsVisibleTo("Specificity2.MbUnit")]
[assembly: InternalsVisibleTo("Specificity2.NUnit")]
[assembly: InternalsVisibleTo("Specificity2.XUnit")]

// Analyzer Suppressions
[assembly: SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "AnyTime", Scope = "member", Target = "Testing.Specificity2.ObjectFactoryExtensions.#AnyTimeSpan(Testing.Specificity2.IObjectFactory,System.Nullable`1<System.TimeSpan>,System.Nullable`1<System.TimeSpan>,Testing.Specificity2.Distribution)", Justification = "Used as compound in 'Any TimeSpan'.")]