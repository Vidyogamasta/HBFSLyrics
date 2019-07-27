// Daft Punk's song 'Harder, Better, Faster, Stronger',
// Original C# Code by  Wil Dobson (wdobson@pixelsyndicate.com) 
// https://github.com/pixelsyndicate/DaftPunkLyrics

using System;
using System.Collections.Generic;

namespace WorkIt
{
    class Program
    {
        public static string[][] LyricComponents = new[]{
                new[] { "work it", "make it", "do it", "makes us" },
                new[] { "harder", "better", "faster", "stronger" },
                new[] { "more than", "hour", "our", "never" },
                new[] { "ever", "after", "work is", "over" } };

        static void Main(string[] args)
        {
            var songOrder = new[] { (FirstHalf, 1), (SecondHalf, 1), (FirstHalf, 1), (JoinedLyric, 11), (ThatOneWeirdOne, 1), (JoinedLyric, 1) };

            foreach (var line in songOrder)
            {
                for (var i = 0; i < line.Item2; i++)
                {
                    foreach (var lyric in line.Item1)
                    {
                        Console.WriteLine(FormatLine(lyric));
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        public static string FormatLine(string lyric)
        {
            return char.ToUpperInvariant(lyric[0]) + lyric.Substring(1).ToLowerInvariant();
        }

        public static IEnumerable<string> FirstHalf
        {
            get
            {
                for (var i = 0; i < 2; i++)
                {
                    foreach (var lyric in LyricComponents[i])
                    {
                        yield return lyric;
                    }
                }
            }
        }

        public static IEnumerable<string> SecondHalf
        {
            get
            {
                for (var i = 2; i < 4; i++)
                {
                    foreach (var lyric in LyricComponents[i])
                    {
                        yield return lyric;
                    }
                }
            }
        }

        public static IEnumerable<string> JoinedLyric
        {
            get
            {
                for (var i = 0; i < LyricComponents[0].Length; i++)
                {
                    yield return LyricComponents[0][i] + " " + LyricComponents[1][i];
                }
                for (var i = 0; i < LyricComponents[0].Length; i++)
                {
                    yield return LyricComponents[2][i] + " " + LyricComponents[3][i];
                }
            }
        }

        public static IEnumerable<string> ThatOneWeirdOne
        {
            get
            {
                for (var i = 0; i <= 2; i += 2)
                {
                    for (var j = 0; j <= 2; j += 2)
                    {
                        yield return LyricComponents[i][j] + " " + LyricComponents[i + 1][j];
                    }
                }
                yield return LyricComponents[2][3] + " " + LyricComponents[3][3];
            }
        }
    }
}