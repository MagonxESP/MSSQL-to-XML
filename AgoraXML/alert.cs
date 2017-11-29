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

        public static bool Confirm(string text)
        {
            DialogResult dr = MessageBox.Show(null, text, "?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                return true;
            }

            return false;
        }
    }
}
