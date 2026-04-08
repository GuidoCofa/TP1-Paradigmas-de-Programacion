namespace EngineGDI
{
    public class GameManager
    {
        private static GameManager instance;

        private GameManager() { }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new GameManager();
                return instance;
            }
        }

        public int Score { get; private set; }
        public int Lives { get; private set; }
        public int TargetScore { get; private set; }

        public void StartNewGame()
        {
            Score = 0;
            Lives = 3;
            TargetScore = 50;
        }

        public void AddScore(int amount) => Score += amount;
        public void LoseLife() => Lives--;

        public bool IsVictory() => Score >= TargetScore;
        public bool IsDefeat() => Lives <= 0;
    }
}