
using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.Inputs;

namespace MauiApp1
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            dataGrid.CellRenderers.Remove("Template");
            dataGrid.CellRenderers.Add("Template", new CustomDataGridCellTemplateRenderer());

        }
    }

    public class CustomDataGridCellTemplateRenderer : DataGridCellTemplateRenderer
    {
        protected override void OnSetCellStyle(DataColumnBase dataColumn)
        {
            base.OnSetCellStyle(dataColumn);

            if (dataColumn?.DataGridColumn != null)
            {
                var gridStyle = this.DataGrid?.DefaultStyle;
                DataGridCell gridCell = dataColumn.ColumnElement as DataGridCell;

                if (this.DataGrid.SelectedRows.Any(row => row == dataColumn.RowData))
                {
                    gridCell.TextColor = gridStyle?.SelectedRowTextColor;
                    SfNumericEntry sfLabel = dataColumn.ColumnElement?.Content as SfNumericEntry;
                    if (sfLabel != null)
                    {
                        sfLabel.TextColor = gridStyle?.SelectedRowTextColor;
                    }
                }
                else
                {
                    gridCell.TextColor = gridStyle?.RowTextColor;
                    SfNumericEntry sfLabel = dataColumn.ColumnElement?.Content as SfNumericEntry;
                    if (sfLabel != null)
                    {
                        sfLabel.TextColor = gridStyle?.RowTextColor;
                    }
                }
            }
        }
    }
}



