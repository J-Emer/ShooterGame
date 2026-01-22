using System;
using System.Buffers;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ShooterGame.Core;
using ShooterGame.ECS.Components;

namespace ShooterGame.Particles
{
    public class Emitter
    {
        public Vector2 SpawnPoint{get;set;} = Vector2.Zero;
        public int MaxParticleCount{get;set;} = 100;
        private List<Particle> _particles = new List<Particle>();
        private List<Effector> _effectors = new List<Effector>();

        private Random _rand;
        // public bool ContineusSpawn{get;set;} = false;

        private bool _isRunning = true;

        public Emitter(Vector2 spawnPoint, List<Effector> effectors)
        {
            SpawnPoint = spawnPoint;
            _rand = new Random(22);
            _effectors = effectors;
            Gen();
        }
        private void Gen()
        {
            if(_particles.Count >= MaxParticleCount)
            {
                return;
            }

            Particle _p = new Particle
            {
                Position = SpawnPoint,  
                Velocity = new Vector2(_rand.Next(-1, 2), _rand.Next(-5, -1)),
            };

            _particles.Add(_p);
        }
        public void Start()
        {
            _isRunning = true;
        }
        public void Stop()
        {
            _isRunning = false;
        }
        public void Update()
        {
            if(!_isRunning){return;}

            if(_particles.Count <= MaxParticleCount)
            {
                Gen();
            }

            foreach (var item in _particles)
            {
                if(!item.IsAlive){continue;}

                item.Timer += Time.DeltaTime;
                
                if(item.Timer >= item.LifeTime)
                {
                    item.IsAlive = false;
                    item.Timer = 0;
                }

                item.Position += item.Velocity;

                foreach (var effector in _effectors)
                {
                    effector.Effect(item);
                }

            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(!_isRunning){return;}

            foreach (var item in _particles)
            {
                if(!item.IsAlive){continue;}

                spriteBatch.Draw(
                                    item.Texture,
                                    item.Position,
                                    null,
                                    item.Color * item.Alpha,
                                    item.Rotation,
                                    Vector2.Zero,
                                    item.Size,
                                    SpriteEffects.None,
                                    0f
                                );
            }
        }

   


    }
}