namespace master_project
{
    partial class Form2
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea16 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend16 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series16 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.довідкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.щоРобитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.етапиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повернутисьДоГрафікуФіїToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.коефіцієнтиГармToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.амплітудиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fAQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(16, 91);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(396, 596);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Items";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.Width = 235;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.довідкаToolStripMenuItem,
            this.етапиToolStripMenuItem,
            this.fAQToolStripMenuItem,
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1289, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // довідкаToolStripMenuItem
            // 
            this.довідкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.щоРобитиToolStripMenuItem});
            this.довідкаToolStripMenuItem.Name = "довідкаToolStripMenuItem";
            this.довідкаToolStripMenuItem.Size = new System.Drawing.Size(77, 24);
            this.довідкаToolStripMenuItem.Text = "Довідка";
            // 
            // щоРобитиToolStripMenuItem
            // 
            this.щоРобитиToolStripMenuItem.Name = "щоРобитиToolStripMenuItem";
            this.щоРобитиToolStripMenuItem.Size = new System.Drawing.Size(178, 26);
            this.щоРобитиToolStripMenuItem.Text = "Що робити?";
            this.щоРобитиToolStripMenuItem.Click += new System.EventHandler(this.щоРобитиToolStripMenuItem_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(16, 39);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 43);
            this.panel2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(87, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(193, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Середні значення:";
            // 
            // chart1
            // 
            this.chart1.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea16.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea16);
            this.chart1.Cursor = System.Windows.Forms.Cursors.Cross;
            legend16.Name = "Legend1";
            this.chart1.Legends.Add(legend16);
            this.chart1.Location = new System.Drawing.Point(420, 91);
            this.chart1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chart1.Name = "chart1";
            series16.ChartArea = "ChartArea1";
            series16.Legend = "Legend1";
            series16.Name = "Series1";
            this.chart1.Series.Add(series16);
            this.chart1.Size = new System.Drawing.Size(853, 596);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "chart1";
            // 
            // етапиToolStripMenuItem
            // 
            this.етапиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.повернутисьДоГрафікуФіїToolStripMenuItem,
            this.коефіцієнтиГармToolStripMenuItem,
            this.амплітудиToolStripMenuItem});
            this.етапиToolStripMenuItem.Name = "етапиToolStripMenuItem";
            this.етапиToolStripMenuItem.Size = new System.Drawing.Size(54, 26);
            this.етапиToolStripMenuItem.Text = "Етап";
            // 
            // повернутисьДоГрафікуФіїToolStripMenuItem
            // 
            this.повернутисьДоГрафікуФіїToolStripMenuItem.Name = "повернутисьДоГрафікуФіїToolStripMenuItem";
            this.повернутисьДоГрафікуФіїToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.повернутисьДоГрафікуФіїToolStripMenuItem.Text = "0. Графік функції";
            // 
            // коефіцієнтиГармToolStripMenuItem
            // 
            this.коефіцієнтиГармToolStripMenuItem.Name = "коефіцієнтиГармToolStripMenuItem";
            this.коефіцієнтиГармToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.коефіцієнтиГармToolStripMenuItem.Text = "2. Коефіцієнти гармонік";
            // 
            // амплітудиToolStripMenuItem
            // 
            this.амплітудиToolStripMenuItem.Name = "амплітудиToolStripMenuItem";
            this.амплітудиToolStripMenuItem.Size = new System.Drawing.Size(258, 26);
            this.амплітудиToolStripMenuItem.Text = "3. Амплітуди";
            // 
            // fAQToolStripMenuItem
            // 
            this.fAQToolStripMenuItem.Name = "fAQToolStripMenuItem";
            this.fAQToolStripMenuItem.Size = new System.Drawing.Size(50, 24);
            this.fAQToolStripMenuItem.Text = "FAQ";
            // 
            // обрахунокКоефіцієнтівГармонікToolStripMenuItem
            // 
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem.BackColor = System.Drawing.Color.IndianRed;
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem.Name = "обрахунокКоефіцієнтівГармонікToolStripMenuItem";
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem.Size = new System.Drawing.Size(266, 26);
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem.Text = "Обрахунок коефіцієнтів гармонік";
            this.обрахунокКоефіцієнтівГармонікToolStripMenuItem.Click += new System.EventHandler(this.обрахунокКоефіцієнтівГармонікToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(420, 39);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(853, 43);
            this.panel1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(238, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Середні значення періодичної функції:";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.ClientSize = new System.Drawing.Size(1289, 702);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.Shown += new System.EventHandler(this.Form2_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem довідкаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem щоРобитиToolStripMenuItem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.ToolStripMenuItem етапиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem повернутисьДоГрафікуФіїToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem коефіцієнтиГармToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem амплітудиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fAQToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обрахунокКоефіцієнтівГармонікToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}