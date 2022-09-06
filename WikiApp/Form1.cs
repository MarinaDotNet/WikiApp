namespace WikiApp
{
    //Not sure about radioButtonHighlight() method 6.6
    //Method lstViewDisplaySort() the sort part not correctly working
    //
    public partial class frm1 : Form
    {
        private List<Information> Wiki = new List<Information>();
        private int sizeWiki = -1;

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
                                swap(i, j);
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


        private void swap(int left, int right)
        {
            try
            {
                    Information inf = new Information();

                    inf = Wiki[left];
                    Wiki[left] = Wiki[right];
                    Wiki[right] = inf;
            }
            catch(IndexOutOfRangeException ioorError)
            {
                errorTracing(ioorError);
            }
            catch (IOException ioerror)
            {
                errorTracing(ioerror);
            }

        }

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

        
    }
    
}