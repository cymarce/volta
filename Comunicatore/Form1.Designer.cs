namespace Comunicatore
{
    partial class Form1
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCarica = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.TextBox();
            this.tabControlForm1 = new System.Windows.Forms.TabControl();
            this.tabDati = new System.Windows.Forms.TabPage();
            this.btnSalva = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tabFile1 = new System.Windows.Forms.TabPage();
            this.chkAbilitaFile1 = new System.Windows.Forms.CheckBox();
            this.btnAnnullaFile1 = new System.Windows.Forms.Button();
            this.btnSalvaFile1 = new System.Windows.Forms.Button();
            this.btnSelectFile1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.tabFile2 = new System.Windows.Forms.TabPage();
            this.chkAbilitaFile2 = new System.Windows.Forms.CheckBox();
            this.btnAnnullaFile2 = new System.Windows.Forms.Button();
            this.btnSalvaFile2 = new System.Windows.Forms.Button();
            this.btnSelectFile2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControlForm1.SuspendLayout();
            this.tabDati.SuspendLayout();
            this.tabFile1.SuspendLayout();
            this.tabFile2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCarica
            // 
            this.btnCarica.Location = new System.Drawing.Point(7, 3);
            this.btnCarica.Name = "btnCarica";
            this.btnCarica.Size = new System.Drawing.Size(130, 45);
            this.btnCarica.TabIndex = 0;
            this.btnCarica.Text = "Carica";
            this.btnCarica.UseVisualStyleBackColor = true;
            this.btnCarica.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(763, 290);
            this.dataGridView1.TabIndex = 1;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Comunicatore";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(96, 26);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(95, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(1, 424);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(780, 182);
            this.textBox.TabIndex = 2;
            // 
            // tabControlForm1
            // 
            this.tabControlForm1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlForm1.Controls.Add(this.tabDati);
            this.tabControlForm1.Controls.Add(this.tabFile1);
            this.tabControlForm1.Controls.Add(this.tabFile2);
            this.tabControlForm1.Location = new System.Drawing.Point(1, -2);
            this.tabControlForm1.Name = "tabControlForm1";
            this.tabControlForm1.SelectedIndex = 0;
            this.tabControlForm1.Size = new System.Drawing.Size(784, 424);
            this.tabControlForm1.TabIndex = 3;
            this.tabControlForm1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlForm1_Selecting);
            // 
            // tabDati
            // 
            this.tabDati.Controls.Add(this.btnSalva);
            this.tabDati.Controls.Add(this.checkBox2);
            this.tabDati.Controls.Add(this.checkBox1);
            this.tabDati.Controls.Add(this.button3);
            this.tabDati.Controls.Add(this.button2);
            this.tabDati.Controls.Add(this.btnCarica);
            this.tabDati.Controls.Add(this.dataGridView1);
            this.tabDati.Location = new System.Drawing.Point(4, 22);
            this.tabDati.Name = "tabDati";
            this.tabDati.Padding = new System.Windows.Forms.Padding(3);
            this.tabDati.Size = new System.Drawing.Size(776, 398);
            this.tabDati.TabIndex = 0;
            this.tabDati.Text = "Dati";
            this.tabDati.UseVisualStyleBackColor = true;
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(7, 51);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(130, 45);
            this.btnSalva.TabIndex = 6;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Click += new System.EventHandler(this.button4_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(353, 61);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(110, 17);
            this.checkBox2.TabIndex = 5;
            this.checkBox2.Text = "Inoltro automatico";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(173, 61);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(142, 17);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.Text = "Monitoraggio automatico";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(353, 6);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(130, 45);
            this.button3.TabIndex = 3;
            this.button3.Text = "Inoltrare test mancani";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(173, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(130, 45);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cercare nuovi test";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabFile1
            // 
            this.tabFile1.Controls.Add(this.chkAbilitaFile1);
            this.tabFile1.Controls.Add(this.btnAnnullaFile1);
            this.tabFile1.Controls.Add(this.btnSalvaFile1);
            this.tabFile1.Controls.Add(this.btnSelectFile1);
            this.tabFile1.Controls.Add(this.label1);
            this.tabFile1.Controls.Add(this.txtFile1);
            this.tabFile1.Location = new System.Drawing.Point(4, 22);
            this.tabFile1.Name = "tabFile1";
            this.tabFile1.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile1.Size = new System.Drawing.Size(776, 398);
            this.tabFile1.TabIndex = 1;
            this.tabFile1.Text = "File1";
            this.tabFile1.UseVisualStyleBackColor = true;
            // 
            // chkAbilitaFile1
            // 
            this.chkAbilitaFile1.AutoSize = true;
            this.chkAbilitaFile1.Location = new System.Drawing.Point(32, 61);
            this.chkAbilitaFile1.Name = "chkAbilitaFile1";
            this.chkAbilitaFile1.Size = new System.Drawing.Size(54, 17);
            this.chkAbilitaFile1.TabIndex = 5;
            this.chkAbilitaFile1.Text = "Abilita";
            this.chkAbilitaFile1.UseVisualStyleBackColor = true;
            this.chkAbilitaFile1.CheckedChanged += new System.EventHandler(this.chkAbilitaFile1_CheckedChanged);
            // 
            // btnAnnullaFile1
            // 
            this.btnAnnullaFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnullaFile1.Enabled = false;
            this.btnAnnullaFile1.Location = new System.Drawing.Point(684, 21);
            this.btnAnnullaFile1.Name = "btnAnnullaFile1";
            this.btnAnnullaFile1.Size = new System.Drawing.Size(82, 19);
            this.btnAnnullaFile1.TabIndex = 4;
            this.btnAnnullaFile1.Text = "Annulla";
            this.btnAnnullaFile1.UseVisualStyleBackColor = true;
            this.btnAnnullaFile1.Click += new System.EventHandler(this.btnAnnullaFile1_Click);
            // 
            // btnSalvaFile1
            // 
            this.btnSalvaFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvaFile1.Enabled = false;
            this.btnSalvaFile1.Location = new System.Drawing.Point(596, 21);
            this.btnSalvaFile1.Name = "btnSalvaFile1";
            this.btnSalvaFile1.Size = new System.Drawing.Size(82, 19);
            this.btnSalvaFile1.TabIndex = 3;
            this.btnSalvaFile1.Text = "Salva";
            this.btnSalvaFile1.UseVisualStyleBackColor = true;
            this.btnSalvaFile1.Click += new System.EventHandler(this.btnSalvaFile1_Click);
            // 
            // btnSelectFile1
            // 
            this.btnSelectFile1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile1.Location = new System.Drawing.Point(508, 21);
            this.btnSelectFile1.Name = "btnSelectFile1";
            this.btnSelectFile1.Size = new System.Drawing.Size(82, 19);
            this.btnSelectFile1.TabIndex = 2;
            this.btnSelectFile1.Text = "Seleziona";
            this.btnSelectFile1.UseVisualStyleBackColor = true;
            this.btnSelectFile1.Click += new System.EventHandler(this.btnSelectFile1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "File ";
            // 
            // txtFile1
            // 
            this.txtFile1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile1.Location = new System.Drawing.Point(32, 21);
            this.txtFile1.Name = "txtFile1";
            this.txtFile1.ReadOnly = true;
            this.txtFile1.Size = new System.Drawing.Size(470, 20);
            this.txtFile1.TabIndex = 0;
            // 
            // tabFile2
            // 
            this.tabFile2.Controls.Add(this.chkAbilitaFile2);
            this.tabFile2.Controls.Add(this.btnAnnullaFile2);
            this.tabFile2.Controls.Add(this.btnSalvaFile2);
            this.tabFile2.Controls.Add(this.btnSelectFile2);
            this.tabFile2.Controls.Add(this.label2);
            this.tabFile2.Controls.Add(this.txtFile2);
            this.tabFile2.Location = new System.Drawing.Point(4, 22);
            this.tabFile2.Name = "tabFile2";
            this.tabFile2.Size = new System.Drawing.Size(776, 398);
            this.tabFile2.TabIndex = 2;
            this.tabFile2.Text = "File2";
            this.tabFile2.UseVisualStyleBackColor = true;
            // 
            // chkAbilitaFile2
            // 
            this.chkAbilitaFile2.AutoSize = true;
            this.chkAbilitaFile2.Location = new System.Drawing.Point(32, 61);
            this.chkAbilitaFile2.Name = "chkAbilitaFile2";
            this.chkAbilitaFile2.Size = new System.Drawing.Size(54, 17);
            this.chkAbilitaFile2.TabIndex = 11;
            this.chkAbilitaFile2.Text = "Abilita";
            this.chkAbilitaFile2.UseVisualStyleBackColor = true;
            this.chkAbilitaFile2.CheckedChanged += new System.EventHandler(this.chkAbilitaFile2_CheckedChanged);
            // 
            // btnAnnullaFile2
            // 
            this.btnAnnullaFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAnnullaFile2.Enabled = false;
            this.btnAnnullaFile2.Location = new System.Drawing.Point(684, 21);
            this.btnAnnullaFile2.Name = "btnAnnullaFile2";
            this.btnAnnullaFile2.Size = new System.Drawing.Size(82, 19);
            this.btnAnnullaFile2.TabIndex = 10;
            this.btnAnnullaFile2.Text = "Annulla";
            this.btnAnnullaFile2.UseVisualStyleBackColor = true;
            this.btnAnnullaFile2.Click += new System.EventHandler(this.btnAnnullaFile2_Click);
            // 
            // btnSalvaFile2
            // 
            this.btnSalvaFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalvaFile2.Enabled = false;
            this.btnSalvaFile2.Location = new System.Drawing.Point(596, 21);
            this.btnSalvaFile2.Name = "btnSalvaFile2";
            this.btnSalvaFile2.Size = new System.Drawing.Size(82, 19);
            this.btnSalvaFile2.TabIndex = 9;
            this.btnSalvaFile2.Text = "Salva";
            this.btnSalvaFile2.UseVisualStyleBackColor = true;
            this.btnSalvaFile2.Click += new System.EventHandler(this.btnSalvaFile2_Click);
            // 
            // btnSelectFile2
            // 
            this.btnSelectFile2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFile2.Location = new System.Drawing.Point(508, 21);
            this.btnSelectFile2.Name = "btnSelectFile2";
            this.btnSelectFile2.Size = new System.Drawing.Size(82, 19);
            this.btnSelectFile2.TabIndex = 8;
            this.btnSelectFile2.Text = "Seleziona";
            this.btnSelectFile2.UseVisualStyleBackColor = true;
            this.btnSelectFile2.Click += new System.EventHandler(this.btnSelectFile2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "File ";
            // 
            // txtFile2
            // 
            this.txtFile2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile2.Location = new System.Drawing.Point(32, 21);
            this.txtFile2.Name = "txtFile2";
            this.txtFile2.ReadOnly = true;
            this.txtFile2.Size = new System.Drawing.Size(470, 20);
            this.txtFile2.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "File csv|*.csv";
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 607);
            this.Controls.Add(this.tabControlForm1);
            this.Controls.Add(this.textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Stato - Impostazioni";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControlForm1.ResumeLayout(false);
            this.tabDati.ResumeLayout(false);
            this.tabDati.PerformLayout();
            this.tabFile1.ResumeLayout(false);
            this.tabFile1.PerformLayout();
            this.tabFile2.ResumeLayout(false);
            this.tabFile2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCarica;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox;
        private System.Windows.Forms.TabControl tabControlForm1;
        private System.Windows.Forms.TabPage tabDati;
        private System.Windows.Forms.TabPage tabFile1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFile1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnAnnullaFile1;
        private System.Windows.Forms.Button btnSalvaFile1;
        private System.Windows.Forms.Button btnSelectFile1;
        private System.Windows.Forms.CheckBox chkAbilitaFile1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.TabPage tabFile2;
        private System.Windows.Forms.CheckBox chkAbilitaFile2;
        private System.Windows.Forms.Button btnAnnullaFile2;
        private System.Windows.Forms.Button btnSalvaFile2;
        private System.Windows.Forms.Button btnSelectFile2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile2;
    }
}

