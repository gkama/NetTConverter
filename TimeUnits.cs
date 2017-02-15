using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTConverter
{
    public static class TimeUnits
    {
        //Calculations
        public static Dictionary<string, SortedDictionary<string, int>> Units = new Dictionary<string, SortedDictionary<string, int>>() 
        {
            {"Minutes", new SortedDictionary<string, int> () {{"minute", 1}, {"hour", 60}, {"day", 60 * 24}, {"month", 60 * 24 * 30}, {"year", 60 * 24 * 365}}},
            {"Hours", new SortedDictionary<string, int> () {{"hour", 1}, {"day", 24}, {"month", 24 * 30}, {"year", 24 * 365}}},
            {"Days", new SortedDictionary<string, int> () {{"day", 1}, {"month", 30}, {"year", 365}}}, 
            {"Months", new SortedDictionary<string, int> () {{"month", 1}, {"year", 12}}}
        };

        //Names
        public static Dictionary<string, List<string>> Names = new Dictionary<string, List<string>>()
        {
            {"Minutes", new List<string>() { "year", "month", "day", "hour", "minute" }},
            {"Hours", new List<string>() { "year", "month", "day", "hour" }},
            {"Days", new List<string>() { "year", "month", "day" }},
            {"Months", new List<string>() { "year", "month" }},
        };
    }
}
