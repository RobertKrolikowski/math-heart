using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace heart
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        double a;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            

            GraphicsDevice.Clear(Color.CornflowerBlue);
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            if(a > MathHelper.TwoPi)
            {
                a = 0;
                GraphicsDevice.Clear(Color.CornflowerBlue);
            }
            a += 0.01;
           
            base.Update(gameTime);

        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
           // GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            //DrawLine(this SpriteBatch spriteBatch, Vector2 point1, Vector2 point2,
            //Color color, float thickness = 1f);
            
            Texture2D texture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            texture.SetData<Color>(new Color[] { Color.Red });
            //for (double a = 0 ; a < MathHelper.TwoPi; a += 0.01)
           // {
            int w = graphics.PreferredBackBufferWidth/2;
            int h = graphics.PreferredBackBufferHeight/2;
            float r = 10;
            int stroke = 10;
            double x = w+(r * 16 * System.Math.Pow(System.Math.Sin(a), 3));
            double y = h+(-r * (13 * System.Math.Cos(a) - 5 * System.Math.Cos(2 * a) - 2 * System.Math.Cos(3 * a) - System.Math.Cos(4 * a)));

            spriteBatch.Begin();
            spriteBatch.Draw(texture, new Rectangle(new Point(System.Convert.ToInt32(x), System.Convert.ToInt32(y)), 
                new Point(stroke,stroke)), Color.White);
            spriteBatch.End();
           // }

            base.Draw(gameTime);
        }
    }
}
