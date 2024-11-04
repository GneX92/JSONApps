using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProductInfo;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        string getjson = File.ReadAllText( @"C:\Users\ITA5-TN05\Desktop\Produkte.json" );
        List<ProductCategory> categories = JsonSerializer.Deserialize<List<ProductCategory>>( getjson );
        comboboxCatgories.ItemsSource = categories;
        comboboxCatgories.DisplayMemberPath = "CategoryName";
    }

    private void cbSelectionChanged( object sender , SelectionChangedEventArgs e )
    {
        ProductCategory current = comboboxCatgories.SelectedItem as ProductCategory;

        listboxProducts.ItemsSource = current.Products;
    }

    private void lbSelectionChanged( object sender , SelectionChangedEventArgs e )
    {
        Product current = listboxProducts.SelectedItem as Product;
        textboxProductName.Text = current.Name;
        textboxPrice.Text = current.Price.ToString();
    }
}