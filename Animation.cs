using SFML.Graphics;
using SFML.System;
using System.Threading;

namespace SFML.Animation
{
    class Animation
    {
        private Sprite _spriteSheet;
        private RenderWindow _window;
        private int _frameWidth;
        private int _frameHeight;
        private int _counter = 0;
        private Texture _rectTexture;
        private Sprite _rectSprite;
        

        public Sprite[] Frames;
        public Vector2f Position = new Vector2f(0, 0);
        public int CurrentFrame = 0;
        public int Speed = 100;
        
        public Animation(RenderWindow Window, Sprite SpriteSheet, int FrameWidth, int FrameHeight) 
        {
            _window = Window;
            _spriteSheet = SpriteSheet;
            _frameWidth = FrameWidth;
            _frameHeight = FrameHeight;
            _initCountFrames();
            _initFrames();

        }

        private void _initCountFrames() 
        {
            _counter = (int)_spriteSheet.Texture.Size.X/_frameWidth;
        }

        private void _initFrames() 
        {
            int currentFrame = 0;
            Frames = new Sprite[_counter];
            int left = _frameWidth;
            int top = 0;
            _rectTexture = new Texture(_spriteSheet.Texture);
            _rectSprite = new Sprite(_rectTexture, new IntRect(left, top, _frameWidth, _frameHeight));
            Frames[0] = _rectSprite;

            ++currentFrame;
            left = currentFrame;

            for (int i = 1; i < Frames.Length; i++) 
            {
                _rectTexture = new Texture(_spriteSheet.Texture);
                _rectSprite = new Sprite(_rectTexture, new IntRect(left, top, _frameWidth, _frameHeight));
                Frames[i] = _rectSprite;
                ++currentFrame;
                left = currentFrame * _frameWidth;
            }

        }

        public void Run()
        { 
            for (CurrentFrame = 0; CurrentFrame < Frames.Length; CurrentFrame++) 
            {
                Frames[CurrentFrame].Position = Position;
                _window.DispatchEvents();
                _window.Clear();
                _window.Draw(Frames[CurrentFrame]);
                _window.Display();
                Thread.Sleep(Speed);
            }
            return;
        }
        public void Run(int StartFrame, int EndFrame)
        {
            for (int CurrentFrame = StartFrame; CurrentFrame < EndFrame; CurrentFrame++)
            {
                Frames[CurrentFrame].Position = Position;
                _window.DispatchEvents();
                _window.Clear();
                _window.Draw(Frames[CurrentFrame]);
                _window.Display();
                Thread.Sleep(Speed);
            }
            return;
        }








    }
}
