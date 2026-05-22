using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using static Atalhos.CustomContextMenu;

namespace Atalhos
{
  public class FormThemeHelper
  {
    [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern long DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);

    // Atributo para definir a cor da barra de título
    private const int DWMWA_CAPTION_COLOR = 35;

    public static void SetTitleBarColor(Form form)
    {
      if (OsIsWindows10OrGreater())
      {
        int colorValue = ColorTranslator.ToWin32(GetAccentColor());
        DwmSetWindowAttribute(form.Handle, DWMWA_CAPTION_COLOR, ref colorValue, sizeof(int));
      }
    }

    private static bool OsIsWindows10OrGreater()
    {
      return Environment.OSVersion.Version.Major >= 10;
    }

    private static Color GetAccentColor()
    {
      if (!IsAccentColorOnTitleBarsEnabled())
      {
        if (IsWindowsDarkMode())
          return Color.FromArgb(32, 32, 32);
        return SystemColors.ActiveCaption;
      }

      var key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\DWM");
      if (key != null)
      {
        // O valor é armazenado como um DWORD em formato ABGR
        int colorValue = (int)key.GetValue("AccentColor");

        // Converte de ABGR para ARGB (padrão do .NET)
        byte a = (byte)((colorValue >> 24) & 0xFF);
        byte b = (byte)((colorValue >> 16) & 0xFF);
        byte g = (byte)((colorValue >> 8) & 0xFF);
        byte r = (byte)(colorValue & 0xFF);

        return Color.FromArgb(a, r, g, b);
      }
      return Color.Empty;
    }

    private static bool IsWindowsDarkMode()
    {
      try
      {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Themes\Personalize"))
        {
          // AppsUseLightTheme = 0 significa Modo Escuro
          return (int)key?.GetValue("AppsUseLightTheme") == 0;
        }
      }
      catch { return false; }
    }

    public static bool IsAccentColorOnTitleBarsEnabled()
    {
      try
      {
        using (RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\DWM"))
        {
          if (key != null)
          {
            object value = key.GetValue("ColorPrevalence");
            if (value != null)
            {
              return (int)value == 1;
            }
          }
        }
      }
      catch
      {
      }

      return false;
    }
  }
}
