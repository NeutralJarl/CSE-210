namespace EternalQuest
{
    class SimpleGoal : Goal
    {
        private bool _completed;

        public SimpleGoal(string name, int points)
        {
            Name = name;
            Points = points;
            _completed = false;
        }

        public override void Record()
        {
            _completed = true;
        }

        public override bool IsCompleted()
        {
            return _completed;
        }

        public override void Display()
        {
            Console.WriteLine($"[{(_completed ? "X" : " ")}] {Name} - {Points} points");
        }

        public bool Completed
        {
            get => _completed;
            set => _completed = value;
        }
    }
}
