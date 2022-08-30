namespace WikiApp
{
    
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
                else if(string.IsNullOrEmpty(cmbBox.Text))
                {
                    cmbBox.Focus();
                    cmbBox.BackColor = Color.Red;
                    MessageBox.Show("Select Category from ComboBox");
                }
                else if (!(rdoButtonL.Checked || rdoButtonN.Checked))
                {
                    grpBox.Focus();
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
                if(checkItems())
                {
                    Information inf = new Information();
                    inf.Name = txtInput.Text;
                    inf.Category = cmbBox.Text;

                    if(rdoButtonL.Checked)
                    {
                        inf.Structure = rdoButtonL.Text;
                    }
                    else
                    {
                        inf.Structure = rdoButtonN.Text;
                    }

                    inf.Definition = txtBoxDefinition.Text;

                    Wiki.Add(inf);
                    sizeWiki++;

                    MessageBox.Show("New data added into list");
                }
                else
                {
                    MessageBox.Show("Data wasnt added into list");
                }
            }
            catch(Exception error)
            {
                errorTracing(error);
            }
        }

        private void frm1_Load(object sender, EventArgs e)
        {
            populateComboBox();
        }

        //method to populate combo Box with Categories, from txt file
        private void populateComboBox()
        {
            try
            {
                try
                {
                    StreamReader reader = new StreamReader("Category.txt");
                
                    while (!reader.EndOfStream)
                    {
                        cmbBox.Items.Add(reader.ReadLine());
                    }

                }
                catch(FileLoadException error)
                {
                    errorTracing(error);
                    MessageBox.Show("Unable to load file: Category.txt");
                }
                catch(FileNotFoundException error2)
                {
                    errorTracing(error2);
                    MessageBox.Show("Unable to find file: Category.txt");
                }
            }
            catch(Exception error)
            {
                errorTracing(error);
            }
        }

        private bool validName(string txt)
        {
            return true;
        }
    }
}