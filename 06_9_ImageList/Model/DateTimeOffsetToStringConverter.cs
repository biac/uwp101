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
      return ((DateTimeOffset)value).ToString("HH:mm:ss");
    }

    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
      // 今回、こちらは使われないので、実装しない
      throw new NotImplementedException();
    }
  }
}
