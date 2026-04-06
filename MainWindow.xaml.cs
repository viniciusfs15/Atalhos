using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Input;
using System.Threading;
using System.Linq;
using System.IO;
using Atalhos.Controllers;
using System.Diagnostics;

namespace Atalhos
{
  /// <summary>
  /// Interaction logic for MainWindow.xaml
  /// </summary>
  public partial class MainWindow : Window
  {
    #region Properties
    public List<Ambiente> ListaAmbiente { get; set; } = new List<Ambiente>();
    public List<Atalho> ListaAtalhos { get; set; } = new List<Atalho>();

    public Dictionary<string, string> NomeAtalhos = new Dictionary<string, string>();

    public Ambiente AmbienteAtual { get; set; }
    public IEnumerable<AliasConfig> Alias { get; set; } = new List<AliasConfig>();
    public AliasConfig AliasSelecionado { get; set; }

    public AmbienteController AmbienteController
    {
      get
      {
        if (_controller == null)
          _controller = new AmbienteController();
        return _controller;
      }
      set { _controller = value; }
    }
    private AmbienteController _controller;

    public ConfigController ConfigController
    {
      get
      {
        if (_configController == null)
          _configController = new ConfigController();
        return _configController;
      }
      set { _configController = value; }
    }
    private ConfigController _configController;

    //private Dictionary<Keys, Action> _shortcuts; //TODO: remover
    #endregion

    public MainWindow()
    {
      InitializeComponent();
      RestoreWindowPosition();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      ValidarVersao();
      LerAmbientes();
      int indiceFavorito = 0;

      for(int i = 0; i < ListaAmbiente.Count; i++)
      {
        var ambiente = ListaAmbiente[i];
        cbxAmbiente.Items.Add(ambiente.Unidade + ambiente.Nome);
        if (ambiente.Nome == "Release")
        {
          indiceFavorito = i;
        }
      }
      cbxAmbiente.SelectedIndex = indiceFavorito;
      lblLog.Text = string.Empty;
    }

    private void LerAmbientes()
    {
      ListaAmbiente.AddRange(AmbienteController.LerAmbientes(ListaAtalhos));

      if (ListaAmbiente.Count == 0)
      {
        System.Windows.MessageBox.Show("Nenhum ambiente encontrado", "Atenção", System.Windows.MessageBoxButton.OK, System.Windows.MessageBoxImage.Warning);
      }
    }

    private static void ValidarVersao()
    {
      VersionController versionController = new VersionController();
      if (!versionController.IsLastVersion())
      {
        var result = System.Windows.MessageBox.Show("Existe nova versão disponível!\r\nDeseja acessar a página de download?", "Atalho", System.Windows.MessageBoxButton.YesNo, System.Windows.MessageBoxImage.Question);
        if (result == System.Windows.MessageBoxResult.Yes)
          Process.Start("https://github.com/viniciusfs15/Atalhos/releases");
      }
    }

    private void GetNomesAtalhos()
    {
      if(cbxAlias.Items.Count <= 0) return;

      var alias = Alias.ToList().Where(x => x.Versao == AmbienteAtual.Nome && x.NomeAlias == cbxAlias.SelectedItem.ToString()).FirstOrDefault();
      string atributosRmexe = alias == null ?
        "multi=true alias=CorporeRM user=mestre password=totvs #objetos_gerenciais" :
        $"multi=true alias=CorporeRM user={alias.UsuarioRM} password={alias.SenhaRM} #objetos_gerenciais";

      var dictionary = new Dictionary<string, string>();
      dictionary.Add(StringConstantes.RM_Exe, atributosRmexe);
      dictionary.Add(StringConstantes.RM_AliasManager, "");
      dictionary.Add(StringConstantes.RM_Atualizador, "");
      dictionary.Add(StringConstantes.RM_Exe_Config, "");
      dictionary.Add(StringConstantes.RM_Host_Exe_Config, "");
      dictionary.Add(StringConstantes.RM_Host_Exe, "");
      NomeAtalhos = dictionary;
    }

    public void SetAmbienteAtual()
    {
      if (!string.IsNullOrWhiteSpace(cbxAmbiente.SelectedItem.ToString()))
      {
        var ambiente = ListaAmbiente.Find(x => x.Nome == cbxAmbiente.SelectedItem.ToString().Split('\\')[1]);

        AmbienteAtual = ambiente;

        PreencherListaAtalhos();
        chkControleIis.IsChecked = AmbienteAtual.ControlaIIS;
      }
    }

    public void SetAliasAtual()
    {
      SetAmbienteAtual();
      if (!string.IsNullOrWhiteSpace(cbxAmbiente.SelectedItem.ToString()))
      {
        Alias = AmbienteController.LerAlias(AmbienteAtual);
        if (Alias != null && cbxAlias.SelectedItem != null)
          AmbienteAtual.ControlaIIS = Alias.ToList().Find(x => x.NomeAlias == cbxAlias.SelectedItem.ToString()).ControlaIIS;
      }
    }

    public void PreencherListaAtalhos()
    {
      ListaAtalhos.Clear();
      GetNomesAtalhos();

      foreach (var nome in NomeAtalhos)
      {
        var caminhoAtalho = AmbienteAtual.FullName + "\\" + nome.Key;
        ListaAtalhos.Add(new Atalho(nome.Key, caminhoAtalho, nome.Value));
      }

      var ambiente = AmbienteAtual;
      AmbienteController.CarregarAtalhos(NomeAtalhos, ref ambiente);
      AmbienteAtual = ambiente;
    }

