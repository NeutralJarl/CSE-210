namespace EternalQuest
{
    abstract class Goal
    {
        private string _name;
        private int _points;

        public string Name
        {
            get => _name;
            protected set => _name = value;
        }

        public int Points
        {
            get => _points;
            protected set => _points = value;
        }

        public abstract void Record();
        public abstract bool IsCompleted();
        public abstract void Display();
    }
}