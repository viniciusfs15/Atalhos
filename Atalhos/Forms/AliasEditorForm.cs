using Atalhos;
using Atalhos.DTO;
using MaterialSkin3.Controls;

namespace Atalhos
{
  public partial class AliasEditorForm : MaterialForm
  {
    public AliasEditorForm()
    {
      InitializeComponent();
      InitializeMaterialSkin.Excute(this);
    }
    private void AliasEditorForm_Load(object sender, EventArgs e)
    {
      CarregarGridAlias();
      FormThemeHelper.SetTitleBarColor(this);
      DefineSize();
    }

    private void DefineSize()
    {
      this.Size = new Size(820, 603);
    }

    public AmbienteDTO Ambiente { get; internal set; }
    public string? AliasSelecionado { get; internal set; }
    private List<AliasConfigDTO> _listAlias { get; set; }
    private AliasConfigDTO _aliasAtual { get; set; }

    private AliasController _controller = new AliasController();

    private void MouseFeedBack()
    {
      Cursor.Current = Cursors.WaitCursor;
      Thread.Sleep(500);
      Cursor.Current = Cursors.Default;
    }

    private void CarregarGridAlias()
    {
      lstAliases.Items.Clear();
      if (Ambiente == null || string.IsNullOrWhiteSpace(Ambiente.Nome))
      {
        LimparCampos();
        return;
      }
      _listAlias = _controller.GetAliasByAmbienteName(Ambiente?.Nome).ToList();

      if (!_listAlias.Any())
      {
        LimparCampos();
        return;
      }

      foreach (var alias in _listAlias.ToList().OrderBy(x => x.NomeAlias))
      {
        lstAliases.Items.Add(alias.NomeAlias);
      }

      if (string.IsNullOrWhiteSpace(AliasSelecionado) && !string.IsNullOrWhiteSpace(txtNomeAlias.Text))
        AliasSelecionado = txtNomeAlias.Text;

      var itemSelecionado = lstAliases.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Text == AliasSelecionado) ??
                            lstAliases.Items.Cast<ListViewItem>().FirstOrDefault(item => item.Text == txtNomeAlias.Text);
      if (itemSelecionado != null)
        itemSelecionado.Selected = true;
      AtualizarCampos(lstAliases.SelectedItems.Cast<ListViewItem>().FirstOrDefault()?.Text);
    }

    private void LimparCampos()
    {
      // Limpar checkboxes
      chkHabilitaPoolProcessos.Checked = false;
      chkHabilitaProcessJobs.Checked = false;
      chkJobsLocais.Checked = false;
      chkRunService.Checked = true;
      chkMsSql.Checked = true;
      chkOracle.Checked = false;

      // Limpar campos de texto
      txtBase.Text = string.Empty;
      txtExecSimultanea.Text = "0";
      txtNomeAlias.Text = string.Empty;
      txtSenhaBd.Text = "masterkey";
      txtSenhaRm.Text = "totvs";
      txtServidor.Text = "localhost";
      txtUsuarioBd.Text = "SYSDBA";
      txtUsuarioRM.Text = "mestre";
    }

    private void AtualizarCampos(string? nomeAlias)
    {
      LimparCampos();
      if (string.IsNullOrWhiteSpace(nomeAlias) || _listAlias == null || !_listAlias.Any()) return;
      var alias = _listAlias.FirstOrDefault(x => x.NomeAlias == nomeAlias);

      chkHabilitaProcessJobs.Checked = alias.JobServerEnabled;
      chkHabilitaPoolProcessos.Checked = alias.JobServerProcessPoolEnabled;
      chkJobsLocais.Checked = alias.JobServerLocalOnly;
      chkRunService.Checked = alias.RunService;
      if (alias.Sgbd == "SQL")
      {
        chkMsSql.Checked = true;
      }
      else
      {
        chkOracle.Checked = true;
      }

      txtExecSimultanea.Text = alias.JobServerMaxThreads.ToString();

      txtNomeAlias.Text = alias.NomeAlias;
      txtServidor.Text = alias.Servidor;
      txtBase.Text = alias.Base;
      txtUsuarioBd.Text = alias.UsuarioDB;
      txtSenhaBd.Text = alias.SenhaDB;
      txtUsuarioRM.Text = alias.UsuarioRM;
      txtSenhaRm.Text = alias.SenhaRM;

    }

