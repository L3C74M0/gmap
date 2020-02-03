using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;


namespace gmap {
    public partial class Form1 : Form {

        DataTable dt;
        public Form1() {
            InitializeComponent();
            readInfo();
        }

        private void gMapController_Load(object sender, EventArgs e) {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("tailnum",typeof(String)));
            dt.Columns.Add(new DataColumn("Month", typeof(String)));
            dt.Columns.Add(new DataColumn("Salida", typeof(String)));
            dt.Columns.Add(new DataColumn("Llegada", typeof(String)));
            dt.Rows.Add("AAA","MARCH","N","new york");
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;
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

        public void readInfo()
        {
            string result="";
            try
            {
                var url = "https://query.data.world/s/6ankomqkxpsxwh4nnxjnw4ffvc7knf";
                 var client = new WebClient();
                 using (var stream = client.OpenRead(url))
                 using (var reader = new StreamReader(stream))
                 {
                     String line = reader.ReadLine();
                     int count = 0;
                     while ((line = reader.ReadLine()) != null && count < 5)
                     {
                         String[] args = line.Split(',');

                         String origin = args[14].Replace("\"", "");
                         String destination = args[24].Replace("\"", "");
                         String date = args[5].Replace("\"", "");
                         String nVuelo = args[11].Replace("\"", "");
                         count++;
                     }
                    reader.Close();
                    stream.Close();
                 }
                 
            }
            catch (WebException e)
            {
                result = string.Format("Could not get data. {0}", e);
                Console.WriteLine(result);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void selectFlight(object sender, DataGridViewCellMouseEventArgs e)
        {
            int filaSeleccionada = e.RowIndex;
            String nVuelo = dataGridView1.Rows[filaSeleccionada].Cells[0].Value.ToString();
            String salida = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();
            String llegada = dataGridView1.Rows[filaSeleccionada].Cells[3].Value.ToString();
            String month = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
            textBoxMes.Text = month;
            textBoxLLegada.Text = llegada;
            textBoxSalida.Text = salida;
            textBoxNvuelo.Text = nVuelo;

            GMapOverlay ruta = new GMapOverlay("Capa ruta");
            List<PointLatLng> puntos = new List<PointLatLng>();
            puntos.Add(new PointLatLng(38.9041, -77.0171));
            puntos.Add(new PointLatLng(39.2903786, -76.6121902));
            GMapRoute puntosRuta = new GMapRoute(puntos,"rutas");
            ruta.Routes.Add(puntosRuta);
            gmap.Overlays.Add(ruta);
            gmap.Zoom = gmap.Zoom + 1;
            gmap.Zoom = gmap.Zoom - 1;
        }
    }
}