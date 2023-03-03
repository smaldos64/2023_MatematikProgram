using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikProgram.Models
{
    public class VaekstFormelClass : INotifyPropertyChanged
    {
        private double startKapital;
        private double slutKapital;
        private int antalTerminer;
        private double rentesats;

        public double StartKapital
        {
            get { return startKapital; }
            set
            {
                startKapital = value;
                OnPropertyChanged("StartKapital");
            }
        }

        public double SlutKapital
        {
            get { return slutKapital; }
            set 
            { 
                slutKapital = value;
                OnPropertyChanged("SlutKapital");
            }
        }

        public int AntalTerminer
        {
            get { return antalTerminer; }
            set 
            { 
                antalTerminer = value;
                OnPropertyChanged("AntalTerminer");
            }
        }

        public double Rentesats
        {
            get { return rentesats; }
            set 
            { 
                rentesats = value;
                OnPropertyChanged("Rentesats");
            }
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
                Rentesats = Convert.ToDouble(RentesatsString) / 100;
            }
            catch (Exception Error)
            {
                Rentesats = 0;
            }
        }

        public VaekstFormelClass()
        {

        }

        public void ClearVariables()
        {
            this.StartKapital = 0;
            this.SlutKapital = 0;
            this.AntalTerminer = 0;
            this.Rentesats = 0;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged(string PropertyNavn)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyNavn));
            }
        }
    }
}
