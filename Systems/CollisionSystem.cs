using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace GameFrameWork
{
    public class CollisionSystem
    {
        public void Check(List<GameObject> objects)
        {
            var collidables = objects.OfType<ICollidable>().ToList();

            for (int i = 0; i < collidables.Count; i++)
            {
                for (int j = i + 1; j < collidables.Count; j++)
                {
                    if (collidables[i].Bounds.IntersectsWith(collidables[j].Bounds))
                    {
                        // Resolve simple overlap and apply rigid-body behavior
                        var a = (GameObject)collidables[i];
                        var b = (GameObject)collidables[j];

                        var overlap = RectangleF.Intersect(a.Bounds, b.Bounds);
                        if (overlap.Width > 0 && overlap.Height > 0)
                        {
                            // If either object is a rigid body, it should stop and not be affected by gravity
                            if (a.IsRigidBody && !b.IsRigidBody)
                            {
                                // push b out of a and stop b
                                if (overlap.Width < overlap.Height)
                                {
                                    if (a.Position.X < b.Position.X)
                                        b.Position = new PointF(b.Position.X + overlap.Width, b.Position.Y);
                                    else
                                        b.Position = new PointF(b.Position.X - overlap.Width, b.Position.Y);
                                }
                                else
                                {
                                    if (a.Position.Y < b.Position.Y)
                                        b.Position = new PointF(b.Position.X, b.Position.Y + overlap.Height);
                                    else
                                        b.Position = new PointF(b.Position.X, b.Position.Y - overlap.Height);
                                }
                                b.Velocity = PointF.Empty;
                            }
                            else if (b.IsRigidBody && !a.IsRigidBody)
                            {
                                // push a out of b and stop a
                                if (overlap.Width < overlap.Height)
                                {
                                    if (b.Position.X < a.Position.X)
                                        a.Position = new PointF(a.Position.X + overlap.Width, a.Position.Y);
                                    else
                                        a.Position = new PointF(a.Position.X - overlap.Width, a.Position.Y);
                                }
                                else
                                {
                                    if (b.Position.Y < a.Position.Y)
                                        a.Position = new PointF(a.Position.X, a.Position.Y + overlap.Height);
                                    else
                                        a.Position = new PointF(a.Position.X, a.Position.Y - overlap.Height);
                                }
                                a.Velocity = PointF.Empty;
                            }
                            else
                            {
                                // Neither or both are rigid — do simple half separation to avoid sticking
                                if (overlap.Width < overlap.Height)
                                {
                                    float sep = overlap.Width / 2f;
                                    if (a.Position.X < b.Position.X)
                                    {
                                        a.Position = new PointF(a.Position.X - sep, a.Position.Y);
                                        b.Position = new PointF(b.Position.X + sep, b.Position.Y);
                                    }
                                    else
                                    {
                                        a.Position = new PointF(a.Position.X + sep, a.Position.Y);
                                        b.Position = new PointF(b.Position.X - sep, b.Position.Y);
                                    }
                                }
                                else
                                {
                                    float sep = overlap.Height / 2f;
                                    if (a.Position.Y < b.Position.Y)
                                    {
                                        a.Position = new PointF(a.Position.X, a.Position.Y - sep);
                                        b.Position = new PointF(b.Position.X, b.Position.Y + sep);
                                    }
                                    else
                                    {
                                        a.Position = new PointF(a.Position.X, a.Position.Y + sep);
                                        b.Position = new PointF(b.Position.X, b.Position.Y - sep);
                                    }
                                }
                            }

                            // Stop rigid bodies and disable their physics so gravity won't affect them
                            if (a.IsRigidBody)
                            {
                                a.Velocity = PointF.Empty;
                                a.HasPhysics = false;
                            }
                            if (b.IsRigidBody)
                            {
                                b.Velocity = PointF.Empty;
                                b.HasPhysics = false;
                            }
                        }

                        // Notify objects about the collision so they can react (damage, pickup, etc.)
                        collidables[i].OnCollision((GameObject)collidables[j]);
                        collidables[j].OnCollision((GameObject)collidables[i]);
                    }
                }
            }
        }
    }
}