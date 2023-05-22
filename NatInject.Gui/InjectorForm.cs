using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace NatInject.Gui
{
    public partial class InjectorForm : Form
    {
        private void RepopulateProcessList()
        {
            ProcessList.Items.Clear();

            foreach (Process process in Process.GetProcesses())
            {
                try
                {
                    string name = process.MainWindowTitle;
                    if (name == string.Empty)
                        name = process.MainModule.ModuleName;

                    string pid = process.Id.ToString();
                    string path = process.MainModule.FileName;

                    ListViewItem item = new ListViewItem(name);
                    item.SubItems.Add(pid);
                    item.SubItems.Add(path);

                    if (!ProcessIconList.Images.ContainsKey(path))
                    {
                        ProcessIconList.Images.Add(path, Icon.ExtractAssociatedIcon(path));
                    }

                    item.ImageKey = path;
                    item.Tag = process;

                    ProcessList.Items.Add(item);
                }
                catch { }
            }
        }

        public InjectorForm()
        {
            InitializeComponent();

            RepopulateProcessList();
        }

        private void RefreshProcessesButton_Click(object sender, EventArgs e)
        {
            RepopulateProcessList();
        }

        private void SelectDllButton_Click(object sender, EventArgs e)
        {
            DialogResult result = SelectDllDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                DllPathTextBox.Text = SelectDllDialog.FileName;
            }
        }

        private void ShowErrorMessage(string text)
        {
            MessageBox.Show(text, "NatInject", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        DllInjector Injector = null;

        private void InjectDllButton_Click(object sender, EventArgs e)
        {
            if (ProcessList.SelectedItems.Count == 0)
            {
                ShowErrorMessage("A running process was not selected");
                return;
            }

            Process process = (Process)ProcessList.SelectedItems[0].Tag;

            try
            {
                if (Injector == null)
                    Injector = new DllInjector();

                Injector.Inject(process, DllPathTextBox.Text);
            }
            catch (Exception exception)
            {
                ShowErrorMessage(exception.Message);
            }
        }
    }
}
