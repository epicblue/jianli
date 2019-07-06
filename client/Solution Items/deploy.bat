set AddinDirectory=%HOMEDRIVE%%HOMEPATH%\My Documents\Visual Studio 2008\Addins
del "%AddinDirectory%\JianLiAddin.*"
del "%AddinDirectory%\JianLi3Data.*"
copy "%~dp0..\koda\bin\JianLiAddin.dll" "%AddinDirectory%"
copy "%~dp0..\JianLi3Data\bin\Debug\JianLi3Data.dll" "%AddinDirectory%"
copy "%~dp0..\JianLi3Data\bin\Debug\JianLi3Data.dll.config" "%AddinDirectory%"
copy "%~dp0JianLi.addin*" "%AddinDirectory%"
