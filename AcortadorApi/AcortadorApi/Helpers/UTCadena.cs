using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public static class UTCadena
    {
        public static string QuitaAcentos(this string cadena)
        {
            string retorno = cadena;
            string[] arrayConAcentos = new string[] { "Á", "É", "Í", "Ó", "Ú", "Ü", "á", "é", "í", "ó", "ú", "ü" };
            string[] arraySinAcentos = new string[] { "A", "E", "I", "O", "U", "U", "a", "e", "i", "o", "u", "u" };

            for (int i = 0; i < arrayConAcentos.Length; i++)
            {
                retorno = retorno.Replace(arrayConAcentos[i], arraySinAcentos[i]);
            }
            return retorno;
        }
        public static string QuitaEspaciosIntermedios(this string cadena)
        {
            string NuevaCadena = "";
            string[] split = cadena.Split(' ');
            for (int i = 0; i < split.Count(); i++)
            {

                if (split[i] != "")
                {
                    if (NuevaCadena.Length > 0) NuevaCadena += " ";
                    NuevaCadena += split[i];
                }

            }
            return NuevaCadena;
        }
        public static string DigitosCinco(string cadena)
        {
            string retorno = cadena;

            if (retorno == null) { retorno = ""; }
            while (retorno.Length < 5)
            { retorno += " "; }
            return retorno;
        }
        //public static string FormatoEstandar(string cadena)
        //{
        //    string retorno = cadena.Trim();
        //    retorno = retorno.ToUpper();
        //    retorno = QuitaAcentos(retorno);
        //    return retorno;
        //}
        public static string FormatoOracionCapital(this string pCadena)
        {
            string[] Articulo = { "el", "la", "los", "las", "un", "una", "unos", "unas", "lo", "la", "de", "del", "al", "a" };
            if (pCadena == null)
            {
                pCadena = "";
            }
            string retorno = pCadena.Trim();
            retorno = retorno.ToLower();
            string[] tArray = retorno.Split(' ');
            retorno = "";
            foreach (string tstring in tArray)
            {
                string tCad = tstring.Trim();
                if (tCad.Length == 0) { }
                else if (tCad.Length == 1)
                {
                    if (retorno.Length > 0) { retorno += " "; }
                    retorno += tCad;
                }
                else
                {
                    if (retorno.Length > 0) { retorno += " "; }
                    if (Articulo.Contains(tCad) == false || retorno.Length == 0)
                    { retorno += tCad.Substring(0, 1).ToUpper() + tCad.Substring(1, tCad.Length - 1); }
                    else
                    { retorno += tCad; }
                }
            }
            return retorno;
        }
        public static string FormatoEstandar(this string pCadena)
        {
            if (pCadena == null)
            {
                pCadena = "";
            }
            string retorno = pCadena.Trim();
            retorno = retorno.ToUpper();
            //retorno = QuitaAcentos(retorno);
            retorno = QuitaEspaciosIntermedios(retorno);
            return retorno;
        }
        public static decimal FormatoDecimal(this string pCadena)
        {
            decimal retorno = 0;
            string tcadena = FormatoNumeroStandarCadenaIn(pCadena.Trim());

            try
            {
                if (decimal.TryParse(tcadena, out retorno))
                { retorno = decimal.Parse(pCadena); }
            }
            catch { }

            return retorno;
        }
        public static bool FormatoNumero(this string pCadena, ref decimal pSalida)
        {
            bool retorno = false;
            string tcadena = FormatoNumeroStandarCadenaIn(pCadena.Trim());

            try
            {
                if (decimal.TryParse(tcadena, out pSalida))
                { retorno = true; }
            }
            catch { }

            return retorno;
        }
        public static bool FormatoNumero(this string pCadena, ref double pSalida)
        {
            bool retorno = false;
            string tcadena = FormatoNumeroStandarCadenaIn(pCadena.Trim());

            try
            {
                if (double.TryParse(tcadena, out pSalida))
                { retorno = true; }
            }
            catch { }

            return retorno;
        }
        public static bool FormatoNumero(this string pCadena, ref int pSalida)
        {
            bool retorno = false;
            string tcadena = FormatoNumeroStandarCadenaIn(pCadena.Trim());

            try
            {
                if (int.TryParse(tcadena, out pSalida))
                { retorno = true; }
            }
            catch { }

            return retorno;
        }

        public static string FormatoNumeroStandarCadenaIn(string pString)
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
            { rtDecimal = retorno.Length; rsDecimal = "."; }
            if (rtDecimal >= 0)//si existe
            {
                string pEntero = "0";
                string pDecimal = "0";
                try
                { pEntero = retorno.Substring(0, rtDecimal); pDecimal = retorno.Substring(rtDecimal + 1, retorno.Length - rtDecimal - 1); }
                catch { }
                pEntero = pEntero.Replace(sMiles, "").Replace(",", "").Replace(".", "").Replace(sDecimal, "");
                pDecimal = pDecimal.Replace(sMiles, "").Replace(",", "").Replace(".", "").Replace(sDecimal, "");
                //if (pDecimal.Length > 2) { pDecimal = pDecimal.Substring(0, 2); }


                decimal tvEntero = 0;
                decimal tvDecimal = 0;
                int pDecimalLenth = pDecimal.Length;
                if (decimal.TryParse(pEntero, out tvEntero) && decimal.TryParse(pDecimal, out tvDecimal))
                {
                    if (pDecimalLenth > 0)
                    {
                        decimal tDividendo = Convert.ToDecimal(Math.Floor(Math.Pow(10, pDecimalLenth)));
                        if (tDividendo > 0)
                        { tvDecimal = (tvDecimal / tDividendo); }
                        tvEntero = tvEntero + (tvDecimal);
                    }
                    retorno = tvEntero.ToString();
                }
                else
                { retorno = pEntero + rsDecimal + pDecimal; }
            }
            else
            {
                retorno = retorno.Replace(sMiles, "");
                retorno = retorno.Replace(sDecimal, ".");
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

        public static string FormatoHoraMinutos(this string pCadena)
        {
            string retorno = pCadena.Trim();
            string[] tArray = retorno.Split(':');
            if (tArray.Count() == 0) { retorno = "00:00"; }
            else
            {
                if (tArray.Count() == 1) { tArray = new string[] { tArray[0], "00" }; }
                int numero = 0;
                if (int.TryParse(tArray[0], out numero)) { tArray[0] = int.Parse(tArray[0]).ToString(); }
                else { tArray[0] = "0"; }
                if (int.TryParse(tArray[1], out numero)) { tArray[1] = int.Parse(tArray[1]).ToString(); }
                else { tArray[1] = "0"; }
                //tArray[0] = tArray[0].ToString();
                if (tArray[0].Length == 0) { tArray[0] = "00"; }
                else if (tArray[0].Length == 1) { tArray[0] = "0" + tArray[0]; }
                else { tArray[0] = tArray[0].Substring(0, 2); }
                /////////////////////////
                if (tArray[1].Length == 0) { tArray[1] = "00"; }
                else if (tArray[1].Length == 1) { tArray[1] = "0" + tArray[1]; }
                else { tArray[1] = tArray[1].Substring(0, 2); }

                if (tArray.Length == 0) { retorno = "00:00"; }
                else if (tArray.Length == 1) { retorno = "00:" + tArray[0]; }
                else { retorno = tArray[0] + ":" + tArray[1]; }
            }
            return retorno;
        }
        public static bool ValidarFormatoHoraMinutos(this string pCadena)
        {
            bool retorno = false;
            string tCadena = pCadena.FormatoHoraMinutos();
            string[] tArray = tCadena.Split(':');
            int numero = 0;
            if (!(int.TryParse(tArray[0], out numero))) { }
            else if (numero < 0 || numero > 24) { }
            else if (!(int.TryParse(tArray[1], out numero))) { }
            else if (numero < 0 || numero > 59) { }
            else { retorno = true; }
            return retorno;
        }
        public static string FormatoNombre(this string pCadena)
        {
            string retorno = pCadena.Trim();
            retorno = QuitaAcentos(retorno);
            retorno = retorno.Replace(" ", "_");
            //pCadena = retorno;
            return retorno;
        }
        public static string FormatoEstandarNumero(this string pCadena)
        {
            string retorno = pCadena.Trim();
            if (retorno.Length == 0)
            { retorno = "0"; }

            if (retorno.Substring(0, 1) == ".")
            { retorno = "0" + retorno; }

            if (retorno.Substring(retorno.Length - 1, 1) == ".")
            { retorno = retorno + "0"; }
            return retorno;
        }
        public static System.TimeSpan GetTimeSpan(this string pCadena)
        {
            System.TimeSpan retorno = new System.TimeSpan();
            try
            {
                string[] tCadena = pCadena.Split(':');
                if (tCadena.Length == 1)
                { retorno = new System.TimeSpan(int.Parse(tCadena[0]), 0, 0); }
                else if (tCadena.Length == 2)
                { retorno = new System.TimeSpan(int.Parse(tCadena[0]), int.Parse(tCadena[1]), 0); }
                else if (tCadena.Length == 3)
                { retorno = new System.TimeSpan(int.Parse(tCadena[0]), int.Parse(tCadena[1]), int.Parse(tCadena[2])); }
            }
            catch
            { }
            return retorno;
        }
        //public static string GetName(this string pCadena, object pObject)
        //{
        //    string retorno = "";
        //    PropertyInfo[] properties = pObject.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        //    for (int i = 0; i < properties.Length; i++)
        //    {
        //        object propValue = properties[i].GetValue(pObject, null);
        //        if (object.ReferenceEquals(propValue, pCadena))
        //        {
        //            retorno = properties[i].Name;
        //            break;
        //        }
        //    }
        //    return retorno;
        //}

        /// <summary>
        /// Retorna una fecha utilizada en los reportes bajo el formato: DD/MM/YYYY, HH:MM
        /// </summary>
        /// <param name="pDateTime"></param>
        /// <returns></returns>
        public static string FormatoFechaImpresion(DateTime pDateTime)
        {
            string retorno = "";
            retorno = pDateTime.ToShortDateString() + ", " + pDateTime.TimeOfDay.Hours + ":" + pDateTime.TimeOfDay.Minutes;

            return retorno;
        }

        public static string ObtenerDiaSemana(DateTime pDateTime)
        {
            string retorno = "";
            switch (pDateTime.DayOfWeek.ToString())
            {
                case "Monday": retorno = "Lu"; break;
                case "Tuesday": retorno = "Ma"; break;
                case "Wednesday": retorno = "Mi"; break;
                case "Thursday": retorno = "Ju"; break;
                case "Friday": retorno = "Vi"; break;
                case "Saturday": retorno = "Sa"; break;
                case "Sunday": retorno = "Do"; break;
            }
            return retorno;
        }

        public static string ObtenerDiaSemana2(DateTime pDateTime)
        {
            string retorno = "";
            switch (pDateTime.DayOfWeek.ToString())
            {
                case "Monday": retorno = "Lunes"; break;
                case "Tuesday": retorno = "Martes"; break;
                case "Wednesday": retorno = "Miércoles"; break;
                case "Thursday": retorno = "Jueves"; break;
                case "Friday": retorno = "Viernes"; break;
                case "Saturday": retorno = "Sábado"; break;
                case "Sunday": retorno = "Domingo"; break;
            }
            return retorno;
        }

        public static bool Comparar(this string pCadenaA, string pCadenaB)
        {
            string xA = pCadenaA.ToUpper(); string xB = pCadenaB.ToUpper();

            xA = QuitaAcentos(pCadenaA).Trim();
            xB = QuitaAcentos(pCadenaB).Trim();



            if (xA == xB)
                return true;
            else
                return false;



        }

    }
}
