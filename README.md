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
> tiene un crud sencillo tanto para el usuario y las tarjetas, las tarjetas tiene relacion con los usuarios al eliminar un usuario estas se eliminan en cascada
> La eliminacion de usuario existe otra tabla llamada "UsuarioBaja" cada vez que se elimine un usuario este pasa a guardarse de manera automaticamente en la tabla UsuarioBaja
> Mantiene las entidades de entityFramework (no el contexto solo las entidades)
> cuenta con un login sencillo tanto con su registro.

## bugs
> no detecta los dataAnnotation, lo cual podria solucionarlo desde una respusta del api y realizar dichas validaciones desde el servidor creando una respuesta personalizada.
> no es bug xd pero un mejor diseño no quedaria mal

