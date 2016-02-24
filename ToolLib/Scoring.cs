using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLib
{
    public class Scoring
    {
        // Key Value pair, Dictionary score model set
        // Two override methods, input key to get score back from dictionary
        public static int getScore(Dictionary<int, int> dict, int keynum)
        {


            foreach (KeyValuePair<int, int> kvp in dict)
            {
                if (kvp.Key == keynum) return kvp.Value;

            }
            return 0;

        }

        public static int getScore(Dictionary<char, int> dict, char charkey)
        {


            foreach (KeyValuePair<char, int> kvp in dict)
            {
                if (kvp.Key == charkey) return kvp.Value;

            }
            return 0;

        }




        // return a score,  if input number between two integer number in int array
        public static int getScore(int[,] datarange, int num)
        {

            for (int i = 0; i < datarange.Length / 3; i++)
            {
                if (num >= datarange[i, 0] && num <= datarange[i, 1]) return datarange[i, 2];

            }
            return 0;

        }
        public static int getScore(float[,] datarange, float num)
        {

            for (int i = 0; i < datarange.Length / 3; i++)
            {
                if (num >= datarange[i, 0] && num <= datarange[i, 1]) return (int)datarange[i, 2];

            }
            return 0;

        }


        // return a score based index.  String array [0] is name and [1] is value

        public static int getScore(string[,] str, int index)
        {

            return int.Parse(str[index, 1]);

        }

        // return a score based on a char input. [0] is a string, if contains char input, then output [1]
        public static char getScore(string[,] str, char charinput)
        {

            char var = ' ';
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i, 0].Contains(charinput)) var = char.Parse(str[i, 1]);
            }

            return var;
        }
    }
}

