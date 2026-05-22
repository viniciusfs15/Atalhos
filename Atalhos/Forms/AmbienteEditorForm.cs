using Atalhos.Controller;
using Atalhos.DTO;
using MaterialSkin3;
using MaterialSkin3.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Atalhos
{
  public partial class AmbienteEditorForm : MaterialForm
  {
    private AmbienteConfigController _ambienteConfigController { get; set; } = new AmbienteConfigController();

    public AmbienteDTO _ambiente { get; internal set; }

    public AmbienteEditorForm()
    {
      InitializeComponent();
      InitializeMaterialSkin.Excute(this);
    }

    private void DefineSize()
    {
      Size = new Size(642, 344);
    }

    public static async void MouseFeedBack()
    {
      Cursor.Current = Cursors.WaitCursor;
      await Task.Delay(1000);
      Cursor.Current = Cursors.Default;
    }

    private void AmbienteEditorForm_Load(object sender, EventArgs e)
    {
      this.Text = $"Ambiente: {_ambiente?.Nome}";

      GetConfigs();
      DefineSize();
    }

    private void GetConfigs()
    {
      var ambienteConfig = _ambienteConfigController.GetAmbiente(_ambiente.Id);
      if (ambienteConfig == null) return;

      txtHost.Text = ambienteConfig.Host;
      txtPort.Text = ambienteConfig.Port?.ToString();
      txtHttpPort.Text = ambienteConfig.HttpPort == -1 ? string.Empty : ambienteConfig.HttpPort.ToString();
      txtApiPort.Text = ambienteConfig.ApiPort == -1 ? string.Empty : ambienteConfig.ApiPort.ToString();
      chkNCamadas.Checked = ambienteConfig.JobServer3Camadas ?? false;
      chkDefaultDb.Checked = ambienteConfig.DefaultDB ?? false;
      chkEnableProcessIsolation.Checked = ambienteConfig.EnableProcessIsolation ?? false;
      chkEnableCompression.Checked = ambienteConfig.EnableCompression ?? false;

      btnNormalizePaths.Enabled = ambienteConfig.NormalizePath ?? false;
    }

    private void Save()
    {
      AmbienteConfigDTO ambienteConfig = GetAmbienteConfigDTO();
      _ambienteConfigController.SaveAmbienteConfig(ambienteConfig);
    }

    private AmbienteConfigDTO GetAmbienteConfigDTO()
    {
      return new AmbienteConfigDTO()
      {
        AmbienteId = _ambiente.Id,
        Host = txtHost.Text,
        Port = int.TryParse(txtPort.Text, out int port) ? port : (int?)null,
        HttpPort = int.TryParse(txtHttpPort.Text, out int httpPort) ? httpPort : (int?)null,
        ApiPort = int.TryParse(txtApiPort.Text, out int apiPort) ? apiPort : (int?)null,
        JobServer3Camadas = chkNCamadas.Checked,
        DefaultDB = chkDefaultDb.Checked,
        EnableProcessIsolation = chkEnableProcessIsolation.Checked,
        EnableCompression = chkEnableCompression.Checked
      };
    }

    private void btnSalvar_Click(object sender, EventArgs e)
    {
      Save();
      MessageBox.Show("Configurações salvas com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
      MouseFeedBack();
    }

    private void btnNormalizePath_Click(object sender, EventArgs e)
    {
      _ambienteConfigController.NormalizeAmbientePath(GetAmbienteConfigDTO());
      MessageBox.Show("Caminhos normalizados com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
      GetConfigs();
    }
  }
}
