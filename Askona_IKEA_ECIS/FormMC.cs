using System;
using System.Windows.Forms;
using System.Linq;

namespace Askona_IKEA_ECIS
{
    public partial class FormMC : Form
    {
        private readonly Galaxy galaxy = new Galaxy();
        private string operation = "";
        public FormMC() => InitializeComponent();
        private void FormMC_Load(object sender, EventArgs e) => RefreshCatalogDVG();
        private void RefreshCatalogDVG()
        {
            int selectedRow = 0;
            if (CatalogDGV.SelectedRows.Count > 0)
                selectedRow = CatalogDGV.SelectedRows[0].Index;
            int displayedRow = 0;
            if (CatalogDGV.Rows.Count > 0 && CatalogDGV.FirstDisplayedCell != null)
                displayedRow = CatalogDGV.FirstDisplayedCell.RowIndex;
            try
            {
                var items = galaxy.IKEA_CATALOG.Select(x => new IKEA_CATALOG_VIEW
                {
                    ARTNO = x.ARTNO,
                    ARTNAME = x.ARTNAME,
                    PAL_COUNT = x.PAL_COUNT,
                    PAL_TYPE = x.PAL_TYPE,
                    PRICE = x.PRICE,
                    VOLUME = Math.Round(x.VOLUME, 3)
                }).Distinct().OrderBy(x => x.ARTNO).ToList();
                CatalogDGV.DataSource = new CustomBindingList<IKEA_CATALOG_VIEW>(items.ToList());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных!\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            int[] width = { 60, 220, 35, 35, 60, 60 };
            string[] name = { "АРТ", "НАИМЕНОВАНИЕ", "КОЛ", "ТИП", "ЦЕНА", "ОБЪЕМ"};
            for (int i = 0; i < CatalogDGV.ColumnCount; i++)
            {
                CatalogDGV.Columns[i].Width = width[i];
                CatalogDGV.Columns[i].HeaderText = name[i];
            }
            if (selectedRow != 0 && selectedRow < CatalogDGV.Rows.Count)
                CatalogDGV.Rows[selectedRow].Selected = true;
            if (displayedRow != 0 && displayedRow < CatalogDGV.Rows.Count)
                CatalogDGV.FirstDisplayedScrollingRowIndex = displayedRow;
        }
        private void AddMCButton_Click(object sender, EventArgs e)
        {
            MCButtonPanel.Visible = false;
            MCPanel.Visible = true;
        }
        private void EditMCButton_Click(object sender, EventArgs e)
        {
            MCButtonPanel.Visible = false;
            MCPanel.Visible = true;
            ArtNoTB.Enabled = false;
        }
        private void RemoveMCButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                string artno = CatalogDGV.Rows[CatalogDGV.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
                try
                {
                    var items = galaxy.IKEA_CATALOG.Where(x => x.ARTNO == artno).ToList();
                    foreach (var item in items)
                        galaxy.IKEA_CATALOG.Remove(item);
                    galaxy.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления!\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    RefreshCatalogDVG();
                }
            }
        }
        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (ArtNoTB.Text.Length == 8 && int.TryParse(ArtNoTB.Text, out _) &&
                ArtNameTB.Text.Length > 5 &&
                int.TryParse(PalCountTB.Text, out _) &&
                double.TryParse(PriceTB.Text, out _) &&
                double.TryParse(VolumeTB.Text, out _))
            {
                try
                {
                    if (ArtNoTB.Enabled)
                    {
                        IKEA_CATALOG mc = galaxy.IKEA_CATALOG.Where(x => x.ARTNO == ArtNoTB.Text).FirstOrDefault();
                        if (mc != null)
                            MessageBox.Show("МЦ с данным артикулом уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            var stores = galaxy.IKEA_CATALOG.Select(x => x.STORE).Distinct().ToList();
                            foreach (var store in stores)
                            {
                                mc = new IKEA_CATALOG
                                {
                                    ARTNO = ArtNoTB.Text,
                                    ARTNAME = ArtNameTB.Text,
                                    PAL_COUNT = int.Parse(PalCountTB.Text),
                                    PAL_TYPE = PalTypeTB.Text,
                                    PRICE = double.Parse(PriceTB.Text),
                                    VOLUME = double.Parse(VolumeTB.Text)
                                };
                                mc.STORE = store;
                                galaxy.IKEA_CATALOG.Add(mc);
                            }
                        }
                    }
                    else
                    {
                        var mcList = galaxy.IKEA_CATALOG.Where(x => x.ARTNO == ArtNoTB.Text).ToList();
                        foreach (var mc in mcList)
                        {
                            mc.ARTNAME = ArtNameTB.Text;
                            mc.PAL_COUNT = int.Parse(PalCountTB.Text);
                            mc.PAL_TYPE = PalTypeTB.Text;
                            mc.PRICE = double.Parse(PriceTB.Text);
                            mc.VOLUME = double.Parse(VolumeTB.Text);
                        }
                    }
                    galaxy.SaveChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при добавлении/изменении МЦ!\n\n" + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    MCButtonPanel.Visible = true;
                    MCPanel.Visible = false;
                    ArtNoTB.Enabled = true;
                    RefreshCatalogDVG();
                }
            }
            else
                MessageBox.Show("Неверный формат вводимых данных!");
        }
        private void CancelButton_Click(object sender, EventArgs e)
        {
            MCButtonPanel.Visible = true;
            MCPanel.Visible = false;
            ArtNoTB.Enabled = true;
        }
        private void AddStoreButton_Click(object sender, EventArgs e)
        {
            StoreButtonPanel.Visible = false;
            StorePanel.Visible = true;
            operation = "ADD";
        }
        private void RemoveStoreButton_Click(object sender, EventArgs e)
        {
            StoreButtonPanel.Visible = false;
            StorePanel.Visible = true;
            operation = "REMOVE";
        }
        private void ApplyStoreButton_Click(object sender, EventArgs e)
        {
            if (KodTB.Text.Length == 3 && int.TryParse(KodTB.Text, out _))
            {
                FormMain fm = (FormMain)this.Owner;
                if (operation == "ADD")
                {
                    try
                    {
                        IKEA_CATALOG mc = galaxy.IKEA_CATALOG.Where(x => x.STORE == KodTB.Text).FirstOrDefault();
                        if (mc != null)
                            MessageBox.Show("Данный магазин уже существует!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        else
                        {
                            var mcList = galaxy.IKEA_CATALOG.Select(x => new
                            {
                                x.ARTNO,
                                x.ARTNAME,
                                x.PAL_COUNT,
                                x.PAL_TYPE,
                                x.PRICE,
                                x.VOLUME
                            }).Distinct().ToList();
                            foreach (var mcItem in mcList)
                            {
                                mc = new IKEA_CATALOG
                                {
                                    STORE = KodTB.Text,
                                    ARTNO = mcItem.ARTNO,
                                    ARTNAME = mcItem.ARTNAME,
                                    PAL_COUNT = mcItem.PAL_COUNT,
                                    PAL_TYPE = mcItem.PAL_TYPE,
                                    PRICE = mcItem.PRICE,
                                    VOLUME = mcItem.VOLUME
                                };
                                galaxy.IKEA_CATALOG.Add(mc);
                            }
                            galaxy.SaveChanges();
                        }
                        MessageBox.Show("Магазин успешно добавлен!\n\n", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fm.StoreCB.Items.Add(KodTB.Text);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка добавления магазина!\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else if (operation == "REMOVE")
                {
                    if (MessageBox.Show($"Вы действительно хотите удалить магазин {KodTB.Text}?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        try
                        {
                            var items = galaxy.IKEA_CATALOG.Where(x => x.STORE == KodTB.Text).ToList();
                            foreach (var item in items)
                                galaxy.IKEA_CATALOG.Remove(item);
                            galaxy.SaveChanges();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Ошибка удаления магазина!\n\n" + ex, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            RefreshCatalogDVG();
                        }
                    }
                    MessageBox.Show("Магазин успешно удален!", "Успешно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fm.StoreCB.Items.Remove(KodTB.Text);
                }
                StoreButtonPanel.Visible = true;
                StorePanel.Visible = false;
                operation = "";
            }
            else
                MessageBox.Show("Неверный формат вводимых данных!");
        }
        private void CancelStoreButton_Click(object sender, EventArgs e)
        {
            StoreButtonPanel.Visible = true;
            StorePanel.Visible = false;
            operation = "";
        }
        private void CatalogDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                ArtNoTB.Text = CatalogDGV.Rows[e.RowIndex].Cells[0].Value.ToString();
                ArtNameTB.Text = CatalogDGV.Rows[e.RowIndex].Cells[1].Value.ToString();
                PalCountTB.Text = CatalogDGV.Rows[e.RowIndex].Cells[2].Value.ToString();
                PalTypeTB.Text = CatalogDGV.Rows[e.RowIndex].Cells[3].Value?.ToString();
                PriceTB.Text = CatalogDGV.Rows[e.RowIndex].Cells[4].Value.ToString();
                VolumeTB.Text = CatalogDGV.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }
    }
}