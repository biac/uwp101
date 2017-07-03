using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace Navigation
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
      this.Frame.Navigate(typeof(Page2));
    }



#if DEBUG
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      System.Diagnostics.Debug.WriteLine("MainPage: OnNavigatedTo");
      // Page2.xaml.csでは、上の「MainPage」を「Page2」に変えてください（以下同じ）
    }
    protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
      base.OnNavigatingFrom(e);
      System.Diagnostics.Debug.WriteLine("MainPage: OnNavigatingFrom");
    }
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
      base.OnNavigatedFrom(e);
      System.Diagnostics.Debug.WriteLine("MainPage: OnNavigatedFrom");
    }
#endif
  }
}
