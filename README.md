# DrSecurity3Capas
sistema web en 3 capas 

# descripcion breve
El sistema solo añade usuarios, tiene un login y un registro dentro del menu puede registrar tarjetas simulando una pequeña billetera xd.


## Sistema basado en 3 capas
### Datos
> es la capa donde nos provee datos de algun archivo de texto o base de datos
### Servicios
> capa que nos provee los datos de una api
### Negocio 
> capa donde se encuentra la logica del negocio 
### Presentador
> capa donde el cliente interactua con la interfaces de usuario, en este caso es un proyecto en MVC con razor

## funciones
1. Tiene un crud sencillo tanto para el usuario y las tarjetas, las tarjetas tiene relacion con los usuarios al eliminar un usuario estas se eliminan en cascada
2. La eliminacion de usuario existe otra tabla llamada "UsuarioBaja" cada vez que se elimine un usuario este pasa a guardarse de manera automaticamente en la tabla UsuarioBaja
3. Mantiene las entidades de entityFramework (no el contexto solo las entidades)
Cuenta con un login sencillo tanto con su registro.

## Como instalarlo 
Antes de instalarlo, debemos mantener activa la api, para instalarla esta en el siguiente enlace
> https://github.com/saulkali/DrSecurityApi

En visual studio, al inicar visual studio, nos otorga la funcion de clonar un repositorio el cual le pasamos el siguiente
> https://github.com/saulkali/DrSecurity3Capas.git

![alt text](https://i.ytimg.com/vi/c4nuFjV9yms/maxresdefault.jpg)
Automaticamente y por teoria tendria que instalar todo.

## bugs
1. No detecta los dataAnnotation, lo cual podria solucionarlo desde una respusta del api y realizar dichas validaciones desde el servidor creando una respuesta personalizada.
2. No es bug xd pero un mejor diseño no quedaria mal


