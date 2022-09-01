# PacMaster 
### Por Joel Piñeiro Suarez y José María Pereira Montero
En este proyecto podremos ver una clássico, *PacMan*, reconvertido a una experiencia multijugador asíncrona en línea.

PacMaster se ha creado con el fin de presentarlo como proyecto de fin de curso para DAM DUAL en el IES de TEIS. Explorando nuevas tecnologías y aplicando conocimientos obtenidos a lo largo del curso.

El principal objetivo es la conectividad para la creación de un juego multijugador en linea.

[Documentación de la aplicación](https://docs.google.com/document/d/1RcDKVdtRN3SXSTfskAkt5VghlbU7UhO6GX8g62Y2wZ4/edit?usp=sharing)
[Presentación de la aplicación](https://1drv.ms/p/s!Ag1YkQf6CsrYsBO54zvm8eHQJack?e=n9SfgR)

## Tecnologías
1. **Unity 3D**</br>
Unity va a ser nuestro Motor de Juego usado. No es una tecnología que dimos en el curso, pero puesto que nos da facilidades a la hora de iniciar el proyecto y tiene una Asset Store muy completa, podremos centrarnos en la parte mas técnica del proyecto.</br>
Versión usada: 2021.3.2f1
2. **Apache Kafka**</br>
Usamos Kafka para la creación de un servidor. Para ello hemos usado la dependencia de [Confluent dotNET](https://github.com/confluentinc/confluent-kafka-dotnet) importandolo en el proyecto con [NuGet](https://github.com/GlitchEnzo/NuGetForUnity/releases). Para una guía mas detallada, hay un apartado en la documentación de implementación de Kafka.</br>
Es necesario crear un Kafka Cluster y despues indicar en el proyecto la ip y el puerto del mismo para poder conectarnos a el.
