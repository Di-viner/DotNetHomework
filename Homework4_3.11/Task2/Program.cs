using System;
namespace SimulateClock
{
    public class Clock
    {
        public event Action Tick;
        public event Action<DateTime> Alarm;
        public DateTime AlarmTime { get; set; }
        public Clock(DateTime a)
        {
            AlarmTime = a;
        }
        public void start()
        {
            while(true)
            {
                Tick();
                if (DateTime.Now > AlarmTime)
                    Alarm(AlarmTime);
                Thread.Sleep(1000);
            }
        }
    }
    public class Task2
    {
        public static void Main(string[] args)
        {
            Clock myClock = new(DateTime.Now.AddMinutes(0.5));
            myClock.Tick += TickHandler;
            myClock.Alarm += AlarmHandler;
            myClock.start();
        }
        public static void TickHandler()
        {
            Console.WriteLine("Clock ticks: " + DateTime.Now.ToString());
        }
        public static void AlarmHandler(DateTime alarmTime)
        {
            Console.WriteLine("Clock rings: " + alarmTime.ToString());
        }     
    }
}
