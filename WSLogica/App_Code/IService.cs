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

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IServicioLogica
{
   
    //Lineas y estaciones
    [OperationContract]
    bool CrearLinea(string nombreLinea, int numeroTrenes, string tipo);
    [OperationContract]
    bool CrearEstacion(string nombreLinea, string estacion);
    [OperationContract]
    bool ModificarLinea(string nombreLinea, string nuevoNombre, int numeroTrenes, string tipo);
    [OperationContract]
    ServicioData.Linea ObtenerLinea(string nombreLinea); 
    [OperationContract]
    ServicioData.Estacion ObtenerEstacion(string nombreLinea, string nombreEstacion);
    [OperationContract]
    bool ModificarEstacion(string nombreLinea, string estacion, string nuevaEstacion);
    [OperationContract]
    bool ModificarEstadoEstacion(string estacion);
    [OperationContract]
    bool ModificarEstadoLinea(string nombreLinea);
    [OperationContract]
    bool EliminarLinea(string nombreLinea);
    [OperationContract]
    bool EliminarEstacion(string nombreLinea, string estacion);
    //Trasbordos
    [OperationContract]
    bool CrearTrasbordoDoble(string linea1, string estacion1, string linea2, string estacion2);
    [OperationContract]
    bool CrearTrasbordoSimple(string estacion, List<string> lineas);
    [OperationContract]
    bool EliminarTrasbordoSimple(string nombreEstacion, string nombreLinea);
    [OperationContract]
    bool EliminarTransbordoDoble(string cadena);
    //Obtener Listas u objetos
    [OperationContract]
    List<ServicioData.TrasbordoDoble> ObtenerListaTrasbordoD();
    [OperationContract]
    List<string> ObtenerListaStringTransbordoD();
    [OperationContract]
    List<ServicioData.Linea> ObtenerListaLineas();
    [OperationContract]
    List<ServicioData.Estacion> ObtenerListaEstaciones(string nombreLinea);
    [OperationContract]
    List<ServicioData.TrasbordoSimple> ObtenerListaTrasbordoS();
    [OperationContract]
    ServicioData.TrasbordoSimple ObtenerTrasbordoS(string estacion);
    //Tablas    Necesario modificar para BD
    //[OperationContract]
   // DataTable LlenarTablaEstaciones(string nombreLinea);
    [OperationContract]
    DataTable LlenarTablas();
    //[OperationContract]
    //DataTable LlenarTablaTrasbordosDobles();
    //Administrador
    [OperationContract]
    bool ValidarUsuario(string usuario, string contraseña);
    [OperationContract]
    ServicioData.Administrador ObtenerAdministrador();
   [OperationContract]
    void ModificarAdministrador(ServicioData.Administrador admin);
    //Validaciones
    [OperationContract]
    bool ValidarTextBoxVacio(string cadena);
    [OperationContract]
    bool ValidarTextBoxCaracteresEsp(string cadena);
    [OperationContract]
    bool ValidarTextBoxNumeros(string cadena);
    [OperationContract]
    bool ComprobarEstacion(string nombreLinea, string nombreEstacion);
    [OperationContract]
    string ValidarNombres(string cadena);

	// TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
