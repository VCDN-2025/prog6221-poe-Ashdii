using System.Drawing;
using System.Windows.Forms;

namespace CyberAwarenessBotGUI
{
    public class NameInputDialog : Form
    {
        public string UserName { get; private set; }
        private TextBox txtName;
        private Button btnOK;

        public NameInputDialog()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Form settings
            Text = "Welcome";
            Size = new Size(300, 150);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterScreen;
            BackColor = Color.FromArgb(30, 40, 50);
            MinimizeBox = false;
            MaximizeBox = false;

            // Prompt label
            Label lblPrompt = new Label();
            lblPrompt.Text = "Please enter your name:";
            lblPrompt.ForeColor = Color.White;
            lblPrompt.Location = new Point(20, 20);
            lblPrompt.AutoSize = true;

            // Name textbox
            txtName = new TextBox();
            txtName.Location = new Point(20, 50);
            txtName.Size = new Size(250, 20);

            // OK button
            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.Location = new Point(100, 90);
            btnOK.Size = new Size(80, 30);
            btnOK.Click += (s, e) =>
            {
                if (!string.IsNullOrWhiteSpace(txtName.Text))
                {
                    UserName = txtName.Text;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Please enter your name", "Input Required",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            };

            // Add controls
            Controls.Add(lblPrompt);
            Controls.Add(txtName);
            Controls.Add(btnOK);

            AcceptButton = btnOK;
        }
    }
}