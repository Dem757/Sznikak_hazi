namespace Signals
{
    partial class GraphicsSignalView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            buttonPlus = new Button();
            buttonMinus = new Button();
            SuspendLayout();
            // 
            // buttonPlus
            // 
            buttonPlus.Location = new Point(1, 1);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(21, 24);
            buttonPlus.TabIndex = 0;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = true;
            buttonPlus.Click += buttonPlus_Click;
            // 
            // buttonMinus
            // 
            buttonMinus.Location = new Point(28, 1);
            buttonMinus.Name = "buttonMinus";
            buttonMinus.Size = new Size(20, 24);
            buttonMinus.TabIndex = 1;
            buttonMinus.Text = "-";
            buttonMinus.UseVisualStyleBackColor = true;
            buttonMinus.Click += buttonMinus_Click;
            // 
            // GraphicsSignalView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(buttonMinus);
            Controls.Add(buttonPlus);
            Name = "GraphicsSignalView";
            ResumeLayout(false);
        }

        #endregion

        private Button buttonPlus;
        private Button buttonMinus;
    }
}
