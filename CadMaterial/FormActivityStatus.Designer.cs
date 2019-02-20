namespace CadMaterial
{
    partial class FormActivityStatus
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
            this.groupBoxAmProcess = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbUnitAmProcess = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dgListaDeProcessos = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbAreaAmProcess = new System.Windows.Forms.ComboBox();
            this.activityCounter = new System.Windows.Forms.Label();
            this.groupBoxAmProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaDeProcessos)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxAmProcess
            // 
            this.groupBoxAmProcess.Controls.Add(this.activityCounter);
            this.groupBoxAmProcess.Controls.Add(this.label1);
            this.groupBoxAmProcess.Controls.Add(this.cbUnitAmProcess);
            this.groupBoxAmProcess.Controls.Add(this.button1);
            this.groupBoxAmProcess.Controls.Add(this.dgListaDeProcessos);
            this.groupBoxAmProcess.Controls.Add(this.label6);
            this.groupBoxAmProcess.Controls.Add(this.label5);
            this.groupBoxAmProcess.Controls.Add(this.cbAreaAmProcess);
            this.groupBoxAmProcess.Location = new System.Drawing.Point(12, 12);
            this.groupBoxAmProcess.Name = "groupBoxAmProcess";
            this.groupBoxAmProcess.Size = new System.Drawing.Size(851, 342);
            this.groupBoxAmProcess.TabIndex = 7;
            this.groupBoxAmProcess.TabStop = false;
            this.groupBoxAmProcess.Text = "AM_PROCESS_SP";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(256, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Linha (UNIT_ID)";
            // 
            // cbUnitAmProcess
            // 
            this.cbUnitAmProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUnitAmProcess.FormattingEnabled = true;
            this.cbUnitAmProcess.Location = new System.Drawing.Point(259, 45);
            this.cbUnitAmProcess.Name = "cbUnitAmProcess";
            this.cbUnitAmProcess.Size = new System.Drawing.Size(188, 21);
            this.cbUnitAmProcess.TabIndex = 9;
            this.cbUnitAmProcess.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(481, 45);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Lista de classes";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgListaDeProcessos
            // 
            this.dgListaDeProcessos.AllowUserToAddRows = false;
            this.dgListaDeProcessos.AllowUserToDeleteRows = false;
            this.dgListaDeProcessos.AllowUserToResizeColumns = false;
            this.dgListaDeProcessos.AllowUserToResizeRows = false;
            this.dgListaDeProcessos.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgListaDeProcessos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgListaDeProcessos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgListaDeProcessos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgListaDeProcessos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgListaDeProcessos.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgListaDeProcessos.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgListaDeProcessos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgListaDeProcessos.GridColor = System.Drawing.SystemColors.Control;
            this.dgListaDeProcessos.Location = new System.Drawing.Point(19, 96);
            this.dgListaDeProcessos.MultiSelect = false;
            this.dgListaDeProcessos.Name = "dgListaDeProcessos";
            this.dgListaDeProcessos.ReadOnly = true;
            this.dgListaDeProcessos.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dgListaDeProcessos.RowHeadersVisible = false;
            this.dgListaDeProcessos.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgListaDeProcessos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListaDeProcessos.ShowEditingIcon = false;
            this.dgListaDeProcessos.Size = new System.Drawing.Size(826, 219);
            this.dgListaDeProcessos.TabIndex = 7;
            this.dgListaDeProcessos.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgListaDeProcessos_RowsAdded);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(217, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Processos por área e classe (PROCESS_ID)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(124, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Área (PROCESS_AREA)";
            // 
            // cbAreaAmProcess
            // 
            this.cbAreaAmProcess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAreaAmProcess.FormattingEnabled = true;
            this.cbAreaAmProcess.Location = new System.Drawing.Point(19, 45);
            this.cbAreaAmProcess.Name = "cbAreaAmProcess";
            this.cbAreaAmProcess.Size = new System.Drawing.Size(188, 21);
            this.cbAreaAmProcess.TabIndex = 1;
            this.cbAreaAmProcess.SelectionChangeCommitted += new System.EventHandler(this.cbAreaAmProcess_SelectionChangeCommitted);
            // 
            // activityCounter
            // 
            this.activityCounter.AutoSize = true;
            this.activityCounter.Location = new System.Drawing.Point(16, 318);
            this.activityCounter.Name = "activityCounter";
            this.activityCounter.Size = new System.Drawing.Size(64, 13);
            this.activityCounter.TabIndex = 12;
            this.activityCounter.Text = "0 atividades";
            // 
            // FormActivityStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(875, 375);
            this.Controls.Add(this.groupBoxAmProcess);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormActivityStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Processos do produto";
            this.Load += new System.EventHandler(this.FormActivityStatus_Load);
            this.groupBoxAmProcess.ResumeLayout(false);
            this.groupBoxAmProcess.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgListaDeProcessos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxAmProcess;
        private System.Windows.Forms.DataGridView dgListaDeProcessos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbAreaAmProcess;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbUnitAmProcess;
        private System.Windows.Forms.Label activityCounter;
    }
}