using System.Drawing.Drawing2D;

namespace Atalhos
{
  public class Windows11Renderer : ToolStripProfessionalRenderer
  {
    public Windows11Renderer() : base(new Windows11ColorTable())
    {
      this.RoundedEdges = false; // Remove as bordas arredondadas padrão antigas do WinForms
    }

    // Renderiza o fundo do item com cantos arredondados no estado de Hover (foco)
    protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
    {
      if (e.Item.Selected && e.Item.Enabled)
      {
        e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        // Aplica margem para o hover não encostar nas bordas do menu
        Rectangle rect = new Rectangle(4, 2, e.Item.Width - 8, e.Item.Height - 4);

        using (GraphicsPath path = GetRoundedRect(rect, 4))
        using (SolidBrush brush = new SolidBrush(Color.FromArgb(65, 65, 65))) // Cor de destaque do hover
        {
          e.Graphics.FillPath(brush, path);
        }
      }
    }

    // Estiliza os separadores com as margens corretas
    protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
    {
      // Adiciona margem lateral no separador e define a espessura de 1px
      Rectangle rect = new Rectangle(12, e.Item.Height / 2, e.Item.Width - 24, 1);
      using (SolidBrush brush = new SolidBrush(Color.FromArgb(80, 80, 80)))
      {
        e.Graphics.FillRectangle(brush, rect);
      }
    }

    // Garante a cor correta do texto
    protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
    {
      e.TextColor = e.Item.Enabled ? Color.White : Color.Gray;
      base.OnRenderItemText(e);
    }

    // Garante a cor correta da seta de submenus
    protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
    {
      e.ArrowColor = e.Item.Enabled ? Color.White : Color.Gray;
      base.OnRenderArrow(e);
    }

    // Método utilitário para desenhar retângulos com cantos arredondados (GDI+)
    private GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
    {
      GraphicsPath path = new GraphicsPath();
      int diameter = radius * 2;
      Rectangle arc = new Rectangle(bounds.Location, new Size(diameter, diameter));

      path.AddArc(arc, 180, 90);
      arc.X = bounds.Right - diameter;
      path.AddArc(arc, 270, 90);
      arc.Y = bounds.Bottom - diameter;
      path.AddArc(arc, 0, 90);
      arc.X = bounds.Left;
      path.AddArc(arc, 90, 90);
      path.CloseFigure();

      return path;
    }
  }
}
