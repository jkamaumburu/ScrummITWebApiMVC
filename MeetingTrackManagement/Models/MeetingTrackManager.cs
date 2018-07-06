using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MeetingTrackManagement.Models
{
    public class MeetingTrackManager
    {
        //Common and fixed sessions
        public int morningSession = 180;
        public int lunchSession = 60;
        public int afternoonSession = 180;
        public int networkingSession = 60;

        //Random/Changing talks
        public int Id { get; set; }
        public string talkTitle { get; set; }
        public int talkLength { get; set; }

        public void PlanMeeting()
        {
            var meeting_names = new List<string> {"Writing Fast Tests Against Enterprise Rails", "Overdoing it in Python",
                    "Lua for the Masses" ,"Ruby Errors from Mismatched Gem Versions" };
            var meetings_duration = new List<int> { 60, 45, 30, 45 };
            var meetings_ids = new List<int> { 1, 2, 3 };
            var tracks = new List<int> { 1, 2 };

            foreach (var duration in meetings_duration)
            {

                Console.WriteLine(meetings_duration[duration]);

            }


            //var new_plans = new List<int>

        }
    }

    public class Track : MeetingTrackManager
    {
        public int trackid { get; set; }
        public string Name { get; set; }
    }
    public class Planner :Track
    {
        public void PlanMeeting()
        {
            
            var meeting_names = new List<string> { };
            var meetings_duration = new List<int> { };
            var tracks = new List<int> { 1, 2 };

        }
    }
}