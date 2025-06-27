using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace CyberAwarenessBotGUI
{
    public class DatePickerDialog : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DateTime SelectedDate { get; private set; } = DateTime.Now.AddDays(1);

        private DateTimePicker dtpDate;
        private Button btnOK;
        private Button btnCancel;

        public DatePickerDialog()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Form settings
            Text = "Select Reminder Date";
            Size = new Size(300, 150);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MinimizeBox = false;
            MaximizeBox = false;

            // Date picker
            dtpDate = new DateTimePicker();
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.MinDate = DateTime.Now.AddDays(1);
            dtpDate.Value = DateTime.Now.AddDays(1);
            dtpDate.Location = new Point(20, 20);
            dtpDate.Width = 200;

            // OK button
            btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.Location = new Point(50, 60);
            btnOK.Size = new Size(80, 30);

            // Cancel button
            btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.Location = new Point(150, 60);
            btnCancel.Size = new Size(80, 30);

            // Add controls
            Controls.Add(dtpDate);
            Controls.Add(btnOK);
            Controls.Add(btnCancel);

            AcceptButton = btnOK;
            CancelButton = btnCancel;
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                SelectedDate = dtpDate.Value;
            }
            base.OnFormClosing(e);
        }
    }
}