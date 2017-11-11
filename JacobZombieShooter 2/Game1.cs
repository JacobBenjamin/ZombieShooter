using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;

namespace JacobZombieShooter
{

    //sprite ☺
    //player ☺
    //wasd movement ☻
    //zombie☻
    //bullet

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteFont font;
        SpriteBatch spriteBatch;
        Vector2 position;
        Texture2D flyguy;
        //  bool ammopalce = true;
        int ammo = 50;
        int kills = 0;
        Texture2D lab;
        bool healing = false;
        Texture2D BImage;
        string ded;
        bool reload = false;
        AmmoCase ammoCase;
        HealthCrate healthCrate;
        Texture2D ammoImage;
        Vector2 ammoPosition;
        TimeSpan pastGameTime;
        Vector2 BPostion;
        Vector2 PositionB;
        Vector2 healthPosition;

        Random randy;
        float spookSpeed = .3f;
        int level = 1;
        Vector2 Position;
        Texture2D Zomb;
        Player hero;
        List<Zombie> Zombies = new List<Zombie>();
        List<Bullet> Bullets = new List<Bullet>();
        List<Lab> Labs = new List<Lab>();
        Color color;
        Vector2 speed;
        float shootSpeed = 150f;
        KeyboardState ks;
        KeyboardState prvsks;
        Texture2D healthimage;
        Texture2D battleGround;
        int lives = 5;
        Vector2 origin;
        Sprite background;
        bool shooting = false;
        //bool shootingSlower = false;
        float rotation;
        TimeSpan elapsedShootTime;
        TimeSpan timeToShoot;
        bool spookIncrease;

        public Game1()
        //
        {
            graphics = new GraphicsDeviceManager(this);

            graphics.PreferredBackBufferWidth = 2000;
            graphics.PreferredBackBufferHeight = 1000;
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

            base.Initialize();
        }
        //
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            position = new Vector2(100, 100);
            flyguy = Content.Load<Texture2D>("FlyGuy");
            Position = new Vector2(0, 300);
            PositionB = new Vector2(0, 300);
            ammoPosition = new Vector2(500, 500);
            healthPosition = new Vector2(300, 300);
            lab = Content.Load<Texture2D>("place");
            Zomb = Content.Load<Texture2D>("Benson");
            ded = kills.ToString();
            BImage = Content.Load<Texture2D>("nugget");
            battleGround = Content.Load<Texture2D>("beez");
            ammoImage = Content.Load<Texture2D>("nuggetBox");
            healthimage = Content.Load<Texture2D>("amazing3D");
            Song jazzLoop = Content.Load<Song>("jazzloop");
            BPostion = position;
            color = Color.White;
            spookIncrease = false;
            randy = new Random();
            timeToShoot = TimeSpan.FromMilliseconds(shootSpeed);
            font = Content.Load<SpriteFont>("font");


            background = new Sprite(battleGround, new Vector2(0, 0), color, 7f, 6f);
            //background.sc
            healthCrate = new HealthCrate(healthimage, healthPosition, color);
            speed = new Vector2(spookSpeed, spookSpeed);

            hero = new Player(flyguy, position, color, new Vector2(1, -5));
            ammoCase = new AmmoCase(ammoImage, new Vector2(randy.Next(100, 1900), randy.Next(100, 900)), color);
            Zombie zombie = new Zombie(Position, Zomb, color, speed);

            for (int i = 0; i < 3; i++)
            {

                Position.X += Zomb.Width + 5;
                Zombies.Add(new Zombie(Position, Zomb, color, speed));
            }
            Labs.Add(new Lab(lab, new Vector2(GraphicsDevice.Viewport.Width - lab.Width, 300), color));
            Labs.Add(new Lab(lab, new Vector2(700, GraphicsDevice.Viewport.Height - lab.Height), color));
            Labs.Add(new Lab(lab, new Vector2(700, 0), color));
            Labs.Add(new Lab(lab, PositionB, color));

            MediaPlayer.Play(jazzLoop);
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
            ks = Keyboard.GetState();
            timeToShoot = TimeSpan.FromMilliseconds(shootSpeed);
            hero.Update(ks);
            //dddd
            if (gameTime.TotalGameTime - pastGameTime > TimeSpan.FromSeconds(1) && hero.gameOver == false)
            {
                for (int i = 0; i < Labs.Count; i++)
                {
                    Zombies.Add(new Zombie(Labs[i].Position, Zomb, color, speed));
                }


                //Zombies.Add(new Zombie(new Vector2(0, 300), Zomb, color, speed));
                //Zombies.Add(new Zombie(new Vector2(GraphicsDevice.Viewport.Width - Zomb.Width, 300), Zomb, color, speed));
                //Zombies.Add(new Zombie(new Vector2(700, GraphicsDevice.Viewport.Height - Zomb.Height), Zomb, color, speed));
                //Zombies.Add(new Zombie(new Vector2(700, 0), Zomb, color, speed));
                pastGameTime = gameTime.TotalGameTime;
            }
            if (ks.IsKeyDown(Keys.Space) /*&& prvsks.IsKeyUp(Keys.Space)*/)
            {
                shooting = true;
            }
            else if (ks.IsKeyUp(Keys.Space))
            {
                shooting = false;
            }

