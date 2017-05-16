namespace simple_prerior
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_grammar = new System.Windows.Forms.RichTextBox();
            this.lbl_syntax = new System.Windows.Forms.Label();
            this.top_menu = new System.Windows.Forms.MenuStrip();
            this.files_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.importSyntaxItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSyntaxItem = new System.Windows.Forms.ToolStripMenuItem();
            this.syntaxSaveAsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anslyse_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.priorTableItem = new System.Windows.Forms.ToolStripMenuItem();
            this.symbolAnalysisItem = new System.Windows.Forms.ToolStripMenuItem();
            this.utils_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFontItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textFontItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chineseItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishItem = new System.Windows.Forms.ToolStripMenuItem();
            this.help_menu = new System.Windows.Forms.ToolStripMenuItem();
            this.operationItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exampleItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutItem = new System.Windows.Forms.ToolStripMenuItem();
            this.buildByItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dgv_prior = new System.Windows.Forms.DataGridView();
            this.lbl_prior = new System.Windows.Forms.Label();
            this.lbl_symbol = new System.Windows.Forms.Label();
            this.txt_input = new System.Windows.Forms.TextBox();
            this.btn_anlysis = new System.Windows.Forms.Button();
            this.lbl_result = new System.Windows.Forms.Label();
            this.dgv_result = new System.Windows.Forms.DataGridView();
            this.top_menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).BeginInit();
            this.SuspendLayout();
            // 
            // rtb_grammar
            // 
            this.rtb_grammar.Location = new System.Drawing.Point(12, 66);
            this.rtb_grammar.Name = "rtb_grammar";
            this.rtb_grammar.Size = new System.Drawing.Size(298, 158);
            this.rtb_grammar.TabIndex = 0;
            this.rtb_grammar.Text = "";
            // 
            // lbl_syntax
            // 
            this.lbl_syntax.AutoSize = true;
            this.lbl_syntax.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_syntax.Location = new System.Drawing.Point(9, 47);
            this.lbl_syntax.Name = "lbl_syntax";
            this.lbl_syntax.Size = new System.Drawing.Size(72, 16);
            this.lbl_syntax.TabIndex = 4;
            this.lbl_syntax.Text = "Grammar:";
            // 
            // top_menu
            // 
            this.top_menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.files_menu,
            this.anslyse_menu,
            this.utils_menu,
            this.help_menu});
            this.top_menu.Location = new System.Drawing.Point(0, 0);
            this.top_menu.Name = "top_menu";
            this.top_menu.Size = new System.Drawing.Size(781, 25);
            this.top_menu.TabIndex = 3;
            this.top_menu.Text = "menuStrip1";
            // 
            // files_menu
            // 
            this.files_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importSyntaxItem,
            this.saveSyntaxItem,
            this.syntaxSaveAsItem,
            this.closeItem});
            this.files_menu.Image = global::simple_prerior.Properties.Resources.dir;
            this.files_menu.Name = "files_menu";
            this.files_menu.Size = new System.Drawing.Size(55, 21);
            this.files_menu.Text = "File";
            // 
            // importSyntaxItem
            // 
            this.importSyntaxItem.Image = global::simple_prerior.Properties.Resources.open_source;
            this.importSyntaxItem.Name = "importSyntaxItem";
            this.importSyntaxItem.Size = new System.Drawing.Size(162, 22);
            this.importSyntaxItem.Text = "Import Syntax";
            this.importSyntaxItem.Click += new System.EventHandler(this.importSyntaxItem_Click);
            // 
            // saveSyntaxItem
            // 
            this.saveSyntaxItem.Image = global::simple_prerior.Properties.Resources.save_result;
            this.saveSyntaxItem.Name = "saveSyntaxItem";
            this.saveSyntaxItem.Size = new System.Drawing.Size(162, 22);
            this.saveSyntaxItem.Text = "Save Syntax";
            this.saveSyntaxItem.Click += new System.EventHandler(this.saveSyntaxItem_Click);
            // 
            // syntaxSaveAsItem
            // 
            this.syntaxSaveAsItem.Image = global::simple_prerior.Properties.Resources.save_as;
            this.syntaxSaveAsItem.Name = "syntaxSaveAsItem";
            this.syntaxSaveAsItem.Size = new System.Drawing.Size(162, 22);
            this.syntaxSaveAsItem.Text = "Syntax Save As";
            this.syntaxSaveAsItem.Click += new System.EventHandler(this.syntaxSaveAsItem_Click);
            // 
            // closeItem
            // 
            this.closeItem.Image = global::simple_prerior.Properties.Resources.close;
            this.closeItem.Name = "closeItem";
            this.closeItem.Size = new System.Drawing.Size(162, 22);
            this.closeItem.Text = "Close";
            this.closeItem.Click += new System.EventHandler(this.closeItem_Click);
            // 
            // anslyse_menu
            // 
            this.anslyse_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.priorTableItem,
            this.symbolAnalysisItem});
            this.anslyse_menu.Image = global::simple_prerior.Properties.Resources.Boomy_026;
            this.anslyse_menu.Name = "anslyse_menu";
            this.anslyse_menu.Size = new System.Drawing.Size(80, 21);
            this.anslyse_menu.Text = "Analyse";
            // 
            // priorTableItem
            // 
            this.priorTableItem.Image = global::simple_prerior.Properties.Resources.ffpic1305165755216_32;
            this.priorTableItem.Name = "priorTableItem";
            this.priorTableItem.Size = new System.Drawing.Size(169, 22);
            this.priorTableItem.Text = "Prior Table";
            this.priorTableItem.Click += new System.EventHandler(this.priorTableItem_Click);
            // 
            // symbolAnalysisItem
            // 
            this.symbolAnalysisItem.Image = global::simple_prerior.Properties.Resources.my_app;
            this.symbolAnalysisItem.Name = "symbolAnalysisItem";
            this.symbolAnalysisItem.Size = new System.Drawing.Size(169, 22);
            this.symbolAnalysisItem.Text = "Symbol Analysis";
            this.symbolAnalysisItem.Click += new System.EventHandler(this.symbolAnalysisItem_Click);
            // 
            // utils_menu
            // 
            this.utils_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFontItem,
            this.textFontItem,
            this.languageItem});
            this.utils_menu.Image = global::simple_prerior.Properties.Resources.Boomy_081;
            this.utils_menu.Name = "utils_menu";
            this.utils_menu.Size = new System.Drawing.Size(61, 21);
            this.utils_menu.Text = "Utils";
            // 
            // menuFontItem
            // 
            this.menuFontItem.Image = global::simple_prerior.Properties.Resources.ffpic1305160785554_32;
            this.menuFontItem.Name = "menuFontItem";
            this.menuFontItem.Size = new System.Drawing.Size(138, 22);
            this.menuFontItem.Text = "Menu Font";
            this.menuFontItem.Click += new System.EventHandler(this.menuFontItem_Click);
            // 
            // textFontItem
            // 
            this.textFontItem.Image = global::simple_prerior.Properties.Resources.ffpic13051608708213_32;
            this.textFontItem.Name = "textFontItem";
            this.textFontItem.Size = new System.Drawing.Size(138, 22);
            this.textFontItem.Text = "Text Font";
            this.textFontItem.Click += new System.EventHandler(this.textFontItem_Click);
            // 
            // languageItem
            // 
            this.languageItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chineseItem,
            this.englishItem});
            this.languageItem.Image = global::simple_prerior.Properties.Resources.Boomy_084;
            this.languageItem.Name = "languageItem";
            this.languageItem.Size = new System.Drawing.Size(138, 22);
            this.languageItem.Text = "Language";
            // 
            // chineseItem
            // 
            this.chineseItem.Name = "chineseItem";
            this.chineseItem.Size = new System.Drawing.Size(129, 22);
            this.chineseItem.Text = "简体-中文";
            // 
            // englishItem
            // 
            this.englishItem.Name = "englishItem";
            this.englishItem.Size = new System.Drawing.Size(129, 22);
            this.englishItem.Text = "English";
            // 
            // help_menu
            // 
            this.help_menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.operationItem,
            this.exampleItem,
            this.aboutItem,
            this.buildByItem});
            this.help_menu.Image = global::simple_prerior.Properties.Resources.Boomy_049;
            this.help_menu.Name = "help_menu";
            this.help_menu.Size = new System.Drawing.Size(63, 21);
            this.help_menu.Text = "Help";
            // 
            // operationItem
            // 
            this.operationItem.Image = global::simple_prerior.Properties.Resources.卡通电脑桌面图标下载7;
            this.operationItem.Name = "operationItem";
            this.operationItem.Size = new System.Drawing.Size(152, 22);
            this.operationItem.Text = "Operation";
            this.operationItem.Click += new System.EventHandler(this.operationItem_Click);
            // 
            // exampleItem
            // 
            this.exampleItem.Image = global::simple_prerior.Properties.Resources.Boomy_005;
            this.exampleItem.Name = "exampleItem";
            this.exampleItem.Size = new System.Drawing.Size(152, 22);
            this.exampleItem.Text = "Example";
            this.exampleItem.Click += new System.EventHandler(this.exampleItem_Click);
            // 
            // aboutItem
            // 
            this.aboutItem.Image = global::simple_prerior.Properties.Resources.Boomy_013;
            this.aboutItem.Name = "aboutItem";
            this.aboutItem.Size = new System.Drawing.Size(152, 22);
            this.aboutItem.Text = "About";
            this.aboutItem.Click += new System.EventHandler(this.aboutItem_Click);
            // 
            // buildByItem
            // 
            this.buildByItem.Image = global::simple_prerior.Properties.Resources.Boomy_015;
            this.buildByItem.Name = "buildByItem";
            this.buildByItem.Size = new System.Drawing.Size(152, 22);
            this.buildByItem.Text = "Build By";
            this.buildByItem.Click += new System.EventHandler(this.buildByItem_Click);
            // 
            // dgv_prior
            // 
            this.dgv_prior.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_prior.Location = new System.Drawing.Point(15, 268);
            this.dgv_prior.Name = "dgv_prior";
            this.dgv_prior.RowTemplate.Height = 23;
            this.dgv_prior.Size = new System.Drawing.Size(295, 209);
            this.dgv_prior.TabIndex = 6;
            // 
            // lbl_prior
            // 
            this.lbl_prior.AutoSize = true;
            this.lbl_prior.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_prior.Location = new System.Drawing.Point(9, 249);
            this.lbl_prior.Name = "lbl_prior";
            this.lbl_prior.Size = new System.Drawing.Size(104, 16);
            this.lbl_prior.TabIndex = 5;
            this.lbl_prior.Text = "Prior Table:";
            // 
            // lbl_symbol
            // 
            this.lbl_symbol.AutoSize = true;
            this.lbl_symbol.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_symbol.Location = new System.Drawing.Point(384, 47);
            this.lbl_symbol.Name = "lbl_symbol";
            this.lbl_symbol.Size = new System.Drawing.Size(320, 16);
            this.lbl_symbol.TabIndex = 7;
            this.lbl_symbol.Text = "Input symbol string(Please end of \'$\'):";
            // 
            // txt_input
            // 
            this.txt_input.Font = new System.Drawing.Font("宋体", 12F);
            this.txt_input.Location = new System.Drawing.Point(387, 66);
            this.txt_input.Name = "txt_input";
            this.txt_input.Size = new System.Drawing.Size(339, 26);
            this.txt_input.TabIndex = 1;
            this.txt_input.TextChanged += new System.EventHandler(this.txt_input_TextChanged);
            // 
            // btn_anlysis
            // 
            this.btn_anlysis.Font = new System.Drawing.Font("宋体", 12F);
            this.btn_anlysis.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.btn_anlysis.Location = new System.Drawing.Point(387, 120);
            this.btn_anlysis.Name = "btn_anlysis";
            this.btn_anlysis.Size = new System.Drawing.Size(147, 31);
            this.btn_anlysis.TabIndex = 2;
            this.btn_anlysis.Text = "START ANALYSIS";
            this.btn_anlysis.UseVisualStyleBackColor = true;
            this.btn_anlysis.Click += new System.EventHandler(this.btn_anlysis_Click);
            // 
            // lbl_result
            // 
            this.lbl_result.AutoSize = true;
            this.lbl_result.Font = new System.Drawing.Font("宋体", 12F);
            this.lbl_result.Location = new System.Drawing.Point(384, 176);
            this.lbl_result.Name = "lbl_result";
            this.lbl_result.Size = new System.Drawing.Size(64, 16);
            this.lbl_result.TabIndex = 8;
            this.lbl_result.Text = "Result:";
            // 
            // dgv_result
            // 
            this.dgv_result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_result.Location = new System.Drawing.Point(387, 195);
            this.dgv_result.Name = "dgv_result";
            this.dgv_result.RowTemplate.Height = 23;
            this.dgv_result.Size = new System.Drawing.Size(382, 282);
            this.dgv_result.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 493);
            this.Controls.Add(this.dgv_result);
            this.Controls.Add(this.lbl_result);
            this.Controls.Add(this.btn_anlysis);
            this.Controls.Add(this.txt_input);
            this.Controls.Add(this.lbl_symbol);
            this.Controls.Add(this.lbl_prior);
            this.Controls.Add(this.dgv_prior);
            this.Controls.Add(this.lbl_syntax);
            this.Controls.Add(this.rtb_grammar);
            this.Controls.Add(this.top_menu);
            this.MainMenuStrip = this.top_menu;
            this.Name = "Form1";
            this.Text = "简单优先算法分析";
            this.top_menu.ResumeLayout(false);
            this.top_menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_prior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_result)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtb_grammar;
        private System.Windows.Forms.Label lbl_syntax;
        private System.Windows.Forms.MenuStrip top_menu;
        private System.Windows.Forms.ToolStripMenuItem files_menu;
        private System.Windows.Forms.ToolStripMenuItem importSyntaxItem;
        private System.Windows.Forms.ToolStripMenuItem saveSyntaxItem;
        private System.Windows.Forms.ToolStripMenuItem syntaxSaveAsItem;
        private System.Windows.Forms.ToolStripMenuItem closeItem;
        private System.Windows.Forms.DataGridView dgv_prior;
        private System.Windows.Forms.ToolStripMenuItem anslyse_menu;
        private System.Windows.Forms.ToolStripMenuItem priorTableItem;
        private System.Windows.Forms.ToolStripMenuItem utils_menu;
        private System.Windows.Forms.ToolStripMenuItem menuFontItem;
        private System.Windows.Forms.ToolStripMenuItem textFontItem;
        private System.Windows.Forms.ToolStripMenuItem help_menu;
        private System.Windows.Forms.ToolStripMenuItem operationItem;
        private System.Windows.Forms.ToolStripMenuItem exampleItem;
        private System.Windows.Forms.ToolStripMenuItem aboutItem;
        private System.Windows.Forms.ToolStripMenuItem buildByItem;
        private System.Windows.Forms.ToolStripMenuItem languageItem;
        private System.Windows.Forms.ToolStripMenuItem chineseItem;
        private System.Windows.Forms.ToolStripMenuItem englishItem;
        private System.Windows.Forms.Label lbl_prior;
        private System.Windows.Forms.Label lbl_symbol;
        private System.Windows.Forms.TextBox txt_input;
        private System.Windows.Forms.Button btn_anlysis;
        private System.Windows.Forms.Label lbl_result;
        private System.Windows.Forms.DataGridView dgv_result;
        private System.Windows.Forms.ToolStripMenuItem symbolAnalysisItem;
    }
}

