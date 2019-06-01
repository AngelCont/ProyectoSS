# Proyecto de Construcción

Utilizando el estandar .NET de Microsoft como base este es el estandard de codificación que rige este proyecto:

## Nombramiento de variables

- Notación CamelCase: El primer carácter de las palabras se escribe en mayúscula (exceptuando la primer palabra) y los demás carácteres se escriben en minúscula.
- Usa la notación __Camel case__ para el nombramiento de variables.

~~~ c#
//Forma correcta:
int variablesLocales
int saldo

//Forma incorrecta:
int VariablesLocales.
string NombrePersonal
~~~

- Utiliza palabras entendibles y descriptivas para nombrar a las variables. __NO uses abreviaciones__.

~~~ c#
//Forma correcta:
string dirección;
int salario;

//Forma incorrecta:
string nom;
string domic;
int sal;
~~~

## Nombramiento de propiedades

- Notación Pascal: El primer carácter de todas las palabras se escriben en mayúsculas, los demas carácteres se escriben en minusculas.
- Utiliza notación __Pascal__ para nombrar las clases.

~~~ c#
//Forma correcta:
public int Propiedad { get; set; }

//Forma incorrecta:
public propiedad { get; set; }
public string nombrePersonal {get; set;}
~~~

- Usa palabras entendibles y descriptivas para nombrar a las variables. __NO uses abreviaciones__.

~~~ c#
//Forma correcta:
public string Direccion { get; set; };
public int Salario { get; set; };

//Forma incorrecta:
private string nom { get; set; };
public string domic { get; set; };
~~~

## Definición de Constantes

- El nombre de las constantes van en __notación Pascal__
- Las constantes se definen en una clase estatica _Constantes_ de la siguiente manera:

~~~ c#
static class Constantes{
  public static int Velocidad = 400000;
  public static floar IVA = .15;
}
~~~

## Nombramiento de clases

- Notación Pascal: El primer carácter de todas las palabras se escriben en mayúsculas, los demas carácteres se escriben en minusculas.
- Utiliza notación __Pascal__ para nombrar las clases.

~~~ c#
//Forma correcta:
public class NombreDeLaClase{

}

public class HolaMundo{
  ...
}

//Forma Incorrecta:
public class nombreDelaClase{

}

public class holaMundo{
  ...
}
~~~

## Nombramiento de metodos

- Notación Pascal: El primer carácter de todas las palabras se escriben en mayúsculas, los demas carácteres se escriben en minusculas.
- Utiliza notación __Pascal__ para nombrar las clases.

~~~ c#
//Forma correcta:
void SumarPuntos(int puntos)
{
  ...
  ...
}

//Forma incorrecta:
void sumarPuntos(int puntos)
{
  ...
  ...
}
~~~

- __Usa notación de Camel case para variables y parámetros de los métodos.__

Ejemplo:

~~~ c#
int cuentaTotal = 0;
void EscribeHola(string nombre)
{
  string mensajeCompleto = “Hola “ + nombre;
  ...
}
~~~

## Interfaces y estructuras de datos

- Usa el prefijo __“I”__ con notación __Pascal__ para las interfaces.

~~~ c#
//Ejemplo:
interface IClaseDAO{
  void Metodo1(int variable);
  int Metodo2();
}
~~~

- Utiliza __“T“__  con notación __Pascal__ para estructuras de tipos de datos.

~~~ c#
public class TFactura
{
  public String nombreDelCliente;
  (...)
  public ArrayList lineasDeDetalle= newArrayList();
}
~~~

- __No__ usar notación Húngara para el nombre de las variables (Que codificas a gusto personal).

- __NUNCA__ usar la función Húngara –la  cual especifica el tipo de dato de la variable como un prefijo en el nombre.

~~~ c#
//Ejemplo:
string m_sNombre;

int nEdad;
~~~

- El uso del tipo de dato y del prefijo m_ para representar variables globales __no debe ser usado__. Todas las variables deben usar una notación __Camel case__.

- No uses nombres de variables de un solo carácter como i, n, s, etc. Usa nombres como indice, temp.

- Una excepción en este caso podría ser las variables usadas para iteraciones en los ciclos:

~~~ c#
for (int i = 0; i < cuantos; i++)
{
  ...
}
~~~

- No utilices guiones bajos ( _ ) para nombres de variables locales.

- Todas las variables globales deben usar el  prefijo de guión bajo ( _ ) de tal forma que puedan ser identificadas de otras variables locales.

- No uses palabras reservadas para nombres de variables.

- Escribe solo una declaración por línea.

- Si las líneas de continuación no están sangradas automáticamente, sangra una tabulación (cuatro espacios).

- Agregua al menos una línea en blanco entre las definiciones de métodos y las definiciones de propiedades.

- Usa paréntesis para hacer que las cláusulas en una expresión sean aparentes, como se muestra en el siguiente código.

~~~ c#
if ((val1 > val2) && (val1 > val3))
{
    // Codigo
}
~~~

## Observaciones para la conexión a base de datos

- No dejar la cadena de conexión cruda dentro del código.

~~~ c#
//Forma correcta
private string conexionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
~~~

~~~ c#
//Forma incorrecta
private string conexionString = "Data Source=Fuente;Initial Catalog=BaseDatos;Persist Security Info=True;User ID=usuario;Password=***********"
~~~

- __No escribir la consulta sin parametrizar__

~~~ c#
//Forma correcta
SqlCommand sqlCommand = new SqlCommand("SELECT dato FROM tabla WHERE valor = @busqueda");

sqlCommand.Parameters.Add(new SqlParameter("busqueda", datoBusqueda));

SqlCommand sqlCommand = new SqlCommand("INSERT INTO tabla VALUES (@registro)")

