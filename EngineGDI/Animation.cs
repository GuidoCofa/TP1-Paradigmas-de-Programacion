using System;

namespace EngineGDI
{
    public class Animation
    {
        private string[] frames;
        private int currentFrame;
        private float frameTimer;
        private float frameInterval;
        private bool loop;

        public string CurrentSprite => frames[currentFrame];
        public bool IsFinished { get; private set; }

        public Animation(string[] framePaths, float fps = 12f, bool loop = true)
        {
            frames = framePaths;
            frameInterval = 1f / fps;
            this.loop = loop;
            currentFrame = 0;
            frameTimer = 0f;
            IsFinished = false;
        }

        public void Update(float deltaTime)
        {
            if (IsFinished) return;

            frameTimer += deltaTime;

            if (frameTimer >= frameInterval)
            {
                frameTimer -= frameInterval;
                currentFrame++;

                if (currentFrame >= frames.Length)
                {
                    if (loop)
                        currentFrame = 0;
                    else
                    {
                        currentFrame = frames.Length - 1;
                        IsFinished = true;
                    }
                }
            }
        }

        public void Reset()
        {
            currentFrame = 0;
            frameTimer = 0f;
            IsFinished = false;
        }
    }
}