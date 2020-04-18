using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace CodeForecs.Topics.String
{
    //https://leetcode.com/problems/reorder-data-in-log-files/
    class ReOrderDataInLogFiles
    {
        public static void TestSolution()
        {
            string[] logFiles = File.ReadAllLinesAsync(@"C:\Users\guptraju\source\repos\CodeForecs\InputFiles\ReOrderDataInLogFiles.txt").Result;

            ReOrderDataInLogFiles testObject = new ReOrderDataInLogFiles();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            string[] sortedLogFiles = testObject.ReorderLogFiles(logFiles);

            stopwatch.Stop();

            Console.WriteLine("Time taken using IComparable method :- " + stopwatch.Elapsed.TotalSeconds);

            /*
            foreach(string sortedLogFile in sortedLogFiles)
            {
                Console.WriteLine(sortedLogFile);
            }
            */

            stopwatch.Start();
            string[] optimisedSortedLogFiles = testObject.ReorderLogFilesOptimised(logFiles);

            stopwatch.Stop();

            Console.WriteLine("Time taken using optimised method :- " + stopwatch.Elapsed.TotalSeconds);

            /*
            foreach (string sortedLogFile in optimisedSortedLogFiles)
            {
                Console.WriteLine(sortedLogFile);
            }
            */
        }
        public class LogFiles: IComparable<LogFiles>
        {
            public int Index { get; set; }

            public string Identifier { get; set; }

            public string Contents { get; set; }

            public LogFiles(int index, string identifier, string contents)
            {
                Index = index;
                Identifier = identifier;
                Contents = contents;
            }

            public int CompareTo(LogFiles toCompareWith)
            {
                if(this.Contents[0] <= '9')
                {
                    if(toCompareWith.Contents[0] <= '9')
                    {
                        return this.Index.CompareTo(toCompareWith.Index);
                    }

                    return 1;
                }

                if (toCompareWith.Contents[0] <= '9')
                {
                    return -1;
                }

                int result = this.Contents.CompareTo(toCompareWith.Contents);

                if(result == 0)
                {
                    return this.Identifier.CompareTo(toCompareWith.Identifier);
                }

                return result;
            }
        }

        //This solution uses the IComparable<T> interface to sort the input. In the best case, when all the words after the identifers contain digits, it will still take O(nlogn) time.
        public string[] ReorderLogFiles(string[] logs)
        {
            LogFiles[] logFiles = new LogFiles[logs.Length];

            for(int i = 0; i < logs.Length; i++)
            {
                int firstSpaceIndex = logs[i].IndexOf(' ');

                string identifier = logs[i].Substring(0, firstSpaceIndex);

                string contents = logs[i].Substring(firstSpaceIndex + 1);

                logFiles[i] = new LogFiles(i, identifier, contents);
            }

            Array.Sort(logFiles);

            string[] sortedLogs = new string[logs.Length];

            for(int i = 0; i < logFiles.Length; i++)
            {
                sortedLogs[i] = logFiles[i].Identifier + " " + logFiles[i].Contents;
            }

            return sortedLogs;
        }

        public class OptimisedLogFile:IComparable<OptimisedLogFile>
        {
            public string Identifier { get; set; }

            public string Contents { get; set; }

            public OptimisedLogFile(string identifier, string contents)
            {
                Identifier = identifier;
                Contents = contents;
            }
            public int CompareTo(OptimisedLogFile other)
            {
                int result = this.Contents.CompareTo(other.Contents);

                if(result == 0)
                {
                    return this.Identifier.CompareTo(other.Identifier);
                }

                return result;
            }
        }

        //This solution avoids sorting those strings that contain digits as words after identifiers. In the best case, when all the words after the identifers contain digits,
        //no sorting is required and it will take O(n) time.
        public string[] ReorderLogFilesOptimised(string[] logs)
        {
            List<OptimisedLogFile> stringsContainingWordsAfterIdentifiers = new List<OptimisedLogFile>();

            IList<int> logFileDigitIdentifier = new List<int>();

            for(int i = 0; i < logs.Length; i++)
            {
                int firstCharacterIndexAfterIdentifer = logs[i].IndexOf(' ');

                if(Char.IsDigit(logs[i][firstCharacterIndexAfterIdentifer + 1]))
                {
                    logFileDigitIdentifier.Add(i);
                }
                else
                {
                    string identifier = logs[i].Substring(0, firstCharacterIndexAfterIdentifer);

                    string contents = logs[i].Substring(firstCharacterIndexAfterIdentifer + 1);

                    stringsContainingWordsAfterIdentifiers.Add(new OptimisedLogFile(identifier, contents));
                }
            }

            stringsContainingWordsAfterIdentifiers.Sort();

            string[] sortedLogs = new string[logs.Length];

            int index = 0;

            foreach(OptimisedLogFile file in stringsContainingWordsAfterIdentifiers)
            {
                sortedLogs[index++] = file.Identifier + " " + file.Contents;
            }

            foreach (int i in logFileDigitIdentifier)
            {
                sortedLogs[index++] = logs[i];
            }

            return sortedLogs;
        }
    }
}
