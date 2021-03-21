# ChallengeAV
proyectos para Challenge American Virtual
Los 2 proyectos realizados en .netCore 5.0 con plataforma de destino aspNetCore 3.1
En la carpeta AmericanVrtual1 se encuentra la APIWeb 
En la carpeta WA_Challenge se encuentra la aplicación WEB que consume los servicios de la API
*********************************************************************************************
Descargar las carpetas y abrir las soluciones con Visual Studio 2019
Primero ejecutar la API (AmericanVirtual1) para ver en que puerto del localhost correrá
Antes de ejecutar la aplicación WEB (WA_Challenge), ir a la carpeta Servicios
luego a la clase ServicioDeDatos y en el constructor de la clase modificar el valor del campo 'urlBase'
this.urlBase = "https://localhost:44353/ChallengeAV"; con el puerto donde este corriendo la API
después de eso se puede ejecutar la aplicación.
*********************************************************************************************




