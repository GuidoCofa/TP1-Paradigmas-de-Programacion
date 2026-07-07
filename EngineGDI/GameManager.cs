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

        private int levelStartScore = 0;

        public void SaveLevelScore()
        {
            levelStartScore = Score;
        }
    
        public void StartNewGame(int levelIndex)
        {
            Lives = 3; // Siempre restablece las vidas al reintentar o cambiar de nivel
            
            if (levelIndex == 1)
            {
                Score = 0;
                levelStartScore = 0;
                TargetScore = 50; // Objetivo nivel 1
            }
            else if (levelIndex == 2)
            {
                Score = levelStartScore; // Revertir el score a como estaba al inicio del nivel
                TargetScore = levelStartScore + 100; // Requiere 100 puntos más
            }
            else if (levelIndex == 3)
            {
                Score = levelStartScore;
                TargetScore = levelStartScore + 150; // Requiere 150 puntos más
            }
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