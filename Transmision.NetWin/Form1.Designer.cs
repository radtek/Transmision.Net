﻿namespace Transmision.NetWin
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnrecepcion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txttda = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.print_qr = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnreimporimir = new System.Windows.Forms.Button();
            this.btnruleta = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "ejecutar ws";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnrecepcion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txttda);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(25, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 140);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Recepcion de Guias";
            // 
            // btnrecepcion
            // 
            this.btnrecepcion.Location = new System.Drawing.Point(58, 102);
            this.btnrecepcion.Name = "btnrecepcion";
            this.btnrecepcion.Size = new System.Drawing.Size(167, 23);
            this.btnrecepcion.TabIndex = 2;
            this.btnrecepcion.Text = "Recepcion de Guia";
            this.btnrecepcion.UseVisualStyleBackColor = true;
            this.btnrecepcion.Click += new System.EventHandler(this.btnrecepcion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Tienda";
            // 
            // txttda
            // 
            this.txttda.Location = new System.Drawing.Point(58, 51);
            this.txttda.Name = "txttda";
            this.txttda.Size = new System.Drawing.Size(100, 20);
            this.txttda.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(197, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "PRINT1 BARRA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(197, 57);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(149, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "PRINT2 BARRA";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(307, 96);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(100, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "Validar/Consumir";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // print_qr
            // 
            this.print_qr.Location = new System.Drawing.Point(293, 158);
            this.print_qr.Name = "print_qr";
            this.print_qr.Size = new System.Drawing.Size(100, 29);
            this.print_qr.TabIndex = 5;
            this.print_qr.Text = "PRINTER QR";
            this.print_qr.UseVisualStyleBackColor = true;
            this.print_qr.Click += new System.EventHandler(this.print_qr_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(396, 31);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(100, 23);
            this.button5.TabIndex = 6;
            this.button5.Text = "Validar/Consumir";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Controls.Add(this.btnreimporimir);
            this.groupBox2.Location = new System.Drawing.Point(428, 62);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Reimpresion de Ticket Retorno";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "123456789101234567";
            // 
            // btnreimporimir
            // 
            this.btnreimporimir.Location = new System.Drawing.Point(64, 54);
            this.btnreimporimir.Name = "btnreimporimir";
            this.btnreimporimir.Size = new System.Drawing.Size(75, 23);
            this.btnreimporimir.TabIndex = 8;
            this.btnreimporimir.Text = "Reimprimir";
            this.btnreimporimir.UseVisualStyleBackColor = true;
            this.btnreimporimir.Click += new System.EventHandler(this.btnreimporimir_Click);
            // 
            // btnruleta
            // 
            this.btnruleta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnruleta.Location = new System.Drawing.Point(513, 187);
            this.btnruleta.Name = "btnruleta";
            this.btnruleta.Size = new System.Drawing.Size(75, 23);
            this.btnruleta.TabIndex = 9;
            this.btnruleta.Text = "RULETA";
            this.btnruleta.UseVisualStyleBackColor = true;
            this.btnruleta.Click += new System.EventHandler(this.btnruleta_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(714, 262);
            this.Controls.Add(this.btnruleta);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.print_qr);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnrecepcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txttda;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button print_qr;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnreimporimir;
        private System.Windows.Forms.Button btnruleta;
    }
}

