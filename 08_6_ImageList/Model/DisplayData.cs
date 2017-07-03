using System;
using System.Collections.ObjectModel; //冒頭にusingを追加
using System.ComponentModel; //冒頭にusingを追加
using Windows.Storage; //冒頭にusingを追加

namespace ImageList.Model
{
  public class DisplayData : INotifyPropertyChanged
  {
    // INotifyPropertyChangedの実装
    public event PropertyChangedEventHandler PropertyChanged;


    //public ObservableCollection<StorageFile> Files { get; set; }
    //  = new ObservableCollection<StorageFile>();
    public ObservableCollection<ImageFileData> Files { get; set; }
      = new ObservableCollection<ImageFileData>();

    private DateTimeOffset m_Time;
    public DateTimeOffset Time
    {
      get { return m_Time; }
      set
      {
        if (m_Time == value) return;
        m_Time = value;

        // プロパティに変化があったとき、PropertyChangedイベントを発行する
        this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Time)));
      }
    }



#if DEBUG
    public DisplayData()
    {
      if (Windows.ApplicationModel.DesignMode.DesignModeEnabled)
      {
        // デザイン時には、仮のデータを作る
        this.Time = DateTimeOffset.Now;
        GetTestDataAsync();
      }
    }

    private async void GetTestDataAsync()
    {
      StorageFolder folder = Windows.ApplicationModel.Package.Current.InstalledLocation;
      // デザインモードでのInstalledLocation は
      // C:\Users\{ユーザー}\AppData\Local\Microsoft\VisualStudio\14.0\Designer\ShadowCache の下

      var files = await folder.GetFilesAsync();
      foreach (var f in files)
        //this.Files.Add(f);
        this.Files.Add(await ImageFileData.CreateAsync(f));
    }
#endif
  }
}
