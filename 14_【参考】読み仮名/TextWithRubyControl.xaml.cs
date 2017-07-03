using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace 読み仮名
{
  public sealed partial class TextWithRubyControl : UserControl
  {
    public TextWithRubyControl()
    {
      this.InitializeComponent();

      this.DataContextChanged += TextWithRubyControl_DataContextChanged;

#if DEBUG
      Body = "(本体)";
      Ruby = "(フリガナ)";
#endif
    }

    private void TextWithRubyControl_DataContextChanged(FrameworkElement sender, DataContextChangedEventArgs args)
    {
      double? newFontSize
        = (Parent as Windows.UI.Xaml.Documents.TextElement)?.FontSize;
      if (newFontSize.HasValue && this.FontSize != newFontSize.Value)
      {
        this.FontSize = newFontSize.Value;
        SetValue(RubyFontSizeProperty, newFontSize.Value / 2.0);
        SetValue(RubyHeightProperty, new GridLength(FontSize));
      }
    }


    // Bodyプロパティ（文字列本体） 
    public string Body
    {
      get { return GetValue(BodyProperty) as string; }
      set { SetValue(BodyProperty, value); }
    }
    public static readonly DependencyProperty BodyProperty
      = DependencyProperty.Register(
          "Body", typeof(string), typeof(TextWithRubyControl), null
        );

    // Rubyプロパティ（フリガナ） 
    public string Ruby
    {
      get { return GetValue(RubyProperty) as string; }
      set { SetValue(RubyProperty, value); }
    }
    public static readonly DependencyProperty RubyProperty
      = DependencyProperty.Register(
          "Ruby", typeof(string), typeof(TextWithRubyControl), null
        );

    // IsPhraseStartプロパティ 
    public bool IsPhraseStart
    {
      get { return (bool)GetValue(IsPhraseStartProperty); }
      set
      {
        SetValue(IsPhraseStartProperty, value);

        SetValue(StartMarkVisibilityProperty,
         IsPhraseStart ? Visibility.Visible : Visibility.Collapsed);
        SetValue(ContinueMarkVisibilityProperty,
         IsPhraseStart ? Visibility.Collapsed : Visibility.Visible);
      }
    }
    public static readonly DependencyProperty IsPhraseStartProperty
      = DependencyProperty.Register(
          "IsPhraseStart", typeof(bool), typeof(TextWithRubyControl), null
        );



    private double RubyFontSize => (double)GetValue(RubyFontSizeProperty);
    private static readonly DependencyProperty RubyFontSizeProperty
      = DependencyProperty.Register(
          "RubyFontSize", typeof(double), typeof(TextWithRubyControl), null
        );

    private GridLength RubyHeight => (GridLength)GetValue(RubyHeightProperty);
    private static readonly DependencyProperty RubyHeightProperty
      = DependencyProperty.Register(
          "RubyHeight", typeof(GridLength), typeof(TextWithRubyControl), null
        );

    private Visibility StartMarkVisibility
      => (Visibility)GetValue(StartMarkVisibilityProperty);
    private static readonly DependencyProperty StartMarkVisibilityProperty
      = DependencyProperty.Register(
          "StartMarkVisibility", typeof(Visibility), typeof(TextWithRubyControl), null
        );

    private Visibility ContinueMarkVisibility
      => (Visibility)GetValue(ContinueMarkVisibilityProperty);
    private static readonly DependencyProperty ContinueMarkVisibilityProperty
      = DependencyProperty.Register(
          "ContinueMarkVisibility", typeof(Visibility), typeof(TextWithRubyControl), null
        );
  }
}
