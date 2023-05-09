
namespace cad_dev_winforms
{
    partial class MainForm
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
            this.openGLControl = new SharpGL.OpenGLControl();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonPrimitives = new System.Windows.Forms.Button();
            this.buttonSTL = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).BeginInit();
            this.SuspendLayout();
            // 
            // openGLControl
            // 
            this.openGLControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openGLControl.DrawFPS = true;
            this.openGLControl.Location = new System.Drawing.Point(12, 41);
            this.openGLControl.Name = "openGLControl";
            this.openGLControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.openGLControl.RenderContextType = SharpGL.RenderContextType.DIBSection;
            this.openGLControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.openGLControl.Size = new System.Drawing.Size(631, 621);
            this.openGLControl.TabIndex = 0;
            this.openGLControl.Load += new System.EventHandler(this.openGLControl_Load);
            this.openGLControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseDown);
            this.openGLControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseMove);
            this.openGLControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.openGLControl_MouseUp);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(12, 12);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(75, 23);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "Сброс";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonPrimitives
            // 
            this.buttonPrimitives.Location = new System.Drawing.Point(121, 12);
            this.buttonPrimitives.Name = "buttonPrimitives";
            this.buttonPrimitives.Size = new System.Drawing.Size(75, 23);
            this.buttonPrimitives.TabIndex = 2;
            this.buttonPrimitives.Text = "Примитивы";
            this.buttonPrimitives.UseVisualStyleBackColor = true;
            this.buttonPrimitives.Click += new System.EventHandler(this.buttonPrimitives_Click);
            // 
            // buttonSTL
            // 
            this.buttonSTL.Location = new System.Drawing.Point(202, 12);
            this.buttonSTL.Name = "buttonSTL";
            this.buttonSTL.Size = new System.Drawing.Size(75, 23);
            this.buttonSTL.TabIndex = 3;
            this.buttonSTL.Text = "STL";
            this.buttonSTL.UseVisualStyleBackColor = true;
            this.buttonSTL.Click += new System.EventHandler(this.buttonSTL_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 674);
            this.Controls.Add(this.buttonSTL);
            this.Controls.Add(this.buttonPrimitives);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.openGLControl);
            this.Name = "MainForm";
            this.Text = "CAD Development";
            ((System.ComponentModel.ISupportInitialize)(this.openGLControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl openGLControl;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonPrimitives;
        private System.Windows.Forms.Button buttonSTL;
    }
}

