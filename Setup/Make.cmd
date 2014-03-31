rem Clean output
rmdir /s /q files
mkdir files

rem Copy PrimeComm files
for /R ..\PrimeComm\bin\Debug %%f in (*.exe) do copy %%f files
for /R ..\PrimeComm\bin\Debug %%f in (*.ttf) do copy %%f files
for /R ..\PrimeComm\bin\Debug %%f in (*.dll) do copy %%f files
del /s "files\*.vshost.exe"

rem Build the Installer
iscc setup.iss
pause

rem Open the folder containing the setup
cd setup
explorer %cd%
exit
