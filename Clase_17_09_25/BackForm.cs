using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clase_17_09_25
{
    public partial class BackForm : Form
    {

        public Point TejoLocation
        {
            get { return TejopictureBox.Location; }
            set { TejopictureBox.Location = value; }
        }
        public Size TejoSize
        {
            get { return TejopictureBox.Size; }
            set { TejopictureBox.Size = value; }
        }
        public Point GroundLocation
        {
            get { return GroundpictureBox.Location; }
            set { GroundpictureBox.Location = value; }
        }

        public Size GroundSize
        {
            get { return GroundpictureBox.Size; }
            set { GroundpictureBox.Size = value; }
        }
        public Point WallLocation
        {
            get { return WallpictureBox.Location; }
            set { WallpictureBox.Location = value; }
        }
        public Size WallSize
        {
            get { return WallpictureBox.Size; }
            set { WallpictureBox.Size = value; }
        }

        public Point TowerLocation
        {
            get { return TowerpictureBox.Location; }
            set { TowerpictureBox.Location = value; }
        }
        public Size TowerSize
        {
            get { return TowerpictureBox.Size; }
            set { TowerpictureBox.Size = value; }
        }
        public BackForm()
        {
            InitializeComponent();
            this.ShowInTaskbar = false;
        }
        private void BackForm_MouseDown(object sender, MouseEventArgs e)
        {
            var processForm = Application.OpenForms["ProcessForm"];
            processForm?.BringToFront();
        }

        private void BackForm_Load(object sender, EventArgs e)
        {

        }
    }
}
