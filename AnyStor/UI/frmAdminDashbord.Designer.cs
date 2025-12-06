namespace AnyStor
{
    partial class frmAdminDashbord
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAdminDashbord));
            this.palFooter = new System.Windows.Forms.Panel();
            this.lblDeveloper = new System.Windows.Forms.Label();
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.userToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.productsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dealerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tansactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblUser = new System.Windows.Forms.Label();
            this.lblUserLogign = new System.Windows.Forms.Label();
            this.lblFirstAppName = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblsubHeading = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.palFooter.SuspendLayout();
            this.menuStripTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // palFooter
            // 
            this.palFooter.BackColor = System.Drawing.Color.Teal;
            this.palFooter.Controls.Add(this.lblDeveloper);
            this.palFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.palFooter.Location = new System.Drawing.Point(0, 475);
            this.palFooter.Name = "palFooter";
            this.palFooter.Size = new System.Drawing.Size(1247, 33);
            this.palFooter.TabIndex = 0;
            // 
            // lblDeveloper
            // 
            this.lblDeveloper.AutoSize = true;
            this.lblDeveloper.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeveloper.ForeColor = System.Drawing.Color.White;
            this.lblDeveloper.Location = new System.Drawing.Point(523, 7);
            this.lblDeveloper.Name = "lblDeveloper";
            this.lblDeveloper.Size = new System.Drawing.Size(252, 17);
            this.lblDeveloper.TabIndex = 0;
            this.lblDeveloper.Text = "Develop By: Any Store Stock Management";
            // 
            // menuStripTop
            // 
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userToolStripMenuItem,
            this.categortToolStripMenuItem,
            this.productsToolStripMenuItem,
            this.dealerToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.tansactionsToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(1247, 24);
            this.menuStripTop.TabIndex = 1;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // userToolStripMenuItem
            // 
            this.userToolStripMenuItem.Name = "userToolStripMenuItem";
            this.userToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.userToolStripMenuItem.Text = "User";
            this.userToolStripMenuItem.Click += new System.EventHandler(this.userToolStripMenuItem_Click);
            // 
            // categortToolStripMenuItem
            // 
            this.categortToolStripMenuItem.Name = "categortToolStripMenuItem";
            this.categortToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.categortToolStripMenuItem.Text = "Category";
            this.categortToolStripMenuItem.Click += new System.EventHandler(this.categortToolStripMenuItem_Click);
            // 
            // productsToolStripMenuItem
            // 
            this.productsToolStripMenuItem.Name = "productsToolStripMenuItem";
            this.productsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.productsToolStripMenuItem.Text = "Products";
            this.productsToolStripMenuItem.Click += new System.EventHandler(this.productsToolStripMenuItem_Click);
            // 
            // dealerToolStripMenuItem
            // 
            this.dealerToolStripMenuItem.Name = "dealerToolStripMenuItem";
            this.dealerToolStripMenuItem.Size = new System.Drawing.Size(130, 20);
            this.dealerToolStripMenuItem.Text = "Dealer and Customer";
            this.dealerToolStripMenuItem.Click += new System.EventHandler(this.dealerToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // tansactionsToolStripMenuItem
            // 
            this.tansactionsToolStripMenuItem.Name = "tansactionsToolStripMenuItem";
            this.tansactionsToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.tansactionsToolStripMenuItem.Text = "Tansactions";
            this.tansactionsToolStripMenuItem.Click += new System.EventHandler(this.tansactionsToolStripMenuItem_Click);
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(14, 37);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(42, 17);
            this.lblUser.TabIndex = 2;
            this.lblUser.Text = "User: ";
            // 
            // lblUserLogign
            // 
            this.lblUserLogign.AutoSize = true;
            this.lblUserLogign.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserLogign.ForeColor = System.Drawing.Color.LimeGreen;
            this.lblUserLogign.Location = new System.Drawing.Point(62, 37);
            this.lblUserLogign.Name = "lblUserLogign";
            this.lblUserLogign.Size = new System.Drawing.Size(0, 17);
            this.lblUserLogign.TabIndex = 3;
            // 
            // lblFirstAppName
            // 
            this.lblFirstAppName.AutoSize = true;
            this.lblFirstAppName.Font = new System.Drawing.Font("Arial", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstAppName.Location = new System.Drawing.Point(509, 342);
            this.lblFirstAppName.Name = "lblFirstAppName";
            this.lblFirstAppName.Size = new System.Drawing.Size(125, 56);
            this.lblFirstAppName.TabIndex = 4;
            this.lblFirstAppName.Text = "ANY";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Segoe UI Black", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.Location = new System.Drawing.Point(619, 335);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(182, 65);
            this.lblLastName.TabIndex = 5;
            this.lblLastName.Text = "STROE";
            // 
            // lblsubHeading
            // 
            this.lblsubHeading.AutoSize = true;
            this.lblsubHeading.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblsubHeading.ForeColor = System.Drawing.Color.LightSeaGreen;
            this.lblsubHeading.Location = new System.Drawing.Point(505, 403);
            this.lblsubHeading.Name = "lblsubHeading";
            this.lblsubHeading.Size = new System.Drawing.Size(300, 25);
            this.lblsubHeading.TabIndex = 6;
            this.lblsubHeading.Text = "Billing and Inventry Management";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(536, 145);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(211, 187);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // frmAdminDashbord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1247, 508);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblsubHeading);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.lblFirstAppName);
            this.Controls.Add(this.lblUserLogign);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.palFooter);
            this.Controls.Add(this.menuStripTop);
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "frmAdminDashbord";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin Dashbord";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmAdminDashbord_FormClosed);
            this.Load += new System.EventHandler(this.frmAdminDashbord_Load);
            this.palFooter.ResumeLayout(false);
            this.palFooter.PerformLayout();
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel palFooter;
        private System.Windows.Forms.Label lblDeveloper;
        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem userToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem categortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem productsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tansactionsToolStripMenuItem;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Label lblUserLogign;
        private System.Windows.Forms.Label lblFirstAppName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblsubHeading;
        private System.Windows.Forms.ToolStripMenuItem dealerToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

