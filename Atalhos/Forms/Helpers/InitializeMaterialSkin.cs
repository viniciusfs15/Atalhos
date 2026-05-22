using MaterialSkin3;
using MaterialSkin3.Controls;

namespace Atalhos
{
  public class InitializeMaterialSkin
  {
    public static void Excute(MaterialForm form)
    {
      var materialSkinManager = MaterialSkinManager.Instance;
      materialSkinManager.AddFormToManage(form);
      materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
      materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
    }
  }
}
