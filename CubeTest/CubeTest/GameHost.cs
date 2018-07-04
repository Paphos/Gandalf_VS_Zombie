using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameFramework.Logic;
using GameFramework.Graphic;
using GameFramework.Input;
using GameFramework.Input.Device;
using GameFramework.Debug;
using GameFramework.Graphic.Renderers;


namespace CubeTest
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameHost : Game
    {
        public static bool debugDisplay = true;

        GraphicSettings _graphicSettings;

        private LogicManager _logic;
        private GraphicManager _graphic;
        private InputManager _input;

        public GameHost()
        {
            //_graphicsDeviceManager = new GraphicsDeviceManager(this);
            _graphicSettings = new GraphicSettings(this); //, 1000, 300);
            Content.RootDirectory = "Content";
            this.Window.Title = "Gandalf VS Zombie";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            _graphicSettings.Initialize();

            CustomContentLoader loader = new CustomContentLoader(this.Content);
            CustomWorld world = new CustomWorld(new CustomPhysicGenerator(loader));
            Tracker tracker = new Tracker(world.Player, 15f);
            Renderer renderer = new BasicRenderer(_graphicSettings, Content, 45f, tracker);

            _logic = new LogicManager(world);
            _graphic = new GraphicManager(_logic, tracker, renderer, new CustomGraphicGenerator(loader));

            CustomActionList actionList = new CustomActionList(this, _graphicSettings, world, tracker);
            KeyboardHandler kh = new KeyboardHandler(new CustomKeyboardBindingMap(actionList));
            MouseHandler mh = new MouseHandler(new CustomMouseBindingMap(actionList), true);

            _input = new InputManager(kh, mh);

            _logic.Start();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            //spriteBatch = new SpriteBatch(GraphicsDevice);

            DebugDisplay.Initialize(_graphic.Renderer);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            /*
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();
             */ 

            _input.Update();
            _logic.Update();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            float frameRate = 1 / (float)gameTime.ElapsedGameTime.TotalSeconds;
            DebugDisplay.Write("fps", frameRate.ToString());
            
            DebugDisplay.Commit();
            _graphic.Draw();

            base.Draw(gameTime);
        }
    }
}
