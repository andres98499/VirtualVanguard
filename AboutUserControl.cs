using System;
using System.Windows.Forms;
using System.Drawing;

namespace VirtualVanguard
{
    public partial class AboutUserControl : UserControl
    {
        public AboutUserControl()
        {
            InitializeComponent();
            SetupUI();
        }

        private void SetupUI()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label titleLabel = new Label
            {
                Text = "About This Application",
                Font = new Font("Arial", 16, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(20, 20)
            };

            Label descriptionLabel = new Label
            {
                Text = "This application was developed as a senior project at University Of Washington Tacoma.\n\n" +
                       "Developed by:\n" +
                       "- Duc Vy Dang - Developer\n" +
                       "- Andres Gamboa - Developer\n" +
                       "- Anthony Kitts - Project Manager\n" +
                       "- Shilong Nie - Designer\n\n" +
                       "Supervised by: Dr. West\n\n" +
                       "© 2024 University Of Washington Tacoma. All rights reserved.",
                Font = new Font("Arial", 12),
                AutoSize = false,
                Size = new Size(500, 200),
                Location = new Point(20, 60)
            };

            PictureBox schoolLogo = new PictureBox
            {
                Image = Image.FromFile("Resources/school_logo.png"), // Change this to your actual image
                Size = new Size(120, 120),
                SizeMode = PictureBoxSizeMode.Zoom,
                Location = new Point(20, 280)
            };

            this.Controls.Add(titleLabel);
            this.Controls.Add(descriptionLabel);
            this.Controls.Add(schoolLogo);
        }
    }
}
