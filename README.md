# How-to-apply-SelectedRowTextColor-to-the-cells-of-a-DataGridTemplateColumn-in-MAUI-DataGrid

As per the current implementation of the MAUI SfDataGrid, the [SelectedRowTextColor](https://help.syncfusion.com/cr/maui/Syncfusion.Maui.DataGrid.DataGridStyle.html#Syncfusion_Maui_DataGrid_DataGridStyle_SelectedRowTextColor) would not apply to the cells of [DataGridTemplateColumn](https://help.syncfusion.com/maui/datagrid/column-types#datagridtemplatecolumn). This article illustrates how to apply `SelectedRowTextColor` for DataGridTemplateColumn cells in a [.NET MAUI DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

* Initialize the [SfDataGrid](https://help.syncfusion.com/maui/datagrid/getting-started) with the required properties, such as `ItemsSource`, `SelectedRowTextColor` in the `SfDataGrid.DefaultStyle`, and use `DataGridTemplateColumn` for the required columns.

* Write a custom renderer class that extends from the `DataGridCellTemplateRenderer` class. In the overridden `OnSetCellStyle` method, check if the respective row is present in `DataGrid.SelectedRows`. If it is, set the `SelectedRowTextColor` for the content of the `DataGridTemplateColumn` cell; otherwise, set the `RowTextColor` to the text color of the content.

* To register the custom cell template renderer with the `SfDataGrid.CellRenderers` collection, remove the existing entry by its key and then add a new entry with the same key, along with an instance of the custom renderer.

**XMAL**

 
 ```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:local="clr-namespace:MauiApp1"
             xmlns:dataGrid="clr-namespace:Syncfusion.Maui.DataGrid;assembly=Syncfusion.Maui.DataGrid"
             x:Class="MauiApp1.MainPage">
    <ContentPage.BindingContext>
        <local:OrderInfoRepository x:Name="viewModel"/>
    </ContentPage.BindingContext>

    <dataGrid:SfDataGrid x:Name="dataGrid"
                         ItemsSource="{Binding OrderInfoCollection}" 
                         SelectionMode="Single"
                         ColumnWidthMode="Auto">
        <dataGrid:SfDataGrid.DefaultStyle>
            <dataGrid:DataGridStyle SelectedRowTextColor="Red">
            </dataGrid:DataGridStyle>
        </dataGrid:SfDataGrid.DefaultStyle>
        <dataGrid:SfDataGrid.Columns>
            <dataGrid:DataGridTemplateColumn HeaderText="Order ID" MappingName="OrderID">
                <dataGrid:DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <Label Text="{Binding OrderID}"/>
                    </DataTemplate>
                </dataGrid:DataGridTemplateColumn.CellTemplate>
            </dataGrid:DataGridTemplateColumn>
        </dataGrid:SfDataGrid.Columns>
    </dataGrid:SfDataGrid>
</ContentPage>

 ```

**MainPage.xaml.cs**

 
 ```C#
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
                    Label sfLabel = dataColumn.ColumnElement?.Content as Label;
                    if (sfLabel != null)
                    {
                        sfLabel.TextColor = gridStyle?.SelectedRowTextColor;
                    }
                }
                else
                {
                    gridCell.TextColor = gridStyle?.RowTextColor;
                    Label sfLabel = dataColumn.ColumnElement?.Content as Label;
                    if (sfLabel != null)
                    {
                        sfLabel.TextColor = gridStyle?.RowTextColor;
                    }
                }
            }
        }
    }
}

 ```

