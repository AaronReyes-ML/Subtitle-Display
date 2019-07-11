using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace SubtitlesApplication
{
    class ReadInFromFile
    {
        public static void ReadFile(string filename)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;
                    int lines = int.Parse(sr.ReadLine()) - 4;
                    int min = int.Parse(sr.ReadLine());
                    int sec = int.Parse(sr.ReadLine());
                    int totalTime = (min * 60) + (sec);
                    int i = 0;
                    Console.WriteLine("File is " + min + " minutes and " + sec + " seconds long.");
                    Console.WriteLine("Total run time is " + totalTime + " seconds.");

                    List<int> TimeCodes = new List<int>();
                    TimeCodes = GetTimeCodes(sr, lines);
                    List<string> Subtitles = new List<string>();
                    Subtitles = GetSubtitles(filename, lines);

                    Dictionary<int, string> SubtitleDictionary = new Dictionary<int, string>();

                    foreach (int time in TimeCodes)
                    {
                        SubtitleDictionary.Add(time, Subtitles[i]);
                        i++;
                    }

                    foreach (KeyValuePair<int, string> SubtitlePair in SubtitleDictionary)
                    {
                        Console.WriteLine(SubtitlePair);
                    }

                    Console.WriteLine("There are a total of " + Subtitles.Count + " subtitles.");
                    Stopwatch leadIn = new Stopwatch();

                    VideoRunning.VideoIsRunning(leadIn, SubtitleDictionary, totalTime);

                    /*
                    Console.WriteLine("Hit enter to start, play video after 5 seconds.");
                    Console.ReadKey();
                    Console.WriteLine("5 seconds until start.");
                    

                    leadIn.Start();

                    while (leadIn.IsRunning)
                    {
                        Thread.Sleep(1000);
                        TimeSpan ts = leadIn.Elapsed;
                        
                        if (ts.Seconds == (5))
                        {
                            leadIn.Stop();
                            Console.WriteLine("Play");
                        }
                        if(ts.Seconds < 5)
                        {
                            Console.WriteLine("T " + (ts.Seconds - 5) + "seconds");
                        }
                        else
                        {

                        }
                    }

                    Stopwatch timer = new Stopwatch();
                    timer.Start();

                    while (timer.IsRunning)
                    {
                        Thread.Sleep(1000);
                        TimeSpan ts = timer.Elapsed;
                        Console.WriteLine(ts.Seconds);

                        if (SubtitleDictionary.TryGetValue(ts.Seconds, out printingSubtitle))
                        {
                            Console.WriteLine(printingSubtitle);
                        }

                        if (ts.Seconds == (totalTime))
                        {
                            timer.Stop();
                        }
                    }
                    */

                    while((line = sr.ReadLine()) != null)
                    {
                        if (line.Equals("Translation:"))
                        {
                            Console.WriteLine(line);
                        }
                        else
                        {
                            Console.WriteLine(line);
                        }
                    }
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static List<int> GetTimeCodes(StreamReader sr, int lines)
        {
            List<int> TimeCodes = new List<int>();
            for(int i = 0; i < lines; i+=2)
            {
                //Console.WriteLine("Added");
                TimeCodes.Add(int.Parse(sr.ReadLine()));
                sr.ReadLine();  
            }
            return TimeCodes;
        }

        static List<string> GetSubtitles(string filename, int lines)
        {
            using (StreamReader sr = new StreamReader("C:/Users/Aaron/Desktop/2016/CSTest/Source/" + filename))
            {
                sr.ReadLine();
                sr.ReadLine();
                sr.ReadLine();
                List<string> Subtitles = new List<String>();
                for (int i = 0; i < lines; i += 2)
                {
                    sr.ReadLine();
                    //Console.WriteLine("Added");
                    Subtitles.Add(sr.ReadLine());
                }
                return Subtitles;
            }
        }
    }
}
