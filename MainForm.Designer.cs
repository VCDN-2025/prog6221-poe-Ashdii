namespace CyberAwarenessBotGUI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl = new TabControl();
            tabChat = new TabPage();
            chatHistory = new ListBox();
            userInput = new TextBox();
            btnSend = new Button();
            tabTasks = new TabPage();
            btnCompleteTask = new Button();
            btnDeleteTask = new Button();
            taskListView = new ListView();
            columnTitle = new ColumnHeader();
            columnDescription = new ColumnHeader();
            columnDueDate = new ColumnHeader();
            columnStatus = new ColumnHeader();
            btnAddTask = new Button();
            cmbReminder = new ComboBox();
            txtTaskDescription = new TextBox();
            txtTaskTitle = new TextBox();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            tabQuiz = new TabPage();
            quizPanel = new Panel();
            btnCloseQuiz = new Button();
            btnSubmitAnswer = new Button();
            lblFeedback = new Label();
            pnlOptions = new Panel();
            lblQuestion = new Label();
            btnStartQuiz = new Button();
            tabActivity = new TabPage();
            btnRefreshLog = new Button();
            activityList = new ListBox();
            tabControl.SuspendLayout();
            tabChat.SuspendLayout();
            tabTasks.SuspendLayout();
            tabQuiz.SuspendLayout();
            quizPanel.SuspendLayout();
            tabActivity.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabChat);
            tabControl.Controls.Add(tabTasks);
            tabControl.Controls.Add(tabQuiz);
            tabControl.Controls.Add(tabActivity);
            tabControl.Dock = DockStyle.Fill;
            tabControl.Location = new Point(0, 0);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(786, 611);
            tabControl.TabIndex = 0;
            // 
            // tabChat
            // 
            tabChat.Controls.Add(chatHistory);
            tabChat.Controls.Add(userInput);
            tabChat.Controls.Add(btnSend);
            tabChat.Location = new Point(4, 29);
            tabChat.Name = "tabChat";
            tabChat.Padding = new Padding(3);
            tabChat.Size = new Size(778, 578);
            tabChat.TabIndex = 0;
            tabChat.Text = "Chat";
            // 
            // chatHistory
            // 
            chatHistory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            chatHistory.FormattingEnabled = true;
            chatHistory.Location = new Point(5, 6);
            chatHistory.Name = "chatHistory";
            chatHistory.Size = new Size(768, 484);
            chatHistory.TabIndex = 0;
            // 
            // userInput
            // 
            userInput.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            userInput.Location = new Point(5, 496);
            userInput.Multiline = true;
            userInput.Name = "userInput";
            userInput.Size = new Size(680, 71);
            userInput.TabIndex = 1;
            userInput.KeyPress += userInput_KeyPress;
            // 
            // btnSend
            // 
            btnSend.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnSend.Location = new Point(690, 496);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(84, 71);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // tabTasks
            // 
            tabTasks.Controls.Add(btnCompleteTask);
            tabTasks.Controls.Add(btnDeleteTask);
            tabTasks.Controls.Add(taskListView);
            tabTasks.Controls.Add(btnAddTask);
            tabTasks.Controls.Add(cmbReminder);
            tabTasks.Controls.Add(txtTaskDescription);
            tabTasks.Controls.Add(txtTaskTitle);
            tabTasks.Controls.Add(label3);
            tabTasks.Controls.Add(label2);
            tabTasks.Controls.Add(label1);
            tabTasks.Location = new Point(4, 29);
            tabTasks.Name = "tabTasks";
            tabTasks.Padding = new Padding(3);
            tabTasks.Size = new Size(778, 578);
            tabTasks.TabIndex = 1;
            tabTasks.Text = "Tasks";
            // 
            // btnCompleteTask
            // 
            btnCompleteTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCompleteTask.Location = new Point(599, 526);
            btnCompleteTask.Name = "btnCompleteTask";
            btnCompleteTask.Size = new Size(174, 41);
            btnCompleteTask.TabIndex = 9;
            btnCompleteTask.Text = "Mark Completed";
            btnCompleteTask.UseVisualStyleBackColor = true;
            btnCompleteTask.Click += btnCompleteTask_Click;
            // 
            // btnDeleteTask
            // 
            btnDeleteTask.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnDeleteTask.Location = new Point(7, 526);
            btnDeleteTask.Name = "btnDeleteTask";
            btnDeleteTask.Size = new Size(174, 41);
            btnDeleteTask.TabIndex = 8;
            btnDeleteTask.Text = "Delete Task";
            btnDeleteTask.UseVisualStyleBackColor = true;
            btnDeleteTask.Click += btnDeleteTask_Click;
            // 
            // taskListView
            // 
            taskListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            taskListView.Columns.AddRange(new ColumnHeader[] { columnTitle, columnDescription, columnDueDate, columnStatus });
            taskListView.Location = new Point(7, 139);
            taskListView.Name = "taskListView";
            taskListView.Size = new Size(767, 381);
            taskListView.TabIndex = 7;
            taskListView.UseCompatibleStateImageBehavior = false;
            taskListView.View = View.Details;
            // 
            // columnTitle
            // 
            columnTitle.Text = "Title";
            columnTitle.Width = 150;
            // 
            // columnDescription
            // 
            columnDescription.Text = "Description";
            columnDescription.Width = 200;
            // 
            // columnDueDate
            // 
            columnDueDate.Text = "Due Date";
            columnDueDate.Width = 100;
            // 
            // columnStatus
            // 
            columnStatus.Text = "Status";
            columnStatus.Width = 80;
            // 
            // btnAddTask
            // 
            btnAddTask.Location = new Point(523, 95);
            btnAddTask.Name = "btnAddTask";
            btnAddTask.Size = new Size(251, 38);
            btnAddTask.TabIndex = 6;
            btnAddTask.Text = "Add Task";
            btnAddTask.UseVisualStyleBackColor = true;
            btnAddTask.Click += btnAddTask_Click;
            // 
            // cmbReminder
            // 
            cmbReminder.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbReminder.FormattingEnabled = true;
            cmbReminder.Items.AddRange(new object[] { "No reminder", "1 day", "3 days", "7 days", "Custom date" });
            cmbReminder.Location = new Point(100, 95);
            cmbReminder.Name = "cmbReminder";
            cmbReminder.Size = new Size(417, 28);
            cmbReminder.TabIndex = 5;
            // 
            // txtTaskDescription
            // 
            txtTaskDescription.Location = new Point(100, 52);
            txtTaskDescription.Name = "txtTaskDescription";
            txtTaskDescription.Size = new Size(673, 27);
            txtTaskDescription.TabIndex = 4;
            // 
            // txtTaskTitle
            // 
            txtTaskTitle.Location = new Point(100, 10);
            txtTaskTitle.Name = "txtTaskTitle";
            txtTaskTitle.Size = new Size(673, 27);
            txtTaskTitle.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(7, 98);
            label3.Name = "label3";
            label3.Size = new Size(76, 20);
            label3.TabIndex = 2;
            label3.Text = "Reminder:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(7, 55);
            label2.Name = "label2";
            label2.Size = new Size(88, 20);
            label2.TabIndex = 1;
            label2.Text = "Description:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(7, 13);
            label1.Name = "label1";
            label1.Size = new Size(41, 20);
            label1.TabIndex = 0;
            label1.Text = "Title:";
            // 
            // tabQuiz
            // 
            tabQuiz.Controls.Add(quizPanel);
            tabQuiz.Controls.Add(btnStartQuiz);
            tabQuiz.Location = new Point(4, 29);
            tabQuiz.Name = "tabQuiz";
            tabQuiz.Size = new Size(778, 578);
            tabQuiz.TabIndex = 2;
            tabQuiz.Text = "Quiz";
            // 
            // quizPanel
            // 
            quizPanel.Controls.Add(btnCloseQuiz);
            quizPanel.Controls.Add(btnSubmitAnswer);
            quizPanel.Controls.Add(lblFeedback);
            quizPanel.Controls.Add(pnlOptions);
            quizPanel.Controls.Add(lblQuestion);
            quizPanel.Dock = DockStyle.Fill;
            quizPanel.Location = new Point(0, 0);
            quizPanel.Name = "quizPanel";
            quizPanel.Size = new Size(778, 578);
            quizPanel.TabIndex = 1;
            quizPanel.Visible = false;
            // 
            // btnCloseQuiz
            // 
            btnCloseQuiz.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnCloseQuiz.Location = new Point(667, 527);
            btnCloseQuiz.Name = "btnCloseQuiz";
            btnCloseQuiz.Size = new Size(100, 39);
            btnCloseQuiz.TabIndex = 4;
            btnCloseQuiz.Text = "Close Quiz";
            btnCloseQuiz.UseVisualStyleBackColor = true;
            // 
            // btnSubmitAnswer
            // 
            btnSubmitAnswer.Anchor = AnchorStyles.Bottom;
            btnSubmitAnswer.Location = new Point(340, 527);
            btnSubmitAnswer.Name = "btnSubmitAnswer";
            btnSubmitAnswer.Size = new Size(100, 39);
            btnSubmitAnswer.TabIndex = 3;
            btnSubmitAnswer.Text = "Submit";
            btnSubmitAnswer.UseVisualStyleBackColor = true;
            btnSubmitAnswer.Visible = false;
            // 
            // lblFeedback
            // 
            lblFeedback.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblFeedback.Location = new Point(18, 405);
            lblFeedback.Name = "lblFeedback";
            lblFeedback.Size = new Size(742, 119);
            lblFeedback.TabIndex = 2;
            // 
            // pnlOptions
            // 
            pnlOptions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlOptions.AutoScroll = true;
            pnlOptions.Location = new Point(8, 281);
            pnlOptions.Name = "pnlOptions";
            pnlOptions.Size = new Size(742, 121);
            pnlOptions.TabIndex = 1;
            // 
            // lblQuestion
            // 
            lblQuestion.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblQuestion.Location = new Point(18, 20);
            lblQuestion.Name = "lblQuestion";
            lblQuestion.Size = new Size(742, 57);
            lblQuestion.TabIndex = 0;
            lblQuestion.Text = "Question will appear here";
            lblQuestion.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnStartQuiz
            // 
            btnStartQuiz.Anchor = AnchorStyles.None;
            btnStartQuiz.Location = new Point(340, 267);
            btnStartQuiz.Name = "btnStartQuiz";
            btnStartQuiz.Size = new Size(100, 39);
            btnStartQuiz.TabIndex = 0;
            btnStartQuiz.Text = "Start Quiz";
            btnStartQuiz.UseVisualStyleBackColor = true;
            // 
            // tabActivity
            // 
            tabActivity.Controls.Add(btnRefreshLog);
            tabActivity.Controls.Add(activityList);
            tabActivity.Location = new Point(4, 29);
            tabActivity.Name = "tabActivity";
            tabActivity.Size = new Size(778, 578);
            tabActivity.TabIndex = 3;
            tabActivity.Text = "Activity Log";
            // 
            // btnRefreshLog
            // 
            btnRefreshLog.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRefreshLog.Location = new Point(638, 526);
            btnRefreshLog.Name = "btnRefreshLog";
            btnRefreshLog.Size = new Size(133, 41);
            btnRefreshLog.TabIndex = 1;
            btnRefreshLog.Text = "Refresh Log";
            btnRefreshLog.UseVisualStyleBackColor = true;
            // 
            // activityList
            // 
            activityList.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            activityList.FormattingEnabled = true;
            activityList.Location = new Point(7, 8);
            activityList.Name = "activityList";
            activityList.Size = new Size(765, 504);
            activityList.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(786, 611);
            Controls.Add(tabControl);
            Name = "MainForm";
            Text = "Cybersecurity Awareness Chatbot";
            Load += MainForm_Load;
            tabControl.ResumeLayout(false);
            tabChat.ResumeLayout(false);
            tabChat.PerformLayout();
            tabTasks.ResumeLayout(false);
            tabTasks.PerformLayout();
            tabQuiz.ResumeLayout(false);
            quizPanel.ResumeLayout(false);
            tabActivity.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabChat;
        private System.Windows.Forms.TabPage tabTasks;
        private System.Windows.Forms.TabPage tabQuiz;
        private System.Windows.Forms.TabPage tabActivity;
        private System.Windows.Forms.ListBox chatHistory;
        private System.Windows.Forms.TextBox userInput;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.ComboBox cmbReminder;
        private System.Windows.Forms.TextBox txtTaskDescription;
        private System.Windows.Forms.TextBox txtTaskTitle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStartQuiz;
        private System.Windows.Forms.Panel quizPanel;
        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Panel pnlOptions;
        private System.Windows.Forms.Label lblFeedback;
        private System.Windows.Forms.Button btnSubmitAnswer;
        private System.Windows.Forms.ListView taskListView;
        private System.Windows.Forms.ColumnHeader columnTitle;
        private System.Windows.Forms.ColumnHeader columnDescription;
        private System.Windows.Forms.ColumnHeader columnDueDate;
        private System.Windows.Forms.ColumnHeader columnStatus;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnCompleteTask;
        private System.Windows.Forms.ListBox activityList;
        private System.Windows.Forms.Button btnRefreshLog;
        private System.Windows.Forms.Button btnCloseQuiz;
    }
}