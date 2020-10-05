using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Collections;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

// NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
public class Service : IService
{
    //ObtenerConexion()
    public MySqlConnectionStringBuilder obtenerConexion()
    {
        MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
        builder.Server = "localhost";
        builder.UserID = "root";
        builder.Password = "acmilan1997";
        builder.Database = "ucabline";
        return (builder);
    }

    //Estado Servicio

    public bool estadoServicio()
    {
        return true;
    }

    //Insertar Linea

    public bool crearLinea(string nombreLinea, string estado, int trenes, string tipo)
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        //if (!buscarLinea(nombreLinea))
        //{
            cmd.CommandText = "INSERT INTO lineas (Linea,Estado,Trenes,Tipo) value (@Linea,@Estado,@Trenes,@Tipo)";
            cmd.Parameters.AddWithValue("@Linea", nombreLinea);
            cmd.Parameters.AddWithValue("@Estado", estado);
            cmd.Parameters.AddWithValue("@Trenes", trenes);
            cmd.Parameters.AddWithValue("@Tipo", tipo);
            cmd.ExecuteNonQuery();

            return true;
        //}
        //return false;
    }

    //Insertar Estacion

    public bool crearEstacion(string estacion, string estado, string tiempo , string nombreLinea)
    {
        int idLinea;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT idLinea FROM lineas WHERE Linea='"+ nombreLinea +"'";
         MySqlDataReader reader = cmd.ExecuteReader();
         if (reader.Read())
         {
             idLinea = (int)reader["idLinea"];
             reader.Close();
             cmd.CommandText = "INSERT INTO estaciones (Estacion,Estado,idLinea,Tiempo) value (@Estacion,@Estado,@idLinea,@Tiempo)";
             cmd.Parameters.AddWithValue("@Estacion", estacion);
             cmd.Parameters.AddWithValue("@Estado", estado);
             cmd.Parameters.AddWithValue("@idLinea", idLinea);
             cmd.Parameters.AddWithValue("@Tiempo", tiempo);
             try
             {
                 cmd.ExecuteNonQuery();
             }
             catch
             {
                 return false;
             }
             return true;
         }
         return false;
    }

    //Eliminar Linea

    public bool eliminarLinea(string nombreLinea)
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "DELETE FROM lineas WHERE Linea='" + nombreLinea + "'";
        //cmd.Parameters.AddWithValue("@Linea", nombreLinea);
        //cmd.Parameters.AddWithValue("@Estado", estado);
        //cmd.Parameters.AddWithValue("@Trenes", trenes);
        //cmd.Parameters.AddWithValue("@Tipo", tipo);
        cmd.ExecuteNonQuery();

        return true;
    }

    //Eliminar Estaciones

    public bool eliminarEstacion(string estacion)
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "DELETE FROM estaciones WHERE Estacion='" + estacion + "'";
        //cmd.Parameters.AddWithValue("@Estacion", estacion);
        //cmd.Parameters.AddWithValue("@Estado", estado);
        //cmd.Parameters.AddWithValue("@idLinea", idLinea);
        //cmd.Parameters.AddWithValue("@Tiempo", tiempo);
        cmd.ExecuteNonQuery();
        return true;
    }

    //Modificar Linea (NOMBRE, TRENES, TIPO)

    public bool modificarLinea(string nombreLinea, int trenes, string tipo, string buscaLinea)
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "UPDATE lineas SET Linea='" + nombreLinea + "', Trenes='" + trenes + "', Tipo='" + tipo + "' WHERE Linea='" + buscaLinea + "'";
        cmd.Parameters.AddWithValue("@Linea", nombreLinea);
        cmd.Parameters.AddWithValue("@Trenes", trenes);
        cmd.Parameters.AddWithValue("@Tipo", tipo);
        cmd.ExecuteNonQuery();
        return true;
    }


    //Modificar Estacion (NOMBRE, idLINEA, TIEMPO)

    public bool modificarEstacion(string estacion, string tiempo, string buscaEstacion, string nombreLinea)
    {
        int idLinea;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT idLinea FROM lineas WHERE Linea='"+ nombreLinea +"'";
         MySqlDataReader reader = cmd.ExecuteReader();
         if (reader.Read())
         {
             idLinea = (int)reader["idLinea"];
             reader.Close();
             cmd.CommandText = "UPDATE estaciones SET Estacion='" + estacion + "', Tiempo='" + tiempo + "' WHERE Estacion='" + buscaEstacion + "', Linea='"+ idLinea +"'";
             //cmd.Parameters.AddWithValue("@Estacion", estacion);
             //cmd.Parameters.AddWithValue("@idLinea", idLinea);
             //cmd.Parameters.AddWithValue("@Tiempo", tiempo);
             cmd.ExecuteNonQuery();
             return true;
         }
         return false;
    }

    //Modificar Linea (ESTADO) 

    public bool modificarEstadoLinea(string nombreLinea)
    {
        //MySqlConnectionStringBuilder builder = obtenerConexion();
        //MySqlConnection conn = new MySqlConnection(builder.ToString());
        //MySqlCommand cmd = conn.CreateCommand();
        //conn.Open();
        //cmd.CommandText = "UPDATE lineas SET Estado='" + estado + "' WHERE Linea='" + nombreLinea + "'";
        //cmd.Parameters.AddWithValue("@Estado", estado);
        //cmd.ExecuteNonQuery();
        //return true;
        string resultado;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM lineas WHERE Linea='" + nombreLinea + "'";
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            resultado = reader["Estado"].ToString();
            reader.Close();
            if (resultado == "activada")
            {
                //estado = "desactivada";
                cmd.CommandText = "UPDATE lineas SET Estado= 'desactivada' WHERE Linea='" + nombreLinea + "'";
                cmd.ExecuteNonQuery();
            }
            else
            {
                //estado ="activada";
                cmd.CommandText = "UPDATE lineas SET Estado= 'activada' WHERE Linea='" + nombreLinea + "'";
                cmd.ExecuteNonQuery();
            }

            //cmd.CommandText = "UPDATE estaciones SET Estado='" + estado + "' WHERE Estacion='" + estacion + "'";
            //cmd.Parameters.AddWithValue("@Estado", estado);
            //cmd.ExecuteNonQuery();
            return true;
        }
        return false;
    }

    //Modificar Estacion (ESTADO) 

    public bool modificarEstadoEstacion(string estacion)
    {
        string resultado;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM estaciones WHERE Estacion='"+ estacion +"'";
         MySqlDataReader reader = cmd.ExecuteReader();
         if (reader.Read())
         {
             resultado = reader["Estado"].ToString();
             reader.Close();
             if (resultado == "activada")
             {
                 //estado = "desactivada";
                 cmd.CommandText = "UPDATE estaciones SET Estado= 'desactivada' WHERE Estacion='" + estacion + "'";
                 cmd.ExecuteNonQuery();
             }
             else
             {
                 //estado ="activada";
                 cmd.CommandText = "UPDATE estaciones SET Estado= 'activada' WHERE Estacion='" + estacion + "'";
                 cmd.ExecuteNonQuery();
             }
             
             //cmd.CommandText = "UPDATE estaciones SET Estado='" + estado + "' WHERE Estacion='" + estacion + "'";
             //cmd.Parameters.AddWithValue("@Estado", estado);
             //cmd.ExecuteNonQuery();
             return true;
         }
         return false;
    }

    //Buscar Linea PREGUNTAR A FRAN

    //public bool buscarLinea(string nombreLinea)
    //{
    //    string resultado;
    //    MySqlConnectionStringBuilder builder = obtenerConexion();
    //    MySqlConnection conn = new MySqlConnection(builder.ToString());
    //    MySqlCommand cmd = conn.CreateCommand();
    //    conn.Open();
    //    resultado = cmd.CommandText = "SELECT Linea FROM lineas WHERE Linea='"+ nombreLinea +"'";
    //    if (MySql)
    //    {
    //        cmd.ExecuteNonQuery();
    //        return true;
    //    }
        
    //        cmd.ExecuteNonQuery();
    //        return false;
        
        
    //}

    //Buscar Estacion PREGUNTAR A FRAN

    //public bool buscarLinea(string nombreLinea)
    //{

    //    MySqlConnectionStringBuilder builder = obtenerConexion();
    //    MySqlConnection conn = new MySqlConnection(builder.ToString());
    //    MySqlCommand cmd = conn.CreateCommand();
    //    conn.Open();
    //}

    //Insertar Trasbordos Dobles

    public bool crearTrasbordoDoble(string estacion1, string estacion2, string linea1, string linea2)
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "INSERT INTO trasbordosdobles (Estacion1,Estacion2,Linea1,Linea2) value (@Estacion1,@Estacion2,@Linea1,@Linea2)";
        cmd.Parameters.AddWithValue("@Estacion1", estacion1);
        cmd.Parameters.AddWithValue("@Estacion2", estacion2);
        cmd.Parameters.AddWithValue("@Linea1", linea1);
        cmd.Parameters.AddWithValue("@Linea2", linea2);
        cmd.ExecuteNonQuery();
        return true;
    }

    //Eliminar Trasbordos Dobles

    public bool eliminarTrasbordoDoble(string estacion1, string estacion2)
    {
        //int  idTrasbordoD;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "DELETE FROM trasbordosdobles WHERE Estacion1 = '" + estacion1 + "' AND Estacion2 = '" + estacion2 + "'";
        //cmd.CommandText = "DELETE FROM SavedSignInsNew WHERE LastName =@LastName AND FirstName = @FirstName";
        //cmd.CommandText = "DELETE FROM trasbordosdobles WHERE Estacion1='"+ estacion1 +"', Estacion2='"+ estacion2 +"'";
        //cmd.CommandText = "SELECT idTrasbordoD FROM trasbordosdobles WHERE Estacion1='"+ estacion1 +"', Estacion2='"+ estacion2 +"'";
        // MySqlDataReader reader = cmd.ExecuteReader();
        // if (reader.Read())
        // {
        //     idTrasbordoD = (int)reader[" idTrasbordoD"];
        //     reader.Close();
        //     cmd.CommandText = "DELETE FROM trasbordosdobles WHERE idTrasbordoD='" + idTrasbordoD + "'";
            cmd.ExecuteNonQuery();
        return true;
        // }
        // return false;
    }

    //Generar Lista Lineas

    public List<Linea> generarListaLinea()//METODO QUE GENERA LINEAS
    {
        List<Linea> lineas = new List<Linea>();

        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM lineas";
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Linea linea = new Linea(reader["Linea"].ToString(), reader["Estado"].ToString(), (int)reader["Trenes"], reader["Tipo"].ToString());//SE GENERA LA LINEA
            lineas.Add(linea);
        }
        return lineas;
    }

    //Generar Lista Estaciones

    public List<Estacion> generarListaEstaciones()//METODO QUE GENERA Estaciones
    {
        List<Estacion> estaciones = new List<Estacion>();

        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM estaciones";
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Estacion estacion = new Estacion((reader["Estacion"].ToString()), (reader["Estado"].ToString()), (reader["Tiempo"].ToString()));//SE GENERA LA LINEA
            estaciones.Add(estacion);
        }
        return estaciones;
    }

    public Linea obtenerLinea(string nombreLinea)
    {
       

        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM lineas WHERE Linea='"+ nombreLinea +"'";
        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Linea linea = new Linea(reader["Linea"].ToString(), reader["Estado"].ToString(), (int)reader["Trenes"], reader["Tipo"].ToString());
           
            return linea;
        }
        return null;
    }

    public Estacion obtenerEstacion(string nombreLinea, string estacion)
    {
        int idLinea;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT idLinea FROM lineas WHERE Linea='"+ nombreLinea +"'";
         MySqlDataReader reader = cmd.ExecuteReader();
         if (reader.Read())
         {
             idLinea = (int)reader["idLinea"];
             reader.Close();
             cmd.CommandText = "SELECT * FROM estaciones WHERE Estacion='" + estacion + "', idLinea='"+ idLinea +"'";
             reader = cmd.ExecuteReader();

             if (reader.Read())
             {
                 Estacion estac = new Estacion((reader["Estacion"].ToString()), (reader["Estado"].ToString()), (reader["Tiempo"].ToString()));//SE GENERA LA LINEA

                 return estac;
             }
         }
        return null;
     }

    public DataTable llenarTablas(string tipo)
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        
        DataTable tabla = new DataTable("TABLA");
        if (tipo == "Lineas")
        {
            cmd.CommandText = "SELECT Linea, Estado, Trenes, Tipo FROM lineas";
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ad.Fill(tabla);
            return tabla;
        }
        
        //else if (tipo == "TrasbordosSimples")
        //     {
        //         cmd.CommandText = "SELECT Estacion1, Estacion2, Linea1, Linea2 FROM trasbordosdobles";
        //         MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
        //         ad.Fill(tabla);
        //         return tabla;
        //     }
        else if (tipo == "TrasbordosDobles")
        {
            cmd.CommandText = "SELECT Estacion1, Estacion2, Linea1, Linea2 FROM trasbordosdobles";
            MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
            ad.Fill(tabla);
            return tabla;
        }

        return null;
    }
    public DataTable llenarTablas(string tipo, string nombreLinea )
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();

        DataTable tabla = new DataTable("TABLA");
        cmd.CommandText = "SELECT Estacion, Estado, Tiempo FROM lineas";
        MySqlDataAdapter ad = new MySqlDataAdapter(cmd);
        ad.Fill(tabla);
        return tabla;
    }

    public void actualizarLlegadas(string tiempo, string nombreLinea)
    {
        int idLinea;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT idLinea FROM lineas WHERE Linea='" + nombreLinea + "'";
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            idLinea = (int)reader["idLinea"];
            reader.Close();
            cmd.CommandText = "UPDATE estaciones SET Tiempo='" + tiempo + "' WHERE idLinea='" + idLinea + "'";
            cmd.ExecuteNonQuery();
        }

    }

    public List<TrasbordoDoble> generarListaTrasbordoD()
    {
        List<TrasbordoDoble> trasbordoD = new List<TrasbordoDoble>();

        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM trasbordosdobles";
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            TrasbordoDoble td = new TrasbordoDoble(reader["Linea1"].ToString(), reader["Estacion1"].ToString(), reader["Linea2"].ToString(), reader["Estacion2"].ToString());//SE GENERA LA LINEA
            trasbordoD.Add(td);
        }
        return trasbordoD;
    }

    public Administrador obtenerAdministrador()
    {

        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM administradores";
        MySqlDataReader reader = cmd.ExecuteReader();

        if (reader.Read())
        {
            Administrador admin = new Administrador(reader["Username"].ToString(), reader["Password"].ToString());

            return admin;
        }
        return null;
    }

    public void modificarAdministrador(string usuario, string contraseña)//MODIFICA LOS DATOS DEL ADMINISTRADOR
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "UPDATE administradores SET Usurio='" + usuario + "', Contraseña='"+ contraseña +"'";
        cmd.ExecuteNonQuery();
    }

    public bool crearTrasbordoSimple(string estacion, List<string> lineas)
    {
        int idLinea;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        foreach (string linea in lineas)
        {
            cmd.CommandText = "SELECT idLinea FROM lineas WHERE Linea='" + linea + "'";
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                idLinea = (int)reader["idLinea"];
                reader.Close();
                cmd.CommandText = "INSERT INTO trasbordossimples (Estacion,idLinea) value ('"+ estacion +"','"+ idLinea +"')";
                cmd.ExecuteNonQuery();
                
            }
        }
        return true;
    }

    public bool eliminarTrasbordoSimple(string estacion)
    {
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "DELETE FROM trasbordossimples WHERE Estacion = '" + estacion + "'";
        cmd.ExecuteNonQuery();
        return true;
    }

    public List<TrasbordoSimple> generarListaTrasbordoS()
    {
        List<TrasbordoSimple> trasbordoS = new List<TrasbordoSimple>();

        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT * FROM trasbordossimples";
        MySqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            TrasbordoSimple ts = new TrasbordoSimple(reader["Estacion"].ToString());//SE GENERA LA LINEA
            trasbordoS.Add(ts);
        }
        return trasbordoS;
    }

    //public bool verificarUsuario(string usuario, string contraseña)
    //{

    //}

    public void verificarEstadoLinea(string nombreLinea)
    {
        int idLinea;
        string resultado;
        MySqlConnectionStringBuilder builder = obtenerConexion();
        MySqlConnection conn = new MySqlConnection(builder.ToString());
        MySqlCommand cmd = conn.CreateCommand();
        conn.Open();
        cmd.CommandText = "SELECT idLinea FROM lineas WHERE Linea='" + nombreLinea + "'";
        MySqlDataReader reader = cmd.ExecuteReader();
        if (reader.Read())
        {
            idLinea = (int)reader["idLinea"];
            reader.Close();
            cmd.CommandText = "SELECT Estado FROM estaciones WHERE idLinea='" + idLinea + "'";
            MySqlDataReader reader1 = cmd.ExecuteReader();
            while (reader1.Read())
            {
                resultado = reader1["Estado"].ToString();
                reader1.Close();
               
                }

            }
        }
    }

  //  //public void insertLinea(string nombreLinea, string estado, int trenes, string tipo)
  //  //{
  //  //    MySqlConnection connection = new MySqlConnection("Server=127.0.0.1; DataBase=metro; Uid=root; Pwd=acmilan1997");
  //  //    connection.Open();
  //  //    string query = @"insert into lineas (Linea,Estado,Trenes,Tipo) values (?nombreLinea, ?estado, ?trenes, ?tipo)";
  //  //    MySqlCommand comando = new MySqlCommand(query, connection);
  //  //    comando.ExecuteNonQuery();
  //  //    connection.Close();
  //  //}

  //  public void insertLinea()
  //  {
  //      MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
  //      builder.Server = "localhost";
  //      builder.UserID = "root";
  //      builder.Password = "acmilan1997";
  //      builder.Database = "metro";

  //      MySqlConnection conn = new MySqlConnection(builder.ToString());
  //      MySqlCommand cmd = conn.CreateCommand();
  //      cmd.CommandText = "INSERT INTO lineas (Linea,Estado,Trenes,Tipo) values ('Hola', 'actv', 12, 'lien')";
  //      conn.Open();
  //      cmd.ExecuteNonQuery();
  //  }
  //  //public void insertLinea(string nombreLinea, string estado, int trenes, string tipo)
  //  //{
  //  //    //string data = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) VALUES('" + nombreLinea + "', '" + estado + "', " + trenes + ", '" + tipo + "')";

  //  //    // MySqlConnection connect = new MySqlConnection("Provider=MySQLProv;Data Source=sistema_metro; User Id=root; Password=acmilan1997");
  //  //    MySqlConnection connect = new MySqlConnection("Server=127.0.0.1; DataBase=metro; Uid=root; Pwd=acmilan1997");
  //  //    connect.Open(); 
  //  //    MySqlCommand cmd = new MySqlCommand();
  //  //     cmd.CommandText = "INSERT INTO lineas (Linea, Estado, Trenes, Tipo) VALUES('" + nombreLinea + "', '" + estado + "', " + trenes + ", '" + tipo + "')";
  //  //     cmd.Connection = connect; 
  //  //    cmd.ExecuteNonQuery();
  //  //    connect.Close();
  //  //}

  ///*  public void insertEstado(string estacion, string estado, string tiempo)
  //  {
  //      //string data = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) VALUES('" + nombreLinea + "', '" + estado + "', " + trenes + ", '" + tipo + "')";

  //      // MySqlConnection connect = new MySqlConnection("Provider=MySQLProv;Data Source=sistema_metro; User Id=root; Password=acmilan1997");
  //      MySqlConnection connect = new MySqlConnection("Server=127.0.0.1; DataBase=sistema_metro; Uid=root; Pwd=acmilan1997");
  //      connect.Open();
  //      MySqlCommand cmd = new MySqlCommand();
  //      cmd.CommandText = "INSERT INTO estaciones ( estacion, estado, tiempo) VALUES('" + estacion + "', '" + estado + "', " + tiempo + ")";
  //      cmd.Connection = connect;
  //      cmd.ExecuteNonQuery();
  //      connect.Close();
  //  }*/

  //  //public bool crearLinea(string nombreLinea, string estado, int trenes, string tipo) //MÉTODO PARA CREAR LINEAS
  //  //{
  //  //    //MySqlConnection conect = new MySqlConnection("host=localhost;usr=root;password=acmilan1997;db=sistema_metro;"); //Declaro la Base de datos
  //  //    MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997");
  //  //    connect.Open(); //Abro la Base de Datos

  //  //    //string Query = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) values ('" +nombreLinea + "','" + estado + "','" + trenes + "','" + tipo+ "');";
  //  //   // MySqlCommand cmd = new MySqlCommand();
  //  //    MySqlCommand cmd = new MySqlCommand();
  //  //    string insert = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) VALUES('"+ nombreLinea +"', '"+ estado +"', "+ trenes + ", '"+ tipo +"')";
  //  //    cmd.BeginExecuteNonQuery();
  //  //    //cmd.CommandText = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) VALUES(?nombreLinea,?estado,?trenes,?tipo)";
  //  //    //cmd.Parameters.Add("?Linea", MySqlDbType.VarChar).Value = "nombreLinea";
  //  //    //cmd.Parameters.Add("?estado", MySqlDbType.VarChar).Value = "estado";
  //  //    //cmd.Parameters.Add("?Trenes", MySqlDbType.Int32).Value = "trenes";
  //  //    //cmd.Parameters.Add("?tipo", MySqlDbType.VarChar).Value = "tipo";
  //  //   // cmd.ExecuteNonQuery();
  //  //    cmd.;
  //  //    connect.Close();

  //  //    return true;
  //  //}

  // // public bool crearEstacion(string estacion, string estado, TimeSpan tiempo, string nombrelinea)
  // // {
  // //     MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997"); //Declaro la Base de datos
  // //     connect.Open(); //Abro la Base de Datos

  // //     //string Query = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) values ('" +nombreLinea + "','" + estado + "','" + trenes + "','" + tipo+ "');";
  // //     MySqlCommand cmd = new MySqlCommand();
  // //     cmd.CommandText = "INSERT INTO sistema_metro.estaciones(Estacion,Estado,Tiempo,Linea) VALUES(?estacion,?estado,?tiempo,?nombreLinea)";
  // //     cmd.Parameters.Add("?Linea", MySqlDbType.VarChar).Value = "estacion";
  // //     cmd.Parameters.Add("?estado", MySqlDbType.VarChar).Value = "estado";
  // //     cmd.Parameters.Add("?Tiempo", MySqlDbType.Time).Value = "tiempo";
  // //    // cmd.ExecuteNonQuery();

  // //     connect.Close();

  // //     return true;
  // // }

  // // public bool agregarTrasbordoDobles(string estacion1, string estacion2, string linea1, string linea2)
  // // {
  // //     MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997"); //Declaro la Base de datos
  // //     connect.Open(); //Abro la Base de Datos

  // //     //string Query = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) values ('" +nombreLinea + "','" + estado + "','" + trenes + "','" + tipo+ "');";
  // //     MySqlCommand cmd = new MySqlCommand();
  // //     cmd.CommandText = "INSERT INTO sistema_metro.trasbordo doble(Estacion 1,Estacion 2, Linea 1, Linea 2) VALUES(?estacion1,?estacion2,?linea1,?linea2)";
  // //     cmd.Parameters.Add("?Estacion 1", MySqlDbType.VarChar).Value = "estacion1";
  // //     cmd.Parameters.Add("?Estacion 2", MySqlDbType.VarChar).Value = "estacion2";
  // //     cmd.Parameters.Add("?Linea 1", MySqlDbType.VarChar).Value = "linea1";
  // //     cmd.Parameters.Add("?Linea 2", MySqlDbType.VarChar).Value = "linea2";
  // //    // cmd.ExecuteNonQuery();

  // //     connect.Close();

  // //     return true;
  // // }

  // // public bool agregarAdministradores(string usuario, string contraseña)
  // // {
  // //     MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997"); //Declaro la Base de datos
  // //     connect.Open(); //Abro la Base de Datos

  // //     //string Query = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) values ('" +nombreLinea + "','" + estado + "','" + trenes + "','" + tipo+ "');";
  // //     MySqlCommand cmd = new MySqlCommand();
  // //     cmd.CommandText = "INSERT INTO sistema_metro.administrador(Usuario,Contraseña) VALUES(?usuario,?contraseña)";
  // //     cmd.Parameters.Add("?Usuario", MySqlDbType.VarChar).Value = "usuario";
  // //     cmd.Parameters.Add("?Contraseña", MySqlDbType.VarChar).Value = "contraseña";
  // //    // cmd.ExecuteNonQuery();
  // //     connect.Close();
  // //     return true;
  // // }

  // // public bool buscarLinea(string nombreLinea)
  // // {
  // //     MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997");
  // //     connect.Open(); //Abro la Base de Datos

  // //     MySqlCommand cmd = new MySqlCommand();
  // //     cmd.CommandText = "SELECT * FROM lineas(Usuario,Contraseña) WHERE linea='string.nombreLinea'";
  // //     return true;
  // // }

  // // public bool eliminarLinea(string nombreLinea, string estado, int trenes, string tipo)
  // // {
  // //     MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997"); //Declaro la Base de datos
  // //     connect.Open(); //Abro la Base de Datos

  // //     //string Query = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) values ('" +nombreLinea + "','" + estado + "','" + trenes + "','" + tipo+ "');";
  // //     MySqlCommand cmd = new MySqlCommand();
  // //     cmd.CommandText = "SELECT * FROM lineas(Linea, Estado, Trenes, Tipo) WHERE linea= + string.nombreLinea, + string.estado, + int.trenes, + string.tipo";
  // //     cmd.Parameters.Remove("?Linea");
  // //     cmd.Parameters.Remove("?Estado");
  // //     cmd.Parameters.Remove("?Trenes");
  // //     cmd.Parameters.Remove("?Tipo");
  // //     // cmd.ExecuteNonQuery();

  // //     connect.Close();

  // //     return true;
  // // }
  // // //MODELO 1 DE ELIMINACION
  // // public bool eliminarEstacion(string estacion, string estado, TimeSpan tiempo, string nombrelinea)
  // // {
  // //     MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997"); //Declaro la Base de datos
  // //     connect.Open(); //Abro la Base de Datos

  // //     //string Query = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) values ('" +nombreLinea + "','" + estado + "','" + trenes + "','" + tipo+ "');";
  // //     MySqlCommand cmd = new MySqlCommand();
  // //     //cmd.CommandText = "SELECT * FROM estaciones(Estacion, Estado, Tiempo, Linea) WHERE linea= + string.estacion, + string.estado, + int.tiempo, +string.nombrelinea";
  // //     cmd.CommandText = "DELETE FROM sistema_metro.estacion WHERE Estacion='string.estacion' and Estado='string.estado' and Tiempo='string.tiempo' and Linea='string.nombreLinea'";
  // //     //cmd.Parameters.Remove("?Estacion");
  // //     //cmd.Parameters.Remove("?Estado");
  // //     //cmd.Parameters.Remove("?Tiempo");
  // //     //cmd.Parameters.Remove("?Linea");
  // //     // cmd.ExecuteNonQuery();
  // //     connect.Close();

  // //     return true;
  // // }
  // // //MODELO 2 DE ELIMINACION
  // // public bool eliminarTrasbordoDobles(string estacion1, string estacion2, string linea1, string linea2)
  // // {
  // //     MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997"); //Declaro la Base de datos
  // //     connect.Open(); //Abro la Base de Datos

  // //     //string Query = "INSERT INTO sistema_metro.lineas(Linea,Estado,Trenes,Tipo) values ('" +nombreLinea + "','" + estado + "','" + trenes + "','" + tipo+ "');";
  // //     MySqlCommand cmd = new MySqlCommand();
  // //     cmd.CommandText = "SELECT * FROM linea(Linea, Estado, Trenes, Tipo, Linea) WHERE linea= + string.nombreLinea, + string.estado, + int.trenes, + string.tipo, +string.nombrelinea";
  // //     cmd.Parameters.Remove("?Linea");
  // //     cmd.Parameters.Remove("?Estado");
  // //     cmd.Parameters.Remove("?Trenes");
  // //     cmd.Parameters.Remove("?Tipo");
  // //     // cmd.ExecuteNonQuery();

  // //     connect.Close();

  // //     return true;
  // // }

  // // public bool modificarLineaNombre(string nombreLinea, string nuevoNombre)
  // // {
  // //     MySqlConnection connect = new MySqlConnection("datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997"); //Declaro la Base de datos
  // //     connect.Open(); //Abro la Base de Datos
  // //     MySqlCommand cmd = new MySqlCommand();
  // //     cmd.CommandText = "UPDATE sistema_metro.lineas SET Linea='string.nombreLinea' WHERE Linea='string.nuevoNombre'";
  // //     connect.Close();
  // //     return true;
  // // }


  // ///* public bool prueba(string nombreLinea, string estado,string trenes, string tipo)
  // // {
  // //     string MyConnection2 = "datasource = localhost;port = 3306; Initial Catalog = 'sistema_metro'; username = root; password=acmilan1997";
  // //     //This is my insert query in which i am taking input from the user through windows forms  
  // //     string Query = "insert into sistema_metro.lineas(Linea,Estado,Trenes,Tipo) VALUES(?nombreLinea,?estado,?trenes,?tipo)";
  // //     //This is  MySqlConnection here i have created the object and pass my connection string.  
  // //     MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
  // //     //This is command class which will handle the query and connection object.  
  // //     MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
  // //     MySqlDataReader MyReader2;
  // //     MyConn2.Open();
  // //     MyReader2 = MyCommand2.ExecuteReader();     // Here our query will be executed and data saved into the database.  
  // //     while (MyReader2.Read())
  // //     {
  // //     }
  // //     MyConn2.Close();
  // //     return true;
  // // }*/

}