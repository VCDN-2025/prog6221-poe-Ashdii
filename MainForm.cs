using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;

namespace CyberAwarenessBotGUI
{
    public partial class MainForm : Form
    {
        private Chatbot chatbot;
        private List<CyberTask> tasks = new List<CyberTask>();
        private List<ActivityLogEntry> activityLog = new List<ActivityLogEntry>();
        private QuizGame quiz;
        private int currentQuestionIndex = -1;
        private int quizScore = 0;
        private System.Windows.Forms.Timer reminderTimer;
        private string userName = "User";

        // Renamed controls to resolve ambiguity
        private ListBox quizOptionsList;
        private Button quizSubmitButton;
        private Button quizCloseButton;

        public MainForm()
        {
            InitializeComponent();

            // Create quiz instance only once
            quiz = new QuizGame();
            Debug.WriteLine($"MainForm created quiz with {quiz.Questions.Count} questions");

            // Get user name using a custom dialog
            using (var nameDialog = new UserNameDialog())
            {
                if (nameDialog.ShowDialog() == DialogResult.OK)
                {
                    userName = nameDialog.UserName;
                    if (string.IsNullOrWhiteSpace(userName))
                        userName = "User";
                }
                else
                {
                    userName = "User";
                }
            }

            InitializeBotComponents();
            SetupUI();
            StartReminderTimer();
            PlayGreetingAndWelcome();
        }

        private void InitializeBotComponents()
        {
            chatbot = new Chatbot("CyberAssistant");

            // Don't create a new quiz here - use the existing instance
            Debug.WriteLine($"MainForm has quiz with {quiz.Questions.Count} questions");

            reminderTimer = new System.Windows.Forms.Timer();
            reminderTimer.Interval = 60000; // Check every minute
            reminderTimer.Tick += ReminderTimer_Tick;
        }

