namespace Broker
{
    partial class Broker
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
            this.label1 = new System.Windows.Forms.Label();
            this.daysCountBox = new System.Windows.Forms.TextBox();
            this.StartButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SumLabel = new System.Windows.Forms.Label();
            this.SchemaLabel = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.IterationLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.startMinerBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Počet dní";
            // 
            // daysCountBox
            // 
            this.daysCountBox.Location = new System.Drawing.Point(106, 52);
            this.daysCountBox.Name = "daysCountBox";
            this.daysCountBox.Size = new System.Drawing.Size(40, 20);
            this.daysCountBox.TabIndex = 1;
            this.daysCountBox.Text = "60";
            // 
            // StartButton
            // 
            this.StartButton.Location = new System.Drawing.Point(242, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(86, 60);
            this.StartButton.TabIndex = 2;
            this.StartButton.Text = "Štart";
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Schéma:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Suma:";
            // 
            // SumLabel
            // 
            this.SumLabel.AutoSize = true;
            this.SumLabel.Location = new System.Drawing.Point(75, 127);
            this.SumLabel.Name = "SumLabel";
            this.SumLabel.Size = new System.Drawing.Size(13, 13);
            this.SumLabel.TabIndex = 5;
            this.SumLabel.Text = "0";
            // 
            // SchemaLabel
            // 
            this.SchemaLabel.AutoSize = true;
            this.SchemaLabel.Location = new System.Drawing.Point(75, 151);
            this.SchemaLabel.Name = "SchemaLabel";
            this.SchemaLabel.Size = new System.Drawing.Size(13, 13);
            this.SchemaLabel.TabIndex = 6;
            this.SchemaLabel.Text = "0";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.StatusLabel.ForeColor = System.Drawing.Color.DodgerBlue;
            this.StatusLabel.Location = new System.Drawing.Point(362, 15);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(80, 24);
            this.StatusLabel.TabIndex = 7;
            this.StatusLabel.Text = "Nečinný";
            // 
            // IterationLabel
            // 
            this.IterationLabel.AutoSize = true;
            this.IterationLabel.Location = new System.Drawing.Point(414, 68);
            this.IterationLabel.Name = "IterationLabel";
            this.IterationLabel.Size = new System.Drawing.Size(13, 13);
            this.IterationLabel.TabIndex = 9;
            this.IterationLabel.Text = "0";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(363, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Iterácia:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(168, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "za deň";
            // 
            // startMinerBox
            // 
            this.startMinerBox.Location = new System.Drawing.Point(106, 12);
            this.startMinerBox.Name = "startMinerBox";
            this.startMinerBox.Size = new System.Drawing.Size(56, 20);
            this.startMinerBox.TabIndex = 11;
            this.startMinerBox.Text = "312";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Začiatočný miner";
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Location = new System.Drawing.Point(414, 108);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(13, 13);
            this.durationLabel.TabIndex = 14;
            this.durationLabel.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(363, 108);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Trvanie:";
            // 
            // Broker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 372);
            this.Controls.Add(this.durationLabel);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.startMinerBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.IterationLabel);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.SchemaLabel);
            this.Controls.Add(this.SumLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.daysCountBox);
            this.Controls.Add(this.label1);
            this.Name = "Broker";
            this.Text = "Broker";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox daysCountBox;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label SumLabel;
        private System.Windows.Forms.Label SchemaLabel;
        private System.Windows.Forms.Label StatusLabel;
        private System.Windows.Forms.Label IterationLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox startMinerBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label label8;
    }
}

