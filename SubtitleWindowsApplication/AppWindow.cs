using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Timers;
using System.Text.RegularExpressions;

namespace SubtitleWindowsApplication
{
    public partial class AppWindow : Form
    {
        #region variables
        public bool isPaused = false;
        public int elapsed = 0;
        public int elapsed2 = 0;
        public bool moreThanOne = false;
        public System.Timers.Timer countdown = new System.Timers.Timer(200);
        public System.Timers.Timer countdown2 = new System.Timers.Timer(200);
        #endregion variables

        #region initialization
        public AppWindow()
        {
            InitializeComponent();
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            this.TopMost = true;
        }

        private void Interface_Load(object sender, EventArgs e)
        {
            SubtitleDisplayBox.Hide();
            StartPrompt.Hide();
            MoreThanOne.Hide();
            StartButton.Hide();
            CountDown.Hide();
            NotPaused.Hide();
            gettingPaused1.Hide();
            gettingPaused2.Hide();
            gettingPaused3.Hide();
            gettingPaused4.Hide();
            Paused.Hide();
            pictureBox1.Hide();
            pictureBox2.Hide();
            Password.Hide();
            Pause.Hide();
    }

        private void SubtitleDisplayBox_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
        }

        private void LanguageSelectorA_Click(object sender, EventArgs e)
        {
            StartPrompt.Text = "字幕ファイル\n選択する";
            MoreThanOne.Text = "と同時に字幕ファイル\n選択する";
            StartButton.Text = "始める";
            LanguageSelectorA.Hide();
            LanguageSelectorB.Hide();

            StartPrompt.Show();
            MoreThanOne.Show();
        }

        private void DeveloperMode_Click(object sender, EventArgs e)
        {
            Password.Show();
            DeveloperMode.Hide();
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {
            Password.UseSystemPasswordChar = true;
            if (Password.Text == "")
            {
                Password.Hide();
                pictureBox1.Show();
                pictureBox2.Show();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void LanguageSelectorB_Click(object sender, EventArgs e)
        {
            DeveloperMode.Hide();
            LanguageSelectorA.Hide();
            LanguageSelectorB.Hide();
            StartPrompt.Show();
            MoreThanOne.Show();
        }
        #endregion initialization

        #region prompts
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StartPrompt.Hide();
                MoreThanOne.Hide();
                StartButton.Show();
            }
        }

        private void MoreThanOne_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    StartPrompt.Hide();
                    MoreThanOne.Hide();
                    StartButton.Show();
                    moreThanOne = true;
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            CountDown.Show();
            pictureBox1.Hide();
            pictureBox2.Hide();
            DeveloperMode.Hide();
            SubtitleDisplayBox.Show();
            StartButton.Hide();
            Pause.Show();

            if (moreThanOne)
            {
                BackgroundWorker ReaderWorker = new BackgroundWorker();
                ReaderWorker.DoWork += (send, param) => ReadInFromAssFile(openFileDialog1.FileName, openFileDialog2.FileName);
                ReaderWorker.RunWorkerAsync();
            }
            else
            {
                BackgroundWorker ReaderWorker = new BackgroundWorker();
                ReaderWorker.DoWork += (send, param) => ReadInFromAssFile(openFileDialog1.FileName, null);
                ReaderWorker.RunWorkerAsync();
            }
            
        }

        #endregion prompts

        #region Display Methods
        private void ProgramIsRunning(string subtitle, string subtitle2)
        {
            if (this.SubtitleDisplayBox.InvokeRequired)
            {
                SubtitleDisplayBox.Invoke(new MethodInvoker(delegate { SubtitleDisplayBox.Text = subtitle; }));
                SubtitleBox2.Invoke(new MethodInvoker(delegate { SubtitleBox2.Text = subtitle2; }));
            }
        }

        private void ProgramIsCountingDown(string subtitle)
        {
            if (this.CountDown.InvokeRequired)
            {
                CountDown.Invoke(new MethodInvoker(delegate { CountDown.Text = subtitle; }));
            }
        }

