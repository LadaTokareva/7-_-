namespace Laba7
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gbProvider = new System.Windows.Forms.GroupBox();
            this.dgvProviders = new System.Windows.Forms.DataGridView();
            this.Delivery = new System.Windows.Forms.GroupBox();
            this.dgvDelivery = new System.Windows.Forms.DataGridView();
            this.Shops = new System.Windows.Forms.GroupBox();
            this.dgvShops = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvCity = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gbProvider.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProviders)).BeginInit();
            this.Delivery.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivery)).BeginInit();
            this.Shops.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvShops)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCity)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gbProvider);
            this.splitContainer1.Panel1.Controls.Add(this.Delivery);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.Shops);
            this.splitContainer1.Size = new System.Drawing.Size(1262, 485);
            this.splitContainer1.SplitterDistance = 246;
            this.splitContainer1.TabIndex = 0;
            // 
            // gbProvider
            // 
            this.gbProvider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbProvider.Controls.Add(this.dgvProviders);
            this.gbProvider.Location = new System.Drawing.Point(8, 4);
            this.gbProvider.Name = "gbProvider";
            this.gbProvider.Size = new System.Drawing.Size(622, 234);
            this.gbProvider.TabIndex = 0;
            this.gbProvider.TabStop = false;
            this.gbProvider.Text = "Providers";
            // 
            // dgvProviders
            // 
            this.dgvProviders.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProviders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProviders.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvProviders.Location = new System.Drawing.Point(3, 18);
            this.dgvProviders.Name = "dgvProviders";
            this.dgvProviders.RowTemplate.Height = 24;
            this.dgvProviders.Size = new System.Drawing.Size(616, 213);
            this.dgvProviders.TabIndex = 0;
            this.dgvProviders.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dqvProviders_RowValidating);
            this.dgvProviders.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvProviders_UserDeletingRow);
            // 
            // Delivery
            // 
            this.Delivery.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Delivery.Controls.Add(this.dgvDelivery);
            this.Delivery.Location = new System.Drawing.Point(636, 3);
            this.Delivery.Name = "Delivery";
            this.Delivery.Size = new System.Drawing.Size(621, 235);
            this.Delivery.TabIndex = 0;
            this.Delivery.TabStop = false;
            this.Delivery.Text = "Delivery";
            // 
            // dgvDelivery
            // 
            this.dgvDelivery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDelivery.Location = new System.Drawing.Point(3, 18);
            this.dgvDelivery.Name = "dgvDelivery";
            this.dgvDelivery.RowTemplate.Height = 24;
            this.dgvDelivery.Size = new System.Drawing.Size(615, 214);
            this.dgvDelivery.TabIndex = 0;
            this.dgvDelivery.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDelivery_RowValidating);
            this.dgvDelivery.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvDelivery_UserDeletingRow);
            // 
            // Shops
            // 
            this.Shops.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.Shops.Controls.Add(this.dgvShops);
            this.Shops.Location = new System.Drawing.Point(11, 3);
            this.Shops.Name = "Shops";
            this.Shops.Size = new System.Drawing.Size(619, 220);
            this.Shops.TabIndex = 1;
            this.Shops.TabStop = false;
            this.Shops.Text = "Shops";
            // 
            // dgvShops
            // 
            this.dgvShops.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvShops.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvShops.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvShops.Location = new System.Drawing.Point(3, 18);
            this.dgvShops.Name = "dgvShops";
            this.dgvShops.RowTemplate.Height = 24;
            this.dgvShops.Size = new System.Drawing.Size(613, 199);
            this.dgvShops.TabIndex = 0;
            this.dgvShops.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvShops_RowValidating);
            this.dgvShops.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvShops_UserDeletingRow);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.dgvCity);
            this.groupBox1.Location = new System.Drawing.Point(636, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(614, 220);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "City";
            // 
            // dgvCity
            // 
            this.dgvCity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCity.Location = new System.Drawing.Point(3, 18);
            this.dgvCity.Name = "dgvCity";
            this.dgvCity.RowTemplate.Height = 24;
            this.dgvCity.Size = new System.Drawing.Size(608, 199);
            this.dgvCity.TabIndex = 0;
            this.dgvCity.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvCity_RowValidating);
            this.dgvCity.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.dgvCity_UserDeletingRow);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 485);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gbProvider.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvProviders)).EndInit();
            this.Delivery.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDelivery)).EndInit();
            this.Shops.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvShops)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox Delivery;
        private System.Windows.Forms.DataGridView dgvDelivery;
        private System.Windows.Forms.GroupBox gbProvider;
        private System.Windows.Forms.DataGridView dgvProviders;
        private System.Windows.Forms.GroupBox Shops;
        private System.Windows.Forms.DataGridView dgvShops;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvCity;
    }
}

