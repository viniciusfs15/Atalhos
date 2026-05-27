namespace Atalhos
{
    partial class AliasEditorForm
  {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AliasEditorForm));
      contextMenuStrip1 = new ContextMenuStrip(components);
      lstAliases = new MaterialSkin3.Controls.MaterialListView();
      columnHeader1 = new ColumnHeader();
      materialCard1 = new MaterialSkin3.Controls.MaterialCard();
      flowLayoutPanel1 = new FlowLayoutPanel();
      btnNovo = new MaterialSkin3.Controls.MaterialButton();
      btnExcluir = new MaterialSkin3.Controls.MaterialButton();
      materialCard2 = new MaterialSkin3.Controls.MaterialCard();
      chkMsSql = new MaterialSkin3.Controls.MaterialSwitch();
      txtNomeAlias = new MaterialSkin3.Controls.MaterialTextBox2();
      chkOracle = new MaterialSkin3.Controls.MaterialSwitch();
      materialCard3 = new MaterialSkin3.Controls.MaterialCard();
      chkHabilitaPoolProcessos = new MaterialSkin3.Controls.MaterialSwitch();
      chkJobsLocais = new MaterialSkin3.Controls.MaterialSwitch();
      chkHabilitaProcessJobs = new MaterialSkin3.Controls.MaterialSwitch();
      chkRunService = new MaterialSkin3.Controls.MaterialSwitch();
      materialLabel3 = new MaterialSkin3.Controls.MaterialLabel();
      txtExecSimultanea = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel10 = new MaterialSkin3.Controls.MaterialLabel();
      btnSalvar = new MaterialSkin3.Controls.MaterialButton();
      txtUsuarioRM = new MaterialSkin3.Controls.MaterialTextBox2();
      txtServidor = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel9 = new MaterialSkin3.Controls.MaterialLabel();
      materialLabel8 = new MaterialSkin3.Controls.MaterialLabel();
      txtUsuarioBd = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel7 = new MaterialSkin3.Controls.MaterialLabel();
      txtBase = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel5 = new MaterialSkin3.Controls.MaterialLabel();
      txtSenhaBd = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel4 = new MaterialSkin3.Controls.MaterialLabel();
      txtSenhaRm = new MaterialSkin3.Controls.MaterialTextBox2();
      materialLabel2 = new MaterialSkin3.Controls.MaterialLabel();
      materialLabel6 = new MaterialSkin3.Controls.MaterialLabel();
      materialCard1.SuspendLayout();
      flowLayoutPanel1.SuspendLayout();
      materialCard2.SuspendLayout();
      materialCard3.SuspendLayout();
      SuspendLayout();
      // 
      // contextMenuStrip1
      // 
      contextMenuStrip1.Name = "contextMenuStrip1";
      contextMenuStrip1.Size = new Size(61, 4);
      // 
      // lstAliases
      // 
      lstAliases.AutoSizeTable = false;
      lstAliases.BackColor = Color.FromArgb(255, 255, 255);
      lstAliases.BorderStyle = BorderStyle.None;
      lstAliases.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
      lstAliases.Depth = 0;
      lstAliases.FullRowSelect = true;
      lstAliases.Location = new Point(0, 0);
      lstAliases.MinimumSize = new Size(200, 100);
      lstAliases.MouseLocation = new Point(-1, -1);
      lstAliases.MouseState = MaterialSkin3.MouseState.OUT;
      lstAliases.MultiSelect = false;
      lstAliases.Name = "lstAliases";
      lstAliases.OwnerDraw = true;
      lstAliases.Size = new Size(229, 449);
      lstAliases.TabIndex = 41;
      lstAliases.UseCompatibleStateImageBehavior = false;
      lstAliases.View = View.Details;
      lstAliases.ItemSelectionChanged += lstAliases_ItemSelectionChanged;
      // 
      // columnHeader1
      // 
      columnHeader1.Text = "Aliases Cadastrados";
      columnHeader1.Width = 229;
      // 
      // materialCard1
      // 
      materialCard1.BackColor = Color.FromArgb(255, 255, 255);
      materialCard1.Controls.Add(lstAliases);
      materialCard1.Controls.Add(flowLayoutPanel1);
      materialCard1.Depth = 0;
      materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
      materialCard1.Location = new Point(17, 78);
      materialCard1.Margin = new Padding(14);
      materialCard1.MouseState = MaterialSkin3.MouseState.HOVER;
      materialCard1.Name = "materialCard1";
      materialCard1.Padding = new Padding(14);
      materialCard1.Size = new Size(229, 506);
      materialCard1.TabIndex = 43;
      // 
      // flowLayoutPanel1
      // 
      flowLayoutPanel1.Controls.Add(btnNovo);
      flowLayoutPanel1.Controls.Add(btnExcluir);
      flowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
      flowLayoutPanel1.Location = new Point(0, 455);
      flowLayoutPanel1.Margin = new Padding(5);
      flowLayoutPanel1.Name = "flowLayoutPanel1";
      flowLayoutPanel1.Padding = new Padding(0, 0, 5, 0);
      flowLayoutPanel1.Size = new Size(229, 49);
      flowLayoutPanel1.TabIndex = 44;
      // 
      // btnNovo
      // 
      btnNovo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnNovo.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnNovo.Depth = 0;
      btnNovo.HighEmphasis = true;
      btnNovo.Icon = null;
      btnNovo.Location = new Point(155, 6);
      btnNovo.Margin = new Padding(4, 6, 4, 6);
      btnNovo.MouseState = MaterialSkin3.MouseState.HOVER;
      btnNovo.Name = "btnNovo";
      btnNovo.NoAccentTextColor = Color.Empty;
      btnNovo.Size = new Size(65, 36);
      btnNovo.TabIndex = 43;
      btnNovo.Text = "NOVO";
      btnNovo.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnNovo.UseAccentColor = false;
      btnNovo.UseVisualStyleBackColor = true;
      btnNovo.Click += btnNovo_Click;
      // 
      // btnExcluir
      // 
      btnExcluir.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnExcluir.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnExcluir.Depth = 0;
      btnExcluir.HighEmphasis = false;
      btnExcluir.Icon = null;
      btnExcluir.Location = new Point(63, 6);
      btnExcluir.Margin = new Padding(4, 6, 4, 6);
      btnExcluir.MouseState = MaterialSkin3.MouseState.HOVER;
      btnExcluir.Name = "btnExcluir";
      btnExcluir.NoAccentTextColor = Color.Empty;
      btnExcluir.Size = new Size(84, 36);
      btnExcluir.TabIndex = 44;
      btnExcluir.Text = "Excluir";
      btnExcluir.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnExcluir.UseAccentColor = false;
      btnExcluir.UseVisualStyleBackColor = true;
      btnExcluir.Click += btnExcluir_Click;
      // 
      // materialCard2
      // 
      materialCard2.BackColor = Color.FromArgb(255, 255, 255);
      materialCard2.Controls.Add(chkMsSql);
      materialCard2.Controls.Add(txtNomeAlias);
      materialCard2.Controls.Add(chkOracle);
      materialCard2.Controls.Add(materialCard3);
      materialCard2.Controls.Add(materialLabel10);
      materialCard2.Controls.Add(btnSalvar);
      materialCard2.Controls.Add(txtUsuarioRM);
      materialCard2.Controls.Add(txtServidor);
      materialCard2.Controls.Add(materialLabel9);
      materialCard2.Controls.Add(materialLabel8);
      materialCard2.Controls.Add(txtUsuarioBd);
      materialCard2.Controls.Add(materialLabel7);
      materialCard2.Controls.Add(txtBase);
      materialCard2.Controls.Add(materialLabel5);
      materialCard2.Controls.Add(txtSenhaBd);
      materialCard2.Controls.Add(materialLabel4);
      materialCard2.Controls.Add(txtSenhaRm);
      materialCard2.Controls.Add(materialLabel2);
      materialCard2.Controls.Add(materialLabel6);
      materialCard2.Depth = 0;
      materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
      materialCard2.Location = new Point(274, 78);
      materialCard2.Margin = new Padding(14);
      materialCard2.MouseState = MaterialSkin3.MouseState.HOVER;
      materialCard2.Name = "materialCard2";
      materialCard2.Padding = new Padding(14);
      materialCard2.Size = new Size(526, 506);
      materialCard2.TabIndex = 44;
      // 
      // chkMsSql
      // 
      chkMsSql.AutoSize = true;
      chkMsSql.Depth = 0;
      chkMsSql.Location = new Point(290, 33);
      chkMsSql.Margin = new Padding(0);
      chkMsSql.MouseLocation = new Point(-1, -1);
      chkMsSql.MouseState = MaterialSkin3.MouseState.HOVER;
      chkMsSql.Name = "chkMsSql";
      chkMsSql.Ripple = true;
      chkMsSql.Size = new Size(88, 37);
      chkMsSql.TabIndex = 17;
      chkMsSql.Text = "SQL";
      chkMsSql.UseVisualStyleBackColor = true;
      chkMsSql.CheckedChanged += chkMsSql_CheckedChanged;
      // 
      // txtNomeAlias
      // 
      txtNomeAlias.AnimateReadOnly = false;
      txtNomeAlias.AutoCompleteMode = AutoCompleteMode.None;
      txtNomeAlias.AutoCompleteSource = AutoCompleteSource.None;
      txtNomeAlias.BackgroundImageLayout = ImageLayout.None;
      txtNomeAlias.CharacterCasing = CharacterCasing.Normal;
      txtNomeAlias.Depth = 0;
      txtNomeAlias.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtNomeAlias.HideSelection = true;
      txtNomeAlias.Hint = "Base_local...";
      txtNomeAlias.LeadingIcon = null;
      txtNomeAlias.Location = new Point(17, 34);
      txtNomeAlias.MaxLength = 32767;
      txtNomeAlias.MouseState = MaterialSkin3.MouseState.OUT;
      txtNomeAlias.Name = "txtNomeAlias";
      txtNomeAlias.PasswordChar = '\0';
      txtNomeAlias.PrefixSuffixText = null;
      txtNomeAlias.ReadOnly = false;
      txtNomeAlias.RightToLeft = RightToLeft.No;
      txtNomeAlias.SelectedText = "";
      txtNomeAlias.SelectionLength = 0;
      txtNomeAlias.SelectionStart = 0;
      txtNomeAlias.ShortcutsEnabled = true;
      txtNomeAlias.Size = new Size(219, 36);
      txtNomeAlias.TabIndex = 46;
      txtNomeAlias.TabStop = false;
      txtNomeAlias.TextAlign = HorizontalAlignment.Left;
      txtNomeAlias.TrailingIcon = null;
      txtNomeAlias.UseAccent = false;
      txtNomeAlias.UseSystemPasswordChar = false;
      txtNomeAlias.UseTallSize = false;
      // 
      // chkOracle
      // 
      chkOracle.AutoSize = true;
      chkOracle.Depth = 0;
      chkOracle.Location = new Point(403, 33);
      chkOracle.Margin = new Padding(0);
      chkOracle.MouseLocation = new Point(-1, -1);
      chkOracle.MouseState = MaterialSkin3.MouseState.HOVER;
      chkOracle.Name = "chkOracle";
      chkOracle.Ripple = true;
      chkOracle.Size = new Size(106, 37);
      chkOracle.TabIndex = 16;
      chkOracle.Text = "Oracle";
      chkOracle.UseVisualStyleBackColor = true;
      chkOracle.CheckedChanged += chkOracle_CheckedChanged;
      // 
      // materialCard3
      // 
      materialCard3.BackColor = Color.FromArgb(255, 255, 255);
      materialCard3.Controls.Add(chkHabilitaPoolProcessos);
      materialCard3.Controls.Add(chkJobsLocais);
      materialCard3.Controls.Add(chkHabilitaProcessJobs);
      materialCard3.Controls.Add(chkRunService);
      materialCard3.Controls.Add(materialLabel3);
      materialCard3.Controls.Add(txtExecSimultanea);
      materialCard3.Depth = 0;
      materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
      materialCard3.Location = new Point(17, 280);
      materialCard3.Margin = new Padding(14);
      materialCard3.MouseState = MaterialSkin3.MouseState.HOVER;
      materialCard3.Name = "materialCard3";
      materialCard3.Padding = new Padding(14);
      materialCard3.Size = new Size(492, 169);
      materialCard3.TabIndex = 45;
      // 
      // chkHabilitaPoolProcessos
      // 
      chkHabilitaPoolProcessos.AutoSize = true;
      chkHabilitaPoolProcessos.Depth = 0;
      chkHabilitaPoolProcessos.Location = new Point(9, 120);
      chkHabilitaPoolProcessos.Margin = new Padding(0);
      chkHabilitaPoolProcessos.MouseLocation = new Point(-1, -1);
      chkHabilitaPoolProcessos.MouseState = MaterialSkin3.MouseState.HOVER;
      chkHabilitaPoolProcessos.Name = "chkHabilitaPoolProcessos";
      chkHabilitaPoolProcessos.Ripple = true;
      chkHabilitaPoolProcessos.Size = new Size(257, 37);
      chkHabilitaPoolProcessos.TabIndex = 49;
      chkHabilitaPoolProcessos.Text = "Habilitar pool de processos";
      chkHabilitaPoolProcessos.UseVisualStyleBackColor = true;
      // 
      // chkJobsLocais
      // 
      chkJobsLocais.AutoSize = true;
      chkJobsLocais.Depth = 0;
      chkJobsLocais.Location = new Point(9, 83);
      chkJobsLocais.Margin = new Padding(0);
      chkJobsLocais.MouseLocation = new Point(-1, -1);
      chkJobsLocais.MouseState = MaterialSkin3.MouseState.HOVER;
      chkJobsLocais.Name = "chkJobsLocais";
      chkJobsLocais.Ripple = true;
      chkJobsLocais.Size = new Size(262, 37);
      chkJobsLocais.TabIndex = 48;
      chkJobsLocais.Text = "Executar apenas Jobs locais";
      chkJobsLocais.UseVisualStyleBackColor = true;
      // 
      // chkHabilitaProcessJobs
      // 
      chkHabilitaProcessJobs.AutoSize = true;
      chkHabilitaProcessJobs.Depth = 0;
      chkHabilitaProcessJobs.Location = new Point(9, 44);
      chkHabilitaProcessJobs.Margin = new Padding(0);
      chkHabilitaProcessJobs.MouseLocation = new Point(-1, -1);
      chkHabilitaProcessJobs.MouseState = MaterialSkin3.MouseState.HOVER;
      chkHabilitaProcessJobs.Name = "chkHabilitaProcessJobs";
      chkHabilitaProcessJobs.Ripple = true;
      chkHabilitaProcessJobs.Size = new Size(298, 37);
      chkHabilitaProcessJobs.TabIndex = 47;
      chkHabilitaProcessJobs.Text = "Habilitar processamento de Jobs";
      chkHabilitaProcessJobs.UseVisualStyleBackColor = true;
      // 
      // chkRunService
      // 
      chkRunService.AutoSize = true;
      chkRunService.Checked = true;
      chkRunService.CheckState = CheckState.Checked;
      chkRunService.Depth = 0;
      chkRunService.Location = new Point(9, 7);
      chkRunService.Margin = new Padding(0);
      chkRunService.MouseLocation = new Point(-1, -1);
      chkRunService.MouseState = MaterialSkin3.MouseState.HOVER;
      chkRunService.Name = "chkRunService";
      chkRunService.Ripple = true;
      chkRunService.Size = new Size(139, 37);
      chkRunService.TabIndex = 46;
      chkRunService.Text = "RunService";
      chkRunService.UseVisualStyleBackColor = true;
      // 
      // materialLabel3
      // 
      materialLabel3.AutoSize = true;
      materialLabel3.Depth = 0;
      materialLabel3.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel3.Location = new Point(306, 14);
      materialLabel3.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel3.Name = "materialLabel3";
      materialLabel3.Size = new Size(169, 21);
      materialLabel3.TabIndex = 2;
      materialLabel3.Text = "Execuções simultâneas";
      // 
      // txtExecSimultanea
      // 
      txtExecSimultanea.AnimateReadOnly = false;
      txtExecSimultanea.AutoCompleteMode = AutoCompleteMode.None;
      txtExecSimultanea.AutoCompleteSource = AutoCompleteSource.None;
      txtExecSimultanea.BackgroundImageLayout = ImageLayout.None;
      txtExecSimultanea.CharacterCasing = CharacterCasing.Normal;
      txtExecSimultanea.Depth = 0;
      txtExecSimultanea.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtExecSimultanea.HideSelection = true;
      txtExecSimultanea.Hint = "0";
      txtExecSimultanea.LeadingIcon = null;
      txtExecSimultanea.Location = new Point(401, 45);
      txtExecSimultanea.MaxLength = 32767;
      txtExecSimultanea.MouseState = MaterialSkin3.MouseState.OUT;
      txtExecSimultanea.Name = "txtExecSimultanea";
      txtExecSimultanea.PasswordChar = '\0';
      txtExecSimultanea.PrefixSuffixText = null;
      txtExecSimultanea.ReadOnly = false;
      txtExecSimultanea.RightToLeft = RightToLeft.No;
      txtExecSimultanea.SelectedText = "";
      txtExecSimultanea.SelectionLength = 0;
      txtExecSimultanea.SelectionStart = 0;
      txtExecSimultanea.ShortcutsEnabled = true;
      txtExecSimultanea.Size = new Size(74, 36);
      txtExecSimultanea.TabIndex = 3;
      txtExecSimultanea.TabStop = false;
      txtExecSimultanea.TextAlign = HorizontalAlignment.Left;
      txtExecSimultanea.TrailingIcon = null;
      txtExecSimultanea.UseAccent = false;
      txtExecSimultanea.UseSystemPasswordChar = false;
      txtExecSimultanea.UseTallSize = false;
      // 
      // materialLabel10
      // 
      materialLabel10.AutoSize = true;
      materialLabel10.Depth = 0;
      materialLabel10.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel10.Location = new Point(290, 14);
      materialLabel10.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel10.Name = "materialLabel10";
      materialLabel10.Size = new Size(95, 21);
      materialLabel10.TabIndex = 18;
      materialLabel10.Text = "Tipo da base";
      // 
      // btnSalvar
      // 
      btnSalvar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnSalvar.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnSalvar.Depth = 0;
      btnSalvar.HighEmphasis = true;
      btnSalvar.Icon = null;
      btnSalvar.Location = new Point(429, 461);
      btnSalvar.Margin = new Padding(4, 6, 4, 6);
      btnSalvar.MouseState = MaterialSkin3.MouseState.HOVER;
      btnSalvar.Name = "btnSalvar";
      btnSalvar.NoAccentTextColor = Color.Empty;
      btnSalvar.Size = new Size(79, 36);
      btnSalvar.TabIndex = 45;
      btnSalvar.Text = "Salvar";
      btnSalvar.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnSalvar.UseAccentColor = false;
      btnSalvar.UseVisualStyleBackColor = true;
      btnSalvar.Click += btnSalvar_Click;
      // 
      // txtUsuarioRM
      // 
      txtUsuarioRM.AnimateReadOnly = false;
      txtUsuarioRM.AutoCompleteMode = AutoCompleteMode.None;
      txtUsuarioRM.AutoCompleteSource = AutoCompleteSource.None;
      txtUsuarioRM.BackgroundImageLayout = ImageLayout.None;
      txtUsuarioRM.CharacterCasing = CharacterCasing.Normal;
      txtUsuarioRM.Depth = 0;
      txtUsuarioRM.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtUsuarioRM.HideSelection = true;
      txtUsuarioRM.Hint = "mestre";
      txtUsuarioRM.LeadingIcon = null;
      txtUsuarioRM.Location = new Point(17, 227);
      txtUsuarioRM.MaxLength = 32767;
      txtUsuarioRM.MouseState = MaterialSkin3.MouseState.OUT;
      txtUsuarioRM.Name = "txtUsuarioRM";
      txtUsuarioRM.PasswordChar = '\0';
      txtUsuarioRM.PrefixSuffixText = null;
      txtUsuarioRM.ReadOnly = false;
      txtUsuarioRM.RightToLeft = RightToLeft.No;
      txtUsuarioRM.SelectedText = "";
      txtUsuarioRM.SelectionLength = 0;
      txtUsuarioRM.SelectionStart = 0;
      txtUsuarioRM.ShortcutsEnabled = true;
      txtUsuarioRM.Size = new Size(219, 36);
      txtUsuarioRM.TabIndex = 15;
      txtUsuarioRM.TabStop = false;
      txtUsuarioRM.TextAlign = HorizontalAlignment.Left;
      txtUsuarioRM.TrailingIcon = null;
      txtUsuarioRM.UseAccent = false;
      txtUsuarioRM.UseSystemPasswordChar = false;
      txtUsuarioRM.UseTallSize = false;
      // 
      // txtServidor
      // 
      txtServidor.AnimateReadOnly = false;
      txtServidor.AutoCompleteMode = AutoCompleteMode.None;
      txtServidor.AutoCompleteSource = AutoCompleteSource.None;
      txtServidor.BackgroundImageLayout = ImageLayout.None;
      txtServidor.CharacterCasing = CharacterCasing.Normal;
      txtServidor.Depth = 0;
      txtServidor.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtServidor.HideSelection = true;
      txtServidor.Hint = "bh-eng-01...";
      txtServidor.LeadingIcon = null;
      txtServidor.Location = new Point(17, 101);
      txtServidor.MaxLength = 32767;
      txtServidor.MouseState = MaterialSkin3.MouseState.OUT;
      txtServidor.Name = "txtServidor";
      txtServidor.PasswordChar = '\0';
      txtServidor.PrefixSuffixText = null;
      txtServidor.ReadOnly = false;
      txtServidor.RightToLeft = RightToLeft.No;
      txtServidor.SelectedText = "";
      txtServidor.SelectionLength = 0;
      txtServidor.SelectionStart = 0;
      txtServidor.ShortcutsEnabled = true;
      txtServidor.Size = new Size(219, 36);
      txtServidor.TabIndex = 13;
      txtServidor.TabStop = false;
      txtServidor.TextAlign = HorizontalAlignment.Left;
      txtServidor.TrailingIcon = null;
      txtServidor.UseAccent = false;
      txtServidor.UseSystemPasswordChar = false;
      txtServidor.UseTallSize = false;
      // 
      // materialLabel9
      // 
      materialLabel9.AutoSize = true;
      materialLabel9.Depth = 0;
      materialLabel9.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel9.Location = new Point(17, 203);
      materialLabel9.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel9.Name = "materialLabel9";
      materialLabel9.Size = new Size(85, 21);
      materialLabel9.TabIndex = 14;
      materialLabel9.Text = "Usuário RM";
      // 
      // materialLabel8
      // 
      materialLabel8.AutoSize = true;
      materialLabel8.Depth = 0;
      materialLabel8.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel8.Location = new Point(17, 77);
      materialLabel8.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel8.Name = "materialLabel8";
      materialLabel8.Size = new Size(62, 21);
      materialLabel8.TabIndex = 12;
      materialLabel8.Text = "Servidor";
      // 
      // txtUsuarioBd
      // 
      txtUsuarioBd.AnimateReadOnly = false;
      txtUsuarioBd.AutoCompleteMode = AutoCompleteMode.None;
      txtUsuarioBd.AutoCompleteSource = AutoCompleteSource.None;
      txtUsuarioBd.BackgroundImageLayout = ImageLayout.None;
      txtUsuarioBd.CharacterCasing = CharacterCasing.Normal;
      txtUsuarioBd.Depth = 0;
      txtUsuarioBd.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtUsuarioBd.HideSelection = true;
      txtUsuarioBd.Hint = "sysdba";
      txtUsuarioBd.LeadingIcon = null;
      txtUsuarioBd.Location = new Point(17, 164);
      txtUsuarioBd.MaxLength = 32767;
      txtUsuarioBd.MouseState = MaterialSkin3.MouseState.OUT;
      txtUsuarioBd.Name = "txtUsuarioBd";
      txtUsuarioBd.PasswordChar = '\0';
      txtUsuarioBd.PrefixSuffixText = null;
      txtUsuarioBd.ReadOnly = false;
      txtUsuarioBd.RightToLeft = RightToLeft.No;
      txtUsuarioBd.SelectedText = "";
      txtUsuarioBd.SelectionLength = 0;
      txtUsuarioBd.SelectionStart = 0;
      txtUsuarioBd.ShortcutsEnabled = true;
      txtUsuarioBd.Size = new Size(219, 36);
      txtUsuarioBd.TabIndex = 11;
      txtUsuarioBd.TabStop = false;
      txtUsuarioBd.TextAlign = HorizontalAlignment.Left;
      txtUsuarioBd.TrailingIcon = null;
      txtUsuarioBd.UseAccent = false;
      txtUsuarioBd.UseSystemPasswordChar = false;
      txtUsuarioBd.UseTallSize = false;
      // 
      // materialLabel7
      // 
      materialLabel7.AutoSize = true;
      materialLabel7.Depth = 0;
      materialLabel7.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel7.Location = new Point(17, 140);
      materialLabel7.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel7.Name = "materialLabel7";
      materialLabel7.Size = new Size(82, 21);
      materialLabel7.TabIndex = 10;
      materialLabel7.Text = "Usuário BD";
      // 
      // txtBase
      // 
      txtBase.AnimateReadOnly = false;
      txtBase.AutoCompleteMode = AutoCompleteMode.None;
      txtBase.AutoCompleteSource = AutoCompleteSource.None;
      txtBase.BackgroundImageLayout = ImageLayout.None;
      txtBase.CharacterCasing = CharacterCasing.Normal;
      txtBase.Depth = 0;
      txtBase.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtBase.HideSelection = true;
      txtBase.Hint = "CorporeRM_121...";
      txtBase.LeadingIcon = null;
      txtBase.Location = new Point(290, 101);
      txtBase.MaxLength = 32767;
      txtBase.MouseState = MaterialSkin3.MouseState.OUT;
      txtBase.Name = "txtBase";
      txtBase.PasswordChar = '\0';
      txtBase.PrefixSuffixText = null;
      txtBase.ReadOnly = false;
      txtBase.RightToLeft = RightToLeft.No;
      txtBase.SelectedText = "";
      txtBase.SelectionLength = 0;
      txtBase.SelectionStart = 0;
      txtBase.ShortcutsEnabled = true;
      txtBase.Size = new Size(219, 36);
      txtBase.TabIndex = 7;
      txtBase.TabStop = false;
      txtBase.TextAlign = HorizontalAlignment.Left;
      txtBase.TrailingIcon = null;
      txtBase.UseAccent = false;
      txtBase.UseSystemPasswordChar = false;
      txtBase.UseTallSize = false;
      // 
      // materialLabel5
      // 
      materialLabel5.AutoSize = true;
      materialLabel5.Depth = 0;
      materialLabel5.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel5.Location = new Point(290, 77);
      materialLabel5.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel5.Name = "materialLabel5";
      materialLabel5.Size = new Size(36, 21);
      materialLabel5.TabIndex = 6;
      materialLabel5.Text = "Base";
      // 
      // txtSenhaBd
      // 
      txtSenhaBd.AnimateReadOnly = false;
      txtSenhaBd.AutoCompleteMode = AutoCompleteMode.None;
      txtSenhaBd.AutoCompleteSource = AutoCompleteSource.None;
      txtSenhaBd.BackgroundImageLayout = ImageLayout.None;
      txtSenhaBd.CharacterCasing = CharacterCasing.Normal;
      txtSenhaBd.Depth = 0;
      txtSenhaBd.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtSenhaBd.HideSelection = true;
      txtSenhaBd.Hint = "masterkey";
      txtSenhaBd.LeadingIcon = null;
      txtSenhaBd.Location = new Point(290, 164);
      txtSenhaBd.MaxLength = 32767;
      txtSenhaBd.MouseState = MaterialSkin3.MouseState.OUT;
      txtSenhaBd.Name = "txtSenhaBd";
      txtSenhaBd.PasswordChar = '\0';
      txtSenhaBd.PrefixSuffixText = null;
      txtSenhaBd.ReadOnly = false;
      txtSenhaBd.RightToLeft = RightToLeft.No;
      txtSenhaBd.SelectedText = "";
      txtSenhaBd.SelectionLength = 0;
      txtSenhaBd.SelectionStart = 0;
      txtSenhaBd.ShortcutsEnabled = true;
      txtSenhaBd.Size = new Size(219, 36);
      txtSenhaBd.TabIndex = 5;
      txtSenhaBd.TabStop = false;
      txtSenhaBd.TextAlign = HorizontalAlignment.Left;
      txtSenhaBd.TrailingIcon = null;
      txtSenhaBd.UseAccent = false;
      txtSenhaBd.UseSystemPasswordChar = false;
      txtSenhaBd.UseTallSize = false;
      // 
      // materialLabel4
      // 
      materialLabel4.AutoSize = true;
      materialLabel4.Depth = 0;
      materialLabel4.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel4.Location = new Point(290, 140);
      materialLabel4.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel4.Name = "materialLabel4";
      materialLabel4.Size = new Size(71, 21);
      materialLabel4.TabIndex = 4;
      materialLabel4.Text = "Senha BD";
      // 
      // txtSenhaRm
      // 
      txtSenhaRm.AnimateReadOnly = false;
      txtSenhaRm.AutoCompleteMode = AutoCompleteMode.None;
      txtSenhaRm.AutoCompleteSource = AutoCompleteSource.None;
      txtSenhaRm.BackgroundImageLayout = ImageLayout.None;
      txtSenhaRm.CharacterCasing = CharacterCasing.Normal;
      txtSenhaRm.Depth = 0;
      txtSenhaRm.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
      txtSenhaRm.HideSelection = true;
      txtSenhaRm.Hint = "totvs";
      txtSenhaRm.LeadingIcon = null;
      txtSenhaRm.Location = new Point(290, 229);
      txtSenhaRm.MaxLength = 32767;
      txtSenhaRm.MouseState = MaterialSkin3.MouseState.OUT;
      txtSenhaRm.Name = "txtSenhaRm";
      txtSenhaRm.PasswordChar = '\0';
      txtSenhaRm.PrefixSuffixText = null;
      txtSenhaRm.ReadOnly = false;
      txtSenhaRm.RightToLeft = RightToLeft.No;
      txtSenhaRm.SelectedText = "";
      txtSenhaRm.SelectionLength = 0;
      txtSenhaRm.SelectionStart = 0;
      txtSenhaRm.ShortcutsEnabled = true;
      txtSenhaRm.Size = new Size(219, 36);
      txtSenhaRm.TabIndex = 9;
      txtSenhaRm.TabStop = false;
      txtSenhaRm.TextAlign = HorizontalAlignment.Left;
      txtSenhaRm.TrailingIcon = null;
      txtSenhaRm.UseAccent = false;
      txtSenhaRm.UseSystemPasswordChar = false;
      txtSenhaRm.UseTallSize = false;
      // 
      // materialLabel2
      // 
      materialLabel2.AutoSize = true;
      materialLabel2.Depth = 0;
      materialLabel2.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel2.Location = new Point(17, 14);
      materialLabel2.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel2.Name = "materialLabel2";
      materialLabel2.Size = new Size(107, 21);
      materialLabel2.TabIndex = 0;
      materialLabel2.Text = "Nome do Alias";
      // 
      // materialLabel6
      // 
      materialLabel6.AutoSize = true;
      materialLabel6.Depth = 0;
      materialLabel6.Font = new Font("HarmonyOS Sans SC", 14F, FontStyle.Regular, GraphicsUnit.Pixel);
      materialLabel6.Location = new Point(290, 203);
      materialLabel6.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel6.Name = "materialLabel6";
      materialLabel6.Size = new Size(74, 21);
      materialLabel6.TabIndex = 8;
      materialLabel6.Text = "Senha RM";
      // 
      // AliasEditorForm
      // 
      AutoScaleDimensions = new SizeF(96F, 96F);
      AutoScaleMode = AutoScaleMode.Dpi;
      BackColor = Color.FromArgb(64, 64, 64);
      ClientSize = new Size(815, 603);
      Controls.Add(materialCard2);
      Controls.Add(materialCard1);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      Icon = (Icon)resources.GetObject("$this.Icon");
      MaximizeBox = false;
      Name = "AliasEditorForm";
      StartPosition = FormStartPosition.CenterScreen;
      Text = "Editor de Alias";
      Load += AliasEditorForm_Load;
      materialCard1.ResumeLayout(false);
      flowLayoutPanel1.ResumeLayout(false);
      flowLayoutPanel1.PerformLayout();
      materialCard2.ResumeLayout(false);
      materialCard2.PerformLayout();
      materialCard3.ResumeLayout(false);
      materialCard3.PerformLayout();
      ResumeLayout(false);

    }

    #endregion

    private Label label1;
    private ContextMenuStrip contextMenuStrip1;
    private Label label8;
    private MaterialSkin3.Controls.MaterialCard materialCard1;
    private MaterialSkin3.Controls.MaterialButton btnNovo;
    private FlowLayoutPanel flowLayoutPanel1;
    private MaterialSkin3.Controls.MaterialButton btnExcluir;
    private MaterialSkin3.Controls.MaterialCard materialCard2;
    private MaterialSkin3.Controls.MaterialLabel materialLabel2;
    private MaterialSkin3.Controls.MaterialTextBox2 materialTextBox21;
    private MaterialSkin3.Controls.MaterialTextBox2 txtUsuarioRM;
    private MaterialSkin3.Controls.MaterialLabel materialLabel9;
    private MaterialSkin3.Controls.MaterialTextBox2 txtServidor;
    private MaterialSkin3.Controls.MaterialLabel materialLabel8;
    private MaterialSkin3.Controls.MaterialTextBox2 txtUsuarioBd;
    private MaterialSkin3.Controls.MaterialLabel materialLabel7;
    private MaterialSkin3.Controls.MaterialTextBox2 txtSenhaRm;
    private MaterialSkin3.Controls.MaterialLabel materialLabel6;
    private MaterialSkin3.Controls.MaterialTextBox2 txtBase;
    private MaterialSkin3.Controls.MaterialLabel materialLabel5;
    private MaterialSkin3.Controls.MaterialTextBox2 txtSenhaBd;
    private MaterialSkin3.Controls.MaterialLabel materialLabel4;
    private MaterialSkin3.Controls.MaterialTextBox2 txtExecSimultanea;
    private MaterialSkin3.Controls.MaterialLabel materialLabel3;
    private MaterialSkin3.Controls.MaterialSwitch chkMsSql;
    private MaterialSkin3.Controls.MaterialSwitch chkOracle;
    private MaterialSkin3.Controls.MaterialLabel materialLabel10;
    private MaterialSkin3.Controls.MaterialCard materialCard3;
    private MaterialSkin3.Controls.MaterialSwitch chkHabilitaPoolProcessos;
    private MaterialSkin3.Controls.MaterialSwitch chkJobsLocais;
    private MaterialSkin3.Controls.MaterialSwitch chkHabilitaProcessJobs;
    private MaterialSkin3.Controls.MaterialSwitch chkRunService;
    private MaterialSkin3.Controls.MaterialButton btnSalvar;
    private MaterialSkin3.Controls.MaterialTextBox2 txtNomeAlias;
    public MaterialSkin3.Controls.MaterialListView lstAliases;
    private ColumnHeader columnHeader1;
  }
}
