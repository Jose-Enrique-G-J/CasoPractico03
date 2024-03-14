using AutomovilesWsSoap.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AutomovilesWsSoap
{
    /// <summary>
    /// Descripción breve de WebServiceAutomoviles
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class WebServiceAutomoviles : System.Web.Services.WebService
    {

     
        [WebMethod(Description = "Listar Automoviles")]
        public List<Automovile> Listar_Automoviles()
        {
            using (var conexion = new ModeloAutomoviles())
            {
                var consulta = (from c in conexion.Automoviles select c).ToList();
                return consulta;

            }

        }



        [WebMethod(Description = "Insertar Automovil")]
        public string Insertar_Automovil(string imagen, string marca, string modelo, int year, int precio)
        {
            using (var conexion = new ModeloAutomoviles())
            {
                try
                {
                    Automovile nuevo = new Automovile();
                    nuevo.Imagen = imagen;
                    nuevo.Marca = marca;
                    nuevo.Modelo = modelo;
                    nuevo.Año = year;
                    nuevo.Precio= precio;
                    nuevo.Fecha_creacion = DateTime.Now;
                    conexion.Automoviles.Add(nuevo);
                    conexion.SaveChanges();
                    return "Datos insertados con exito";

                }
                catch (Exception)
                {
                    return "Error, no fue posible insertar los dados del automovil";
                }

            }
        }

        [WebMethod(Description = "Modificar datos del automovil")]
        public string Modificar_Automovil(int id, string imagen, string marca, string modelo, int year, int precio)
        {
            using (var conexion = new ModeloAutomoviles())
            {
                var consulta = (from c in conexion.Automoviles
                                where c.Id == id
                                select c).FirstOrDefault();
                if (consulta != null)
                {
                    consulta.Imagen = imagen;
                    consulta.Marca = marca;
                    consulta.Modelo= modelo;
                    consulta.Año = year;
                    consulta.Precio = precio;
                    consulta.Fecha_creacion = DateTime.Now;
                    conexion.SaveChanges();

                    return "Datos modificados con exito";
                }
                else
                {
                    return "Error, no fue posible modificar los dados del automovil";
                }
            }

        }

        [WebMethod(Description = "Eliminar Automovil")]
        public string Eliminar_Automovil(int id)
        {
            using (var conexion = new ModeloAutomoviles())
            {
                var consulta = (from c in conexion.Automoviles
                                where c.Id == id
                                select c).FirstOrDefault();
                if (consulta != null)
                {
                    conexion.Automoviles.Remove(consulta);
                    conexion.SaveChanges();
                    return "Automovil eliminado con exito";
                }
                else
                {
                    return "Error, no fue posible eliminar el automovil";
                }
            }

        }


    }
}
