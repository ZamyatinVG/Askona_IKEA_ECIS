using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Microsoft.Office.Interop.Excel;

namespace Askona_IKEA_ECIS
{
    public partial class FormMain : Form
    {
        private readonly Galaxy galaxy = new Galaxy();
        public FormMain() => InitializeComponent();
        private void FormMain_Load(object sender, EventArgs e)
        {
            StartDate.Value = DateTime.Now;
            FinishDate.Value = DateTime.Now.AddDays(7);
            this.Text += $" - {Environment.UserName} - {System.Windows.Forms.Application.ProductVersion}";
            try
            {
                StoreCB.Items.Add("ALL");
                StoreCB.SelectedIndex = 0;
                StoreCB.Items.Add("ALL(+)");
                StoreCB.Items.Add("ALL(-)");
                StoreCB.Items.Add("MAG(-)");
                StoreCB.Items.Add("MAG(0)");
                StoreCB.Items.Add("SUM");
                var stores = galaxy.IKEA_CATALOG.Select(x => x.STORE).Distinct().OrderBy(x => x).ToList();
                foreach (var store in stores)
                    StoreCB.Items.Add(store);

                ItemCB.Items.Add("ALL  |  ALL");
                ItemCB.SelectedIndex = 0;
                var items = galaxy.IKEA_CATALOG.Select(x => x.ARTNO + "  |  " + x.ARTNAME).Distinct().OrderBy(x => x).ToList();
                foreach (var item in items)
                    ItemCB.Items.Add(item);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка соединения с базой!\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
            }
        }
        private void ViewButton_Click(object sender, EventArgs e) => View_Plan();
        public void View_Plan()
        {
            try
            {
                var plandata = galaxy.IKEA_PLAN_2020.Select(x => new IKEA_PLAN_VIEW
                {
                    STORE = x.STORE,
                    ARTNO = x.ARTNO,
                    ARTNAME = x.ARTNAME,
                    DNMK_1 = x.DNMK_1,
                    DNMK_2 = x.DNMK_2,
                    DNMK_3 = x.DNMK_3,
                    AVG_DNMK = x.AVG_DNMK,
                    DNMK_FUT1 = x.DNMK_FUT1,
                    DNMK_FUT2 = x.DNMK_FUT2,
                    DNMK_FUT3 = x.DNMK_FUT3,
                    AVG_DNMK_FUT = x.AVG_DNMK_FUT,
                    SALES = x.SALES,
                    PLAN_ORDER_QNTY = x.PLAN_ORDER_QNTY,
                    STOCK_AVAILABLE = x.STOCK_AVAILABLE,
                    SUPPLY = x.SUPPLY,
                    GOODS_IN_TRANSIT = x.GOODS_IN_TRANSIT,
                    PLAN_OUT = x.PLAN_OUT,
                    MINIMUM = x.MINIMUM,
                    AVG_MAX = Math.Round(0.25 * x.MINIMUM + 0.75 * x.MAXIMUM),
                    MAXIMUM = x.MAXIMUM,
                    PLAN = x.PLAN,
                    DELTA = Math.Round(0.25 * x.MINIMUM + 0.75 * x.MAXIMUM - x.PLAN),
                    SERVICE_LEVEL = x.SERVICE_LEVEL,
                    FSALDOKOL = x.FSALDOKOL,
                    FPZKOL = x.FPZKOL,
                    FPZKOL_FUT = x.FPZKOL_FUT,
                    STARTDATE = x.STARTDATE,
                    FINISHDATE = x.FINISHDATE
                });
                if (ItemCB.Text != "ALL  |  ALL")
                    plandata = plandata.Where(x => x.ARTNO == ItemCB.Text.Substring(0, 8));
                if (StoreCB.Text == "ALL")
                { }
                else if (StoreCB.Text == "ALL(-)")
                    plandata = plandata.Where(x => x.PLAN < x.MINIMUM);
                else if (StoreCB.Text == "ALL(+)")
                    plandata = plandata.Where(x => x.PLAN > x.MAXIMUM);
                else if (StoreCB.Text == "MAG(-)")
                    plandata = plandata.Where(x => x.STOCK_AVAILABLE > x.MINIMUM);
                else if (StoreCB.Text == "MAG(0)")
                    plandata = plandata.Where(x => x.STOCK_AVAILABLE <= 0);
                else if (StoreCB.Text == "SUM")
                    plandata = plandata.GroupBy(x => new { x.ARTNO, x.ARTNAME, x.SERVICE_LEVEL, x.FSALDOKOL, x.FPZKOL, x.FPZKOL_FUT, x.STARTDATE, x.FINISHDATE })
                                        .Select(g => new IKEA_PLAN_VIEW
                                        {
                                            STORE = "SUM",
                                            ARTNO = g.Key.ARTNO,
                                            ARTNAME = g.Key.ARTNAME,
                                            DNMK_1 = g.Sum(c => c.DNMK_1),
                                            DNMK_2 = g.Sum(c => c.DNMK_2),
                                            DNMK_3 = g.Sum(c => c.DNMK_3),
                                            AVG_DNMK = g.Sum(c => c.AVG_DNMK),
                                            DNMK_FUT1 = g.Sum(c => c.DNMK_FUT1),
                                            DNMK_FUT2 = g.Sum(c => c.DNMK_FUT2),
                                            DNMK_FUT3 = g.Sum(c => c.DNMK_FUT3),
                                            AVG_DNMK_FUT = g.Sum(c => c.AVG_DNMK_FUT),
                                            SALES = g.Sum(c => c.SALES),
                                            PLAN_ORDER_QNTY = g.Sum(c => c.PLAN_ORDER_QNTY),
                                            STOCK_AVAILABLE = g.Sum(c => c.STOCK_AVAILABLE),
                                            SUPPLY = g.Sum(c => c.SUPPLY),
                                            GOODS_IN_TRANSIT = g.Sum(c => c.GOODS_IN_TRANSIT),
                                            PLAN_OUT = g.Sum(c => c.PLAN_OUT),
                                            MINIMUM = g.Sum(c => c.MINIMUM),
                                            AVG_MAX = g.Sum(c => c.AVG_MAX),
                                            MAXIMUM = g.Sum(c => c.MAXIMUM),
                                            PLAN = g.Sum(c => c.PLAN),
                                            DELTA = g.Sum(c => c.DELTA),
                                            SERVICE_LEVEL = g.Key.SERVICE_LEVEL,
                                            FSALDOKOL = g.Key.FSALDOKOL,
                                            FPZKOL = g.Key.FPZKOL,
                                            FPZKOL_FUT = g.Key.FPZKOL_FUT,
                                            STARTDATE = g.Key.STARTDATE,
                                            FINISHDATE = g.Key.FINISHDATE
                                        });
                else
                    plandata = plandata.Where(x => x.ARTNO == StoreCB.Text);
                plandata = plandata.OrderBy(x => new { x.STORE, x.ARTNO });
                PlanDataGrid.DataSource = new CustomBindingList<IKEA_PLAN_VIEW>(plandata.ToList());
                int[] width = { 35, 60, 200, 30, 30, 30, 35, 30, 30, 30, 35, 30, 70, 50, 45, 50, 50, 35, 50, 35, 65, 60, 25, 35, 35, 35, 60, 60 };
                string[] name = { "МАГ", "АРТ", "НАИМЕНОВАНИЕ", "Н1", "Н2", "Н3", "НСР", "Б1", "Б2", "Б3", "БСР", "ТЕК", "ПОТРМАГ", "НАЛИЧ",
                             "ПОСТ", "ТРАНЗ", "БУДЕТ", "MIN", "MAXСР", "MAX", "ПРОГНОЗ", "ДЕЛЬТА", "SL", "СГП", "ПЗ", "БПЗ", "НАЧАЛО", "КОНЕЦ" };
                for (int i = 0; i < PlanDataGrid.ColumnCount; i++)
                {
                    PlanDataGrid.Columns[i].Width = width[i];
                    PlanDataGrid.Columns[i].HeaderText = name[i];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных!\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void MiLoadTranzact_Click(object sender, EventArgs e)
        {
            LoadFile("Файл csv|*.csv|Все файлы|*.*",
                     2,
                     ';',
                     23,
                     "gal_asup.IKEA_TRANZACT_2020_TEMP",
                     "gal_asup.IKEA.TransferData_2020");
        }
        private void MiSupply_Click(object sender, EventArgs e)
        {
            LoadFile("Файл xls|*.xls|Все файлы|*.*",
                     5,
                     Convert.ToChar(9), //Tab
                     73,
                     "gal_asup.IKEA_SUPPLY_2020_TEMP",
                     "gal_asup.IKEA.TransferSupply_2020");
        }
        private void LoadFile(string filter, int first_row, char separator, int column_count, string temp_table, string transfer_proc)
        {
            int count = 0;
            FileBar.Maximum = 1000;
            FileBar.Visible = true;
            OpenFD.Title = "Открытие файла данных IKEA";
            OpenFD.FileName = "";
            OpenFD.Filter = filter;
            OpenFD.Multiselect = true;
            if (OpenFD.ShowDialog() != DialogResult.Cancel)
            {
                foreach (string file in OpenFD.FileNames)
                    try
                    {
                        galaxy.Database.ExecuteSqlCommand($"delete from {temp_table}");
                        StreamReader SR = new StreamReader(file);
                        string str = "";
                        for (int i = 0; i < first_row - 1; i++)
                            SR.ReadLine();
                        while (!SR.EndOfStream)
                        {
                            str = SR.ReadLine().Trim(separator);
                            //Структурирование строки из файла под SQL insert
                            str += new string(separator, column_count - 1 - str.Count(x => x == separator));
                            str = str.Replace(separator.ToString(), "', '");
                            galaxy.Database.ExecuteSqlCommand($"insert into {temp_table} values ('{str}', '{file}')");
                            count++;
                            if (count % 50 == 0)
                                if (count == FileBar.Maximum)
                                    count = FileBar.Value = 0;
                                else FileBar.Value = count;
                        }
                        galaxy.Database.ExecuteSqlCommand($"begin {transfer_proc}; end;");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка чтения файла или сохранения данных!\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                MessageBox.Show("Файл(ы) успешно загружен(ы)!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            FileBar.Visible = false;
        }
        private void CalculateButton_Click(object sender, EventArgs e)
        {
            if (StoreCB.Text != "ALL(-)" && StoreCB.Text != "ALL(+)" && StoreCB.Text != "MAG(-)"
                 && StoreCB.Text != "MAG(0)" && StoreCB.Text != "SUM")
            {
                try
                {
                    CalculateButton.Visible = false;
                    galaxy.Database.ExecuteSqlCommand($@"begin 
                                                        gal_asup.IKEA.CALCULATE_2020
                                                        (startdate => '{StartDate.Value:yyyyMMdd}',
                                                        finishdate => '{ FinishDate.Value:yyyyMMdd}',
                                                        p_store => '{StoreCB.Text}',
                                                        p_mark => {Convert.ToInt16(FullChB.Checked)});
                                                        end;");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при расчете данных!\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                CalculateButton.Visible = true;
                View_Plan();
            }
            else MessageBox.Show("Неверный параметр магазина! Допускается значение ALL или конкретный номер.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void FillColorButton_Click(object sender, EventArgs e) => FillColor_DGV(PlanDataGrid);
        public void FillColor_DGV(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                try
                {
                    dgv.Rows[i].Cells[18].Style.BackColor = Color.LightGray;
                    //если наличие меньше минимума или больше максимума
                    if (Convert.ToInt32(dgv.Rows[i].Cells[13].Value) < Convert.ToInt32(dgv.Rows[i].Cells[17].Value))
                        dgv.Rows[i].Cells[13].Style.BackColor = Color.Red;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[13].Value) > Convert.ToInt32(dgv.Rows[i].Cells[19].Value))
                        dgv.Rows[i].Cells[13].Style.BackColor = Color.LightGreen;
                    //если наличие больше максимума на 25%
                    if (Convert.ToInt32(dgv.Rows[i].Cells[13].Value) > 1.25 * Convert.ToInt32(dgv.Rows[i].Cells[19].Value))
                        dgv.Rows[i].Cells[13].Style.BackColor = Color.LightSkyBlue;
                    //если прогноз меньше минимума или больше максимума
                    if (Convert.ToInt32(dgv.Rows[i].Cells[20].Value) < Convert.ToInt32(dgv.Rows[i].Cells[17].Value))
                        dgv.Rows[i].Cells[20].Style.BackColor = Color.Red;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[20].Value) > Convert.ToInt32(dgv.Rows[i].Cells[19].Value))
                        dgv.Rows[i].Cells[20].Style.BackColor = Color.Green;
                    //если дельта положительная/отрицательная
                    if (Convert.ToInt32(dgv.Rows[i].Cells[21].Value) <= 0)
                        dgv.Rows[i].Cells[21].Style.BackColor = Color.LightGreen;
                    else dgv.Rows[i].Cells[21].Style.BackColor = Color.LightPink;
                    //если дельта к прогнозу больше 25%
                    if (4 * (Convert.ToInt32(dgv.Rows[i].Cells[21].Value)) <= -(Convert.ToInt32(dgv.Rows[i].Cells[20].Value)))
                        dgv.Rows[i].Cells[21].Style.BackColor = Color.LightSkyBlue;
                    //если есть продажи
                    if (Convert.ToInt32(dgv.Rows[i].Cells[3].Value) > 0) dgv.Rows[i].Cells[3].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[4].Value) > 0) dgv.Rows[i].Cells[4].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[5].Value) > 0) dgv.Rows[i].Cells[5].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[6].Value) > 0) dgv.Rows[i].Cells[6].Style.BackColor = Color.Goldenrod;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[7].Value) > 0) dgv.Rows[i].Cells[7].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[8].Value) > 0) dgv.Rows[i].Cells[8].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[9].Value) > 0) dgv.Rows[i].Cells[9].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[10].Value) > 0) dgv.Rows[i].Cells[10].Style.BackColor = Color.Goldenrod;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[11].Value) > 0) dgv.Rows[i].Cells[11].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[12].Value) > 0) dgv.Rows[i].Cells[12].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[14].Value) > 0) dgv.Rows[i].Cells[14].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[15].Value) > 0) dgv.Rows[i].Cells[15].Style.BackColor = Color.LightPink;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[17].Value) == 0) dgv.Rows[i].Cells[17].Style.BackColor = Color.LightSlateGray;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[19].Value) == 0) dgv.Rows[i].Cells[19].Style.BackColor = Color.LightSlateGray;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[23].Value) == 0) dgv.Rows[i].Cells[23].Style.BackColor = Color.Red;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[24].Value) == 0) dgv.Rows[i].Cells[24].Style.BackColor = Color.Red;
                    if (Convert.ToInt32(dgv.Rows[i].Cells[25].Value) == 0) dgv.Rows[i].Cells[25].Style.BackColor = Color.Red;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void ExportButton_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            Workbook ExcelWorkBook;
            Worksheet ExcelWorkSheet;
            Range ExcelRange;
            object misValue = System.Reflection.Missing.Value;
            ExcelWorkBook = ExcelApp.Workbooks.Add(misValue);
            ExcelWorkSheet = (Worksheet)ExcelWorkBook.Worksheets.get_Item(1);
            ExcelWorkSheet.Columns.HorizontalAlignment = 3;
            ExcelWorkSheet.Cells[1, 1] = "Магазин";
            ExcelWorkSheet.Cells[1, 2] = "Артикул";
            ExcelWorkSheet.Cells[1, 3] = "Наименование";
            ExcelWorkSheet.Cells[1, 4] = "1 нед. назад";
            ExcelWorkSheet.Cells[1, 5] = "2 нед. назад";
            ExcelWorkSheet.Cells[1, 6] = "3 нед. назад";
            ExcelWorkSheet.Cells[1, 7] = "Прошл. ср. продажи";
            ExcelWorkSheet.Cells[1, 8] = "1 нед. вперед";
            ExcelWorkSheet.Cells[1, 9] = "2 нед. вперед";
            ExcelWorkSheet.Cells[1, 10] = "3 нед. вперед";
            ExcelWorkSheet.Cells[1, 11] = "Буд. ср. продажи";
            ExcelWorkSheet.Cells[1, 12] = "Текущие продажи";
            ExcelWorkSheet.Cells[1, 13] = "Потр. магазина";
            ExcelWorkSheet.Cells[1, 14] = "Наличие";
            ExcelWorkSheet.Cells[1, 15] = "Поставки";
            ExcelWorkSheet.Cells[1, 16] = "Транзит";
            ExcelWorkSheet.Cells[1, 17] = "Будет";
            ExcelWorkSheet.Cells[1, 18] = "Минимум";
            ExcelWorkSheet.Cells[1, 19] = "Максимум ср.";
            ExcelWorkSheet.Cells[1, 20] = "Максимум";
            ExcelWorkSheet.Cells[1, 21] = "Прогноз";
            ExcelWorkSheet.Cells[1, 22] = "Дельта";
            ExcelWorkSheet.Cells[1, 23] = "SL";
            ExcelWorkSheet.Cells[1, 24] = "Остаток на СГП";
            ExcelWorkSheet.Cells[1, 25] = "ПЗ";
            ExcelWorkSheet.Cells[1, 26] = "Будущие ПЗ";
            ExcelWorkSheet.Cells[1, 27] = "Начало анализа";
            ExcelWorkSheet.Cells[1, 28] = "Конец анализа";
            object[,] objData = new object[PlanDataGrid.Rows.Count, PlanDataGrid.Columns.Count];
            for (int j = 0; j < PlanDataGrid.Columns.Count; j++)
                for (int i = 0; i < PlanDataGrid.Rows.Count; i++)
                    objData[i, j] = (j == 1 ? "'" : "") + PlanDataGrid.Rows[i].Cells[j].Value.ToString();
            ExcelRange = ExcelWorkSheet.get_Range("A1", misValue);
            ExcelRange = ExcelRange.get_Resize(1, PlanDataGrid.Columns.Count);
            ExcelRange.Font.Bold = true;
            ExcelRange.AutoFilter(1, ExcelRange, XlAutoFilterOperator.xlAnd, misValue, true);
            ExcelRange = ExcelWorkSheet.get_Range("A2", misValue);
            ExcelRange = ExcelRange.get_Resize(PlanDataGrid.Rows.Count, PlanDataGrid.Columns.Count);
            ExcelRange.Value2 = objData;
            ExcelRange = ExcelWorkSheet.get_Range("A1", misValue);
            ExcelRange = ExcelRange.get_Resize(PlanDataGrid.Rows.Count + 1, PlanDataGrid.Columns.Count);
            ExcelRange.Borders.LineStyle = 1;
            ExcelRange.Columns.AutoFit();
            ExcelRange.Rows.AutoFit();
            ExcelApp.Interactive = true;
            ExcelApp.ScreenUpdating = true;
            ExcelApp.Visible = true;
            ExcelApp.UserControl = true; 
        }
        private void MiMC_Click(object sender, EventArgs e)
        {
            FormMC f = new FormMC
            {
                Owner = this
            };
            f.Show();
        }
    }
}