using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROJETO.models.bases
{
    public class MenuManager
    {
        private Dictionary<string, EventHandler> menuActions;
        private Panel panelMenu;
        private MenuStrip menuStrip;
        private Random random;
        private List<Color> buttonColors;

        public MenuManager(MenuStrip menuStrip, Panel panelMenu)
        {
            this.menuStrip = menuStrip;
            this.panelMenu = panelMenu;
            menuActions = new Dictionary<string, EventHandler>();
            random = new Random();
            buttonColors = new List<Color>
            {
                Color.Gray, Color.DarkGray, Color.Silver, Color.LightGray, Color.DimGray
            };
            CriarMenu();
        }

        private void CriarMenu()
        {
            foreach (ToolStripMenuItem item in menuStrip.Items)
            {
                item.Click += MenuPrincipal_Click;
            }
        }

        private void MenuPrincipal_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                panelMenu.Controls.Clear();
                Panel flowPanel = new Panel
                {
                    Dock = DockStyle.Fill,
                    AutoScroll = true, 
                };

                TableLayoutPanel tableLayoutPanel = new TableLayoutPanel
                {
                    Dock = DockStyle.Top,
                    AutoSize = true,
                    ColumnCount = 3, 
                    RowCount = (menuItem.DropDownItems.Count / 3) + 1,
                    CellBorderStyle = TableLayoutPanelCellBorderStyle.None,
                    AutoScroll = true
                };

                int rowIndex = 0;
                foreach (ToolStripItem subItem in menuItem.DropDownItems)
                {
                    if (subItem is ToolStripMenuItem subMenuItem)
                    {
                        ModernButton btn = CriarBotaoMenu(subMenuItem.Text);

                        if (menuActions.TryGetValue(subMenuItem.Text, out EventHandler action))
                        {
                            btn.Click += action;
                        }
                        else
                        {
                            btn.Click += (s, args) => MessageBox.Show($"Este item está desativado: {subMenuItem.Text}");
                        }

                        tableLayoutPanel.Controls.Add(btn, rowIndex % 3, rowIndex / 3); // Position buttons in 3x4 grid
                        rowIndex++;
                    }
                }

                flowPanel.Controls.Add(tableLayoutPanel);
                panelMenu.Controls.Add(flowPanel);
            }
        }

        private ModernButton CriarBotaoMenu(string texto)
        {
            ModernButton btn = new ModernButton
            {
                Text = texto,
                Width = 200, 
                Height = 60, 
                Margin = new Padding(10),
                HoverColor = Color.Silver, 
                DefaultColor = Color.Gray,
                BorderRadius = 12,
                FlatAppearance =
                {
                    BorderSize = 0,
                    MouseOverBackColor = Color.LightGray, // Slightly lighter gray when hovered
                },
                Font = new Font("Arial", 10, FontStyle.Bold), 
                ForeColor = Color.White, 
                BackColor = Color.SlateGray, 
                TextAlign = ContentAlignment.MiddleCenter, // Center the text
            };

            // Change the color when clicked
            btn.Click += (s, args) =>
            {
                btn.BackColor = buttonColors[random.Next(buttonColors.Count)];
            };

            return btn;
        }

        // Define button actions
        public void DefinirAcoesDosBotoes(Dictionary<string, EventHandler> actions)
        {
            menuActions = actions;
        }
    }
}
