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
using MatematikProgram.Constants;
using MatematikProgram.Models;

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

        private VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = VaekstFormelClass_Object;
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
                    NumberOfTextBoxesShouldBeFilled = Const.RentesatsTextBoxNummer;
                    //ControlTools.ClearTextBoxes(TextBoxList);
                    MethodDelegateList.Clear();
                    MethodDelegateList.Add(BeregnStartKapital);
                    MethodDelegateList.Add(BeregnSlutKapital);
                    MethodDelegateList.Add(BeregnAntalTerminer);
                    MethodDelegateList.Add(BeregnRentesats);
                    break;
            }
        }

        private void CheckforZeroInFieldAndEraseField(ref string TextBoxString)
        {
            TextBoxString = String.Empty;
        }

        private void txtCheckForValidKeyPressedDoublePositive(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidPositive(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
            else
            {
                //CheckforZeroInFieldAndEraseField(ref (((TextBox)sender).Text));
                if ("0" == ((System.Windows.Controls.TextBox)sender).Text)
                {
                    ((System.Windows.Controls.TextBox)sender).Text = String.Empty;
                }
            }
        }

        private void txtCheckForValidKeyPressedDouble(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidNumeric(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
            else
            {
                if ("0" == ((System.Windows.Controls.TextBox)sender).Text)
                {
                    ((System.Windows.Controls.TextBox)sender).Text = String.Empty;
                }
            }
        }

        private void txtCheckForValidKeyPressedPositiveInteger(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidPositiveInteger(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
            else
            {
                if ("0" == ((System.Windows.Controls.TextBox)sender).Text)
                {
                    ((System.Windows.Controls.TextBox)sender).Text = String.Empty;
                }
            }
        }
        #endregion

        #region VaekstFormel
        private void btnClearVaekstFormelVariable_Click(object sender, RoutedEventArgs e)
        {
            //ControlTools.ClearTextBoxes(TextBoxList);
            VaekstFormelClass_Object.ClearVariables();
            VaekstformelBeregningerDataGrid.Visibility = Visibility.Hidden;
        }

        private void BeregnOgVisDataGrid(VaekstFormelClass VaekstFormelClass_Object)
        {
            List<VaekstFormelClass> VaekstFormelClassList = new List<VaekstFormelClass>();
            double StartKapital = VaekstFormelClass_Object.StartKapital;

            for (int Counter = 0; Counter < VaekstFormelClass_Object.AntalTerminer; Counter++)
            {
                VaekstFormelClass VaekstFormelClass_Object_Work = new VaekstFormelClass();

                VaekstFormelClass_Object_Work.AntalTerminer = Counter + 1;
                VaekstFormelClass_Object_Work.Rentesats = VaekstFormelClass_Object.Rentesats;
                VaekstFormelClass_Object_Work.StartKapital = Math.Round(StartKapital, Const.DefaultNumberOfDecimals);
                VaekstFormelClass_Object_Work.SlutKapital = Math.Round(StartKapital * (1 + VaekstFormelClass_Object.Rentesats), Const.DefaultNumberOfDecimals);
                
                VaekstFormelClassList.Add(VaekstFormelClass_Object_Work);

                StartKapital = VaekstFormelClass_Object_Work.SlutKapital;
            }
            VaekstformelBeregningerDataGrid.ItemsSource = VaekstFormelClassList;
            VaekstformelBeregningerDataGrid.Visibility = Visibility.Visible;
        }


        private void btnBeregnVaekstFormelVariable_Click(object sender, RoutedEventArgs e)
        {
            if (ControlTools.CheckTextBoxesForInformation(TextBoxList, NumberOfTextBoxesShouldBeFilled))
            {
                int EmptyFieldNumber = ControlTools.GetTextBoxNumberCOntainingZeroValueInTextBoxList(TextBoxList);
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
            //VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass(TextBoxes[Const.StartKapitalTextBoxNummer].Text,
            //                                                                   TextBoxes[Const.SlutKapitalTextBoxNummer].Text,
            //                                                                   TextBoxes[Const.AntalTerminerTextBoxNummer].Text,
            //                                                                   TextBoxes[Const.RentesatsTextBoxNummer].Text);
            VaekstFormelClass_Object.StartKapital = Math.Round(VaekstFormelClass_Object.SlutKapital / Math.Pow((1 + VaekstFormelClass_Object.Rentesats), VaekstFormelClass_Object.AntalTerminer), Const.DefaultNumberOfDecimals);
            //TextBoxes[Const.StartKapitalTextBoxNummer].Text = VaekstFormelClass_Object.StartKapital.ToString();
            BeregnOgVisDataGrid(VaekstFormelClass_Object);
        }

        private void BeregnSlutKapital(List<TextBox> TextBoxes)
        {
            VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass(TextBoxes[Const.StartKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.SlutKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.AntalTerminerTextBoxNummer].Text,
                                                                               TextBoxes[Const.RentesatsTextBoxNummer].Text);
            VaekstFormelClass_Object.SlutKapital = Math.Round(VaekstFormelClass_Object.StartKapital * Math.Pow((1 + VaekstFormelClass_Object.Rentesats), VaekstFormelClass_Object.AntalTerminer), Const.DefaultNumberOfDecimals);
            TextBoxes[Const.SlutKapitalTextBoxNummer].Text = VaekstFormelClass_Object.SlutKapital.ToString();
            BeregnOgVisDataGrid(VaekstFormelClass_Object);
        }

        private void BeregnAntalTerminer(List<TextBox> TextBoxes)
        {
            VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass(TextBoxes[Const.StartKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.SlutKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.AntalTerminerTextBoxNummer].Text,
                                                                               TextBoxes[Const.RentesatsTextBoxNummer].Text);
            VaekstFormelClass_Object.AntalTerminer = Convert.ToInt32(Math.Log(VaekstFormelClass_Object.SlutKapital / VaekstFormelClass_Object.StartKapital) / Math.Log(1 + VaekstFormelClass_Object.Rentesats));
            TextBoxes[Const.AntalTerminerTextBoxNummer].Text = VaekstFormelClass_Object.AntalTerminer.ToString();
            BeregnOgVisDataGrid(VaekstFormelClass_Object);
            //VaekstFormelClass_Object.SlutKapital = 
        }

        private void BeregnRentesats(List<TextBox> TextBoxes)
        {
            VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass(TextBoxes[Const.StartKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.SlutKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.AntalTerminerTextBoxNummer].Text,
                                                                               TextBoxes[Const.RentesatsTextBoxNummer].Text);
            VaekstFormelClass_Object.Rentesats = Math.Round((Math.Pow(VaekstFormelClass_Object.SlutKapital / VaekstFormelClass_Object.StartKapital, (double)(1 / VaekstFormelClass_Object.AntalTerminer)) - 1) * 100, Const.DefaultNumberOfDecimals);
            TextBoxes[Const.RentesatsTextBoxNummer].Text = VaekstFormelClass_Object.Rentesats.ToString();
            BeregnOgVisDataGrid(VaekstFormelClass_Object);
        }
        #endregion

        private void btnClearVaekstformelTextBox_Click(object sender, RoutedEventArgs e)
        {
            switch (((System.Windows.FrameworkElement)sender).Name)
            {
                case "btnClearStartKapital":
                    //txtStartKapital.Text = string.Empty;
                    VaekstFormelClass_Object.StartKapital = 0;
                    break;

                case "btnClearSlutKapital":
                    //txtSlutKapital.Text = string.Empty;
                    VaekstFormelClass_Object.SlutKapital = 0;   
                    break;

                case "btnClearAntalTerminer":
                    //txtAntalTerminer.Text = string.Empty;
                    VaekstFormelClass_Object.AntalTerminer = 0;
                    break;

                case "btnClearRentesats":
                    //txtRentesats.Text = string.Empty;
                    VaekstFormelClass_Object.Rentesats = 0;
                    break;
            }
        }
    }
}
