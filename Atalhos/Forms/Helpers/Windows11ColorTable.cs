namespace Atalhos
{
  public class Windows11ColorTable : ProfessionalColorTable
  {
    // Sobrescreve as cores padrão para remover o estilo Office/Windows 7
    public override Color MenuBorder => Color.FromArgb(70, 70, 70);
    public override Color ToolStripDropDownBackground => Color.FromArgb(43, 43, 43);
    public override Color ImageMarginGradientBegin => Color.FromArgb(43, 43, 43);
    public override Color ImageMarginGradientMiddle => Color.FromArgb(43, 43, 43);
    public override Color ImageMarginGradientEnd => Color.FromArgb(43, 43, 43);
    public override Color SeparatorDark => Color.FromArgb(43, 43, 43);
    public override Color SeparatorLight => Color.FromArgb(43, 43, 43);
  }
}
