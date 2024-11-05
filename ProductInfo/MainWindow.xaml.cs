using System.Globalization;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;

namespace ProductInfo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        string getJson = File.ReadAllText( @"C:\Users\ITA5-TN05\Desktop\Produkte.json" );

        comboboxCatgories.ItemsSource = JsonSerializer.Deserialize<List<ProductCategory>>( getJson );

        comboboxCatgories.SelectedIndex = 0;
    }

    private void cbSelectionChanged( object sender , SelectionChangedEventArgs e )
    {
        ProductCategory? currentCategory = comboboxCatgories.SelectedItem as ProductCategory;

        if ( currentCategory != null )
            listboxProducts.ItemsSource = currentCategory.Products;
    }

    private void lbSelectionChanged( object sender , SelectionChangedEventArgs e )
    {
        Product? currentProduct = listboxProducts.SelectedItem as Product;

        if ( currentProduct != null )
        {
            textboxProductName.Text = currentProduct.Name;
            textboxPrice.Text = $"{currentProduct.Price.ToString( "C" , CultureInfo.CurrentCulture )}";
        }
    }
}