sqlCommand.Parameters.Add(new SqlParameter("registro", nuevoDato));
~~~

~~~ c#
//Forma incorrecta
SqlCommand sqlCommand = new SqlCommand("SELECT dato FROM tabla WHERE valor = " +busqueda);

SqlCommand sqlCommand = new SqlCommand("INSERT INTO tabla VALUES (" +nuevoDato+ ")")
~~~

- La plantilla __únicamente__ para los métodos de que __hacen uso de la base de datos__ es:

~~~ c#
using(SqlConnection sqlConnection = new SqlConnection(conexionString)){
  sqlConnection.open();
  using(SqlCommand sqlCommand = new SqlCommand("sentencia")){

  }
}
~~~

## Sangría y espaciamiento

- Para la sangría seran utilizados los TAB, no los espacios.

- Las llaves "{ }" estarán al mismo nivel del código.

~~~ c#
//Forma correcta
bool metodoEjemplo()
{
  //Instrucciones
  //...
}
~~~

~~~ c#
//Forma incorrecta
bool metodoEjemplo(){
//Instrucciones
//...
}
~~~

- Para separar un grupo lógico de código, utiliza una línea en blanco.

~~~ c#
//Forma correcta
bool metodoEjemplo()
{
  String mensaje = "Hola " + nombreEmpleado;
  String MensajeCompleto = mensaje + ", hoy debes realizar " + metaDiaria;

  messageBox(MensajeCompleto);  
  //Instrucciones
  //...
}
~~~

~~~ c#
//Forma incorrecta
bool metodoEjemplo()
{
  string mensaje = "Hola " + nombreEmpleado;
  string MensajeCompleto = mensaje + ", hoy debes realizar " + metaDiaria;
  -----------------------------------------------------------------------
  messageBox(MensajeCompleto);  
  //Instrucciones
  //...
}
~~~

- Entre cada método de una clase solo debe haber una línea en blanco de separación.

- Uso de #region para agrupar piezas de codigo juntas.

Ejemplo:

~~~ c#
#region

bool entradaValidada = false;
string metaDiaria;
#endregion
~~~

- Mantener privadas las variables globales, las propiedades y los métodos en la parte superior del archivo y los elementos públicos en la parte inferior

## Definición de comentarios

- Los comentarios se ponen después de dos diagonales: //.
- Los comentarios demasiados largos (más de 100 carácteres) se continuan en la siguiente línea.
- No debe ser comentado así: /\*...* /.

~~~ c#
//Forma correcta
//Este es un comentario bien escrito.

//Este comentario también esta bien redactado pero es demasiado largo
//por eso se continua en otra linea.
~~~

~~~ c#
/* Mal Comentario */

/*
 * Mal Comentario
 */
~~~

- Los comentarios deben iniciar con mayúscula.
- Terminar los comentarios con un punto.

~~~ c#
//Buen comentario.
~~~

~~~ c#
//mal comentario
//Mal comentario
~~~

- Los comentarios se ponen una línea arriba de donde está lo que se quiere comentar.
- __Nunca__ comentar al finalizar la línea de código.

~~~ c#
//Forma correcta
//Verifica que el valor de la lista coincida con el número de personas.
if(lista.getValor(i) == personas.getCantidad())
{
  //Resto de codigo.
}
~~~

~~~ c#
//Forma incorrecta
if(lista.getValor(i) == personas.getCantidad()) //Verifica que los valores coincidan
{
  //Resto de codigo.
}
~~~

- Los comentarios deben ser cortos y claros.
- No debe haber comentarios que no tienen que ver con el código.
- No se debe comentar todas las variables declaradas.

~~~ c#
//Forma correcta

//Actualiza el cálculo automáticamente.
~~~

~~~ c#
//Forma incorrecta

// le toca a ver esto a Juan

int animal; //Numero de perros registrados en los estados transitados.
~~~

## Documentación de clases y métodos

C# utiliza XML para generar la API del proyecto.

- Los comentarios utilizados para la documetación de clases y métodos usan tres barras diagonales: /// y un cuerpo de comentario con formato XML. Por ejemplo:

Ejemplo:

~~~ c#
/// <summary>
/// Esta clase hace algo.
/// </summary>
public class AlgunaClase
{

}
~~~

- La documentación generada a partir de los comentarios de tres barras diagonales no incluye aquellos comentarios dejados despues dos barras diagonales: //

La base para la documentación de una clase cualquiera en este proyecto es:

~~~ c#
/// <summary>
/// Explicación general de la clase.
/// </summary>
/// <remark>
/// Explicación poco mas detallada de clase.
/// </remark>
///
public class AlgunaClase
{

}
~~~

La base para la documentación de un método cualquiera en este proyecto es:

~~~ c#
/// <summary>
/// Explicación general del metodo.
/// </summary>
/// <remark>
/// <para>Explicación mas detallada del metodo.</para>
/// </remark>
/// <param name="nombre de parametro">Tipo de parametro.</param>
/// <returns>
/// Aclaración de valor que regresa.
/// </returns>
/// <exception cref="excepción">Condición para aparición de la excepción.</exception>
private void multiplicar(int ancho, int alto)
{

}
~~~

No todos los métodos utilizan esas etiquetas, si no utilizas una quítala y continua con la siguiente. En caso de que quiera usar otra etiqueta el orden es el siguiente:

~~~ c#
/// <value>
/// <example>
/// <code>
/// <typeparam>
/// <paramref>
/// <typeparamref>
/// <list>
/// <see>
/// <seealso>
~~~

### Etiquetas

Las etiquetas que se pueden realizar están redactadas en la web .NET de Microsoft, puede verlas [aquí](<https://docs.microsoft.com/es-es/dotnet/csharp/codedoc> "Documentar el código con comentarios XML")
