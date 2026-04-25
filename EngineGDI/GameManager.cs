namespace EngineGDI
{
    public class GameManager
    {
        // 3. Patrón Singleton Estricto:
        // Variable estática privada para almacenar la única instancia.
        private static GameManager instance;
        // Objeto para bloqueo (lock) de hilos (thread-safety), parte del modelo clásico en C#.
        private static readonly object padlock = new object();

        // Constructor privado: evita que se puedan crear instancias usando 'new GameManager()'.
        private GameManager() { }

        // Propiedad pública estática con instanciación perezosa (lazy initialization).
        public static GameManager Instance
        {
            get
            {
                // Double-checked locking para asegurar de forma estricta que 
                // solo haya una instancia incluso en entornos multihilo.
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