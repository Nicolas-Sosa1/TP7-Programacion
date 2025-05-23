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



    }
}