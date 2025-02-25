using MeetingSecond;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace MeetingSecond
{
    internal class DayInSchedule
    {
        private int day;
        private int month;
        private Node<Meeting> mList;
        public DayInSchedule(Node<Meeting> mList)
        {
            this.mList = mList;
        }
        public int GetDay() { return day; }
        public int GetMonth() { return month; }
        public Node<Meeting> GetMList() { return mList; }

        public Node<int> GetFreeHours()
        {
            Node<Meeting> current = mList;
            Node<int> freeHour = null;
            Node<int> endList = null;

            while (current != null)
            {
                int startH = current.GetValue().GetHour();
                int startM = current.GetValue().GetMinutes();
                int nextH;
                if (startM > 60)
                {
                    if (startM % 60 != 0)
                        nextH = startH + (startM / 60) + 1;
                    else
                        nextH = startH + (startM / 60);
                }
                else
                    nextH = startH + 1;
                int temp = nextH;
                Node<int> newNode = new Node<int>(nextH, null);
                if (freeHour == null)
                {
                    freeHour = newNode;
                }
                else
                {
                    endList.SetNext(newNode);
                }
                endList = newNode;
                current = current.GetNext();
            }
            return freeHour;
        }
        public bool CanStart(int startHour, int minute)
        {
            Node<int> fHour;
            fHour = GetFreeHours();
            while (fHour != null)
            {
                if (fHour.GetValue() == startHour)
                {
                    if (startHour + (minute / 60) < fHour.GetNext().GetValue())
                        return true;
                }
                fHour = fHour.GetNext();
            }
            return false;
        }
        public void LabelDay(Node<DayInSchedule> first, Meeting m)
        {
            bool isDay = false;
            while (first != null)
            {
                DayInSchedule currentDay = first.GetValue();
                Node<int> freeHours = GetFreeHours();
                while (freeHours != null)
                {
                    int startHour = freeHours.GetValue();
                    int endHour = freeHours.GetNext().GetValue();
                    if (m.GetHour() >= startHour && m.GetHour() + (m.GetMinutes() / 60.0) <= endHour)
                    {
                        isDay = true;
                        Console.WriteLine($"The meeting at {m.GetHour()} that takes {m.GetMinutes()} minutes can be on month {currentDay.month} in day {currentDay.day}");
                        break;
                    }
                    freeHours = freeHours.GetNext();
                }
                first = first.GetNext();
            }
            if (!isDay)
                Console.WriteLine("there are not empty day");
        }
    }
}








































//        internal class DayInSchedule
//        {
//            private Node<Meeting> mList;

//            public DayInSchedule(Node<Meeting> mList)
//            {
//                this.mList = mList;
//            }

//            // פונקציה למציאת השעות הפנויות ביום
//            public Node<int> GetFreeHours()
//            {
//                Node<Meeting> current = mList;
//                Node<int> freeHours = null;
//                Node<int> endList = null;
//                int previousEnd = 8; // מתחילים ב-8 בבוקר

//                // נוסיף את השעות הפנויות בין הפגישות
//                while (current != null)
//                {
//                    int startHour = current.GetValue().GetHour();
//                    int startMinutes = current.GetValue().GetMinutes();
//                    int nextHour = startHour + (startMinutes / 60) + (startMinutes % 60 > 0 ? 1 : 0); // הוספת השעה העגולה הבאה

//                    // הוספת שעות פנויות לפני הפגישה הנוכחית
//                    for (int hour = previousEnd; hour < nextHour && hour < 20; hour++)
//                    {
//                        Node<int> newNode = new Node<int>(hour, null);
//                        if (freeHours == null)
//                        {
//                            freeHours = newNode;
//                        }
//                        else
//                        {
//                            endList.SetNext(newNode);
//                        }
//                        endList = newNode;
//                    }

//                    previousEnd = nextHour; // עדכון השעה שבה הסתיימה הפגישה הנוכחית
//                    current = current.GetNext();
//                }

