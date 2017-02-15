using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetTConverter
{
    //TConvert class
    #region Regular TConvert class
    public class TConvert
    {
        //Constructor
        public TConvert() { }

        // Converting Minutes to readable string
        public string Minutes(int Minutes)
        {
            return convert(Minutes, "Minutes");
        }
        public string Hours(int Hours)
        {
            return convert(Hours, "Hours");
        }
        public string Days(int Days)
        {
            return convert(Days, "Days");
        }
        public string Months(int Months)
        {
            return convert(Months, "Months");
        }
        public string Years(int Years)
        {
            return Years + " years";
        }

        //Convert minutes
        public double MinutesToHours(int Minutes)
        {
            return TimeSpan.FromMinutes(Minutes).TotalHours;
        }
        public double MinutesToDays(int Minutes)
        {
            return TimeSpan.FromMinutes(Minutes).TotalDays;
        }
        public double MinutesToSeconds(int Minutes)
        {
            return TimeSpan.FromMinutes(Minutes).TotalSeconds;
        }
        //Convert hours
        public double HoursToMinutes(int Hours)
        {
            return TimeSpan.FromHours(Hours).TotalMinutes;
        }
        public double HoursToDays(int Hours)
        {
            return TimeSpan.FromHours(Hours).TotalDays;
        }
        public double HoursToSeconds(int Hours)
        {
            return TimeSpan.FromHours(Hours).TotalSeconds;
        }
        //Convert days
        public double DaysToMinutes(int Days)
        {
            return TimeSpan.FromDays(Days).TotalMinutes;
        }
        public double DaysToHours(int Days)
        {
            return TimeSpan.FromDays(Days).TotalHours;
        }
        public double DaysToSeconds(int Days)
        {
            return TimeSpan.FromDays(Days).TotalMinutes;
        }
        //Convert seconds
        public double SecondsToDays(int Seconds)
        {
            return TimeSpan.FromSeconds(Seconds).TotalDays;
        }
        public double SecondsToHours(int Seconds)
        {
            return TimeSpan.FromSeconds(Seconds).TotalHours;
        }
        public double SecondsToMinutes(int Seconds)
        {
            return TimeSpan.FromSeconds(Seconds).TotalMinutes;
        }


        //Convert function
        private string convert(int Value, string Case)
        {
            try
            {
                //Error check
                if (Value < 0)
                    return "Negative value";
                else if (Value == 0)
                    return "0 value";
                else
                {
                    //Map time units to the number of minutes they contain
                    //(i.e. 60 minutes per hour, etc.)
                    SortedDictionary<String, int> timeUnits = new SortedDictionary<string,int>();
                    if (Case.Trim().ToLower().Equals("minutes"))
                        timeUnits = TimeUnits.Units["Minutes"];
                    else if (Case.Trim().ToLower().Equals("hours"))
                        timeUnits = TimeUnits.Units["Hours"];
                    else if (Case.Trim().ToLower().Equals("days"))
                        timeUnits = TimeUnits.Units["Days"];
                    else
                        timeUnits = TimeUnits.Units["Months"];

                    //Result from conversion
                    SortedDictionary<String, int> Results = new SortedDictionary<String, int>();

                    //Sort the time in descending order
                    List<string> Names = new List<string>();
                    if (Case.Trim().ToLower().Equals("minutes"))
                        Names = TimeUnits.Names["Minutes"];
                    else if (Case.Trim().ToLower().Equals("hours"))
                        Names = TimeUnits.Names["Hours"];
                    else if (Case.Trim().ToLower().Equals("days"))
                        Names = TimeUnits.Names["Days"];
                    else
                        Names = TimeUnits.Names["Months"];

                    int tRemaining = Value;
                    foreach (string unit in Names)
                    {
                        int divisor = timeUnits[unit];
                        Results.Add(unit, tRemaining / divisor);
                        tRemaining %= divisor;
                    }

                    //Composing out string
                    StringBuilder toReturnSB = new StringBuilder();

                    //Check the results for a maximal time unit to have a non-zero value
                    //and remember the unit's position in the sorted "names" array
                    int Position = -1;
                    for (int i = 0; i < Names.Count(); i++)
                    {
                        if (Results[Names[i]] != 0)
                        {
                            Position = i; break;
                        }
                    }

                    //Limit output to 3 consecutive values if input larger than year, 2 otherwise
                    int Offset = Names[Position].Equals("year") ? 3 : 2;

                    //Iterate through appropriate time units and append their respective values
                    //to the output string:
                    for (int i = Position; i < Position + Offset && i < Names.Count(); i++)
                    {
                        int n = Results[Names[i]];
                        if (n == 0) continue;
                        if (i > Position)
                        {
                            //Add comma or "and" between the values
                            toReturnSB.Append(i == Position + Offset - 1 ? " and " : ", ");
                        }
                        toReturnSB.Append(n + " " + Names[i]);
                        //Plural suffix
                        if (n > 1) toReturnSB.Append("s");
                    }
                    //Return the result
                    return toReturnSB.ToString().Trim();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    #endregion


    //Static Class
    #region Static TConvert class - TSConvert
    public static class TSConvert
    {
        // Converting Minutes to readable string
        public static string Minutes(int Minutes)
        {
            return staticConvert(Minutes, "Minutes");
        }
        public static string Hours(int Hours)
        {
            return staticConvert(Hours, "Hours");
        }
        public static string Days(int Days)
        {
            return staticConvert(Days, "Days");
        }
        public static string Months(int Months)
        {
            return staticConvert(Months, "Months");
        }
        public static string Years(int Years)
        {
            return Years + " years";
        }

        //Convert minutes
        public static double MinutesToHours(int Minutes)
        {
            return TimeSpan.FromMinutes(Minutes).TotalHours;
        }
        public static double MinutesToDays(int Minutes)
        {
            return TimeSpan.FromMinutes(Minutes).TotalDays;
        }
        public static double MinutesToSeconds(int Minutes)
        {
            return TimeSpan.FromMinutes(Minutes).TotalSeconds;
        }
        //Convert hours
        public static double HoursToMinutes(int Hours)
        {
            return TimeSpan.FromHours(Hours).TotalMinutes;
        }
        public static double HoursToDays(int Hours)
        {
            return TimeSpan.FromHours(Hours).TotalDays;
        }
        public static double HoursToSeconds(int Hours)
        {
            return TimeSpan.FromHours(Hours).TotalSeconds;
        }
        //Convert days
        public static double DaysToMinutes(int Days)
        {
            return TimeSpan.FromDays(Days).TotalMinutes;
        }
        public static double DaysToHours(int Days)
        {
            return TimeSpan.FromDays(Days).TotalHours;
        }
        public static double DaysToSeconds(int Days)
        {
            return TimeSpan.FromDays(Days).TotalMinutes;
        }
        //Convert seconds
        public static double SecondsToDays(int Seconds)
        {
            return TimeSpan.FromSeconds(Seconds).TotalDays;
        }
        public static double SecondsToHours(int Seconds)
        {
            return TimeSpan.FromSeconds(Seconds).TotalHours;
        }
        public static double SecondsToMinutes(int Seconds)
        {
            return TimeSpan.FromSeconds(Seconds).TotalMinutes;
        }


        //Convert function
        private static string staticConvert(int Value, string Case)
        {
            try
            {
                //Error check
                if (Value < 0)
                    return "Negative value";
                else if (Value == 0)
                    return "0 value";
                else
                {
                    //Map time units to the number of minutes they contain
                    //(i.e. 60 minutes per hour, etc.)
                    SortedDictionary<String, int> timeUnits = new SortedDictionary<string, int>();
                    if (Case.Trim().ToLower().Equals("minutes"))
                        timeUnits = TimeUnits.Units["Minutes"];
                    else if (Case.Trim().ToLower().Equals("hours"))
                        timeUnits = TimeUnits.Units["Hours"];
                    else if (Case.Trim().ToLower().Equals("days"))
                        timeUnits = TimeUnits.Units["Days"];
                    else
                        timeUnits = TimeUnits.Units["Months"];

                    //Result from conversion
                    SortedDictionary<String, int> Results = new SortedDictionary<String, int>();

                    //Sort the time in descending order
                    List<string> Names = new List<string>();
                    if (Case.Trim().ToLower().Equals("minutes"))
                        Names = TimeUnits.Names["Minutes"];
                    else if (Case.Trim().ToLower().Equals("hours"))
                        Names = TimeUnits.Names["Hours"];
                    else if (Case.Trim().ToLower().Equals("days"))
                        Names = TimeUnits.Names["Days"];
                    else
                        Names = TimeUnits.Names["Months"];

                    int tRemaining = Value;
                    foreach (string unit in Names)
                    {
                        int divisor = timeUnits[unit];
                        Results.Add(unit, tRemaining / divisor);
                        tRemaining %= divisor;
                    }

                    //Composing out string
                    StringBuilder toReturnSB = new StringBuilder();

                    //Check the results for a maximal time unit to have a non-zero value
                    //and remember the unit's position in the sorted "names" array
                    int Position = -1;
                    for (int i = 0; i < Names.Count(); i++)
                    {
                        if (Results[Names[i]] != 0)
                        {
                            Position = i; break;
                        }
                    }

                    //Limit output to 3 consecutive values if input larger than year, 2 otherwise
                    int Offset = Names[Position].Equals("year") ? 3 : 2;

                    //Iterate through appropriate time units and append their respective values
                    //to the output string:
                    for (int i = Position; i < Position + Offset && i < Names.Count(); i++)
                    {
                        int n = Results[Names[i]];
                        if (n == 0) continue;
                        if (i > Position)
                        {
                            //Add comma or "and" between the values
                            toReturnSB.Append(i == Position + Offset - 1 ? " and " : ", ");
                        }
                        toReturnSB.Append(n + " " + Names[i]);
                        //Plural suffix
                        if (n > 1) toReturnSB.Append("s");
                    }
                    //Return the result
                    return toReturnSB.ToString().Trim();
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
    #endregion
}
