using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TP7_Grupo18_Programacion.Clases;

namespace TP7_Grupo18_Programacion
{
    public partial class SeleccionarSucursales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack == false)
            {

                //Cargar ListView Sucursales
                CargarListView();

                //Cargar Provincias en el DataList
                CargarProvincias();
            }

        }

        private void CargarListView()
        {
            GestionSucursales gestionSucursales = new GestionSucursales();
            lvSucursales.DataSource = gestionSucursales.ObtenerTodosLosProductos();
            lvSucursales.DataBind();
        }

        private void CargarProvincias()
        {
            GestionSucursales gestion = new GestionSucursales();
            dlProvincias.DataSource = gestion.ObtenerProvincias();
            dlProvincias.DataBind();
        }

    }
}