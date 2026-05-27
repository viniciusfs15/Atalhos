namespace Atalhos
{
  partial class AmbienteEditorForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      chkNCamadas = new MaterialSkin3.Controls.MaterialSwitch();
      txtPort = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel1 = new MaterialSkin3.Controls.MaterialLabel();
      materialLabel2 = new MaterialSkin3.Controls.MaterialLabel();
      txtHttpPort = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel3 = new MaterialSkin3.Controls.MaterialLabel();
      txtApiPort = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel4 = new MaterialSkin3.Controls.MaterialLabel();
      txtHost = new MaterialSkin3.Controls.MaterialTextBox2();
      chkEnableProcessIsolation = new MaterialSkin3.Controls.MaterialSwitch();
      materialCard1 = new MaterialSkin3.Controls.MaterialCard();
      btnNormalizePaths = new MaterialSkin3.Controls.MaterialButton();
      chkEnableCompression = new MaterialSkin3.Controls.MaterialSwitch();
      chkDefaultDb = new MaterialSkin3.Controls.MaterialSwitch();
      btnSalvar = new MaterialSkin3.Controls.MaterialButton();
      materialCard1.SuspendLayout();
      SuspendLayout();
      // 
      // chkNCamadas
      // 
      chkNCamadas.AutoSize = true;
      chkNCamadas.Depth = 0;
      chkNCamadas.Location = new Point(284, 51);
      chkNCamadas.Margin = new Padding(0);
      chkNCamadas.MouseLocation = new Point(-1, -1);
      chkNCamadas.MouseState = MaterialSkin3.MouseState.HOVER;
      chkNCamadas.Name = "chkNCamadas";
      chkNCamadas.Ripple = true;
      chkNCamadas.Size = new Size(220, 37);
      chkNCamadas.TabIndex = 6;
      chkNCamadas.Text = "Job Server 3 Camadas";
      chkNCamadas.UseVisualStyleBackColor = true;
      // 
      // txtPort
      // 
      txtPort.AnimateReadOnly = false;
      txtPort.AutoCompleteMode = AutoCompleteMode.None;
      txtPort.AutoCompleteSource = AutoCompleteSource.None;
      txtPort.BackgroundImageLayout = ImageLayout.None;
      txtPort.CharacterCasing = CharacterCasing.Normal;
      txtPort.Depth = 0;
      txtPort.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtPort.HideSelection = true;
      txtPort.Hint = "8050";
      txtPort.LeadingIcon = null;
      txtPort.Location = new Point(17, 101);
      txtPort.MaxLength = 32767;
      txtPort.MouseState = MaterialSkin3.MouseState.OUT;
      txtPort.Name = "txtPort";
      txtPort.PasswordChar = '\0';
      txtPort.PrefixSuffixText = null;
      txtPort.ReadOnly = false;
      txtPort.RightToLeft = RightToLeft.No;
      txtPort.SelectedText = "";
      txtPort.SelectionLength = 0;
      txtPort.SelectionStart = 0;
      txtPort.ShortcutsEnabled = true;
      txtPort.Size = new Size(81, 36);
      txtPort.TabIndex = 2;
      txtPort.TabStop = false;
      txtPort.TextAlign = HorizontalAlignment.Left;
      txtPort.TrailingIcon = null;
      txtPort.UseAccent = false;
      txtPort.UseSystemPasswordChar = false;
      txtPort.UseTallSize = false;
      // 
      // materialLabel1
      // 
      materialLabel1.AutoSize = true;
      materialLabel1.Depth = 0;
      materialLabel1.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel1.Location = new Point(17, 77);
      materialLabel1.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel1.Name = "materialLabel1";
      materialLabel1.Size = new Size(32, 21);
      materialLabel1.TabIndex = 2;
      materialLabel1.Text = "Port";
      // 
      // materialLabel2
      // 
      materialLabel2.AutoSize = true;
      materialLabel2.Depth = 0;
      materialLabel2.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel2.Location = new Point(104, 77);
      materialLabel2.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel2.Name = "materialLabel2";
      materialLabel2.Size = new Size(66, 21);
      materialLabel2.TabIndex = 4;
      materialLabel2.Text = "HttpPort";
      // 
      // txtHttpPort
      // 
      txtHttpPort.AnimateReadOnly = false;
      txtHttpPort.AutoCompleteMode = AutoCompleteMode.None;
      txtHttpPort.AutoCompleteSource = AutoCompleteSource.None;
      txtHttpPort.BackgroundImageLayout = ImageLayout.None;
      txtHttpPort.CharacterCasing = CharacterCasing.Normal;
      txtHttpPort.Depth = 0;
      txtHttpPort.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtHttpPort.HideSelection = true;
      txtHttpPort.Hint = "8051";
      txtHttpPort.LeadingIcon = null;
      txtHttpPort.Location = new Point(104, 101);
      txtHttpPort.MaxLength = 32767;
      txtHttpPort.MouseState = MaterialSkin3.MouseState.OUT;
      txtHttpPort.Name = "txtHttpPort";
      txtHttpPort.PasswordChar = '\0';
      txtHttpPort.PrefixSuffixText = null;
      txtHttpPort.ReadOnly = false;
      txtHttpPort.RightToLeft = RightToLeft.No;
      txtHttpPort.SelectedText = "";
      txtHttpPort.SelectionLength = 0;
      txtHttpPort.SelectionStart = 0;
      txtHttpPort.ShortcutsEnabled = true;
      txtHttpPort.Size = new Size(81, 36);
      txtHttpPort.TabIndex = 3;
      txtHttpPort.TabStop = false;
      txtHttpPort.TextAlign = HorizontalAlignment.Left;
      txtHttpPort.TrailingIcon = null;
      txtHttpPort.UseAccent = false;
      txtHttpPort.UseSystemPasswordChar = false;
      txtHttpPort.UseTallSize = false;
      // 
      // materialLabel3
      // 
      materialLabel3.AutoSize = true;
      materialLabel3.Depth = 0;
      materialLabel3.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel3.Location = new Point(191, 77);
      materialLabel3.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel3.Name = "materialLabel3";
      materialLabel3.Size = new Size(57, 21);
      materialLabel3.TabIndex = 6;
      materialLabel3.Text = "ApiPort";
      // 
      // txtApiPort
      // 
      txtApiPort.AnimateReadOnly = false;
      txtApiPort.AutoCompleteMode = AutoCompleteMode.None;
      txtApiPort.AutoCompleteSource = AutoCompleteSource.None;
      txtApiPort.BackgroundImageLayout = ImageLayout.None;
      txtApiPort.CharacterCasing = CharacterCasing.Normal;
      txtApiPort.Depth = 0;
      txtApiPort.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtApiPort.HideSelection = true;
      txtApiPort.Hint = "8052";
      txtApiPort.LeadingIcon = null;
      txtApiPort.Location = new Point(191, 101);
      txtApiPort.MaxLength = 32767;
      txtApiPort.MouseState = MaterialSkin3.MouseState.OUT;
      txtApiPort.Name = "txtApiPort";
      txtApiPort.PasswordChar = '\0';
      txtApiPort.PrefixSuffixText = null;
      txtApiPort.ReadOnly = false;
      txtApiPort.RightToLeft = RightToLeft.No;
      txtApiPort.SelectedText = "";
      txtApiPort.SelectionLength = 0;
      txtApiPort.SelectionStart = 0;
      txtApiPort.ShortcutsEnabled = true;
      txtApiPort.Size = new Size(81, 36);
      txtApiPort.TabIndex = 4;
      txtApiPort.TabStop = false;
      txtApiPort.TextAlign = HorizontalAlignment.Left;
      txtApiPort.TrailingIcon = null;
      txtApiPort.UseAccent = false;
      txtApiPort.UseSystemPasswordChar = false;
      txtApiPort.UseTallSize = false;
      // 
      // materialLabel4
      // 
      materialLabel4.AutoSize = true;
      materialLabel4.Depth = 0;
      materialLabel4.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel4.Location = new Point(17, 14);
      materialLabel4.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel4.Name = "materialLabel4";
      materialLabel4.Size = new Size(35, 21);
      materialLabel4.TabIndex = 8;
      materialLabel4.Text = "Host";
      // 
      // txtHost
      // 
      txtHost.AnimateReadOnly = false;
      txtHost.AutoCompleteMode = AutoCompleteMode.None;
      txtHost.AutoCompleteSource = AutoCompleteSource.None;
      txtHost.BackgroundImageLayout = ImageLayout.None;
      txtHost.CharacterCasing = CharacterCasing.Normal;
      txtHost.Depth = 0;
      txtHost.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtHost.HideSelection = true;
      txtHost.Hint = "localhost";
      txtHost.LeadingIcon = null;
      txtHost.Location = new Point(17, 38);
      txtHost.MaxLength = 32767;
      txtHost.MouseState = MaterialSkin3.MouseState.OUT;
      txtHost.Name = "txtHost";
      txtHost.PasswordChar = '\0';
      txtHost.PrefixSuffixText = null;
      txtHost.ReadOnly = false;
      txtHost.RightToLeft = RightToLeft.No;
      txtHost.SelectedText = "";
      txtHost.SelectionLength = 0;
      txtHost.SelectionStart = 0;
      txtHost.ShortcutsEnabled = true;
      txtHost.Size = new Size(255, 36);
      txtHost.TabIndex = 1;
      txtHost.TabStop = false;
      txtHost.TextAlign = HorizontalAlignment.Left;
      txtHost.TrailingIcon = null;
      txtHost.UseAccent = false;
      txtHost.UseSystemPasswordChar = false;
      txtHost.UseTallSize = false;
      // 
      // chkEnableProcessIsolation
      // 
      chkEnableProcessIsolation.AutoSize = true;
      chkEnableProcessIsolation.Depth = 0;
      chkEnableProcessIsolation.Location = new Point(284, 88);
      chkEnableProcessIsolation.Margin = new Padding(0);
      chkEnableProcessIsolation.MouseLocation = new Point(-1, -1);
      chkEnableProcessIsolation.MouseState = MaterialSkin3.MouseState.HOVER;
      chkEnableProcessIsolation.Name = "chkEnableProcessIsolation";
      chkEnableProcessIsolation.Ripple = true;
      chkEnableProcessIsolation.Size = new Size(203, 37);
      chkEnableProcessIsolation.TabIndex = 7;
      chkEnableProcessIsolation.Text = "Desativa JobRunner";
      chkEnableProcessIsolation.UseVisualStyleBackColor = true;
      // 
      // materialCard1
      // 
      materialCard1.BackColor = Color.FromArgb(255, 255, 255);
      materialCard1.Controls.Add(btnNormalizePaths);
      materialCard1.Controls.Add(chkEnableCompression);
      materialCard1.Controls.Add(chkDefaultDb);
      materialCard1.Controls.Add(btnSalvar);
      materialCard1.Controls.Add(materialLabel4);
      materialCard1.Controls.Add(chkNCamadas);
      materialCard1.Controls.Add(chkEnableProcessIsolation);
      materialCard1.Controls.Add(txtPort);
      materialCard1.Controls.Add(materialLabel1);
      materialCard1.Controls.Add(txtHost);
      materialCard1.Controls.Add(txtHttpPort);
      materialCard1.Controls.Add(materialLabel3);
      materialCard1.Controls.Add(materialLabel2);
      materialCard1.Controls.Add(txtApiPort);
      materialCard1.Depth = 0;
      materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
      materialCard1.Location = new Point(17, 78);
      materialCard1.Margin = new Padding(14);
      materialCard1.MouseState = MaterialSkin3.MouseState.HOVER;
      materialCard1.Name = "materialCard1";
      materialCard1.Padding = new Padding(14);
      materialCard1.Size = new Size(607, 232);
      materialCard1.TabIndex = 11;
      // 
      // btnNormalizePaths
      // 
      btnNormalizePaths.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnNormalizePaths.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnNormalizePaths.Depth = 0;
      btnNormalizePaths.Enabled = false;
      btnNormalizePaths.HighEmphasis = false;
      btnNormalizePaths.Icon = Properties.Resources.Settings;
      btnNormalizePaths.Location = new Point(17, 176);
      btnNormalizePaths.Margin = new Padding(4, 6, 4, 6);
      btnNormalizePaths.MouseState = MaterialSkin3.MouseState.HOVER;
      btnNormalizePaths.Name = "btnNormalizePaths";
      btnNormalizePaths.NoAccentTextColor = Color.Empty;
      btnNormalizePaths.Size = new Size(331, 36);
      btnNormalizePaths.TabIndex = 9;
      btnNormalizePaths.Text = "Normalizar Caminhos dos Configs";
      btnNormalizePaths.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Outlined;
      btnNormalizePaths.UseAccentColor = false;
      btnNormalizePaths.UseVisualStyleBackColor = true;
      btnNormalizePaths.Click += btnNormalizePath_Click;
      // 
      // chkEnableCompression
      // 
      chkEnableCompression.AutoSize = true;
      chkEnableCompression.Depth = 0;
      chkEnableCompression.Location = new Point(284, 14);
      chkEnableCompression.Margin = new Padding(0);
      chkEnableCompression.MouseLocation = new Point(-1, -1);
      chkEnableCompression.MouseState = MaterialSkin3.MouseState.HOVER;
      chkEnableCompression.Name = "chkEnableCompression";
      chkEnableCompression.Ripple = true;
      chkEnableCompression.Size = new Size(203, 37);
      chkEnableCompression.TabIndex = 5;
      chkEnableCompression.Text = "EnableCompression";
      chkEnableCompression.UseVisualStyleBackColor = true;
      // 
      // chkDefaultDb
      // 
      chkDefaultDb.AutoSize = true;
      chkDefaultDb.Depth = 0;
      chkDefaultDb.Location = new Point(284, 125);
      chkDefaultDb.Margin = new Padding(0);
      chkDefaultDb.MouseLocation = new Point(-1, -1);
      chkDefaultDb.MouseState = MaterialSkin3.MouseState.HOVER;
      chkDefaultDb.Name = "chkDefaultDb";
      chkDefaultDb.Ripple = true;
      chkDefaultDb.Size = new Size(133, 37);
      chkDefaultDb.TabIndex = 8;
      chkDefaultDb.Text = "DefaultDB";
      chkDefaultDb.UseVisualStyleBackColor = true;
      // 
      // btnSalvar
      // 
      btnSalvar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnSalvar.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnSalvar.Depth = 0;
      btnSalvar.HighEmphasis = true;
      btnSalvar.Icon = null;
      btnSalvar.Location = new Point(510, 176);
      btnSalvar.Margin = new Padding(4, 6, 4, 6);
      btnSalvar.MouseState = MaterialSkin3.MouseState.HOVER;
      btnSalvar.Name = "btnSalvar";
      btnSalvar.NoAccentTextColor = Color.Empty;
      btnSalvar.Size = new Size(79, 36);
      btnSalvar.TabIndex = 10;
      btnSalvar.Text = "Salvar";
      btnSalvar.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnSalvar.UseAccentColor = false;
      btnSalvar.UseVisualStyleBackColor = true;
      btnSalvar.Click += btnSalvar_Click;
      // 
      // AmbienteEditorForm
      // 
      AutoScaleDimensions = new SizeF(96F, 96F);
      AutoScaleMode = AutoScaleMode.Dpi;
      BackColor = SystemColors.Desktop;
      ClientSize = new Size(642, 327);
      Controls.Add(materialCard1);
      MaximizeBox = false;
      Name = "AmbienteEditorForm";
      Sizable = false;
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Editor de Ambiente";
      Load += AmbienteEditorForm_Load;
      materialCard1.ResumeLayout(false);
      materialCard1.PerformLayout();
      ResumeLayout(false);
    }

    #endregion

    private MaterialSkin3.Controls.MaterialSwitch chkNCamadas;
    private MaterialSkin3.Controls.MaterialTextBox2 txtPort;
    private MaterialSkin3.Controls.MaterialLabel materialLabel1;
    private MaterialSkin3.Controls.MaterialLabel materialLabel2;
    private MaterialSkin3.Controls.MaterialTextBox2 txtHttpPort;
    private MaterialSkin3.Controls.MaterialLabel materialLabel3;
    private MaterialSkin3.Controls.MaterialTextBox2 txtApiPort;
    private MaterialSkin3.Controls.MaterialLabel materialLabel4;
    private MaterialSkin3.Controls.MaterialTextBox2 txtHost;
    private MaterialSkin3.Controls.MaterialSwitch chkEnableProcessIsolation;
    private MaterialSkin3.Controls.MaterialCard materialCard1;
    private MaterialSkin3.Controls.MaterialButton btnSalvar;
    private MaterialSkin3.Controls.MaterialSwitch chkDefaultDb;
    private MaterialSkin3.Controls.MaterialSwitch chkEnableCompression;
    private MaterialSkin3.Controls.MaterialButton btnNormalizePaths;
  }
}