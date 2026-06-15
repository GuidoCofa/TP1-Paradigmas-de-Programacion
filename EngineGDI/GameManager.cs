namespace EngineGDI
{
    public class GameManager
    {
       
        private static GameManager instance;
        
        private static readonly object padlock = new object();

        
        private GameManager() { }

        
        public static GameManager Instance
        {
            get
            {

                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new GameManager();
                        }
                    }
                }
                return instance;
            }
        }

        public int Score { get; private set; }
        public int Lives { get; private set; }
        public int TargetScore { get; private set; }

        // Consigna 3: Crear y usar dos eventos en situaciones que lo ameriten.
        public event System.Action OnScoreAdded;
        public event System.Action OnLifeLost;

        public void StartNewGame()
        {
            Score = 0;
            Lives = 3;
            TargetScore = 50;
        }

        public void AddScore(int amount)
        {
            Score += amount;
            OnScoreAdded?.Invoke();
        }

        public void LoseLife()
        {
            Lives--;
            OnLifeLost?.Invoke();
        }

        public bool IsVictory() => Score >= TargetScore;
        public bool IsDefeat() => Lives <= 0;
    }
}