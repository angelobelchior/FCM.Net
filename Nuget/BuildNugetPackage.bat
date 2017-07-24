@echo off

REM Cria os dirs
if not exist lib\net452 md lib\net452
if not exist lib\netstandard1 md lib\netstandard1
if not exist lib\portable46-net451+win81+wpa81 md lib\portable46-net451+win81+wpa81

REM Copia cada dll de sua pasta de origem para a pasta lib do nuget
copy /y ..\fcm.net\bin\release\fcm.net.dll lib\net452
copy /y ..\fcm.net.standard\bin\release\netstandard1.6\FCM.Net.Standard.dll lib\netstandard1.6
copy /y ..\fcm.net.pcl\bin\release\FCM.Net.pcl.dll "lib\portable46-net451+win81+wpa81"

nuget pack FCM.net.nuspec