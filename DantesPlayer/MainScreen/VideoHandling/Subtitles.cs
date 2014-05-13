namespace MainScreen.VideoHandling
{
    #region Namespaces
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    #endregion

    public class Subtitles
    {
        private const string StringTimeRegex = "\\d\\d[:]\\d\\d[:]\\d\\d[,]\\d\\d\\d";
        private string filePath;

        private List<int> startSubTime;
        private List<int> endSubTime;
        private List<string> subtitle;

        /// <summary>
        /// Gets the subtitle text
        /// </summary>
        public List<string> Subtitle
        {
            get { return subtitle; }
        }
        
        /// <summary>
        /// Gets the end time of the subtitle 
        /// </summary>
        public List<int> EndSubTime
        {
            get { return endSubTime; }
        }
        
        /// <summary>
        /// Gets the start time of the subtitle
        /// </summary>
        public List<int> StartSubTime
        {
            get { return startSubTime; }
        }


        /// <summary>
        /// Gets the total subtitles there are in the file StartSubTime 
        /// and EndSubTime have the same number of elements
        /// </summary>
        public int SubtitleLinesTotal
        {
            get { return startSubTime.Count; }
        }

        public bool SubsLoaded { get; set; }

        public Subtitles()
        {
            this.SubsLoaded = false;
        }

        public Subtitles(string filePath)
        {
            this.startSubTime = new List<int>();
            this.endSubTime = new List<int>();
            this.subtitle = new List<string>();
            this.filePath = filePath;
            extractSubtitle(this.startSubTime, this.endSubTime, this.subtitle, File.ReadAllLines(this.filePath));
            this.SubsLoaded = true;
        }

        public void Load(string filePath)
        {
            this.startSubTime = new List<int>();
            this.endSubTime = new List<int>();
            this.subtitle = new List<string>();
            this.filePath = filePath;
            extractSubtitle(this.startSubTime, this.endSubTime, this.subtitle, File.ReadAllLines(this.filePath));
            this.SubsLoaded = true;
        }

        public void UnLoad()
        {
            this.startSubTime = new List<int>();
            this.endSubTime = new List<int>();
            this.subtitle = new List<string>();
            this.SubsLoaded = false;
        }

        public bool CheckPrint(int videoTime, int subStart)
        {
            return videoTime > subStart;
        }

        public bool CheckSubEnded(int videoTime, int subEnd)
        {
            return videoTime > subEnd;
        }

        private static void extractSubtitle(List<int> startTimeDestination, List<int> endTimeDestination, List<string> subDestination, string[] source)
        {
            int i = 0;
            Regex regexForTime = new Regex(StringTimeRegex);
            const int startPos = 0;
            const int endPos = 2;
            const int endSubInc = 5;
            char[] delimiter = new Char[] { ':', ',', ' ' };
            int fake = 0;
            for (int y = 0; y < source.Length; y++)
            {
                if (regexForTime.IsMatch(source[y]))
                {
                    startTimeDestination.Add(0);
                    endTimeDestination.Add(0);
                    subDestination.Add("");
                    //Time factor for hours then for minutes 3600 -> 60 -> 1
                    int timeFactor = 3600;
                    for (int j = startPos; j <= endPos; j++)
                    {
                        startTimeDestination[i] += int.Parse(source[y].Split(delimiter)[j]) * timeFactor;
                        endTimeDestination[i] += int.Parse(source[y].Split(delimiter)[j + endSubInc]) * timeFactor;
                        timeFactor /= 60;
                    }
                    y++;
                    do
                    {
                        subDestination[i] += source[y] + Environment.NewLine;
                        ++y;
                        //Console.WriteLine(subDestination[i]);
                        //Console.ReadLine();
                        if (y + 1 > source.Length)
                        {
                            break;
                        }
                    } while (!string.IsNullOrWhiteSpace(source[y]) && !int.TryParse(source[y + 1], out fake));
                    i++;
                }
            }
        }
    }
}
