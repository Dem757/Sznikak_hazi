namespace MultiThreadedApp
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pTarget = new Panel();
            bBike1 = new Button();
            bStart = new Button();
            bBike2 = new Button();
            bBike3 = new Button();
            pStart = new Panel();
            bStep1 = new Button();
            pDepo = new Panel();
            bStep2 = new Button();
            bFinish = new Button();
            SuspendLayout();
            // 
            // pTarget
            // 
            pTarget.BackColor = Color.LightSteelBlue;
            pTarget.Location = new Point(625, 25);
            pTarget.Name = "pTarget";
            pTarget.Size = new Size(163, 246);
            pTarget.TabIndex = 0;
            // 
            // bBike1
            // 
            bBike1.Font = new Font("Webdings", 32F, FontStyle.Regular, GraphicsUnit.Point);
            bBike1.Location = new Point(12, 25);
            bBike1.Name = "bBike1";
            bBike1.Size = new Size(121, 78);
            bBike1.TabIndex = 1;
            bBike1.Text = "b";
            bBike1.UseVisualStyleBackColor = true;
            bBike1.Click += Bike_Click;
            // 
            // bStart
            // 
            bStart.Location = new Point(12, 302);
            bStart.Name = "bStart";
            bStart.Size = new Size(121, 34);
            bStart.TabIndex = 2;
            bStart.Text = "Start";
            bStart.UseVisualStyleBackColor = true;
            bStart.Click += bStart_Click;
            // 
            // bBike2
            // 
            bBike2.Font = new Font("Webdings", 32F, FontStyle.Regular, GraphicsUnit.Point);
            bBike2.Location = new Point(12, 109);
            bBike2.Name = "bBike2";
            bBike2.Size = new Size(121, 78);
            bBike2.TabIndex = 3;
            bBike2.Text = "b";
            bBike2.UseVisualStyleBackColor = true;
            bBike2.Click += Bike_Click;
            // 
            // bBike3
            // 
            bBike3.Font = new Font("Webdings", 32F, FontStyle.Regular, GraphicsUnit.Point);
            bBike3.Location = new Point(12, 193);
            bBike3.Name = "bBike3";
            bBike3.Size = new Size(121, 78);
            bBike3.TabIndex = 4;
            bBike3.Text = "b";
            bBike3.UseVisualStyleBackColor = true;
            bBike3.Click += Bike_Click;
            // 
            // pStart
            // 
            pStart.BackColor = Color.SlateGray;
            pStart.Location = new Point(204, 25);
            pStart.Name = "pStart";
            pStart.Size = new Size(144, 246);
            pStart.TabIndex = 5;
            // 
            // bStep1
            // 
            bStep1.Location = new Point(204, 302);
            bStep1.Name = "bStep1";
            bStep1.Size = new Size(144, 34);
            bStep1.TabIndex = 6;
            bStep1.Text = "Step1";
            bStep1.UseVisualStyleBackColor = true;
            bStep1.Click += bStep1_Click;
            // 
            // pDepo
            // 
            pDepo.BackColor = Color.LightSkyBlue;
            pDepo.Location = new Point(413, 25);
            pDepo.Name = "pDepo";
            pDepo.Size = new Size(145, 246);
            pDepo.TabIndex = 7;
            // 
            // bStep2
            // 
            bStep2.Location = new Point(413, 302);
            bStep2.Name = "bStep2";
            bStep2.Size = new Size(145, 34);
            bStep2.TabIndex = 8;
            bStep2.Text = "Step2";
            bStep2.UseVisualStyleBackColor = true;
            bStep2.Click += bStep2_Click;
            // 
            // bFinish
            // 
            bFinish.Location = new Point(625, 302);
            bFinish.Name = "bFinish";
            bFinish.Size = new Size(163, 34);
            bFinish.TabIndex = 9;
            bFinish.UseVisualStyleBackColor = true;
            bFinish.Click += bFinish_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 355);
            Controls.Add(bStep2);
            Controls.Add(bStep1);
            Controls.Add(bBike3);
            Controls.Add(bBike2);
            Controls.Add(bStart);
            Controls.Add(bBike1);
            Controls.Add(pTarget);
            Controls.Add(pStart);
            Controls.Add(pDepo);
            Controls.Add(bFinish);
            Name = "MainForm";
            Text = "Tour de France";
            Load += MainForm_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel pTarget;
        private Button bBike1;
        private Button bStart;
        private Button bBike2;
        private Button bBike3;
        private Panel pStart;
        private Button bStep1;
        private Panel pDepo;
        private Button bStep2;
        private Button bFinish;
    }
}