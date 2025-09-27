namespace Clase_17_09_25
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TowerpictureBox = new System.Windows.Forms.PictureBox();
            this.MousepictureBox = new System.Windows.Forms.PictureBox();
            this.GroundpictureBox = new System.Windows.Forms.PictureBox();
            this.WallpictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.restartButton = new System.Windows.Forms.Button();
            this.TejopictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.TowerpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MousepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroundpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WallpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TejopictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // TowerpictureBox
            // 
            this.TowerpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.TowerpictureBox.Image = global::Clase_17_09_25.Properties.Resources.Torre;
            this.TowerpictureBox.Location = new System.Drawing.Point(345, 387);
            this.TowerpictureBox.Name = "TowerpictureBox";
            this.TowerpictureBox.Size = new System.Drawing.Size(137, 222);
            this.TowerpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TowerpictureBox.TabIndex = 2;
            this.TowerpictureBox.TabStop = false;
            // 
            // MousepictureBox
            // 
            this.MousepictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MousepictureBox.Image = global::Clase_17_09_25.Properties.Resources.Mococo_2;
            this.MousepictureBox.Location = new System.Drawing.Point(930, 480);
            this.MousepictureBox.Name = "MousepictureBox";
            this.MousepictureBox.Size = new System.Drawing.Size(147, 129);
            this.MousepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MousepictureBox.TabIndex = 0;
            this.MousepictureBox.TabStop = false;
            // 
            // GroundpictureBox
            // 
            this.GroundpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.GroundpictureBox.Location = new System.Drawing.Point(-3, 606);
            this.GroundpictureBox.Name = "GroundpictureBox";
            this.GroundpictureBox.Size = new System.Drawing.Size(1228, 42);
            this.GroundpictureBox.TabIndex = 3;
            this.GroundpictureBox.TabStop = false;
            // 
            // WallpictureBox
            // 
            this.WallpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.WallpictureBox.Location = new System.Drawing.Point(1186, -1);
            this.WallpictureBox.Name = "WallpictureBox";
            this.WallpictureBox.Size = new System.Drawing.Size(39, 610);
            this.WallpictureBox.TabIndex = 4;
            this.WallpictureBox.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // restartButton
            // 
            this.restartButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.restartButton.Location = new System.Drawing.Point(22, 17);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(167, 48);
            this.restartButton.TabIndex = 5;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // TejopictureBox
            // 
            this.TejopictureBox.BackColor = System.Drawing.Color.Transparent;
            this.TejopictureBox.Image = global::Clase_17_09_25.Properties.Resources.Baelz_rat;
            this.TejopictureBox.Location = new System.Drawing.Point(128, 320);
            this.TejopictureBox.Name = "TejopictureBox";
            this.TejopictureBox.Size = new System.Drawing.Size(70, 59);
            this.TejopictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TejopictureBox.TabIndex = 1;
            this.TejopictureBox.TabStop = false;
            this.TejopictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TejopictureBox_MouseDown);
            this.TejopictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TejopictureBox_MouseMove);
            this.TejopictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TejopictureBox_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.BackgroundImage = global::Clase_17_09_25.Properties.Resources.Back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1222, 641);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.TejopictureBox);
            this.Controls.Add(this.WallpictureBox);
            this.Controls.Add(this.GroundpictureBox);
            this.Controls.Add(this.TowerpictureBox);
            this.Controls.Add(this.MousepictureBox);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Temu Birds";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TowerpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MousepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroundpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WallpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TejopictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MousepictureBox;
        private System.Windows.Forms.PictureBox TowerpictureBox;
        private System.Windows.Forms.PictureBox GroundpictureBox;
        private System.Windows.Forms.PictureBox WallpictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.PictureBox TejopictureBox;
    }
}

