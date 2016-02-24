using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToolLib
{
    public class Validation
    {
        // validate if a value is between a range
        public static bool isValidated(int low, int high, int value)
        {
            if (value >= low && value <= high) return true;
            return false;
        }
        public static bool isValidated(float low, float high, float value)
        {
            if (value >= low && value <= high) return true;
            return false;
        }
        public static bool isValidated(float low,float value)
        {
            if (value >= low) return true;
            return false;
        }

    }
}
