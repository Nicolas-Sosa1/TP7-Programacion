using System;
using System.Collections.Generic;
using System.Data;
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

        private DataTable CrearTabla()
        {
            DataTable dataTable = new DataTable();

            DataColumn dataColumn;

            dataColumn = new DataColumn("Id_Sucursal", typeof(string));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("NombreSucursal", typeof(string));
            dataTable.Columns.Add(dataColumn);

            dataColumn = new DataColumn("DescripcionSucursal", typeof(string));
            dataTable.Columns.Add(dataColumn);

            return dataTable;
        }

        private DataTable AgregarFila(DataTable dataTable, string idSucursal, string nombre, string descripcion)
        {
            DataRow dataRow = dataTable.NewRow();

            dataRow["Id_Sucursal"] = idSucursal;
            dataRow["NombreSucursal"] = nombre;
            dataRow["DescripcionSucursal"] = descripcion;

            dataTable.Rows.Add(dataRow);

            return dataTable;
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            if (txtNombreSucursal.Text == "")
            {
                CargarListView();
            }
            else if (txtNombreSucursal.Text != "")
            {

                GestionSucursales gestionSucursales = new GestionSucursales();
                lvSucursales.DataSource = gestionSucursales.BuscarSucursalPorNombre(txtNombreSucursal.Text);
                lvSucursales.DataBind();
            }
        }

        protected void btnSeleccionar_Command(object sender, CommandEventArgs e)
        {

            if (e.CommandName == "eventoSeleccionar")
            {

                string[] datos = e.CommandArgument.ToString().Split('|');

                if (datos.Length == 3)
                {
                    string idSucursal = datos[0];
                    string nombre = datos[1];
                    string descripcion = datos[2];



                    if (Session["tabla"] == null)
                    {
                        Session["tabla"] = CrearTabla();
                    }
                   
                    DataTable tabla = (DataTable)Session["tabla"];
                    bool yaExiste = tabla.AsEnumerable().Any(row => row["Id_Sucursal"].ToString() == idSucursal);

                    // Si el ID ya existe
                    if (yaExiste)
                    {
                        lblMensaje.Text = "Sucursal ya agregada, seleccione otra";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                    // Si no existe agrega la sucursal
                    else
                    {
                        AgregarFila((DataTable)Session["tabla"], idSucursal, nombre, descripcion);
                        Session["Tabla"] = tabla;
                        lblMensaje.Text = "Sucursal agregada: " + nombre;
                        lblMensaje.ForeColor = System.Drawing.Color.Green;

                    }
                    
                }

            }
        }

        protected void btnProvincia_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "filtrarProvincia")
            {
                int idProvincia = Convert.ToInt32(e.CommandArgument);
                GestionSucursales gestion = new GestionSucursales();
                lvSucursales.DataSource = gestion.ObtenerSucursalesPorProvincia(idProvincia);
                lvSucursales.DataBind();
            }
        }

        protected void lvSucursales_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager dataPager = (DataPager)lvSucursales.FindControl("DataPager1");
            if (dataPager != null)
            {
                dataPager.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            }

            CargarListView();
        }

       
    }
}