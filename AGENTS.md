\# Frío Dorado - Reservas de habitaciones



App Windows Forms en C# sobre .NET Framework 4.8. Datos solo en XML (XDocument). Sin base de datos.

El backlog vive en Linear (proyecto "Frío Dorado", team WOR). El código y los PR viven en GitHub.



\## Estructura

\- `FrioDorado.Core`: modelos, reglas de negocio, servicios y repositorio XML. NO referencia System.Windows.Forms.

\- `FrioDorado.Tests`: xUnit. Solo prueba Core.

\- `FrioDorado.App`: formularios delgados. Solo llaman a servicios de Core.



\## Reglas de negocio

\- Una reserva ocupa de entrada a salida, sin contar el día de salida. Salir el día X no choca con entrar el día X.

\- Noches = salida - entrada, mínimo 1.

\- Descuento: porcentaje del subtotal, de 0 a 100.

\- Total = noches x tarifa x (1 - descuento).

\- Una reserva cancelada no bloquea la habitación.

\- Estados de reserva: Activa, Cancelada.



\## Cómo trabajamos (TDD)

1\. Una issue de Linear = una rama = un PR. Usar el nombre de rama que sugiere Linear.

2\. Primero la lista de pruebas en lenguaje natural. Joel la aprueba antes de escribir código.

3\. RED: se escriben las pruebas y se ven fallar por la razón correcta.

4\. GREEN: se escribe lo mínimo para pasarlas. Nada de funciones que ninguna prueba pida.

5\. REFACTOR: limpiar con las pruebas en verde.

6\. Commits pequeños, un paso por commit.



\## Reglas para agentes (obligatorias)

\- NO modificar, borrar ni comentar pruebas para que pasen. Si una prueba parece mal, detenerse y avisar a Joel.

\- NO fusionar PR propios ni hacer push a `main`.

\- NO añadir paquetes NuGet sin preguntar.

\- NO poner lógica de negocio en los formularios.

\- Antes de cambiar código, explicar en 2-3 frases qué se hará y por qué. Joel debe poder repetirlo con sus palabras.

\- Si la tarea toca más de lo que dice la issue, detenerse y preguntar.

\- Prompts de implementación: una sola issue, solo los archivos necesarios.



\## Comandos

\- Pruebas: `dotnet test` desde la raíz de la solución (en Windows).

\- Si falta el Developer Pack de .NET Framework 4.8, agregar el paquete `Microsoft.NETFramework.ReferenceAssemblies` a los proyectos.



\## Definición de Terminado

\- Criterios de aceptación de la issue cumplidos.

\- Pruebas nuevas y anteriores en verde.

\- Diff leído por Joel y revisado por Claude Code.

\- PR con 3 líneas escritas por Joel: qué hace y por qué.

\- Issue cerrada en Linear.


## Interfaz (WinForms)
- Todos los controles se crean con el diseñador de Visual Studio y viven en Form1.Designer.cs (InitializeComponent). Joel debe poder moverlos y editarlos visualmente.
- NO crear controles dinámicamente en el constructor ni en Form1.cs, salvo que la issue lo pida.
- Si hay que tocar un .Designer.cs a mano, solo con patrones que el diseñador entienda. Después, avisar a Joel para que lo abra en el diseñador y confirme.
- Los manejadores de eventos van en Form1.cs y solo llaman a servicios de Core.