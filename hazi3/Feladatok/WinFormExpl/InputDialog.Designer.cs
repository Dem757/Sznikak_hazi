namespace WinFormExpl
{
    partial class InputDialog
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
            tPath = new TextBox();
            label1 = new Label();
            bOk = new Button();
            bCancel = new Button();
            SuspendLayout();
            // 
            // tPath
            // 
            tPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tPath.Location = new Point(297, 175);
            tPath.Name = "tPath";
            tPath.Size = new Size(150, 31);
            tPath.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(342, 147);
            label1.Name = "label1";
            label1.Size = new Size(46, 25);
            label1.TabIndex = 1;
            label1.Text = "Path";
            // 
            // bOk
            // 
            bOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            bOk.DialogResult = DialogResult.OK;
            bOk.Location = new Point(212, 225);
            bOk.Name = "bOk";
            bOk.Size = new Size(112, 34);
            bOk.TabIndex = 2;
            bOk.Text = "Ok";
            bOk.UseVisualStyleBackColor = true;
            // 
            // bCancel
            // 
            bCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            bCancel.DialogResult = DialogResult.Cancel;
            bCancel.Location = new Point(416, 225);
            bCancel.Name = "bCancel";
            bCancel.Size = new Size(112, 34);
            bCancel.TabIndex = 3;
            bCancel.Text = "Cancel";
            bCancel.UseVisualStyleBackColor = true;
            // 
            // InputDialog
            // 
            AcceptButton = bOk;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = bCancel;
            ClientSize = new Size(800, 450);
            Controls.Add(bCancel);
            Controls.Add(bOk);
            Controls.Add(label1);
            Controls.Add(tPath);
            Name = "InputDialog";
            Text = "InputDialog";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tPath;
        private Label label1;
        private Button bOk;
        private Button bCancel;
    }
}