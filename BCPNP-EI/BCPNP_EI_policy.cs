using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImmManager
{
    public class BCPNP_EI_policy
    {
        // Score points policies about work experience
       public int[,] OwnerScorePolicy = new int[,] {
            // Months to months and points 
            {0,11,0},
            {12,24,4},
            {25,36,6},
            {37,48,12},
            {49,60,15},
            {61,120,20}
           };
        public int[,] SeniorManagerScorePolicy = new int[,] {
            // Months to months and points 
            {0,23,0},
            {24,48,4},
            {49,60,8},
            {61,120,12}
          };

        // Score points policies about assets
        public int[,] CurrentAssetPolicy = new int[,]
        {
            // current asset range and points, we setup the max is $1 billion
            {0,49999,0},
            {50000,199999,1},
            {200000,399999,3},
            {400000,1000000000,6}
            };

        public int[,] NetAssetPolicy = new int[,]
        {
            // Net asset rage and points, we setup the max is $1 billion
            {0,599999,0},
            {600000,799999,1},
            {800000, 1999999,3},
            {2000000,4999999,5},
            {5000000,1000000000,6}
          };

        // score points policy about eligible investment,  we setup the max is $1 billion
        public int[,] EligibleInvestPolicy = new int[,]
        {
            {0,199999,0},
            {200000,399999,6},
            {400000,999999,20},
            {1000000,1000000000,30}
         };

        // score points policy about job creation, we setup the max person is 10,000
        public int[,] JobCreationPolicy = new int[,]
            {
                // from to amount of persons, and points
               {0,0,0},
               {1,1,2},
               {2,2,6},
               {3,4,12},
               {5,6,20},
               {7,8,28},
               {9,10,32},
               {11,10000,36 }
            };

        

        public static int scoring(int[,] policy, int num)
        {


            for(int i = 0; i < policy.Length / 3; i++)
            {
                if(num >= policy[i, 0] && num <= policy[i, 1]) return policy[i, 2];

            }
            return -1;

        }


    }

}
