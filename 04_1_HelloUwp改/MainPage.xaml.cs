using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace HelloUwp
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      TextBlock1.Text = DateTimeOffset.Now.ToString("HH:mm:ss");
    }
  }
}
