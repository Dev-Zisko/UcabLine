using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Collections;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{
    [OperationContract]
    bool estadoServicio();
    [OperationContract]
    void actualizarLlegadas(string tiempo, string nombreLinea);
    [OperationContract]    
    bool verificarUsuario(string usuario, string contraseña);
    [OperationContract]
    bool crearLinea(string nombreLinea, int trenes, string tipo);
    [OperationContract]
    bool crearEstacion(string nombreLinea,string estacion);
    [OperationContract]
    bool modificarLinea(string nombreLinea, string nuevoNombre, int trenes, string tipo);
    [OperationContract]
    bool modificarEstacion(string nombreLinea, string nombreEstacion, string nuevaEstacion);
    [OperationContract]
    bool modificarEstadoLinea(string nombreLinea);
    [OperationContract]
    bool modificarEstadoEstacion(string nombreEstacion);
    [OperationContract]
    bool eliminarLinea(string nombreLinea);
    [OperationContract]
    bool eliminarEstacion(string nombreLinea, string nombreEstacion);
    [OperationContract]
    bool buscarLinea(string nombreLinea);
    [OperationContract]
    bool buscarEstacion(string nombreLinea, string nombreEstacion);
    //[OperationContract]
   // bool comprobarEstado(string nombreLinea);
    [OperationContract]
    List<Linea> generarListaLinea();
    [OperationContract]
    List<Estacion> generarListaEstaciones(string nombreLinea);
    [OperationContract]
    Linea obtenerLinea(string nombreLinea);
    [OperationContract]
    Estacion obtenerEstacion(string nombreLinea, string nombreEstacion);
    [OperationContract]
    void verificarEstadoLinea();
    [OperationContract]
    bool crearTrasbordoSimple(string estacion, List<string> lineas);
    [OperationContract]
    bool crearTrasbordoDoble(string linea1, string estacion1, string linea2, string estacion2);
    [OperationContract]
    bool eliminarTrasbordoGeneral(string linea, string estacion);
    [OperationContract]
    bool eliminarTrasbordoLineasGeneral(string linea);
    [OperationContract]
    bool eliminarTrasbordoSimple(string estacion);
    [OperationContract]
    bool eliminarTrasbordoDoble(string estacion1, string estacion2);
    [OperationContract]
    bool modificarTrasbordoGeneralEstacion(string estacion, string nuevaEstacion);
    [OperationContract]
    List<TrasbordoDoble> generarListaTrasbordoD();
    [OperationContract]
    List<TrasbordoSimple> generarListaTrasbordoS();
    [OperationContract]
    bool modificarTrasbordoGeneralLinea(string linea, string nuevaLinea);
    [OperationContract]
    Administrador obtenerAdministrador();
    [OperationContract]
    void modificarAdministrador(string username, string password);
   
  
   

}
	// TODO: agregue aquí sus operaciones de servicio

    [DataContract]
    public class Linea
    {
        
        public Linea(string nombre, string estado, int numeroTrenes, string tipo)
        {
            this.nombre = nombre;
            this.estado = estado;
            this.numeroTrenes = numeroTrenes;
            this.tipo = tipo;
        }

        [DataMember]
        public string nombre { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public int numeroTrenes { get; set; }
        [DataMember]
        public List<Estacion> estaciones { get; set; }
        [DataMember]
        public string tipo { get; set; }
    }

    [DataContract]
    public class Estacion
    {
        
        public Estacion(string nombreEstacion, string estado)
        {
            this.nombreEstacion = nombreEstacion;
            this.estado = estado;
        }
        [DataMember]
        public string nombreEstacion { get; set; }
        [DataMember]
        public string estado { get; set; }


    }

    [DataContract]
    public class TrasbordoSimple
    {
        public TrasbordoSimple(string estacion)
        {
            this.estacion = estacion;
        }
        [DataMember]
        public string estacion { get; set; }
        [DataMember]
        public List<string> lineas { get; set; }

    }

    [DataContract]
    public class TrasbordoDoble
    {
        public TrasbordoDoble(string linea1, string estacion1, string linea2, string estacion2)
        {
            this.linea1 = linea1;
            this.estacion1 = estacion1;
            this.linea2 = linea2;
            this.estacion2 = estacion2;
            
        }
        [DataMember]
        public string estacion1 { get; set; }
        [DataMember]
        public string estacion2 { get; set; }
        [DataMember]
        public string linea1 { get; set; }
        [DataMember]
        public string linea2 { get; set; }
    }

    [DataContract]
    public class Administrador
    {
        public Administrador(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        [DataMember]
        public string username { get; set; }
        [DataMember]
        public string password { get; set; }
    }