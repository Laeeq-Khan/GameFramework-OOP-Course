using EZInput;
using FirstDesktopApp.Properties;
using GameFrameWork;
using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameFrameWork
{
    public partial class GameForm : Form
    {
        Game game = new Game();
        PhysicsSystem physics = new PhysicsSystem();
        CollisionSystem collisions = new CollisionSystem();
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        public GameForm()
        {
            InitializeComponent();
            DoubleBuffered = true;

            game.AddObject(new Player
            {
                Position = new PointF(100, 200),
                Size = new Size(40, 40),
                Sprite = Resources.fire,
                Movement = new KeyboardMovement()
            });

            game.AddObject(new Player
            {
                Position = new PointF(250, 100),
                Size = new Size(100, 100),
                HasPhysics = true,
               // Movement = new PatrolMovement(left: 100, right: 500)
            });

            // A physics-enabled rigid player — will stop on collision and gravity will be disabled
            game.AddObject(new Player
            {
                Position = new PointF(250, 350),
                Size = new Size(40, 40),
                IsRigidBody = true
            });

            game.AddObject(new Enemy
            {
                Position = new PointF(300, 100),
                Size = new Size(50, 50),
                HasPhysics = false // Enable physics with default gravity
            });

            timer.Interval = 16;
            timer.Tick += GameLoop;
            timer.Start();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {

        }
        private void GameLoop(object sender, EventArgs e)
        {
            // Update all game objects
            game.Update(new GameTime());

            // Apply physics to all objects
            physics.Apply(game.Objects.ToList());

            // Check for collisions between objects
            collisions.Check(game.Objects.ToList());

            // Cleanup objects marked for removal
            game.Cleanup();

            // Redraw the game
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

    }
}
