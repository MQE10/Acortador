using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public static class UTNumero
    {
        public static bool ValidarNota(string pNota)
        {
            bool retorno = true;
            if (pNota == null) { }
            else
            {
                string tNotaCadena = pNota.Trim();
                foreach (char tChar in tNotaCadena)
                {
                    if (char.IsNumber(tChar)) { }
                    else if (tChar == ',' || tChar == '.' || tChar == '-') { }
                    else { retorno = false; }
                }

            }
            return retorno;
        }
        public static decimal Redondear(decimal pNumero, int pPrecicion)
        {
            decimal retorno = 0;
            try
            {
                retorno = Math.Round(pNumero, pPrecicion, MidpointRounding.AwayFromZero);
            }
            catch { }
            return retorno;
        }
        public static int Redondear(decimal pNumero)
        {
            int retorno = 0;
            try
            {
                retorno = (int)Math.Round(pNumero, 0, MidpointRounding.AwayFromZero);
            }
            catch { }

            return retorno;
        }
        public static string ToDecimales(this decimal pDecimal, int pCantidadDecimales = 2)
        {
            pDecimal = decimal.Round(pDecimal, pCantidadDecimales);
            string tCadena = "0:0.";
            string retorno = pDecimal.ToString();
            if (pCantidadDecimales >= 0)
            {
                if (pCantidadDecimales <= 0)
                { tCadena = "0:0"; }

                for (int i = 0; i < pCantidadDecimales; i++)
                {
                    tCadena = tCadena + "0";
                }
                retorno = String.Format("{" + tCadena + "}", pDecimal);
            }
            //string retorno = pDecimal.ToString();
            retorno = retorno.Replace(',', '.');
            return retorno;
        }
        public static string ToDecimales2(this decimal pDecimal)
        {
            pDecimal = decimal.Round(pDecimal, 2);
            string retorno = String.Format("{0:0.00}", pDecimal);
            retorno = retorno.Replace(',', '.');
            return retorno;
        }
        public static string ToMaxDecimales2(this decimal pDecimal)
        {
            pDecimal = decimal.Round(pDecimal, 2);
            string retorno = String.Format("{0:0.00}", pDecimal);
            retorno = retorno.Replace(',', '.');
            return retorno;
        }
        public static string ToDecimales(this double pDecimal, int pCantidadDecimales = 2)
        {
            string tCadena = "0:0.";
            if (pCantidadDecimales <= 0)
            { tCadena = "0:0"; }

            for (int i = 0; i <= pCantidadDecimales; i++)
            {
                tCadena = tCadena + "0";
            }
            string retorno = String.Format("{" + tCadena + "}", pDecimal);
            //string retorno = pDecimal.ToString();
            retorno = retorno.Replace(',', '.');
            return retorno;
        }
        public static string ToDecimales2(this double pDecimal)
        {
            string retorno = String.Format("{0:0.00}", pDecimal);
            retorno = retorno.Replace(',', '.');
            return retorno;
        }
        public static string ToMaxDouble2(this double pDecimal)
        {
            string retorno = String.Format("{0:0.00}", pDecimal);
            retorno = retorno.Replace(',', '.');
            return retorno;
        }
        public static string DigitosDos(int entero)
        {
            string retorno = "00";
            if (entero > 9) { retorno = entero.ToString(); }
            else { retorno = "0" + entero; }
            return retorno;
        }
        public static string DigitosTres(int entero)
        {
            string retorno = "000";
            if (entero > 99) { retorno = entero.ToString(); }
            else if (entero > 9) { retorno = "0" + entero; }
            else { retorno = "00" + entero; }
            return retorno;
        }
    }
}
