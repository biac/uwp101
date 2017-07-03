using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ImageList
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

    // この画面に遷移してきたときに呼び出されるメソッド
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);
      
      //ShowFilesAsync();
    }

    // ［更新］ボタン
    private void Button_Click(object sender, RoutedEventArgs e)
    {
      (Application.Current as App).GetFilesAsync();
    }
  }
}
