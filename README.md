
# Instrucciones de Instalación y Ejecucion Aplicacion de Incidentes

**1.Requisitos**

- .NET SDK 5
- SQL SERVER o una base compatible
- Un editor de codigo como Visual Studio Code o Visual Studio

**2.Configuracion Conexion**
- Configuracion de archivo appsettings.json
```bash
 ConnectionStrings": {
    "ConexionDB" :"Server=EQUIPOSEVER\\SERVER; DataBase=BASE ;Trusted_Connection=True;TrustServerCertificate=True;MultipleActiveResultSets=true;
```    

**3.Restauracion de Dependencias**
- Ejecutar el siguiente comando para Restauracion de dependencias;
```bash
dotnet restore
```   

**4.Aplicacion de Migracion**
- Ejecutar el siguiente comando para restaurar las migraciones a la base de datos
```bash
dotnet ef database update
```  

**5.Ejecucion de la Aplicacion**
- Ejecutar el siguiente comando para ejecutar la aplicación
```bash
    dotnet run
```   
-  La aplicacion estara disponible en los enlaces : http://localhost:5000 o https://localhost:5001

**6.Acceder de la aplicacion**
- Abrir el navegador e ingresar a las URL dispinibles proporcionadas


## Patrones y Prácticas Implementadas

#### **Separación de Responsabilidades:**
Se utiliza una arquitectura basada en capas (Controladores, Repositorios, Servicios) para separar la lógica de negocio, acceso a datos y presentación.

#### **Repository Pattern:**
Los repositorios (IIncidenteRepository, ITecnicoRepository, etc.) encapsulan el acceso a datos, promoviendo la reutilización y facilitando pruebas unitarias.

#### **Dependency Injection (Inyección de Dependencias):**
Los servicios y repositorios se registran en el contenedor de dependencias de ASP.NET Core, permitiendo una inyección limpia y desacoplada.

#### **AutoMapper:**
Se utiliza AutoMapper para mapear entidades de base de datos a DTOs, reduciendo la repetición de código.

#### **Validaciones y Manejo de Errores:**
Se implementan validaciones en los modelos y controladores para garantizar la integridad de los datos.
Los errores se manejan con bloques try-catch y mensajes claros para facilitar el diagnóstico.

####  **Responsive Design:**
Las vistas utilizan Bootstrap para garantizar un diseño responsive y accesible en diferentes dispositivos.

#### **Asincronía:**
Todos los métodos de acceso a datos son asíncronos (async/await) para mejorar el rendimiento y evitar bloqueos.

## Información Adicional

#### **Uso de Datatables:**
Se utilizo Datatables para manejar los datos en genera y darle paginacion, filtros y demas.

#### **Uso de SweetAlert:**
Se utilizo sweetalert para lanzar alertas en ciertos procedimientos los cuales pueden cancelar algun procedimiento como eliminar, editar o registrar.

#### **Uso de CHART.JS:**
Se utilizo chart.js para mostrar la informacion de los reportes de los incidentes de manera grafica.

## Diagrama BD

[![Captura-de-pantalla-2025-03-24-022114.png](https://i.postimg.cc/GpzGLFJY/Captura-de-pantalla-2025-03-24-022114.png)](https://postimg.cc/xkJcgbZT)

## Funcionamiento
#### 1.Registro Incidente:
[![Registro-Incidente.png](https://i.postimg.cc/PJHC1N4h/Registro-Incidente.png)](https://postimg.cc/ygf6H1tr)
[![Incidente-Registrado.png](https://i.postimg.cc/LXLqqjjN/Incidente-Registrado.png)](https://postimg.cc/HcWWRcZy)
#### 2.Edicion Incidente:
[![Edicion-Registro.png](https://i.postimg.cc/DztJyx4S/Edicion-Registro.png)](https://postimg.cc/cKB4FMmW)
[![Confirmacion-Editado.png](https://i.postimg.cc/TPy56z18/Confirmacion-Editado.png)](https://postimg.cc/zLrGwPTp)
[![Prueba-Editado.png](https://i.postimg.cc/rwwth0Lw/Prueba-Editado.png)](https://postimg.cc/LnGX5sXc)
#### 3.Detalles Incidente:
[![Detalles-Incidente.png](https://i.postimg.cc/GmgT6LcJ/Detalles-Incidente.png)](https://postimg.cc/sMS2hRGv)

#### 4.Eliminacion Incidente:
[![Confirmacion-Eliminacion.png](https://i.postimg.cc/rFJrCG3H/Confirmacion-Eliminacion.png)](https://postimg.cc/KR1jmTZ7)
[![Prueba-Eliminado.png](https://i.postimg.cc/15PFq7C6/Prueba-Eliminado.png)](https://postimg.cc/HjZjGzCs)
#### 5.Reportes Incidente:
[![Reporte2.png](https://i.postimg.cc/ZY630zc4/Reporte2.png)](https://postimg.cc/NLfLPVSz)
[![Reportes1.png](https://i.postimg.cc/Rh1nYwFN/Reportes1.png)](https://postimg.cc/2L66bbnD)

