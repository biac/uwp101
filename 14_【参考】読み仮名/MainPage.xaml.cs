using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace 読み仮名
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class MainPage : Page
  {
    public MainPage()
    {
      this.InitializeComponent();

      ClearText();
    }

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
      base.OnNavigatedTo(e);

      SampleMethod("試験ですよ❢");
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
      ClearText();
      SampleMethod(TextBox1.Text, monoRubySwitch.IsOn);
    }



    private void ClearText()
    {
      P1.Inlines.Clear();
    }

    private void SampleMethod(string text, bool monoRuby = false)
    {
      // JapanesePhoneticAnalyzerはデスクトップ専用API 
      if (!Windows.Foundation.Metadata.ApiInformation.IsTypePresent(
              "Windows.Globalization.JapanesePhoneticAnalyzer"))
        return;

      // JapanesePhoneticAnalyzerクラスのGetWordsメソッドを呼び出すだけで、 
      // 形態素への分割と、読み仮名の付与をしてくれる 
      IReadOnlyList<Windows.Globalization.JapanesePhoneme> list
        = Windows.Globalization.JapanesePhoneticAnalyzer
            .GetWords(text, monoRuby);

      // 全体の読み仮名を取得する例 
      string yomi
        = string.Join(null, list.Select(p => p.YomiText));
      TextBox2.Text = yomi;

      // 形態素ごとの処理をする例 
      foreach (var phoneme in list)
      {
        // 分割した文字列（形態素） 
        string displayText = phoneme.DisplayText;
        // 分割した文字列の読み仮名 
        string yomiText = phoneme.YomiText;
        // この形態素は句の先頭か？ 
        bool isPhraseStart = phoneme.IsPhraseStart;

        // 何か処理をする 
        AppendTextAndRuby(displayText, yomiText, isPhraseStart);
      }
    }

    private void AppendTextAndRuby(string text, string ruby = "", bool isPhraseStart = false)
    {
      if (ruby == text)
        ruby = string.Empty;

      P1.Inlines.Add(
        new Windows.UI.Xaml.Documents.InlineUIContainer
        {
          Child = new TextWithRubyControl
          {
            Body = text,
            Ruby = ruby,
            IsPhraseStart = isPhraseStart,
          },
        }
      );
    }
  }
}
