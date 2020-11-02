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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.apriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.chiudiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox = new System.Windows.Forms.TextBox();
            this.tabControlForm1 = new System.Windows.Forms.TabControl();
            this.tabDati = new System.Windows.Forms.TabPage();
            this.btnCancellaTutti = new System.Windows.Forms.Button();
            this.btnSalva = new System.Windows.Forms.Button();
            this.chkInoltroAutomatico = new System.Windows.Forms.CheckBox();
            this.chkMonitoraggioAutomatico = new System.Windows.Forms.CheckBox();
            this.btnInoltroSingoloTest = new System.Windows.Forms.Button();
            this.tabFile1 = new System.Windows.Forms.TabPage();
            this.btnLeggiFile1 = new System.Windows.Forms.Button();
            this.chkAbilitaFile1 = new System.Windows.Forms.CheckBox();
            this.btnAnnullaFile1 = new System.Windows.Forms.Button();
            this.btnSalvaFile1 = new System.Windows.Forms.Button();
            this.btnSelectFile1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFile1 = new System.Windows.Forms.TextBox();
            this.tabFile2 = new System.Windows.Forms.TabPage();
            this.btnLeggiFile2 = new System.Windows.Forms.Button();
            this.chkAbilitaFile2 = new System.Windows.Forms.CheckBox();
            this.btnAnnullaFile2 = new System.Windows.Forms.Button();
            this.btnSalvaFile2 = new System.Windows.Forms.Button();
            this.btnSelectFile2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFile2 = new System.Windows.Forms.TextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tmrInvioDati = new System.Windows.Forms.Timer(this.components);
            this.tmrLeggiFile1 = new System.Windows.Forms.Timer(this.components);
            this.tmrLeggiFile2 = new System.Windows.Forms.Timer(this.components);
            this.tmrAttivitàIniziali = new System.Windows.Forms.Timer(this.components);
            this.fileSystemWatcher2 = new System.IO.FileSystemWatcher();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tabellaDatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaTuttiIRecordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaUltimiRecordImporatiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaUltimiRecordTrasferitiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaUltimiRecordConErroriToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.aggiornamentoAutomaticoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.visualizzaDebugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.arrestoProgrammaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.esciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.tabControlForm1.SuspendLayout();
            this.tabDati.SuspendLayout();
            this.tabFile1.SuspendLayout();
            this.tabFile2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.dataGridView1.Location = new System.Drawing.Point(7, 57);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(978, 446);
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
            this.apriToolStripMenuItem,
            this.infoToolStripMenuItem,
            this.debugToolStripMenuItem,
            this.toolStripSeparator1,
            this.chiudiToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(117, 98);
            // 
            // apriToolStripMenuItem
            // 
            this.apriToolStripMenuItem.Name = "apriToolStripMenuItem";
            this.apriToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.apriToolStripMenuItem.Text = "Apri";
            this.apriToolStripMenuItem.Click += new System.EventHandler(this.apriToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.debugToolStripMenuItem.Text = "Debug";
            this.debugToolStripMenuItem.Click += new System.EventHandler(this.debugToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(113, 6);
            // 
            // chiudiToolStripMenuItem
            // 
            this.chiudiToolStripMenuItem.Name = "chiudiToolStripMenuItem";
            this.chiudiToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.chiudiToolStripMenuItem.Text = "Termina";
            this.chiudiToolStripMenuItem.Click += new System.EventHandler(this.chiudiToolStripMenuItem_Click);
            // 
            // textBox
            // 
            this.textBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox.Location = new System.Drawing.Point(1, 568);
            this.textBox.Multiline = true;
            this.textBox.Name = "textBox";
            this.textBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox.Size = new System.Drawing.Size(995, 142);
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
            this.tabControlForm1.Location = new System.Drawing.Point(1, 27);
            this.tabControlForm1.Name = "tabControlForm1";
            this.tabControlForm1.SelectedIndex = 0;
            this.tabControlForm1.Size = new System.Drawing.Size(999, 535);
            this.tabControlForm1.TabIndex = 3;
            this.tabControlForm1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControlForm1_Selecting);
            // 
            // tabDati
            // 
            this.tabDati.Controls.Add(this.button1);
            this.tabDati.Controls.Add(this.btnCancellaTutti);
            this.tabDati.Controls.Add(this.btnSalva);
            this.tabDati.Controls.Add(this.chkInoltroAutomatico);
            this.tabDati.Controls.Add(this.chkMonitoraggioAutomatico);
            this.tabDati.Controls.Add(this.btnInoltroSingoloTest);
            this.tabDati.Controls.Add(this.dataGridView1);
            this.tabDati.Location = new System.Drawing.Point(4, 22);
            this.tabDati.Name = "tabDati";
            this.tabDati.Padding = new System.Windows.Forms.Padding(3);
            this.tabDati.Size = new System.Drawing.Size(991, 509);
            this.tabDati.TabIndex = 0;
            this.tabDati.Text = "Dati";
            this.tabDati.UseVisualStyleBackColor = true;
            // 
            // btnCancellaTutti
            // 
            this.btnCancellaTutti.Location = new System.Drawing.Point(507, 4);
            this.btnCancellaTutti.Name = "btnCancellaTutti";
            this.btnCancellaTutti.Size = new System.Drawing.Size(130, 45);
            this.btnCancellaTutti.TabIndex = 7;
            this.btnCancellaTutti.Text = "Cancella tutti";
            this.btnCancellaTutti.UseVisualStyleBackColor = true;
            this.btnCancellaTutti.Visible = false;
            this.btnCancellaTutti.Click += new System.EventHandler(this.btnCancellaTutti_Click);
            // 
            // btnSalva
            // 
            this.btnSalva.Location = new System.Drawing.Point(640, 3);
            this.btnSalva.Name = "btnSalva";
            this.btnSalva.Size = new System.Drawing.Size(130, 45);
            this.btnSalva.TabIndex = 6;
            this.btnSalva.Text = "Salva";
            this.btnSalva.UseVisualStyleBackColor = true;
            this.btnSalva.Visible = false;
            this.btnSalva.Click += new System.EventHandler(this.btnSalva_Click);
            // 
            // chkInoltroAutomatico
            // 
            this.chkInoltroAutomatico.AutoSize = true;
            this.chkInoltroAutomatico.Location = new System.Drawing.Point(303, 18);
            this.chkInoltroAutomatico.Name = "chkInoltroAutomatico";
            this.chkInoltroAutomatico.Size = new System.Drawing.Size(110, 17);
            this.chkInoltroAutomatico.TabIndex = 5;
            this.chkInoltroAutomatico.Text = "Inoltro automatico";
            this.chkInoltroAutomatico.UseVisualStyleBackColor = true;
            this.chkInoltroAutomatico.CheckedChanged += new System.EventHandler(this.chkInoltroAutomatico_CheckedChanged);
            // 
            // chkMonitoraggioAutomatico
            // 
            this.chkMonitoraggioAutomatico.AutoSize = true;
            this.chkMonitoraggioAutomatico.Location = new System.Drawing.Point(155, 18);
            this.chkMonitoraggioAutomatico.Name = "chkMonitoraggioAutomatico";
            this.chkMonitoraggioAutomatico.Size = new System.Drawing.Size(142, 17);
            this.chkMonitoraggioAutomatico.TabIndex = 4;
            this.chkMonitoraggioAutomatico.Text = "Monitoraggio automatico";
            this.chkMonitoraggioAutomatico.UseVisualStyleBackColor = true;
            this.chkMonitoraggioAutomatico.CheckedChanged += new System.EventHandler(this.chkMonitoraggioAutomatico_CheckedChanged);
            // 
            // btnInoltroSingoloTest
            // 
            this.btnInoltroSingoloTest.Location = new System.Drawing.Point(7, 6);
            this.btnInoltroSingoloTest.Name = "btnInoltroSingoloTest";
            this.btnInoltroSingoloTest.Size = new System.Drawing.Size(130, 45);
            this.btnInoltroSingoloTest.TabIndex = 3;
            this.btnInoltroSingoloTest.Text = "Inoltro singolo test";
            this.btnInoltroSingoloTest.UseVisualStyleBackColor = true;
            this.btnInoltroSingoloTest.Click += new System.EventHandler(this.btnInoltroSingoloTest_Click);
            // 
            // tabFile1
            // 
            this.tabFile1.Controls.Add(this.btnLeggiFile1);
            this.tabFile1.Controls.Add(this.chkAbilitaFile1);
            this.tabFile1.Controls.Add(this.btnAnnullaFile1);
            this.tabFile1.Controls.Add(this.btnSalvaFile1);
            this.tabFile1.Controls.Add(this.btnSelectFile1);
            this.tabFile1.Controls.Add(this.label1);
            this.tabFile1.Controls.Add(this.txtFile1);
            this.tabFile1.Location = new System.Drawing.Point(4, 22);
            this.tabFile1.Name = "tabFile1";
            this.tabFile1.Padding = new System.Windows.Forms.Padding(3);
            this.tabFile1.Size = new System.Drawing.Size(991, 509);
            this.tabFile1.TabIndex = 1;
            this.tabFile1.Text = "File1";
            this.tabFile1.UseVisualStyleBackColor = true;
            // 
            // btnLeggiFile1
            // 
            this.btnLeggiFile1.Location = new System.Drawing.Point(32, 99);
            this.btnLeggiFile1.Name = "btnLeggiFile1";
            this.btnLeggiFile1.Size = new System.Drawing.Size(201, 45);
            this.btnLeggiFile1.TabIndex = 6;
            this.btnLeggiFile1.Text = "Acquisizione Manuale";
            this.btnLeggiFile1.UseVisualStyleBackColor = true;
            this.btnLeggiFile1.Click += new System.EventHandler(this.btnLeggiFile1_Click);
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
            this.btnAnnullaFile1.Location = new System.Drawing.Point(899, 21);
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
            this.btnSalvaFile1.Location = new System.Drawing.Point(811, 21);
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
            this.btnSelectFile1.Location = new System.Drawing.Point(723, 21);
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
            this.txtFile1.Size = new System.Drawing.Size(685, 20);
            this.txtFile1.TabIndex = 0;
            // 
            // tabFile2
            // 
            this.tabFile2.Controls.Add(this.btnLeggiFile2);
            this.tabFile2.Controls.Add(this.chkAbilitaFile2);
            this.tabFile2.Controls.Add(this.btnAnnullaFile2);
            this.tabFile2.Controls.Add(this.btnSalvaFile2);
            this.tabFile2.Controls.Add(this.btnSelectFile2);
            this.tabFile2.Controls.Add(this.label2);
            this.tabFile2.Controls.Add(this.txtFile2);
            this.tabFile2.Location = new System.Drawing.Point(4, 22);
            this.tabFile2.Name = "tabFile2";
            this.tabFile2.Size = new System.Drawing.Size(991, 509);
            this.tabFile2.TabIndex = 2;
            this.tabFile2.Text = "File2";
            this.tabFile2.UseVisualStyleBackColor = true;
            // 
            // btnLeggiFile2
            // 
            this.btnLeggiFile2.Location = new System.Drawing.Point(32, 99);
            this.btnLeggiFile2.Name = "btnLeggiFile2";
            this.btnLeggiFile2.Size = new System.Drawing.Size(201, 45);
            this.btnLeggiFile2.TabIndex = 12;
            this.btnLeggiFile2.Text = "Acquisizione Manuale";
            this.btnLeggiFile2.UseVisualStyleBackColor = true;
            this.btnLeggiFile2.Click += new System.EventHandler(this.btnLeggiFile2_Click);
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
            this.btnAnnullaFile2.Location = new System.Drawing.Point(899, 21);
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
            this.btnSalvaFile2.Location = new System.Drawing.Point(811, 21);
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
            this.btnSelectFile2.Location = new System.Drawing.Point(723, 21);
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
            this.txtFile2.Size = new System.Drawing.Size(685, 20);
            this.txtFile2.TabIndex = 6;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "File csv|*.csv";
            this.openFileDialog1.InitialDirectory = "c:\\";
            this.openFileDialog1.RestoreDirectory = true;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // tmrInvioDati
            // 
            this.tmrInvioDati.Interval = 10000;
            this.tmrInvioDati.Tick += new System.EventHandler(this.tmrInvioDati_Tick);
            // 
            // tmrLeggiFile1
            // 
            this.tmrLeggiFile1.Interval = 1000;
            this.tmrLeggiFile1.Tick += new System.EventHandler(this.tmrLeggiFile1_Tick);
            // 
            // tmrLeggiFile2
            // 
            this.tmrLeggiFile2.Interval = 1000;
            this.tmrLeggiFile2.Tick += new System.EventHandler(this.tmrLeggiFile2_Tick);
            // 
            // tmrAttivitàIniziali
            // 
            this.tmrAttivitàIniziali.Interval = 5000;
            this.tmrAttivitàIniziali.Tick += new System.EventHandler(this.tmrAttivitàIniziali_Tick);
            // 
            // fileSystemWatcher2
            // 
            this.fileSystemWatcher2.EnableRaisingEvents = true;
            this.fileSystemWatcher2.NotifyFilter = System.IO.NotifyFilters.LastWrite;
            this.fileSystemWatcher2.SynchronizingObject = this;
            this.fileSystemWatcher2.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher2_Changed);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tabellaDatiToolStripMenuItem,
            this.logToolStripMenuItem,
            this.arrestoProgrammaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(999, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tabellaDatiToolStripMenuItem
            // 
            this.tabellaDatiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizzaTuttiIRecordToolStripMenuItem,
            this.visualizzaUltimiRecordImporatiToolStripMenuItem,
            this.visualizzaUltimiRecordTrasferitiToolStripMenuItem,
            this.visualizzaUltimiRecordConErroriToolStripMenuItem,
            this.toolStripMenuItem1,
            this.aggiornamentoAutomaticoToolStripMenuItem});
            this.tabellaDatiToolStripMenuItem.Name = "tabellaDatiToolStripMenuItem";
            this.tabellaDatiToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.tabellaDatiToolStripMenuItem.Text = "Tabella Dati";
            // 
            // visualizzaTuttiIRecordToolStripMenuItem
            // 
            this.visualizzaTuttiIRecordToolStripMenuItem.Name = "visualizzaTuttiIRecordToolStripMenuItem";
            this.visualizzaTuttiIRecordToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.visualizzaTuttiIRecordToolStripMenuItem.Text = "Visualizza Tutti i record";
            this.visualizzaTuttiIRecordToolStripMenuItem.Click += new System.EventHandler(this.visualizzaTuttiIRecordToolStripMenuItem_Click);
            // 
            // visualizzaUltimiRecordImporatiToolStripMenuItem
            // 
            this.visualizzaUltimiRecordImporatiToolStripMenuItem.Name = "visualizzaUltimiRecordImporatiToolStripMenuItem";
            this.visualizzaUltimiRecordImporatiToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.visualizzaUltimiRecordImporatiToolStripMenuItem.Text = "Visualizza ultimi record imporati";
            this.visualizzaUltimiRecordImporatiToolStripMenuItem.Click += new System.EventHandler(this.visualizzaUltimiRecordImporatiToolStripMenuItem_Click);
            // 
            // visualizzaUltimiRecordTrasferitiToolStripMenuItem
            // 
            this.visualizzaUltimiRecordTrasferitiToolStripMenuItem.Name = "visualizzaUltimiRecordTrasferitiToolStripMenuItem";
            this.visualizzaUltimiRecordTrasferitiToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.visualizzaUltimiRecordTrasferitiToolStripMenuItem.Text = "Visualizza ultimi record trasferiti";
            this.visualizzaUltimiRecordTrasferitiToolStripMenuItem.Click += new System.EventHandler(this.visualizzaUltimiRecordTrasferitiToolStripMenuItem_Click);
            // 
            // visualizzaUltimiRecordConErroriToolStripMenuItem
            // 
            this.visualizzaUltimiRecordConErroriToolStripMenuItem.Name = "visualizzaUltimiRecordConErroriToolStripMenuItem";
            this.visualizzaUltimiRecordConErroriToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.visualizzaUltimiRecordConErroriToolStripMenuItem.Text = "Visualizza ultimi record con errori";
            this.visualizzaUltimiRecordConErroriToolStripMenuItem.Click += new System.EventHandler(this.visualizzaUltimiRecordConErroriToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(246, 6);
            // 
            // aggiornamentoAutomaticoToolStripMenuItem
            // 
            this.aggiornamentoAutomaticoToolStripMenuItem.Checked = true;
            this.aggiornamentoAutomaticoToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aggiornamentoAutomaticoToolStripMenuItem.Name = "aggiornamentoAutomaticoToolStripMenuItem";
            this.aggiornamentoAutomaticoToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.aggiornamentoAutomaticoToolStripMenuItem.Text = "Aggiornamento automatico";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.visualizzaDebugToolStripMenuItem});
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.logToolStripMenuItem.Text = "Log";
            // 
            // visualizzaDebugToolStripMenuItem
            // 
            this.visualizzaDebugToolStripMenuItem.Checked = true;
            this.visualizzaDebugToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.visualizzaDebugToolStripMenuItem.Name = "visualizzaDebugToolStripMenuItem";
            this.visualizzaDebugToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.visualizzaDebugToolStripMenuItem.Text = "Visualizza debug";
            this.visualizzaDebugToolStripMenuItem.Click += new System.EventHandler(this.visualizzaDebugToolStripMenuItem_Click);
            // 
            // arrestoProgrammaToolStripMenuItem
            // 
            this.arrestoProgrammaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.esciToolStripMenuItem});
            this.arrestoProgrammaToolStripMenuItem.Name = "arrestoProgrammaToolStripMenuItem";
            this.arrestoProgrammaToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.arrestoProgrammaToolStripMenuItem.Text = "Arresto Programma";
            // 
            // esciToolStripMenuItem
            // 
            this.esciToolStripMenuItem.Name = "esciToolStripMenuItem";
            this.esciToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.esciToolStripMenuItem.Text = "Esci";
            this.esciToolStripMenuItem.Click += new System.EventHandler(this.esciToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(852, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 45);
            this.button1.TabIndex = 8;
            this.button1.Text = "Salva";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 711);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tabControlForm1);
            this.Controls.Add(this.textBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Stato - Impostazioni";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabControlForm1.ResumeLayout(false);
            this.tabDati.ResumeLayout(false);
            this.tabDati.PerformLayout();
            this.tabFile1.ResumeLayout(false);
            this.tabFile1.PerformLayout();
            this.tabFile2.ResumeLayout(false);
            this.tabFile2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
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
        private System.Windows.Forms.CheckBox chkInoltroAutomatico;
        private System.Windows.Forms.CheckBox chkMonitoraggioAutomatico;
        private System.Windows.Forms.Button btnInoltroSingoloTest;
        private System.Windows.Forms.Button btnSalva;
        private System.Windows.Forms.TabPage tabFile2;
        private System.Windows.Forms.CheckBox chkAbilitaFile2;
        private System.Windows.Forms.Button btnAnnullaFile2;
        private System.Windows.Forms.Button btnSalvaFile2;
        private System.Windows.Forms.Button btnSelectFile2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFile2;
        private System.Windows.Forms.Button btnCancellaTutti;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStripMenuItem apriToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiudiToolStripMenuItem;
        private System.Windows.Forms.Timer tmrInvioDati;
        private System.Windows.Forms.Timer tmrLeggiFile1;
        private System.Windows.Forms.Timer tmrLeggiFile2;
        private System.Windows.Forms.Timer tmrAttivitàIniziali;
        private System.Windows.Forms.Button btnLeggiFile1;
        private System.Windows.Forms.Button btnLeggiFile2;
        private System.IO.FileSystemWatcher fileSystemWatcher2;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tabellaDatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizzaTuttiIRecordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aggiornamentoAutomaticoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizzaUltimiRecordImporatiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizzaUltimiRecordTrasferitiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizzaUltimiRecordConErroriToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem arrestoProgrammaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem esciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem visualizzaDebugToolStripMenuItem;
        private System.Windows.Forms.Button button1;
    }
}

