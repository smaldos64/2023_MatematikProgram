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

namespace MatematikProgram
{

    class VaekstFormelClass
    {
        private double startKapital;
        private double slutKapital;
        private int antalTerminer;
        private double rentesats;

        public double StartKapital
        {
            get { return startKapital; }
            set { startKapital = value; }
        }

        public double SlutKapital
        {
            get { return slutKapital; }
            set { slutKapital = value; }
        }

        public int AntalTerminer
        {
            get { return antalTerminer; }
            set { antalTerminer = value; }
        }

        public double Rentesats
        {
            get { return rentesats; }
            set { rentesats = value; }
        }

        public VaekstFormelClass(string StartKapitalString, string SlutKapitalString, string AntalTerminerString, string RentesatsString)
        {
            try
            {
                StartKapital = Convert.ToDouble(StartKapitalString);
            }
            catch (Exception Error)
            {
                StartKapital = 0;
            }

            try
            {
                SlutKapital = Convert.ToDouble(SlutKapitalString);
            }
            catch (Exception Error)
            {
                SlutKapital = 0;
            }

            try
            {
                AntalTerminer = Convert.ToInt16(AntalTerminerString);
            }
            catch (Exception Error)
            {
                AntalTerminer = 0;
            }

            try
            {
                Rentesats = Convert.ToDouble(RentesatsString)/100;
            }
            catch (Exception Error)
            {
                Rentesats = 0;
            }
        }
    }
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
                    NumberOfTextBoxesShouldBeFilled = Const.RentesatsTextBoxNummer;
                    ControlTools.ClearTextBoxes(TextBoxList);
                    MethodDelegateList.Clear();
                    MethodDelegateList.Add(BeregnStartKapital);
                    MethodDelegateList.Add(BeregnSlutKapital);
                    MethodDelegateList.Add(BeregnAntalTerminer);
                    MethodDelegateList.Add(BeregnRentesats);
                    break;
            }
        }

        private void txtCheckForValidKeyPressedDoublePositive(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidPositive(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void txtCheckForValidKeyPressedDouble(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidNumeric(((System.Windows.Controls.TextBox)sender).Text, e.Key))
            {
                SystemSounds.Beep.Play();
                e.Handled = true;
            }
        }

        private void txtCheckForValidKeyPressedPositiveInteger(object sender, KeyEventArgs e)
        {
            if (!KeyHelper.IsKeyPressedValidPositiveInteger(((System.Windows.Controls.TextBox)sender).Text, e.Key))
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
            VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass(TextBoxes[Const.StartKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.SlutKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.AntalTerminerTextBoxNummer].Text,
                                                                               TextBoxes[Const.RentesatsTextBoxNummer].Text);
            //double SlutKapital = Convert.ToDouble(TextBoxes[Const.SlutKapitalTextBoxNummer].Text);
            //double AntalTerminer = Convert.ToDouble(TextBoxes[Const.AntalTerminerTextBoxNummer].Text);
            //double Rentesats = (Convert.ToDouble(TextBoxes[Const.RentesatsTextBoxNummer].Text)) / 100;
            //TextBoxes[Const.StartKapitalTextBoxNummer].Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(SlutKapital / Math.Pow((1 + Rentesats), AntalTerminer), Const.DefaultNumberOfDecimals);
            TextBoxes[Const.StartKapitalTextBoxNummer].Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(VaekstFormelClass_Object.SlutKapital / Math.Pow((1 + VaekstFormelClass_Object.Rentesats), VaekstFormelClass_Object.AntalTerminer), Const.DefaultNumberOfDecimals);
        }

        private void BeregnSlutKapital(List<TextBox> TextBoxes)
        {
            VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass(TextBoxes[Const.StartKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.SlutKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.AntalTerminerTextBoxNummer].Text,
                                                                               TextBoxes[Const.RentesatsTextBoxNummer].Text);
            TextBoxes[Const.SlutKapitalTextBoxNummer].Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(VaekstFormelClass_Object.StartKapital * Math.Pow((1 + VaekstFormelClass_Object.Rentesats), VaekstFormelClass_Object.AntalTerminer), Const.DefaultNumberOfDecimals);
        }

        private void BeregnAntalTerminer(List<TextBox> TextBoxes)
        {
            VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass(TextBoxes[Const.StartKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.SlutKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.AntalTerminerTextBoxNummer].Text,
                                                                               TextBoxes[Const.RentesatsTextBoxNummer].Text);
            TextBoxes[Const.AntalTerminerTextBoxNummer].Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals(Math.Log(VaekstFormelClass_Object.SlutKapital / VaekstFormelClass_Object.StartKapital) / Math.Log(1 + VaekstFormelClass_Object.Rentesats), Const.DefaultNumberOfDecimals);
        }

        private void BeregnRentesats(List<TextBox> TextBoxes)
        {
            VaekstFormelClass VaekstFormelClass_Object = new VaekstFormelClass(TextBoxes[Const.StartKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.SlutKapitalTextBoxNummer].Text,
                                                                               TextBoxes[Const.AntalTerminerTextBoxNummer].Text,
                                                                               TextBoxes[Const.RentesatsTextBoxNummer].Text);
            TextBoxes[Const.RentesatsTextBoxNummer].Text = PrintOutTools.WritDecimalStringWithSpecifiedNumberOfDecimals((Math.Pow(VaekstFormelClass_Object.SlutKapital / VaekstFormelClass_Object.StartKapital, 1 / VaekstFormelClass_Object.AntalTerminer) - 1) * 100, Const.DefaultNumberOfDecimals);
        }
        #endregion

        private void btnClearVaekstformelTextBox_Click(object sender, RoutedEventArgs e)
        {
            switch (((System.Windows.FrameworkElement)sender).Name)
            {
                case "btnClearStartKapital":
                    txtStartKapital.Text = string.Empty;
                    break;

                case "btnClearSlutKapital":
                    txtSlutKapital.Text = string.Empty;
                    break;

                case "btnClearAntalTerminer":
                    txtAntalTerminer.Text = string.Empty;
                    break;

                case "btnClearRentesats":
                    txtRentesats.Text = string.Empty;
                    break;
            }
        }
    }
}
