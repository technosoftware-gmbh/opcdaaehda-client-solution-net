-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.2.6

###	Changes
- Update to enable/disable DCOM call cancellation

-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.2.5

###	Fixed Issues
- Support of .NET 6.0 

-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.2.4

###	Fixed Issues
- Added README to nuget package
- Changed lock for subscription to instance lock to increase performance. Might affect callback handling. 

-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.2.3

###	Fixed Issues
- For OPC DA 2.0 only servers Subscription GetState() was called wrong. The OPC DA 3.0 version was used instead of the DA 2.0 version.

-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.2.2

###	Changes
- Added ApplicationInstance class containing Property TimAsUtc (from LicenseHandler) and InitializeSecurity
- InitializeSecurity can be used to set the authentication level to Integrity as requested in [KB5004442—Manage changes for Windows DCOM Server Security Feature Bypass (CVE-2021-26414)](https://support.microsoft.com/en-us/topic/kb5004442-manage-changes-for-windows-dcom-server-security-feature-bypass-cve-2021-26414-f1400b52-c141-43d2-941e-37ed901c769c)

-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.2.0

###	Changes
- NuGet packages are now available under a commercial license

### Fixed Issues
- Issue #14: Fix Connect method(). It ended correctly even if connection is not established
- Issue #15: Disconnect() method is not executed correctly because of wrong implemented Dispose() methods.

### Refactoring
- Refactored Technosoftware.DaAeHdaClient.Da
- Refactored Technosoftware.DaAeHdaClient.Ae
- Refactored Technosoftware.DaAeHdaClient.Hda
- Removed OpcServerType class because it is not used at all

-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.1.1

###	Changes
- Changed copyright year
- Examples are now using the NuGet packages

-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.1.0

###	Enhancements
- Support of .NET 5.0
- Added nuget packages

-------------------------------------------------------------------------------------------------------------
## OPC DA/AE/HDA Solution .NET - 1.0.0902

###	Enhancements
- Support of .NET Standard 2.1
- Also supported: .NET 4.8, .NET 4.7.2, .NET 4.6.2
- Support of OPC Classic Core Components 108.41
- Enhanced COM call tracing for OPC DA 
- For missing required OPC Interfaces a NotSupportedException is thrown and for optional ones just an entry in the log created.

###	Redistributables
- Redistributables are available [here](https://opcfoundation.org/developer-tools/samples-and-tools-classic/core-components/)


