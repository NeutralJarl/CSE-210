namespace EternalQuest
{
    class ChecklistGoal : Goal
    {
        private int _targetCount;
        private int _currentCount;
        private int _bonusPoints;

        public ChecklistGoal(string name, int points, int targetCount, int bonusPoints)
        {
            Name = name;
            Points = points;
            _targetCount = targetCount;
            _bonusPoints = bonusPoints;
            _currentCount = 0;
        }

        public override void Record()
        {
            _currentCount++;
        }

        public override bool IsCompleted()
        {
            return _currentCount >= _targetCount;
        }

        public override void Display()
        {
            Console.WriteLine($"[{(_currentCount >= _targetCount ? "X" : " ")}] {Name} - {Points} points each time (Completed {_currentCount}/{_targetCount} times, Bonus: {_bonusPoints} points)");
        }

        public int CurrentCount
        {
            get => _currentCount;
            set => _currentCount = value;
        }

        public int TargetCount
        {
            get => _targetCount;
            set => _targetCount = value;
        }

        public int BonusPoints
        {
            get => _bonusPoints;
            set => _bonusPoints = value;
        }
    }
}