using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Documents;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Windows.Media;

namespace MatematikProgram.Tools
{
    public class ControlTools
    {
        public static void SetComboBoxSelectedItem(ComboBox ThisComboBox, int SelectedValue)
        {
            int ComboBoxItemsCounter = 0;
            bool ComboBoxSelectedItemFound = false;

            do
            {
                if ((int)ThisComboBox.Items[ComboBoxItemsCounter] == SelectedValue)
                {
                    ComboBoxSelectedItemFound = true;
                }
                else
                {
                    ComboBoxItemsCounter++;
                }
            } while ((ComboBoxItemsCounter < ThisComboBox.Items.Count) && (false == ComboBoxSelectedItemFound));

            ThisComboBox.SelectedItem = ThisComboBox.Items.GetItemAt(ComboBoxItemsCounter);
        }

        public static void SetComboBoxSelectedItem(ComboBox ThisComboBox, char SelectedChar)
        {
            int ComboBoxItemsCounter = 0;
            bool ComboBoxSelectedItemFound = false;

            do
            {
                if ((char)ThisComboBox.Items[ComboBoxItemsCounter] == SelectedChar)
                {
                    ComboBoxSelectedItemFound = true;
                }
                else
                {
                    ComboBoxItemsCounter++;
                }
            } while ((ComboBoxItemsCounter < ThisComboBox.Items.Count) && (false == ComboBoxSelectedItemFound));

            ThisComboBox.SelectedItem = ThisComboBox.Items.GetItemAt(ComboBoxItemsCounter);
        }

        public static int CheckTextBoxesForInformation(List<TextBox> TextBoxes)
        {
            int Counter;
            int NumberOfTextBoxesWithInfo = 0;

            for (Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                if (TextBoxes[Counter].Text.Length > 0)
                {
                    NumberOfTextBoxesWithInfo++;
                }
            }

            return (NumberOfTextBoxesWithInfo);
        }

        public static bool CheckTextBoxesForInformation(List<TextBox> TextBoxes, 
                                                        string EmptyString)
        {
            int Counter;
           
            for (Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                if ( !((TextBoxes[Counter].Text.Length > 0) && 
                      (TextBoxes[Counter].Text != EmptyString)) )
                {
                    return (false);
                }
            }

            return (true);
        }

