using System;

namespace StudentLifeSimulation
{
    public delegate void PartyEventHandler(object sender, PartyEventArgs e);
    public delegate void ExamEventHandler(object sender, ExamEventArgs e);
    public delegate void EventAttendanceEventHandler(object sender, EventAttendanceEventArgs e);

    public class StudentLife
    {
        private string studentName;
        private int dormRooms;
        private int days;
        private PartyOrganizer partyOrganizer;
        private ExamScheduler examScheduler;
        private EventAttendee eventAttendee;

        public event PartyEventHandler Party;
        public event ExamEventHandler Exam;
        public event EventAttendanceEventHandler EventAttendance;

        private Random rnd = new Random();

        public StudentLife(string name, int rooms, int days)
        {
            studentName = name;
            dormRooms = rooms;
            this.days = days;
            partyOrganizer = new PartyOrganizer(this);
            examScheduler = new ExamScheduler(this);
            eventAttendee = new EventAttendee(this);
        }

        protected virtual void OnParty(PartyEventArgs e)
        {
            const string MESSAGE_PARTY = "Студент {0} влаштовує вечірку в кімнаті {1} в {2}-й день.";
            Console.WriteLine(string.Format(MESSAGE_PARTY, studentName, e.Room, e.Day));

            Party?.Invoke(this, e);
        }

        protected virtual void OnExam(ExamEventArgs e)
        {
            const string MESSAGE_EXAM = "Студент {0} має екзамен {1} в {2}-й день.";
            Console.WriteLine(string.Format(MESSAGE_EXAM, studentName, e.Subject, e.Day));

            Exam?.Invoke(this, e);
        }

        protected virtual void OnEventAttendance(EventAttendanceEventArgs e)
        {
            const string MESSAGE_EVENT = "Студент {0} відвідав захід \"{1}\" в {2}-й день.";
            Console.WriteLine(string.Format(MESSAGE_EVENT, studentName, e.EventName, e.Day));

            EventAttendance?.Invoke(this, e);
        }

        public void SimulateStudentLife()
        {
            for (int day = 1; day <= days; day++)
            {
                if (rnd.NextDouble() < 0.1) // Ймовірність влаштувати вечірку
                {
                    int room = rnd.Next(1, dormRooms + 1);
                    PartyEventArgs e = new PartyEventArgs(room, day);
                    OnParty(e);
                }

                if (rnd.NextDouble() < 0.2) // Ймовірність мати екзамен
                {
                    string[] subjects = { "Математика", "Фізика", "Історія", "Література", "Хімія" };
                    string subject = subjects[rnd.Next(subjects.Length)];
                    ExamEventArgs e = new ExamEventArgs(subject, day);
                    OnExam(e);
                }

                if (rnd.NextDouble() < 0.3) // Ймовірність відвідати захід
                {
                    string[] events = { "Вечірка в клубі", "Кіно з друзями", "Концерт університетського оркестру", "Студентська конференція" };
                    string eventName = events[rnd.Next(events.Length)];
                    EventAttendanceEventArgs e = new EventAttendanceEventArgs(eventName, day);
                    OnEventAttendance(e);
                }
            }
        }
    }

    public class PartyOrganizer
    {
        private StudentLife studentLife;

        public PartyOrganizer(StudentLife studentLife)
        {
            this.studentLife = studentLife;
            studentLife.Party += PartyTime;
        }

        private void PartyTime(object sender, PartyEventArgs e)
        {
            const string MESSAGE_POLICE = "Поліція виїхала на вечірку в кімнату {0}.";
            if (new Random().Next(0, 10) > 7)
                Console.WriteLine(string.Format(MESSAGE_POLICE, e.Room));
        }
    }

    public class ExamScheduler
    {
        private StudentLife studentLife;

        public ExamScheduler(StudentLife studentLife)
        {
            this.studentLife = studentLife;
            studentLife.Exam += StudyForExam;
        }

        private void StudyForExam(object sender, ExamEventArgs e)
        {
            Console.WriteLine("Студент готується до іспиту з {0}.", e.Subject);
        }
    }

    public class EventAttendee
    {
        private StudentLife studentLife;

        public EventAttendee(StudentLife studentLife)
        {
            this.studentLife = studentLife;
            studentLife.EventAttendance += AttendEvent;
        }

        private void AttendEvent(object sender, EventAttendanceEventArgs e)
        {
            Console.WriteLine("Студент відвідав захід \"{0}\".", e.EventName);
        }
    }

    public class PartyEventArgs : EventArgs
    {
        public int Room { get; }
        public int Day { get; }

        public PartyEventArgs(int room, int day)
        {
            Room = room;
            Day = day;
        }
    }

    public class ExamEventArgs : EventArgs
    {
        public string Subject { get; }
        public int Day { get; }

        public ExamEventArgs(string subject, int day)
        {
            Subject = subject;
            Day = day;
        }
    }

    public class EventAttendanceEventArgs : EventArgs
    {
        public string EventName { get; }
        public int Day { get; }

        public EventAttendanceEventArgs(string eventName, int day)
        {
            EventName = eventName;
            Day = day;
        }
    }
}