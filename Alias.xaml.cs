using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Atalhos
{
  /// <summary>
  /// Interaction logic for Alias.xaml
  /// </summary>
  public partial class AliasForm : Window
  {
    public Ambiente Ambiente { get; set; } = new Ambiente();

    public string AliasSelecionado { get; set; }

    public IEnumerable<AliasConfig> LisAlias { get; set; } = new List<AliasConfig>();
    public AliasConfig AliasAtual { get; private set; }

    public AliasForm()
    {
      InitializeComponent();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
      CarregarGridAlias();
    }

    private void CarregarGridAlias()
    {
      gridAlias.Items.Clear();
      var server = new ConfigServer();
      LisAlias = server.GetAliasByVersao(Ambiente.Nome);
      foreach (var alias in LisAlias.ToList().OrderBy(x=>x.NomeAlias))
      {
        gridAlias.Items.Add(alias.NomeAlias);
      }
      gridAlias.SelectedIndex = 0;
      if(!string.IsNullOrWhiteSpace(AliasSelecionado))
        gridAlias.SelectedItem = AliasSelecionado;

      AtualizarCampos(gridAlias.SelectedItem?.ToString());
    }

    private void AtualizarCampos(string nomeAlias)
    {
      LimparCampos();
      if (nomeAlias == null)
        return;
      var alias = LisAlias.Where(x => x.NomeAlias.Equals(nomeAlias)).FirstOrDefault();

      chkJobServerEnabled.IsChecked = alias.JobServerEnabled;
      chkJobServerLocalOnly.IsChecked = alias.JobServerLocalOnly;
      chkJobServerProcessPoolEnabled.IsChecked = alias.JobServerProcessPoolEnabled;
      chkRunService.IsChecked = alias.RunService;
      chkSql.IsChecked = alias.Sgbd == "SQL" ? true : false;
      chkOracle.IsChecked = alias.Sgbd == "ORACLE" ? true : false;

      txtNome.Text = nomeAlias;
      txtServidor.Text = alias.Servidor;
      txtBase.Text = alias.Base;
      txtDbPass.Text = alias.SenhaDB;
      txtDbUser.Text = alias.UsuarioDB;
      txtSenha.Text = alias.SenhaRM;
      txtUsuario.Text = alias.UsuarioRM;
      txtJobServerMaxThreads.Text = alias.JobServerMaxThreads.ToString();
    }

    private void LimparCampos()
    {
      // Limpar checkboxes
      chkJobServerEnabled.IsChecked = false;
      chkJobServerLocalOnly.IsChecked = false;
      chkJobServerProcessPoolEnabled.IsChecked = false;
      chkRunService.IsChecked = true;
      chkSql.IsChecked = true;
      chkOracle.IsChecked = false;

      // Limpar campos de texto
      txtNome.Text = string.Empty;
      txtServidor.Text = string.Empty;
      txtBase.Text = string.Empty;
      txtDbPass.Text = "masterkey";
      txtDbUser.Text = "SYSDBA";
      txtSenha.Text = "totvs";
      txtUsuario.Text = "mestre";
      txtJobServerMaxThreads.Text = "0";
    }


    private void listAlias_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      if(LisAlias == null)
      { return; }

      var selecionado = gridAlias.SelectedItem;
      if (selecionado == null)
        return;

      var alias = LisAlias.Where(x => x.NomeAlias == selecionado.ToString()).FirstOrDefault();
        AtualizarCampos(alias.NomeAlias);
      AliasAtual = alias;
    }

    private void btnNovoAlias_Click(object sender, RoutedEventArgs e)
    {
      gridAlias.SelectedIndex = -1;
      LimparCampos();
    }

    private void btnSalvar_Click(object sender, RoutedEventArgs e)
    {
      var selecionado = gridAlias.SelectedIndex == -1 ? gridAlias.Items.Count : gridAlias.SelectedIndex;

      MouseFeedBack();
      if (string.IsNullOrWhiteSpace(txtNome.Text))
      {
        MessageBox.Show("O campo Nome não pode ser vazio", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
        return;
      }
        
      var server = new ConfigServer();
      if(gridAlias.SelectedItem == null || AliasSelecionado == null)
        server.AddAliasConfig(CriarObjetoAliasConfig());
      else
        server.UpdateAliasConfig(AliasAtual, CriarObjetoAliasConfig());
      CarregarGridAlias();

      gridAlias.SelectedIndex = selecionado;
    }

    private void MouseFeedBack()
    {
      Mouse.SetCursor(System.Windows.Input.Cursors.Wait);
      Thread.Sleep(500);
      Mouse.SetCursor(System.Windows.Input.Cursors.Arrow);
    }

    private AliasConfig CriarObjetoAliasConfig()
    {
      AliasConfig alias = new AliasConfig();

      // Preencher os valores do objeto AliasConfig com os dados dos campos
      alias.JobServerEnabled = chkJobServerEnabled.IsChecked ?? false;
      alias.JobServerLocalOnly = chkJobServerLocalOnly.IsChecked ?? false;
      alias.JobServerProcessPoolEnabled = chkJobServerProcessPoolEnabled.IsChecked ?? false;
      alias.RunService = chkRunService.IsChecked ?? false;
      alias.Sgbd = chkSql.IsChecked == true ? "SQL" : (chkOracle.IsChecked == true ? "ORACLE" : null);

      alias.NomeAlias = txtNome.Text.Trim();
      alias.Servidor = txtServidor.Text.Trim();
      alias.Base = txtBase.Text.Trim();
      alias.SenhaDB = txtDbPass.Text.Trim();
      alias.UsuarioDB = txtDbUser.Text.Trim();
      alias.SenhaRM = txtSenha.Text.Trim();
      alias.UsuarioRM = txtUsuario.Text.Trim();
      alias.JobServerMaxThreads = Convert.ToInt32(txtJobServerMaxThreads.Text);
      alias.Versao = Ambiente.Nome.Trim();

      return alias;
    }

    private void btnExcluir_Click(object sender, RoutedEventArgs e)
    {
      MouseFeedBack();
      var server = new ConfigServer();
      server.RemoveAliasConfig(CriarObjetoAliasConfig());
      CarregarGridAlias();
    }
  }
}
