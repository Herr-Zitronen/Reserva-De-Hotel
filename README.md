# Hotel Frío Dorado – Reservas de habitaciones

Aplicación de escritorio (Windows Forms, .NET Framework 4.8) para gestionar las reservas de un hotel de 12 habitaciones. Los datos se guardan únicamente en XML.

Ejercicio 5 de Aplicaciones Informáticas (ESPOCH).

## Qué hace

- Crear, modificar y cancelar reservas (la cancelación pide confirmación).
- Evita solapamientos: una reserva ocupa de la entrada a la salida sin incluir el día de salida.
- Calcula noches y total con descuento: `noches × tarifa × (1 − descuento/100)`.
- Busca reservas por documento y consulta habitaciones libres por rango de fechas.
- Cuatro reportes: reservas por período, ingresos por tipo, habitaciones más reservadas y reservas canceladas por período.
- Persistencia en `datos.xml`, con copia de seguridad `datos.xml.bak` y recuperación ante archivo ausente, vacío o dañado.

Habitaciones: 101–104 Simple ($35), 201–204 Doble ($55), 301–304 Suite ($90) por noche.

## Estructura

| Proyecto | Contenido |
| --- | --- |
| `FrioDorado.Core` | Entidades, reglas de negocio, reportes y repositorio XML |
| `FrioDorado.App` | Formularios Windows Forms |
| `FrioDorado.Tests` | Pruebas xUnit del Core |
| `datos-ejemplo` | Archivos XML de ejemplo para probar cada operación |

## Cómo ejecutarlo

1. Abrir `FrioDorado.sln` en Visual Studio y ejecutar `FrioDorado.App`.
2. Al primer inicio se crea `datos.xml` junto al ejecutable, con las 12 habitaciones y sin reservas.
3. Para probar con datos: cerrar la aplicación y copiar `datos-ejemplo/datos.xml` sobre el `datos.xml` de `FrioDorado.App/bin/Debug`.

## Pruebas

```
dotnet test
```

## Archivos de ejemplo

| Archivo | Para probar |
| --- | --- |
| `datos.xml` | 12 habitaciones y 10 reservas (8 activas, 2 canceladas): todas las operaciones y reportes |
| `datos-vacio-inicial.xml` | Alta de la primera reserva |
| `datos-corrupto.xml` | Recuperación ante XML dañado (genera `datos.xml.corrupto.bak`) |
| `datos-sin-reservas-archivo-vacio.xml` | Archivo de 0 bytes: se recrea con datos iniciales |

Resultados esperados de los reportes con `datos.xml`:

- Reservas del 10 al 15/11/2026: 5 reservas (códigos 1 a 5).
- Ingresos por tipo: Simple $171,50, Doble $649,00, Suite $630,00.
- Más reservadas: 201 (3), 101 (2), 301 (2), 202 (1).
- Canceladas de nov a dic 2026: 2 reservas (códigos 6 y 9).

## Método de trabajo

Scrum con backlog y sprints en Linear, TDD (pruebas primero) y agentes de IA como apoyo. Todos los cambios entraron por Pull Request en GitHub.
