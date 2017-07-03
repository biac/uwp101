using System;
using System.ComponentModel;

namespace XBindSample
{
  public class SampleData : INotifyPropertyChanged
  {
    // 現在時刻を返すプロパティ（更新通知は発行しない）
    public string NowTime => $"{DateTimeOffset.Now:HH:mm:ss}";

    // nullを返すプロパティ（更新通知は発行しない）
    public string NullData => null; //{ get; }

    // INotifyPropertyChangedの実装
    public event PropertyChangedEventHandler PropertyChanged;

    // スライダーの値を表すプロパティ
    private double m_SliderValue = 7.0; //初期値
    const double MinValue = -10.0; //最小値
    const double MaxValue = 10.0; //最大値
    public double SliderValue
    {
      get => m_SliderValue;
      set
      {
        if (m_SliderValue == value) return;
        m_SliderValue = value;
        if (m_SliderValue < MinValue) m_SliderValue = MinValue;
        if (MaxValue < m_SliderValue) m_SliderValue = MaxValue;
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SliderValue)));
      }
    }
  }
}
