using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace WikiApp
{
    //check if needs last else in method radioButtonText() ~ line198
    public partial class frm1 : Form
    {
        private static string path = "definition.bin";
        private static List<Information> Wiki = new List<Information>();
        private int sizeWiki = -1;

        //List to store all errors during program run
        private static List<string> errors = new List<string>();
        public frm1()
        {
            InitializeComponent();
        }

        //method for error tracing
        //adds all errors in list and Status Strip Bar
        private void errorTracing(Exception error)
        {
            MessageBox.Show("Error: " + error);
            errors.Add(DateTime.Now.ToString() + " : " + error.ToString());

            stsStrip.Items.Clear();
            drpBoxButton.DropDownItems.Clear();
            stsStrip.Items.Add(drpBoxButton);

            for (int i = 0; i < errors.Count; i++)
            {
                drpBoxButton.DropDownItems.Add(errors[i]);
            }

            stsStrip.Items.Add(errors[errors.Count - 1]);
        }

        //method checks if there all appropriate items in Form has been filled
        //if not it focusing on first unfilled item
        private bool checkItems()
        {
            bool run = false;
            try
            {
                if (string.IsNullOrEmpty(txtInput.Text))
                {
                    txtInput.Focus();
                    MessageBox.Show("Text Box should not be empty");
                }
                else if (string.IsNullOrEmpty(cmbBox.Text))
                {
                    cmbBox.Focus();
                    MessageBox.Show("Select Category from ComboBox");
                }
                else if (!(rdoButtonL.Checked || rdoButtonN.Checked))
                {
                    MessageBox.Show("Select one in Structure");

                }
                else if (string.IsNullOrEmpty(txtBoxDefinition.Text))
                {
                    txtBoxDefinition.Focus();
                    MessageBox.Show("Deffinition text Box should not be empty");
                }
                else
                {
                    run = true;

                }

            }
            catch (Exception error)
            {
                errorTracing(error);
            }

            return run;
        }

        //method adds new data into List Wiki
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (checkItems() && validName(txtInput.Text))
                {
                    Information inf = new Information();
                    inf.Name = txtInput.Text;
                    inf.Category = cmbBox.Text;

                    inf.Structure = radioButtonText();

                    inf.Definition = txtBoxDefinition.Text;

                    Wiki.Add(inf);
                    sizeWiki++;

                    MessageBox.Show("New data added into list");

                    lstViewDisplaySort();
                }
                else
                {
                    MessageBox.Show("Data wasnt added into list");
                    if (!validName(txtInput.Text))
                    {
                        MessageBox.Show("Dublicate input: '" + txtInput.Text + "' alreade exists");
                    }
                }
            }
            catch (IOException ioeError)
            {
                errorTracing(ioeError);
            }
            catch (Exception error)
            {
                errorTracing(error);
            }
        }

        private void frm1_Load(object sender, EventArgs e)
        {
            loadFrom(path);
            lstViewDisplaySort();

            populateComboBox();
        }

        //method to populate combo Box with Categories, from txt file
        //if file Category.txt not exists its creating new file Category.txt and fills it with data
        private void populateComboBox()
        {
            try
            {
                if (File.Exists("Category.txt"))
                {
                    using (BinaryReader br = new BinaryReader(File.OpenRead("Category.txt")))
                    {
                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            cmbBox.Items.Add(br.ReadString());
                        }
                        br.Close();
                    }
                }
                else
                {
                    using (BinaryWriter bw = new BinaryWriter(File.OpenWrite("Category.txt")))
                    {
                        bw.Flush();

                        bw.Write("Array");
                        bw.Write("List");
                        bw.Write("Tree");
                        bw.Write("Graphs");
                        bw.Write("Abstract");
                        bw.Write("Hash");

                        bw.Close();
                    }

                    using (BinaryReader br = new BinaryReader(File.OpenRead("Category.txt")))
                    {
                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            cmbBox.Items.Add(br.ReadString());
                        }
                        br.Close();
                    }
                }
            }
            catch (FileFormatException ffeError)
            {
                errorTracing(ffeError);
            }
            catch (FileLoadException fleError)
            {
                errorTracing(fleError);
            }
            catch (FieldAccessException faeError)
            {
                errorTracing(faeError);
            }
            catch (IOException ioeError)
            {
                errorTracing(ioeError);
            }
        }

        //method checks for dublicates in Wiki List by Name
        private bool validName(string txt)
        {
            return !Wiki.Exists(x => x.Name == txt);
        }

        //method return text of sellected radio button
        private string radioButtonText()
        {
            if (radioButtonHighlight() == 0)
            {

                return rdoButtonL.Text;
            }
            else if (radioButtonHighlight() == 1)
            {

                return rdoButtonN.Text;
            }
            else
            {
                MessageBox.Show("Structure was not found");
                return "Structure was not found";
            }

        }

        //method highlights the selected radioButton
        //for first radioButton selected returns - 0, for second - 1
        private int radioButtonHighlight()
        {
            int index = -1;

            foreach (var rdButton in grpBox.Controls.OfType<RadioButton>())
            {
                if (rdButton.Checked)
                {
                    rdButton.ForeColor = Color.Red;
                    index = grpBox.Controls.GetChildIndex(rdButton);
                }
                else
                {
                    rdButton.ForeColor = Color.Black;
                }

            }
            return index;
        }

        private void rdoButtonL_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonHighlight();
        }

        private void rdoButtonN_CheckedChanged(object sender, EventArgs e)
        {
            radioButtonHighlight();
        }

        //method reloads and sorts all data from List Wiki into List View
        private void lstViewDisplaySort()
        {
            try
            {
                lstView.View = View.Details;

                //sort
                if (Wiki.Count > 1)
                {
                    for (int i = 0; i < Wiki.Count - 1; i++)
                    {
                        for (int j = i + 1; j < Wiki.Count; j++)
                        {
                            if (string.Compare((Wiki[i].Name.ToString()),
                                (Wiki[j].Name.ToString())) > 0)
                            {
                                Information inf = new Information();

                                inf = Wiki[i];
                                Wiki[i] = Wiki[j];
                                Wiki[j] = inf;
                            }
                        }
                    }
                }


                //display
                if (Wiki.Count > 0)
                {
                    lstView.Items.Clear();
                    for (int i = 0; i < Wiki.Count; i++)
                    {
                        ListViewItem item = new ListViewItem(Wiki[i].Name);
                        item.SubItems.Add(Wiki[i].Category);
                        lstView.Items.Add(item);
                    }
                }
            }
            catch (InvalidOperationException ioeError)
            {
                errorTracing(ioeError);
            }
            catch (ArgumentException aeError)
            {
                errorTracing(aeError);
            }
            catch (IndexOutOfRangeException ioorError)
            {
                errorTracing(ioorError);
            }
            catch (IOException error)
            {
                errorTracing(error);
            }
        }

        //deletes data from Wiki and reloads lstView
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstView.SelectedItems.Count > 0)
                {
                    var check = MessageBox.Show("The data would be deleted, you want to countinue?",
                        "Deliting Data", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (check == DialogResult.Yes)
                    {
                        int index = lstView.FocusedItem.Index;

                        Wiki.RemoveAt(index);

                        sizeWiki--;

                        lstViewDisplaySort();
                    }
                    else
                    {
                        MessageBox.Show("The deliting was canceled");
                    }
                }
                else
                {
                    MessageBox.Show("Select in List View data to delete it");
                }
            }
            catch (IOException ioeError)
            {
                errorTracing(ioeError);
            }
        }

        //edits the selected data at lstView in Wiki
        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!(string.IsNullOrEmpty(txtInput.Text) || string.IsNullOrEmpty(txtBoxDefinition.Text) || string.IsNullOrEmpty(cmbBox.Text)))
                {
                    int index = lstView.FocusedItem.Index;
                    Wiki[index].Name = txtInput.Text;
                    Wiki[index].Category = cmbBox.Text;
                    Wiki[index].Definition = txtBoxDefinition.Text;
                    Wiki[index].Structure = radioButtonText();

                    lstViewDisplaySort();

                    clearItems();
                }
                else
                {
                    MessageBox.Show("To Edite data select it from List View");
                }
            }
            catch (IOException ioeError)
            {
                errorTracing(ioeError);
            }
        }

        //when data selected in lstView all information displaying in the related components (txtFields, rdoButtons and etc.)
        private void lstView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lstView.SelectedItems.Count > 0)
                {
                    int index = lstView.FocusedItem.Index;
                    txtInput.Text = Wiki[index].Name;
                    txtBoxDefinition.Text = Wiki[index].Definition;
                    cmbBox.Text = Wiki[index].Category;

                    string radioButton = Wiki[index].Structure;
                    if (radioButton.CompareTo(rdoButtonL.Text) == 0)
                    {
                        rdoButtonL.Checked = true;
                        rdoButtonN.Checked = false;
                    }
                    else if (radioButton.CompareTo(rdoButtonN.Text) == 0)
                    {
                        rdoButtonN.Checked = true;
                        rdoButtonL.Checked = false;
                    }
                    else
                    {
                        MessageBox.Show("Data for Structure was not found");
                        rdoButtonN.Checked = false;
                        rdoButtonL.Checked = false;
                    }

                    radioButtonHighlight();
                }

            }
            catch (Exception error)
            {
                errorTracing(error);
            }
        }

        //allows user to save file only in binary format
        private void bntSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "Binary | *.bin";
            save.DefaultExt = "bin";
            DialogResult result = save.ShowDialog();

            if (result == DialogResult.OK)
            {
                writeTo(save.FileName);

                MessageBox.Show("File was saved");
            }
            else
            {
                MessageBox.Show("File was not saved");
            }
        }

        //Built in BinarySearch() 
        //ignore case
        //checks if txtSearch is not empty
        //once data found highlights appropriate line in lstView clmName,
        //and populates related componets(txtFields and etc.) with appropriate data
        //at the end clears txtSearch
        //if data not found shows error message
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Wiki.Count != 0)
                {
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                    {
                        lstViewDisplaySort();

                        List<string> search = new List<string>();

                        for (int i = 0; i < Wiki.Count; i++)
                        {

                            search.Add(Wiki[i].Name.ToString().ToLower());

                        }

                        if (search.BinarySearch(txtSearch.Text.ToLower()) > -1)
                        {
                            //clearing all GUI Form components(txtBoxes, rdoButtons and etc.)
                            clearItems();

                            //selecting the found data in ListView
                            lstView.Focus();
                            lstView.SelectedIndices.Clear();
                            lstView.Items[search.BinarySearch(txtSearch.Text.ToLower())].Selected = true;

                            //populating the components with appropriate data
                            txtInput.Text = Wiki[search.BinarySearch(txtSearch.Text.ToLower())].Name;
                            cmbBox.Text = Wiki[search.BinarySearch(txtSearch.Text.ToLower())].Category;
                            txtBoxDefinition.Text = Wiki[search.BinarySearch(txtSearch.Text.ToLower())].Definition;

                            if (rdoButtonL.Text.CompareTo(Wiki[search.BinarySearch(txtSearch.Text.ToLower())].Structure) == 0)
                            {
                                rdoButtonL.Checked = true;
                                rdoButtonN.Checked = false;
                            }
                            else if (rdoButtonN.Text.CompareTo(Wiki[search.BinarySearch(txtSearch.Text.ToLower())].Structure) == 0)
                            {
                                rdoButtonL.Checked = false;
                                rdoButtonN.Checked = true;
                            }
                            else
                            {
                                rdoButtonL.Checked = false;
                                rdoButtonN.Checked = false;
                                MessageBox.Show("The Structure for :'" + txtInput.Text + "'\nDefinition Name was not found");
                            }

                            radioButtonHighlight();

                            txtSearch.Clear();
                        }
                        else
                        {
                            MessageBox.Show("The data: '" + txtSearch.Text + "' was not found");
                            txtSearch.Clear();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Enter something for Search in txt Box");
                        txtSearch.Focus();
                    }

                }
                else
                {
                    MessageBox.Show("There no data for search in List View, first add some data");
                }
            }

            catch (ArgumentException arError)
            {
                errorTracing(arError);
            }
            catch (Exception error)
            {
                errorTracing(error);
            }
        }

        //method clears and resets the components
        private void clearItems()
        {
            txtInput.Clear();
            txtBoxDefinition.Clear();
            cmbBox.Text = "";
            rdoButtonL.Checked = false;
            rdoButtonL.ForeColor = DefaultForeColor;
            rdoButtonN.Checked = false;
            rdoButtonN.ForeColor = DefaultForeColor;

            lstView.Focus();
            lstView.SelectedIndices.Clear();

            txtInput.BackColor = Color.White;
            txtBoxDefinition.BackColor = Color.White;
            cmbBox.BackColor = Color.White;
        }

        private void txtInput_DoubleClick(object sender, EventArgs e)
        {
            clearItems();
        }

        //load file from user choice
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var check = MessageBox.Show("By loading from new file previouse data would be deleted. Do you want to continue?",
                        "Loading from File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    OpenFileDialog open = new OpenFileDialog();
                    open.Filter = "Binary | *.bin";
                    open.DefaultExt = "bin";
                    DialogResult result = open.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        loadFrom(open.FileName);

                        lstView.Items.Clear();

                        lstViewDisplaySort();
                        MessageBox.Show("Data was loaded");
                    }
                }

            }
            catch (FileFormatException ffeError)
            {
                errorTracing(ffeError);
            }
            catch (FileLoadException fleError)
            {
                errorTracing(fleError);
            }
            catch (FieldAccessException faeError)
            {
                errorTracing(faeError);
            }
            catch (IOException ioeError)
            {
                errorTracing(ioeError);
            }
        }

        //loads default file
        private void loadFrom(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using (BinaryReader br = new BinaryReader(File.OpenRead(path)))
                    {
                        Wiki.Clear();
                        sizeWiki = -1;

                        while (br.BaseStream.Position != br.BaseStream.Length)
                        {
                            Information inf = new Information();
                            inf.Name = br.ReadString();
                            inf.Category = br.ReadString();
                            inf.Structure = br.ReadString();
                            inf.Definition = br.ReadString();

                            Wiki.Add(inf);
                            sizeWiki++;
                        }

                        br.Close();
                    }
                }
                else
                {
                    MessageBox.Show("File was not found: " + path);
                }
            }
            catch (FileFormatException ffeError)
            {
                errorTracing(ffeError);
            }
            catch (FileLoadException fleError)
            {
                errorTracing(fleError);
            }
            catch (FieldAccessException faeError)
            {
                errorTracing(faeError);
            }
            catch (IOException ioeError)
            {
                errorTracing(ioeError);
            }
        }

        //saves all data from Wiki into file by user choise
        private void writeTo(string path)
        {
            try
            {
                using (BinaryWriter bw = new BinaryWriter(File.OpenWrite(path)))
                {
                    bw.Flush();



                    for (int i = 0; i <= sizeWiki; i++)
                    {
                        bw.Write(Wiki[i].Name);
                        bw.Write(Wiki[i].Category);
                        bw.Write(Wiki[i].Structure);
                        bw.Write(Wiki[i].Definition);
                    }

                    bw.Close();
                }

            }
            catch (Exception error)
            {
                errorTracing(error);
            }
        }

        private void frm1_FormClosed(object sender, FormClosedEventArgs e)
        {
            File.WriteAllText(path, "");

            writeTo(path);
        }
    }

}