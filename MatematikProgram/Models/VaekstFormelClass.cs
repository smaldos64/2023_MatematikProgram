using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatematikProgram.Models
{
    public class VaekstFormelClass
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
    }
}