        private void ProgramIsDoneCountingDown()
        {
            if (this.CountDown.InvokeRequired)
            {
                CountDown.Invoke(new MethodInvoker(delegate { CountDown.Hide(); }));
            }
        }
        #endregion Display Methods

        #region main tasks
        public void MainOperation(Dictionary<int, string> SubtitleDictionary, int totalTime, Dictionary<int, string> subtitleDictionary2)
        {
            if (moreThanOne)
            {
                SubtitleBox2.Invoke(new MethodInvoker(delegate { SubtitleBox2.Show(); }));
            }

            Stopwatch timer1 = new Stopwatch();
            timer1.Start();

            while (timer1.IsRunning)
            {
                Thread.Sleep(1000);
                TimeSpan tsLeadIn = timer1.Elapsed;
                if (tsLeadIn.Seconds == 1)
                {
                    ProgramIsCountingDown("3");
                }
                if (tsLeadIn.Seconds == 2)
                {
                    ProgramIsCountingDown("2");
                }
                if (tsLeadIn.Seconds == 3)
                {
                    ProgramIsCountingDown("1");
                }
                if (tsLeadIn.Seconds == 4)
                {
                    ProgramIsCountingDown("PLAY");
                    timer1.Stop();
                }
            }

            string printingSubtitle;
            string printingSubtitle2 = null;
            Stopwatch timer = new Stopwatch();
            timer.Start();
            TimeSpan monitorTotalTime = new TimeSpan();
            while (monitorTotalTime.Seconds * 1000 != totalTime)
            {
                if (!(this.isPaused))
                {
                    if (!(timer.IsRunning))
                    {
                        timer.Start();
                    }
                    Thread.Sleep(250);
                    TimeSpan ts = timer.Elapsed;
                    int currentTime = (((ts.Minutes * 60) + (ts.Seconds)) * 1000);
                    if (currentTime == 2000)
                    {
                        ProgramIsDoneCountingDown();
                    }
                    if (SubtitleDictionary.TryGetValue(currentTime, out printingSubtitle))
                    {
                        if (subtitleDictionary2 != null)
                        {
                            subtitleDictionary2.TryGetValue(currentTime, out printingSubtitle2);
                        }
                        ProgramIsRunning(printingSubtitle, printingSubtitle2);
                    }
                }
                if (this.isPaused)
                {
                    if (timer.IsRunning)
                    {
                        timer.Stop();
                    }
                    Thread.Sleep(250);
                }
            }
        }

        private void ReadInFromFile(string filename, string filename2)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    int lines = int.Parse(sr.ReadLine()) - 4;
                    int min = int.Parse(sr.ReadLine());
                    int sec = int.Parse(sr.ReadLine());
                    int totalTimeInMilliseconds = ((min * 60) + (sec)) * 1000;

                    Dictionary<int, string> SubtitleDictionary = new Dictionary<int, string>();
                    SubtitleDictionary = GetTimeCodesAndGetSubtitles(filename, lines);

