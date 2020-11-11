using PluginInterface;
using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace MainApp
{
    public partial class MainForm : Form
    {
        private Controller controller;

        public MainForm()
        {
            InitializeComponent();
            controller = new Controller();
            CreatePluginsMenu();
        }

        private void CreatePluginsMenu()
        {
            controller.FindPlugins();
            foreach (var x in controller.plugins.Keys)
            {
                var pluginItem = new ToolStripMenuItem(x, null, OnPluginClick);
                filtersMenu.DropDownItems.Add(pluginItem);
            }
        }

        private void OnPluginClick(object sender, EventArgs args)
        {
            IPlugin plugin = controller.plugins[((ToolStripMenuItem)sender).Text];
            plugin.Transform((Bitmap)pictureBox1.Image);
            pictureBox1.Invalidate();
        }

        private void CFGMenu_Click(object sender, EventArgs e)
        {
           // controller.tryGetDeserialize(openFileDialog);
        }

        private void getListMenu_Click(object sender, EventArgs e)
        {
            controller.getPluginsList();
        }

    }
}