        public static bool CheckTextBoxesForInformation(List<TextBox> TextBoxes,
                                                        string EmptyString,
                                                        int NumberOfItems)
        {
            int Counter;
            int ValueSetCounter = 0;

            for (Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                if (((TextBoxes[Counter].Text.Length > 0) &&
                     (TextBoxes[Counter].Text != EmptyString)))
                {
                    ValueSetCounter++;
                }
            }

            if (NumberOfItems == ValueSetCounter)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public static bool CheckTextBoxesForInformation(List<TextBox> TextBoxes,
                                                        int NumberOfItems)
        {
            int Counter;
            int ValueSetCounter = 0;

            for (Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                if (((TextBoxes[Counter].Text.Length > 0) &&
                     (TextBoxes[Counter].Text != String.Empty) &&
                     ("0" != TextBoxes[Counter].Text)))
                {
                    ValueSetCounter++;
                }
            }

            if (NumberOfItems == ValueSetCounter)
            {
                return (true);
            }
            else
            {
                return (false);
            }
        }

        public static int GetEmptyTextBoxNumberInTextBoxList(List<TextBox> TextBoxes)
        {
            for (int Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                if (string.IsNullOrEmpty(TextBoxes[Counter].Text))
                {
                    return (Counter);
                }
            }
            return (-1);
        }

        public static int GetTextBoxNumberCOntainingZeroValueInTextBoxList(List<TextBox> TextBoxes)
        {
            for (int Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                if ("0" == TextBoxes[Counter].Text)
                {
                    return (Counter);
                }
            }
            return (-1);
        }

        public static void ClearTextBoxes(List<TextBox> TextBoxes, string ClearString = "", bool ClearOnlyWriteFields = false)
        {
            int Counter;

            for (Counter = 0; Counter < TextBoxes.Count; Counter++)
            {
                if ( (!TextBoxes[Counter].IsReadOnly) || (false == ClearOnlyWriteFields) )
                {
                    TextBoxes[Counter].Text = ClearString;
                }
            }
        }

        public static List<string> GetAllLinesInTextBlock(TextBlock ThisTextBlock)
        {
            List<string> LinesInTextBlock = new List<string>();
            string TextBloxkText;
            string SubString;
            int NewLinePosition = -1;

            TextBloxkText = ((System.Windows.Documents.Run)ThisTextBlock.Inlines.FirstInline).Text;
            TextBloxkText.Trim();

            do
            {
                NewLinePosition = TextBloxkText.IndexOf('\n');
                if (NewLinePosition > 0)
                {
                    SubString = TextBloxkText.Substring(0, NewLinePosition - 1);
                    LinesInTextBlock.Add(SubString);
                    TextBloxkText = TextBloxkText.Substring(NewLinePosition + 1);
                }
                else
                {
                    if (0 == NewLinePosition)
                    {
                        TextBloxkText = TextBloxkText.Substring(1);
                    }
                }
            } while (NewLinePosition >= 0);

            LinesInTextBlock.Add(TextBloxkText);

            return (LinesInTextBlock);
        }

        public static void InsertRowInGrid(Grid Grid_Object)
        {
            RowDefinition MyRow = new RowDefinition();
            MyRow.Height = new GridLength(30);
            Grid_Object.RowDefinitions.Add(MyRow);
        }

        public static void InsertRowInGrid(Grid Grid_Object, int RowHeight)
        {
            RowDefinition MyRow = new RowDefinition();
            MyRow.Height = new GridLength(RowHeight);
            Grid_Object.RowDefinitions.Add(MyRow);
        }

        public static Label InsertLabelInGrid(Grid Grid_Object, string LabelName, string LabelText,
                                              int RowPosition, int ColumnPosition, int ColumnSpan)
        {
            Label Label_Object = new Label();

            Label_Object.Name = LabelName;
            Label_Object.Content = LabelText;
            Label_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);

            Grid_Object.Children.Add(Label_Object);
            Grid.SetColumn(Label_Object, ColumnPosition);
            Grid.SetRow(Label_Object, RowPosition);

            return (Label_Object);
        }

        public static TextBox InsertTextBoxInGrid(Grid Grid_Object, string TextBoxName, int RowPosition, 
                                                  int ColumnPosition, int ColumnSpan, int Width, int Height,
                                                  KeyEventHandler FunctionKeyDown,
                                                  TextChangedEventHandler FunctionTextChanged,
                                                  string TextBox_Text = "",
                                                  bool DisableTextBox = false)
        {
            TextBox TextBox_Object = new TextBox();

            TextBox_Object.Name = TextBoxName;
            TextBox_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);
            TextBox_Object.Width = Width;
            TextBox_Object.Height = Height;

            if (null != FunctionTextChanged)
            {
                TextBox_Object.TextChanged += FunctionTextChanged;
            }

            if (null != FunctionKeyDown)
            {
                TextBox_Object.KeyDown += FunctionKeyDown;
            }

            if ("" != TextBox_Text)
            {
                TextBox_Object.Text = TextBox_Text;
            }

            if (true == DisableTextBox)
            {
                TextBox_Object.IsReadOnly = true;
                TextBox_Object.Background = Brushes.Yellow;
                TextBox_Object.Foreground = Brushes.Blue;
            }

            Grid_Object.Children.Add(TextBox_Object);
            Grid.SetColumn(TextBox_Object, ColumnPosition);
            Grid.SetRow(TextBox_Object, RowPosition);

            return (TextBox_Object);
        }

        public static ComboBox InsertComboBoxInGrid(Grid Grid_Object, ComboBox ComboBox_Present_Object, 
                                                    string ComboBoxName, int RowPosition,
                                                    int ColumnPosition, int ColumnSpan, int Height,
                                                    SelectionChangedEventHandler FunctionKeyDownSelectionChanged)
        {
            ComboBox ComboBox_Object = new ComboBox();
            ComboBox_Object.Name = ComboBoxName;
            ComboBox_Object.Height = Height;
            ComboBox_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);
            ComboBox_Object.ItemsSource = ComboBox_Present_Object.Items.Cast<Object>().ToArray();
            ComboBox_Object.SelectedIndex = ComboBox_Present_Object.SelectedIndex;

