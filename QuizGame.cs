using System.Collections.Generic;
using System.Diagnostics;

namespace CyberAwarenessBotGUI
{
    public class QuizGame
    {
        public List<QuizQuestion> Questions { get; set; } = new List<QuizQuestion>();

        public QuizGame()
        {
            Debug.WriteLine("Initializing QuizGame with 10 questions");

            // Add 10 cybersecurity questions
            Questions.Add(new QuizQuestion
            {
                QuestionText = "1. What should you do if you receive an email asking for your password?",
                Options = new List<string> {
                    "Reply with your password",
                    "Delete the email",
                    "Report the email as phishing",
                    "Ignore it"
                },
                CorrectAnswerIndex = 2,
                Explanation = "Reporting phishing emails helps prevent scams and protects others."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "2. Which of these is the strongest password?",
                Options = new List<string> {
                    "password123",
                    "P@ssw0rd!",
                    "Summer2025",
                    "Tr0ub4dor&3"
                },
                CorrectAnswerIndex = 3,
                Explanation = "Long passwords with mixed characters and special symbols are strongest."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "3. What is two-factor authentication?",
                Options = new List<string> {
                    "Using two different passwords",
                    "Verifying identity with two different methods",
                    "Having two security questions",
                    "Using two different antivirus programs"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Two-factor authentication adds an extra layer of security beyond just a password."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "4. What should you do before connecting to public Wi-Fi?",
                Options = new List<string> {
                    "Disable your firewall",
                    "Share sensitive information",
                    "Use a VPN",
                    "Enable file sharing"
                },
                CorrectAnswerIndex = 2,
                Explanation = "A VPN encrypts your connection on public networks, protecting your data."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "5. How often should you update your software?",
                Options = new List<string> {
                    "Only when new features are added",
                    "Once a year",
                    "Never - updates cause problems",
                    "As soon as updates are available"
                },
                CorrectAnswerIndex = 3,
                Explanation = "Software updates often contain critical security patches for vulnerabilities."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "6. What is a common sign of a phishing website?",
                Options = new List<string> {
                    "HTTPS in the URL",
                    "Poor spelling and grammar",
                    "Padlock icon in the address bar",
                    "Professional-looking design"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Phishing sites often have spelling mistakes and poor grammar."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "7. Why should you avoid using the same password for multiple accounts?",
                Options = new List<string> {
                    "It's harder to remember",
                    "It increases vulnerability if one account is compromised",
                    "It slows down login times",
                    "It confuses password managers"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Using unique passwords limits exposure if one account is breached."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "8. What does HTTPS in a website URL indicate?",
                Options = new List<string> {
                    "The site has high traffic",
                    "The site is encrypted and secure",
                    "The site is government-approved",
                    "The site uses cookies"
                },
                CorrectAnswerIndex = 1,
                Explanation = "HTTPS indicates encrypted communication between your browser and the website."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "9. What is the purpose of a firewall?",
                Options = new List<string> {
                    "To block all internet traffic",
                    "To monitor and control network traffic",
                    "To speed up internet connections",
                    "To encrypt your data"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Firewalls act as barriers between trusted and untrusted networks."
            });

            Questions.Add(new QuizQuestion
            {
                QuestionText = "10. What should you do if you suspect your computer has malware?",
                Options = new List<string> {
                    "Continue using it normally",
                    "Disconnect from the internet and run scans",
                    "Share files with others to warn them",
                    "Delete random files"
                },
                CorrectAnswerIndex = 1,
                Explanation = "Disconnecting prevents spread while scanning removes threats."
            });

            Debug.WriteLine($"QuizGame initialized with {Questions.Count} questions");
        }
    }

    public class QuizQuestion
    {
        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public int CorrectAnswerIndex { get; set; }
        public string Explanation { get; set; }
    }
}