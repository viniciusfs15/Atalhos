using System.Runtime.InteropServices;

namespace Atalhos
{
  public class CustomContextMenu : ContextMenuStrip
  {
    [DllImport("dwmapi.dll", CharSet = CharSet.Unicode, SetLastError = true)]
    private static extern long DwmSetWindowAttribute(IntPtr hwnd, int attr, ref uint pvAttr, uint cbAttr);

    public CustomContextMenu()
    {

      this.Renderer = new Windows11Renderer();
      this.BackColor = System.Drawing.Color.FromArgb(43, 43, 43);
      this.ForeColor = System.Drawing.Color.White;
      this.Padding = new Padding(2, 4, 2, 4);
      this.ShowImageMargin = true;
      this.AutoClose = true;
    }

    protected override void OnHandleCreated(EventArgs e)
    {
      base.OnHandleCreated(e);
      ApplyRoundedCornersToHandle(this.Handle);
    }

    // Intercepta a adição de itens no nível raiz do ContextMenu
    protected override void OnItemAdded(ToolStripItemEventArgs e)
    {
      base.OnItemAdded(e);
      AttachDropDownEvent(e.Item);
    }

    // Configura recursivamente os eventos para submenus
    private void AttachDropDownEvent(ToolStripItem item)
    {
      if (item is ToolStripMenuItem menuItem)
      {
        // Remove e adiciona para evitar vazamento de memória e múltiplas inscrições
        menuItem.DropDownOpened -= MenuItem_DropDownOpened;
        menuItem.DropDownOpened += MenuItem_DropDownOpened;

        // Garante que o submenu utilize o mesmo renderizador e cor de fundo do menu pai
        if (menuItem.DropDown != null)
        {
          menuItem.DropDown.Renderer = this.Renderer;
          menuItem.DropDown.BackColor = this.BackColor;
          menuItem.DropDown.ForeColor = this.ForeColor;

          // Escuta itens adicionados dinamicamente ao submenu
          menuItem.DropDown.ItemAdded -= DropDown_ItemAdded;
          menuItem.DropDown.ItemAdded += DropDown_ItemAdded;
        }

        // Aplica a lógica para sub-itens já existentes (ex: adicionados via Designer)
        if (menuItem.HasDropDownItems)
        {
          foreach (ToolStripItem subItem in menuItem.DropDownItems)
          {
            AttachDropDownEvent(subItem);
          }
        }
      }
    }

    private void DropDown_ItemAdded(object sender, ToolStripItemEventArgs e)
    {
      AttachDropDownEvent(e.Item);
    }

    // Injeta a API do DWM assim que a janela do submenu é criada e aberta
    private void MenuItem_DropDownOpened(object sender, EventArgs e)
    {
      if (sender is ToolStripMenuItem menuItem && menuItem.DropDown != null)
      {
        ApplyRoundedCornersToHandle(menuItem.DropDown.Handle);
      }
    }

    private void ApplyRoundedCornersToHandle(IntPtr handle)
    {
      if (handle != IntPtr.Zero && Environment.OSVersion.Version.Major >= 10 && Environment.OSVersion.Version.Build >= 22000)
      {
        uint pvAttribute = (uint)DWM_WINDOW_CORNER_PREFERENCE.DWMWCP_ROUNDSMALL;
        DwmSetWindowAttribute(handle, (int)DWMWINDOWATTRIBUTE.DWMWA_WINDOW_CORNER_PREFERENCE, ref pvAttribute, sizeof(uint));
      }
    }
  }

  public enum DWMWINDOWATTRIBUTE
  {
    DWMWA_WINDOW_CORNER_PREFERENCE = 33
  }

  public enum DWM_WINDOW_CORNER_PREFERENCE
  {
    DWMWA_DEFAULT = 0,
    DWMWCP_DONOTROUND = 1,
    DWMWCP_ROUND = 2,
    DWMWCP_ROUNDSMALL = 3,
  }
}
