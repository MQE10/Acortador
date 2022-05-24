using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public class UTModelo
    {
        //Persona tPersona = new Persona();
        //this.txbPersonaCodigo.Text = "10";
        //tPersona.Id = UTModelo.ValorAsignar(tPersona.Id, this.txbPersonaCodigo.Text);
        //txbEstudiante.Text = UTModelo.ValorAsignar(txbEstudiante.Text, tPersona.Id);

        public static byte ValorAsignar(Nullable<byte> pPropiedad, object pValor)
        { byte retorno = 0; return ValorAsignar(retorno, pValor); }
        public static byte ValorAsignar(byte pPropiedad, object pValor)
        {
            byte retorno = 0;
            bool sw = false;
            if (pValor == null)
            { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
            else
            {
                if (byte.TryParse(pValor.ToString(), out retorno))
                { sw = true; }
                if (sw == false)
                {/* MessageBox.Show("Por favor es necesario rebisar la clase UTModelo-Int");*/ }
            }
            return retorno;
        }
        public static short ValorAsignar(Nullable<short> pPropiedad, object pValor)
        { short retorno = 0; return ValorAsignar(retorno, pValor); }
        public static short ValorAsignar(short pPropiedad, object pValor)
        {
            short retorno = 0;
            bool sw = false;
            if (pValor == null)
            { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
            else
            {
                if (short.TryParse(pValor.ToString(), out retorno))
                { sw = true; }
                if (sw == false)
                {/* MessageBox.Show("Por favor es necesario rebisar la clase UTModelo-Int");*/ }
            }
            return retorno;
        }
        public static int ValorAsignar(Nullable<int> pPropiedad, object pValor)
        { int retorno = 0; return ValorAsignar(retorno, pValor); }
        public static int ValorAsignar(int pPropiedad, object pValor)
        {
            int retorno = 0;
            bool sw = false;
            if (pValor == null)
            { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
            else
            {
                if (int.TryParse(pValor.ToString(), out retorno))
                { sw = true; }
                if (sw == false)
                {/* MessageBox.Show("Por favor es necesario rebisar la clase UTModelo-Int");*/ }
            }
            return retorno;
        }
        public static long ValorAsignar(Nullable<long> pPropiedad, object pValor)
        { long retorno = 0; return ValorAsignar(retorno, pValor); }
        public static long ValorAsignar(long pPropiedad, object pValor)
        {
            long retorno = 0;
            bool sw = false;
            if (pValor == null)
            { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
            else
            {
                if (long.TryParse(pValor.ToString(), out retorno))
                { sw = true; }
                if (sw == false)
                {/* MessageBox.Show("Por favor es necesario rebisar la clase UTModelo-Int");*/ }
            }
            return retorno;
        }
        public static decimal ValorAsignar(Nullable<decimal> pPropiedad, object pValor)
        { decimal retorno = 0; return ValorAsignar(retorno, pValor); }

        public static decimal ValorAsignar(decimal pPropiedad, object pValor)
        {
            decimal retorno = 0;
            bool sw = false;
            string tcadena = UTCadena.FormatoNumeroStandarCadenaIn(pValor.ToString());
            if (pValor == null)
            { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
            else
            {
                if (decimal.TryParse(tcadena, out retorno))
                { sw = true; }
                if (sw == false)
                {/* MessageBox.Show("Por favor es necesario rebisar la clase UTModelo-Int");*/ }
            }
            return retorno;
        }

        public static double ValorAsignar(Nullable<double> pPropiedad, object pValor)
        { double retorno = 0; return ValorAsignar(retorno, pValor); }
        public static double ValorAsignar(double pPropiedad, object pValor)
        {
            double retorno = 0;
            bool sw = false;
            string tcadena = UTCadena.FormatoNumeroStandarCadenaIn(pValor.ToString());
            if (pValor == null)
            { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
            else
            {
                if (double.TryParse(tcadena, out retorno))
                { sw = true; }
                if (sw == false)
                { /* MessageBox.Show("Por favor es necesario rebisar la clase UTModelo-Int");*/ }
            }
            return retorno;
        }
        //public static string ValorAsignar(Nullable<string> pPropiedad, object pValor)
        //{ string retorno = ""; return ValorAsignar(retorno, pValor); }
        public static string ValorAsignar(string pPropiedad, object pValor, int pCantidadDecimales = 2)
        {
            string retorno = "";
            if (pValor == null)
            { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
            else
            {
                if (pValor is decimal)
                { decimal tDecimal = (decimal)pValor; retorno = FormatoNumeroStandarCadenaOut(tDecimal.ToDecimales(pCantidadDecimales)); }
                else if (pValor is double)
                { double tDouble = (double)pValor; retorno = FormatoNumeroStandarCadenaOut(tDouble.ToDecimales(pCantidadDecimales)); }
                else
                { retorno = pValor.ToString(); }
            }
            return retorno;
        }

        public static string FormatoNumeroStandarCadenaOut(string pString)
        {
            string retorno = pString;
            if (retorno.Length == 0) { retorno = "0"; }
            //System.Globalization.NumberFormatInfo Info = System.Globalization.CultureInfo.CurrentCulture.NumberFormat;
            string sMiles = ",";// Info.CurrencyGroupSeparator;
            string sDecimal = ".";// Info.CurrencyDecimalSeparator;
            string rsDecimal = "";// Info.CurrencyDecimalSeparator;
            int tMiles = retorno.LastIndexOf(sMiles);
            int tDecimal = retorno.LastIndexOf(sDecimal);
            int rtDecimal = 0;
            if (tMiles > tDecimal)
            { rtDecimal = tMiles; rsDecimal = sMiles; }
            else if (tMiles < tDecimal)
            { rtDecimal = tDecimal; rsDecimal = sDecimal; }
            else
            { rtDecimal = retorno.Length - 1; rsDecimal = "."; }
            if (rtDecimal >= 0)//si existe
            {
                string pEntero = "0";
                string pDecimal = "0";
                try
                { pEntero = retorno.Substring(0, rtDecimal); pDecimal = retorno.Substring(rtDecimal + 1, retorno.Length - rtDecimal - 1); }
                catch { }

                pEntero = pEntero.Replace(sMiles, "").Replace(",", "").Replace(".", "").Replace(sDecimal, "");
                pDecimal = pDecimal.Replace(sMiles, "").Replace(",", "").Replace(".", "").Replace(sDecimal, "");
                retorno = pEntero + "." + pDecimal;
            }
            else
            {
                retorno = retorno.Replace(sMiles, "");
                retorno = retorno.Replace(sDecimal, ".");
            }


            return retorno;
        }

        public static DateTime ValorAsignar(Nullable<DateTime> pPropiedad, object pValor)
        { DateTime retorno = DateTime.Now; return ValorAsignar(retorno, pValor); }
        public static DateTime ValorAsignar(DateTime pPropiedad, object pValor)
        {
            DateTime retorno = DateTime.Now;
            bool sw = false;
            if (pValor == null)
            { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
            else
            {
                if (DateTime.TryParse(pValor.ToString(), out retorno))
                { sw = true; }
                if (sw == false)
                {/* MessageBox.Show("Por favor es necesario rebisar la clase UTModelo-Int");*/ }
            }
            return retorno;
        }

        //public static int ValorAsignar(ref int pPropiedad, object pValor)
        //{
        //    bool sw = false;
        //    string tValor = "";
        //    string pTipoDato = "";
        //    if (pValor == null)
        //    { /*MessageBox.Show("en UTModelo-ValorAsignar el pValor es null");*/ }
        //    else
        //    {
        //        tValor = pValor.ToString();
        //        switch (pTipoDato)
        //        {
        //            case enuTipoDato.iByte:
        //            case enuTipoDato.iNullableByte:
        //                byte tByte;
        //                if (byte.TryParse(tValor, out tByte))
        //                { pPropiedad = tByte; sw = true; }
        //                break;
        //            case enuTipoDato.iShort:
        //            case enuTipoDato.iNullableShort:
        //                short tShort;
        //                if (short.TryParse(tValor, out tShort))
        //                { pPropiedad = tShort; sw = true; }
        //                break;
        //            case enuTipoDato.iInt:
        //            case enuTipoDato.iNullableInt:
        //                int tInt;
        //                if (int.TryParse(tValor, out tInt))
        //                { pPropiedad = tInt; sw = true; }
        //                break;
        //            case enuTipoDato.iString:
        //            case enuTipoDato.iNullableString:
        //                //string tString;
        //                //if (string.TryParse(tValor, out tIString))
        //                //{ pPropiedad = tString; sw = true; }
        //                pPropiedad = tValor; sw = true;
        //                break;
        //            case enuTipoDato.iDateTime:
        //            case enuTipoDato.iNullableDateTime:
        //            case enuTipoDato.iSystemDateTime:
        //            case enuTipoDato.iNullableSystemDateTime:
        //                DateTime tDateTime;
        //                if (DateTime.TryParse(tValor, out tDateTime))
        //                { pPropiedad = tDateTime; sw = true; }

        //                break;
        //        }
        //        if (sw == false) { MessageBox.Show("Por favor es necesario rebisar la clase UTModelo-" + pTipoDato); }
        //    }
        //    return pPropiedad;
        //}
    }
}
