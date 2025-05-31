using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirtualVanguard
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Initialize Supabase service
            var supabaseUrl = "https://iovuooitdddswxrrdydd.supabase.co";
            var supabaseKey = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImlvdnVvb2l0ZGRkc3d4cnJkeWRkIiwicm9sZSI6ImFub24iLCJpYXQiOjE3Mzc1ODg4NDQsImV4cCI6MjA1MzE2NDg0NH0.mkz2rf2pwcuI_2eJF_BFPNi62QvIJ9_qw2qT3NJU7Cc";
            var supabaseService = new SupabaseService(supabaseUrl, supabaseKey);

#if DEBUG   // In Debug mode, skip login and go straight to MainUI
            Application.Run(new MainUI(supabaseService));

#else       // In Release mode, show the login form first
            
            LoginForm loginForm = new LoginForm(supabaseService);

            // Show LoginForm first
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // If login is successful, open MainUI
                Application.Run(new MainUI(supabaseService));
            }
#endif
        }
    }
}
