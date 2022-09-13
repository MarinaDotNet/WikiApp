using System.IO;
using static System.Net.Mime.MediaTypeNames;

namespace WikiApp
{
    //add on close to save error in file
    //on form load not loads data from file
    public partial class frm1 : Form
    {
        private List<Information> Wiki = new List<Information>();
        private int sizeWiki = -1;

        //List to store all errors during program run
        private List<string> errors = new List<string>();
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
        //if not it focusing on first unfilled item and changing color
        private bool checkItems()
        {
            bool run = false;
            try
            {
                if (string.IsNullOrEmpty(txtInput.Text))
                {
                    txtInput.Focus();
                    txtInput.BackColor = Color.Red;
                    MessageBox.Show("Text Box should not be empty");
                }
                else if (string.IsNullOrEmpty(cmbBox.Text))
                {
                    cmbBox.Focus();
                    cmbBox.BackColor = Color.Red;
                    MessageBox.Show("Select Category from ComboBox");
                }
                else if (!(rdoButtonL.Checked || rdoButtonN.Checked))
                {
                    grpBox.BackColor = Color.Red;
                    MessageBox.Show("Select one in Structure");
                }
                else if (string.IsNullOrEmpty(txtBoxDefinition.Text))
                {
                    txtBoxDefinition.Focus();
                    txtBoxDefinition.BackColor = Color.Red;
                    MessageBox.Show("Deffinition text Box should not be empty");
                }
                else
                {
                    txtInput.BackColor = DefaultBackColor;
                    cmbBox.BackColor = DefaultBackColor;
                    txtBoxDefinition.BackColor = DefaultBackColor;
                    grpBox.BackColor = DefaultBackColor;
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
            //not working
            loadFrom("definition.dat");
            //working
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
            else
            {

                return rdoButtonN.Text;
            }

        }

        //method highlights the selected radioButton
        //for first radioButton selected returns - 0, for second - 1
        private int radioButtonHighlight()
        {
            if (rdoButtonL.Checked)
            {
                rdoButtonL.ForeColor = Color.Red;
                rdoButtonN.ForeColor = Color.Black;
                return 0;
            }
            else
            {
                rdoButtonN.ForeColor = Color.Red;
                rdoButtonL.ForeColor = Color.Black;
                return 1;
            }
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
                    for(int i = 0; i < Wiki.Count - 1; i++)
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
                if(!(string.IsNullOrEmpty(txtInput.Text) || string.IsNullOrEmpty(txtBoxDefinition.Text) || string.IsNullOrEmpty(cmbBox.Text)))
                {
                    int index = lstView.FocusedItem.Index;
                    Wiki[index].Name = txtInput.Text;
                    Wiki[index].Category = cmbBox.Text;
                    Wiki[index].Definition = txtBoxDefinition.Text;
                    Wiki[index].Structure = radioButtonText();

                    lstViewDisplaySort();
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
                    if(radioButton.CompareTo(rdoButtonL.Text) == 0)
                    {
                        rdoButtonL.Checked = true;
                        rdoButtonN.Checked = false;
                    }    
                    else if(radioButton.CompareTo(rdoButtonN.Text) == 0)
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

        
        private void bntSave_Click(object sender, EventArgs e)
        {           
            SaveFileDialog save = new SaveFileDialog();
            DialogResult result = save.ShowDialog();
            
            if(result == DialogResult.OK)
            {
                writeTo(save.FileName);

                MessageBox.Show("File was saved");
            }
            else
            {
                MessageBox.Show("File was not saved");
            }
        }

        //binary search with ignore case, by Data Structure name at Wiki.
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
                        int middle;
                        int low = 0;
                        int high = Wiki.Count - 1;
                        bool run = true;

                        while ((low < high) && run)
                        {
                            middle = (low + high) / 2;

                            if ((Wiki[middle].Name).ToLower().CompareTo((txtSearch.Text).ToLower()) > 0)
                            {
                                high--;
                            }
                            else if ((Wiki[middle].Name).ToLower().CompareTo((txtSearch.Text).ToLower()) < 0)
                            {
                                low++;
                            }
                            else if ((Wiki[middle].Name).ToLower().CompareTo((txtSearch.Text).ToLower()) == 0)
                            {
                                run = false;
                                clearItems();

                                lstView.Focus();
                                lstView.SelectedIndices.Clear();
                                lstView.Items[middle].Selected = true;

                                txtInput.Text = Wiki[middle].Name;
                                cmbBox.Text = Wiki[middle].Category;
                                txtBoxDefinition.Text = Wiki[middle].Definition;

                                if (Wiki[middle].Structure.CompareTo("Linear") == 0)
                                {
                                    rdoButtonL.Checked = true;
                                    rdoButtonN.Checked = false;
                                }
                                else
                                {
                                    rdoButtonL.Checked = false;
                                    rdoButtonN.Checked = true;
                                }

                                radioButtonHighlight();

                                txtSearch.Clear();
                                
                            }
                            if (low == high)
                            {
                                MessageBox.Show("Data was not found");
                                run = false;
                                txtSearch.Clear();
                            }
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
            catch(Exception error)
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
        }

        private void txtInput_DoubleClick(object sender, EventArgs e)
        {
            clearItems();
        }

        
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                var check = MessageBox.Show("By loading from new file previouse data would be deleted. Do you want to continue?",
                        "Loading from File", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (check == DialogResult.Yes)
                {
                    OpenFileDialog open = new OpenFileDialog();
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
            catch(Exception error)
            {
                errorTracing(error);
            }
        }
        
        //load file from user choice
        private void loadFrom(string path)
        {
            try
            {
                if (File.Exists(path))
                {
                    using(BinaryReader br = new BinaryReader(File.OpenRead(path)))
                    {
                        Wiki.Clear();
                        sizeWiki = -1;

                        while(br.BaseStream.Position != br.BaseStream.Length)
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
            catch (Exception error)
            {
                errorTracing(error);
            }
        }

        //saves all data from Wiki into file by user choise
        private void writeTo(string path)
        {
            try
            {                
                using(BinaryWriter bw = new BinaryWriter(File.OpenWrite(path)))
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
            File.WriteAllText("definition.dat", "");

            writeTo("definition.dat");
        }
    }
    
}