using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ShooterGame.Core;
using ShooterGame.ECS;
using ShooterGame.ECS.Systems;
using ShooterGame.Particles;
using ShooterGame.Scenes;
using ShooterGame.UI;

namespace ShooterGame;

public class Game1 : Game
{
    public static bool IsPaused = false;
    public static bool ShowDebug = true;



    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Color BackgroundColor = new Color(47, 59, 64);




    private SpriteSystem _spriteSystem;
    private PlayerController _playerControllerSystem;
    private PhysicsSystem _physicsSystem;
    private ColliderDebugSystem _colliderDebugSystem;
    private EntityInfoSystem _entityInfoSystem;
    private VelocitySystem _velocitySytem;
    private BulletSystem _bulletSystem;
    private HealthSystem _healthSystem;
    private EnemySystem _enemySystem;



    private Texture2D _pointLight;



    private Emitter _emitter;



    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

        AssetLoader.Init(Content, _graphics.GraphicsDevice, "font");

        _pointLight = AssetLoader.GetTexture("PointLight");

        new Camera(_graphics.GraphicsDevice.Viewport);
        Camera.Instance.Position = new Vector2(600, 300);

        new EntityWorld();
        new UISystem();
        _spriteSystem = new SpriteSystem();
        _playerControllerSystem = new PlayerController();
        _physicsSystem = new PhysicsSystem();
        _colliderDebugSystem = new ColliderDebugSystem();
        _entityInfoSystem = new EntityInfoSystem();
        _velocitySytem = new VelocitySystem();
        _bulletSystem = new BulletSystem();
        _healthSystem = new HealthSystem();
        _enemySystem = new EnemySystem();

        new SceneManager();
        SceneManager.Instance.RegisterScene(new Demo("Demo"));
        SceneManager.Instance.RegisterScene(new Other("Other"));
        SceneManager.Instance.LoadScene("Demo");


        _emitter = new Emitter(new Vector2(500, 300), new List<Effector>
        {
            new SizeEffector
            {
                StartValue = Vector2.Zero,
                EndValue = new Vector2(10, 10)
            },
            new ColorEffector
            {
                StartValue = Color.Yellow,
                EndValue = Color.Red
            }
        });
    }

    protected override void Update(GameTime gameTime)
    {
        if(Input.GetKeyDown(Keys.Escape))
        {
            Exit();
        }

        if(Input.GetKeyDown(Keys.LeftShift))
        {
            ShowDebug = !ShowDebug;
        }

        Time.Update(gameTime);
        Input.Update();

        if(IsPaused)
        {
            return;
        }

        UISystem.Instance.Update();
        // _physicsSystem.Update();
        // _playerControllerSystem.Update();
        // _velocitySytem.Update();
        // _bulletSystem.Update();
        // _healthSystem.Update();
        // _enemySystem.Update();
        _emitter.Update();
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(BackgroundColor);

        if(IsPaused)
        {
            Console.WriteLine("---GamePaused");
            return;
        }

        // UI
        _spriteBatch.Begin();
        UISystem.Instance.Draw(_spriteBatch);
        _spriteBatch.End();

        // Game logic
        _spriteBatch.Begin(SpriteSortMode.BackToFront, null, null, null, null, null, Camera.Instance.GetViewMatrix());

        _spriteSystem.Draw(_spriteBatch);
        _colliderDebugSystem.Draw(_spriteBatch);
        _entityInfoSystem.Draw(_spriteBatch);
        
        _spriteBatch.End();


        _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive, null, null, null, null, Camera.Instance.GetViewMatrix());
        _emitter.Draw(_spriteBatch);
        _spriteBatch.End();

        // Dark overlay
        // _spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
        // _spriteBatch.Draw(AssetLoader.GetPixel(), new Rectangle(0, 0, GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height), Color.Black * 0.5f);
        // _spriteBatch.End();

        // Light
        // _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.Additive);
        // _spriteBatch.Draw(_pointLight, Vector2.Zero, null, new Color(177, 189, 201) * 0.9f, 0f, Vector2.Zero, new Vector2(3f, 3f), SpriteEffects.None, 0);            
        // _spriteBatch.End();

        base.Draw(gameTime);
    }
}
