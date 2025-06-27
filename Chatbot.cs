using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CyberAwarenessBotGUI
{
    public class Chatbot
    {
        private string name;

        public Chatbot(string name)
        {
            this.name = name;
        }

        public string ProcessInput(string input, List<CyberTask> tasks, ref List<ActivityLogEntry> activityLog)
        {
            string lowerInput = input.ToLower().Trim();

            // Handle commands first
            if (DetectTaskCommand(lowerInput, out string taskTitle))
            {
                tasks.Add(new CyberTask { Title = taskTitle });
                activityLog.Add(new ActivityLogEntry($"Task added: {taskTitle}"));
                return $"Task '{taskTitle}' added successfully! Would you like to set a reminder?";
            }

            if (DetectReminderCommand(lowerInput, tasks, out string reminderTask, out DateTime? dueDate))
            {
                activityLog.Add(new ActivityLogEntry($"Reminder set for: {reminderTask}"));
                return $"Reminder set for '{reminderTask}' on {dueDate.Value.ToShortDateString()}";
            }

            if (lowerInput.Contains("activity log") || lowerInput.Contains("what have you done"))
            {
                var recentActions = activityLog
                    .TakeLast(5)
                    .Select(log => log.Action);
                return "Recent actions:\n" + string.Join("\n", recentActions);
            }

            // Check for exact keyword matches
            foreach (var keyword in ResponseBank.KeywordResponses.Keys)
            {
                if (lowerInput.Equals(keyword))
                {
                    return ResponseBank.GetRandomResponse(keyword);
                }
            }

            // Check for synonyms and partial matches
            foreach (var keyword in ResponseBank.KeywordResponses.Keys)
            {
                if (lowerInput.Contains(keyword))
                {
                    return ResponseBank.GetRandomResponse(keyword);
                }

                foreach (var synonym in ResponseBank.KeywordSynonyms)
                {
                    if (synonym.Value == keyword && lowerInput.Contains(synonym.Key))
                    {
                        return ResponseBank.GetRandomResponse(keyword);
                    }
                }
            }

            // Greetings and general responses
            if (lowerInput.Contains("hello") || lowerInput.Contains("hi"))
                return "Hello there! How can I help with cybersecurity today?";

            if (lowerInput.Contains("how are you"))
                return "I'm running securely! Ready to help you stay safe online.";

            if (lowerInput.Contains("thank"))
                return "You're welcome! Stay vigilant online!";

            // Improved fallback with suggestions
            string topics = string.Join(", ", ResponseBank.KeywordResponses.Keys);
            return $"I can help with: {topics}. Which cybersecurity topic interests you?";
        }

        private bool DetectTaskCommand(string input, out string taskTitle)
        {
            taskTitle = "";
            var patterns = new[]
            {
                @"add task (?:to )?(.+)",
                @"create task (?:for )?(.+)",
                @"remind me to (.+)",
                @"i need to (.+)",
                @"set a? ?reminder for (.+)"
            };

            foreach (var pattern in patterns)
            {
                var match = Regex.Match(input, pattern);
                if (match.Success)
                {
                    taskTitle = match.Groups[1].Value.Trim();
                    return true;
                }
            }
            return false;
        }

        private bool DetectReminderCommand(string input, List<CyberTask> tasks, out string taskTitle, out DateTime? dueDate)
        {
            taskTitle = "";
            dueDate = null;

            // Try to parse date
            if (input.Contains("tomorrow"))
            {
                dueDate = DateTime.Now.AddDays(1);
            }
            else if (input.Contains("next week"))
            {
                dueDate = DateTime.Now.AddDays(7);
            }
            else
            {
                // Try to parse number of days
                var dayMatch = Regex.Match(input, @"(\d+) days?");
                if (dayMatch.Success)
                {
                    int days = int.Parse(dayMatch.Groups[1].Value);
                    dueDate = DateTime.Now.AddDays(days);
                }
            }

            if (dueDate == null) return false;

            // Find matching task
            foreach (var task in tasks)
            {
                if (input.Contains(task.Title.ToLower()))
                {
                    taskTitle = task.Title;
                    task.DueDate = dueDate;
                    return true;
                }
            }

            return false;
        }
    }
}