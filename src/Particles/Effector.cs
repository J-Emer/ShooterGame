using System;
using Microsoft.Xna.Framework;
using ShooterGame.Particles;

namespace ShooterGame
{
    public abstract class Effector
    {
        public string Name{get; private set;}

        public Effector()
        {
            this.Name = this.GetType().Name;
        }

        protected float Noramlize(float _value, float _min, float _max)
        {
            //return (_value - 0) / (1 - 0);
            return (_value - _min) / (_max - _min);
        }    

        public abstract void Effect(Particle _p);
        public override string ToString()
        {
            return this.Name;
        }
    }

    public abstract class Effector<T> : Effector
    {
        public T StartValue{get;set;}
        public T EndValue{get;set;}
    }

    public class SizeEffector : Effector<Vector2>
    {
        public override void Effect(Particle _p)
        {
            float t = Noramlize(_p.Timer, 0, _p.LifeTime);
            _p.Size = Vector2.Lerp(StartValue, EndValue, t);
        }
    }

    public class ColorEffector : Effector<Color>
    {
        public override void Effect(Particle _p)
        {
            _p.Color = Color.Lerp(StartValue, EndValue, Noramlize(_p.Timer, 0, _p.LifeTime));
        }
    }

    public class RotationEffector : Effector<float>
    {
        public override void Effect(Particle _p)
        {
            _p.Rotation = MathHelper.ToRadians(float.Lerp(StartValue, EndValue, Noramlize(_p.Timer, 0, _p.LifeTime)));
        }
    }

    public class AlphaEffector : Effector<float>
    {
        public override void Effect(Particle _p)
        {
            _p.Alpha = MathHelper.ToRadians(float.Lerp(StartValue, EndValue, Noramlize(_p.Timer, 0, _p.LifeTime)));
        }
    }    
}