using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using JianLi3Data;

namespace JianLi3.views
{
    /// <summary>
    /// BookListView.xaml 的交互逻辑
    /// </summary>
    public partial class BookListView : UserControl
    {
        public BookListView()
        {
            InitializeComponent();
            var p = from b in JianLiLinq.Default.DB.Books
                    where b.BookName.ToUpper().Contains("W")
                    select b;
            this.listBox1.ItemsSource = p;
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
    [ValueConversion(typeof(System.Data.Linq.Binary), typeof(System.Windows.Media.Imaging.BitmapSource))]
    public class BinaryToBitmapConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
                return null;

            System.IO.MemoryStream ms = new System.IO.MemoryStream(((System.Data.Linq.Binary)value).ToArray());
            System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(ms);
            System.Windows.Media.Imaging.BitmapSource bitmapSource = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                bitmap.GetHbitmap(),
                IntPtr.Zero,
                Int32Rect.Empty,
                System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            return bitmapSource;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