        private void SetupUI()
        {
            // Set form properties
            Text = "CyberSecurity Awareness Chatbot";
            BackColor = Color.FromArgb(15, 25, 35);
            Size = new Size(1000, 700);
            MinimumSize = new Size(800, 600);

            // Set control styles
            chatHistory.BackColor = Color.FromArgb(25, 35, 45);
            chatHistory.ForeColor = Color.LightCyan;
            userInput.BackColor = Color.FromArgb(25, 35, 45);
            userInput.ForeColor = Color.White;
            btnSend.BackColor = Color.FromArgb(0, 100, 180);
            btnSend.ForeColor = Color.White;
            btnSend.FlatStyle = FlatStyle.Flat;

            taskListView.BackColor = Color.FromArgb(25, 35, 45);
            taskListView.ForeColor = Color.LightGreen;
            taskListView.FullRowSelect = true;

            activityList.BackColor = Color.FromArgb(25, 35, 45);
            activityList.ForeColor = Color.LightGoldenrodYellow;

            // Setup task list columns
            taskListView.Columns.Add("Title", 150);
            taskListView.Columns.Add("Description", 200);
            taskListView.Columns.Add("Due Date", 100);
            taskListView.Columns.Add("Status", 80);
            taskListView.View = View.Details;

            // ===== QUIZ PANEL SETUP =====
            quizPanel.Dock = DockStyle.Fill;
            quizPanel.BackColor = Color.FromArgb(15, 25, 35);
            quizPanel.Padding = new Padding(20);
            quizPanel.Visible = false;
            quizPanel.BringToFront();

            // Create main table layout for quiz
            TableLayoutPanel quizTable = new TableLayoutPanel();
            quizTable.Dock = DockStyle.Fill;
            quizTable.RowCount = 4;
            quizTable.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Question
            quizTable.RowStyles.Add(new RowStyle(SizeType.Percent, 100)); // Options
            quizTable.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Feedback
            quizTable.RowStyles.Add(new RowStyle(SizeType.AutoSize)); // Buttons
            quizPanel.Controls.Add(quizTable);

            // Add question label
            lblQuestion.Dock = DockStyle.Fill;
            lblQuestion.AutoSize = true;
            lblQuestion.Padding = new Padding(10);
            lblQuestion.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblQuestion.ForeColor = Color.White;
            quizTable.Controls.Add(lblQuestion, 0, 0);
            quizTable.SetColumnSpan(lblQuestion, 2);

            // Create and configure ListBox for quiz options
            quizOptionsList = new ListBox();
            quizOptionsList.Dock = DockStyle.Fill;
            quizOptionsList.BackColor = Color.FromArgb(25, 35, 45);
            quizOptionsList.ForeColor = Color.White;
            quizOptionsList.Font = new Font("Segoe UI", 10);
            quizOptionsList.BorderStyle = BorderStyle.None;
            quizOptionsList.Height = 200;
            quizTable.Controls.Add(quizOptionsList, 0, 1);
            quizTable.SetColumnSpan(quizOptionsList, 2);

            // Add feedback label
            lblFeedback.Dock = DockStyle.Fill;
            lblFeedback.AutoSize = true;
            lblFeedback.Padding = new Padding(10);
            lblFeedback.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            lblFeedback.ForeColor = Color.Lime;
            quizTable.Controls.Add(lblFeedback, 0, 2);
            quizTable.SetColumnSpan(lblFeedback, 2);

            // Create button panel
            Panel buttonPanel = new Panel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.Padding = new Padding(10);
            buttonPanel.Height = 60;
            quizTable.Controls.Add(buttonPanel, 0, 3);
            quizTable.SetColumnSpan(buttonPanel, 2);

            // Initialize and position buttons
            quizSubmitButton = new Button();
            quizSubmitButton.Text = "Submit Answer";
            quizSubmitButton.Size = new Size(120, 35);
            quizSubmitButton.BackColor = Color.FromArgb(0, 100, 180);
            quizSubmitButton.ForeColor = Color.White;
            quizSubmitButton.FlatStyle = FlatStyle.Flat;
            quizSubmitButton.Click += QuizSubmitButton_Click;
            quizSubmitButton.Location = new Point(buttonPanel.Width - 250, 10);

            quizCloseButton = new Button();
            quizCloseButton.Text = "Close Quiz";
            quizCloseButton.Size = new Size(120, 35);
            quizCloseButton.BackColor = Color.FromArgb(180, 50, 50);
            quizCloseButton.ForeColor = Color.White;
            quizCloseButton.FlatStyle = FlatStyle.Flat;
            quizCloseButton.Click += QuizCloseButton_Click;
            quizCloseButton.Location = new Point(buttonPanel.Width - 120, 10);

            // Style quiz elements
            quizPanel.BackColor = Color.FromArgb(15, 25, 35);
            lblQuestion.ForeColor = Color.White;
            lblFeedback.ForeColor = Color.Lime;

            // Style buttons
            btnSubmitAnswer.BackColor = Color.FromArgb(0, 100, 180);
            btnSubmitAnswer.ForeColor = Color.White;
            btnSubmitAnswer.FlatStyle = FlatStyle.Flat;

            btnCloseQuiz.BackColor = Color.FromArgb(180, 50, 50);
            btnCloseQuiz.ForeColor = Color.White;
            btnCloseQuiz.FlatStyle = FlatStyle.Flat;

            btnStartQuiz.BackColor = Color.FromArgb(0, 100, 180);
            btnStartQuiz.ForeColor = Color.White;
            btnStartQuiz.FlatStyle = FlatStyle.Flat;
            btnStartQuiz.Click += (sender, e) => StartQuiz();

            buttonPanel.Controls.Add(quizSubmitButton);
            buttonPanel.Controls.Add(quizCloseButton);

            quizSubmitButton.Visible = true;
            quizCloseButton.Visible = true;
        }

        private void StartReminderTimer()
        {
            reminderTimer.Start();
        }

        private void PlayGreetingAndWelcome()
        {
            try
            {
                // Simulate voice greeting
                AddToChat("Bot: Hello! Welcome to the Cybersecurity Awareness Bot.");

                // Use the actual user name
                AddToChat($"Bot: Welcome, {userName}! I'm here to help you stay safe online.");
                AddToChat("Bot: You can ask me about:");
                AddToChat("Bot: - Passwords");
                AddToChat("Bot: - Phishing");
                AddToChat("Bot: - Privacy");
                AddToChat("Bot: - Hackers");
                AddToChat("Bot: - Malware");
                AddToChat("Bot: Or try adding tasks, taking a quiz, or viewing the activity log!");
            }
            catch
            {
                AddToChat("Bot: Welcome to Cybersecurity Awareness Chatbot!");
            }
        }

