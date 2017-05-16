using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace simple_prerior
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.lbl_prior.Visible = false;
            this.dgv_prior.Visible = false;
            this.lbl_symbol.Visible = false;
            this.lbl_result.Visible = false;
            this.btn_anlysis.Visible = false;
            this.txt_input.Visible = false;
            this.dgv_result.Visible = false;
        }

        OpenFileDialog openFileDialog = new OpenFileDialog();   // 打开文件对话框
        string grammar = ""; // 符号串
        string Vn = ""; // 非终结符
        string Vt = ""; // 终结符
        string VnVt = "";   // 非终结符、终结符并集
        Dictionary<string, string> priorDic = new Dictionary<string, string>(); // 优先关系表字典形式

        // 导入语法文件
        private void importSyntaxItem_Click(object sender, EventArgs e)
        {
            string fname = "";
            openFileDialog.Filter = "文本文件（*.txt)|*.txt";
            openFileDialog.Title = "打开文件";
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fname = openFileDialog.FileName;
            }
            if (fname != "")
                rtb_grammar.LoadFile(fname, RichTextBoxStreamType.PlainText);
        }

        // 保存
        private void saveSyntaxItem_Click(object sender, EventArgs e)
        {

            string fname = "";
            fname= openFileDialog.FileName;
            if (fname != "")
                rtb_grammar.SaveFile(fname, RichTextBoxStreamType.PlainText);
            else MessageBox.Show("Not found any file this belongs to");
        }

        // 另存为
        private void syntaxSaveAsItem_Click(object sender, EventArgs e)
        {
            string fname;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.RestoreDirectory = true;
            saveFileDialog.ShowDialog();
            fname = saveFileDialog.FileName;
            if (fname != "")
                rtb_grammar.SaveFile(fname, RichTextBoxStreamType.PlainText);
        }

        // 关闭应用
        private void closeItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // 设置菜单部分字体
        private void menuFontItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = top_menu.Font;
            if (fontDialog.ShowDialog() == DialogResult.OK)
                top_menu.Font = fontDialog.Font;
        }

        // 设置文本字体
        private void textFontItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Font = rtb_grammar.SelectionFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                rtb_grammar.SelectionFont = fontDialog.Font;
                lbl_syntax.Font = fontDialog.Font;
                lbl_prior.Font = fontDialog.Font;
            }
        }

        // 得到优先关系表
        private void priorTableItem_Click(object sender, EventArgs e)
        {
            priorDic.Clear();
            grammar = "";
            Vn = "";
            Vt = "";
            VnVt = "";
            grammar = rtb_grammar.Text.ToString();
            string nomeans = "\t\r\n->| ";  // 无意义字符
            for (int i = 0; i < grammar.Length; i++)
            {
                if (grammar[i] >= 'A' && grammar[i] <= 'Z')
                {
                    if (!Vn.Contains(grammar[i]))
                        Vn += grammar[i];
                }
                else if (!nomeans.Contains(grammar[i]))
                {
                    if (!Vt.Contains(grammar[i]))
                        Vt += grammar[i];
                }
            }
            VnVt = Vn + Vt;
            int lenVnVt = VnVt.Length;
            for (int i = 0; i < lenVnVt; i++)
            {
                for (int j = 0; j < lenVnVt; j++)
                {
                    priorDic.Add(VnVt[i] + "" + VnVt[j], "");
                }
                priorDic.Add("$" + VnVt[i], "<");
            }

            Dictionary<string, int> eql_dic = new Dictionary<string, int>();
            Dictionary<string, int> first_dic = new Dictionary<string, int>();
            Dictionary<string, int> last_dic = new Dictionary<string, int>();
            initRelDic(lenVnVt, eql_dic);   // 初始化等于优先关系
            initRelDic(lenVnVt, first_dic);  // 初始化低于优先关系
            initRelDic(lenVnVt, last_dic);  // 初始化高于优先关系
            Dictionary<string, int> equalRelDic = new Dictionary<string, int>();
            Dictionary<string, int> firstDic = new Dictionary<string, int>();
            Dictionary<string, int> lastDic = new Dictionary<string, int>();
            equalRelDic = getEqlRelDic(eql_dic);    // 获取等于优先关系
            firstDic = getFirstDic(first_dic);   // 获取关系first
            lastDic = getLastDic(last_dic);     // 获取关系last
            int[,] equal = Dic2Array(VnVt, equalRelDic);   // 获取等于关系数组
            int[,] first = Dic2Array(VnVt, firstDic);   // 获取first关系数组
            int[,] last = Dic2Array(VnVt, lastDic);   // 获取last关系数组
            int[,] firstPlus = warshall(first, lenVnVt);    // first+矩阵
            int[,] lastPlus = warshall(last, lenVnVt);  // last+矩阵
            int[,] firstClo = firstClosure(firstPlus, lenVnVt); // first*矩阵
            int[,] transLastPlus = lastPlusTranspose(lastPlus, lenVnVt);    // last+转置矩阵
            int[,] lower = getLowerRel(equal, firstPlus, lenVnVt);   // 计算得到低于优先关系矩阵
            int[,] upper = getUpperRel(transLastPlus, equal, firstClo, lenVnVt); // 计算高于优先关系矩阵
            fillPriorTable(equal, lower, upper, VnVt, lenVnVt);
        }

        // 填写简单优先关系表
        private void fillPriorTable(int[,] equal, int[,] lower, int[,] upper, string VnVt, int lenVnVt)
        {
            string[,] priorTab = new string[lenVnVt,lenVnVt];
            DataTable dt = new DataTable();
            for (int i = 0; i < lenVnVt; i++)
            {
                dt.Columns.Add(VnVt[i]+"", typeof(string));
            }
            for (int i = 0; i < lenVnVt; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 0; j < lenVnVt; j++)
                {
                    if (equal[i, j] == 1)
                    {
                        priorTab[i, j] = "=";
                        priorDic[VnVt[i] + "" + VnVt[j]] = "=";
                    }
                    else if (lower[i, j] == 1)
                    {
                        priorTab[i, j] = "<";
                        priorDic[VnVt[i] + "" + VnVt[j]] = "<";
                    }
                    else if (upper[i, j] == 1)
                    {
                        priorTab[i, j] = ">";
                        priorDic[VnVt[i] + "" + VnVt[j]] = ">";
                    }
                    else 
                    { 
                        priorTab[i, j] = "";
                    }
                    dr[j] = priorTab[i, j];
                }
                dt.Rows.Add(dr);
            }
            this.lbl_prior.Visible = true;
            this.dgv_prior.Visible = true;
            this.dgv_prior.DataSource = dt;
            for (int i = 0; i < lenVnVt; i++)
            {
                dgv_prior.Columns[i].Width = 30;
                dgv_prior.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv_prior.Rows[i].HeaderCell.Value = VnVt[i]+"";
            }
            dgv_prior.RowHeadersWidth = 50;
            dgv_prior.ColumnHeadersHeight = 25;
            dgv_prior.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv_prior.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgv_prior.AllowUserToAddRows = false;
            dgv_prior.ReadOnly = true;
            this.dgv_prior.RowHeadersDefaultCellStyle.Padding = new Padding(-1);
            this.lbl_symbol.Visible = true;
            this.txt_input.Visible = true;
        }

        // 计算高于优先关系
        private int[,] getUpperRel(int[,] transLastPlus, int[,] equal, int[,] firstClo, int lenVnVt)
        {
            int[,] upper = new int[lenVnVt, lenVnVt];
            upper = getLowerRel(transLastPlus, equal, lenVnVt); // 借助低于优先关系计算矩阵乘法
            upper = getLowerRel(upper, firstClo, lenVnVt);  // 借助低于优先关系计算矩阵乘法
            return upper;
        }

        // 计算低于优先关系矩阵
        private int[,] getLowerRel(int[,] equal, int[,] firstPlus, int lenVnVt)
        {
            int[,] lower = new int[lenVnVt, lenVnVt];
            for (int i = 0; i < lenVnVt; i++)
            {
                for (int j = 0; j < lenVnVt; j++)
                {
                    lower[i,j] = 0;
                    for (int k = 0; k < lenVnVt; k++)
                    {
                        lower[i, j] += equal[i, k] * firstPlus[k, j];
                    }
                }
            }
            return lower;
        }

        // 计算[last+]T
        private int[,] lastPlusTranspose(int[,] lastPlus, int lenVnVt)
        {
            int[,] transposition = new int[lenVnVt, lenVnVt];
            for (int i = 0; i < lenVnVt; i++)
            {
                for (int j = 0; j < lenVnVt; j++)
                {
                    transposition[i, j] = lastPlus[j, i];
                }
            }
            return transposition;
        }

        // 计算first*
        private int[,] firstClosure(int[,] firstPlus, int lenVnVt)
        {
            int[,] closure = new int[lenVnVt, lenVnVt];
            for (int i = 0; i < lenVnVt; i++)
            {
                for (int j = 0; j < lenVnVt; j++)
                {
                    if (i != j)
                    { 
                        closure[i, j] = firstPlus[i, j]; 
                    }
                    else
                    {
                        closure[i, j] = 1;
                    }
                }
            }
            return closure;
        }

        // warshall算法
        private int[,] warshall(int[,] arr, int lenVnVt)
        {
            int[,] toPlus = new int[lenVnVt, lenVnVt];
            for (int i = 0; i < lenVnVt; i++)
            {
                for (int j = 0; j < lenVnVt; j++)
                {
                    toPlus[i, j] = arr[i, j];
                }
            }
            for (int i = 0; i < lenVnVt; i++)
            {
                for (int j = 0; j < lenVnVt; j++)
                {
                    if (toPlus[j,i] == 1)
                    {
                        for (int k = 0; k < lenVnVt; k++)
                        {
                            if (toPlus[i,k]==1)
                            {
                                toPlus[j, k] = 1;
                            }
                        }
                    }
                }
            }
            return toPlus;
        }

        // 字典类型转数组
        private int[,] Dic2Array(string VnVt, Dictionary<string, int> dic)
        {
            int lenVnVt = VnVt.Length;
            int[,] arrRel = new int[lenVnVt, lenVnVt];
            for (int i = 0; i < lenVnVt; i++)
            {
                for (int j = 0; j < lenVnVt; j++)
                {
                    arrRel[i, j] = dic[VnVt[i] + "" + VnVt[j]];
                }
            }
            return arrRel;
        }

        // 获取关系last
        private Dictionary<string, int> getLastDic(Dictionary<string, int> relDic)
        {
            Dictionary<string, int> lastDic = relDic;
            string[] syntax = grammar.Split('\n');
            for (int i = 0; i < syntax.Length; i++)
            {
                syntax[i] = syntax[i].Replace('\r', '\0');
                int lenSyntax = syntax[i].Length;
                lastDic[syntax[i][0] + "" + syntax[i][lenSyntax - 1]] = 1;
                for (int j = lenSyntax - 1; j > 0; j--)
                {
                    if (syntax[i][j] == '|')
                    {
                        lastDic[syntax[i][0] + "" + syntax[i][j - 1]]=1;
                    }
                }
            }
            return lastDic;
        }

        // 获取关系first
        private Dictionary<string, int> getFirstDic(Dictionary<string, int> relDic)
        {
            Dictionary<string, int> firstDic = relDic;
            string[] syntax = grammar.Split('\n');
            for (int i = 0; i < syntax.Length; i++)
            {
                syntax[i] = syntax[i].Replace('\r', '\0');
                firstDic[syntax[i][0] + "" + syntax[i][3]] = 1;
                for (int j = 3; j < syntax[i].Length-1; j++)
                {
                    if (syntax[i][j] == '|')
                    {
                        firstDic[syntax[i][0] + "" + syntax[i][j + 1]] = 1;
                    }
                }
            }
            return firstDic;
        }

        // 获取等于优先关系
        private Dictionary<string, int> getEqlRelDic(Dictionary<string, int> relDic)
        {
            Dictionary<string, int> equalRelDic = relDic;
            string[] syntax = grammar.Split('\n');
            for (int i = 0; i < syntax.Length; i++)
            {
                syntax[i] = syntax[i].Remove(0, 3);
                syntax[i] = syntax[i].Replace('\r','\0');
            }
            for (int i = 0; i < syntax.Length; i++)
            {
                for (int j = 0; j < syntax[i].Length - 1; j++)
                {
                    if (syntax[i][j] != '|' && syntax[i][j + 1] != '|')
                    {
                        equalRelDic[syntax[i][j] + "" + syntax[i][j + 1]] = 1;
                    }
                }
            }
            return equalRelDic;
        }

        // 初始化简单优先关系
        private void initRelDic(int lenVnVt, Dictionary<string, int> relDic)
        {
            for (int i = 0; i < lenVnVt; i++)
            {
                for (int j = 0; j < lenVnVt; j++)
                {
                    relDic.Add(VnVt[i] + "" + VnVt[j], 0);
                }
            }
        }

        // 符号串分析
        private void btn_anlysis_Click(object sender, EventArgs e)
        {
            analysisProcess();
        }

        // 分析过程
        private void analysisProcess()
        {
            string inputString = getInputString(); // 获取输入串
            string tmp = "";
            List<Process> proList = new List<Process>();
            Process pro1 = new Process();
            string symbolStack = "$";
            string relationship = "<";
            string inputStr = inputString;
            string generator = "";
            pro1.Step = 1;
            pro1.Symbol = symbolStack;
            pro1.Relation = relationship;
            pro1.Input = inputStr;
            pro1.Generator = generator;
            proList.Add(pro1);
            for (int i = 2; ; i++)
            {
                if (relationship == "<" | relationship == "=")
                {
                    symbolStack += inputStr[0] + "";
                    inputStr = inputStr.Substring(1);
                }
                else if (relationship == ">")
                {
                    if (generator != "" && generator != "error")
                    {
                        symbolStack = symbolStack.Substring(0, symbolStack.Length - tmp.Length);
                        symbolStack += generator[0];
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    relationship = "error";
                    break;
                }

                if (symbolStack != "$" + VnVt[0])
                {
                    if (inputStr != "$")
                    {
                        relationship = priorDic[symbolStack[symbolStack.Length - 1] + "" + inputStr[0]];
                    }
                    else
                    {
                        relationship = ">";
                    }
                    Process pro = new Process();
                    pro.Step = i;
                    pro.Symbol = symbolStack;
                    pro.Relation = relationship;
                    pro.Input = inputStr;
                    generator = "";
                    if (relationship == ">")
                    {
                        tmp = "";
                        for (int k = symbolStack.Length - 1; k > 0; k--)
                        {
                            tmp = symbolStack[k] + tmp;
                            if (priorDic[symbolStack[k - 1] + "" + symbolStack[k]] == "<")
                            {
                                break;
                            }
                        }
                        generator = getGenerator(tmp);  // 获取产生式
                    }
                    pro.Generator = generator;
                    proList.Add(pro);
                }
                else
                {
                    relationship = "OK";
                    Process pro = new Process();
                    pro.Step = i;
                    pro.Symbol = symbolStack;
                    pro.Relation = relationship;
                    pro.Input = inputStr;
                    pro.Generator = "";
                    proList.Add(pro);
                    break;
                }
            }
            setResultStyle(proList);
        }

        // 设置结果样式
        private void setResultStyle(List<Process> proList)
        {
            this.lbl_result.Visible = true;
            this.dgv_result.Visible = true;
            dgv_result.DataSource = proList;
            dgv_result.Columns[0].HeaderText = "步骤";
            dgv_result.Columns[1].HeaderText = "符号栈S";
            dgv_result.Columns[2].HeaderText = "关系";
            dgv_result.Columns[3].HeaderText = "输入串TR";
            dgv_result.Columns[4].HeaderText = "产生式";
            this.dgv_result.AllowUserToAddRows = false;
            dgv_result.ReadOnly = true;
            dgv_result.RowHeadersVisible = false;
            for (int i = 0; i < 5; i++)
            {
                dgv_result.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dgv_result.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dgv_result.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgv_result.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgv_result.Columns[0].Width = 50;
            dgv_result.Columns[1].Width = 100;
            dgv_result.Columns[2].Width = 50;
            dgv_result.Columns[3].Width = 100;
            dgv_result.Columns[4].Width = 60;
            dgv_result.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // 获取产生式
        private string getGenerator(string tmp)
        {
            string generator = "";
            string[] syntax = grammar.Split('\n');
            int count_syntax = syntax.Length;
            for (int i = 0; i < count_syntax; i++)
            {
                syntax[i].Replace('\r', '\0');
            }
            for (int i = 0; i < count_syntax; i++)
            {
                string[] oneSyntax = syntax[i].Split('>');
                string[] oneSyntaxRight = oneSyntax[1].Split('|');
                for (int j = 0; j < oneSyntaxRight.Length; j++)
                {
                    if (tmp == oneSyntaxRight[j])
                    {
                        return syntax[i][0] + "" + syntax[i][1] + "" + syntax[i][2] + tmp;
                    }
                }
            }
            generator = "error";
            return generator;
        }

        // 初始化输入串
        private string getInputString()
        {
            string inputStr = "";
            inputStr = txt_input.Text.Trim().ToString();
            if (inputStr[inputStr.Length - 1] != '$')
            {
                inputStr += "$";
            }
            return inputStr;
        }

        // 符号串分析
        private void symbolAnalysisItem_Click(object sender, EventArgs e)
        {
            analysisProcess();
        }

        // 符号串文本控件监听事件
        private void txt_input_TextChanged(object sender, EventArgs e)
        {
            if (txt_input.Text.Trim().ToString() != "")
            {
                this.btn_anlysis.Visible = true;
            }
            else
            {
                this.btn_anlysis.Visible = false;
            }
        }

        // about(关于)介绍事件
        private void aboutItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This a syntax anlysis procedure" 
            + "that based on means of simple precedence anlysis.\n" + 
            "Current Version:v1.0.0\nBuild Time:2017-05-16", "About");
        }

        // belongs to
        private void buildByItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Build By: Zuoxy");
        }

        // 操作方法
        private void operationItem_Click(object sender, EventArgs e)
        {
            string info = "Step 1:File->Import File, import text of grammar. Can also edit grammar directly.\n"+
                "Step 2:Analysis->Prior Table, get table of prior relationship\n"+
                "Step 3:Input string\n"+
                "Step 4:Start Analysis or Analsis->Analysis Symbol";
            MessageBox.Show(info, "Operation Declaration");
        }

        // 示例
        private void exampleItem_Click(object sender, EventArgs e)
        {

        }

    }
}
