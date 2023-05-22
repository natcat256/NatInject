namespace NatInject.Gui
{
    partial class InjectorForm
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
            this.components = new System.ComponentModel.Container();
            this.ProcessList = new System.Windows.Forms.ListView();
            this.ProcessId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProcessIconList = new System.Windows.Forms.ImageList(this.components);
            this.ProcessesLabel = new System.Windows.Forms.Label();
            this.RefreshProcessesButton = new System.Windows.Forms.Button();
            this.InjectDllButton = new System.Windows.Forms.Button();
            this.SelectDllDialog = new System.Windows.Forms.OpenFileDialog();
            this.DllPathLabel = new System.Windows.Forms.Label();
            this.DllPathTextBox = new System.Windows.Forms.TextBox();
            this.SelectDllButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProcessList
            // 
            this.ProcessList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProcessName,
            this.ProcessId,
            this.ProcessPath});
            this.ProcessList.FullRowSelect = true;
            this.ProcessList.HideSelection = false;
            this.ProcessList.Location = new System.Drawing.Point(12, 99);
            this.ProcessList.MultiSelect = false;
            this.ProcessList.Name = "ProcessList";
            this.ProcessList.Size = new System.Drawing.Size(512, 192);
            this.ProcessList.SmallImageList = this.ProcessIconList;
            this.ProcessList.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.ProcessList.TabIndex = 0;
            this.ProcessList.UseCompatibleStateImageBehavior = false;
            this.ProcessList.View = System.Windows.Forms.View.Details;
            // 
            // ProcessId
            // 
            this.ProcessId.Text = "PID";
            this.ProcessId.Width = 64;
            // 
            // ProcessName
            // 
            this.ProcessName.Text = "Name";
            this.ProcessName.Width = 224;
            // 
            // ProcessPath
            // 
            this.ProcessPath.Text = "Path";
            this.ProcessPath.Width = 384;
            // 
            // ProcessIconList
            // 
            this.ProcessIconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.ProcessIconList.ImageSize = new System.Drawing.Size(32, 32);
            this.ProcessIconList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // ProcessesLabel
            // 
            this.ProcessesLabel.AutoSize = true;
            this.ProcessesLabel.Location = new System.Drawing.Point(12, 80);
            this.ProcessesLabel.Name = "ProcessesLabel";
            this.ProcessesLabel.Size = new System.Drawing.Size(59, 13);
            this.ProcessesLabel.TabIndex = 1;
            this.ProcessesLabel.Text = "Processes:";
            // 
            // RefreshProcessesButton
            // 
            this.RefreshProcessesButton.Location = new System.Drawing.Point(368, 70);
            this.RefreshProcessesButton.Name = "RefreshProcessesButton";
            this.RefreshProcessesButton.Size = new System.Drawing.Size(75, 23);
            this.RefreshProcessesButton.TabIndex = 2;
            this.RefreshProcessesButton.Text = "Refresh";
            this.RefreshProcessesButton.UseVisualStyleBackColor = true;
            this.RefreshProcessesButton.Click += new System.EventHandler(this.RefreshProcessesButton_Click);
            // 
            // InjectDllButton
            // 
            this.InjectDllButton.Location = new System.Drawing.Point(449, 70);
            this.InjectDllButton.Name = "InjectDllButton";
            this.InjectDllButton.Size = new System.Drawing.Size(75, 23);
            this.InjectDllButton.TabIndex = 3;
            this.InjectDllButton.Text = "Inject";
            this.InjectDllButton.UseVisualStyleBackColor = true;
            this.InjectDllButton.Click += new System.EventHandler(this.InjectDllButton_Click);
            // 
            // SelectDllDialog
            // 
            this.SelectDllDialog.Filter = "Dynamic-Link Library (*.dll)|*.dll";
            // 
            // DllPathLabel
            // 
            this.DllPathLabel.AutoSize = true;
            this.DllPathLabel.Location = new System.Drawing.Point(12, 17);
            this.DllPathLabel.Name = "DllPathLabel";
            this.DllPathLabel.Size = new System.Drawing.Size(55, 13);
            this.DllPathLabel.TabIndex = 4;
            this.DllPathLabel.Text = "DLL Path:";
            // 
            // DllPathTextBox
            // 
            this.DllPathTextBox.Location = new System.Drawing.Point(73, 12);
            this.DllPathTextBox.Name = "DllPathTextBox";
            this.DllPathTextBox.Size = new System.Drawing.Size(370, 20);
            this.DllPathTextBox.TabIndex = 5;
            // 
            // SelectDllButton
            // 
            this.SelectDllButton.Location = new System.Drawing.Point(449, 12);
            this.SelectDllButton.Name = "SelectDllButton";
            this.SelectDllButton.Size = new System.Drawing.Size(75, 23);
            this.SelectDllButton.TabIndex = 6;
            this.SelectDllButton.Text = "Select";
            this.SelectDllButton.UseVisualStyleBackColor = true;
            this.SelectDllButton.Click += new System.EventHandler(this.SelectDllButton_Click);
            // 
            // InjectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 305);
            this.Controls.Add(this.SelectDllButton);
            this.Controls.Add(this.DllPathTextBox);
            this.Controls.Add(this.DllPathLabel);
            this.Controls.Add(this.InjectDllButton);
            this.Controls.Add(this.RefreshProcessesButton);
            this.Controls.Add(this.ProcessesLabel);
            this.Controls.Add(this.ProcessList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "InjectorForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NatInject";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView ProcessList;
        private System.Windows.Forms.ColumnHeader ProcessId;
        private System.Windows.Forms.ColumnHeader ProcessName;
        private System.Windows.Forms.ColumnHeader ProcessPath;
        private System.Windows.Forms.ImageList ProcessIconList;
        private System.Windows.Forms.Label ProcessesLabel;
        private System.Windows.Forms.Button RefreshProcessesButton;
        private System.Windows.Forms.Button InjectDllButton;
        private System.Windows.Forms.OpenFileDialog SelectDllDialog;
        private System.Windows.Forms.Label DllPathLabel;
        private System.Windows.Forms.TextBox DllPathTextBox;
        private System.Windows.Forms.Button SelectDllButton;
    }
}