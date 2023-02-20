using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using MatematikProgram.Tools;

namespace MatematikProgram
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static List<TextBox> TextBoxList = new List<TextBox>();

        private static int NumberOfTextBoxesShouldBeFilled = -1;

        private delegate void MethodDelegate(List<TextBox> TextBoxes);
        private List<MethodDelegate> MethodDelegateList = new List<MethodDelegate>();

        public MainWindow()
        {
            InitializeComponent();
        }

        #region General_Code
        private void MainTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((System.Windows.FrameworkElement)MainTabControl.SelectedItem).Name)
            {
                case "Vaekstformel":
                    TextBoxList.Clear();
                    TextBoxList.Add(txtStartKapital);
                    TextBoxList.Add(txtSlutKapital);
                    TextBoxList.Add(txtAntalTerminer);
                    TextBoxList.Add(txtRentesats);
                    NumberOfTextBoxesShouldBeFilled = 3;
                    ControlTools.ClearTextBoxes(TextBoxList);
                    MethodDelegateList.Clear();
                    MethodDelegateList.Add(BeregnStartKapital);
                    break;
            }
        }

        private void txtCheckForValidKeyPressed(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidPositive(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }
        #endregion

        #region VaekstFormel
        private void btnClearVaekstFormelVariable_Click(object sender, RoutedEventArgs e)
        {
            ControlTools.ClearTextBoxes(TextBoxList);
        }
        
        private void btnBeregnVaekstFormelVariable_Click(object sender, RoutedEventArgs e)
        {
            if (ControlTools.CheckTextBoxesForInformation(TextBoxList, " " , NumberOfTextBoxesShouldBeFilled))
            {
                int EmptyFieldNumber = ControlTools.GetEmptyTextBoxNumberInTextBoxList(TextBoxList);
                if (EmptyFieldNumber < 0)
                {
                    MessageBox.Show("Hmm noget galt i din kode her !!!");
                }
                else
                {
                    MethodDelegateList[EmptyFieldNumber](TextBoxList);
                }
            }
            else
            {
                MessageBox.Show("Husk at " + NumberOfTextBoxesShouldBeFilled.ToString() + " input felter skal have en værdi !!!");
            }
        }

        private void BeregnStartKapital(List<TextBox> TextBoxes)
        {
            TextBoxes[0].Text = "Hej Kurt";
        }

        private void BeregnSlutKapital(List<TextBox> TextBoxes)
        {
            TextBoxes[1].Text = "Hej Kurt1";
        }

        private void BeregnAntalTerminer(List<TextBox> TextBoxes)
        {

        }

        private void BeregnRentesats(List<TextBox> TextBoxes)
        {

        }
        #endregion
    }
}
