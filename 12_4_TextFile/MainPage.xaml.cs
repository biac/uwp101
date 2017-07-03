using System;
using Windows.ApplicationModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace TextFile
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class MainPage : Page
  {
    // テキストファイルの名前
    const string UserTextFileName = "Sample.txt";

    // データバインディング用
    // 表示／編集するテキスト
    private string DisplayText { get; set; } = "(TEST)";
    // テキストファイルのパス
    private string FilePath { get; set; } = "(NO FILE)";



    public MainPage()
    {
      this.InitializeComponent();
    }



    protected override async void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);

      await LoadTextAsync();
      Bindings.Update();

      App.Current.Suspending += Current_Suspending;
    }

    // 画面遷移をする場合は、その時にもデータを保存する
    protected override async void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {
      base.OnNavigatingFrom(e);

      App.Current.Suspending -= Current_Suspending;

      await SaveTextAsync();
      //Bindings.Update(); // もう画面はなくなるのでUpdate不要
    }



    private async void ButtonSaveClicked(object sender, RoutedEventArgs e)
    {
      await SaveTextAsync();
      Bindings.Update(); // FilePathはOneTimeなので、Update必要
    }

    // 中断または終了されるときには、データ保存
    private async void Current_Suspending(object sender, SuspendingEventArgs e)
    {
      var deferral = e.SuspendingOperation.GetDeferral(); // 中断処理開始宣言

      await SaveTextAsync();
      Bindings.Update(); // また再開されるかもしれないのでUpdate必要

      deferral.Complete(); // 中断処理完了宣言
    }



    private async System.Threading.Tasks.Task LoadTextAsync()
    {
      // ファイルを取得（存在していなかったらnull）
      var file = await Windows.Storage.ApplicationData.Current.LocalFolder
                        .TryGetItemAsync(UserTextFileName)
                  as Windows.Storage.IStorageFile;

      // 取得したファイルのパスを画面に表示
      FilePath = (file?.Path) ?? "(NO FILE)";

      if (file == null)
        return;

      // ファイルの内容を読み取って画面に表示
      DisplayText = await Windows.Storage.FileIO.ReadTextAsync(file);
    }



    private async System.Threading.Tasks.Task SaveTextAsync()
    {
      // ファイルを作成（存在していたらオープン）
      var file = await Windows.Storage.ApplicationData.Current.LocalFolder
                        .CreateFileAsync(UserTextFileName,
                          Windows.Storage.CreationCollisionOption.OpenIfExists);

      // ファイルを上書きする
      await Windows.Storage.FileIO.WriteTextAsync(file, DisplayText);

      // 保存したファイルのパスを画面に表示
      FilePath = file.Path;
    }

  }
}
