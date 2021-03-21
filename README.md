# ChallengeAV
proyectos para Challenge American Virtual
Los 2 proyectos realizados en .netCore 5.0 con plataforma de destino aspNetCore 3.1
En la carpeta AmericanVrtual1 se encuentra la APIWeb (Api WEB NetCore)
En la carpeta WA_Challenge se encuentra la aplicación WEB que consume los servicios de la API (Aplicación Web NetCore MVC)
**************************************************************************************************************************
Descargar las carpetas y abrir las soluciones con Visual Studio 2019
Primero ejecutar la API (AmericanVirtual1) para ver en que puerto del localhost correrá
Antes de ejecutar la aplicación WEB (WA_Challenge), ir a la carpeta Servicios
luego a la clase ServicioDeDatos y en el constructor de la clase modificar el valor del campo 'urlBase'
this.urlBase = "https://localhost:44353/ChallengeAV"; con el puerto donde este corriendo la API
después de eso se puede ejecutar la aplicación.

Las aplicaciones estan preparadas para probarse en un entorno local de desarrollo; para poder publicarlas
primero hay que generar el paquete de publicacion de la api y subirla preferentemente a un servidor IIS
ya con la url donde correra la api establecida se puede modificar la aplicacion, compilarla y despues generar el paquete 
para publicarla (Aclaración: la variable que se indica más arriba 'urlBase' se debe declarar como variable de entorno 
y modificar ese constructor para que lea ese valor desde la configuracion de la aplicación)
**************************************************************************************************************************
NOTA: Teniendo en cuenta que estos proyectos son unos ejercicios, hay algunas particularidades a considerar
.- La Base de Datos, esta embebida en la API, para evitar el proceso de generar una BD en un servidor
Es una BD de SQLite3 que se genero con CodeFirst de EntityFramework.Core; los datos que contiene se 
generaron con unos procesos que se encuentran en el controlador de la API (Aclaración: esos procesos no deben estar alli,
solo los deje por si en algún momento se quiere saber de donde salieron los datos)
**************************************************************************************************************************




