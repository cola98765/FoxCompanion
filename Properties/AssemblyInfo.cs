﻿using System.Reflection;
using System.Runtime.InteropServices;
using MelonLoader;
using FoxCompanion;

// General Information about an assembly is controlled through the following
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: MelonInfo(typeof(SnowFoxMain), BuildInfo.ModName, BuildInfo.ModVersion, BuildInfo.ModAuthor, "")]
[assembly: MelonGame("Hinterland", "TheLongDark")]
[assembly: AssemblyTitle(BuildInfo.ModName)]
[assembly: AssemblyDescription("A little companion for the lonely TLD player")]
[assembly: AssemblyCompany(BuildInfo.ModAuthor)]
[assembly: AssemblyProduct(BuildInfo.ModName)]

// Setting ComVisible to false makes the types in this assembly not visible
// to COM components.  If you need to access a type in this assembly from
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("288b5e55-e8ec-46ec-a841-fd543ef5b1b8")]

// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
// [assembly: AssemblyVersion("1.0.*")]
[assembly: AssemblyVersion("2.0.0")]
[assembly: AssemblyFileVersion("2.0.0")]
internal static class BuildInfo
{
    internal const string ModName = "FoxCompanion";
    internal const string ModAuthor = "Digitalzombie, cola98765";

    internal const string ModVersion = "2.0.0";
}