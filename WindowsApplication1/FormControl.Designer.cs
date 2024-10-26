namespace WindowsApplication1
{
    partial class FormControl
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
            this.label_TPSSimulation = new System.Windows.Forms.Label();
            this.textBox_TPSSimulation = new System.Windows.Forms.TextBox();
            this.textBox_PhaseCur = new System.Windows.Forms.TextBox();
            this.label_PhaseCur = new System.Windows.Forms.Label();
            this.textBox_AngleWrite = new System.Windows.Forms.TextBox();
            this.label_AngleWrite = new System.Windows.Forms.Label();
            this.textBox_Duty = new System.Windows.Forms.TextBox();
            this.label_Duty = new System.Windows.Forms.Label();
            this.button_EMS = new System.Windows.Forms.Button();
            this.checkBox_TPSSimulation = new System.Windows.Forms.CheckBox();
            this.checkBox_PhaseCur = new System.Windows.Forms.CheckBox();
            this.checkBox_Duty = new System.Windows.Forms.CheckBox();
            this.checkBox_AngleWrite = new System.Windows.Forms.CheckBox();
            this.button_Confirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_TPSSimulation
            // 
            this.label_TPSSimulation.AutoSize = true;
            this.label_TPSSimulation.Location = new System.Drawing.Point(32, 44);
            this.label_TPSSimulation.Name = "label_TPSSimulation";
            this.label_TPSSimulation.Size = new System.Drawing.Size(74, 12);
            this.label_TPSSimulation.TabIndex = 0;
            this.label_TPSSimulation.Text = "TPSSimulation";
            // 
            // textBox_TPSSimulation
            // 
            this.textBox_TPSSimulation.Location = new System.Drawing.Point(139, 41);
            this.textBox_TPSSimulation.Name = "textBox_TPSSimulation";
            this.textBox_TPSSimulation.Size = new System.Drawing.Size(100, 22);
            this.textBox_TPSSimulation.TabIndex = 1;
            // 
            // textBox_PhaseCur
            // 
            this.textBox_PhaseCur.Location = new System.Drawing.Point(139, 95);
            this.textBox_PhaseCur.Name = "textBox_PhaseCur";
            this.textBox_PhaseCur.Size = new System.Drawing.Size(100, 22);
            this.textBox_PhaseCur.TabIndex = 3;
            // 
            // label_PhaseCur
            // 
            this.label_PhaseCur.AutoSize = true;
            this.label_PhaseCur.Location = new System.Drawing.Point(32, 98);
            this.label_PhaseCur.Name = "label_PhaseCur";
            this.label_PhaseCur.Size = new System.Drawing.Size(55, 12);
            this.label_PhaseCur.TabIndex = 2;
            this.label_PhaseCur.Text = "Phase Cur.";
            // 
            // textBox_AngleWrite
            // 
            this.textBox_AngleWrite.Location = new System.Drawing.Point(139, 207);
            this.textBox_AngleWrite.Name = "textBox_AngleWrite";
            this.textBox_AngleWrite.Size = new System.Drawing.Size(100, 22);
            this.textBox_AngleWrite.TabIndex = 7;
            // 
            // label_AngleWrite
            // 
            this.label_AngleWrite.AutoSize = true;
            this.label_AngleWrite.Location = new System.Drawing.Point(32, 210);
            this.label_AngleWrite.Name = "label_AngleWrite";
            this.label_AngleWrite.Size = new System.Drawing.Size(59, 12);
            this.label_AngleWrite.TabIndex = 6;
            this.label_AngleWrite.Text = "AngleWrite";
            // 
            // textBox_Duty
            // 
            this.textBox_Duty.Location = new System.Drawing.Point(139, 153);
            this.textBox_Duty.Name = "textBox_Duty";
            this.textBox_Duty.Size = new System.Drawing.Size(100, 22);
            this.textBox_Duty.TabIndex = 5;
            // 
            // label_Duty
            // 
            this.label_Duty.AutoSize = true;
            this.label_Duty.Location = new System.Drawing.Point(32, 156);
            this.label_Duty.Name = "label_Duty";
            this.label_Duty.Size = new System.Drawing.Size(28, 12);
            this.label_Duty.TabIndex = 4;
            this.label_Duty.Text = "Duty";
            // 
            // button_EMS
            // 
            this.button_EMS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.button_EMS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button_EMS.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_EMS.ForeColor = System.Drawing.Color.White;
            this.button_EMS.Location = new System.Drawing.Point(24, 279);
            this.button_EMS.Name = "button_EMS";
            this.button_EMS.Size = new System.Drawing.Size(205, 92);
            this.button_EMS.TabIndex = 10;
            this.button_EMS.Text = "EmergencyStop";
            this.button_EMS.UseVisualStyleBackColor = false;
            // 
            // checkBox_TPSSimulation
            // 
            this.checkBox_TPSSimulation.AutoSize = true;
            this.checkBox_TPSSimulation.Location = new System.Drawing.Point(313, 41);
            this.checkBox_TPSSimulation.Name = "checkBox_TPSSimulation";
            this.checkBox_TPSSimulation.Size = new System.Drawing.Size(93, 16);
            this.checkBox_TPSSimulation.TabIndex = 11;
            this.checkBox_TPSSimulation.Text = "TPSSimulation";
            this.checkBox_TPSSimulation.UseVisualStyleBackColor = true;
            this.checkBox_TPSSimulation.CheckedChanged += new System.EventHandler(this.checkBox_TPSSimulation_CheckedChanged);
            // 
            // checkBox_PhaseCur
            // 
            this.checkBox_PhaseCur.AutoSize = true;
            this.checkBox_PhaseCur.Location = new System.Drawing.Point(313, 98);
            this.checkBox_PhaseCur.Name = "checkBox_PhaseCur";
            this.checkBox_PhaseCur.Size = new System.Drawing.Size(74, 16);
            this.checkBox_PhaseCur.TabIndex = 12;
            this.checkBox_PhaseCur.Text = "Phase Cur.";
            this.checkBox_PhaseCur.UseVisualStyleBackColor = true;
            this.checkBox_PhaseCur.CheckedChanged += new System.EventHandler(this.checkBox_PhaseCur_CheckedChanged);
            // 
            // checkBox_Duty
            // 
            this.checkBox_Duty.AutoSize = true;
            this.checkBox_Duty.Location = new System.Drawing.Point(313, 153);
            this.checkBox_Duty.Name = "checkBox_Duty";
            this.checkBox_Duty.Size = new System.Drawing.Size(47, 16);
            this.checkBox_Duty.TabIndex = 13;
            this.checkBox_Duty.Text = "Duty";
            this.checkBox_Duty.UseVisualStyleBackColor = true;
            this.checkBox_Duty.CheckedChanged += new System.EventHandler(this.checkBox_Duty_CheckedChanged);
            // 
            // checkBox_AngleWrite
            // 
            this.checkBox_AngleWrite.AutoSize = true;
            this.checkBox_AngleWrite.Location = new System.Drawing.Point(313, 210);
            this.checkBox_AngleWrite.Name = "checkBox_AngleWrite";
            this.checkBox_AngleWrite.Size = new System.Drawing.Size(78, 16);
            this.checkBox_AngleWrite.TabIndex = 14;
            this.checkBox_AngleWrite.Text = "AngleWrite";
            this.checkBox_AngleWrite.UseVisualStyleBackColor = true;
            this.checkBox_AngleWrite.CheckedChanged += new System.EventHandler(this.checkBox_AngleWrite_CheckedChanged);
            // 
            // button_Confirm
            // 
            this.button_Confirm.BackColor = System.Drawing.Color.Yellow;
            this.button_Confirm.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Confirm.Location = new System.Drawing.Point(282, 300);
            this.button_Confirm.Name = "button_Confirm";
            this.button_Confirm.Size = new System.Drawing.Size(124, 52);
            this.button_Confirm.TabIndex = 16;
            this.button_Confirm.Text = "Confirm";
            this.button_Confirm.UseVisualStyleBackColor = false;
            this.button_Confirm.Click += new System.EventHandler(this.button_Confirm_Click);
            // 
            // FormControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 416);
            this.Controls.Add(this.button_Confirm);
            this.Controls.Add(this.checkBox_AngleWrite);
            this.Controls.Add(this.checkBox_Duty);
            this.Controls.Add(this.checkBox_PhaseCur);
            this.Controls.Add(this.checkBox_TPSSimulation);
            this.Controls.Add(this.button_EMS);
            this.Controls.Add(this.textBox_AngleWrite);
            this.Controls.Add(this.label_AngleWrite);
            this.Controls.Add(this.textBox_Duty);
            this.Controls.Add(this.label_Duty);
            this.Controls.Add(this.textBox_PhaseCur);
            this.Controls.Add(this.label_PhaseCur);
            this.Controls.Add(this.textBox_TPSSimulation);
            this.Controls.Add(this.label_TPSSimulation);
            this.Name = "FormControl";
            this.Text = "FormControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_TPSSimulation;
        private System.Windows.Forms.TextBox textBox_TPSSimulation;
        private System.Windows.Forms.TextBox textBox_PhaseCur;
        private System.Windows.Forms.Label label_PhaseCur;
        private System.Windows.Forms.TextBox textBox_AngleWrite;
        private System.Windows.Forms.Label label_AngleWrite;
        private System.Windows.Forms.TextBox textBox_Duty;
        private System.Windows.Forms.Label label_Duty;
        private System.Windows.Forms.Button button_EMS;
        private System.Windows.Forms.CheckBox checkBox_TPSSimulation;
        private System.Windows.Forms.CheckBox checkBox_PhaseCur;
        private System.Windows.Forms.CheckBox checkBox_Duty;
        private System.Windows.Forms.CheckBox checkBox_AngleWrite;
        private System.Windows.Forms.Button button_Confirm;
    }
}