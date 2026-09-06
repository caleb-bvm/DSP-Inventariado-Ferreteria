@echo off
setlocal
title Sistema de Inventario de Ferreteria
cd /d "%~dp0"

powershell.exe -NoLogo -NoProfile -ExecutionPolicy Bypass -File "%~dp0scripts\Iniciar.ps1" %*

if errorlevel 1 (
    echo.
    echo No se pudo iniciar el sistema. Revisa el mensaje anterior.
    pause
)

endlocal
