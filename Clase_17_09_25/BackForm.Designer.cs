namespace Clase_17_09_25
{
    partial class BackForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.WallpictureBox = new System.Windows.Forms.PictureBox();
            this.GroundpictureBox = new System.Windows.Forms.PictureBox();
            this.TowerpictureBox = new System.Windows.Forms.PictureBox();
            this.TejopictureBox = new System.Windows.Forms.PictureBox();
            this.MousepictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.WallpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroundpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TowerpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TejopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MousepictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // WallpictureBox
            // 
            this.WallpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.WallpictureBox.Location = new System.Drawing.Point(1186, -4);
            this.WallpictureBox.Name = "WallpictureBox";
            this.WallpictureBox.Size = new System.Drawing.Size(39, 610);
            this.WallpictureBox.TabIndex = 9;
            this.WallpictureBox.TabStop = false;
            // 
            // GroundpictureBox
            // 
            this.GroundpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.GroundpictureBox.Location = new System.Drawing.Point(-3, 603);
            this.GroundpictureBox.Name = "GroundpictureBox";
            this.GroundpictureBox.Size = new System.Drawing.Size(1228, 42);
            this.GroundpictureBox.TabIndex = 8;
            this.GroundpictureBox.TabStop = false;
            // 
            // TowerpictureBox
            // 
            this.TowerpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.TowerpictureBox.Image = global::Clase_17_09_25.Properties.Resources.Torre;
            this.TowerpictureBox.Location = new System.Drawing.Point(345, 448);
            this.TowerpictureBox.Name = "TowerpictureBox";
            this.TowerpictureBox.Size = new System.Drawing.Size(105, 158);
            this.TowerpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TowerpictureBox.TabIndex = 7;
            this.TowerpictureBox.TabStop = false;
            // 
            // TejopictureBox
            // 
            this.TejopictureBox.BackColor = System.Drawing.Color.Transparent;
            this.TejopictureBox.Image = global::Clase_17_09_25.Properties.Resources.Tejo;
            this.TejopictureBox.Location = new System.Drawing.Point(88, 398);
            this.TejopictureBox.Name = "TejopictureBox";
            this.TejopictureBox.Size = new System.Drawing.Size(70, 59);
            this.TejopictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TejopictureBox.TabIndex = 6;
            this.TejopictureBox.TabStop = false;
            // 
            // MousepictureBox
            // 
            this.MousepictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MousepictureBox.Image = global::Clase_17_09_25.Properties.Resources.Mococo_2;
            this.MousepictureBox.Location = new System.Drawing.Point(884, 477);
            this.MousepictureBox.Name = "MousepictureBox";
            this.MousepictureBox.Size = new System.Drawing.Size(147, 129);
            this.MousepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MousepictureBox.TabIndex = 5;
            this.MousepictureBox.TabStop = false;
            // 
            // BackForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Clase_17_09_25.Properties.Resources.Back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1222, 641);
            this.Controls.Add(this.WallpictureBox);
            this.Controls.Add(this.GroundpictureBox);
            this.Controls.Add(this.TowerpictureBox);
            this.Controls.Add(this.TejopictureBox);
            this.Controls.Add(this.MousepictureBox);
            this.DoubleBuffered = true;
            this.Name = "BackForm";
            this.Text = "BackForm";
            this.Load += new System.EventHandler(this.BackForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.WallpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroundpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TowerpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TejopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MousepictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox WallpictureBox;
        private System.Windows.Forms.PictureBox GroundpictureBox;
        private System.Windows.Forms.PictureBox TowerpictureBox;
        private System.Windows.Forms.PictureBox TejopictureBox;
        private System.Windows.Forms.PictureBox MousepictureBox;
    }
}