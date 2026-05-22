using Atalhos.Controller;
using Atalhos.DTO;
using Atalhos.Properties;
using MaterialSkin3.Controls;
using Microsoft.Win32;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace Atalhos
{
  public partial class AtalhosMainForm : MaterialForm
  {
    #region [- PROPERTIES -]
    private Dictionary<string, string> _nomesAtalhos;
    protected AmbienteController _ambienteController { get; set; } = new AmbienteController();
    protected AliasController _aliasController { get; set; } = new AliasController();

    public List<AmbienteDTO> _listaAmbiente { get; set; } = new List<AmbienteDTO>();
    public List<AtalhoDTO> _listaAtalhos { get; set; } = new List<AtalhoDTO>();
    protected List<AliasConfigDTO> _listaAlias { get; set; } = new List<AliasConfigDTO>();
    protected AmbienteDTO _ambienteAtual { get; set; }
    private AliasConfigDTO _aliasAtual { get; set; }
    private bool _onTray;
    private bool _onShow = true;
    #endregion

    public AtalhosMainForm()
    {
      InitializeComponent();
      RestoreWindowPosition();
      InitializeMaterialSkin.Excute(this);
      SystemEvents.UserPreferenceChanged += (s, e) =>
      {
        if (e.Category == UserPreferenceCategory.General)
        {
          FormThemeHelper.SetTitleBarColor(this);
        }
      };
    }

    private void MouseFeedBack()
    {
      Cursor.Current = Cursors.WaitCursor;
      Thread.Sleep(500);
      Cursor.Current = Cursors.Default;
    }

    private void RestoreWindowPosition()
    {
      if (global::Atalhos.Properties.Settings.Default.WindowTop != 0)
        this.Top = global::Atalhos.Properties.Settings.Default.WindowTop;
      if (global::Atalhos.Properties.Settings.Default.WindowLeft != 0)
        this.Left = global::Atalhos.Properties.Settings.Default.WindowLeft;
      _onTray = global::Atalhos.Properties.Settings.Default.MinimizeOnTray;
    }

    private void SaveWindowPosition()
    {
      if (this.Top < 0 || this.Left < 0)
      {
        global::Atalhos.Properties.Settings.Default.WindowTop = 500;
        global::Atalhos.Properties.Settings.Default.WindowLeft = 500;
      }
      else
      {
        global::Atalhos.Properties.Settings.Default.WindowTop = this.Top;
        global::Atalhos.Properties.Settings.Default.WindowLeft = this.Left;
      }
      global::Atalhos.Properties.Settings.Default.MinimizeOnTray = chkOnTray.Checked;
      Properties.Settings.Default.Save();
    }

    private void AtalhosMainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      SaveWindowPosition();
      if (notifyIcon != null)
      {
        notifyIcon.Visible = false;
        notifyIcon.Dispose();
      }
    }

    private void ValidarVersao()
    {
      VersionController versionController = new VersionController();
      if (!versionController.IsLastVersion())
      {
        var result = MessageBox.Show("Existe nova versão disponível!\r\nDeseja acessar a página de download?", "Atalho", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result == DialogResult.Yes)
          Process.Start("https://github.com/viniciusfs15/Atalhos/releases");
      }
    }

    private void AtalhosMainForm_Load(object sender, EventArgs e)
    {
      ValidarVersao();
      LerAmbientes();
      SetAmbienteFavorito();
      lblLog.Text = string.Empty;
      SetAmbienteAndAliasAtual();
      CarregaCbmAlias();
      FormThemeHelper.SetTitleBarColor(this);
      PreencherCampos();
      LerAliasExistentes();
      chkOnTray.Checked = _onTray;
      ConfigurarTray();
      DefineSize();
    }

    private void DefineSize()
    {
      this.Size = new Size(947, 452);
    }

    private void LerAliasExistentes()
    {
      _aliasController.ReadAllExistentAlias(_listaAmbiente);
    }

    private void SetAmbienteFavorito()
    {
      int indiceFavorito = 0;
      for (int i = 0; i < _listaAmbiente.Count; i++)
      {
        var ambiente = _listaAmbiente[i];
        cmbAmbiente.Items.Add(ambiente.Unidade + ambiente.Nome);
        if (ambiente.Favorito)
        {
          indiceFavorito = i;
        }
      }
      cmbAmbiente.SelectedIndex = indiceFavorito;
      chkFavorito.Checked = true;
    }

    private void LerAmbientes()
    {
      _listaAmbiente.Clear();
      _listaAmbiente.AddRange(_ambienteController.LerAmbientes(_listaAtalhos));
      if (_listaAmbiente.Count == 0)
      {
        MessageBox.Show("Nenhum ambiente encontrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
      }
    }

    private void PreencherCampos()
    {
      if (_ambienteAtual == null) return;
      chkFavorito.Checked = _ambienteAtual.Favorito;
      chkAutoLogin.Checked = _ambienteAtual.AutoLogin;
      chkControlaIis.Checked = _ambienteAtual.ControlaIIS;
    }

    public void SetAmbienteAtual()
    {
      LerAmbientes();
      if (string.IsNullOrWhiteSpace(cmbAmbiente.SelectedItem?.ToString()))
        return;
      var ambiente = _listaAmbiente.Find(x => x.Nome == cmbAmbiente.SelectedItem?.ToString()?.Split('\\')[1]);

      _ambienteAtual = ambiente;
      if (_ambienteAtual == null) return;

      PreencherListaAtalhos();
      _ambienteAtual.Arquivos = _listaAtalhos;
    }

    public void SetAmbienteAndAliasAtual()
    {
      SetAmbienteAtual();
      _listaAlias = _aliasController.GetAliasByAmbienteName(_ambienteAtual.Nome).ToList();

      if (string.IsNullOrWhiteSpace(cmbAmbiente.SelectedItem.ToString()))
        return;

      if (cmbAlias.SelectedItem == null)
        return;

      _aliasAtual = _listaAlias.Find(x => x.NomeAlias == cmbAlias.SelectedItem.ToString());
    }

    public void PreencherListaAtalhos()
    {
      _listaAtalhos.Clear();
      if (cmbAmbiente.Items.Count <= 0 || cmbAlias.Items.Count <= 0 || cmbAmbiente.SelectedItem == null || cmbAlias.SelectedItem == null)
        return;
      _listaAtalhos = _ambienteController.GetListAtalhos(_listaAlias, cmbAmbiente.SelectedItem.ToString().Split("\\")[1], cmbAlias.SelectedItem.ToString());
    }

    private void IniciaApp(string nomeApp)
    {
      _ambienteController.IniciarApp(nomeApp);
      MouseFeedBack();
    }

    public void IniciarAppsRM(string nomeApp, bool privilegios = false)
    {
      SetAmbienteAndAliasAtual();
      var atalho = _listaAtalhos.Find(x => x.Nome.ToUpper() == nomeApp.ToUpper());
      if (atalho == null)
        return;

      if (privilegios)
      {
        _ambienteController.IniciarAppComPrivilegios(atalho);
        return;
      }
      _ambienteController.IniciarAppComArgumentos(atalho);

      if (nomeApp.ToUpper() == "RM.HOST.EXE" && _ambienteAtual.ControlaIIS)
      {
        _ambienteController.ReciclarAppPool();
      }
    }

    public void EncerrarAmbiente(object sender, EventArgs e)
    {
      if (_ambienteAtual == null) return;
      _ambienteController.EncerrarProcesso();
      lblLog.Text = string.Empty;
      MouseFeedBack();
    }

    public void EncerrarApp(string nomeApp)
    {
      _ambienteController.EncerrarProcesso(nomeApp);
    }

    private void IniciarAmbiente(object sender, EventArgs e)
    {
      SetAmbienteAndAliasAtual();
      _aliasController.CreateAlias(_ambienteAtual.FullName, _aliasAtual);
      if (_ambienteAtual == null || _ambienteAtual.Arquivos.Count <= 0)
        return;
      _ambienteController.IniciarAmbiente(_ambienteAtual, chkAutoLogin.Checked, chkDelBrokerCustom.Checked, chkDelBroker.Checked);
      chkDelBroker.Checked = false;
      chkDelBrokerCustom.Checked = false;
    }

    private void UpdateAmbienteAtual()
    {
      if (_ambienteAtual == null) return;

      try
      {
        _ambienteAtual.Favorito = chkFavorito.Checked;
        _ambienteAtual.ControlaIIS = chkControlaIis.Checked;
        _ambienteAtual.AutoLogin = chkAutoLogin.Checked;
      }
      catch
      {
      }

      _ambienteController.SaveAmbiente(_ambienteAtual);
    }

    public void cmbAmbiente_SelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      CarregaCbmAlias();
      if (_listaAlias == null || _listaAlias.Count <= 0)
        return;

      chkControlaIis.Checked = _ambienteAtual.ControlaIIS;
      chkFavorito.Checked = _ambienteAtual.Favorito;
      lblLog.Text = string.Empty;
    }

    private void CarregaCbmAlias()
    {
      cmbAlias.Items.Clear();

      SetAmbienteAndAliasAtual();
      if (_listaAlias == null || !_listaAlias.Any())
        return;

      foreach (var alias in _listaAlias)
      {
        cmbAlias.Items.Add(alias.NomeAlias);
      }

      cmbAlias.SelectedIndex = 0;
    }

    public void AtualizarLog()
    {
      lblLog.Text = string.Empty;
      lblLog.Text = _ambienteController.ObterLog(_ambienteAtual);
    }

    private void DelBroker()
    {
      if (chkDelBrokerCustom.Checked == true)
      {
        _ambienteController.ApagarBrokerCustom(_ambienteAtual.Bin);
      }
      if (chkDelBroker.Checked == true)
      {
        _ambienteController.ApagarBroker(_ambienteAtual.Bin);
      }
      chkDelBrokerCustom.Checked = false;
      chkDelBroker.Checked = false;
    }

    private void btnRmExe_Click(object sender, EventArgs e)
    {
      IniciarAmbiente(sender, e);
      MouseFeedBack();
    }

    private void btnHost_Click(object sender, EventArgs e)
    {
      AtualizarLog();
      _aliasController.CreateAlias(_ambienteAtual.FullName, _aliasAtual);
      DelBroker();
      IniciarAppsRM(StringConstantes.RM_Host_Exe, true);
      MouseFeedBack();
    }

    private void btnEncerrarAmbiente_Click(object sender, EventArgs e)
    {
      EncerrarAmbiente(sender, e);
      MouseFeedBack();
    }

    private void btnAtualizador_Click(object sender, EventArgs e)
    {
      IniciarAppsRM(StringConstantes.RM_Atualizador);
      MouseFeedBack();
    }

    private void btnAlias_Click(object sender, EventArgs e)
    {
      IniciarAppsRM(StringConstantes.RM_AliasManager);
      MouseFeedBack();
    }

    private void btnBin_Click(object sender, EventArgs e)
    {
      _ambienteController.IniciarExplorer(_ambienteAtual.Bin);
      MouseFeedBack();
    }

    private void btnCustom_Click(object sender, EventArgs e)
    {
      _ambienteController.IniciarExplorer(_ambienteAtual.Custom);
      MouseFeedBack();
    }

    private void btnAbrirIIS_Click(object sender, EventArgs e)
    {
      _ambienteController.IniciarExplorer("C:\\Windows\\System32\\inetsrv\\InetMgr.exe");
      MouseFeedBack();
    }

    private void btnCorporeNet_Click(object sender, EventArgs e)
    {
      _ambienteController.IniciarExplorer(_ambienteAtual.CorporeNet);
      MouseFeedBack();
    }

    private void btnFrameHtml_Click(object sender, EventArgs e)
    {
      _ambienteController.IniciarExplorer(_ambienteAtual.FrameHTML);
      MouseFeedBack();
    }

    private void btnDelDllCustom_Click(object sender, EventArgs e)
    {
      _ambienteController.ApagarDllCustom(_ambienteAtual.Bin);
      AtualizarLog();
      MouseFeedBack();
    }

    private void cmbAlias_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (cmbAlias.SelectedIndex == -1 || cmbAlias.SelectedItem == null)
        return;

      _listaAlias = _aliasController.GetAliasByAmbienteName(_ambienteAtual.Nome).ToList();
      _aliasAtual = _listaAlias.Find(x => x.NomeAlias == cmbAlias.SelectedItem.ToString());
    }

    private void btnAddAlias_Click(object sender, EventArgs e)
    {
      AliasEditorForm aliasEditorForm = new AliasEditorForm();
      SetAmbienteAndAliasAtual();
      aliasEditorForm.Ambiente = _ambienteAtual;
      aliasEditorForm.AliasSelecionado = cmbAlias.SelectedItem != null ? cmbAlias.SelectedItem.ToString() : string.Empty;
      aliasEditorForm.ShowDialog();
      CarregaCbmAlias();
      AtualizarMenuAmbientes();
    }

    private void btnConfigAmbiente_Click(object sender, EventArgs e)
    {
      AmbienteEditorForm ambienteEditorForm = new AmbienteEditorForm();
      SetAmbienteAndAliasAtual();
      ambienteEditorForm._ambiente = _ambienteController.GetAmbiente(_ambienteAtual.Nome);
      ambienteEditorForm.ShowDialog();
      CarregaCbmAlias();
      AtualizarMenuAmbientes();
    }

    private void btnReset_Click(object sender, EventArgs e)
    {
      _ambienteController.ResetarIIS(_ambienteAtual, chkControlaIis.Checked);
      MouseFeedBack();
    }

    private void btnReciclarAppPool_Click(object sender, EventArgs e)
    {
      _ambienteController.ReciclarAppPool();
      MouseFeedBack();
    }

    private void cmbAmbiente_SelectedIndexChanged(object sender, EventArgs e)
    {
      SetAmbienteAndAliasAtual();
      PreencherCampos();
      CarregaCbmAlias();
    }

    private void chkOnTray_CheckedChanged(object sender, EventArgs e)
    {
      global::Atalhos.Properties.Settings.Default.MinimizeOnTray = chkOnTray.Checked;
      Properties.Settings.Default.Save();
      if (chkOnTray.Checked)
      {
        ConfigurarTray();
      }
      else
      {
        notifyIcon.Visible = false;
      }
    }

    private void AtalhosMainForm_Deactivate(object sender, EventArgs e)
    {
      UpdateAmbienteAtual();
      SetAmbienteAndAliasAtual();
    }

    private void ConfigurarTray()
    {
      if (!chkOnTray.Checked) return;

      using (var ms = new MemoryStream(Resources.atalho))
      {
        notifyIcon.Icon = new Icon(ms);
      }
      notifyIcon.Text = "Atalhos";
      notifyIcon.Visible = true;
      notifyIcon.MouseClick += NotifyIcon_MouseClick;
      AtualizarMenuAmbientes();
    }

    private void ExecTrayButon(object sender, EventArgs args, AmbienteDTO ambiente, Action act)
    {
      cmbAmbiente.SelectedItem = ambiente.Unidade + ambiente.Nome;
      if (cmbAlias.Items.Count > 0 && cmbAlias.SelectedItem == null)
        cmbAlias.SelectedIndex = 0;
      act.Invoke();
      MouseFeedBack();
    }

    private void ExecTrayButon(object sender, EventArgs args, AmbienteDTO ambiente, Action act, int delBroker)
    {
      switch (delBroker)
      {
        case 1:
          chkDelBroker.Checked = true;
          break;
        case 2:
          chkDelBrokerCustom.Checked = true;
          break;
        case 3:
          chkDelBrokerCustom.Checked = true;
          chkDelBroker.Checked = true;
          break;
      }
      ExecTrayButon(sender, args, ambiente, act);
    }

    private void ExecTrayButon(object sender, EventArgs args, AmbienteDTO ambiente, string alias, Action act, int? delBroker = 0)
    {
      cmbAlias.SelectedItem = alias;
      if (delBroker != null && delBroker > 0)
        ExecTrayButon(sender, args, ambiente, act, (int)delBroker);
      ExecTrayButon(sender, args, ambiente, act);
    }

    private readonly Font _labelFont = new Font("Segoe UI", 9, FontStyle.Regular);

    private void AtualizarMenuAmbientes()
    {
      contextMenuStripTray.Items.Clear();
      contextMenuStripTray = new CustomContextMenu();

      if (_listaAmbiente == null || !_listaAmbiente.Any())
        return;

      foreach (var ambiente in _listaAmbiente)
      {
        var itemAmbiente = CriarItemAmbiente(ambiente);
        contextMenuStripTray.Items.Add(itemAmbiente);
      }

      contextMenuStripTray.Items.AddRange(new ToolStripItem[]
      {
            new ToolStripSeparator(),
            CriarMenuItem("Encerrar RM.exe e Hosts", Resources.Host_Down, (s, e) => btnEncerrarAmbiente_Click(s, e)),
            new ToolStripSeparator(),
            CriarMenuItem("Encerrar RM.exe", Resources.Host_Down, (s, e) => EncerrarApp("RM")),
            CriarMenuItem("Encerrar Host", Resources.Host_Down, (s, e) => EncerrarApp("RM.Host")),
            new ToolStripSeparator(),
            CriarMenuItem("Abrir IIS", Resources.IIS, (s, e) => btnAbrirIIS_Click(s,e)),
            new ToolStripSeparator(),
            CriarMenuItem("Abrir janela principal", Resources.AtalhoIcone, (s, e) => MostrarJanela()),
            CriarMenuItem("Sair", Resources.Close, (s, e) => EncerrarAplicacao())
      });
    }

    private ToolStripMenuItem CriarItemAmbiente(AmbienteDTO ambiente)
    {
      var itemAmbiente = new ToolStripMenuItem
      {
        Text = $"{ambiente.Unidade}{ambiente.Nome}",
        Tag = ambiente,
        Image = Resources.Settings
      };
      itemAmbiente.Click += (s, e) => ExecTrayButon(s, e, ambiente, () => btnConfigAmbiente_Click(s, e));

      // Adiciona seção de Aliases
      itemAmbiente.DropDown.Items.Add(new ToolStripLabel() { Text = "Aliases", Font = _labelFont, ForeColor = SystemColors.GrayText });

      var aliases = _aliasController.GetAliasByAmbienteName(ambiente.Nome);
      foreach (var alias in aliases)
      {
        itemAmbiente.DropDown.Items.Add(CriarItemAlias(ambiente, alias));
      }

      // Adiciona ações do ambiente (IIS, Pasta, etc)
      itemAmbiente.DropDown.Items.AddRange(new ToolStripItem[]
      {
            new ToolStripSeparator(),
            CriarMenuItem("RM.Atualizador", Resources.Atualizador, (s, e) => ExecTrayButon(s, e, ambiente, () => btnAtualizador_Click(s, e))),
            CriarMenuItem("RM.AliasManager", Resources.ArquivoConfig, (s, e) => ExecTrayButon(s, e, ambiente, () => btnAlias_Click(s, e))),
            new ToolStripSeparator(),
            CriarMenuItem("Bin/RM.net", Resources.Pasta, (s, e) => ExecTrayButon(s, e, ambiente, () => btnBin_Click(s, e))),
            CriarMenuItem("Frame HTML", Resources.Pasta, (s, e) => ExecTrayButon(s, e, ambiente, () => btnFrameHtml_Click(s, e))),
            CriarMenuItem("Corpore.Net", Resources.Pasta, (s, e) => ExecTrayButon(s, e, ambiente, () => btnCorporeNet_Click(s, e))),
            new ToolStripSeparator(),
            CriarMenuItem("Reiniciar IIS", Properties.Resources.IIS, (s, e) => ExecTrayButon(s, e, ambiente, () => btnReset_Click(s, e))),
            CriarMenuItem("Reciclar App Pool", Properties.Resources.IisAppPool, (s, e) => ExecTrayButon(s, e, ambiente, () => btnReciclarAppPool_Click(s, e)))
      });


      return itemAmbiente;
    }

    private ToolStripMenuItem CriarItemAlias(AmbienteDTO ambiente, AliasConfigDTO alias)
    {
      var itemAlias = new ToolStripMenuItem
      {
        Text = alias.NomeAlias,
        Tag = (ambiente, alias),
        Image = Resources.DataBase
      };
      itemAlias.Click += (s, e) => ExecTrayButon(s, e, ambiente, alias.NomeAlias, () => btnAddAlias_Click(s, e));

      itemAlias.DropDown.Items.Add(CriarMenuItem("Iniciar", Properties.Resources.Host, (s, e) => ExecTrayButon(s, e, ambiente, () => IniciarAmbiente(s, e))));
      itemAlias.DropDown.Items.Add(new ToolStripSeparator());
      itemAlias.DropDown.Items.Add(new ToolStripLabel() { Text = "Iniciar apagando:", Font = _labelFont, ForeColor = SystemColors.GrayText });

      itemAlias.DropDown.Items.AddRange(new ToolStripItem[]
      {
            CriarMenuItem("Broker", Properties.Resources.HostClean, (s, e) => ExecTrayButon(s, e, ambiente, () => IniciarAmbiente(s, e), 1)),
            CriarMenuItem("Broker Custom", Properties.Resources.HostClean, (s, e) => ExecTrayButon(s, e, ambiente, () => IniciarAmbiente(s, e), 2)),
            CriarMenuItem("Todos os Broker", Properties.Resources.HostClean, (s, e) => ExecTrayButon(s, e, ambiente, () => IniciarAmbiente(s, e), 3))
      });

      return itemAlias;
    }

    private ToolStripMenuItem CriarMenuItem(string texto, Image imagem, EventHandler clique)
    {
      var item = new ToolStripMenuItem(texto, imagem, clique);
      return item;
    }

    [DllImport("user32.dll")]
    [return: MarshalAs(UnmanagedType.Bool)]
    static extern bool SetForegroundWindow(IntPtr hWnd);

    private void NotifyIcon_MouseClick(object sender, MouseEventArgs e)
    {
      if (e.Button == MouseButtons.Left)
      {
        if (_onShow)
        {
          MinimizarParaTray();
          _onShow = false;
        }
        else
        {
          MostrarJanela();
        }
      }
      else if (e.Button == MouseButtons.Right)
      {
        SetForegroundWindow(this.Handle);
        contextMenuStripTray.Show(Cursor.Position);
      }
    }

    private void MinimizarParaTray()
    {
      this.Hide();
      this.WindowState = FormWindowState.Minimized;
    }

    private void MostrarJanela()
    {
      _onShow = true;
      this.Show();
      this.WindowState = FormWindowState.Normal;
      this.BringToFront();
      this.Activate();
    }

    private void EncerrarAplicacao()
    {
      Application.Exit();
    }

    protected override void OnFormClosing(FormClosingEventArgs e)
    {
      if (e.CloseReason == CloseReason.UserClosing && chkOnTray.Checked)
      {
        e.Cancel = true;
        MinimizarParaTray();
        _onShow = false;
        return;
      }

      base.OnFormClosing(e);
    }
  }
}
