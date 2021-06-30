using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL.Ultilities
{
    class Ultility
    {
        public static string generateId(string name)
        {
            return name + Nanoid.Nanoid.Generate("0123456789", 5);
        }

        public static void modal(Form parent, Form child)
        {
            Form formBackground = new Form();
            try
            {
                using (child)
                {
                    // Tao background 
                    formBackground.StartPosition = FormStartPosition.Manual;
                    formBackground.FormBorderStyle = FormBorderStyle.None;
                    formBackground.Opacity = .50d;
                    formBackground.BackColor = Color.Black;
                    formBackground.TopMost = true;
                    formBackground.Location = parent.Location;
                    formBackground.Size = parent.Size;
                    formBackground.ShowInTaskbar = false;
                    formBackground.Show();

                    // Hien thi modal
                    child.Owner = formBackground;
                    child.StartPosition = FormStartPosition.CenterParent; // Hien thi form o giua
                    child.FormBorderStyle = FormBorderStyle.None;
                    child.ShowDialog();

                    formBackground.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                formBackground.Dispose();
            }
        }
    }
}