                    if (moreThanOne)
                    {
                        using (StreamReader sr2 = new StreamReader(filename2))
                        {
                            Dictionary<int, string> SubtitleDictionary2 = new Dictionary<int, string>();
                            SubtitleDictionary2 = GetTimeCodesAndGetSubtitles(filename, lines);

                            BackgroundWorker SubtitleWorker = new BackgroundWorker();
                            SubtitleWorker.DoWork += (send, param) => MainOperation(SubtitleDictionary, (int)totalTimeInMilliseconds, SubtitleDictionary2);
                            SubtitleWorker.RunWorkerAsync();
                        }
                    }
                    else
                    {
                        BackgroundWorker SubtitleWorker = new BackgroundWorker();
                        SubtitleWorker.DoWork += (send, param) => MainOperation(SubtitleDictionary, (int)totalTimeInMilliseconds, null);
                        SubtitleWorker.RunWorkerAsync();
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static Dictionary<int, string> GetTimeCodesAndGetSubtitles(string filename, int lines)
        {
            using (StreamReader sr = new StreamReader(filename))
            {
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                Dictionary<int, string> SubtitleDictionary = new Dictionary<int, string>();
                for (int i = 0; i < lines; i += 2)
                {
                    double timeCode = double.Parse(sr.ReadLine());
                    int timeCodeMS = (int)timeCode * 1000;
                    SubtitleDictionary.Add(timeCodeMS, sr.ReadLine());
                }
                return SubtitleDictionary;
            }
        }

        public void ReadInFromAssFile(string filename, string filename2)
        {
            Dictionary<int, string> SubtitleDictionary = new Dictionary<int, string>();
            SubtitleDictionary = GetTimeCodesAndGetSubtitlesFromAssFile(filename, 0);

                BackgroundWorker SubtitleWorker = new BackgroundWorker();
                SubtitleWorker.DoWork += (send, param) => MainOperation(SubtitleDictionary, 10000000, null);
                SubtitleWorker.RunWorkerAsync();

        }

        static Dictionary<int, string> GetTimeCodesAndGetSubtitlesFromAssFile(string filename, int lines)
        {
            Dictionary<int, string> subtitleDictionary = new Dictionary<int, string>();
            int counterHMS = 0;
            int counterSTET = 0;
            int counterSubtitle = 0;
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {

                    while (sr.ReadLine() != "[Events]")
                    {
                        sr.ReadLine();
                    }
                    sr.ReadLine();

                    char[] delim1 = { ',' };
                    char[] delim2 = { ':' };

                    string check = @"[0-9]:[0-9][0-9]:[0-9][0-9].(\d+)";
                    List<List<string>> splitArray = new List<List<string>>();
                    List<List<string>> splitArray2 = new List<List<string>>();
                    List<List<string>> splitArray3 = new List<List<string>>();

                    List<int> timeCodes = new List<int>();

                    while (!sr.EndOfStream)
                    {
                        splitArray.Add(sr.ReadLine().Split(delim1).ToList());
                    }

                    foreach (List<string> array in splitArray)
                    {
                        foreach (string str in array)
                        {
                            foreach (Match m in Regex.Matches(str, check))
                            {
                                //Console.WriteLine(m.Groups[0]);
                                splitArray2.Add(m.Groups[0].ToString().Split(delim2).ToList());
                            }
                            //Console.WriteLine(str);
                            //Console.ReadKey();
                        }
                    }

                    sr.BaseStream.Seek(0, System.IO.SeekOrigin.Begin);

                    while (sr.ReadLine() != "[Events]")
                    {
                        sr.ReadLine();
                    }

                    sr.ReadLine();

                    List<List<string>> rawLines = new List<List<string>>();
                    List<string> subtitleList = new List<string>();
                    string[] delim3 = { "0,," };
                    while (!sr.EndOfStream)
                    {
                        rawLines.Add(sr.ReadLine().Split(delim3, 10000000, StringSplitOptions.RemoveEmptyEntries).ToList());
                    }

                    foreach (List<string> array in rawLines)
                    {
                        foreach (string str in array)
                        {
                            if (counterSubtitle == 0)
                            {
                                counterSubtitle++;
                            }
                            else if (counterSubtitle == 1)
                            {
                                //Console.WriteLine(str);
                                subtitleList.Add(str);
                                counterSubtitle = 0;
                            }
                        }
                    }




                    List<double> startTimeStringsHours = new List<double>();
                    List<double> startTimeStringsMins = new List<double>();
                    List<double> startTimeStringsSecs = new List<double>();
                    List<int> startTimes = new List<int>();

                    List<double> endTimeStringsHours = new List<double>();
                    List<double> endTimeStringsMins = new List<double>();
                    List<double> endTimeStringsSecs = new List<double>();
                    List<int> endTimes = new List<int>();

                    foreach (List<string> array2 in splitArray2)
                    {
                        foreach (string str2 in array2)
                        {
                            if (counterHMS == 0 && counterSTET == 0)
                            {
                                //Console.WriteLine("Hours: " + str2);
                                startTimeStringsHours.Add(double.Parse(str2) * 60 * 60);
                                counterHMS++;
                            }
                            else if (counterHMS == 1 && counterSTET == 0)
                            {
                                //Console.WriteLine("Minutes: " + str2);
                                startTimeStringsMins.Add(double.Parse(str2) * 60);
                                counterHMS++;
                            }
                            else if (counterHMS == 2 && counterSTET == 0)
                            {
                                //Console.WriteLine("Seconds: " + str2);
                                startTimeStringsSecs.Add(double.Parse(str2));
                                counterHMS = 0;
                            }
                            else if (counterHMS == 0 && counterSTET == 1)
                            {
                                //Console.WriteLine("Hours: " + str2);
                                endTimeStringsHours.Add(double.Parse(str2) * 60 * 60);
                                counterHMS++;
                            }
                            else if (counterHMS == 1 && counterSTET == 1)
                            {
                                //Console.WriteLine("Minutes: " + str2);
                                endTimeStringsMins.Add(double.Parse(str2) * 60);
                                counterHMS++;
                            }
                            else if (counterHMS == 2 && counterSTET == 1)
                            {
                                //Console.WriteLine("Seconds: " + str2);
                                endTimeStringsSecs.Add(double.Parse(str2));
                                counterHMS = 0;
                            }
                            if (counterSTET == 1)
                            {
                                counterSTET = 0;
                            }
                            else if (counterSTET == 0)
                            {
                                counterSTET = 1;
                            }
                        }
                    }

                    int i = 0;
                    foreach (double value in startTimeStringsHours)
                    {
                        startTimes.Add(((int)value + (int)startTimeStringsMins[i] + (int)startTimeStringsSecs[i]) * 1000);
                        i++;
                    }

                    i = 0;
                    foreach (double value in endTimeStringsHours)
                    {
                        endTimes.Add((int)value + (int)endTimeStringsMins[i] + (int)endTimeStringsSecs[i]);
                        i++;
                    }

                    string newline = @"\\N";
                    string replaceNewline = "\n";

                    for (i = 0; i < subtitleList.Count; i++)
                    {
                        Regex reg = new Regex(newline);
                        string replacement = reg.Replace(subtitleList[i], replaceNewline);
                        subtitleList[i] = replacement;
                    }

                    i = 0;
                    foreach (int value in startTimes)
                    {
                        if (subtitleDictionary.ContainsKey(value))
                        {
                            subtitleDictionary.Add(value + 1, subtitleList[i]);
                            i++;
                        }
                        else
                        {
                            subtitleDictionary.Add(value, subtitleList[i]);
                            i++;
                        }
                    }

                    foreach (KeyValuePair<int, string> pair in subtitleDictionary)
                    {
                        //Console.WriteLine(pair.Key + " : " + pair.Value);
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            return subtitleDictionary;
        }

        #endregion main tasks

        #region pausing

        private void Pause_Click(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(ThreadAction);
        }

        public void ThreadAction(Object stateInfo)
        {
            if (this.isPaused != true)
            {
                this.isPaused = true;
                Pause.Invoke(new MethodInvoker(delegate { Pause.Text = "|>"; }));
            }
            else
            {
                this.isPaused = false;
                Pause.Invoke(new MethodInvoker(delegate { Pause.Text = "||";}));
            }
        }


        public void Pausing()
        {
            countdown.Start();
            countdown.Elapsed += (obj, param) => PauseCycle(countdown);
            countdown.Enabled = true;
        }

        public void Playing()
        {
            countdown2.Start();
            countdown2.Elapsed += (obj, param) => PlayCycle(countdown2);
            countdown2.Enabled = true;
        }


        public void PauseCycle(System.Timers.Timer countdown)
        {
            this.elapsed += 200;
            if (this.elapsed == 200)
            {
                NotPaused.Invoke(new MethodInvoker(delegate { NotPaused.Hide(); }));
                gettingPaused1.Invoke(new MethodInvoker(delegate { gettingPaused1.Show(); }));
            }
            if (this.elapsed == 400)
            {
                gettingPaused1.Invoke(new MethodInvoker(delegate { gettingPaused1.Hide(); }));
                gettingPaused2.Invoke(new MethodInvoker(delegate { gettingPaused2.Show(); }));
            }
            if (this.elapsed == 600)
            {
                gettingPaused2.Invoke(new MethodInvoker(delegate { gettingPaused2.Hide(); }));
                gettingPaused3.Invoke(new MethodInvoker(delegate { gettingPaused3.Show(); }));
            }
            if (this.elapsed == 800)
            {
                gettingPaused3.Invoke(new MethodInvoker(delegate { gettingPaused3.Hide(); }));
                gettingPaused4.Invoke(new MethodInvoker(delegate { gettingPaused4.Show(); }));
            }
            if (this.elapsed == 1000)
            {
                PauseStatus.Invoke(new MethodInvoker(delegate { PauseStatus.Text = "Paused"; }));

                gettingPaused4.Invoke(new MethodInvoker(delegate { gettingPaused4.Hide(); }));
                gettingPaused3.Invoke(new MethodInvoker(delegate { gettingPaused3.Hide(); }));
                gettingPaused2.Invoke(new MethodInvoker(delegate { gettingPaused2.Hide(); }));
                gettingPaused1.Invoke(new MethodInvoker(delegate { gettingPaused1.Hide(); }));
                countdown.Stop();
                this.elapsed = 0;
            }
            else
            {

            }
        }

        public void PlayCycle(System.Timers.Timer countdown2)
        {
            this.elapsed2 += 200;
            if (this.elapsed2 == 200)
            {
                Paused.Invoke(new MethodInvoker(delegate { Paused.Hide(); }));
                gettingPaused4.Invoke(new MethodInvoker(delegate { gettingPaused4.Show(); }));
            }
            if (this.elapsed2 == 400)
            {
                gettingPaused4.Invoke(new MethodInvoker(delegate { gettingPaused4.Hide(); }));
                gettingPaused3.Invoke(new MethodInvoker(delegate { gettingPaused3.Show(); }));
            }
            if (this.elapsed2 == 600)
            {
                gettingPaused3.Invoke(new MethodInvoker(delegate { gettingPaused3.Hide(); }));
                gettingPaused2.Invoke(new MethodInvoker(delegate { gettingPaused2.Show(); }));
            }
            if (this.elapsed2 == 800)
            {
                gettingPaused2.Invoke(new MethodInvoker(delegate { gettingPaused2.Hide(); }));
                gettingPaused1.Invoke(new MethodInvoker(delegate { gettingPaused1.Show(); }));
            }
            if (this.elapsed2 == 1000)
            {
                gettingPaused1.Invoke(new MethodInvoker(delegate { gettingPaused1.Hide(); }));
                PauseStatus.Invoke(new MethodInvoker(delegate { PauseStatus.Text = ""; }));
                countdown2.Stop();

                Paused.Invoke(new MethodInvoker(delegate { Paused.Hide(); }));
                gettingPaused4.Invoke(new MethodInvoker(delegate { gettingPaused4.Hide(); }));
                gettingPaused3.Invoke(new MethodInvoker(delegate { gettingPaused3.Hide(); }));
                gettingPaused2.Invoke(new MethodInvoker(delegate { gettingPaused2.Hide(); }));
                gettingPaused1.Invoke(new MethodInvoker(delegate { gettingPaused1.Hide(); }));
                this.elapsed2 = 0;
            }
        }

        #endregion pausing

        #region other methods
        private void CountDown_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void LoadInToFine_Click(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        #endregion other methods
    }
}
