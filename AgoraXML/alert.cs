using System.Windows.Forms;

namespace AgoraXML
{
    class Alert
    {
        public static void Info(string text)
        {
            MessageBox.Show(null, text, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void Warning(string text)
        {
            MessageBox.Show(null, text, "Oups", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
