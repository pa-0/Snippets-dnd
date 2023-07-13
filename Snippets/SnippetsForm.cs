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
    public partial class SnippetsForm : Form
    {
        readonly Snippets snippets;
        const int MIN_HEIGHT = 120;
        const int MAX_HEIGHT = 480;

        public int SnippetListFullHeight
        {
            get
            {
                int height = 0;
                for (int i = 0; i < snippetList.Items.Count; i++)
                    height += (snippetList.Items[i] as SnippetItem)?.Height ?? 0;
                return height;
            }
        }


        public SnippetsForm(Snippets snippets)
        {
            InitializeComponent();
            this.snippets = snippets;

            PopulateList();
            SetHeight();
        }
        public void SetHeight()
        {
            int requestedHeight = SnippetListFullHeight;
            Height = Math.Clamp(requestedHeight, MIN_HEIGHT, MAX_HEIGHT);
        }
        public void PopulateList()
        {
            Dictionary<string, SnippetsDataObject> snippets = this.snippets.snippets;

            List<string> keysToBePopulated = new List<string>(snippets.Count);
            keysToBePopulated.AddRange(snippets.Keys);

            // dispose and wipe ones that no longer exist. 
            int numberOfItems = snippets.Count;
            for (int i = numberOfItems - 1; i >= 0; i--)
            {
                object element = snippetList.Items[i];
                SnippetItem item = (SnippetItem)element;
                string keyOfElement = item.SnippetTitle;

                if (snippets.ContainsKey(keyOfElement))
                {
                    keysToBePopulated.Remove(keyOfElement);
                    continue;
                }

                (snippetList.Items[i] as SnippetItem)?.Dispose();
                snippetList.Items.RemoveAt(i);
                continue;
            }

            // create the element(s) that are now needed.
            foreach (string key in keysToBePopulated)
            {
                SnippetsDataObject dataObject = snippets[key];
                SnippetItem item = new SnippetItem(key, dataObject);
                snippetList.Items.Add(item);
            }
        }
    }
}
