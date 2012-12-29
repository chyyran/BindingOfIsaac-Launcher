Binding of Isaac Launcher: Revamped by Ron
==========================================

Building
========
Open Binding of Isaac Launcher in VS10.

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
