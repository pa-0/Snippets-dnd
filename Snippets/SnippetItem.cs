using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snippets
{
    public partial class SnippetItem : UserControl
    {
        public static readonly Color BACK_COLOR_DEFAULT = Color.FromArgb(39, 44, 54);
        public static readonly Color BACK_COLOR_HOVER = Color.FromArgb(33, 38, 48);

        public bool hovered = false;
        public Color goalColor = BACK_COLOR_DEFAULT;
        public Color backColor = BACK_COLOR_DEFAULT;

        public string snippetTitle;
        public string snippetPreview;

        public SnippetItem(string snippetTitle, string snippetPreview)
        {
            InitializeComponent();
            this.snippetTitle = snippetTitle;
            this.snippetPreview = snippetPreview;
        }

        private void SnippetItem_Load(object sender, EventArgs e)
        {

        }

        private void HoverStart(object sender, EventArgs e)
        {
            hovered = true;
        }
        private void HoverEnd(object sender, EventArgs e)
        {
            hovered = false;
        }
    }
}
