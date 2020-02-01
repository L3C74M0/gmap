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
        public Form1() {
            InitializeComponent();
        }

        private void gMapController_Load(object sender, EventArgs e) {
            gmap.MapProvider = GMap.NET.MapProviders.BingMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            gmap.SetPositionByKeywords("Medellín, Colombia");
        }
    }
}