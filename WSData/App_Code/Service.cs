using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Collections;
using System.Xml;



public class ServicioData : IService
{ 
    
     string direccion = AppDomain.CurrentDomain.BaseDirectory+"Datos/Datos.xml";  //DIRECCION DEL XML de Lineas, estaciones y Administrador
     string direccion2 = AppDomain.CurrentDomain.BaseDirectory + "Datos/Trasbordos.xml";
   
           

           
    XmlDocument doc = new XmlDocument();
    XmlDocument doc2 = new XmlDocument();


    public bool estadoServicio()
    {
        return true;
    }
    
    public void actualizarLlegadas(string tiempo, string nombreLinea)
    {
        doc.Load(direccion);
        doc.SelectSingleNode("SistemaMetro/Tiempo").InnerText = tiempo;
        doc.Save(direccion);

    }
    public bool verificarUsuario(string usuario, string contraseña)  //MÉTODO BOOLEANO QUE VERIFICA EL ADMINISTRADOR
    {
       
        doc.Load(direccion);
        if(doc.SelectSingleNode("SistemaMetro/Administrador/Nombre").InnerText.Equals(usuario) && doc.SelectSingleNode("SistemaMetro/Administrador/Contraseña").InnerText.Equals(contraseña)) //SE BUSCA EL ADMINISTRADOR
            return true;  //SI SE ENCUENTRA EL ADMINISTRADOR ENTONCES EXISTE
        else
            return false;  //SI NO LO ENCUENTRA ENTONCES NO EXISTE
    }

    public bool crearLinea(string nombreLinea, int trenes, string tipo) //MÉTODO PARA CREAR LINEAS
    {
        if (!buscarLinea(nombreLinea)) // Devuelve true si la linea no existe
        {
            doc.Load(direccion);
            XmlElement elementoLi = doc.CreateElement("Linea");  //SE CREA UN ELEMENTO LINEA
            XmlElement elementoNom = doc.CreateElement("NombreLinea"); //SE CREA UN ELEMENTO NOMBRE LINEA
            XmlElement elementoEst = doc.CreateElement("Estaciones"); //SE CREA UN ELEMENTO DE ESTACIONES
            XmlElement elementoEstado = doc.CreateElement("Estado"); //SE CREA UN ELEMENTO DE ESTADO DE LA LINEA YA SEA OPERATIVA O INOPERATIVA
            XmlElement elementoNumTren = doc.CreateElement("NumeroTrenes"); //SE CREA UN ELEMENTO DE NUMERO DE TRENES DE LA LINEA
            XmlElement elementoTipo = doc.CreateElement("TipoLinea");//SE CREA UN ELEMENTO DE TIPO DE LA LINEA YA SEA LINEAL O CIRCULAR
            elementoNom.InnerText = nombreLinea;//SE LE ASIGNA UN NOMBRE AL ELEMENTO NOMBRE
            elementoEst.InnerText = "";//SE LE ASIGNA UNA ESTACION NULA
            elementoEstado.InnerText = "true";//SE LE ASIGNA LA OPERATIVIDAD
            elementoNumTren.InnerText = trenes.ToString();//SE LE ASIGNA EL NUMERO DE TRENES
            elementoTipo.InnerText = tipo;//SE LE ASIGNA EL TIPO DE LA LINEA
            elementoLi.AppendChild(elementoNom);//SE LE AÑADE EL ELEMENTO NOMBRE LINEA AL ELEMENTO LINEA
            elementoLi.AppendChild(elementoEst);////SE LE AÑADE EL ELEMENTO ESTACIÓN AL ELEMENTO LINEA
            elementoLi.AppendChild(elementoEstado);//SE LE AÑADE EL ELEMENTO ESTADO AL ELEMENTO LINEA
            elementoLi.AppendChild(elementoNumTren);//SE LE AÑADE EL ELEMENTO NOMBRE LINEA AL ELEMENTO LINEA
            elementoLi.AppendChild(elementoTipo);//SE LE AÑADE EL ELEMENTO TIPO DE LINEA AL ELEMENTO LINEA
            doc.SelectSingleNode("SistemaMetro/Lineas").AppendChild(elementoLi);//SE LE AGREGA AL XML EL ELEMENTO LINEA
            doc.Save(direccion);
            return true;
        }
        else
            return false;
    }

