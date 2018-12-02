@echo off

if '%OutRoot%' == '' goto noenv
if '%PP_DIR%' == '' goto noppdir
if '%PP_VER%' == '' goto noppver

rem Create PP Build Strategy file for this version
if '%PP_LocalBuildStrategyFolder%' == '' goto noLocalBuildStategyFolder
if not exist %PP_LocalBuildStrategyFolder% == '' goto LocalBuildStategyFolderNotFound

set buildstrategyfile=%PP_LocalBuildStrategyFolder%PowerPlatformLKG.%PP_VER%.BuildStrategy.xml

echo Creating %buildstrategyfile%
echo ^<?xml version="1.0" encoding="utf-8"?^> > %buildstrategyfile%
echo ^<BuildStrategy  xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"  xsi:noNamespaceSchemaLocation="../bsicommon/build/BuildStrategy.xsd"^> >> %buildstrategyfile%
echo   ^<LastKnownGoodServer Name="Local_PP_LKGs" Type="local" Address="%PP_DIR%%PP_VER%\out\LKG\$(platform)\" /^> >> %buildstrategyfile%
echo   ^<LastKnownGoodSource Name="PowerPlatform" Type="dev" DevServer="Local_PP_LKGs" /^> >> %buildstrategyfile%
echo   ^<PullToBuildDescriptionFile Name="bdfserver:PowerPlatform:%PP_VER%"/^> >> %buildstrategyfile%
echo ^</BuildStrategy^> >> %buildstrategyfile%

pause

goto savelkgs

:noLocalBuildStategyFolder
echo Warning: PP_LocalBuildStrategyFolder is not defined
goto savelkgs

:LocalBuildStategyFolderNotFound
echo  Warning: %PP_LocalBuildStrategyFolder% was not found
goto savelkgs


:savelkgs

cd /d %OutRoot%

echo Saving LKGs
bb savelkgs --useSymlinks LKG 
goto done

:noppdir
echo  PP_DIR not set
goto done

:noppver
echo  PP_VER not set
goto done


:noenv
echo Environment is not properly set up
goto done

:done
