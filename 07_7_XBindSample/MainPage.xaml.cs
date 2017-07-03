using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace XBindSample
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class MainPage : Page
  {

    // 表示するデータ
    public SampleData SampleData { get; } = new SampleData();

    public MainPage()
    {
      this.InitializeComponent();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      this.Bindings.Update();
    }
  }
}
