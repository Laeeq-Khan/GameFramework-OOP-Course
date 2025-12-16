namespace GameFrameWork
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            gameTimer = new System.Windows.Forms.Timer(components);
            player1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)player1).BeginInit();
            SuspendLayout();
            // 
            // gameTimer
            // 
            gameTimer.Enabled = true;
            gameTimer.Tick += gameTimer_Tick;
            // 
            // player1
            // 
            player1.Image = (Image)resources.GetObject("player1.Image");
            player1.Location = new Point(378, 384);
            player1.Name = "player1";
            player1.Size = new Size(97, 123);
            player1.SizeMode = PictureBoxSizeMode.StretchImage;
            player1.TabIndex = 0;
            player1.TabStop = false;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1091, 606);
            Controls.Add(player1);
            Name = "Game";
            Text = "Game";
            ((System.ComponentModel.ISupportInitialize)player1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Timer gameTimer;
        private PictureBox player1;
    }
}