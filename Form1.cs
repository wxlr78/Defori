using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsShingles
{
    public partial class MainForm : Form
    {
        string? verifiablePath = null;
        string? comparablePath = null;

        List<string> verifiableFilesPaths = new List<string>();
        List<string> comparableFilesPaths = new List<string>();

        List<string> verifiableFilesNames = new List<string>();
        List<string> comparableFilesNames = new List<string>();

        List<string> extensions = new List<string>();

        int shingleLength = 0;
        bool shingleOverlay = false;

        List<List<Comparison>> reports = new List<List<Comparison>>();

        public MainForm()
        {
            InitializeComponent();
            FileExtensionDocxCheck.Checked = true;
            FileExtensionDocCheck.Checked = true;
            FileExtensionOdtCheck.Checked = true;
            FileExtensionTxtCheck.Checked = true;
            BalancedCheck.Checked = true;
        }

        private void FillFiles(List<string> fp, List<string> fn, ListBox lb, string path)
        {
            List<FileInfo> fi = GetFilesFromPath(path);
            FillFilesPaths(fp, fn, fi);
            FillFilesList(lb, fi);

            void FillFilesPaths(List<string> fp, List<string> fn, List<FileInfo> fi)
            {
                fp.Clear();
                fn.Clear();
                foreach (FileInfo file in fi)
                {
                    fp.Add(file.FullName);
                    fn.Add(file.Name);
                }
            }

            void FillFilesList(ListBox lb, List<FileInfo> fi)
            {
                lb.Items.Clear();
                foreach (FileInfo file in fi)
                {
                    lb.Items.Add(file.Name);
                }
            }

            List<FileInfo> GetFilesFromPath(string path)
            {
                List<FileInfo> allFiles = new DirectoryInfo(path).EnumerateFiles().ToList();
                List<FileInfo> resultFiles = new List<FileInfo>();

                foreach (FileInfo file in allFiles)
                {
                    if (extensions.Contains(file.Extension))
                    {
                        resultFiles.Add(file);
                    }
                }

                return resultFiles;
            }
        }

        private void SwitchCheckBox(string extension)
        {
            if (extensions.Contains(extension))
            {
                extensions.Remove(extension);
            }
            else
            {
                extensions.Add(extension);
            }

            if (verifiablePath != null)
            {
                FillFiles(verifiableFilesPaths, verifiableFilesNames, VerifiableFilesList, verifiablePath);
                VerifiableFilesTitleLabel.Text = $"œÓ‚ÂˇÂÏ˚Â Ù‡ÈÎ˚ ({VerifiableFilesList.Items.Count}):";
            }

            if (comparablePath != null)
            {
                FillFiles(comparableFilesPaths, comparableFilesNames, —omparableFilesList, comparablePath);
                —omparableFilesTitleLabel.Text = $"—‡‚ÌË‚‡ÂÏ˚Â Ù‡ÈÎ˚ ({—omparableFilesList.Items.Count}):";
            }
        }

        private void SelectVerifiablePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                verifiablePath = FBD.SelectedPath;

                FillFiles(verifiableFilesPaths, verifiableFilesNames, VerifiableFilesList, verifiablePath);
                
                VerifiablePathLabel.Text = FBD.SelectedPath;
                VerifiableFilesTitleLabel.Text = $"œÓ‚ÂˇÂÏ˚Â Ù‡ÈÎ˚ ({VerifiableFilesList.Items.Count}):";
            }
        }

        private void SelectComparablePathButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FBD = new FolderBrowserDialog();
            if (FBD.ShowDialog() == DialogResult.OK)
            {
                comparablePath = FBD.SelectedPath;

                FillFiles(comparableFilesPaths, comparableFilesNames, —omparableFilesList, comparablePath);

                —omparablePathLabel.Text = FBD.SelectedPath;
                —omparableFilesTitleLabel.Text = $"—‡‚ÌË‚‡ÂÏ˚Â Ù‡ÈÎ˚ ({—omparableFilesList.Items.Count}):";
            }
        }

        private void FileExtensionDocxCheck_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBox(".docx");
        }

        private void FileExtensionDocCheck_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBox(".doc");
        }

        private void FileExtensionOdtCheck_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBox(".odt");
        }

        private void FileExtensionTxtCheck_CheckedChanged(object sender, EventArgs e)
        {
            SwitchCheckBox(".txt");
        }

        private void QuickCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (QuickCheck.Checked)
            {
                shingleLength = 20;
                shingleOverlay = false;
            }
        }

        private void BalancedCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (BalancedCheck.Checked)
            {
                shingleLength = 3;
                shingleOverlay = true;
            }
        }

        private void AccurateCheck_CheckedChanged(object sender, EventArgs e)
        {

            if (AccurateCheck.Checked)
            {
                shingleLength = 2;
                shingleOverlay = true;
            }
        }
        private void Start_Click(object sender, EventArgs e)
        {
            if (verifiablePath != null &&
                comparablePath != null &&
                verifiableFilesPaths != null &&
                comparableFilesPaths != null)
            {
                ResultDataGrid.Rows.Clear();
                ResultDataGrid.Columns.Clear();
                ResultDataGrid.Columns.Add("Num", "π");
                ResultDataGrid.Columns.Add("File", "‘‡ÈÎ");
                ResultDataGrid.Columns.Add("Author", "¿‚ÚÓ");
                ResultDataGrid.Columns.Add("Creation", "—ÓÁ‰‡Ì");
                ResultDataGrid.Columns.Add("Editing", "»ÁÏÂÌÂÌ");
                ResultDataGrid.Columns.Add("EditTime", "–Â‰‡ÍÚËÓ‚‡Ì");
                ResultDataGrid.Columns.Add("Originality", "ŒË„ËÌ‡Î¸ÌÓÒÚ¸");
                var button = new DataGridViewButtonColumn();
                button.HeaderText = "ŒÚ˜ÂÚ";
                button.Text = "ŒÚÍ˚Ú¸";
                button.UseColumnTextForButtonValue = true;
                ResultDataGrid.Columns.Add(button);

                ResultDataGrid.Columns[0].Width = 30;

                int n = 1;
                foreach (string veriFilePath in verifiableFilesPaths)
                {
                    bool creatorMatch = false;
                    bool createdMatch = false;
                    bool editedMatch = false;
                    bool editTimeMatch = false;

                    double orig = 100;
                    string[] result = new string[] { "", "", "", "", "", "", "" };
                    List<Comparison> temp = new List<Comparison>();

                    foreach (string compFilePath in comparableFilesPaths)
                    {
                        if (veriFilePath != compFilePath)
                        {
                            string dictPath = @"opencorpora.db";

                            Comparison comp = new Comparison(veriFilePath, compFilePath, dictPath, shingleLength, shingleOverlay);
                            temp.Add(comp);

                            if (comp.Result < orig)
                            {
                                orig = comp.Result;

                                string num = n.ToString();
                                string verifiable = comp.Verifiable.Info.Name + '.' + comp.Verifiable.Info.Extension;

                                string author = "";
                                string creation = "";
                                string editing = "";
                                string editTime = "";

                                if (comp.Verifiable.Info.Extension == "docx")
                                {
                                    author = comp.Verifiable.Info.Creator;
                                    creation = comp.Verifiable.Info.Created;
                                    editing = comp.Verifiable.Info.Edited;
                                    editTime = comp.Verifiable.Info.EditTime + " ÏËÌÛÚ";
                                } else
                                {
                                    author = "ÕÂËÁ‚ÂÒÚÂÌ";
                                    creation = "ÕÂËÁ‚ÂÒÚÌÓ";
                                    editing = "ÕÂËÁ‚ÂÒÚÌÓ";
                                    editTime = "ÕÂËÁ‚ÂÒÚÌÓ";
                                }

                                string originality = comp.Result.ToString("0.00") + '%';

                                result = new string[] {
                                    num,
                                    verifiable,
                                    author,
                                    creation,
                                    editing,
                                    editTime,
                                    originality
                                };
                            }

                            if (comp.Comparable.Info.Creator == comp.Verifiable.Info.Creator && comp.Comparable.Info.Creator != null)
                            {
                                creatorMatch = true;
                            }

                            if (comp.Comparable.Info.Created == comp.Verifiable.Info.Created && comp.Comparable.Info.Created != null)
                            {
                                createdMatch = true;
                            }

                            if (comp.Comparable.Info.Edited == comp.Verifiable.Info.Edited && comp.Comparable.Info.Edited != null)
                            {
                                editedMatch = true;
                            }

                            if (comp.Comparable.Info.EditTime == comp.Verifiable.Info.EditTime && comp.Comparable.Info.EditTime != null)
                            {
                                editTimeMatch = true;
                            }
                        }

                        
                    }
                    n++;
                    ResultDataGrid.Rows.Add(result);
                    if (creatorMatch)
                        ResultDataGrid.Rows[ResultDataGrid.Rows.Count - 1].Cells[2].Style.BackColor = Color.Red;
                    if (createdMatch)
                        ResultDataGrid.Rows[ResultDataGrid.Rows.Count - 1].Cells[3].Style.BackColor = Color.Red;
                    if (editedMatch)
                        ResultDataGrid.Rows[ResultDataGrid.Rows.Count - 1].Cells[4].Style.BackColor = Color.Red;
                    if (editTimeMatch)
                    {
                        ResultDataGrid.Rows[ResultDataGrid.Rows.Count - 1].Cells[5].Style.BackColor = Color.Red;
                    }
                    reports.Add(temp);
                }
            }
        }

        private void ResultDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                Form2 v = new Form2(reports[e.RowIndex]);
                v.Show();
            }
        }
    }
}