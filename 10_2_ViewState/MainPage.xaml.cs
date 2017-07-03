using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ViewState
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

    // 赤系（既定）のViewStateに切り替える
    private void ButtonReddish_Clicked(object sender, RoutedEventArgs e)
    {
      VisualStateManager.GoToState(this, "Reddish", true);
    }

    // 青系のViewStateに切り替える
    private void ButtonBluish_Clicked(object sender, RoutedEventArgs e)
    {
      VisualStateManager.GoToState(this, "Bluish", true);
    }
  }
}