    public bool crearEstacion(string nombreLinea,string nombreEstacion) //CREA LA ESTACION EN LA LINEA DADA EN EL XML
    {
        if (!buscarEstacion(nombreLinea, nombreEstacion)) // DEVUELVE TRUE SI LA ESTACION NO EXISTE EN LA LINEA INDICADA
        {
            doc.Load(direccion);
            XmlElement estacion = doc.CreateElement("Estacion");
            XmlElement estado = doc.CreateElement("Estado");
            XmlElement nombre = doc.CreateElement("NombreEstacion");
            estado.InnerText = "true";
            nombre.InnerText = nombreEstacion;
            estacion.AppendChild(nombre);
            estacion.AppendChild(estado);
            XmlNodeList lista = doc.SelectSingleNode("SistemaMetro/Lineas").ChildNodes;
            foreach (XmlNode nodo in lista)//PARA CADA NODO DE LA LISTA APLICA LO SIGUENTE
            {
                if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))//SI EL NOMBRE DE LA LINEA ES IGUAL AL NOMBRE DE LA LINEA QUE INGRESO EL USUARIO REALIZA LO SIGUIENTE
                {
                    nodo.SelectSingleNode("Estaciones").AppendChild(estacion);//AGREGA EL NOMBRE DE LA ESTACION
                    doc.Save(direccion);
                   
                }
            }
            return true;
        }
        else
            return false;

    }

    public bool modificarLinea(string nombreLinea, string nuevoNombre, int trenes, string tipo)//PROCESO QUE MODIFICA EL NOMBRE, NUMERO DE TRENES Y TIPO DE LINEAS
    {
       
        doc.Load(direccion);
        XmlNodeList lista = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))//COMPRUEBA SI ALGUNA DE LAS LINEAS COINCIDE CON EL NOMBRE DADO
            {
                nodo.SelectSingleNode("NombreLinea").InnerText = nuevoNombre;//LE ASIGNA EL NUEVO NOMBRE
                nodo.SelectSingleNode("NumeroTrenes").InnerText = trenes.ToString();//SE LE ASIGNA LOS NUEVOS NUMEROS DE TRENES
                nodo.SelectSingleNode("TipoLinea").InnerText = tipo;//SE LE ASINA EL NUEVO TIPO
                doc.Save(direccion);
                return true;
            }
        }
        return false;
    }

    public bool modificarEstacion(string nombreLinea, string nombreEstacion, string nuevaEstacion)//PROCESO QUE MODIFICA LA ESTACIÓN
    {
      
        doc.Load(direccion);
        XmlNodeList lista = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))//COMPRUEBA SI EXISTE ALGUNA LINEA COINCIDE CON EL NOMBRE DE LA LINEA DADO
            {
                XmlNodeList lista2 = nodo.SelectNodes("Estaciones/Estacion");
                foreach(XmlNode nodo1 in lista2)
                {
                    if(nodo1.SelectSingleNode("NombreEstacion").InnerText.Equals(nombreEstacion))//COMPRUEBA SI EXISTE ALGUNA ESTACION QUE COINCIDA CON EL NOMBRE DE LA ESTACION DADA
                    {
                        nodo1.SelectSingleNode("NombreEstacion").InnerText = nuevaEstacion;//SE LE ASIGNA EL NUEVO NOMBRE
                        doc.Save(direccion);
                        return true;
                    }
                }
            }
        }
        return false;
    }

    public bool modificarEstadoLinea(string nombreLinea)//PROCESO QUE MODIFICA EL ESTADO DE LA LINEA
    {
        doc.Load(direccion);
        XmlNodeList lista1 = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo1 in lista1)
        {
            if (nodo1.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))
            {
                XmlNodeList lista2 = nodo1.SelectNodes("Estaciones/Estacion");
                if (lista2.Count == 0) //Si la linea no contiene estaciones
                    return false;
                if (nodo1.SelectSingleNode("Estado").InnerText.Equals("true"))//CHEQUEA SI EL ESTADO DE LA LINEA ES OPERATIVA
                {
                    foreach (XmlNode nodo2 in lista2)
                    {
                        nodo2.SelectSingleNode("Estado").InnerText = "false";//CAMBIA A INOPERATIVA EL ESTADO
                    }
                    doc.Save(direccion);
                  
                     
                   
                }


                else if (nodo1.SelectSingleNode("Estado").InnerText.Equals("false"))//CHEQUEA SI EL ESTADO DE LA LINEA ES INOPERATIVA
                {
                    foreach (XmlNode nodo2 in lista2)
                    {
                        nodo2.SelectSingleNode("Estado").InnerText = "true";//CAMBIA A OPERATIVA EL ESTADO
                    }
                    doc.Save(direccion);
                   
                     
                    

                }
               
               
            }
        }
        return true;
    }

    public void verificarEstadoLinea() // si todas las estaciones de la linea se encuentran inoperativas entonces la linea tambien
    {
        int i;
        doc.Load(direccion);
        XmlNodeList lista1 = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo1 in lista1)
        {
            i = 0;
          
                XmlNodeList lista2 = nodo1.SelectNodes("Estaciones/Estacion");
                foreach (XmlNode nodo2 in lista2)
                {
                    if (nodo2.SelectSingleNode("Estado").InnerText.Equals("false"))
                    {
                        i = i + 1;
                    }
                   
                }
                if (lista2.Count == i)
                {
                    nodo1.SelectSingleNode("Estado").InnerText = "false";
                    
                }
                else
                {
                    nodo1.SelectSingleNode("Estado").InnerText = "true";
                   
                }
            
        }
        doc.Save(direccion);
       
      

    }

    public bool modificarEstadoEstacion(string nombreEstacion) // que sea general por el nombre
    {
        doc.Load(direccion);

        XmlNodeList lista = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        if (lista.Count != 0)
        {
            foreach (XmlNode nodo in lista)
            {
               
                XmlNodeList lista2 = nodo.SelectNodes("Estaciones/Estacion");
                foreach (XmlNode nodo1 in lista2)
                {
                    if (nodo1.SelectSingleNode("NombreEstacion").InnerText.Equals(nombreEstacion))
                    {
                        
                        if (nodo1.SelectSingleNode("Estado").InnerText.Equals("true"))//CHEQUEA SI EL ESTADO DE LA ESTACION ES OPERATIVA
                        {
                            nodo1.SelectSingleNode("Estado").InnerText = "false";//LE ASIGNA INOPERATIVA
                            doc.Save(direccion);
                           
                        }
                        else if (nodo1.SelectSingleNode("Estado").InnerText.Equals("false"))//CHEQUEA SI EL ESTADO DE LA ESTACION ES INOPERATIVA
                        {
                            nodo1.SelectSingleNode("Estado").InnerText = "true";//LE ASIGNA OPERATIVA
                            doc.Save(direccion);
                        }
                      

                    }
                 
                }
                
            }
           
            return true;
        }
        else
            return false;
    }

    public bool eliminarLinea(string nombreLinea)//ELIMINA LA LINEA DESEADA
    {
       
        doc.Load(direccion);
        XmlNodeList lista = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))//REVISA SI EXISTE ALGUNA LINEA QUE COINCIDA CON EL NOMBRE DADO
            {
                nodo.ParentNode.RemoveChild(nodo);//ELIMINA LA LINEA
                doc.Save(direccion);
                return true;
            }
        }
        return false;
    }

    public bool eliminarEstacion(string nombreLinea, string nombreEstacion)//ELIMINA LA ESTACIÓN DESEADA
    {
        
        doc.Load(direccion);
        XmlNodeList lista = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo in lista)
        {
          if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))
          {
            XmlNodeList lista2 = nodo.SelectNodes("Estaciones/Estacion");
            foreach (XmlNode nodo1 in lista2)
            {
                if(nodo1.SelectSingleNode("NombreEstacion").InnerText.Equals(nombreEstacion))
                {
                    nodo1.ParentNode.RemoveChild(nodo1);//ELIMINA LA ESTACION
                    doc.Save(direccion);
                   
                    return true;
                }
            }
          }
        }
        return false;
    }

    public bool buscarLinea(string nombreLinea) //Comprueba si la linea ya existe
    {
       
        doc.Load(direccion);
        XmlNodeList lista = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))
                return true;//DEVUELVE TRUE SI ENCUENTRA LA LINEA
        }
        return false;
    }

    public bool buscarEstacion(string nombreLinea, string nombreEstacion)//COMPRUEBA SI LA ESTACION YA EXISTE
    {
        doc.Load(direccion);
        XmlNodeList lista = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))
            {
                XmlNodeList lista2 = nodo.SelectNodes("Estaciones/Estacion");
                foreach (XmlNode nodo1 in lista2)
                {
                    if (nodo1.SelectSingleNode("NombreEstacion").InnerText.Equals(nombreEstacion))
                        return true;//DEVUELVE TRUE SI ENCUENTRA LA ESTACION
                }
            }
        }
        return false;
    }
  

   public List<Linea> generarListaLinea()//METODO QUE GENERA LINEAS
   {
       doc.Load(direccion);
       List<Linea> lineas = new List<Linea>();

       XmlNodeList lista = doc.SelectNodes("SistemaMetro/Lineas/Linea");

       foreach (XmlNode nodo in lista)
       {
           Linea linea = new Linea(nodo.SelectSingleNode("NombreLinea").InnerText, nodo.SelectSingleNode("Estado").InnerText, int.Parse(nodo.SelectSingleNode("NumeroTrenes").InnerText), nodo.SelectSingleNode("TipoLinea").InnerText);//SE GENERA LA LINEA
           lineas.Add(linea);

       }
       return lineas;
   }

   public List<Estacion> generarListaEstaciones(string nombreLinea)//GENERA ESTACIONES
   {

       doc.Load(direccion);
       List<Estacion> estaciones = new List<Estacion>();
       XmlNodeList lista1 = doc.SelectNodes("SistemaMetro/Lineas/Linea");
       foreach (XmlNode nodo1 in lista1)
       {
           if (nodo1.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))
           {
               XmlNodeList lista2 = nodo1.SelectNodes("Estaciones/Estacion");
               foreach (XmlNode nodo2 in lista2)
               {
                   Estacion estacion = new Estacion(nodo2.SelectSingleNode("NombreEstacion").InnerText, nodo2.SelectSingleNode("Estado").InnerText);
                   estaciones.Add(estacion);
               }
               
           }
          
       }
       return estaciones;
   }

    public Linea obtenerLinea(string nombreLinea)//OBTIENE LINEAS
   {
        doc.Load(direccion);
        XmlNodeList Lineas = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo in Lineas)
        {
            if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))
            {
                Linea linea = new Linea(nodo.SelectSingleNode("NombreLinea").InnerText, nodo.SelectSingleNode("Estado").InnerText, int.Parse(nodo.SelectSingleNode("NumeroTrenes").InnerText), nodo.SelectSingleNode("TipoLinea").InnerText);
                return linea;
            }
           
        }

        return null;
    }

    public Estacion obtenerEstacion(string nombreLinea, string nombreEstacion)//OBTENER ESTACIONES
    {
        doc.Load(direccion);
        XmlNodeList Lineas = doc.SelectNodes("SistemaMetro/Lineas/Linea");
        foreach (XmlNode nodo1 in Lineas)
        {
            if (nodo1.SelectSingleNode("NombreLinea").InnerText.Equals(nombreLinea))
            {
                XmlNodeList estaciones = nodo1.SelectNodes("Estaciones/Estacion");
                foreach (XmlNode nodo2 in estaciones)
                {
                    if (nodo2.SelectSingleNode("NombreEstacion").InnerText.Equals(nombreEstacion))
                    {
                        Estacion estacion = new Estacion(nodo2.SelectSingleNode("NombreEstacion").InnerText, nodo2.SelectSingleNode("Estado").InnerText);
                        return estacion;
                    }
                }
            }
        }
        return null;
    }

    public bool crearTrasbordoSimple(string estacion, List<string> lineas)//CREA TRASBORDOS SIMPLES
    {
        if (comprobarTrasbordoSimple(estacion))//DEVUELVE TRUE SI YA EXISTE
            return false;

        doc2.Load(direccion2);       
        XmlElement elementTrasbordoS = doc2.CreateElement("TrasbordoS");
        XmlElement elementEst = doc2.CreateElement("NombreEstacion");
        elementEst.InnerText = estacion;
        XmlElement elementLineas = doc2.CreateElement("Lineas");
        elementLineas.InnerText = "";
        foreach (string linea in lineas)
        {
            XmlElement elementLinea = doc2.CreateElement("Linea");
            XmlElement elementNomLinea = doc2.CreateElement("NombreLinea");
            elementNomLinea.InnerText = linea;
            elementLinea.AppendChild(elementNomLinea);
            elementLineas.AppendChild(elementLinea);
            crearEstacion(linea, estacion);
          
        }
        elementTrasbordoS.AppendChild(elementLineas);
        elementTrasbordoS.AppendChild(elementEst);
        doc2.SelectSingleNode("Trasbordos/Simples").AppendChild(elementTrasbordoS);//AÑADE EL TRASBORDO AL DOCUMENTO
        doc2.Save(direccion2);
       
       
        return true;
    }

    public bool crearTrasbordoDoble(string linea1, string estacion1, string linea2, string estacion2)//CREA TRASBORDOS DOBLES
    {
        if (comprobarTrasbordoDoble(estacion1, estacion2))//DEVUELVE TRUE SI YA EXISTE
            return false;

        doc2.Load(direccion2);
        XmlElement elementTrasbordoD = doc2.CreateElement("TrasbordoD");
        XmlElement elementLinea1 = doc2.CreateElement("Linea1");
        XmlElement elementLinea2 = doc2.CreateElement("Linea2");
        XmlElement elementEstacion1 = doc2.CreateElement("Estacion1");
        XmlElement elementEstacion2 = doc2.CreateElement("Estacion2");
        elementLinea1.InnerText = linea1;
        elementLinea2.InnerText = linea2;
        elementEstacion1.InnerText = estacion1;
        elementEstacion2.InnerText = estacion2;
        elementTrasbordoD.AppendChild(elementLinea1);
        elementTrasbordoD.AppendChild(elementLinea2);
        elementTrasbordoD.AppendChild(elementEstacion1);
        elementTrasbordoD.AppendChild(elementEstacion2);
        doc2.SelectSingleNode("Trasbordos/Dobles").AppendChild(elementTrasbordoD);//AÑADE EL TRASBORDO AL DOCUMENTO
        doc2.Save(direccion2);
        return true;
    }

    public bool eliminarTrasbordoGeneral(string linea, string estacion)//ELIMINA EL TRASBBORDO BUSCANDO SI ES SIMPLE O DOBLE
    {
        doc2.Load(direccion2);
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Simples/TrasbordoS");
        bool resultado = false;
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreEstacion").InnerText.Equals(estacion))
            {
                XmlNodeList lineas = nodo.SelectNodes("Lineas/Linea");
                foreach (XmlNode nodo2 in lineas)
                {
                    if (nodo2.SelectSingleNode("NombreLinea").InnerText.Equals(linea))
                    {
                        nodo2.ParentNode.RemoveChild(nodo2);
                        doc2.Save(direccion2);
                        resultado = true;
                    }
                }

                lineas = nodo.SelectNodes("Lineas/Linea");
                if (lineas.Count < 2)
                {
                    nodo.ParentNode.RemoveChild(nodo);
                    doc2.Save(direccion2);

                }
            }
           
        }
        XmlNodeList lista2 = doc2.SelectNodes("Trasbordos/Dobles/TrasbordoD");
        foreach (XmlNode nodo1 in lista2)
        {
            if ((nodo1.SelectSingleNode("Estacion1").InnerText.Equals(estacion) && nodo1.SelectSingleNode("Linea1").InnerText.Equals(linea)) || (nodo1.SelectSingleNode("Estacion2").InnerText.Equals(estacion) && nodo1.SelectSingleNode("Linea2").InnerText.Equals(linea)))
            {
                nodo1.ParentNode.RemoveChild(nodo1);
                doc2.Save(direccion2);
                resultado = true;
            }
        }

        return resultado;
    }

    public bool eliminarTrasbordoLineasGeneral(string linea)//ELIMINA EL TRASBORDO YA SEA SIMPLE O GENERAL PERO BUSCANDOLO POR LINEAS
    {
        doc2.Load(direccion2);
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Simples/TrasbordoS");
        bool resultado = false;
        foreach (XmlNode nodo in lista)
        {
            XmlNodeList lista1 = nodo.SelectNodes("Lineas/Linea");
            foreach (XmlNode nodo1 in lista1)
            {
                if (nodo1.SelectSingleNode("NombreLinea").InnerText.Equals(linea))
                {
                    nodo1.ParentNode.RemoveChild(nodo1);
                    doc2.Save(direccion2);
                    resultado = true;
                }
            }
            lista1 = nodo.SelectNodes("Lineas/Linea");
            if (lista1.Count < 2)
            {
                nodo.ParentNode.RemoveChild(nodo);
                doc2.Save(direccion2);

            }
        }
        XmlNodeList lista2 = doc2.SelectNodes("Trasbordos/Dobles/TrasbordoD");
        foreach (XmlNode nodo2 in lista2)
        {
            if ((nodo2.SelectSingleNode("Linea1").InnerText.Equals(linea)) || (nodo2.SelectSingleNode("Linea2").InnerText.Equals(linea)))
            {
                nodo2.ParentNode.RemoveChild(nodo2);
                doc2.Save(direccion2);
                resultado = true;
            }
        }

        return resultado;

    }




    public bool eliminarTrasbordoSimple(string estacion)//ELIMINA EL TRASBORDO SIMPLE
    {
        doc2.Load(direccion2);
        doc.Load(direccion);
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Simples/TrasbordoS");
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreEstacion").InnerText.Equals(estacion)) 
            {
                
                XmlNodeList lineas = nodo.SelectNodes("Lineas/Linea");
                foreach (XmlNode nodo2 in lineas)
                {
                    eliminarEstacion(nodo2.SelectSingleNode("NombreLinea").InnerText, estacion);
                }
                nodo.ParentNode.RemoveChild(nodo);
                doc2.Save(direccion2);
                doc.Save(direccion);
            
                return true;
            }
        }
        return false;
    }


    public bool modificarTrasbordoGeneralEstacion(string estacion, string nuevaEstacion)//MODIFICA EL TRASBORDO YA SEA SIMPLE O DOBLE
    {
        doc.Load(direccion);
        doc2.Load(direccion2);
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Simples/TrasbordoS");
        bool resultado = false, ts = false;
        foreach (XmlNode nodo in lista) //Recorre los trasbordos simples y cambia el nombre de la estacion correspondiente
        {
            if (nodo.SelectSingleNode("NombreEstacion").InnerText.Equals(estacion))
            {
                nodo.SelectSingleNode("NombreEstacion").InnerText = nuevaEstacion;
                doc2.Save(direccion2);
                ts = true;
                resultado = true;
            }
        }
        XmlNodeList lista2 = doc2.SelectNodes("Trasbordos/Dobles/TrasbordoD");//Recorre los trasbordos dobles y cambia el nombre de la estacion correspondiente
        foreach (XmlNode nodo2 in lista2)
        {
            if (nodo2.SelectSingleNode("Estacion1").InnerText.Equals(estacion))
            {
                nodo2.SelectSingleNode("Estacion1").InnerText = nuevaEstacion;
                doc2.Save(direccion2);
                resultado = true;
            }
            else
                if (nodo2.SelectSingleNode("Estacion2").InnerText.Equals(estacion))
                {
                    nodo2.SelectSingleNode("Estacion2").InnerText = nuevaEstacion;
                    doc2.Save(direccion2);
                    resultado = true;
                }
        }
        if (ts) //Si se ha cambiado el nombre de alguna estacion de trasbordo simple, se cambia el nombre de la estacion correspondiente en el Xml de las estaciones
        {
            XmlNodeList lista3 = doc.SelectNodes("SistemaMetro/Lineas/Linea");
            foreach (XmlNode nodo3 in lista3)
            {
                XmlNodeList lista4 = nodo3.SelectNodes("Estaciones/Estacion");
                foreach (XmlNode nodo4 in lista4)
                {
                    if (nodo4.SelectSingleNode("NombreEstacion").InnerText.Equals(estacion))
                    {
                        nodo4.SelectSingleNode("NombreEstacion").InnerText = nuevaEstacion;

                    }
                }
            }
            doc.Save(direccion);
        }
        return resultado;
    }

    public List<TrasbordoDoble> generarListaTrasbordoD()//GENERA TRASBORDOS DOBLES
    {
        doc2.Load(direccion2);
        List<TrasbordoDoble> trasbordoD = new List<TrasbordoDoble>();
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Dobles/TrasbordoD");
        foreach (XmlNode nodo in lista)
        {
            TrasbordoDoble tras = new TrasbordoDoble(nodo.SelectSingleNode("Linea1").InnerText, nodo.SelectSingleNode("Estacion1").InnerText, nodo.SelectSingleNode("Linea2").InnerText, nodo.SelectSingleNode("Estacion2").InnerText);
            trasbordoD.Add(tras);
        }
        return trasbordoD;
    }

    public bool modificarTrasbordoGeneralLinea(string linea, string nuevaLinea) //MODIFIFCA TRASBORDOS YA SEA SIMPLE O DOBLE PERO BUSCANDOLO POR LINEAS
    {
        doc2.Load(direccion2);
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Simples/TrasbordoS/Lineas/Linea");
        bool resultado = false;
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreLinea").InnerText.Equals(linea))
            {
                nodo.SelectSingleNode("NombreLinea").InnerText = nuevaLinea;
                doc2.Save(direccion2);
                resultado = true;
            }
        }
        XmlNodeList lista2 = doc2.SelectNodes("Trasbordos/Dobles/TrasbordoD");
        foreach (XmlNode nodo1 in lista2)
        {
            if (nodo1.SelectSingleNode("Linea1").InnerText.Equals(linea))
            {
                nodo1.SelectSingleNode("Linea1").InnerText = nuevaLinea;
                doc2.Save(direccion2);
                resultado = true;
            }
            else
                if (nodo1.SelectSingleNode("Linea2").InnerText.Equals(linea))
                {
                    nodo1.SelectSingleNode("Linea2").InnerText = nuevaLinea;
                    doc2.Save(direccion2);
                    resultado = true;
                }
        }
        return resultado;
    }
    public bool comprobarTrasbordoSimple(string estacion)//COMPRUEBA SI EXISTE EL TRASBORDO SIMPLE
    {
        doc2.Load(direccion2);
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Simples/TrasbordoS");
        foreach (XmlNode nodo in lista)
        {
            if (nodo.SelectSingleNode("NombreEstacion").InnerText.Equals(estacion))
            {
                return true;
            }
        }
        return false;
    }

    public bool comprobarTrasbordoDoble(string estacion1, string estacion2)//COMPRUEBA EL TRASBORDO DOBLE
    {
        doc2.Load(direccion2);
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Dobles/TrasbordoD");
        foreach (XmlNode nodo in lista)
        {
            if ((nodo.SelectSingleNode("Estacion1").InnerText.Equals(estacion1) && nodo.SelectSingleNode("Estacion2").InnerText.Equals(estacion2)) ||( nodo.SelectSingleNode("Estacion1").InnerText.Equals(estacion2) && nodo.SelectSingleNode("Estacion2").InnerText.Equals(estacion1)))
            {
                return true;
            }
        }
        return false;
    }
    public List<TrasbordoSimple> generarListaTrasbordoS()//GENERA TRASBORDOS SIMPLES
    {
        doc2.Load(direccion2);
        List<TrasbordoSimple> trasbordoS = new List<TrasbordoSimple>();
       
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Simples/TrasbordoS");
        foreach (XmlNode nodo in lista)
        {
            TrasbordoSimple tras = new TrasbordoSimple(nodo.SelectSingleNode("NombreEstacion").InnerText);
            List<string> listaLineas = new List<string>();
            XmlNodeList lineas = nodo.SelectNodes("Lineas/Linea");
            foreach (XmlNode nodo2 in lineas)
            {
             listaLineas.Add(nodo2.SelectSingleNode("NombreLinea").InnerText);  
            }
            tras.lineas = listaLineas;
            trasbordoS.Add(tras);
        }
        
            return trasbordoS;
    }

    public bool eliminarTrasbordoDoble(string estacion1, string estacion2)//ELIMINA TRASBORDOS DOBLES
    {
        
        doc2.Load(direccion2);
        XmlNodeList lista = doc2.SelectNodes("Trasbordos/Dobles/TrasbordoD");
        foreach (XmlNode nodo in lista)
        {
            if (((nodo.SelectSingleNode("Estacion1").InnerText.Equals(estacion1) && nodo.SelectSingleNode("Estacion2").InnerText.Equals(estacion2))) || ((nodo.SelectSingleNode("Estacion1").InnerText.Equals(estacion2) && nodo.SelectSingleNode("Estacion2").InnerText.Equals(estacion1))))
            {
                nodo.ParentNode.RemoveChild(nodo);
                doc2.Save(direccion2);
                return true;
            }
        }
        return false;
    }

    public Administrador obtenerAdministrador() //Obtiene las credenciales del administrador del sistema
    {
        doc.Load(direccion);
        XmlNode administrador = doc.SelectSingleNode("SistemaMetro/Administrador");
        Administrador admin = new Administrador(administrador.SelectSingleNode("Nombre").InnerText, administrador.SelectSingleNode("Contraseña").InnerText);
        return admin;
    }

    public void modificarAdministrador(string username, string password)//MODIFICA LOS DATOS DEL ADMINISTRADOR
    {
        doc.Load(direccion);
        XmlNode administrador = doc.SelectSingleNode("SistemaMetro/Administrador");
        administrador.SelectSingleNode("Nombre").InnerText = username;
        administrador.SelectSingleNode("Contraseña").InnerText = password;
        doc.Save(direccion);
    }

  
}
