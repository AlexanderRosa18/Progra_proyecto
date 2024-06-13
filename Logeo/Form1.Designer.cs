namespace Logeo
{
    partial class Login
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.txt1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt2 = new System.Windows.Forms.Label();
            this.btnAdmin = new FontAwesome.Sharp.IconButton();
            this.btnUsuario = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // txt1
            // 
            this.txt1.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt1.Location = new System.Drawing.Point(189, 126);
            this.txt1.Name = "txt1";
            this.txt1.Size = new System.Drawing.Size(79, 40);
            this.txt1.TabIndex = 0;
            this.txt1.Text = "ADMIN";
            this.txt1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txt1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.Font = new System.Drawing.Font("Impact", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(198, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(425, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "BIENVENIDO AL PROGRAMA!";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // txt2
            // 
            this.txt2.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.txt2.Location = new System.Drawing.Point(487, 126);
            this.txt2.Name = "txt2";
            this.txt2.Size = new System.Drawing.Size(106, 40);
            this.txt2.TabIndex = 2;
            this.txt2.Text = "USUARIO";
            this.txt2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.txt2.Click += new System.EventHandler(this.btnUsuario_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnAdmin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdmin.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnAdmin.IconColor = System.Drawing.Color.Black;
            this.btnAdmin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAdmin.Location = new System.Drawing.Point(173, 169);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(104, 48);
            this.btnAdmin.TabIndex = 3;
            this.btnAdmin.Text = "Entrar";
            this.btnAdmin.UseVisualStyleBackColor = false;
            // 
            // btnUsuario
            // 
            this.btnUsuario.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnUsuario.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUsuario.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnUsuario.IconColor = System.Drawing.Color.Black;
            this.btnUsuario.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUsuario.Location = new System.Drawing.Point(489, 169);
            this.btnUsuario.Name = "btnUsuario";
            this.btnUsuario.Size = new System.Drawing.Size(104, 48);
            this.btnUsuario.TabIndex = 4;
            this.btnUsuario.Text = "Entrar";
            this.btnUsuario.UseVisualStyleBackColor = false;
            this.btnUsuario.Click += new System.EventHandler(this.btnUsuario_Click_1);
            // 
            // iconButton1
            // 
            this.iconButton1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.iconButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.Location = new System.Drawing.Point(325, 343);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(104, 48);
            this.iconButton1.TabIndex = 5;
            this.iconButton1.Text = "Salir";
            this.iconButton1.UseVisualStyleBackColor = false;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(766, 450);
            this.Controls.Add(this.iconButton1);
            this.Controls.Add(this.btnUsuario);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.txt2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sesión";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label txt1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt2;
        private FontAwesome.Sharp.IconButton btnAdmin;
        private FontAwesome.Sharp.IconButton btnUsuario;
        private FontAwesome.Sharp.IconButton iconButton1;
    }
}

