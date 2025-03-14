# **PRUEBA TÉCNICA SUMITEMP**  

## **PeopleManagement**  
PeopleManagement es un sistema para la gestión de personas, con arquitectura en capas y desarrollado en **.NET Framework**.  

---

## **Estructura del Proyecto**  

* **PeopleManagement.Application**  
     Contiene la lógica de aplicación y los casos de uso principales.  

* **PeopleManagement.ConsolTest**  
     Proyecto de consola para realizar pruebas rápidas de la lógica del dominio.  

* **PeopleManagement.Domain**  
     Contiene las entidades del dominio y reglas de negocio.  

* **PeopleManagement.Infrastructure**  
     Implementa el acceso a datos y la comunicación con la base de datos.  

* **PeopleManagement.Test**  
     Proyecto de pruebas unitarias e integración para validar la funcionalidad del sistema.  

---

## **Requisitos**  
* .NET Framework 4.8
* SQL Server (para persistencia de datos)
* AutoMapper (para mapeo de objetos)
* FluentValidation (para validaciones de datos)
* Entity Framework (para ORM)
  
---

## **Base de Datos**
1. El sistema utiliza SQL Server como motor de base de datos
2. La base de datos debe llamarse PeopleManagementDB
3. En la carpeta PeopleManagement.Infrastructure/Scripts, encontrarás el script CreateDatabase.sql, que contiene la estructura inicial de las tablas

## **Cómo Ejecutarlo**
1. Clonar el repositorio: git clone https://github.com/tu_usuario/PeopleManagement.git
2. Ejecutar el script CreateDatabase.sql para crear la base de datos y sus tablas
3. Configurar la cadena de conexión en app.config o en las variables de entorno.
4. Compilar la solución en Visual Studio.
5. Ejecutar PeopleManagement.ConsolTest para pruebas manuales.
6. Ejecutar PeopleManagement.Test para validar la funcionalidad con MSTest.
