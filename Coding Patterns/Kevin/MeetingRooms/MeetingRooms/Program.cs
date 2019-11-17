using System;
using System.Collections.Generic;

class MainClass
{

    public static string MostFreeTime(string[] strArr)
    {

        // code goes here  
        List<ParsedTime> times = new List<ParsedTime>();
        foreach (var time in strArr)
        {
            var period = time.Split('-');
            var startTime = GetParsedTime(period[0]);
            startTime.EndTime = GetParsedTime(period[1]);
            times.Add(startTime);
        }

        times.Sort((x, y) =>
        {
            return x.TotalMinutes - y.TotalMinutes;
        });

        var interval = 0;
        var maxInterval = 0;
      for (int i = 0; i < times.Count - 1; i++)
        {
            var endTimeOfEvent = times[i].EndTime;
            var startTimeOfNextEvent = times[i + 1];

            interval = startTimeOfNextEvent.TotalMinutes - endTimeOfEvent.TotalMinutes;
            if (interval > maxInterval)
            {
                maxInterval = interval;
            }

        }
        string result = String.Empty;
        if (maxInterval < 60)
        {

            result = "00:" + Format(maxInterval);
        }
        else
        {
            var hours = Convert.ToInt32(maxInterval / 60);
            var minutes = maxInterval % 60;

            result = Format(hours) + ":" + Format(minutes);
        }

        return result;

    }

    private static string Format(int time)
    {
        if (time < 10)
            return "0" + time.ToString();
        else
            return time.ToString();
    }



    private static ParsedTime GetParsedTime(string time)
    {
        var timeParts = time.Split(':');
        int hours = Convert.ToInt32(timeParts[0]);
        int minutes = Convert.ToInt32(timeParts[1].Substring(0, 2));
        string amOrPm = timeParts[1].Substring(2, 2).ToUpper();
        int totalMinutes = hours * 60 + minutes;
        if (amOrPm == 'PM' && hours < 12)
            totalMinutes += 12 * 60
  

    return new ParsedTime { Hours = hours, Minutes = minutes, AMOrPM = amOrPm, TotalMinutes = totalMinutes };
    }



    static void Main()
    {
        // keep this function call here
        Console.WriteLine(MostFreeTime(Console.ReadLine()));
    }

}


public class ParsedTime
{

    public int Hours { get; set; }
    public int Minutes { get; set; }
    public string AMOrPM { get; set; }
    public int TotalMinutes { get; set; }

    public ParsedTime EndTime { get; set; }
}