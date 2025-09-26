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
            this.TejopictureBox = new System.Windows.Forms.PictureBox();
            this.MousepictureBox = new System.Windows.Forms.PictureBox();
            this.GroundpictureBox = new System.Windows.Forms.PictureBox();
            this.WallpictureBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.restartButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.TowerpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TejopictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MousepictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroundpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WallpictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // TowerpictureBox
            // 
            this.TowerpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.TowerpictureBox.Image = global::Clase_17_09_25.Properties.Resources.Torre;
            this.TowerpictureBox.Location = new System.Drawing.Point(460, 476);
            this.TowerpictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TowerpictureBox.Name = "TowerpictureBox";
            this.TowerpictureBox.Size = new System.Drawing.Size(183, 273);
            this.TowerpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TowerpictureBox.TabIndex = 2;
            this.TowerpictureBox.TabStop = false;
            // 
            // TejopictureBox
            // 
            this.TejopictureBox.BackColor = System.Drawing.Color.Transparent;
            this.TejopictureBox.Image = global::Clase_17_09_25.Properties.Resources.Baelz_rat;
            this.TejopictureBox.Location = new System.Drawing.Point(212, 181);
            this.TejopictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TejopictureBox.Name = "TejopictureBox";
            this.TejopictureBox.Size = new System.Drawing.Size(93, 73);
            this.TejopictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.TejopictureBox.TabIndex = 1;
            this.TejopictureBox.TabStop = false;
            this.TejopictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TejopictureBox_MouseDown);
            this.TejopictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TejopictureBox_MouseMove);
            this.TejopictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TejopictureBox_MouseUp);
            // 
            // MousepictureBox
            // 
            this.MousepictureBox.BackColor = System.Drawing.Color.Transparent;
            this.MousepictureBox.Image = global::Clase_17_09_25.Properties.Resources.Mococo_2;
            this.MousepictureBox.Location = new System.Drawing.Point(1240, 591);
            this.MousepictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MousepictureBox.Name = "MousepictureBox";
            this.MousepictureBox.Size = new System.Drawing.Size(196, 159);
            this.MousepictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.MousepictureBox.TabIndex = 0;
            this.MousepictureBox.TabStop = false;
            // 
            // GroundpictureBox
            // 
            this.GroundpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.GroundpictureBox.Location = new System.Drawing.Point(-4, 746);
            this.GroundpictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.GroundpictureBox.Name = "GroundpictureBox";
            this.GroundpictureBox.Size = new System.Drawing.Size(1637, 52);
            this.GroundpictureBox.TabIndex = 3;
            this.GroundpictureBox.TabStop = false;
            // 
            // WallpictureBox
            // 
            this.WallpictureBox.BackColor = System.Drawing.Color.Transparent;
            this.WallpictureBox.Location = new System.Drawing.Point(1581, -1);
            this.WallpictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.WallpictureBox.Name = "WallpictureBox";
            this.WallpictureBox.Size = new System.Drawing.Size(52, 751);
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
            this.restartButton.Location = new System.Drawing.Point(29, 21);
            this.restartButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(223, 59);
            this.restartButton.TabIndex = 5;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(813, 28);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(725, 112);
            this.dataGridView1.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Velocidad inicial";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 125;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Tiempo total";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 125;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Alcance Maximo";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            this.Column3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Altura Maxima";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 125;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Velocidad al impacto";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            this.Column5.Width = 125;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.Column6,
            this.Column7,
            this.Column8});
            this.dataGridView2.Location = new System.Drawing.Point(813, 148);
            this.dataGridView2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.Size = new System.Drawing.Size(725, 121);
            this.dataGridView2.TabIndex = 7;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Velocidad en altura maxima";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "componente x";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "component y";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Magnitud de la velocidad";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            this.Column7.Width = 125;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Angulo respecto al eje x";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            this.Column8.Width = 125;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.BackgroundImage = global::Clase_17_09_25.Properties.Resources.Back;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1629, 789);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.TejopictureBox);
            this.Controls.Add(this.WallpictureBox);
            this.Controls.Add(this.GroundpictureBox);
            this.Controls.Add(this.TowerpictureBox);
            this.Controls.Add(this.MousepictureBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "Temu Birds";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TowerpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TejopictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MousepictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.GroundpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WallpictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox MousepictureBox;
        private System.Windows.Forms.PictureBox TejopictureBox;
        private System.Windows.Forms.PictureBox TowerpictureBox;
        private System.Windows.Forms.PictureBox GroundpictureBox;
        private System.Windows.Forms.PictureBox WallpictureBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
    }
}

