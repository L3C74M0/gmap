using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gmap {
    public partial class Form1 : Form {

        DataTable dt;
        public Form1() {
            InitializeComponent();

        }

        private void gMapController_Load(object sender, EventArgs e) {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Year",typeof(String)));
            dt.Columns.Add(new DataColumn("Month", typeof(String)));
            dt.Columns.Add(new DataColumn("Salida", typeof(String)));
            dt.Columns.Add(new DataColumn("Llegada", typeof(String)));
            dt.Rows.Add("2017","march","Cali","Bogota");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            gmap.DragButton = MouseButtons.Left;
            gmap.CanDragMap = true;
            gmap.MapProvider = GMap.NET.MapProviders.GoogleTerrainMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gmap.Position = new GMap.NET.PointLatLng(38.9041, -77.0171);
            gmap.MinZoom = 0;
            gmap.MaxZoom = 18;
            gmap.Zoom = 9;
            gmap.AutoScroll = true;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void selectFlight(object sender, DataGridViewCellMouseEventArgs e)
        {
            int filaSeleccionada = e.RowIndex;
            String salida = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();
            String llegada = dataGridView1.Rows[filaSeleccionada].Cells[3].Value.ToString();
            String month = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
            textBoxMes.Text = month;
            textBoxLLegada.Text = llegada;
            textBoxSalida.Text = salida;
        }
    }
}