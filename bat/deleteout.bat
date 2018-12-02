@echo off

if '%OutRoot%' == '' goto noenv

cd /d %OutRoot%..

echo deleting Out folder
rd %OutRoot% /s /q

:noenv
echo Environment is not properly set up

:done
