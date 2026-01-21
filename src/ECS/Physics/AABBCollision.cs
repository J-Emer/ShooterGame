using System;
using Microsoft.Xna.Framework;
using ShooterGame.ECS.Components;
using ShooterGame.ECS.Physics;

namespace TestGame.ECS.Physics
{
    public static class AABBCollision
    {
        public static bool Intersects(BoxCollider a, BoxCollider b,out CollisionContact contact)
        {
            contact = default;

            Rectangle ra = a.Bounds;
            Rectangle rb = b.Bounds;

            float dx = (ra.Center.X - rb.Center.X);
            float px = (ra.Width / 2f + rb.Width / 2f) - Math.Abs(dx);
            if (px <= 0) return false;

            float dy = (ra.Center.Y - rb.Center.Y);
            float py = (ra.Height / 2f + rb.Height / 2f) - Math.Abs(dy);
            if (py <= 0) return false;

            // Collision confirmed — determine minimum penetration axis
            if (px < py)
            {
                contact.Normal = new Vector2(Math.Sign(dx), 0f);
                contact.Penetration = px;
            }
            else
            {
                contact.Normal = new Vector2(0f, Math.Sign(dy));
                contact.Penetration = py;
            }

            contact.A = a.Entity;
            contact.B = b.Entity;

            return true;
        }

        public static void Resolve(CollisionContact contact)
        {
            var colA = contact.A.GetComponent<BoxCollider>();
            var colB = contact.B.GetComponent<BoxCollider>();

            if (colA.IsStatic && colB.IsStatic)
                return;

            Transform transA = contact.A.GetComponent<Transform>();
            Transform transB = contact.B.GetComponent<Transform>();

            Vector2 correction = contact.Normal * contact.Penetration;

            if (colA.IsStatic)
            {
                transB.Position -= correction;
            }
            else if (colB.IsStatic)
            {
                transA.Position += correction;
            }
            else
            {
                // Split correction
                transA.Position += correction * 0.5f;
                transB.Position -= correction * 0.5f;
            }

            if(contact.A.HasComponent<CollisionHandler>())
            {
                contact.A.GetComponent<CollisionHandler>().OnCollision(contact.A, contact.B);
            }
            if(contact.B.HasComponent<CollisionHandler>())
            {
                contact.B.GetComponent<CollisionHandler>().OnCollision(contact.B, contact.A);
            }            
        }
    }
}