        private void ReminderTimer_Tick(object sender, EventArgs e)
        {
            CheckReminders();
        }

        private void CheckReminders()
        {
            foreach (var task in tasks.Where(t => t.DueDate.HasValue && !t.IsCompleted))
            {
                if (DateTime.Now >= task.DueDate.Value)
                {
                    AddToChat($"Bot: ⏰ Reminder! It's time to: {task.Title}");
                    activityLog.Add(new ActivityLogEntry($"Reminder triggered: {task.Title}"));
                    task.IsCompleted = true;
                    UpdateTaskList();
                }
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            ProcessUserInput();
        }

        private void userInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                ProcessUserInput();
                e.Handled = true;
            }
        }

        private void ProcessUserInput()
        {
            string input = userInput.Text.Trim();
            if (string.IsNullOrWhiteSpace(input)) return;

            AddToChat($"{userName}: {input}");
            userInput.Clear();

            // Process NLP commands
            string response = chatbot.ProcessInput(input, tasks, ref activityLog);
            AddToChat($"Bot: {response}");

            // Handle special commands
            if (input.ToLower().Contains("quiz") || input.ToLower().Contains("game"))
            {
                StartQuiz();
            }
            else if (input.ToLower().Contains("task") || input.ToLower().Contains("reminder"))
            {
                tabControl.SelectedTab = tabTasks;
            }
            else if (input.ToLower().Contains("log") || input.ToLower().Contains("activity"))
            {
                tabControl.SelectedTab = tabActivity;
                RefreshActivityLog();
            }
        }

        private void AddToChat(string message)
        {
            chatHistory.Items.Add(message);
            chatHistory.TopIndex = chatHistory.Items.Count - 1;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            string title = txtTaskTitle.Text.Trim();
            string description = txtTaskDescription.Text.Trim();

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Task title is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DateTime? dueDate = null;
            string reminderText = "No reminder";

            if (cmbReminder.SelectedIndex > 0)
            {
                int days = 0;
                switch (cmbReminder.SelectedIndex)
                {
                    case 1: days = 1; break;
                    case 2: days = 3; break;
                    case 3: days = 7; break;
                    case 4:
                        // Simplified date selection for this example
                        dueDate = DateTime.Now.AddDays(14);
                        reminderText = $"Reminder set for {dueDate.Value.ToShortDateString()}";
                        break;
                }

                if (cmbReminder.SelectedIndex != 4 && days > 0)
                {
                    dueDate = DateTime.Now.AddDays(days);
                    reminderText = $"Reminder set for {days} days";
                }
            }

            var task = new CyberTask
            {
                Title = title,
                Description = description,
                DueDate = dueDate
            };

            tasks.Add(task);
            activityLog.Add(new ActivityLogEntry($"Task added: {title} ({reminderText})"));
            UpdateTaskList();

            txtTaskTitle.Clear();
            txtTaskDescription.Clear();
            cmbReminder.SelectedIndex = 0;

            AddToChat($"Bot: Task '{title}' added successfully!");
        }

        private void UpdateTaskList()
        {
            taskListView.Items.Clear();
            foreach (var task in tasks)
            {
                var item = new ListViewItem(task.Title);
                item.SubItems.Add(task.Description);
                item.SubItems.Add(task.DueDate.HasValue ? task.DueDate.Value.ToShortDateString() : "No reminder");
                item.SubItems.Add(task.IsCompleted ? "Completed" : "Pending");
                item.Tag = task;
                taskListView.Items.Add(item);
            }
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (taskListView.SelectedItems.Count == 0) return;

            var task = taskListView.SelectedItems[0].Tag as CyberTask;
            if (task != null)
            {
                tasks.Remove(task);
                activityLog.Add(new ActivityLogEntry($"Task deleted: {task.Title}"));
                UpdateTaskList();
                AddToChat($"Bot: Task '{task.Title}' has been removed");
            }
        }

        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            if (taskListView.SelectedItems.Count == 0) return;

