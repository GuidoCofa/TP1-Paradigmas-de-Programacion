using System;
using System.Drawing;

namespace EngineGDI
{
    static class Program
    {
        public static float deltaTime;
        private static DateTime lastFrameTime = DateTime.Now;

        public static int SCREEN_WIDTH = 800;
        public static int SCREEN_HEIGHT = 450;

        // Máquina de estados requerida para las consignas 1, 3 y 4
        public enum GameState { Menu, Playing, Victory, Defeat }
        public static GameState currentState = GameState.Menu;

        private static Menu menu;
        public static GameLevel level; // Lo hacemos público para instanciarlo desde el menú
        private static VictoryScreen victory;
        private static DefeatScreen defeat;

        [STAThread]
        static void Main()
        {
            Engine.Initialize("Catch Game - Examen POO", SCREEN_WIDTH, SCREEN_HEIGHT, false);

            menu = new Menu();
            victory = new VictoryScreen();
            defeat = new DefeatScreen();

            while (Engine.IsWindowOpen)
            {
                Engine.UpdateWindow();
                CalcDeltaTime();

                // Limpiamos el fondo (Gris oscuro)
                Engine.Clear(Color.FromArgb(30, 30, 30));

                Input();
                Update();
                Render();

                Engine.Window.Invalidate();
            }
        }

        static void CalcDeltaTime()
        {
            TimeSpan span = DateTime.Now - lastFrameTime;
            deltaTime = (float)span.TotalSeconds;
            lastFrameTime = DateTime.Now;
        }

        static void Input()
        {
            switch (currentState)
            {
                case GameState.Menu: menu.Input(); break;
                case GameState.Playing: level?.Input(); break;
                case GameState.Victory: victory.Input(); break;
                case GameState.Defeat: defeat.Input(); break;
            }
        }

        static void Update()
        {
            switch (currentState)
            {
                case GameState.Menu: menu.Update(); break;
                case GameState.Playing: level?.Update(); break;
                case GameState.Victory: victory.Update(); break;
                case GameState.Defeat: defeat.Update(); break;
            }
        }

        static void Render()
        {
            switch (currentState)
            {
                case GameState.Menu: menu.Render(); break;
                case GameState.Playing: level?.Render(); break;
                case GameState.Victory: victory.Render(); break;
                case GameState.Defeat: defeat.Render(); break;
            }
        }
    }
}