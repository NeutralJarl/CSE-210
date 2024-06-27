namespace EternalQuest
{
    class EternalGoal : Goal
    {
        private int _timesRecorded;

        public EternalGoal(string name, int points)
        {
            Name = name;
            Points = points;
            _timesRecorded = 0;
        }

        public override void Record()
        {
            _timesRecorded++;
        }

        public override bool IsCompleted()
        {
            return false;
        }

        public override void Display()
        {
            Console.WriteLine($"[∞] {Name} - {Points} points each time ({_timesRecorded} times recorded)");
        }

        public int TimesRecorded
        {
            get => _timesRecorded;
            set => _timesRecorded = value;
        }
    }
}