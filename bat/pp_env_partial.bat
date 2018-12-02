
rem *----------------------------------------------*
rem *-------- Machine-specific locations ----------*
rem *----------------------------------------------*

set BSISRC=%PP_DIR%%PP_VER%\src\
set BSIOUT=%PP_DIR%%PP_VER%\out\

rem *----------------------------------------------*
rem BuildStrategy specifies what repositories and source
rem you will be pulling, pushing and building.
rem *----------------------------------------------*
rem LocalLKG Our Own BuildStrategy File from BUILDSTRATEGYPATH
set BUILDSTRATEGYPATH=D:\CONNECT\LocalBuildStrategies\
set BUILDSTRATEGY=powerplatform;buildall;ecf_PRG_LKG
set TAGFILE=src_localLKG.tag

rem *----------------------------------------------*
rem Some recommended options...
rem *----------------------------------------------*
set DEBUG=1

rem *----------------------------------------------*
rem *----------- Shared Shell Setup ---------------*
rem *----------------------------------------------*
call %BSISRC%bsicommon\shell\SharedShellEnv.bat

rem *----------------------------------------------*
rem  Change this to take you to your favorite spot.
rem *----------------------------------------------*
cd /d %SrcRoot%

if /i [%1]==[pull] Title %PP_DIR%%PP_VER% Pull&echo "calling dopull"&dopull
if /i [%1]==[build] Title %PP_DIR%%PP_VER% Build&echo "calling bb b"&bb b
if /i [%1]==[savelkg] Title %PP_DIR%%PP_VER% Save LKG&echo "calling savelkg"&savelkg

