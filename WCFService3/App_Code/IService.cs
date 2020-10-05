using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IService1" en el código y en el archivo de configuración a la vez.
[ServiceContract]
public interface IService
{

    [OperationContract]
    bool crearLinea(string nombreLinea, string estado, int trenes, string tipo);
    [OperationContract]
    bool crearEstacion(string estacion, string estado, string tiempo, string nombreLinea);
    [OperationContract]
    bool eliminarLinea(string nombreLinea);
    [OperationContract]
    bool eliminarEstacion(string estacion);
    [OperationContract]
    bool modificarLinea(string nombreLinea, int trenes, string tipo, string buscaLinea);
    [OperationContract]
    bool modificarEstacion(string estacion, string tiempo, string buscaEstacion, string nombreLinea);
    [OperationContract]
    bool modificarEstadoLinea(string nombreLinea);
    [OperationContract]
    bool modificarEstadoEstacion(string estacion);
    [OperationContract]
    bool crearTrasbordoDoble(string estacion1, string estacion2, string linea1, string linea2);
    [OperationContract]
    bool eliminarTrasbordoDoble(string estacion1, string estacion2);
    [OperationContract]
    List<Linea> generarListaLinea();
    [OperationContract]
    List<Estacion> generarListaEstaciones();
    [OperationContract]
    Linea obtenerLinea(string nombreLinea);
    [OperationContract]
    Estacion obtenerEstacion(string nombreLinea, string estacion);
    [OperationContract]
    DataTable llenarTablas(string tipo);
    [OperationContract]
    void actualizarLlegadas(string tiempo, string nombreLinea);
    [OperationContract]
    List<TrasbordoDoble> generarListaTrasbordoD();
    [OperationContract]
    Administrador obtenerAdministrador();
    [OperationContract]
    void modificarAdministrador(string usuario, string contraseña);
    [OperationContract]
    bool crearTrasbordoSimple(string estacion, List<string> lineas);
    [OperationContract]
    bool eliminarTrasbordoSimple(string estacion);
    [OperationContract]
    List<TrasbordoSimple> generarListaTrasbordoS();
    //[OperationContract]
    //void insertEstado(string estacion, string estado, string tiempo);
    //bool crearLinea(string nombreLinea, string estado, int trenes, string tipo);
    //[OperationContract]
    //bool crearEstacion(string estacion, string estado, TimeSpan tiempo);
    //[OperationContract]
    //bool agregarTrasbordoDobles(string estacion1, string estacion2, string linea1, string linea2);
    //[OperationContract]
    //bool agregarAdministradores(string usuario, string contraseña);
    //[OperationContract]
    //bool eliminarLinea(string nombreLinea, string estado, int trenes, string tipo);
    //[OperationContract]
    //bool prueba(string nombreLinea, string estado, string trenes, string tipo);
    //// TODO: agregue aquí sus operaciones de servicio
}

// Utilice un contrato de datos, como se ilustra en el ejemplo siguiente, para agregar tipos compuestos a las operaciones de servicio.
[DataContract]
 public class Linea
    {
        
        public Linea(string nombreLinea, string estado, int trenes, string tipo)
        {
            this.nombreLinea = nombreLinea;
            this.estado = estado;
            this.trenes = trenes;
            this.tipo = tipo;
        }

        [DataMember]
        public string nombreLinea { get; set; }
        [DataMember]
        public string estado { get; set; }
        [DataMember]
        public int trenes { get; set; }
        [DataMember]
        public string tipo { get; set; }
    }

    [DataContract]
    public class Estacion
    {
        public Estacion(string estacion, string estado, string tiempo)
        {
            this.estacion = estacion;
            this.estado = estado;
            // this.linea = linea;
            this.tiempo = tiempo;
        }
        [DataMember]
        public string estacion { get; set; }
        [DataMember]
        public string estado { get; set; }
       // [DataMember]
       // public int linea { get; set; }
        [DataMember]
        public string tiempo { get; set; }
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
