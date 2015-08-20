@echo off
setlocal
set BUILD_TARGET=%~1

echo Building Application...

if not "%BUILD_TARGET%"=="" set BUILD_TARGET="/target:%BUILD_TARGET%"
msbuild /m /nologo /verbosity:m /toolsversion:12.0 build.xml %BUILD_TARGET% %2 %3 %4 %5 %6 %7 %8 %9

endlocal
if errorlevel 1 pause