namespace mesic
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.textBoxAddress = new System.Windows.Forms.TextBox();
            this.buttonStart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.updaterTimer = new System.Windows.Forms.Timer(this.components);
            this.scheme = new System.Windows.Forms.PictureBox();
            this.labelX = new System.Windows.Forms.Label();
            this.labelY = new System.Windows.Forms.Label();
            this.labelVX = new System.Windows.Forms.Label();
            this.labelVY = new System.Windows.Forms.Label();
            this.labelFuel = new System.Windows.Forms.Label();
            this.labelLandingL = new System.Windows.Forms.Label();
            this.labelLandingR = new System.Windows.Forms.Label();
            this.labelID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonStartAuto = new System.Windows.Forms.Button();
            this.labelState = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.scheme)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxAddress
            // 
            this.textBoxAddress.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBoxAddress.Location = new System.Drawing.Point(99, 7);
            this.textBoxAddress.Name = "textBoxAddress";
            this.textBoxAddress.Size = new System.Drawing.Size(96, 20);
            this.textBoxAddress.TabIndex = 0;
            this.textBoxAddress.Text = "127.0.0.1:8000";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(201, 7);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(133, 20);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Manuální přistání";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Adresa serveru:";
            // 
            // updaterTimer
            // 
            this.updaterTimer.Enabled = true;
            this.updaterTimer.Interval = 50;
            this.updaterTimer.Tick += new System.EventHandler(this.updaterTimer_Tick);
            // 
            // scheme
            // 
            this.scheme.BackColor = System.Drawing.Color.White;
            this.scheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.scheme.Location = new System.Drawing.Point(15, 33);
            this.scheme.Name = "scheme";
            this.scheme.Size = new System.Drawing.Size(450, 450);
            this.scheme.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.scheme.TabIndex = 3;
            this.scheme.TabStop = false;
            // 
            // labelX
            // 
            this.labelX.AutoSize = true;
            this.labelX.Location = new System.Drawing.Point(79, 490);
            this.labelX.Name = "labelX";
            this.labelX.Size = new System.Drawing.Size(14, 13);
            this.labelX.TabIndex = 4;
            this.labelX.Text = "X";
            // 
            // labelY
            // 
            this.labelY.AutoSize = true;
            this.labelY.Location = new System.Drawing.Point(128, 490);
            this.labelY.Name = "labelY";
            this.labelY.Size = new System.Drawing.Size(14, 13);
            this.labelY.TabIndex = 5;
            this.labelY.Text = "Y";
            // 
            // labelVX
            // 
            this.labelVX.AutoSize = true;
            this.labelVX.Location = new System.Drawing.Point(193, 490);
            this.labelVX.Name = "labelVX";
            this.labelVX.Size = new System.Drawing.Size(20, 13);
            this.labelVX.TabIndex = 6;
            this.labelVX.Text = "vX";
            // 
            // labelVY
            // 
            this.labelVY.AutoSize = true;
            this.labelVY.Location = new System.Drawing.Point(242, 490);
            this.labelVY.Name = "labelVY";
            this.labelVY.Size = new System.Drawing.Size(20, 13);
            this.labelVY.TabIndex = 7;
            this.labelVY.Text = "vY";
            // 
            // labelFuel
            // 
            this.labelFuel.AutoSize = true;
            this.labelFuel.Location = new System.Drawing.Point(320, 490);
            this.labelFuel.Name = "labelFuel";
            this.labelFuel.Size = new System.Drawing.Size(14, 13);
            this.labelFuel.TabIndex = 8;
            this.labelFuel.Text = "P";
            // 
            // labelLandingL
            // 
            this.labelLandingL.AutoSize = true;
            this.labelLandingL.Location = new System.Drawing.Point(383, 490);
            this.labelLandingL.Name = "labelLandingL";
            this.labelLandingL.Size = new System.Drawing.Size(13, 13);
            this.labelLandingL.TabIndex = 9;
            this.labelLandingL.Text = "L";
            // 
            // labelLandingR
            // 
            this.labelLandingR.AutoSize = true;
            this.labelLandingR.Location = new System.Drawing.Point(420, 490);
            this.labelLandingR.Name = "labelLandingR";
            this.labelLandingR.Size = new System.Drawing.Size(15, 13);
            this.labelLandingR.TabIndex = 10;
            this.labelLandingR.Text = "R";
            // 
            // labelID
            // 
            this.labelID.AutoSize = true;
            this.labelID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelID.Location = new System.Drawing.Point(20, 490);
            this.labelID.Name = "labelID";
            this.labelID.Size = new System.Drawing.Size(20, 13);
            this.labelID.TabIndex = 11;
            this.labelID.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(12, 522);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(438, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Modul můžete ovládat při manuálním přistání klávesnicí šipkami nahoru, doleva a d" +
    "oprava.";
            // 
            // buttonStartAuto
            // 
            this.buttonStartAuto.Location = new System.Drawing.Point(341, 7);
            this.buttonStartAuto.Name = "buttonStartAuto";
            this.buttonStartAuto.Size = new System.Drawing.Size(124, 20);
            this.buttonStartAuto.TabIndex = 13;
            this.buttonStartAuto.Text = "Automatické přistání";
            this.buttonStartAuto.UseVisualStyleBackColor = true;
            this.buttonStartAuto.Click += new System.EventHandler(this.buttonStartAuto_Click);
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.BackColor = System.Drawing.Color.White;
            this.labelState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelState.Location = new System.Drawing.Point(23, 42);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(152, 13);
            this.labelState.TabIndex = 14;
            this.labelState.Text = "Přistání nebylo zahájeno.";
            this.labelState.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 541);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Přerušit probíhající přistání můžete klávesou Esc.";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 568);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelState);
            this.Controls.Add(this.buttonStartAuto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelID);
            this.Controls.Add(this.labelLandingR);
            this.Controls.Add(this.labelLandingL);
            this.Controls.Add(this.labelFuel);
            this.Controls.Add(this.labelVY);
            this.Controls.Add(this.labelVX);
            this.Controls.Add(this.labelY);
            this.Controls.Add(this.labelX);
            this.Controls.Add(this.scheme);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.textBoxAddress);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Přistání na Měsíci";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.scheme)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxAddress;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer updaterTimer;
        private System.Windows.Forms.PictureBox scheme;
        private System.Windows.Forms.Label labelX;
        private System.Windows.Forms.Label labelY;
        private System.Windows.Forms.Label labelVX;
        private System.Windows.Forms.Label labelVY;
        private System.Windows.Forms.Label labelFuel;
        private System.Windows.Forms.Label labelLandingL;
        private System.Windows.Forms.Label labelLandingR;
        private System.Windows.Forms.Label labelID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonStartAuto;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label label3;
    }
}

