using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;

namespace Kindergarten
{
    public static class func
    {
        // Flags for playing sounds.  For this example, we are reading 
        // the sound from a filename, so we need only specify 
        // SND_FILENAME | SND_ASYNC
        [Flags]
        public enum SoundFlags : int
        {
            SND_SYNC = 0x0000,  // play synchronously (default) 
            SND_ASYNC = 0x0001,  // play asynchronously 
            SND_NODEFAULT = 0x0002,  // silence (!default) if sound not found 
            SND_MEMORY = 0x0004,  // pszSound points to a memory file
            SND_LOOP = 0x0008,  // loop the sound until next sndPlaySound 
            SND_NOSTOP = 0x0010,  // don't stop any currently playing sound 
            SND_NOWAIT = 0x00002000, // don't wait if the driver is busy 
            SND_ALIAS = 0x00010000, // name is a registry alias 
            SND_ALIAS_ID = 0x00110000, // alias is a predefined ID
            SND_FILENAME = 0x00020000, // name is file name 
            SND_RESOURCE = 0x00040004  // name is resource name or atom 
        }

        [DllImport("winmm.dll", EntryPoint = "mciSendStringA", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        public static extern int mciSendString(string lpstrCommand, string lpstrReturnString, int uReturnLength, int hwndCallback);

        [DllImport("winmm.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        public static extern bool PlaySound(
            string pszSound,
            IntPtr hMod,
            SoundFlags sf);


        public static MySqlConnection connection;
        public static login loginForm;
        public static admin adminForm;
        public static parent parentForm;
        public static student studentForm;
        public static string userid;

        public static void conn()
        {
            func.connection = new MySqlConnection("SERVER=127.0.0.1;DATABASE=kindergarten;UID=root;PASSWORD=;");
            func.connection.Open();

        }

        public static void start()
        {
            conn();
            func.loginForm = new login();
            // func.adminForm = new admin();
            // func.parentForm = new parent();
            // func.studentForm = new student();
        }

        public static void about(Form container)
        {
            MessageBox.Show(container, "about form");
        }
    }
}

