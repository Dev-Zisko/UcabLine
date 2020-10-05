using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Collections;
using System.Web.UI.WebControls;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using System.Globalization;
// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class ServicioLogica : IServicioLogica
{
    
   
    ServicioData.ServiceClient clienteData = new ServicioData.ServiceClient();
    DateTime tIni;
    //Verificacion de estado servicio
  
    // Administracion de contenidos
    public bool CrearLinea(string nombreLinea, int numeroTrenes, string tipo, int idLinea)  //Llama al metodo crear linea en Data
    {
        if (clienteData.crearLinea(idLinea, nombreLinea,"activada", numeroTrenes, tipo))
        {
           // clienteData.verificarEstadoLinea();
            return true;
        }
        else
            return false;
    }

    public bool CrearEstacion(string nombreLinea, string nombreEstacion, int idEstacion) // Llama al metodo crear estacion en Data
    {
        //Crea un objeto Estacion con los datos obtenidos. int idEstacion, string estacion, string estado, string tiempo, string nombreLinea

        if (clienteData.crearEstacion(idEstacion, nombreEstacion, "activada", "00:00 p.m.", nombreLinea))
            return true;
        else
            return false;
    }

    public bool ModificarLinea(string nombreLinea, string nuevoNombre, int numeroTrenes, string tipo) //Llama al metodo modificarLinea en Data
    {
        if (clienteData.modificarLinea(nuevoNombre, numeroTrenes, tipo,  nombreLinea)) //si encuentra la linea y la logra modificar
        {
            //clienteData.modificarTrasbordoGeneralLinea(nombreLinea, nuevoNombre);
            return true;
        }
        
        else
            return false;
    }

    public ServicioData.Linea ObtenerLinea(string nombreLinea) 
    {
        return (clienteData.obtenerLinea(nombreLinea));

    }


    public ServicioData.Estacion ObtenerEstacion(string nombreLinea, string nombreEstacion)
    {
       return clienteData.obtenerEstacion(nombreLinea, nombreEstacion);
    }

    public bool ModificarEstacion(string nombreLinea, string estacion, string nuevaEstacion) //Llama al metodo modificarEstacion en Data
    {
        if (clienteData.modificarEstacion(nuevaEstacion, "00:00 p.m.", estacion, nombreLinea)) //si encuentra la estacion en la linea y la logra modificar
        {
            //clienteData.modificarTrasbordoGeneralEstacion(estacion, nuevaEstacion);
            return true;
        }
        else
            return false;
    }

   
    public bool ModificarEstadoEstacion( string nombreEstacion) //Modifica el estado operativo de la estacion
    {
          if (clienteData.modificarEstadoEstacion(nombreEstacion, estado, nom)) // Si modifica el estado retorna verdadero
          {
              clienteData.verificarEstadoLinea();
              return true;
          }
        
          else // En caso contrario retorna falso
              return false;
    }

    public bool ModificarEstadoLinea(string nombreLinea)  //Modifica el estado Operativo de la Linea
    {
        if (clienteData.modificarEstadoLinea(nombreLinea)) // Si modifica el estado retorna verdadero
        {
            clienteData.verificarEstadoLinea();
            return true;
           
        }

        else // En caso contrario o que no tenga estaciones la linea, retorna falso.
            return false;
    }


  

    public bool EliminarLinea(string nombreLinea) 
    {
        if (clienteData.buscarLinea(nombreLinea))//Llama al metodo que Verifica si la linea existe en Data.
        { 
            if (clienteData.eliminarLinea(nombreLinea)) //Si la linea existe, llama la función que elimina la linea en Data.
            {
                clienteData.eliminarTrasbordoLineasGeneral(nombreLinea); // Si logra eliminar la linea, Llama a la función que elimina la linea de los trasbordos
            }
            return true;
        }
        else
            return false;
    }

    public bool EliminarEstacion(string nombreLinea, string estacion) 
    {
        if(clienteData.buscarEstacion(nombreLinea,estacion)) //Llama la función que verifica si la estación existe en esa linea.
        {
            if (clienteData.eliminarEstacion(nombreLinea, estacion)) //Si la estación existe, llama al metodo que elimina la estacion de la linea.
                clienteData.eliminarTrasbordoGeneral(nombreLinea,estacion); //si elimina la estación, llama al metodo que elimina a la estación de cada trasbordo general.
            clienteData.verificarEstadoLinea(); //Llama al metodo que verifica el estado de cada una de las lineas.
            return true;
           
        }
        else
            return false;
    }

    public bool CrearTrasbordoDoble(string linea1, string estacion1,string linea2, string estacion2) // Llama al metodo para crear un Transbordo Doble desde Data
    {

        if (clienteData.crearTrasbordoDoble(linea1, estacion1, linea2, estacion2))
            return true;
        else
            return false;
      
    }

    public bool CrearTrasbordoSimple(string estacion, List<string> lineas) //Llama al metodo para crear un Transbordo Simple desde Data
    {

        if (clienteData.crearTrasbordoSimple(estacion, lineas.ToArray()))
        {
            clienteData.verificarEstadoLinea();
            return true;
           
        }
        else
            return false;
       
    }

    public bool EliminarTrasbordoSimple(string nombreEstacion, string nombreLinea)
    {
        if (clienteData.eliminarTrasbordoSimple(nombreEstacion)) //Llama a la función que elimina al trasbordo simple del xml de trasbordos.
        {
            clienteData.crearEstacion(nombreLinea, nombreEstacion); // si logra borrar el trasbordo, crea la estación que era trasbordo en la linea que fue seleccionada.
            return true;
        }
        else
            return false;
    }

    public bool EliminarTransbordoDoble(string cadena)
    {
       ServicioData.TrasbordoDoble trasbordo =  ConversionTransbordoD(cadena); // Crea el objeto trasbordoDoble a partir de la cadena de formato Linea1.Estacion1-Linea2.Estacion2

       if (clienteData.eliminarTrasbordoDoble(trasbordo.estacion1, trasbordo.estacion2)) //Llama a la función que elimina el trasbordo doble del xml correspondiente.
           return true;
       else
           return false;
    }
    
   
    public List<ServicioData.Linea> ObtenerListaLineas() //Metodo que obtiene la lista de lineas del servicio Data y las transforma a string
    {
        return clienteData.generarListaLinea().ToList(); 
    }

    public List<ServicioData.Estacion> ObtenerListaEstaciones(string nombreLinea) // Metodo que obtiene la lista de estaciones dado un nombre de linea
    {

        if (clienteData.buscarLinea(nombreLinea))
            return (clienteData.generarListaEstaciones(nombreLinea).ToList());
        else
            return null;
        
    }

    public List<ServicioData.TrasbordoDoble> ObtenerListaTrasbordoD()
    {
        return clienteData.generarListaTrasbordoD().ToList();
    }

    public List<string> ObtenerListaStringTransbordoD() //Obtiene una lista de strings con el formato "Linea1.estacion1-Linea2.estacion2"
    {
        List<ServicioData.TrasbordoDoble> trasbordos = ObtenerListaTrasbordoD();
        List<string> lista = new List<string>();

        foreach (ServicioData.TrasbordoDoble t in trasbordos)
        {
            string cadena = (t.linea1 + "." + t.estacion1 + "-" + t.linea2 + "." + t.estacion2);
            lista.Add(cadena);

        }
        return lista;
    }

    public List<ServicioData.TrasbordoSimple> ObtenerListaTrasbordoS() // función que devuelve la lista de trassbordos simples obtenidas del xml correspondiente en Data.
    {
        return clienteData.generarListaTrasbordoS().ToList();
    }

    public ServicioData.TrasbordoSimple ObtenerTrasbordoS(string estacion) //función que devuelve un objeto TrasbordoSimple
    {
        List<ServicioData.TrasbordoSimple> lista = clienteData.generarListaTrasbordoS().ToList();
        foreach (ServicioData.TrasbordoSimple tras in lista)
        {
            if (tras.estacion.Equals(estacion))
                return tras;
        }
        return null;
    }
    public bool ComprobarEstacion(string nombreLinea, string nombreEstacion) //Llama a la funcion de Data que comprueba si la estacion existe en la linea dada, es utilizada en modificar Estacion en interfaz
    {
        //if (clienteData.buscarEstacion(nombreLinea, nombreEstacion))
        //    return true;
        //else
        //    return false;
    }
    // Tablas
      public DataTable LlenarTablas(string tipo) //funcion que arma y devuelve la tabla según los datos obtenidos de las lineas en el xml correspondiente.
      {

        return clienteData.llenarTablas(tipo);
            /*bool estado;
        
        List<ServicioData.Linea> lineas = clienteData.generarListaLinea().ToList();

          if (lineas != null)
          {

              DataTable tabla = new DataTable("Lineas");
              tabla.Columns.Add("Nombre de Linea");
              tabla.Columns.Add("Numero de trenes");
              tabla.Columns.Add("Tipo de Linea");
              DataColumn columnaBool = new DataColumn("Operatividad", System.Type.GetType("System.Boolean"));
              tabla.Columns.Add(columnaBool);


              foreach (ServicioData.Linea linea in lineas)
              {
                  if (linea.estado.Equals("true"))
                      estado = true;
                  else
                      estado = false;

                  tabla.Rows.Add(linea.nombre,linea.numeroTrenes, linea.tipo, estado);
              }

              tabla.AcceptChanges();
              return tabla;
          }
          else
              return null;
            */
       
      } 


    /*public DataTable LlenarTablaEstaciones(string nombreLinea) //funcion que arma y devuelve la tabla según los datos obtenidos de las estaciones en el xml correspondiente.
    {
        bool estado;
        List<ServicioData.Estacion> estaciones = ObtenerListaEstaciones(nombreLinea);
       
        if (estaciones != null)
        {

            DataTable tabla = new DataTable("Estaciones");
            
            tabla.Columns.Add("Estacion");
            DataColumn columnaBool = new DataColumn("Operatividad", System.Type.GetType("System.Boolean"));
            tabla.Columns.Add(columnaBool);

            foreach (ServicioData.Estacion estacion in estaciones)
            {
                if (estacion.estado.Equals("true"))
                    estado = true;
                else
                    estado = false;

                tabla.Rows.Add(estacion.nombreEstacion, estado);
            }

            tabla.AcceptChanges();
            return tabla;
        }
        else
            return null;
    
    }/*
    public DataTable LlenarTablaTrasbordosDobles() //funcion que arma y devuelve la tabla según los datos obtenidos de los trasbordosDobles en el xml correspondiente.
    {
        List<ServicioData.TrasbordoDoble> lista = clienteData.generarListaTrasbordoD().ToList();
        DataTable tabla = new DataTable("TrasbordoDoble");
        tabla.Columns.Add("Linea de Origen");
        tabla.Columns.Add("Estacion de Origen");
        tabla.Columns.Add("Linea Destino");
        tabla.Columns.Add("Estacion Destino");

        foreach (ServicioData.TrasbordoDoble tras in lista)
        {
            tabla.Rows.Add(tras.linea1, tras.estacion1, tras.linea2, tras.estacion2);
        }
        tabla.AcceptChanges();
        return tabla;
    }*/

    //Administrador
    public bool ValidarUsuario(string usuario, string contraseña) //busca en el xml si el usuario coincide
    {
        if (clienteData.verificarUsuario(usuario, contraseña))
            return true;
        else
            return false;
    }

    public ServicioData.Administrador ObtenerAdministrador() //función que devuelve un objeto de tipo administrador
    {
        return clienteData.obtenerAdministrador();
    }

    public void ModificarAdministrador(ServicioData.Administrador admin) // metodo envía los datos correspondientes a Data para modificar las credenciales del Administrador.
    {
        clienteData.modificarAdministrador(admin.username, admin.password);
    }
     
     // Validaciones ///////////////////////Validaciones///////////////////Validaciones/////////////////////////////

    public ServicioData.TrasbordoDoble ConversionTransbordoD(string cadena) //Transforma un único string de formato "Linea1.estacion1-Linea2.estacion2" en un objeto TrasbordoDoble
    {
        string estacion1, estacion2, linea1, linea2;


        char[] delimitador = { '-', '.' };
        string[] palabras = cadena.Split(delimitador);
        linea1 = palabras[0];
        estacion1 = palabras[1];
        linea2 = palabras[2];
        estacion2 = palabras[3];

        ServicioData.TrasbordoDoble transbordoD = new ServicioData.TrasbordoDoble();
        transbordoD.linea1 = linea1;
        transbordoD.estacion1 = estacion1;
        transbordoD.linea2 = linea2;
        transbordoD.estacion2 = estacion2;
        return transbordoD;

    }

    public bool ValidarTextBoxVacio(string cadena) //Si la cadena recibida esta vacia retorna false
    {
        if (cadena == null || cadena == string.Empty || cadena == " ")
        {
            return false;
        }
        else
            return true;
    }

    public bool ValidarTextBoxCaracteresEsp(string cadena) // función que retorna true si la cadena recibida  cumple con los requisitos descritos a continuacion.
    {


        Regex reg = new Regex("^[A-Za-z0-9áéíóúAÉÍÓÚÑñ ]*$"); //Letras numeros espacios, letras acentuadas y la letra ñ.
        if (reg.IsMatch(cadena))
            return true; // Coincide
        else
            return false; //No respeta el formato
    }
    public bool ValidarTextBoxNumeros(string cadena) //Función que devuelve true si la cadena recibida contiene unicamente numeros enteros.
    {
        Regex reg = new Regex("^[0-9]*$");
        if (reg.IsMatch(cadena))
            return true;
        else
            return false;

    }

    public string ValidarNombres(string cadena) //Función que recibe una cadena y la devulve transformada al formato de Titulos (primeras letras de cada palabra en mayuscula)
    {
        TextInfo info = new CultureInfo("en-US", false).TextInfo; //Primeras letras en mayuscula
        cadena = info.ToTitleCase(cadena);
        return cadena;
    }


   
}
