using System;
using System.Collections.Generic;
using System.Linq;


namespace CIPolicyLib
{
    public class CLB
    {
        public static string[] TestType = new string[] {"No Test", "IELTS", "CELPIP-G 14", "CELPIP-G 13" };  // WILL do TEF LATER
        
        //private static string[,] CELPIPG13 = new string[,]
        //      {
        //        {"10","5H","5H","5H","5H"},
        //        {"9","5L","5L","5L","5L"},
        //        {"8","4H","4H","4H","4H"},
        //        {"7","4L","4L","4L","4L"},
        //        {"6","3H","3H","3H","3H"},
        //        {"5","3L","3L","3L","3L"},
        //        {"4","2H","2H","2H","2H"}
        //      };

        private static Dictionary<string, int> CELPIPG13 = new Dictionary<string, int>()
            {
                {"5H",10},
                {"5L",9},
                {"4H",8},
                {"4L",7},
                {"3H",6},
                {"3L",5},
                {"2H",4}
            };
        private static float[,] IELTSG = new float[,]
            {
                {10f, 8.0f,7.5f,8.5f,7.5f},
                {9f,7.0f,7.0f,8.0f,7.0f},
                {8f,6.5f,6.5f,7.5f,6.5f},
                {7f,6.0f,6.0f,6.0f,6.0f},
                {6f,5.0f,5.5f,5.5f,5.5f},
                {5f,4.0f,5.0f,5.0f,5.0f},
                {4f,3.5f,4.0f,4.5f,4.0f}
            };

        // four section sequence: Reading, Writing, Lisenting, Speaking

        //CLB <->CELPIP General, Version: After April 1, 2014
        public static int CELPIPGtoCLB(int reading, int writing, int listening, int speaking)
        {
            List<int> l = new List<int>() { reading, writing, listening, speaking };
            return l.Min();
        }
        public static List<int> CLBtoCELPIPG(int clb)
        {
            return new List<int>() { clb, clb, clb, clb };
        }

        // CLB<->CLIPIP General, Version: Before May 3, 2013
        public static int CELPIPG13toCLB(string reading, string writing, string listensing, string speaking)
        {
            List<string> scores = new List<string>() { reading, writing, listensing, speaking };
           
            int[] level = new int[4];


            for (int i = 0; i < 4; i++) // search for 4 string 
            {
                foreach (KeyValuePair<string, int> kvp in CELPIPG13) // in the dictionary
                {

                    if (kvp.Key == scores[i]) level[i] = kvp.Value;  // find the match and assign the level to array;
                }

            }

            return level.Min();
        }
        public static string CLBtoCELPIPG13(int clb)
        {

            string feedback ="";
            foreach(KeyValuePair<string, int> kvp in CELPIPG13)
            {
                if (kvp.Value == clb) feedback = kvp.Key;
            }
            
            return feedback;
        }
        //IELTS General to CLB
        public static int IELTSGtoCLB(float reading, float writing, float listening, float speaking)
        {
            int[] clb = new int[IELTSG.Length / 5];
            for (int i = 0; i < IELTSG.Length / 5; i++)
            {
                if (reading >= IELTSG[i, 1] && writing >= IELTSG[i, 2] && listening >= IELTSG[i, 3] && speaking >= IELTSG[i, 4]) clb[i] = (int)IELTSG[i, 0];

            }
            return clb.Max();
        }

        public static List<float> CLBtoIELTSG(int clb)
        {

            List<float> feedback = new List<float>();
            if (clb > 10) clb = 10;
            if (clb >= 4)
            {
                for (int i = 0; i < IELTSG.Length / 5; i++)
                {
                    if ((int)IELTSG[i, 0] == clb)
                    {
                        return new List<float> { IELTSG[i, 1], IELTSG[i, 2], IELTSG[i, 3], IELTSG[i, 4] };
                    }
                  
                }
            }
            else feedback = new List<float> { 0f, 0f, 0f, 0f };
            return feedback;
        }
    }

}

