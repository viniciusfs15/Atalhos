namespace Atalhos
{
    partial class AtalhosMainForm
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
      materialCard1 = new MaterialSkin3.Controls.MaterialCard();
      materialLabel3 = new MaterialSkin3.Controls.MaterialLabel();
      flowLayoutPanel1 = new FlowLayoutPanel();
      btnAtualizador = new MaterialSkin3.Controls.MaterialButton();
      btnAliasManager = new MaterialSkin3.Controls.MaterialButton();
      materialButton4 = new MaterialSkin3.Controls.MaterialButton();
      materialButton3 = new MaterialSkin3.Controls.MaterialButton();
      btnLimparDllCustom = new MaterialSkin3.Controls.MaterialButton();
      cmbAmbiente = new MaterialSkin3.Controls.MaterialComboBox();
      materialLabel1 = new MaterialSkin3.Controls.MaterialLabel();
      btnConfigAmbiente = new MaterialSkin3.Controls.MaterialFloatingActionButton();
      btnAddAlias = new MaterialSkin3.Controls.MaterialFloatingActionButton();
      materialLabel2 = new MaterialSkin3.Controls.MaterialLabel();
      cmbAlias = new MaterialSkin3.Controls.MaterialComboBox();
      materialCard2 = new MaterialSkin3.Controls.MaterialCard();
      btnEncerrarServicos = new MaterialSkin3.Controls.MaterialButton();
      materialButton7 = new MaterialSkin3.Controls.MaterialButton();
      materialCard3 = new MaterialSkin3.Controls.MaterialCard();
      chkDelBroker = new MaterialSkin3.Controls.MaterialSwitch();
      chkDelBrokerCustom = new MaterialSkin3.Controls.MaterialSwitch();
      materialLabel5 = new MaterialSkin3.Controls.MaterialLabel();
      btnRmExe = new MaterialSkin3.Controls.MaterialButton();
      chkAutoLogin = new MaterialSkin3.Controls.MaterialCheckbox();
      materialLabel4 = new MaterialSkin3.Controls.MaterialLabel();
      materialDrawer1 = new MaterialSkin3.Controls.MaterialDrawer();
      materialCard4 = new MaterialSkin3.Controls.MaterialCard();
      btnCorporeNet = new MaterialSkin3.Controls.MaterialButton();
      btnFrameHtml = new MaterialSkin3.Controls.MaterialButton();
      chkControlaIis = new MaterialSkin3.Controls.MaterialCheckbox();
      btnAbrirIIS = new MaterialSkin3.Controls.MaterialButton();
      btnReciclarPool = new MaterialSkin3.Controls.MaterialButton();
      btnResetIIs = new MaterialSkin3.Controls.MaterialButton();
      materialLabel6 = new MaterialSkin3.Controls.MaterialLabel();
      chkFavorito = new MaterialSkin3.Controls.MaterialSwitch();
      lblLog = new MaterialSkin3.Controls.MaterialLabel();
      chkOnTray = new MaterialSkin3.Controls.MaterialCheckbox();
      notifyIcon = new NotifyIcon(components);
      contextMenuStripTray = new ContextMenuStrip(components);
      materialCard1.SuspendLayout();
      flowLayoutPanel1.SuspendLayout();
      materialCard2.SuspendLayout();
      materialCard3.SuspendLayout();
      materialCard4.SuspendLayout();
      SuspendLayout();
      // 
      // materialCard1
      // 
      materialCard1.BackColor = Color.FromArgb(255, 255, 255);
      materialCard1.Controls.Add(materialLabel3);
      materialCard1.Controls.Add(flowLayoutPanel1);
      materialCard1.Depth = 0;
      materialCard1.ForeColor = Color.FromArgb(222, 0, 0, 0);
      materialCard1.Location = new Point(10, 113);
      materialCard1.Margin = new Padding(5);
      materialCard1.MouseState = MaterialSkin3.MouseState.HOVER;
      materialCard1.Name = "materialCard1";
      materialCard1.Padding = new Padding(14);
      materialCard1.Size = new Size(243, 288);
      materialCard1.TabIndex = 13;
      // 
      // materialLabel3
      // 
      materialLabel3.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      materialLabel3.AutoSize = true;
      materialLabel3.Depth = 0;
      materialLabel3.Font = new Font("HarmonyOS Sans SC Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
      materialLabel3.FontType = MaterialSkin3.MaterialSkinManager.fontType.H6;
      materialLabel3.Location = new Point(6, 7);
      materialLabel3.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel3.Name = "materialLabel3";
      materialLabel3.Size = new Size(231, 26);
      materialLabel3.TabIndex = 1;
      materialLabel3.Text = "Ferramentas e Diretórios";
      // 
      // flowLayoutPanel1
      // 
      flowLayoutPanel1.Controls.Add(btnAtualizador);
      flowLayoutPanel1.Controls.Add(btnAliasManager);
      flowLayoutPanel1.Controls.Add(materialButton4);
      flowLayoutPanel1.Controls.Add(materialButton3);
      flowLayoutPanel1.Controls.Add(btnLimparDllCustom);
      flowLayoutPanel1.Location = new Point(0, 36);
      flowLayoutPanel1.Name = "flowLayoutPanel1";
      flowLayoutPanel1.Size = new Size(243, 252);
      flowLayoutPanel1.TabIndex = 0;
      // 
      // btnAtualizador
      // 
      btnAtualizador.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      btnAtualizador.AutoSize = false;
      btnAtualizador.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnAtualizador.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnAtualizador.Depth = 0;
      btnAtualizador.HighEmphasis = false;
      btnAtualizador.Icon = Properties.Resources.Atualizador;
      btnAtualizador.Location = new Point(4, 6);
      btnAtualizador.Margin = new Padding(4, 6, 4, 6);
      btnAtualizador.MouseState = MaterialSkin3.MouseState.HOVER;
      btnAtualizador.Name = "btnAtualizador";
      btnAtualizador.NoAccentTextColor = Color.Empty;
      btnAtualizador.Size = new Size(233, 36);
      btnAtualizador.TabIndex = 5;
      btnAtualizador.Text = "RM Atualizador";
      btnAtualizador.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnAtualizador.UseAccentColor = false;
      btnAtualizador.UseVisualStyleBackColor = true;
      btnAtualizador.Click += btnAtualizador_Click;
      // 
      // btnAliasManager
      // 
      btnAliasManager.AutoSize = false;
      btnAliasManager.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnAliasManager.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnAliasManager.Depth = 0;
      btnAliasManager.HighEmphasis = false;
      btnAliasManager.Icon = Properties.Resources.Settings;
      btnAliasManager.Location = new Point(4, 54);
      btnAliasManager.Margin = new Padding(4, 6, 4, 6);
      btnAliasManager.MouseState = MaterialSkin3.MouseState.HOVER;
      btnAliasManager.Name = "btnAliasManager";
      btnAliasManager.NoAccentTextColor = Color.Empty;
      btnAliasManager.Size = new Size(233, 36);
      btnAliasManager.TabIndex = 6;
      btnAliasManager.Text = "RM Alias Manager";
      btnAliasManager.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnAliasManager.UseAccentColor = false;
      btnAliasManager.UseVisualStyleBackColor = true;
      btnAliasManager.Click += btnAlias_Click;
      // 
      // materialButton4
      // 
      materialButton4.AutoSize = false;
      materialButton4.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      materialButton4.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      materialButton4.Depth = 0;
      materialButton4.HighEmphasis = false;
      materialButton4.Icon = Properties.Resources.Pasta;
      materialButton4.Location = new Point(4, 102);
      materialButton4.Margin = new Padding(4, 6, 4, 6);
      materialButton4.MouseState = MaterialSkin3.MouseState.HOVER;
      materialButton4.Name = "materialButton4";
      materialButton4.NoAccentTextColor = Color.Empty;
      materialButton4.Size = new Size(233, 36);
      materialButton4.TabIndex = 7;
      materialButton4.Text = "Abrir Pasta Bin";
      materialButton4.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      materialButton4.UseAccentColor = false;
      materialButton4.UseVisualStyleBackColor = true;
      materialButton4.Click += btnBin_Click;
      // 
      // materialButton3
      // 
      materialButton3.AutoSize = false;
      materialButton3.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      materialButton3.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      materialButton3.Depth = 0;
      materialButton3.HighEmphasis = false;
      materialButton3.Icon = Properties.Resources.Pasta;
      materialButton3.Location = new Point(4, 150);
      materialButton3.Margin = new Padding(4, 6, 4, 6);
      materialButton3.MouseState = MaterialSkin3.MouseState.HOVER;
      materialButton3.Name = "materialButton3";
      materialButton3.NoAccentTextColor = Color.Empty;
      materialButton3.Size = new Size(233, 36);
      materialButton3.TabIndex = 8;
      materialButton3.Text = "Abrir Pasta Custom";
      materialButton3.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      materialButton3.UseAccentColor = false;
      materialButton3.UseVisualStyleBackColor = true;
      materialButton3.Click += btnCustom_Click;
      // 
      // btnLimparDllCustom
      // 
      btnLimparDllCustom.AutoSize = false;
      btnLimparDllCustom.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnLimparDllCustom.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnLimparDllCustom.Depth = 0;
      btnLimparDllCustom.HighEmphasis = false;
      btnLimparDllCustom.Icon = Properties.Resources.delete;
      btnLimparDllCustom.Location = new Point(4, 198);
      btnLimparDllCustom.Margin = new Padding(4, 6, 4, 6);
      btnLimparDllCustom.MouseState = MaterialSkin3.MouseState.HOVER;
      btnLimparDllCustom.Name = "btnLimparDllCustom";
      btnLimparDllCustom.NoAccentTextColor = Color.Empty;
      btnLimparDllCustom.Size = new Size(233, 36);
      btnLimparDllCustom.TabIndex = 9;
      btnLimparDllCustom.Text = "Limpar DLLs custom";
      btnLimparDllCustom.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnLimparDllCustom.UseAccentColor = false;
      btnLimparDllCustom.UseVisualStyleBackColor = true;
      btnLimparDllCustom.Click += btnDelDllCustom_Click;
      // 
      // cmbAmbiente
      // 
      cmbAmbiente.AutoResize = false;
      cmbAmbiente.BackColor = Color.FromArgb(255, 255, 255);
      cmbAmbiente.Depth = 0;
      cmbAmbiente.DrawMode = DrawMode.OwnerDrawVariable;
      cmbAmbiente.DropDownHeight = 118;
      cmbAmbiente.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbAmbiente.DropDownWidth = 121;
      cmbAmbiente.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
      cmbAmbiente.ForeColor = Color.FromArgb(222, 0, 0, 0);
      cmbAmbiente.FormattingEnabled = true;
      cmbAmbiente.IntegralHeight = false;
      cmbAmbiente.ItemHeight = 29;
      cmbAmbiente.Location = new Point(10, 70);
      cmbAmbiente.MaxDropDownItems = 4;
      cmbAmbiente.MouseState = MaterialSkin3.MouseState.OUT;
      cmbAmbiente.Name = "cmbAmbiente";
      cmbAmbiente.Size = new Size(400, 35);
      cmbAmbiente.StartIndex = 0;
      cmbAmbiente.TabIndex = 0;
      cmbAmbiente.UseAccent = false;
      cmbAmbiente.UseTallSize = false;
      cmbAmbiente.SelectedIndexChanged += cmbAmbiente_SelectedIndexChanged;
      // 
      // materialLabel1
      // 
      materialLabel1.Depth = 0;
      materialLabel1.Font = new Font("HarmonyOS Sans SC Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
      materialLabel1.FontType = MaterialSkin3.MaterialSkinManager.fontType.H6;
      materialLabel1.Location = new Point(10, 44);
      materialLabel1.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel1.Name = "materialLabel1";
      materialLabel1.Size = new Size(100, 23);
      materialLabel1.TabIndex = 11;
      materialLabel1.Text = "Ambiente";
      // 
      // btnConfigAmbiente
      // 
      btnConfigAmbiente.Depth = 0;
      btnConfigAmbiente.Icon = Properties.Resources.Settings;
      btnConfigAmbiente.Location = new Point(416, 65);
      btnConfigAmbiente.Mini = true;
      btnConfigAmbiente.MouseState = MaterialSkin3.MouseState.HOVER;
      btnConfigAmbiente.Name = "btnConfigAmbiente";
      btnConfigAmbiente.Size = new Size(40, 40);
      btnConfigAmbiente.TabIndex = 2;
      btnConfigAmbiente.UseVisualStyleBackColor = true;
      btnConfigAmbiente.Click += btnConfigAmbiente_Click;
      // 
      // btnAddAlias
      // 
      btnAddAlias.Depth = 0;
      btnAddAlias.Icon = Properties.Resources.Settings;
      btnAddAlias.Location = new Point(897, 65);
      btnAddAlias.Mini = true;
      btnAddAlias.MouseState = MaterialSkin3.MouseState.HOVER;
      btnAddAlias.Name = "btnAddAlias";
      btnAddAlias.Size = new Size(40, 40);
      btnAddAlias.TabIndex = 4;
      btnAddAlias.UseVisualStyleBackColor = true;
      btnAddAlias.Click += btnAddAlias_Click;
      // 
      // materialLabel2
      // 
      materialLabel2.Depth = 0;
      materialLabel2.Font = new Font("HarmonyOS Sans SC Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
      materialLabel2.FontType = MaterialSkin3.MaterialSkinManager.fontType.H6;
      materialLabel2.Location = new Point(491, 44);
      materialLabel2.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel2.Name = "materialLabel2";
      materialLabel2.Size = new Size(100, 23);
      materialLabel2.TabIndex = 9;
      materialLabel2.Text = "Alias";
      // 
      // cmbAlias
      // 
      cmbAlias.AutoResize = false;
      cmbAlias.BackColor = Color.FromArgb(255, 255, 255);
      cmbAlias.Depth = 0;
      cmbAlias.DrawMode = DrawMode.OwnerDrawVariable;
      cmbAlias.DropDownHeight = 118;
      cmbAlias.DropDownStyle = ComboBoxStyle.DropDownList;
      cmbAlias.DropDownWidth = 121;
      cmbAlias.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
      cmbAlias.ForeColor = Color.FromArgb(222, 0, 0, 0);
      cmbAlias.FormattingEnabled = true;
      cmbAlias.IntegralHeight = false;
      cmbAlias.ItemHeight = 29;
      cmbAlias.Location = new Point(491, 70);
      cmbAlias.MaxDropDownItems = 4;
      cmbAlias.MouseState = MaterialSkin3.MouseState.OUT;
      cmbAlias.Name = "cmbAlias";
      cmbAlias.Size = new Size(400, 35);
      cmbAlias.StartIndex = 0;
      cmbAlias.TabIndex = 3;
      cmbAlias.UseAccent = false;
      cmbAlias.UseTallSize = false;
      cmbAlias.SelectedIndexChanged += cmbAlias_SelectedIndexChanged;
      // 
      // materialCard2
      // 
      materialCard2.BackColor = Color.FromArgb(255, 255, 255);
      materialCard2.Controls.Add(btnEncerrarServicos);
      materialCard2.Controls.Add(materialButton7);
      materialCard2.Controls.Add(materialCard3);
      materialCard2.Controls.Add(btnRmExe);
      materialCard2.Controls.Add(chkAutoLogin);
      materialCard2.Controls.Add(materialLabel4);
      materialCard2.Depth = 0;
      materialCard2.ForeColor = Color.FromArgb(222, 0, 0, 0);
      materialCard2.Location = new Point(264, 113);
      materialCard2.Margin = new Padding(14);
      materialCard2.MouseState = MaterialSkin3.MouseState.HOVER;
      materialCard2.Name = "materialCard2";
      materialCard2.Padding = new Padding(14);
      materialCard2.Size = new Size(338, 288);
      materialCard2.TabIndex = 6;
      // 
      // btnEncerrarServicos
      // 
      btnEncerrarServicos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnEncerrarServicos.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnEncerrarServicos.Depth = 0;
      btnEncerrarServicos.HighEmphasis = true;
      btnEncerrarServicos.Icon = Properties.Resources.Close;
      btnEncerrarServicos.Location = new Point(124, 193);
      btnEncerrarServicos.Margin = new Padding(4, 6, 4, 6);
      btnEncerrarServicos.MouseState = MaterialSkin3.MouseState.HOVER;
      btnEncerrarServicos.Name = "btnEncerrarServicos";
      btnEncerrarServicos.NoAccentTextColor = Color.Empty;
      btnEncerrarServicos.Size = new Size(203, 36);
      btnEncerrarServicos.TabIndex = 15;
      btnEncerrarServicos.Text = "Encerrar Serviços";
      btnEncerrarServicos.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnEncerrarServicos.UseAccentColor = true;
      btnEncerrarServicos.UseVisualStyleBackColor = true;
      btnEncerrarServicos.Click += EncerrarAmbiente;
      // 
      // materialButton7
      // 
      materialButton7.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      materialButton7.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      materialButton7.Depth = 0;
      materialButton7.HighEmphasis = true;
      materialButton7.Icon = Properties.Resources.Host;
      materialButton7.Location = new Point(238, 49);
      materialButton7.Margin = new Padding(4, 6, 4, 6);
      materialButton7.MouseState = MaterialSkin3.MouseState.HOVER;
      materialButton7.Name = "materialButton7";
      materialButton7.NoAccentTextColor = Color.Empty;
      materialButton7.Size = new Size(89, 36);
      materialButton7.TabIndex = 12;
      materialButton7.Text = "Host";
      materialButton7.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      materialButton7.UseAccentColor = false;
      materialButton7.UseVisualStyleBackColor = true;
      materialButton7.Click += btnHost_Click;
      // 
      // materialCard3
      // 
      materialCard3.BackColor = Color.FromArgb(255, 255, 255);
      materialCard3.Controls.Add(chkDelBroker);
      materialCard3.Controls.Add(chkDelBrokerCustom);
      materialCard3.Controls.Add(materialLabel5);
      materialCard3.Depth = 0;
      materialCard3.ForeColor = Color.FromArgb(222, 0, 0, 0);
      materialCard3.Location = new Point(13, 99);
      materialCard3.Margin = new Padding(14);
      materialCard3.MouseState = MaterialSkin3.MouseState.HOVER;
      materialCard3.Name = "materialCard3";
      materialCard3.Padding = new Padding(14);
      materialCard3.Size = new Size(314, 80);
      materialCard3.TabIndex = 0;
      // 
      // chkDelBroker
      // 
      chkDelBroker.AutoSize = true;
      chkDelBroker.Depth = 0;
      chkDelBroker.Location = new Point(11, 30);
      chkDelBroker.Margin = new Padding(0);
      chkDelBroker.MouseLocation = new Point(-1, -1);
      chkDelBroker.MouseState = MaterialSkin3.MouseState.HOVER;
      chkDelBroker.Name = "chkDelBroker";
      chkDelBroker.Ripple = true;
      chkDelBroker.Size = new Size(106, 37);
      chkDelBroker.TabIndex = 13;
      chkDelBroker.Text = "Broker";
      chkDelBroker.UseVisualStyleBackColor = true;
      // 
      // chkDelBrokerCustom
      // 
      chkDelBrokerCustom.AutoSize = true;
      chkDelBrokerCustom.Depth = 0;
      chkDelBrokerCustom.Location = new Point(133, 30);
      chkDelBrokerCustom.Margin = new Padding(0);
      chkDelBrokerCustom.MouseLocation = new Point(-1, -1);
      chkDelBrokerCustom.MouseState = MaterialSkin3.MouseState.HOVER;
      chkDelBrokerCustom.Name = "chkDelBrokerCustom";
      chkDelBrokerCustom.Ripple = true;
      chkDelBrokerCustom.Size = new Size(165, 37);
      chkDelBrokerCustom.TabIndex = 14;
      chkDelBrokerCustom.Text = "Broker Custom";
      chkDelBrokerCustom.UseVisualStyleBackColor = true;
      // 
      // materialLabel5
      // 
      materialLabel5.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      materialLabel5.AutoSize = true;
      materialLabel5.Depth = 0;
      materialLabel5.Font = new Font("HarmonyOS Sans SC Medium", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
      materialLabel5.FontType = MaterialSkin3.MaterialSkinManager.fontType.Subtitle2;
      materialLabel5.Location = new Point(28, 6);
      materialLabel5.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel5.Name = "materialLabel5";
      materialLabel5.Size = new Size(189, 19);
      materialLabel5.TabIndex = 2;
      materialLabel5.Text = "Limpeza de broker ao iniciar";
      // 
      // btnRmExe
      // 
      btnRmExe.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnRmExe.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnRmExe.Depth = 0;
      btnRmExe.HighEmphasis = true;
      btnRmExe.Icon = Properties.Resources.TOTVS_Branco;
      btnRmExe.Location = new Point(127, 49);
      btnRmExe.Margin = new Padding(4, 6, 4, 6);
      btnRmExe.MouseState = MaterialSkin3.MouseState.HOVER;
      btnRmExe.Name = "btnRmExe";
      btnRmExe.NoAccentTextColor = Color.Empty;
      btnRmExe.Size = new Size(103, 36);
      btnRmExe.TabIndex = 11;
      btnRmExe.Text = "RM.exe";
      btnRmExe.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnRmExe.UseAccentColor = false;
      btnRmExe.UseVisualStyleBackColor = true;
      btnRmExe.Click += btnRmExe_Click;
      // 
      // chkAutoLogin
      // 
      chkAutoLogin.AutoSize = true;
      chkAutoLogin.Depth = 0;
      chkAutoLogin.Location = new Point(5, 50);
      chkAutoLogin.Margin = new Padding(0);
      chkAutoLogin.MouseLocation = new Point(-1, -1);
      chkAutoLogin.MouseState = MaterialSkin3.MouseState.HOVER;
      chkAutoLogin.Name = "chkAutoLogin";
      chkAutoLogin.ReadOnly = false;
      chkAutoLogin.Ripple = true;
      chkAutoLogin.Size = new Size(110, 37);
      chkAutoLogin.TabIndex = 10;
      chkAutoLogin.Text = "Auto login";
      chkAutoLogin.UseVisualStyleBackColor = true;
      // 
      // materialLabel4
      // 
      materialLabel4.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
      materialLabel4.AutoSize = true;
      materialLabel4.Depth = 0;
      materialLabel4.Font = new Font("HarmonyOS Sans SC Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
      materialLabel4.FontType = MaterialSkin3.MaterialSkinManager.fontType.H6;
      materialLabel4.Location = new Point(69, 7);
      materialLabel4.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel4.Name = "materialLabel4";
      materialLabel4.Size = new Size(203, 26);
      materialLabel4.TabIndex = 5;
      materialLabel4.Text = "Controle de Execução";
      // 
      // materialDrawer1
      // 
      materialDrawer1.AutoHide = false;
      materialDrawer1.AutoShow = false;
      materialDrawer1.BackgroundWithAccent = false;
      materialDrawer1.BaseTabControl = null;
      materialDrawer1.Depth = 0;
      materialDrawer1.HighlightWithAccent = true;
      materialDrawer1.IndicatorWidth = 0;
      materialDrawer1.IsOpen = false;
      materialDrawer1.Location = new Point(-250, 0);
      materialDrawer1.MouseState = MaterialSkin3.MouseState.HOVER;
      materialDrawer1.Name = "materialDrawer1";
      materialDrawer1.ShowIconsWhenHidden = false;
      materialDrawer1.Size = new Size(250, 120);
      materialDrawer1.TabIndex = 0;
      materialDrawer1.UseColors = false;
      // 
      // materialCard4
      // 
      materialCard4.BackColor = Color.FromArgb(255, 255, 255);
      materialCard4.Controls.Add(btnCorporeNet);
      materialCard4.Controls.Add(btnFrameHtml);
      materialCard4.Controls.Add(chkControlaIis);
      materialCard4.Controls.Add(btnAbrirIIS);
      materialCard4.Controls.Add(btnReciclarPool);
      materialCard4.Controls.Add(btnResetIIs);
      materialCard4.Controls.Add(materialLabel6);
      materialCard4.Depth = 0;
      materialCard4.ForeColor = Color.FromArgb(222, 0, 0, 0);
      materialCard4.Location = new Point(612, 113);
      materialCard4.Margin = new Padding(14);
      materialCard4.MouseState = MaterialSkin3.MouseState.HOVER;
      materialCard4.Name = "materialCard4";
      materialCard4.Padding = new Padding(14);
      materialCard4.Size = new Size(325, 288);
      materialCard4.TabIndex = 5;
      // 
      // btnCorporeNet
      // 
      btnCorporeNet.AutoSize = false;
      btnCorporeNet.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnCorporeNet.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnCorporeNet.Depth = 0;
      btnCorporeNet.HighEmphasis = false;
      btnCorporeNet.Icon = Properties.Resources.Pasta;
      btnCorporeNet.Location = new Point(11, 145);
      btnCorporeNet.Margin = new Padding(4, 6, 4, 6);
      btnCorporeNet.MouseState = MaterialSkin3.MouseState.HOVER;
      btnCorporeNet.Name = "btnCorporeNet";
      btnCorporeNet.NoAccentTextColor = Color.Empty;
      btnCorporeNet.Size = new Size(305, 36);
      btnCorporeNet.TabIndex = 20;
      btnCorporeNet.Text = "Abrir Corpore.Net";
      btnCorporeNet.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnCorporeNet.UseAccentColor = false;
      btnCorporeNet.UseVisualStyleBackColor = true;
      btnCorporeNet.Click += btnCorporeNet_Click;
      // 
      // btnFrameHtml
      // 
      btnFrameHtml.AutoSize = false;
      btnFrameHtml.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnFrameHtml.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnFrameHtml.Depth = 0;
      btnFrameHtml.HighEmphasis = false;
      btnFrameHtml.Icon = Properties.Resources.Pasta;
      btnFrameHtml.Location = new Point(11, 193);
      btnFrameHtml.Margin = new Padding(4, 6, 4, 6);
      btnFrameHtml.MouseState = MaterialSkin3.MouseState.HOVER;
      btnFrameHtml.Name = "btnFrameHtml";
      btnFrameHtml.NoAccentTextColor = Color.Empty;
      btnFrameHtml.Size = new Size(305, 36);
      btnFrameHtml.TabIndex = 21;
      btnFrameHtml.Text = "Abrir Pasta FrameHTML";
      btnFrameHtml.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnFrameHtml.UseAccentColor = false;
      btnFrameHtml.UseVisualStyleBackColor = true;
      btnFrameHtml.Click += btnFrameHtml_Click;
      // 
      // chkControlaIis
      // 
      chkControlaIis.AutoSize = true;
      chkControlaIis.Depth = 0;
      chkControlaIis.Location = new Point(4, 48);
      chkControlaIis.Margin = new Padding(0);
      chkControlaIis.MouseLocation = new Point(-1, -1);
      chkControlaIis.MouseState = MaterialSkin3.MouseState.HOVER;
      chkControlaIis.Name = "chkControlaIis";
      chkControlaIis.ReadOnly = false;
      chkControlaIis.Ripple = true;
      chkControlaIis.Size = new Size(118, 37);
      chkControlaIis.TabIndex = 16;
      chkControlaIis.Text = "Controla IIS";
      chkControlaIis.UseVisualStyleBackColor = true;
      // 
      // btnAbrirIIS
      // 
      btnAbrirIIS.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnAbrirIIS.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnAbrirIIS.Depth = 0;
      btnAbrirIIS.HighEmphasis = true;
      btnAbrirIIS.Icon = null;
      btnAbrirIIS.Location = new Point(214, 97);
      btnAbrirIIS.Margin = new Padding(4, 6, 4, 6);
      btnAbrirIIS.MouseState = MaterialSkin3.MouseState.HOVER;
      btnAbrirIIS.Name = "btnAbrirIIS";
      btnAbrirIIS.NoAccentTextColor = Color.Empty;
      btnAbrirIIS.Size = new Size(102, 36);
      btnAbrirIIS.TabIndex = 19;
      btnAbrirIIS.Text = "Abrir o IIS";
      btnAbrirIIS.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Contained;
      btnAbrirIIS.UseAccentColor = false;
      btnAbrirIIS.UseVisualStyleBackColor = true;
      btnAbrirIIS.Click += btnAbrirIIS_Click;
      // 
      // btnReciclarPool
      // 
      btnReciclarPool.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnReciclarPool.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnReciclarPool.Depth = 0;
      btnReciclarPool.HighEmphasis = false;
      btnReciclarPool.Icon = Properties.Resources.recycle;
      btnReciclarPool.Location = new Point(11, 97);
      btnReciclarPool.Margin = new Padding(4, 6, 4, 6);
      btnReciclarPool.MouseState = MaterialSkin3.MouseState.HOVER;
      btnReciclarPool.Name = "btnReciclarPool";
      btnReciclarPool.NoAccentTextColor = Color.Empty;
      btnReciclarPool.Size = new Size(193, 36);
      btnReciclarPool.TabIndex = 18;
      btnReciclarPool.Text = "Reciclar AppPool";
      btnReciclarPool.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Outlined;
      btnReciclarPool.UseAccentColor = false;
      btnReciclarPool.UseVisualStyleBackColor = true;
      btnReciclarPool.Click += btnReciclarAppPool_Click;
      // 
      // btnResetIIs
      // 
      btnResetIIs.AutoSizeMode = AutoSizeMode.GrowAndShrink;
      btnResetIIs.Density = MaterialSkin3.Controls.MaterialButton.MaterialButtonDensity.Default;
      btnResetIIs.Depth = 0;
      btnResetIIs.HighEmphasis = false;
      btnResetIIs.Icon = Properties.Resources.update;
      btnResetIIs.Location = new Point(173, 49);
      btnResetIIs.Margin = new Padding(4, 6, 4, 6);
      btnResetIIs.MouseState = MaterialSkin3.MouseState.HOVER;
      btnResetIIs.Name = "btnResetIIs";
      btnResetIIs.NoAccentTextColor = Color.Empty;
      btnResetIIs.Size = new Size(143, 36);
      btnResetIIs.TabIndex = 17;
      btnResetIIs.Text = "Reiniciar IIS";
      btnResetIIs.Type = MaterialSkin3.Controls.MaterialButton.MaterialButtonType.Outlined;
      btnResetIIs.UseAccentColor = false;
      btnResetIIs.UseVisualStyleBackColor = true;
      btnResetIIs.Click += btnReset_Click;
      // 
      // materialLabel6
      // 
      materialLabel6.AutoSize = true;
      materialLabel6.Depth = 0;
      materialLabel6.Font = new Font("HarmonyOS Sans SC Medium", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
      materialLabel6.FontType = MaterialSkin3.MaterialSkinManager.fontType.H6;
      materialLabel6.Location = new Point(112, 7);
      materialLabel6.MouseState = MaterialSkin3.MouseState.HOVER;
      materialLabel6.Name = "materialLabel6";
      materialLabel6.Size = new Size(111, 26);
      materialLabel6.TabIndex = 6;
      materialLabel6.Text = "IIS e Portais";
      // 
      // chkFavorito
      // 
      chkFavorito.AutoSize = true;
      chkFavorito.Depth = 0;
      chkFavorito.Location = new Point(292, 30);
      chkFavorito.Margin = new Padding(0);
      chkFavorito.MouseLocation = new Point(-1, -1);
      chkFavorito.MouseState = MaterialSkin3.MouseState.HOVER;
      chkFavorito.Name = "chkFavorito";
      chkFavorito.Ripple = true;
      chkFavorito.Size = new Size(118, 37);
      chkFavorito.TabIndex = 1;
      chkFavorito.Text = "Favorito";
      chkFavorito.UseVisualStyleBackColor = true;
      // 
      // lblLog
      // 
      lblLog.Depth = 0;
      lblLog.Font = new Font("HarmonyOS Sans SC", 12F, FontStyle.Italic, GraphicsUnit.Pixel);
      lblLog.FontType = MaterialSkin3.MaterialSkinManager.fontType.SubtleEmphasis;
      lblLog.ForeColor = Color.Firebrick;
      lblLog.Location = new Point(10, 406);
      lblLog.MouseState = MaterialSkin3.MouseState.HOVER;
      lblLog.Name = "lblLog";
      lblLog.Size = new Size(100, 23);
      lblLog.TabIndex = 3;
      lblLog.Text = "lblLog";
      // 
      // chkOnTray
      // 
      chkOnTray.AutoSize = true;
      chkOnTray.Depth = 0;
      chkOnTray.Location = new Point(622, 406);
      chkOnTray.Margin = new Padding(0);
      chkOnTray.MouseLocation = new Point(-1, -1);
      chkOnTray.MouseState = MaterialSkin3.MouseState.HOVER;
      chkOnTray.Name = "chkOnTray";
      chkOnTray.ReadOnly = false;
      chkOnTray.Ripple = true;
      chkOnTray.Size = new Size(315, 37);
      chkOnTray.TabIndex = 22;
      chkOnTray.Text = "Minimizar para a bandeja do Windows";
      chkOnTray.UseVisualStyleBackColor = true;
      chkOnTray.CheckedChanged += chkOnTray_CheckedChanged;
      // 
      // contextMenuStripTray
      // 
      contextMenuStripTray.Name = "contextMenuStripTray";
      contextMenuStripTray.RenderMode = ToolStripRenderMode.System;
      contextMenuStripTray.Size = new Size(61, 4);
      // 
      // AtalhosMainForm
      // 
      AutoScaleDimensions = new SizeF(7F, 15F);
      AutoScaleMode = AutoScaleMode.Font;
      BackColor = Color.FromArgb(64, 64, 64);
      ClientSize = new Size(941, 448);
      Controls.Add(chkOnTray);
      Controls.Add(lblLog);
      Controls.Add(chkFavorito);
      Controls.Add(materialCard4);
      Controls.Add(materialCard2);
      Controls.Add(btnAddAlias);
      Controls.Add(cmbAlias);
      Controls.Add(materialLabel2);
      Controls.Add(btnConfigAmbiente);
      Controls.Add(materialLabel1);
      Controls.Add(cmbAmbiente);
      Controls.Add(materialCard1);
      FormBorderStyle = FormBorderStyle.FixedSingle;
      FormStyle = FormStyles.ActionBar_None;
      MaximizeBox = false;
      Name = "AtalhosMainForm";
      Padding = new Padding(3, 24, 3, 3);
      Sizable = false;
      Deactivate += AtalhosMainForm_Deactivate;
      FormClosing += AtalhosMainForm_FormClosing;
      Load += AtalhosMainForm_Load;
      materialCard1.ResumeLayout(false);
      materialCard1.PerformLayout();
      flowLayoutPanel1.ResumeLayout(false);
      materialCard2.ResumeLayout(false);
      materialCard2.PerformLayout();
      materialCard3.ResumeLayout(false);
      materialCard3.PerformLayout();
      materialCard4.ResumeLayout(false);
      materialCard4.PerformLayout();
      ResumeLayout(false);
      PerformLayout();
    }

    #endregion
    private MaterialSkin3.Controls.MaterialCard materialCard1;
    private MaterialSkin3.Controls.MaterialComboBox cmbAmbiente;
    private MaterialSkin3.Controls.MaterialLabel materialLabel1;
    private MaterialSkin3.Controls.MaterialFloatingActionButton materialFloatingActionButton1;
    private MaterialSkin3.Controls.MaterialLabel materialLabel3;
    private MaterialSkin3.Controls.MaterialFloatingActionButton materialFloatingActionButton2;
    private MaterialSkin3.Controls.MaterialLabel materialLabel2;
    private MaterialSkin3.Controls.MaterialComboBox cmbAlias;
    private MaterialSkin3.Controls.MaterialButton materialButton3;
    private MaterialSkin3.Controls.MaterialButton btnAtualizador;
    private MaterialSkin3.Controls.MaterialButton btnLimparDllCustom;
    private MaterialSkin3.Controls.MaterialButton materialButton4;
    private MaterialSkin3.Controls.MaterialCard materialCard2;
    private MaterialSkin3.Controls.MaterialCheckbox chkAutoLogin;
    private MaterialSkin3.Controls.MaterialLabel materialLabel4;
    private MaterialSkin3.Controls.MaterialButton btnEncerrarServicos;
    private MaterialSkin3.Controls.MaterialButton materialButton7;
    private MaterialSkin3.Controls.MaterialButton btnRmExe;
    private MaterialSkin3.Controls.MaterialLabel materialLabel5;
    private MaterialSkin3.Controls.MaterialDrawer materialDrawer1;
    private MaterialSkin3.Controls.MaterialCard materialCard3;
    private MaterialSkin3.Controls.MaterialCard materialCard4;
    private MaterialSkin3.Controls.MaterialButton btnResetIIs;
    private MaterialSkin3.Controls.MaterialLabel materialLabel6;
    private MaterialSkin3.Controls.MaterialButton btnAbrirIIS;
    private MaterialSkin3.Controls.MaterialButton btnReciclarPool;
    private MaterialSkin3.Controls.MaterialSwitch chkFavorito;
    private MaterialSkin3.Controls.MaterialCheckbox chkControlaIis;
    private MaterialSkin3.Controls.MaterialButton btnCorporeNet;
    private MaterialSkin3.Controls.MaterialButton btnFrameHtml;
    private MaterialSkin3.Controls.MaterialLabel lblLog;
    private MaterialSkin3.Controls.MaterialFloatingActionButton btnAddAlias;
    private MaterialSkin3.Controls.MaterialFloatingActionButton btnConfigAmbiente;
    private MaterialSkin3.Controls.MaterialCheckbox chkOnTray;
    private NotifyIcon notifyIcon;
    private MaterialSkin3.Controls.MaterialSwitch chkDelBrokerCustom;
    private MaterialSkin3.Controls.MaterialSwitch chkDelBroker;
    private ContextMenuStrip contextMenuStripTray;
    private FlowLayoutPanel flowLayoutPanel1;
    private MaterialSkin3.Controls.MaterialButton btnAliasManager;
  }
}
