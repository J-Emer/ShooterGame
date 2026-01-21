using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.ECS.Components;

namespace ShooterGame.ECS.Systems
{
    public class SpriteSystem : DrawSystem
    {
        public override void Draw(SpriteBatch _spritebatch)
        {
            foreach (var _ent in EntityWorld.Instance.GetEntitiesWithComponent<Transform, Sprite>())
            {
                Transform _tran = _ent.GetComponent<Transform>();
                Sprite _sprite = _ent.GetComponent<Sprite>(); 

                _spritebatch.Draw
                                (
                                    _sprite.Texture,
                                    _tran.Position,
                                    _sprite.SourceRect,
                                    _sprite.DrawColor,
                                    _tran.Rotation,
                                    Vector2.Zero,
                                    _tran.Scale,
                                    _sprite.Effects,
                                    _sprite.DrawLayer * 0.1f
                                );
            }
        }
    }
}