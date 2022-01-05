using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace TextAnalyzer
{
    public partial class Form1 : Form
    {
        BackgroundWorker bgw = new BackgroundWorker();//create the background worker to perform tasks
        public string[] inputText;
        public static string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
        static string[] words = System.IO.File.ReadAllText(projectDirectory + "\\TextAnalyzer\\words.txt").Normalize().ToLower().Split(new char[] { ' ', '\n', '\r', '_' });
        public static List<wordCount> wordsCount = new List<wordCount>();
        public static List<string> invalidWords = new List<string>();
        public string verified = "";
        public string counted = "";
        public int total;
        public int done = 0;

        public class wordCount
        {
            public string word;
            public int count;

            public wordCount(string word)
            {
                this.word = word;
                this.count = 1;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void verifyButton_Click_1(object sender, EventArgs e)
        {
            errorsBox.Text = "";//set all the values to defaults
            countsBox.Text = "";
            done = 0;
            verified = "";
            counted = "";
            wordsCount.Clear();
            invalidWords.Clear();
            inputText = inputBox.Text.Normalize().ToLower().Split(new char[] { ' ' , '\n', '\r'});//get the input into array

            for(int i = 0; i < inputText.Length; i++)
            {
                inputText[i] = new String(inputText[i].Where(Char.IsLetter).ToArray());//remove any characters other than letters
            }
               
            total = inputText.Length * 3;//data to count progress bar percentage

            bgw.RunWorkerAsync();
        }

        void verifyWords(object sender, DoWorkEventArgs e)
        {
            foreach(var x in inputText)
            {
                if (!words.Contains(x))//check whether the word is in the dictionary
                {
                    if (!invalidWords.Contains(x))//check whether the word wasn't already added to the invalid words
                    {
                        invalidWords.Add(x);//add the word to the invalid words list
                        verified += x + Environment.NewLine;//add the word to the string to be displayed
                    }
                }
                done++;
                bgw.ReportProgress((done * 100 / total), done);//send the progress report to the background worker
            }
        }
        
        void ProgressBarUpdate(object sender, ProgressChangedEventArgs e)//increment the progress bar through backgroundworker
        {
            progressBar.Value = e.ProgressPercentage;
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)//when the worker completes the works it displays the results
        {
            progressBar.Value = 100;
            errorsBox.AppendText(verified);
            countsBox.AppendText(counted);
        }

        void countWords(object sender, DoWorkEventArgs e)
        {
            bool found;
            foreach(var x in inputText)
            {
                if (words.Contains(x))//we check if the word is in the dictionary
                {
                    found = false;
                    foreach(var y in wordsCount)//then we check if it was already counted
                    {
                        if(y.word == x)//if it was
                        {
                            y.count++;//we increment the count
                            found = true;
                            break;
                        }
                    }
                    if (!found)//if it wasnt we add it
                        wordsCount.Add(new wordCount(x));
                }
                done++;
                bgw.ReportProgress((done * 100 / total),done);//reporting progress to background worker
            }

            counted = "";

            foreach(var x in wordsCount)//add all counted words to the string to be displayed
            {
                if(x.word != "")
                {
                    counted += x.word + " - " + x.count + Environment.NewLine;
                }
                done++;
                bgw.ReportProgress((done * 100 / total), done);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bgw.DoWork += new DoWorkEventHandler(verifyWords);//add verifyWords function as work to background worker
            bgw.DoWork += new DoWorkEventHandler(countWords);//doing the same with the second function that counts the valid words
            bgw.ProgressChanged += new ProgressChangedEventHandler(ProgressBarUpdate);//on progress change we update the progress bar
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);//add the function to run at worker complete
            bgw.WorkerReportsProgress = true;
        }
    }
}
