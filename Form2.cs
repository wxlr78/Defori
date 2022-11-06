using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsShingles
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(List<Comparison> comps)
        {
            InitializeComponent();
            this.Text = comps[0].Verifiable.Info.Path;

            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Num", "№");
            dataGridView1.Columns.Add("File", "Файл");
            dataGridView1.Columns.Add("Author", "Автор");
            dataGridView1.Columns.Add("Creation", "Создан");
            dataGridView1.Columns.Add("Editing", "Изменен");
            dataGridView1.Columns.Add("EditTime", "Редактирован");
            dataGridView1.Columns.Add("Originality", "Оригинальность");

            int n = 1;
            foreach (Comparison c in comps)
            {
                string[] result = new string[] { "", "", "", "", "", "", "" };
                string num = n.ToString();
                string comparable = c.Comparable.Info.Name + '.' + c.Comparable.Info.Extension;

                string author = "";
                string creation = "";
                string editing = "";
                string editTime = "";

                if (c.Comparable.Info.Extension == "docx")
                {
                    author = c.Comparable.Info.Creator;
                    creation = c.Comparable.Info.Created;
                    editing = c.Comparable.Info.Edited;
                    editTime = c.Comparable.Info.EditTime + " минут";
                }
                else
                {
                    author = "Неизвестен";
                    creation = "Неизвестно";
                    editing = "Неизвестно";
                    editTime = "Неизвестно";
                }

                string originality = c.Result.ToString("0.00") + '%';

                result = new string[] {
                                    num,
                                    comparable,
                                    author,
                                    creation,
                                    editing,
                                    editTime,
                                    originality
                                };

                dataGridView1.Rows.Add(result);

                if (c.Comparable.Info.Creator == c.Verifiable.Info.Creator && c.Comparable.Info.Creator != null)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[2].Style.BackColor = Color.Red;
                }

                if (c.Comparable.Info.Created == c.Verifiable.Info.Created && c.Comparable.Info.Created != null)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[3].Style.BackColor = Color.Red;
                }

                if (c.Comparable.Info.Edited == c.Verifiable.Info.Edited && c.Comparable.Info.Edited != null)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[4].Style.BackColor = Color.Red;
                }

                if (c.Comparable.Info.EditTime == c.Verifiable.Info.EditTime && c.Comparable.Info.EditTime != null)
                {
                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[5].Style.BackColor = Color.Red;
                }
                n++;
            }
        }
    }
}
