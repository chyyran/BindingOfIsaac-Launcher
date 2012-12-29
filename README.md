Binding of Isaac Launcher: Revamped by Ron
==========================================

Building
========
Open Binding of Isaac Launcher in VS10, and build the solution.
Installer.exe is the installer, and requires the md5 sums of Wrath of the Lamb and the vanilla Binding of Isaac, 
the launcher (named Launcher.exe), the uninstaller, (Uninstaller.exe) and xdelta.exe, as well as the patch from Wrath of the Lamb to vanilla Binding of Isaac (patch.xdelta)
to run. xdelta and the patch should be included, launcher and uninstaller are found in their respective directories in the solution

Launcher.exe is the actual launcher. It will launch Isaac\_Vanilla.exe and Isaac\_WotL.exe respectively (You'll know once built). Since no checks have been added, if one attempts to launch without a file being present, it will throw an exception.\


Maintaining
===========
To all who come after me:

Everything should be ready, in case of an update, however, future maintainers, you will need to do a few things
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
If you're just looking to install it, just download the latest installer from
http://punyman.com/projects/Binding%20of%20Isaac%20Launcher%20Installer.exe
and run the installer. Prompts should be easy enough to figure out.
