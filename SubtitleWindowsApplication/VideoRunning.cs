using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace SubtitlesApplication
{
    class VideoRunning
    {
        public static void VideoIsRunning(Stopwatch leadIn, Dictionary<int, string> SubtitleDictionary, int totalTime)
        {

            string printingSubtitle;

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
                if (ts.Seconds < 5)
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
                //Console.WriteLine(ts.Seconds);

                if (SubtitleDictionary.TryGetValue(ts.Seconds, out printingSubtitle))
                {
                    Console.WriteLine(printingSubtitle);
                }

                if (ts.Seconds == (totalTime))
                {
                    timer.Stop();
                }
            }
        }
    }
}
