using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BCPNP_SkillWorker
{
    public class BCPNP_SkillWorker_Policy
    {
        // Top 100 NOC demaned in BC. Qualified applicant will get 10 bonus points
        public List<int> top100NOC = new List<int>(new int[] {
                                             0621,0121,0631,0711,0601,0122,0111,0013,0714,0712,
                                             0016,0213,0124,0112,0632,0731,0421,0211,1111,2171,
                                             4021,4011,2174,1114,2131,4112,2173,1122,1123,4012,
                                             4152,4163,4153,5121,1121,2133,2132,2175,2151,4165,
                                             4151,1221,1241,7271,1311,4212,6322,4214,1224,7241,
                                             6321,4311,6231,7294,5254,7311,2281,7237,6232,2242,
                                             6211,7312,7251,6332,7302,1222,1242,1225,7205,2241,
                                             2253,6222,7284,1312,4312,7231,9241,5242,7242,2263,
                                             7204,2264,7233,7371,7252,7282,7253,6421,7511,1411,
                                             1414,6513,7452,1431,6541,7521,7514,4411,7441,7513
                                            });
        // NOC to 0, A, B, C, D
        public string[,] NOC = new string[,]
        {
            { "0", "0"},// If the first number of NOC is 0, then the skill level is 0
            {"1","A" }, // if the 2nd number of NOC is 1, then the skill level is A
            {"2,3","B" },
            {"4,5","C" },
            {"6,7","D" }

        };


        // Skill level of BC Job offer. skill type char pairs with points 
        public Dictionary<char, int> jobLevel = new Dictionary<char, int> {
            { '0', 25 }, {'A',25}, {'B',10}, {'C',5}, {'D',5}
        };

        public int[,] wagePoints = new int[,]
        {
            { 100000 , 1000000,50 },
            { 97500 , 99999,38 },
            { 95000 , 97499,37 },
            { 92500 , 94999,36 },
            { 90000 , 92499,35 },
            { 87500 , 89999,34 },
            { 85000 , 87499,33 },
            { 82500 , 84999,32 },
            { 80000 , 82499,31 },
            { 77500 , 79999,30 },
            { 75000 , 77499,29 },
            { 72500 , 74999,28 },
            { 70000 , 72499,27 },
            { 67500 , 69999,26 },
            { 65000 , 67499,25 },
            { 62500 , 64999,24 },
            { 60000 , 62499,23 },
            { 57500 , 59999,22 },
            { 55000 , 57499,21 },
            { 52500 , 54999,20 },
            { 50000 , 52499,19 },
            { 47500 , 49999,18 },
            { 45000 , 47499,17 },
            { 42500 , 44999,16 },
            { 40000 , 42499,15 },
            { 38750 , 39999,14 },
            { 37500 , 38749,13 },
            { 36250 , 37499,12 },
            { 35000 , 36249,11 },
            { 33750 , 34999,10 },
            { 32500 , 33749,9 },
            { 31250 , 32499,8 },
            { 30000 , 31249,7 },
            { 28750 , 29999,6 },
            { 27500 , 28749,5 },
            { 26250 , 27499,4 },
            { 25000 , 26249,3 },
            { 0     , 25000,0 }
        };

        // Regional district of employment will be embeded directly into the code somewhere

        //Work experience points polciy. Max is setup as 100 years 
        public int[,] workExperiencePoints = new int[,]
        {
            { 5,100,15},
            { 4,5,12},
            { 3,4,9},
            { 2,3,6},
            { 1,2,3},
            {0,1,1}
        };

        // Education points policy will be embeded directly into code somewhere

        // Language points policy
        public Dictionary<int, int> CLBLevel = new Dictionary<int, int> {
            {12,30},{11,30},{ 10, 30 }, {9,26}, {8,22}, {7,18}, {6,14}, {5,10}, {4,6}, {3,0 }, {2,0 }, {1,0 }, {0,0}
        };

        // Education points policy
        public string[,] education = new string[,]
        {
            { "Doctoral or Master’s degree", "17" },
            {"Post Graduate Certificate or Diploma","11" },
            {"Bachelor’s degree","11" },
            {"Trades certification","11" },
            {"Associate Degree","4" },
            {"Non-trades certification or Diploma","2" },
            {"High School","0" }

        };
        // Education bonus points policy
        public string[,] eduBonus = new string[,]
        {
            {"  ","0" },
            {"Post-secondary education completed in B.C","8" },
            {"Post-secondary education completed in Canada (outside of B.C.)","6" },
            {"Education Credential Assessment from a qualified supplier","4" },
            {"Trades certification assessment from the Industry Training Authority","4" }

        };

        // Region points policy
        public string[,] region = new string[,]
        {
           {"Stikine","10" },
            {"Central Coast","10" },
            {"Northern Rockies","10" },
            {"Mount Waddington","10" },
            {"Skeena -Queen Charlotte","10" },
            {"Powell River","10" },
            {"Sunshine Coast","10" },
            {"Kootenay -Boundary","10" },
            {"Alberni - Clayoquot","10" },
            {"Kitimat-Stikine","8"},
            {"Bulkley -Nechako","8"},
            {"Squamish -Lillooet","8"},
            {"Strathcona","8"},
            {"Columbia - Shushwap","8"},
            {"East Kootenay","8"},
            {"Peace River","6"},
            {"Comox Valley","6"},
            {"Cariboo","6"},
            {"Central Kootenay","6"},
            {"Okanagan-Similkameen","4" },
            {"Cowichan Valley","4" },
            {"North Okanagan","4" },
            {"Fraser -Fort George","4"},
            {"Thompson-Nicola","2"},
            {"Nanaimo","2"},
            {"Central Okanagan","2"},
            {"Capital","2"},
            {"Fraser Valley","2"},
            {"Greater Vancouver","0"}

        };



        public int scoring(int[,] policy, int num)
        {


            for (int i = 0; i < policy.Length / 3; i++)
            {
                if (num >= policy[i, 0] && num <= policy[i, 1]) return policy[i, 2];

            }
            return 0;

        }

        public int scoring(Dictionary<int, int> dict, int num)
        {


            foreach (KeyValuePair<int, int> kvp in dict)
            {
                if (kvp.Key == num) return kvp.Value;

            }
            return 0;

        }

        public int scoring(Dictionary<char, int> dict, char c)
        {


            foreach (KeyValuePair<char, int> kvp in dict)
            {
                if (kvp.Key == c) return kvp.Value;

            }
            return 0;

        }
        public int scoring(string[,] str, int index)
        {

            return int.Parse(str[index, 1]);

        }
        public char scoring(string[,] str, char noc)
        {

            char var = ' ';
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i, 0].Contains(noc)) var = char.Parse(str[i, 1]);
            }

            return var;
        }
    }
}