            var task = taskListView.SelectedItems[0].Tag as CyberTask;
            if (task != null)
            {
                task.IsCompleted = true;
                activityLog.Add(new ActivityLogEntry($"Task completed: {task.Title}"));
                UpdateTaskList();
                AddToChat($"Bot: Great job completing '{task.Title}'!");
            }
        }

        private void btnStartQuiz_Click(object sender, EventArgs e)
        {
            StartQuiz();
        }

        private void StartQuiz()
        {
            // Reset quiz state
            currentQuestionIndex = 0;
            quizScore = 0;

            // Verify question count
            if (quiz.Questions == null || quiz.Questions.Count == 0)
            {
                MessageBox.Show("Quiz questions not loaded!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Show debug info
            Debug.WriteLine($"Starting quiz with {quiz.Questions.Count} questions");
            AddToChat($"Bot: Starting quiz with {quiz.Questions.Count} questions");

            // Show quiz UI
            quizPanel.Visible = true;
            quizPanel.BringToFront();
            quizSubmitButton.Visible = true;
            quizSubmitButton.Enabled = true;
            lblFeedback.Text = "";

            // Show first question
            ShowQuestion();
            activityLog.Add(new ActivityLogEntry("Quiz started"));
            AddToChat("Bot: Starting cybersecurity quiz!");
        }

        private void ShowQuestion()
        {
            // Add debug output
            Debug.WriteLine($"Showing question {currentQuestionIndex + 1}/{quiz.Questions.Count}");

            if (currentQuestionIndex < 0 || currentQuestionIndex >= quiz.Questions.Count)
            {
                EndQuiz();
                return;
            }

            var question = quiz.Questions[currentQuestionIndex];
            lblQuestion.Text = question.QuestionText;
            lblFeedback.Text = "";

            quizOptionsList.Items.Clear();
            foreach (var option in question.Options)
            {
                quizOptionsList.Items.Add(option);
            }
            quizOptionsList.SelectedIndex = -1;
        }

        private async void QuizSubmitButton_Click(object sender, EventArgs e)
        {
            if (quizOptionsList.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an answer", "Quiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Add debug output
            Debug.WriteLine($"Submitting answer for question {currentQuestionIndex + 1}");

            // Check answer
            var question = quiz.Questions[currentQuestionIndex];
            bool isCorrect = quizOptionsList.SelectedIndex == question.CorrectAnswerIndex;

            if (isCorrect)
            {
                quizScore++;
                lblFeedback.Text = "✓ Correct! " + question.Explanation;
                lblFeedback.ForeColor = Color.Lime;
            }
            else
            {
                lblFeedback.Text = "✗ Incorrect. " + question.Explanation;
                lblFeedback.ForeColor = Color.OrangeRed;
            }

            // Disable submit button during transition
            quizSubmitButton.Enabled = false;

            // Wait before moving to next question
            await Task.Delay(2500);

            // Move to next question
            currentQuestionIndex++;

            if (currentQuestionIndex < quiz.Questions.Count)
            {
                ShowQuestion();
                quizSubmitButton.Enabled = true;
            }
            else
            {
                EndQuiz();
            }
        }

        private void EndQuiz()
        {
            string result = $"Quiz completed! Score: {quizScore}/{quiz.Questions.Count}";

            if (quizScore == quiz.Questions.Count)
                result += "\nPerfect! You're a cybersecurity expert!";
            else if (quizScore >= quiz.Questions.Count * 0.7)
                result += "\nGreat job! You know your cybersecurity!";
            else
                result += "\nGood effort! Keep learning to stay safe online!";

            lblFeedback.Text = result;
            lblFeedback.ForeColor = quizScore >= quiz.Questions.Count * 0.7 ? Color.Lime : Color.OrangeRed;
            quizSubmitButton.Visible = false;
            activityLog.Add(new ActivityLogEntry($"Quiz completed - Score: {quizScore}/{quiz.Questions.Count}"));
            AddToChat($"Bot: {result}");

            // Debug output
            Debug.WriteLine($"Quiz ended. Score: {quizScore}/{quiz.Questions.Count}");
        }

        private void QuizCloseButton_Click(object sender, EventArgs e)
        {
            quizPanel.Visible = false;
        }

        private void btnRefreshLog_Click(object sender, EventArgs e)
        {
            RefreshActivityLog();
        }

        private void RefreshActivityLog()
        {
            activityList.Items.Clear();
            var recentLogs = activityLog
                .OrderByDescending(log => log.Timestamp)
                .Take(10)
                .Select(log => $"[{log.Timestamp:HH:mm}] {log.Action}");

            foreach (var log in recentLogs)
            {
                activityList.Items.Add(log);
            }
        }

        // Helper classes for the application
        public class Chatbot
        {
            public string Name { get; }

            public Chatbot(string name)
            {
                Name = name;
            }

            public string ProcessInput(string input, List<CyberTask> tasks, ref List<ActivityLogEntry> activityLog)
            {
                string response = "I'm here to help with cybersecurity awareness!";
                activityLog.Add(new ActivityLogEntry($"User asked: {input}"));

                if (input.ToLower().Contains("hello") || input.ToLower().Contains("hi"))
                {
                    response = "Hello! How can I assist you with cybersecurity today?";
                }
                else if (input.ToLower().Contains("thank"))
                {
                    response = "You're welcome! Stay safe online!";
                }
                else if (input.ToLower().Contains("password"))
                {
                    response = "Strong passwords should be at least 12 characters long and include a mix of letters, numbers, and symbols.";
                }
                else if (input.ToLower().Contains("phishing"))
                {
                    response = "Phishing emails often try to create urgency or threaten consequences. Always verify unexpected requests!";
                }
                else if (input.ToLower().Contains("privacy"))
                {
                    response = "Protect your privacy by limiting what you share online and reviewing privacy settings regularly.";
                }

                return response;
            }
        }

        public class CyberTask
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime? DueDate { get; set; }
            public bool IsCompleted { get; set; }
        }

        public class ActivityLogEntry
        {
            public string Action { get; }
            public DateTime Timestamp { get; }

            public ActivityLogEntry(string action)
            {
                Action = action;
                Timestamp = DateTime.Now;
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
    }

    // Renamed to UserNameDialog to avoid conflicts
    public class UserNameDialog : Form
    {
        [System.ComponentModel.DesignerSerializationVisibility(System.ComponentModel.DesignerSerializationVisibility.Hidden)]
        public string UserName { get; private set; } = "User";
        private TextBox txtName;

        public UserNameDialog()
        {
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.Text = "Welcome to CyberSecurity Awareness Bot";
            this.Size = new Size(350, 180);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(15, 25, 35);
            this.Padding = new Padding(20);

            // Create main layout
            var layout = new TableLayoutPanel();
            layout.Dock = DockStyle.Fill;
            layout.RowCount = 3;
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            layout.RowStyles.Add(new RowStyle(SizeType.AutoSize));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 50));
            this.Controls.Add(layout);

            // Add instruction label
            var lblInstruction = new Label();
            lblInstruction.Text = "Please enter your name:";
            lblInstruction.ForeColor = Color.White;
            lblInstruction.Font = new Font("Segoe UI", 10);
            lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            lblInstruction.Dock = DockStyle.Fill;
            layout.Controls.Add(lblInstruction, 0, 0);

            // Add text box
            txtName = new TextBox();
            txtName.Font = new Font("Segoe UI", 10);
            txtName.Text = "User";
            txtName.SelectAll();
            txtName.Dock = DockStyle.Fill;
            txtName.BackColor = Color.FromArgb(25, 35, 45);
            txtName.ForeColor = Color.White;
            layout.Controls.Add(txtName, 0, 1);

            // Add button panel
            var buttonPanel = new FlowLayoutPanel();
            buttonPanel.Dock = DockStyle.Fill;
            buttonPanel.FlowDirection = FlowDirection.RightToLeft;
            layout.Controls.Add(buttonPanel, 0, 2);

            // Add OK button
            var btnOK = new Button();
            btnOK.Text = "OK";
            btnOK.DialogResult = DialogResult.OK;
            btnOK.BackColor = Color.FromArgb(0, 100, 180);
            btnOK.ForeColor = Color.White;
            btnOK.FlatStyle = FlatStyle.Flat;
            btnOK.Size = new Size(80, 30);
            btnOK.Click += (s, e) => { UserName = txtName.Text; this.Close(); };
            buttonPanel.Controls.Add(btnOK);

            // Add Cancel button
            var btnCancel = new Button();
            btnCancel.Text = "Cancel";
            btnCancel.DialogResult = DialogResult.Cancel;
            btnCancel.BackColor = Color.FromArgb(80, 80, 80);
            btnCancel.ForeColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Size = new Size(80, 30);
            buttonPanel.Controls.Add(btnCancel);
        }
    }
}