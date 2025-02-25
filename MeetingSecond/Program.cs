//using MeetingSecond;

using System;

namespace MeetingSecond
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // יצירת פגישות
            Meeting m1 = new Meeting(8, 30, "Meeting 1");
            Meeting m2 = new Meeting(11, 30, "Meeting 2");
            Meeting m3 = new Meeting(14, 30, "Meeting 3");
            Meeting m4 = new Meeting(16, 30, "Meeting 4");

            // יצירת רשימה מקושרת של פגישות
            Node<Meeting> meetingList = new Node<Meeting>(m1, null);
            meetingList = new Node<Meeting>(m2, meetingList);
            meetingList = new Node<Meeting>(m3, meetingList);
            meetingList = new Node<Meeting>(m4, meetingList);

            // יצירת יום ביומן עם הפגישות
            DayInSchedule day = new DayInSchedule(meetingList);

            // מציאת השעות הפנויות ביום
            Node<int> freeHours = day.GetFreeHours();
            while (freeHours != null)
            {
                Console.WriteLine($"Free hour: {freeHours.GetValue()}");
                freeHours = freeHours.GetNext();
            }

            // בדיקת אם אפשר לקבוע פגישה בשעה מסוימת
            bool isAvailable = day.CanStart(10, 59);
            Console.WriteLine($"Can start at 10:59? {isAvailable}");
            //day.LabelDay(meetingList, m1);
        }
    }

}