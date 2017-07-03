using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace ImageList.Model
{
  public class ImageFileData
  {
    // 公開するプロパティ
    public StorageFile File { get; private set; }
    public ulong Size { get; private set; }
    public BitmapImage Image { get; private set; }

    // ファクトリー メソッド
    public static async Task<ImageFileData> CreateAsync(StorageFile file)
    {
      // ファイルサイズの取得
      ulong size = (await file.GetBasicPropertiesAsync()).Size;

      var bitmap = new BitmapImage();
      if (file.ContentType.StartsWith("image/", StringComparison.OrdinalIgnoreCase))
      {
        // 画像の読み込み（第4章4.6）
        using (var stream = await file.OpenAsync(FileAccessMode.Read))
          bitmap.SetSource(stream);
      }

      return new ImageFileData
      {
        File = file,
        Size = size,
        Image = bitmap,
      };
    }
  }
}
