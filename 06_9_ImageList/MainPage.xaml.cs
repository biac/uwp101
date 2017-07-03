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

    //// ピクチャ フォルダーの中のファイル名一覧を表示する
    //async void ShowFilesAsync()
    //{
    //  // ピクチャ フォルダーを表すStorageFolderオブジェクト
    //  Windows.Storage.StorageFolder folder
    //    = Windows.Storage.KnownFolders.PicturesLibrary;

    //  // フォルダー内のファイル一覧を取得する
    //  // ※ 非同期API
    //  IReadOnlyList<Windows.Storage.StorageFile> files
    //    = await folder.GetFilesAsync();

    //  //// 拡張子順にソートし、ファイル名だけを取り出す（LINQ）
    //  //IEnumerable<string> fileNames
    //  //  = files.OrderBy(f => f.FileType)
    //  //          .Select(f => f.Name);

    //  // ListViewにファイル名を表示する
    //  //ListView1.ItemsSource = fileNames;
    //  this.DataContext = files.OrderBy(f => f.FileType);
    //}
  }
}
