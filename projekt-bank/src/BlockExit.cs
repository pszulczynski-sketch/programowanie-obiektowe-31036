using System.Runtime.InteropServices;

namespace projekt_bank
{
      public class BlockExit()
      {
            [DllImport("user32.dll")]
            static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

            [DllImport("user32.dll")]
            static extern bool DeleteMenu(IntPtr hMenu, uint uPosition, uint uFlags);

            [DllImport("kernel32.dll")]
            static extern IntPtr GetConsoleWindow();

            const uint SC_CLOSE = 0xF060;
            const uint MF_BYCOMMAND = 0x00000000;

            public void DisableCloseButton()
            {
                  IntPtr window = GetConsoleWindow();
                  IntPtr menu = GetSystemMenu(window,false);
                  DeleteMenu(menu,SC_CLOSE,MF_BYCOMMAND);
            }
      }
}