            ComboBox_Object.SelectionChanged += FunctionKeyDownSelectionChanged;

            Grid_Object.Children.Add(ComboBox_Object);
            Grid.SetColumn(ComboBox_Object, ColumnPosition);
            Grid.SetRow(ComboBox_Object, RowPosition);

            return (ComboBox_Object);
        }

        public static ComboBox InsertComboBoxInGrid(Grid Grid_Object, string ComboBoxName, int RowPosition,
                                                    int ColumnPosition, int ColumnSpan, int Height,
                                                    SelectionChangedEventHandler FunctionKeyDownSelectionChanged)
        {
            ComboBox ComboBox_Object = new ComboBox();
            ComboBox_Object.Name = ComboBoxName;
            ComboBox_Object.Height = Height;
            ComboBox_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);
            
            ComboBox_Object.SelectionChanged += FunctionKeyDownSelectionChanged;

            Grid_Object.Children.Add(ComboBox_Object);
            Grid.SetColumn(ComboBox_Object, ColumnPosition);
            Grid.SetRow(ComboBox_Object, RowPosition);

            return (ComboBox_Object);
        }

        public static Button InsertButtonInGrid(Grid Grid_Object, 
                                                string ButtonName, string ButtonText, int RowPosition,
                                                int ColumnPosition, int ColumnSpan, int Width, int Height,
                                                RoutedEventHandler FunctionButtonClicked)
        {
            Button Button_Object = new Button();

            Button_Object.Name = ButtonName;
            Button_Object.Width = Width;
            Button_Object.Height = Height;
            Button_Object.Content = ButtonText;
            Button_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);
            
            Button_Object.Click += FunctionButtonClicked;

            Grid_Object.Children.Add(Button_Object);
            Grid.SetColumn(Button_Object, ColumnPosition);
            Grid.SetRow(Button_Object, RowPosition);

            return (Button_Object);
        }

        public static Image InsertImageInGrid(Grid Grid_Object, string ImageFileName, int RowPosition,
            int ColumnPosition, int ColumnSpan, int Width, int Height)
        {
            Image Image_Object = new Image();
            //Image_Object.Width = Width;
            //Image_Object.SetValue(Grid.ColumnSpanProperty, ColumnSpan);

            //BitmapImage BitmapImage_Object = new BitmapImage();

            //BitmapImage_Object.BeginInit();
            //BitmapImage_Object.UriSource = new Uri(@ImageFileName);
            //BitmapImage_Object.DecodePixelWidth = Width;
            //BitmapImage_Object.EndInit();

            //Image_Object.Source = BitmapImage_Object;
            //Image_Object.Stretch = Stretch.UniformToFill;

            //Image_Object.Stretch = Stretch.Fill;

            //Grid_Object.Children.Add(Image_Object);
            //Grid.SetColumn(Image_Object, ColumnPosition);
            //Grid.SetRow(Image_Object, RowPosition);

            return (Image_Object);
        }

        public static string GetStringFromInt(int KeyValue)
        {
            int KeyValueCounter = 0;

            do
            {
                if (KeyValue == ConstNumberSystems.KeyToCharConverterArray[KeyValueCounter].KeyValue)
                {
                    return ((ConstNumberSystems.KeyToCharConverterArray[KeyValueCounter].KeyChar).ToString());
                }
                else
                {
                    KeyValueCounter++;
                }
            } while (KeyValueCounter < ConstNumberSystems.KeyToCharConverterArray[ConstNumberSystems.KeyToCharConverterArray.Length - 1].KeyValue);

            return (' '.ToString());
        }

        public static string GetStringValueFromInt(int KeyValue)
        {
            int KeyValueCounter = 0;
            
            do
            {
                if (KeyValue == ConstNumberSystems.KeyToCharConverterArray[KeyValueCounter].KeyValue)
                {
                    return ((ConstNumberSystems.KeyToCharConverterArray[KeyValueCounter].Value).ToString());
                }
                else
                {
                    KeyValueCounter++;
                }
            } while (KeyValueCounter < ConstNumberSystems.KeyToCharConverterArray.Length - 1);

            return (' '.ToString());
        }

    }
}
