//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace MeetingSecond
//{
//    internal class Meeting
//    {
//        private int startHour;
//        private int minutes;
//        private string content;
//        public Meeting(int startHour, int minutes, string content)
//        {
//            this.startHour = startHour;
//            this.minutes = minutes;
//            this.content = content;
//        }
//        public int GetHour() { return startHour; }
//        public int GetMinutes() { return minutes; }
//        public string GetContent() { return content; }
//    }
//}
namespace MeetingSecond
{
    internal class Meeting
    {
        private int startHour;
        private int minutes;
        private string content;

        public Meeting(int startHour, int minutes, string content)
        {
            this.startHour = startHour;
            this.minutes = minutes;
            this.content = content;
        }

        public int GetHour() { return startHour; }
        public int GetMinutes() { return minutes; }
        public string GetContent() { return content; }
    }
}

