@echo off

rem for example, update.10.12.0.xx 10 12 will update 10.12.0.10 to 10.12.0.12


if '%PP_DIR%' == '' goto invalidArgs
if '%PP_VER%' == '' goto invalidArgs
if '%PP_UPD_VER%' == '' goto invalidArgs

if not exist %PP_DIR% goto invalidArgs

cd /d %PP_DIR%

if not exist %PP_VER% goto oldVersionDoesNotExist

echo renaming '%PP_VER%' to '%PP_UPD_VER%'
rename %PP_VER% %PP_UPD_VER%

pause

set OutFolder=%PP_UPD_VER%\out

echo OutFolder=%OutFolder%
set TMPOUTFOLDER=out-%RANDOM%

rem delete out folder (which contains LKGs as well)
if exist %OutFolder% (
    echo renaming and deleting out folder %OutFolder%
    
    pushd %PP_UPD_VER%

    if exist %TMPOUTFOLDER% goto tmpOutDirExists

    rem rename the out folder
    echo renaming out to %TMPOUTFOLDER%
    rename out %TMPOUTFOLDER%
    
    popd
   
)

cd /d %PP_DIR%\%PP_UPD_VER%
if not exist src md src
cd src

call bentleybootstrap PowerPlatform:%PP_UPD_VER%

cd /d %PP_DIR%\%PP_UPD_VER%
echo %cd%
echo %TMPOUTFOLDER%
if exist %TMPOUTFOLDER% (
    rem delete the renamed out folder
    echo removing %TMPOUTFOLDER%, you can move on to the dopull step in another shell
    rd %TMPOUTFOLDER% /s /q
)
goto done

:invalidArgs
echo invalid args
goto done

:oldVersionDoesNotExist
echo Old PowerPlatform Version %PP_VER% does not exist
goto done

:tmpOutDirExists
echo %TMPOUTFOLDER% already exists
goto done


:done
