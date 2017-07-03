using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Navigation
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class Page2 : Page
  {
    public Page2()
    {
      this.InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      this.Frame.Navigate(typeof(MainPage));
    }



#if DEBUG
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      System.Diagnostics.Debug.WriteLine("Page2: OnNavigatedTo");
    }
    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
      base.OnNavigatingFrom(e);
      System.Diagnostics.Debug.WriteLine("Page2: OnNavigatingFrom");
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      base.OnNavigatedFrom(e);
      System.Diagnostics.Debug.WriteLine("Page2: OnNavigatedFrom");
    }
#endif
  }
}
