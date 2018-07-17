FreeIsaac - Binding of Isaac Launcher
==========================================

Building
========
Open Binding of Isaac Launcher in VS10, and build the solution.

The installer "Installer.exe" requires the following to execute:
1. md5 sums of Wrath of the Lamb and the vanilla Binding of Isaac 
2. launcher (named Launcher.exe)
3. uninstaller (Uninstaller.exe)
4. xdelta.exe
5. patch from Wrath of the Lamb to vanilla Binding of Isaac (patch.xdelta)

Launcher.exe is the program launcher, and will execute Isaac\_Vanilla.exe and Isaac\_WotL.exe respectively. Since no checks have been added, any attempts to launch with missing files will throw an exception.


Maintenance
===========
To all who come after me:

Updates will be all encompassing. Future maintainers will, however, need to do a few things.  
1. Get the md5 for the latest Wrath of the Lamb EXE, put this in WotL.md5  
2. Get the md5 for the latest Vanilla EXE, put this in Vanila.md5  
4. Rename the Vanilla EXE to "Isaac_Vanilla.exe"  
3. Make a patch with Xdelta, like this   
```
xdelta delta Isaac_WotL.exe Isaac_Vanilla.exe patch.xdelta
```
Pack it all up in a nice WinRAR SFX and you're good to go

Installing
==========
Download the latest installer from [here](http://punyman.com/projects/Binding%20of%20Isaac%20Launcher%20Installer.exe) and run the installer. Follow the prompts to complete the installation.

Manual Install
==============
To install the program manually, obtain launcher.exe (which you can get from this repo or build yourself), rename it to Isaac.exe, and put it in your BoI install folder.  
Before you manually install the program, rename your Wrath of the Lamb .exe file to Isaac\_WotL.exe. If you have the vanilla version, rename the file to Isaac\_Vanilla.exe.

To patch Wrath of the Lamb to vanilla, get patch.xdelta and xdelta.exe (from this repo or somewhere else) Be sure to obtain xdelta1, and not xdelta2 or xdelta3). Patch using 
```
xdelta patch patch.xdelta Isaac_WotL.exe
```
and that should output Isaac\_Vanilla.exe
