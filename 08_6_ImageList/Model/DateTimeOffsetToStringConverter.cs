using System;
using Windows.UI.Xaml.Data;

namespace ImageList.Model
{
  public class DateTimeOffsetToStringConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, string language)
    {
      if (value == null || !(value is DateTimeOffset))
        return null;

      // コンバーターパラメーターを文字列として取り出す
      var param = parameter as string;

      // パラメーターがないときは、従来の動作
      if (param == null)
        return ((DateTimeOffset)value).ToString("HH:mm:ss");

      // パラメーターがあるときは、それをフォーマット文字列として使う
      return ((DateTimeOffset)value).ToString(param);
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      // 今回、こちらは使われないので、実装しない
      throw new NotImplementedException();
    }
  }
}
