using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Graphic
{
    public class GraphicSettings
    {
        private Game _game;
        private GraphicsDeviceManager _graphicsManager;

        private const int DEFAULT_WIDTH = 1200;
        private const int DEFAULT_HEIGHT = 700;

        private int _storedWindowWidth;
        private int _storedWindowHeight;

        #region Evenement
        public delegate void WindowSizeChangeDelegate(int width, int height);
        private event WindowSizeChangeDelegate WindowSizeChangeEvent;

        public void SubscribeEventWindowSizeChange(WindowSizeChangeDelegate method)
        {
            WindowSizeChangeEvent += method;
        }

        public void OnWindowSizeChange()
        {
            if (WindowSizeChangeEvent != null)
            {
                WindowSizeChangeEvent(this.WindowWidth, this.WindowHeight);
            }
        }

        #endregion

        public bool FullScreen
        {
            get { return _graphicsManager.IsFullScreen; }
            set
            {
                if (_graphicsManager.IsFullScreen != value)
                {
                    if (value)
                    {
                        _graphicsManager.PreferredBackBufferWidth = this.GraphicDevice.DisplayMode.Width;
                        _graphicsManager.PreferredBackBufferHeight = this.GraphicDevice.DisplayMode.Height;
                    }
                    else
                    {
                        _graphicsManager.PreferredBackBufferWidth = _storedWindowWidth;
                        _graphicsManager.PreferredBackBufferHeight = _storedWindowHeight;
                    }
                    _graphicsManager.IsFullScreen = value;
                    _graphicsManager.ApplyChanges();
                    OnWindowSizeChange();
                }
            }
        }

        // TODO : à virer
        public GraphicsDevice GraphicDevice
        {
            get { return _game.GraphicsDevice; }
        }

        public int WindowWidth
        {
            get { return _graphicsManager.PreferredBackBufferWidth; }
        }

        public int WindowHeight
        {
            get { return _graphicsManager.PreferredBackBufferHeight; }
        }
        
        public GraphicSettings(Game game, int windowWidth = GraphicSettings.DEFAULT_WIDTH, int windowHeight = GraphicSettings.DEFAULT_HEIGHT)
        {
            _game = game;
            _graphicsManager = new GraphicsDeviceManager(game);
            _storedWindowWidth = _graphicsManager.PreferredBackBufferWidth = windowWidth;
            _storedWindowHeight = _graphicsManager.PreferredBackBufferHeight = windowHeight;
            OnWindowSizeChange();
        }

        public void Initialize()
        {
            FullScreen = false;
            GraphicDevice.SamplerStates[0] = SamplerState.PointWrap;
        }
    }
}