//                // הוספת שעות פנויות אחרי הפגישה האחרונה עד 8 בערב
//                for (int hour = previousEnd; hour < 20; hour++)
//                {
//                    Node<int> newNode = new Node<int>(hour, null);
//                    if (freeHours == null)
//                    {
//                        freeHours = newNode;
//                    }
//                    else
//                    {
//                        endList.SetNext(newNode);
//                    }
//                    endList = newNode;
//                }

//                return freeHours;
//            }

//            // פונקציה לבדיקת אם ניתן לקבוע פגישה בשעה נתונה
//            public bool CanStart(int startHour, int minute)
//            {
//                Node<int> fHour = GetFreeHours();
//                while (fHour != null)
//                {
//                    if (fHour.GetValue() == startHour)
//                    {
//                        if (startHour + (minute / 60) < fHour.GetNext().GetValue())
//                        {
//                            return true;
//                        }
//                    }
//                    fHour = fHour.GetNext();
//                }
//                return false;
//            }
//        }
//    }

//}
using System;

namespace MeetingSecond
{
    internal class DayInSchedule
    {
        private Node<Meeting> mList;

        public DayInSchedule(Node<Meeting> mList)
        {
            this.mList = mList;
        }

        // פונקציה למציאת השעות הפנויות ביום
        public Node<int> GetFreeHours()
        {
            Node<Meeting> current = mList;
            Node<int> freeHours = null;
            Node<int> endList = null;
            int previousEnd = 8; // מתחילים ב-8 בבוקר

            // נוסיף את השעות הפנויות בין הפגישות
            while (current != null)
            {
                int startHour = current.GetValue().GetHour();
                int startMinutes = current.GetValue().GetMinutes();
                int nextHour = startHour + (startMinutes / 60) + (startMinutes % 60 > 0 ? 1 : 0); // הוספת השעה העגולה הבאה

                // הוספת שעות פנויות לפני הפגישה הנוכחית
                for (int hour = previousEnd; hour < nextHour && hour < 20; hour++)
                {
                    Node<int> newNode = new Node<int>(hour, null);
                    if (freeHours == null)
                    {
                        freeHours = newNode;
                    }
                    else
                    {
                        endList.SetNext(newNode);
                    }
                    endList = newNode;
                }

                previousEnd = nextHour; // עדכון השעה שבה הסתיימה הפגישה הנוכחית
                current = current.GetNext();
            }

            // הוספת שעות פנויות אחרי הפגישה האחרונה עד 8 בערב
            for (int hour = previousEnd; hour < 20; hour++)
            {
                Node<int> newNode = new Node<int>(hour, null);
                if (freeHours == null)
                {
                    freeHours = newNode;
                }
                else
                {
                    endList.SetNext(newNode);
                }
                endList = newNode;
            }

            return freeHours;
        }

        // פונקציה לבדיקת אם ניתן לקבוע פגישה בשעה נתונה
        public bool CanStart(int startHour, int minute)
        {
            Node<int> fHour = GetFreeHours();
            while (fHour != null)
            {
                if (fHour.GetValue() == startHour)
                {
                    if (startHour + (minute / 60) < fHour.GetNext().GetValue())
                    {
                        return true;
                    }
                }
                fHour = fHour.GetNext();
            }
            return false;
        }

        // פונקציה להדפסת יומני פגישות
        public void LabelDay(Node<DayInSchedule> first, Meeting m)
        {
            bool isDay = false;

            while (first != null)
            {
                DayInSchedule currentDay = first.GetValue();
                Node<int> freeHours = currentDay.GetFreeHours();

                while (freeHours != null)
                {
                    int startHour = freeHours.GetValue();
                    int endHour = freeHours.GetNext()?.GetValue() ?? 20; // אם אין "שעה הבאה", סיים ב-8 בערב

                    // בדוק אם הפגישה יכולה להתקיים בשעה זו
                    if (m.GetHour() >= startHour && m.GetHour() + (m.GetMinutes() / 60.0) <= endHour)
                    {
                        isDay = true;
                        Console.WriteLine($"The meeting at {m.GetHour()} that takes ");
                        break;
                    }
                    freeHours = freeHours.GetNext();
                }

                first = first.GetNext();
            }

            if (!isDay)
                Console.WriteLine("There are no empty days for your meeting.");
        }
    }
}