    private AliasConfigDTO CriarObjetoAlias()
    {
      return new AliasConfigDTO
      {
        NomeAlias = txtNomeAlias.Text,
        Servidor = txtServidor.Text,
        Base = txtBase.Text,
        UsuarioDB = txtUsuarioBd.Text,
        SenhaDB = txtSenhaBd.Text,
        UsuarioRM = txtUsuarioRM.Text,
        SenhaRM = txtSenhaRm.Text,
        JobServerEnabled = chkHabilitaProcessJobs.Checked,
        JobServerProcessPoolEnabled = chkHabilitaPoolProcessos.Checked,
        JobServerLocalOnly = chkJobsLocais.Checked,
        RunService = chkRunService.Checked,
        JobServerMaxThreads = int.TryParse(txtExecSimultanea.Text, out int maxThreads) ? maxThreads : 0,
        Sgbd = chkMsSql.Checked ? "SQL" : chkOracle.Checked ? "ORACLE" : string.Empty
      };
    }

    private bool ValidarPreenchimentoDosCampos()
    {
      if (string.IsNullOrWhiteSpace(txtNomeAlias.Text))
      {
        MessageBox.Show("O campo 'Nome do Alias' é obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      if (string.IsNullOrWhiteSpace(txtServidor.Text))
      {
        MessageBox.Show("O campo 'Servidor' é obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      if (string.IsNullOrWhiteSpace(txtBase.Text))
      {
        MessageBox.Show("O campo 'Base de Dados' é obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      if (string.IsNullOrWhiteSpace(txtUsuarioBd.Text))
      {
        MessageBox.Show("O campo 'Usuário do Banco de Dados' é obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      if (string.IsNullOrWhiteSpace(txtSenhaBd.Text))
      {
        MessageBox.Show("O campo 'Senha do Banco de Dados' é obrigatório.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return false;
      }
      return true;
    }

    private void btnNovo_Click(object sender, EventArgs e)
    {
      lstAliases.SelectedItems.Clear();
      AtualizarCampos(string.Empty);
    }

    private void btnExcluir_Click(object sender, EventArgs e)
    {
      MouseFeedBack();
      if (_aliasAtual == null)
      {
        MessageBox.Show("Selecione um alias para excluir.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        return;
      }
      var confirmResult = MessageBox.Show($"Tem certeza que deseja excluir o alias '{_aliasAtual.NomeAlias}'?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
      if (confirmResult == DialogResult.Yes)
      {
        _controller.RemoveAlias(_aliasAtual);
        CarregarGridAlias();
      }
    }

    private void lstAliases_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
    {
      if (_listAlias == null || !_listAlias.Any()) return;

      var selecionado = lstAliases.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
      if (selecionado == null) return;

      var alias = _listAlias.FirstOrDefault(x => x.NomeAlias == selecionado.Text);
      AtualizarCampos(alias.NomeAlias);
      _aliasAtual = alias;
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
      var selecionado = lstAliases.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
      MouseFeedBack();
      if (!ValidarPreenchimentoDosCampos()) return;
      if (lstAliases.SelectedItems.Count == 0 || selecionado == null)
        _controller.AddAlias(Ambiente, CriarObjetoAlias());
      else
        _controller.UpdateAlias(Ambiente, CriarObjetoAlias());
      CarregarGridAlias();
      MessageBox.Show("Alias salvo com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void chkOracle_CheckedChanged(object sender, EventArgs e)
    {
      if (chkOracle.Checked)
      {
        chkMsSql.Checked = false;
      }
    }

    private void chkMsSql_CheckedChanged(object sender, EventArgs e)
    {
      if (chkMsSql.Checked)
      {
        chkOracle.Checked = false;
      }
    }
  }
}
