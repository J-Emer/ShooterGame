using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShooterGame.Core
{
    public class Stats
    {
        public static Stats Instance{get; private set;}
        private Dictionary<string, Func<string>> _stats = new Dictionary<string, Func<string>>();
        private Vector2 Position{get;set;} = new Vector2(10, 10);
        public float YOffset{get;set;} = 20f;
        public Color FontColor{get;set;} = Color.White;


        public Stats()
        {
            Instance = this;
        }
        public void Add(string title, Func<string> value)
        {
            _stats.Add(title, value);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(!Game1.ShowDebug){return;}

            float yPos = Position.Y;

            foreach (var item in _stats)
            {
                Vector2 _pos = new Vector2(Position.X, yPos);

                spriteBatch.DrawString(AssetLoader.DefaultFont, $"{item.Key}: {item.Value.Invoke()}", _pos, FontColor);    
            
                yPos += YOffset;
            }
        }

    }
}