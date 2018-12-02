@echo off

if '%SrcRoot%' == '' goto noenv

cd /d %SrcRoot%

if '%PP_BDF%' == '' goto tip

echo Pulling via bb pull -r %PP_BDF%
bb pull -r %PP_BDF%

goto done

:tip
echo Warning: PP_BDF no defined. Pulling from tip.
bb pull

goto done

:noenv
echo Environment is not properly set up

:done
