using MeetingTrackManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace MeetingTrackManagement.Controllers
{
    public class MeetingTrackManagerController : ApiController
    {

        MeetingTrackManager[] meetingtrackmanager = new MeetingTrackManager[]
        {
            new MeetingTrackManager {Id=1, talkTitle = "Writing Fast Tests Against Enterprise Rails", talkLength =  60 },
            new MeetingTrackManager {Id=2, talkTitle = "Overdoing it in Python",talkLength =  45  },
            new MeetingTrackManager {Id=3, talkTitle = "Lua for the Masses", talkLength= 30 },
            new MeetingTrackManager {Id=4, talkTitle = "Ruby Errors from Mismatched Gem Versions", talkLength = 45 },
            new MeetingTrackManager {Id=5, talkTitle = "Common Ruby Errors", talkLength = 45 },
            new MeetingTrackManager {Id=6, talkTitle = "Rails for Python Developers lightning", talkLength =  35 },
            new MeetingTrackManager {Id=7, talkTitle = "Communicating Over Distance", talkLength =  60 },
            new MeetingTrackManager {Id=8, talkTitle = "Accounting-Driven Development", talkLength =  45 },
            new MeetingTrackManager {Id=9, talkTitle = "Woah", talkLength =  30 },
            new MeetingTrackManager {Id=10, talkTitle = "Sit Down and Write", talkLength =  30 },
            new MeetingTrackManager {Id=11, talkTitle = "Pair Programming vs Noise", talkLength =  45 },
            new MeetingTrackManager {Id=12, talkTitle = "Rails Magic", talkLength =  60 },
            new MeetingTrackManager {Id=13, talkTitle = "Ruby on Rails: Why We Should Move On?", talkLength =  60 },
            new MeetingTrackManager {Id=14, talkTitle = "Clojure Ate Scala (on my project)", talkLength =  45 },
            new MeetingTrackManager {Id=15, talkTitle = "Programming in the Boondocks of Seattle", talkLength =  30 },
            new MeetingTrackManager {Id=16, talkTitle = "Ruby vs. Clojure for Back-End Development", talkLength =  30 },
            new MeetingTrackManager {Id=17, talkTitle = "Ruby on Rails Legacy App Maintenance", talkLength =  60 },
            new MeetingTrackManager {Id=18, talkTitle = "A World Without HackerNews", talkLength =  30 },
            new MeetingTrackManager {Id=19, talkTitle = "User Interface CSS in Rails Apps", talkLength =  30 }
        };
             

    public IEnumerable<MeetingTrackManager> GetAllMeetings()
        {
           
            return meetingtrackmanager;
            

        }

         public IEnumerable<MeetingTrackManager> GetplannednedMettings()
         {

            //this.meetingPlanner;
            return meetingtrackmanager;

         }

        public IHttpActionResult GetMeetings(int id)
        {
            var meeting = meetingtrackmanager.FirstOrDefault((p) => p.Id == id);
            if (meeting == null)
            {
                return NotFound();
            }
            return Ok(meeting);
        }

        

    }
    public class MeetingPlanner
    {
        public void meetingPlanner()
        {

            var meeting_names = new List<string> {"Writing Fast Tests Against Enterprise Rails", "Overdoing it in Python","Lua for the Masses" ,
            "Ruby Errors from Mismatched Gem Versions","Common Ruby Errors","Rails for Python Developers lightning","Communicating Over Distance",
            "Accounting-Driven Development","Woah","Sit Down and Write","Pair Programming vs Noise","Rails Magic","Ruby on Rails: Why We Should Move On?",
            "Clojure Ate Scala (on my project)","Programming in the Boondocks of Seattle","Ruby vs. Clojure for Back-End Development","Ruby on Rails Legacy App Maintenance",
            "A World Without HackerNews","User Interface CSS in Rails Apps" };
            var meetings_duration = new List<int> { 60, 45, 30, 45, 45, 35, 60, 45, 30, 30, 45, 60, 60, 45, 30, 30, 60, 30, 30 };
            var meetings_ids = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18 };
            var tracks = new List<int> { 1, 2 };
            var skipped = new List<int> { };
            var new_meeting_ids = new List<int> { };

            var new_meeting_names = new List<string> { };
            int morning_session = 180, afternoon_session = 240;//,  lunch_session=60; 
            var fixed_timed_sessions = new List<string> { "Lunch", "Networking Event", };
            var timeSpan = DateTime.Today;
            timeSpan = timeSpan.AddHours(9);

            var next_track = DateTime.Today;
            next_track = next_track.AddHours(9);


            int total_meeting_duration = 0, track_two_duration = 0;
            foreach (var duration in meetings_ids)
            {


                int mins = meetings_duration[duration];

                //total_meeting_duration = total_meeting_duration + meetings_duration[duration];
                if ((total_meeting_duration + meetings_duration[duration]) <= morning_session & (timeSpan <= timeSpan.AddHours(12)))
                {
                    //var timespan = DateTime.Today ;
                    //if (timespan  <= timespan.AddHours(12))

                    //Console.WriteLine(duration);
                    total_meeting_duration = total_meeting_duration + meetings_duration[duration];
                    new_meeting_ids.Add(meetings_ids[duration]);
                    new_meeting_names.Add(meeting_names[duration]);
                    Console.WriteLine(timeSpan.ToString("hh:mm tt") + " " + meeting_names[duration] + ": " + meetings_duration[duration] + "min");
                    timeSpan = timeSpan.AddMinutes(mins);


                }
                else if ((total_meeting_duration == morning_session))
                {
                    total_meeting_duration = total_meeting_duration + meetings_duration[duration];
                    //mins = lunch_session;
                    new_meeting_ids.Add(meetings_ids[duration]);
                    new_meeting_names.Add(fixed_timed_sessions[0]);
                    Console.WriteLine(timeSpan.ToString("hh:mm tt") + " " + fixed_timed_sessions[0]);
                    //Console.WriteLine("I CAME HERE BRO ---------" + mins);
                    timeSpan = timeSpan.AddMinutes(60);

                    if ((total_meeting_duration + meetings_duration[duration]) > (morning_session) & (timeSpan <= timeSpan.AddHours(12)))
                    {

                        //Console.WriteLine("I CAME HERE BRO______________");
                        //timeSpan = timeSpan.AddMinutes(60);
                        //total_meeting_duration = total_meeting_duration - meetings_duration[duration] ;
                        total_meeting_duration = 0;
                    }
                    if ((total_meeting_duration + meetings_duration[duration]) <= (afternoon_session))
                    {
                        if (timeSpan == timeSpan.AddHours(12))
                        {
                            //Console.WriteLine("I CAME HERE BRO ---------" + timeSpan.AddHours(13));
                            //timeSpan = timeSpan.AddMinutes(meetings_duration[duration]);
                            new_meeting_ids.Add(meetings_ids[duration]);
                            new_meeting_names.Add(meeting_names[duration]);
                            Console.WriteLine(timeSpan.ToString("hh:mm tt") + " " + new_meeting_names[duration] + ": " + meetings_duration[duration] + "min");
                            timeSpan = timeSpan.AddMinutes(meetings_duration[duration]);
                        }
                        if (timeSpan > timeSpan.AddHours(12))
                        {
                            Console.WriteLine("I CAME HERE BRO ---------" + timeSpan.AddHours(13));
                            timeSpan = timeSpan.AddMinutes(meetings_duration[duration]);
                            new_meeting_ids.Add(meetings_ids[duration]);
                            new_meeting_names.Add(meeting_names[duration]);
                            Console.WriteLine(timeSpan.ToString("hh:mm tt") + " " + new_meeting_names[duration] + ": " + meetings_duration[duration] + "min");
                            timeSpan = timeSpan.AddMinutes(meetings_duration[duration]);
                        }

                    }

                }
                else if ((total_meeting_duration + meetings_duration[duration]) >= (afternoon_session) & (timeSpan > timeSpan.AddHours(13)))
                {
                    //Console.WriteLine("I CAME HERE BRO______________" +timeSpan.AddHours(13) );
                    //timeSpan = timeSpan.AddMinutes(-(meetings_duration[duration]));
                    //total_meeting_duration = total_meeting_duration - meetings_duration[duration] ;
                    total_meeting_duration = 0;
                    if ((total_meeting_duration + meetings_duration[duration]) <= afternoon_session)
                        if (total_meeting_duration != afternoon_session)
                        {
                            {
                                //Console.WriteLine("I CAME HERE BRO______________" +timeSpan.AddHours(13) );
                                total_meeting_duration = total_meeting_duration + meetings_duration[duration];
                                new_meeting_ids.Add(meetings_ids[duration]);
                                new_meeting_names.Add(meeting_names[duration]);
                                Console.WriteLine(timeSpan.ToString("hh:mm tt") + " " + new_meeting_names[duration] + ": " + meetings_duration[duration] + "min");
                                timeSpan = timeSpan.AddMinutes(meetings_duration[duration]);
                            }

                        }
                }
                else //if ((total_meeting_duration +  meetings_duration[duration]) > afternoon_session ) 
                {
                    var networking_time = DateTime.Today;
                    var networkingstart__time = DateTime.Today;

                    if (timeSpan < networking_time.AddHours(17))
                    {
                        new_meeting_ids.Add(meetings_ids[duration]);
                        new_meeting_names.Add(fixed_timed_sessions[1]);


                        Console.WriteLine(networkingstart__time.AddHours(17).ToString("hh:mm tt") + " " + fixed_timed_sessions[1]);
                        timeSpan = timeSpan.AddHours(17);

                    }

                    if ((track_two_duration + meetings_duration[duration]) <= morning_session & (next_track <= next_track.AddHours(12)))
                    {
                        track_two_duration = track_two_duration + meetings_duration[duration];
                        new_meeting_ids.Add(meetings_ids[duration]);
                        new_meeting_names.Add(meeting_names[duration]);
                        Console.WriteLine(next_track.ToString("hh:mm tt") + " " + meeting_names[duration] + ": " + meetings_duration[duration] + "min");
                        next_track = next_track.AddMinutes(mins);

                        if (duration == meetings_duration.Count - 1)
                        {
                            new_meeting_ids.Add(meetings_ids[duration]);
                            new_meeting_names.Add(fixed_timed_sessions[1]);

                            Console.WriteLine(networkingstart__time.AddHours(17).ToString("hh:mm tt") + " " + fixed_timed_sessions[1]);
                            timeSpan = timeSpan.AddHours(17);

                        }
                    }
                    else if ((track_two_duration == morning_session))
                    {
                        track_two_duration = track_two_duration + meetings_duration[duration];
                        new_meeting_ids.Add(meetings_ids[duration]);
                        new_meeting_names.Add(fixed_timed_sessions[0]);
                        Console.WriteLine(next_track.ToString("hh:mm tt") + " " + fixed_timed_sessions[0]);
                        next_track = next_track.AddMinutes(60);
                        if ((track_two_duration + meetings_duration[duration]) > (morning_session) & (next_track <= next_track.AddHours(12)))
                        {

                            track_two_duration = 0;
                        }
                        if ((track_two_duration + meetings_duration[duration]) <= (afternoon_session))
                        {
                            if (next_track == next_track.AddHours(12))
                            {
                                new_meeting_ids.Add(meetings_ids[duration]);
                                new_meeting_names.Add(meeting_names[duration]);
                                Console.WriteLine(next_track.ToString("hh:mm tt") + " " + new_meeting_names[duration] + ": " + meetings_duration[duration] + "min");
                                next_track = next_track.AddMinutes(meetings_duration[duration]);
                            }
                            if (next_track > next_track.AddHours(12))
                            {
                                next_track = next_track.AddMinutes(meetings_duration[duration]);
                                new_meeting_ids.Add(meetings_ids[duration]);
                                new_meeting_names.Add(meeting_names[duration]);
                                Console.WriteLine(next_track.ToString("hh:mm tt") + " " + new_meeting_names[duration] + ": " + meetings_duration[duration] + "min");
                                next_track = next_track.AddMinutes(meetings_duration[duration]);
                            }

                        }
                    }

                }


            }

        }

    }

}