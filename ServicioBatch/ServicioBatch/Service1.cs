using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Timers;
using System.ServiceModel;
namespace ServicioBatch
{
    public partial class Service1 : ServiceBase
    {
        Timer timer;
        public Service1()
        {
            InitializeComponent();
           
        }

        protected override void OnStart(string[] args)
        {
            llamadaWebService();
            timer = new Timer();
            timer.Interval = 60000 * 2; // 1 minutos  
            timer.Elapsed += new ElapsedEventHandler(timerElapsed);
            timer.Enabled = true;
        }

        protected override void OnStop()
        {
        }

        void timerElapsed(object sender, ElapsedEventArgs e)
        {
            timer.Enabled = false;
            llamadaWebService();
            timer.Enabled = true;
        }

        void llamadaWebService()
        {
            try
            {
                ServicioData.ServiceClient cliente = new ServicioData.ServiceClient();
                bool estado;
                DateTime tIni;
                estado = cliente.estadoServicio();
                if (estado == true)
                {
                    tIni = DateTime.Now;
                    tIni = tIni.AddMinutes(2);
                    List<ServicioData.Linea> lineas = cliente.generarListaLinea().ToList();
                    foreach (ServicioData.Linea linea in lineas)
                    {
                        try
                        {

                            cliente = new ServicioData.ServiceClient();
                            cliente.actualizarLlegadas(tIni.ToShortTimeString(), linea.nombre);
                            cliente.Close();
                        }
                        catch (FaultException)
                        {
                            cliente.Abort();
                        }
                        catch (CommunicationException)
                        {
                            cliente.Abort();
                        }
                        catch (System.TimeoutException)
                        {
                            cliente.Abort();
                        }

                    }
                }


            }
            catch
            {

            }
        }
    }
}
