using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ImageViewer
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
      // インストールフォルダーにある画像を表示する
      // 画像ファイルのパス：Assets/Square150x150Logo.scale-200.png

      // ファイル名中の「.scale-200」は指定しなくてもよい
      // 指定しなければ、最適な解像度のファイルを自動的に選んでくれる
      var fileUri = "ms-appx:///Assets/Square150x150Logo.png";

      // BitmapImageオブジェクトを作り、ImageコントロールのSourceプロパティにセットする
      Image1.Source = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri(fileUri));
    }

    private async void Button_Click_1(object sender, RoutedEventArgs e)
    {
      // ユーザーが選んだ画像を表示する
      // 画像例：C:\Windows\Web\Wallpaper

      // FileOpenPickerを用意する
      var openPicker = new Windows.Storage.Pickers.FileOpenPicker();
      // 表示モード：リスト／サムネイル
      openPicker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
      // 初期表示フォルダー
      openPicker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
      // 選択させるファイル拡張子
      openPicker.FileTypeFilter.Add(".jpg");
      openPicker.FileTypeFilter.Add(".png");

      // FileOpenPickerを表示し、ファイルをひとつ選択してもらう
      // ※ 非同期API
      var file = await openPicker.PickSingleFileAsync();
      if (file == null)
        return;

      // ファイルを開いてストリームを得る
      // ※ 非同期API
      using (var stream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
      {
        // BitmapImageオブジェクトを作り、ストリームをセットする
        var bitmap = new Windows.UI.Xaml.Media.Imaging.BitmapImage();
        bitmap.SetSource(stream);

        // BitmapImageオブジェクトをImageコントロールにセットする
        Image1.Source = bitmap;
      }
    }
  }
}
