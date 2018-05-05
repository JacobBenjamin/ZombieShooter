using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace JacobZombieShooter
{

    //sprite ☺
    //player ☺
    //wasd movement ☻
    //zombie☻
    //bullet☺

    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteFont font;
        SpriteBatch spriteBatch;
        bool speshal = false;
        bool freeze = false;
        bool respawining = false;
        Vector2 position;
        Texture2D flyguy;
        bool hack = false;
        TimeSpan slomoDelay;
        TimeSpan slomo;
        //  bool ammopalce = true;
        int ammo = 50;
        int kills = 0;
        Texture2D lab;
        bool healing = false;
        Texture2D bossBoi;
        string ded;
        Sprite yes;
        Sprite no;
        string HackTalk;
        bool reload = false;
        Texture2D HappiMeel;
        int prvsLabLife;
        List<AmmoCase> ammoCases = new List<AmmoCase>();
        List<HealthCrate> healthCrates = new List<HealthCrate>();
        Texture2D ammoImage;
        Texture2D yesImage;
        Texture2D noImage;
        Vector2 ammoPosition;
        Vector2 HeroPosition;
        TimeSpan pastGameTime;
        Vector2 BPostion;
        Vector2 PositionB;
        boss boss;
        Vector2 deathPlace;
        Rectangle buttonA;
        Vector2 buttonPlace;
        Vector2 healthPosition;
        Tank tank;
        bool poweredUp = false;
        Random randy;
        float spookSpeed = .3f;
        int level = 1;
        Vector2 Position;
        Texture2D Zomb;
        Player hero;
        List<Zombie> Zombies = new List<Zombie>();
        TimeSpan lastTank;
        List<Bullet> Bullets = new List<Bullet>();
        bool respawnable = false;
        List<Lab> Labs = new List<Lab>();
        Color color;
        Vector2 speed;
        float shootSpeed = 100f;
        Texture2D whatDoesATankLookLikeAgain;
        KeyboardState ks;
        MouseState ms;
        GamePadState gs;
        KeyboardState prvsks;
        Texture2D healthimage;
        Texture2D battleGround;
        bool battle = false;
        float lives = 5;
        Vector2 origin;
        Sprite background;
        bool shooting = false;
        //bool shootingSlower = false;
        float rotation;
        TimeSpan elapsedShootTime;
        TimeSpan timeToShoot;

        bool spookIncrease;
        Texture2D tankImage;
        bool battleFinished = false;
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
            IsMouseVisible = true;
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
            flyguy = Content.Load<Texture2D>("flyguy");
            Position = new Vector2(100, 300);
            PositionB = new Vector2(0, 300);
            ammoPosition = new Vector2(500, 500);
            healthPosition = new Vector2(300, 300);
            lab = Content.Load<Texture2D>("place");
            Zomb = Content.Load<Texture2D>("benson");
            yesImage = Content.Load<Texture2D>("no no");
            noImage = Content.Load<Texture2D>("no");
            slomo = TimeSpan.FromMilliseconds(60);
            ded = kills.ToString();
            HackTalk = "finish game?";
            bossBoi = Content.Load<Texture2D>("jerry");
            HappiMeel = Content.Load<Texture2D>("yumYum");
            HeroPosition = new Vector2(1, 5);
            whatDoesATankLookLikeAgain = Content.Load<Texture2D>("tank");
            Bullet.Texture = Content.Load<Texture2D>("nugget");
            Bullet.EvilTexture = Content.Load<Texture2D>("noodle");
            battleGround = Content.Load<Texture2D>("beez");
            ammoImage = Content.Load<Texture2D>("nuggetBox");
            buttonPlace = new Vector2(1000, 100);
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

            speed = new Vector2(spookSpeed, spookSpeed);
            tank = new Tank(whatDoesATankLookLikeAgain, new Vector2(50, 500), color);

            hero = new Player(flyguy, position, color, HeroPosition);
            yes = new Sprite(yesImage, new Vector2(200, 200), Color.Green, 2, 2);
            no = new Sprite(noImage, new Vector2(700, 300), Color.Green, 1, 1);
            Zombie zombie = new Zombie(Position, Zomb, color, speed, 2000);
            boss = new boss(new Vector2(-100, 100), bossBoi, color, speed, 1000);

            for (int i = 0; i < 3; i++)
            {

                Position.X += Zomb.Width + 5;
                Zombies.Add(new Zombie(Position, Zomb, color, speed, 2000));
            }
            Labs.Add(new Lab(lab, new Vector2(randy.Next(0, GraphicsDevice.Viewport.Width - lab.Width + 1), randy.Next(0, GraphicsDevice.Viewport.Height)), color));
            Labs.Add(new Lab(lab, new Vector2(randy.Next(0, GraphicsDevice.Viewport.Width - lab.Width + 1), randy.Next(0, GraphicsDevice.Viewport.Height)), color));
            Labs.Add(new Lab(lab, new Vector2(randy.Next(0, GraphicsDevice.Viewport.Width - lab.Width + 1), randy.Next(0, GraphicsDevice.Viewport.Height)), color));
            Labs.Add(new Lab(lab, new Vector2(randy.Next(0, GraphicsDevice.Viewport.Width - lab.Width + 1), randy.Next(0, GraphicsDevice.Viewport.Height)), color));

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
            if (!hack && !freeze)
            {
                hero.Update(ks, gs);
            }
            
                if (ks.IsKeyDown(Keys.Space) || gs.Triggers.Right > 0.95f /*&& prvsks.IsKeyUp(Keys.Space)*/)
            {
                shooting = true;
            }
            if (shooting == true && ammo > 0 && !freeze )
            {
                elapsedShootTime += gameTime.ElapsedGameTime;
                if (elapsedShootTime > timeToShoot)
                {
                    elapsedShootTime = TimeSpan.Zero;
                    Bullets.Add(new Bullet(hero.Position, color, hero.Rotation - MathHelper.PiOver2, hero.originalSpeedMagnitude, 2, 2, false, 1));
                    ammo--;
                }

            }
            for (int i = 0; i < Bullets.Count; i++)
            {
                
                Bullets[i].update();
            }
            if (ks.IsKeyUp(Keys.Space) || gs.Triggers.Right < 0.95f)
            {
                shooting = false;
            }


            slomoDelay += gameTime.ElapsedGameTime;

            if (slomoDelay > slomo)
            {
                if (speshal == true)
                {
                    slomoDelay = TimeSpan.Zero;
                }
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                    Exit();
                ks = Keyboard.GetState();
                gs = GamePad.GetState(0);
                ms = Mouse.GetState();
                timeToShoot = TimeSpan.FromMilliseconds(shootSpeed);

                if (hero.gameOver == false && battle == true && battleFinished == false && !freeze)
                {
                    boss.update(hero, gameTime);
                    for (int i = 0; i < boss.BadBullets.Count; i++)
                    {
                        boss.BadBullets[i].update();
                    }
                }
                if (ms.LeftButton == ButtonState.Pressed && ms.X == buttonPlace.X && ms.Y == buttonPlace.Y)
                {
                    flyguy = Content.Load<Texture2D>("flyguy");
                    Zomb = Content.Load<Texture2D>("benson");
                }
                //dddd
                //boss.update(hero, gameTime);
                if (gameTime.TotalGameTime - pastGameTime > TimeSpan.FromSeconds(1) && hero.gameOver == false)
                {
                    for (int i = 0; i < Labs.Count; i++)
                    {
                        Zombies.Add(new Zombie(Labs[i].Position, Zomb, color, speed, 2000));
                    }


                    //Zombies.Add(new Zombie(new Vector2(0, 300), Zomb, color, speed));
                    //Zombies.Add(new Zombie(new Vector2(GraphicsDevice.Viewport.Width - Zomb.Width, 300), Zomb, color, speed));
                    //Zombies.Add(new Zombie(new Vector2(700, GraphicsDevice.Viewport.Height - Zomb.Height), Zomb, color, speed));
                    //Zombies.Add(new Zombie(new Vector2(700, 0), Zomb, color, speed));
                    pastGameTime = gameTime.TotalGameTime;
                }


                //wwwwww



                if (Labs.Count <= 0 && !battleFinished)
                {
                    //  ded = "noice jbo boi, perss neter ro X to restrat";
                    battle = true;

                }

                if (battle)
                {
                    if (hero.hitbox.Intersects(boss.hitbox))
                    {
                        lives -= 3;
                    }
                    for (int a = 0; a < Bullets.Count; a++)
                    {
                        if (Bullets[a].hitbox.Intersects(boss.hitbox))
                        {
                            boss.bossLives--;
                            Bullets.RemoveAt(a);

                        }

                    }
                }



                if (boss.bossLives == 0)
                {
                    battleFinished = true;
                }

                if (battleFinished)
                {

                    Zombies.Clear();
                    healthCrates.Clear();
                    ammoCases.Clear();
                    battle = false;
                    hack = true;
                    respawnable = true;

                }
                if (respawnable)
                {

                    respawining = true;


                }
                if (respawining)
                {

                    boss.respawn();
                    respawining = false;
                    respawnable = false;
                }
                for (int z = 0; z < boss.BadBullets.Count; z++)
                {
                    if (boss.BadBullets[z].hitbox.Intersects(hero.hitbox))
                    {
                        boss.BadBullets.RemoveAt(z);
                        lives--;
                        hero.Color.R -= 50;
                        hero.Color.B -= 50;
                        continue;

                    }
                }
                if (lives <= 0)
                {
                    ded = "yuo deid ;( perss entre ro X to restrat";
                    freeze = true;
                    if (ks.IsKeyDown(Keys.Enter))
                    {
                        hero.gameOver = true;
                    }
                }

                if (hero.gameOver)
                {
                    freeze = true;
                    Restart(ks);
                    //hero.gameOver = false;




                }

                if (ms.Position.X > yes.hitbox.X && ms.Position.X < (yes.hitbox.X + yes.hitbox.Width) && ms.Position.Y > yes.hitbox.Y && ms.Position.Y < (yes.hitbox.Y + yes.hitbox.Height) && ms.LeftButton == ButtonState.Pressed && hack)
                {

                    hero.gameOver = true;

                }
                if (ms.Position.X > no.hitbox.X && ms.Position.X < (no.hitbox.X + no.hitbox.Width) && ms.Position.Y > no.hitbox.Y && ms.Position.Y < (no.hitbox.Y + no.hitbox.Height) && ms.LeftButton == ButtonState.Pressed && hack)
                {

                    Exit();

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
                        break;
                    }

                    for (int a = 0; a < Bullets.Count; a++)

                    {

                        if (Bullets[a].hitbox.Intersects(Zombies[i].hitbox))
                        {

                            breaking = true;
                            deathPlace.X = Zombies[i].Position.X;
                            deathPlace.Y = Zombies[i].Position.Y;
                            Zombies.RemoveAt(i);
                            if (poweredUp == true/*&& gameTime.TotalGameTime - pastGameTime > TimeSpan.FromSeconds(10) && hero.gameOver == false*/)
                            {

                                ammo -= 1;

                                // poweredUp = false;


                            }
                            else if (poweredUp == false)
                            {
                                Bullets.RemoveAt(a);
                            }
                            kills++;

                            ded = kills.ToString();
                            int drop = randy.Next(1, 11);

                            if (drop == 5)
                            {
                                healthCrates.Add(new HealthCrate(healthimage, deathPlace, color));
                            }
                            else if (drop >= 1)
                            {
                                ammoCases.Add(new AmmoCase(ammoImage, deathPlace, color));
                            }

                            else
                            {

                            }
                            spookIncrease = false;

                            break;

                        }

                        if (Bullets.Count > 0)
                        {
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
                    }
                    if (breaking)
                    {
                        break;
                    }

                    if (hero.gameOver == false && !freeze)
                    {
                        Zombies[i].update(hero, gameTime);


                        if (Zombies[i].BadBullets.Count > 0)
                        {
                            for (int z = 0; z < Zombies[i].BadBullets.Count; z++)
                            {
                                Zombies[i].BadBullets[z].update();
                                if (Zombies[i].BadBullets[z].hitbox.Intersects(hero.hitbox))
                                {
                                    Zombies[i].BadBullets.RemoveAt(z);
                                    lives -= .5f;
                                    hero.Color.R -= 25;
                                    hero.Color.B -= 25;
                                    continue;
                                }
                                
                                  

                                if (i == Zombies.Count)
                                {
                                    break;
                                }
                            }

                        }
                    }



                }
                if (hack)
                {
                    for (int z = 0; z < Bullets.Count; z++)
                    {
                        Bullets.RemoveAt(z);
                    }
                    boss.BadBullets.Clear();
                    ammo = 0;


                }

                if (hero.Position.X < 0)
                {
                    hero.Position.X = GraphicsDevice.Viewport.Width;

                }
                else if (hero.Position.X > GraphicsDevice.Viewport.Width)
                {
                    hero.Position.X = 0;

                }
                else if (hero.Position.Y < 0)
                {
                    hero.Position.Y = GraphicsDevice.Viewport.Height;

                }
                else if (hero.Position.Y > GraphicsDevice.Viewport.Height)
                {
                    hero.Position.Y = 0;

                }
                for (int x = 0; x < ammoCases.Count; x++)
                {
                    if (hero.hitbox.Intersects(ammoCases[x].hitbox))
                    {
                        reload = true;

                        ammoCases.RemoveAt(x);
                    }
                }

                if (reload == true)
                {
                    ammo += 50;
                    speshal = true;
                    reload = false;
                }
                for (int x = 0; x < healthCrates.Count; x++)
                {
                    if (healthCrates[x].hitbox.Intersects(hero.hitbox))
                    {
                        healing = true;
                        healthCrates.RemoveAt(x);
                    }
                }
                if (healing == true && lives < 5)
                {
                    lives += 1;
                    hero.Color.R += 50;
                    hero.Color.B += 50;

                    healing = false;

                }
                else if (healing == true && lives == 4.75f)
                {
                    lives += .25f;
                    hero.Color.R += 25;
                    hero.Color.B += 25;

                    healing = false;
                }
                if (hero.hitbox.Intersects(tank.hitbox))
                {
                    poweredUp = true;
                    tank.Position = new Vector2(randy.Next(100, 1900), randy.Next(100, 900));
                }

                if (lastTank > TimeSpan.FromSeconds(5) && hero.gameOver == false)
                {
                    lastTank = TimeSpan.Zero;


                    poweredUp = false;

                }

                if (poweredUp == true)
                {
                    hero.Image = whatDoesATankLookLikeAgain;
                    for (int u = 0; u < Bullets.Count; u++)
                    {
                        Bullets[u].Image = HappiMeel;
                    }
                    lastTank += gameTime.ElapsedGameTime;
                }
                else
                {
                    hero.Image = flyguy;
                    for (int u = 0; u < Bullets.Count; u++)
                    {
                        Bullets[u].Image = Bullet.Texture;
                    }
                }

                if (hero.Color.B >= 250)
                {
                    hero.Color.B = 250;
                    hero.Color.R = 250;
                    hero.Color.G = 250;
                }
                if (kills != 0 && kills % 25 == 0 && !spookIncrease)
                {
                    spookIncrease = true;

                    spookSpeed += .08f;

                    level++;
                }


                if (ammo == 500)
                {
                    shootSpeed = 100;
                }
                //  List<Bullet> itemsToDelete;
                if (hero.gameOver == false)
                {

                    for (int z = 0; z < Bullets.Count; z++)
                    {
                       

                        if (Bullets[z].Position.Y < 0 || Bullets[z].Position.Y > GraphicsDevice.Viewport.Height || Bullets[z].Position.X < 0 || Bullets[z].Position.X > GraphicsDevice.Viewport.Width)
                        {
                            Bullets.RemoveAt(z);
                            break;
                        }
                        //if (Bullets[i].Position.X < 0)
                        //{
                        //    Bullets[i].Position.X = GraphicsDevice.Viewport.Width;

                        //}
                        //else if (Bullets[i].Position.X > GraphicsDevice.Viewport.Width)
                        //{
                        //    Bullets[i].Position.X = 0;

                        //}
                        //else if (Bullets[i].Position.Y < 0)
                        //{
                        //    Bullets[i].Position.Y = GraphicsDevice.Viewport.Height;

                        //}
                        //else if (Bullets[i].Position.Y > GraphicsDevice.Viewport.Height)
                        //{
                        //    Bullets[i].Position.Y = 0;

                        //}
                    }

                    //
                }
                prvsks = ks;
                // TODO: Add your update logic here
                //pastGameTime = gameTime;
                base.Update(gameTime);
            }



        }




        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {

            spriteBatch.Begin();

            if (hack)
            {

                GraphicsDevice.Clear(Color.Black);
                spriteBatch.DrawString(font, HackTalk, Vector2.Zero, Color.Green);

                yes.Draw(spriteBatch);
                no.Draw(spriteBatch);
                //yes.DrawHitBox(spriteBatch , GraphicsDevice);
                //no.DrawHitBox(spriteBatch, GraphicsDevice);
            }
            else if (!hack)
            {
                background.Draw(spriteBatch);

                tank.Draw(spriteBatch);
                spriteBatch.DrawString(font, ded, Vector2.Zero, Color.White);
                spriteBatch.DrawString(font, ammo.ToString(), new Vector2(1900, 0), color);
            }
            //hero.DrawHitBox(spriteBatch);

            //spriteBatch.DrawString(font, "yeet", buttonPlace, Color.Black);
            for (int a = 0; a < healthCrates.Count; a++)
            {
                healthCrates[a].Draw(spriteBatch);
            }
            for (int i = 0; i < boss.BadBullets.Count; i++)
            {
                boss.BadBullets[i].Draw(spriteBatch);
                //  boss.BadBullets[i].DrawHitBox(spriteBatch, GraphicsDevice);
            }
            //   healthCrate.DrawHitBox(spriteBatch);
            hero.Draw(spriteBatch);
            // tank.DrawHitBox(spriteBatch);
            if (battle && !battleFinished)
            {
                boss.Draw(spriteBatch);
                //boss.respawn();
            }
            for (int a = 0; a < ammoCases.Count; a++)
            {
                ammoCases[a].Draw(spriteBatch);
            }
            //   ammoCase.DrawHitBox(spriteBatch);
            for (int i = 0; i < Labs.Count; i++)
            {
                Labs[i].Draw(spriteBatch);
                //  Labs[i].DrawHitBox(spriteBatch);
            }
            for (int i = 0; i < Bullets.Count; i++)
            {
                Bullets[i].Draw(spriteBatch);
                Bullets[i].DrawHitBox(spriteBatch, GraphicsDevice);
            }
            for (int a = 0; a < Zombies.Count; a++)
            {
                for (int i = 0; i < Zombies[a].BadBullets.Count; i++)
                {
                    Zombies[a].BadBullets[i].Draw(spriteBatch);
                    //Zombies[a].BadBullets[i].DrawHitBox(spriteBatch, GraphicsDevice);
                }

            }
            for (int i = 0; i < Zombies.Count; i++)
            {
                Zombies[i].Draw(spriteBatch);
                // Zombies[i].DrawHitBox(spriteBatch);
            }

            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        void Restart(KeyboardState ks)
        {

            hack = false;
            kills = 0;
            lives = 5;
            boss.Position = new Vector2(-100, 100);
            ammo = 50;
            boss.bossLives = 20;
            Zombies.Clear();
            healthCrates.Clear();
            Bullets.Clear();
            for (int i = 0; i < Zombies.Count; i++)
            {
                Zombies[i].BadBullets.Clear();
            }

            for (int i = 0; i < Labs.Count; i++)
            {
                Labs[i].lives = 20;
            }

            boss.BadBullets.Clear();
            speshal = false;
            hero.Color.R = 255;
            hero.Color.B = 255;
            ded = kills.ToString();
            spookSpeed = .3f;
            shootSpeed = 100f;
            hero.gameOver = false;
            poweredUp = false;
            HeroPosition.X = 1;
            HeroPosition.Y = 5;
            freeze = false;

            Labs.Clear();
            Labs.Add(new Lab(lab, new Vector2(randy.Next(0, GraphicsDevice.Viewport.Width - lab.Width + 1), randy.Next(0, GraphicsDevice.Viewport.Height)), color));
            Labs.Add(new Lab(lab, new Vector2(randy.Next(0, GraphicsDevice.Viewport.Width - lab.Width + 1), randy.Next(0, GraphicsDevice.Viewport.Height)), color));
            Labs.Add(new Lab(lab, new Vector2(randy.Next(0, GraphicsDevice.Viewport.Width - lab.Width + 1), randy.Next(0, GraphicsDevice.Viewport.Height)), color));
            Labs.Add(new Lab(lab, new Vector2(randy.Next(0, GraphicsDevice.Viewport.Width - lab.Width + 1), randy.Next(0, GraphicsDevice.Viewport.Height)), color));

            battle = false;
            battleFinished = false;

        }
    }
}