            //wwwwww
            if (shooting == true && ammo > 0)
            {
                elapsedShootTime += gameTime.ElapsedGameTime;
                if (elapsedShootTime > timeToShoot)
                {
                    elapsedShootTime = TimeSpan.Zero;
                    Bullets.Add(new Bullet(BImage, hero.Position, color, hero.rotation - MathHelper.PiOver2, hero.originalSpeedMagnitude, 2));
                    ammo--;
                }


            }

            for (int i = 0; i < Zombies.Count; i++)
            {
                Zombies[i].Speed = speed = new Vector2(spookSpeed, spookSpeed);
                bool breaking = false;

                if (hero.hitbox.Intersects(Zombies[i].hitbox))
                {
                    Zombies.RemoveAt(i);
                    lives--;
                    hero.Color.R -= 50;
                    hero.Color.B -= 50;
                    if (lives <= 0)
                    {
                        ded = "yuo deid ;( perss entre to restrat";
                        hero.gameOver = true;
                    }
                    break;
                }

                for (int a = 0; a < Bullets.Count; a++)

                {
                    if (Bullets[a].hitbox.Intersects(Zombies[i].hitbox))
                    {
                        breaking = true;
                        Zombies.RemoveAt(i);
                        Bullets.RemoveAt(a);
                        kills++;
                        ded = kills.ToString();
                        spookIncrease = false;
                      
                        break;

                    }
                    for (int y = 0; y < Labs.Count; y++)
                    {
                        if (Bullets[a].hitbox.Intersects(Labs[y].hitbox))
                        {
                            Labs[y].lives--;
                            Bullets.RemoveAt(a);
                            break;
                        }
                        if (Labs[y].lives == 0)
                        {
                            Labs.RemoveAt(y);

                        }

                    }
                }

                if (breaking)
                {
                    break;
                }
                if (hero.gameOver == false)
                {
                    Zombies[i].update(hero);
                }
                else if (hero.gameOver)
                {
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        kills = 0;
                        lives = 5;
                        ammo = 50;
                        Zombies.Clear();
                        Bullets.Clear();
                        hero.Color.R = 255;
                        hero.Color.B = 255;
                        ded = kills.ToString();
                        spookSpeed = .3f;
                        shootSpeed = 150f;
                        hero.gameOver = false;
                        Labs.Clear();
                        Labs.Add(new Lab(lab, new Vector2(GraphicsDevice.Viewport.Width - lab.Width, 300), color));
                        Labs.Add(new Lab(lab, new Vector2(700, GraphicsDevice.Viewport.Height - lab.Height), color));
                        Labs.Add(new Lab(lab, new Vector2(700, 0), color));
                        Labs.Add(new Lab(lab, PositionB, color));
                    }
                }
                if(Labs.Count <= 0)
                {
                    ded = "noice jbo boi, perss neter to restrat";
                    hero.gameOver = true;
                }

                if (hero.hitbox.Intersects(ammoCase.hitbox))
                {
                    reload = true;
                    ammoCase.Position = new Vector2(randy.Next(100, 1900), randy.Next(100, 900));
                }
                if (reload == true)
                {
                    ammo += 50;
                    reload = false;
                }
                if (healthCrate.hitbox.Intersects(hero.hitbox))
                {
                    healing = true;
                    healthCrate.Position = new Vector2(randy.Next(100, 1900), randy.Next(100, 900));
                }
                if (healing == true)
                {
                    lives += 1;
                    hero.Color.R += 50;
                    hero.Color.B += 50;
                    healing = false;

                }
                if (hero.Color.B >= 250)
                {
                    hero.Color.B = 250;
                    hero.Color.R = 250;
                    hero.Color.G = 250;
                }
                if (kills != 0 && kills % 50 == 0 && !spookIncrease)
                {
                    spookIncrease = true;

                    spookSpeed += .1f;

                    level++;
                }
            }
            if (ammo == 500)
            {
                shootSpeed = 75;
            }
            //  List<Bullet> itemsToDelete;
            if (hero.gameOver == false)
            {
                for (int i = 0; i < Bullets.Count; i++)
                {
                    Bullets[i].update(ks);
                    if (Bullets[i].Position.Y < 0 || Bullets[i].Position.Y > GraphicsDevice.Viewport.Height || Bullets[i].Position.X < 0 || Bullets[i].Position.X > GraphicsDevice.Viewport.Width)
                    {
                        Bullets.RemoveAt(i);
                    }
                }
            }
            //

            prvsks = ks;
            // TODO: Add your update logic here
            //pastGameTime = gameTime;
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(Color.Gold);
            spriteBatch.Begin();
            background.Draw(spriteBatch);
            hero.Draw(spriteBatch);
            spriteBatch.DrawString(font, ded, Vector2.Zero, Color.White);
            spriteBatch.DrawString(font, ammo.ToString(), new Vector2(1900, 0), color);
            healthCrate.Draw(spriteBatch);


            ammoCase.Draw(spriteBatch);
            for (int i = 0; i < Labs.Count; i++)
            {
                Labs[i].Draw(spriteBatch);
            }
            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Draw(spriteBatch);
            }


            for (int i = 0; i < Zombies.Count; i++)
            {
                Zombies[i].Draw(spriteBatch);
            }
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