    private void IniciarApp(string app, bool privilegios = false)
    {
      SetAmbienteAtual();
      var atalho = AmbienteAtual.Arquivos.Find(x => x.Nome == app);
      if (atalho == null)
        return;

      if (privilegios)
      {
        AmbienteController.IniciarAppComPrivilegios(atalho);
        return;
      }
      AmbienteController.IniciarAppComArgumentos(atalho);
      
      if (app == "RM.Host.exe" && AmbienteAtual.ControlaIIS)
        AmbienteController.ReciclarAppPool();
    }

    private void Encerrar_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      AmbienteController.EncerrarProcesso();
      lblLog.Text = string.Empty;
    }

    private void bntIniciar_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      SetAmbienteAtual();

      if (AmbienteAtual != null && AmbienteAtual.Arquivos.Count > 0)
        AmbienteController.IniciarAmbiente(AmbienteAtual, (bool)chkLogin.IsChecked, (bool)chkDelCustom.IsChecked);
    }

    private void cbxAmbiente_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      CarregaCbxAlias();
      if(Alias == null || cbxAlias.SelectedItem == null)
				return;
			AmbienteAtual.ControlaIIS = Alias.ToList().Find(x => x.NomeAlias == cbxAlias.SelectedItem.ToString()).ControlaIIS;
      chkControleIis.IsChecked = AmbienteAtual.ControlaIIS;
    }

    private void CarregaCbxAlias()
    {
      cbxAlias.Items.Clear();

      SetAliasAtual();
      if (Alias != null)
      {
        foreach (var config in Alias.ToList().OrderBy(x => x.NomeAlias))
        {
          cbxAlias.Items.Add(config.NomeAlias);
        }

        cbxAlias.SelectedIndex = 0;
      }
    }

    private void btnRMexe_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      bntIniciar_Click(sender, e);
    }

    private void btnHost_Click(object sender, RoutedEventArgs e)
    {
      AtualizarLog();

      MouseFeedBack();
      AmbienteController.CreateAlias(AmbienteAtual.FullName, AliasSelecionado);
      DelBroker();
      IniciarApp("RM.Host.exe", true);
    }

    private void AtualizarLog()
    {
      lblLog.Text = string.Empty;
      lblLog.Text = AmbienteController.ObterLog(AmbienteAtual);
    }

    private void btnAtualizador_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      IniciarApp("RM.Atualizador.exe");
    }

    private void DelBroker()
    {
      if(chkDelCustom.IsChecked == true)
      {
        AmbienteController.ApagarBrokerCustom(AmbienteAtual.Bin);
      }
      if(chkDelBroker.IsChecked == true)
      {
        AmbienteController.ApagarBroker(AmbienteAtual.Bin);
      }
      chkDelCustom.IsChecked = false;
      chkDelBroker.IsChecked = false;
    }

    private void btnDelDllCustom_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      AmbienteController.ApagarDllCustom(AmbienteAtual.Bin);
      AtualizarLog();
    }

    private void btnAlias_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      IniciarApp("RM.AliasManager.exe");
    }

    private void cbxAlias_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if (cbxAlias.SelectedItem != null)
      {
        Alias = AmbienteController.LerAlias(AmbienteAtual);
        AliasSelecionado = Alias.ToList().Find(x => x.NomeAlias == cbxAlias.SelectedItem.ToString());
      }
    }

    private void btnBin_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      AmbienteController.IniciarAppComArgumentos(new Atalho(AmbienteAtual.Bin));
    }

    private void MouseFeedBack()
    {
      Mouse.SetCursor(System.Windows.Input.Cursors.Wait);
      Thread.Sleep(500);
      Mouse.SetCursor(System.Windows.Input.Cursors.Arrow);
    }

    private void btnNovoAlias_Click(object sender, RoutedEventArgs e)
    {
      AliasForm form = new AliasForm();
      form.Ambiente = AmbienteAtual;
      form.AliasSelecionado = cbxAlias.SelectedItem?.ToString();
      form.ShowDialog();
      CarregaCbxAlias();
    }

    private void btnCustom_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      AmbienteController.IniciarAppComArgumentos(new Atalho(Path.Combine(AmbienteAtual.Bin, "Custom")));
    }

    private void btnIisReset_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      AmbienteController.ResetarIIS(AmbienteAtual, chkControleIis.IsChecked);
    }

    private void chkControleIis_Checked(object sender, RoutedEventArgs e)
    {
      ConfigController.ControlarIIS(AmbienteAtual, chkControleIis.IsChecked);
    }

    private void SaveWindowPosition()
    {
      Properties.Settings.Default.WindowTop = this.Top;
      Properties.Settings.Default.WindowLeft = this.Left;
      Properties.Settings.Default.WindowHeight = this.Height;
      Properties.Settings.Default.WindowWidth = this.Width;
      Properties.Settings.Default.Save();
    }
    private void RestoreWindowPosition()
    {
      if (Properties.Settings.Default.WindowTop != 0)
        this.Top = Properties.Settings.Default.WindowTop;
      if (Properties.Settings.Default.WindowLeft != 0)
        this.Left = Properties.Settings.Default.WindowLeft;
      if (Properties.Settings.Default.WindowHeight != 0)
        this.Height = Properties.Settings.Default.WindowHeight;
      if (Properties.Settings.Default.WindowWidth != 0)
        this.Width = Properties.Settings.Default.WindowWidth;
    }

    private void Window_Closing(object sender, EventArgs e)
    {
      SaveWindowPosition();
    }

    private void btnIisReciclar_Click(object sender, RoutedEventArgs e)
    {
      AmbienteController.ReciclarAppPool();
      MouseFeedBack();
    }
  }
}
