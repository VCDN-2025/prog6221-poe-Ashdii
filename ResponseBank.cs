using System;
using System.Collections.Generic;
using System.Linq;

namespace CyberAwarenessBotGUI
{
    public static class ResponseBank
    {
        public static Dictionary<string, List<string>> KeywordResponses = new Dictionary<string, List<string>>
        {
            { "password", new List<string>
                {
                    "Strong passwords should be at least 12 characters long and include a mix of uppercase, lowercase, numbers, and symbols.",
                    "Avoid using personal information like names or birthdates in your passwords.",
                    "Consider using a passphrase instead of a password for better security and memorability.",
                    "Enable two-factor authentication whenever possible for additional security."
                }
            },
            { "phishing", new List<string>
                {
                    "Phishing is when attackers impersonate trusted entities to steal sensitive data.",
                    "Always verify sender email addresses and check for typos in URLs before clicking.",
                    "Legitimate organizations will never ask for passwords via email.",
                    "Hover over links to preview the actual destination URL before clicking."
                }
            },
            { "privacy", new List<string>
                {
                    "Protect your privacy by limiting what you share online and reviewing privacy settings regularly.",
                    "Use VPNs when browsing on public Wi-Fi networks to encrypt your connection.",
                    "Be cautious about sharing location data and personal routines on social media.",
                    "Regularly review app permissions on your devices and revoke unnecessary access."
                }
            },
            { "hackers", new List<string>
                {
                    "Hackers exploit vulnerabilities to gain unauthorized access to systems.",
                    "Protect yourself with firewalls, regular software updates, and least-privilege access controls.",
                    "Be cautious with public Wi-Fi - hackers often use it to intercept unencrypted data.",
                    "Never share sensitive information over unsecured connections or with untrusted parties."
                }
            },
            { "malware", new List<string>
                {
                    "Malware includes viruses, ransomware, spyware, and other malicious software.",
                    "Prevent infections by avoiding suspicious downloads and keeping antivirus software updated.",
                    "Be extremely cautious with email attachments, especially from unknown senders.",
                    "Regularly back up your important data to mitigate damage from ransomware attacks."
                }
            }
        };

        public static Dictionary<string, string> KeywordSynonyms = new Dictionary<string, string>
        {
            { "scam", "phishing" },
            { "fake email", "phishing" },
            { "cybercriminals", "hackers" },
            { "attackers", "hackers" },
            { "virus", "malware" },
            { "ransomware", "malware" },
            { "spyware", "malware" }
        };

        public static string GetRandomResponse(string keyword)
        {
            if (KeywordSynonyms.ContainsKey(keyword))
            {
                keyword = KeywordSynonyms[keyword];
            }

            if (KeywordResponses.ContainsKey(keyword) && KeywordResponses[keyword].Count > 0)
            {
                Random rand = new Random();
                return KeywordResponses[keyword][rand.Next(KeywordResponses[keyword].Count)];
            }
            return "Cybersecurity is important! Let me know if you have specific questions.";
        }
    }
}