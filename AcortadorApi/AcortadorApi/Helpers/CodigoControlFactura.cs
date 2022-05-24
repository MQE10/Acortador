using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public static class CodigoControlFactura
    {
        public static string GenerarCodigoControl(long NroAutorizacion, long NroFactura, long NitCliente, long FechaTransaccion, long MontoTransaccion, string LLaveDosificacion)
        {

            #region "Paso1"


            string CadNroFactura, CadNitCliente, CadFechaTransaccion, CadMontoTransaccion;


            CadNroFactura = VerhoeffCheckDigit.VerhoeffXDigCon(NroFactura, 2);
            CadNitCliente = VerhoeffCheckDigit.VerhoeffXDigCon(NitCliente, 2);
            CadFechaTransaccion = VerhoeffCheckDigit.VerhoeffXDigCon(FechaTransaccion, 2);
            CadMontoTransaccion = VerhoeffCheckDigit.VerhoeffXDigCon(MontoTransaccion, 2);

            NroFactura = long.Parse(CadNroFactura);
            NitCliente = long.Parse(CadNitCliente);
            FechaTransaccion = long.Parse(CadFechaTransaccion);
            MontoTransaccion = long.Parse(CadMontoTransaccion);

            long SumVerhoeff = NroFactura + NitCliente + FechaTransaccion + MontoTransaccion;

            // SumVerhoeff = VerhoeffCheckDigit.VerhoeffXDig(SumVerhoeff, 5);
            string CincoDigitoVerhoeff = VerhoeffCheckDigit.VerhoeffXDigCAD(SumVerhoeff, 5);
            #endregion

            #region  "Paso2"

            string Cadena1, Cadena2, Cadena3, Cadena4, Cadena5;
            string AuxLLaveDosificacion = LLaveDosificacion;

            Cadena1 = NroAutorizacion.ToString() + AuxLLaveDosificacion.Substring(0, int.Parse(CincoDigitoVerhoeff[0].ToString()) + 1);
            AuxLLaveDosificacion = AuxLLaveDosificacion.Remove(0, int.Parse(CincoDigitoVerhoeff[0].ToString()) + 1);

            Cadena2 = CadNroFactura + AuxLLaveDosificacion.Substring(0, int.Parse(CincoDigitoVerhoeff[1].ToString()) + 1);
            AuxLLaveDosificacion = AuxLLaveDosificacion.Remove(0, int.Parse(CincoDigitoVerhoeff[1].ToString()) + 1);

            Cadena3 = CadNitCliente + AuxLLaveDosificacion.Substring(0, int.Parse(CincoDigitoVerhoeff[2].ToString()) + 1);
            AuxLLaveDosificacion = AuxLLaveDosificacion.Remove(0, int.Parse(CincoDigitoVerhoeff[2].ToString()) + 1);

            Cadena4 = CadFechaTransaccion + AuxLLaveDosificacion.Substring(0, int.Parse(CincoDigitoVerhoeff[3].ToString()) + 1);
            AuxLLaveDosificacion = AuxLLaveDosificacion.Remove(0, int.Parse(CincoDigitoVerhoeff[3].ToString()) + 1);

            Cadena5 = CadMontoTransaccion + AuxLLaveDosificacion.Substring(0, int.Parse(CincoDigitoVerhoeff[4].ToString()) + 1);
            #endregion

            #region "Paso3"
            string CadenaConcatenada = Cadena1 + Cadena2 + Cadena3 + Cadena4 + Cadena5;
            string llaveCifrada = LLaveDosificacion + CincoDigitoVerhoeff;
            string CadRC4 = RC4.allegedrc4(CadenaConcatenada, llaveCifrada);
            #endregion

            #region "PASO4"

            long SumASCII = SumatoriaParcialASCII(0, CadRC4, 1);
            long SP1, SP2, SP3, SP4, SP5;

            SP1 = SumatoriaParcialASCII(0, CadRC4, 5);
            SP2 = SumatoriaParcialASCII(1, CadRC4, 5);
            SP3 = SumatoriaParcialASCII(2, CadRC4, 5);
            SP4 = SumatoriaParcialASCII(3, CadRC4, 5);
            SP5 = SumatoriaParcialASCII(4, CadRC4, 5);
            #endregion

            #region "PASO5"
            double xSumatoria = Math.Truncate(((double)SumASCII * (double)SP1) / (double.Parse(CincoDigitoVerhoeff[0].ToString()) + 1)) +
                                Math.Truncate(((double)SumASCII * (double)SP2) / (double.Parse(CincoDigitoVerhoeff[1].ToString()) + 1)) +
                                Math.Truncate(((double)SumASCII * (double)SP3) / (double.Parse(CincoDigitoVerhoeff[2].ToString()) + 1)) +
                                Math.Truncate(((double)SumASCII * (double)SP4) / (double.Parse(CincoDigitoVerhoeff[3].ToString()) + 1)) +
                                Math.Truncate(((double)SumASCII * (double)SP5) / (double.Parse(CincoDigitoVerhoeff[4].ToString()) + 1));

            string xBase64 = Base64.base64((int)xSumatoria);

            #endregion

            #region "PASO6"

            string CodigoControl = RC4.allegedrc4(xBase64, llaveCifrada);
            string rCodigoControl = "";
            int xC = 0;

            for (int i = 0; i < CodigoControl.Count(); i++)
            {

                if (xC != 2)
                {
                    rCodigoControl += CodigoControl[i];
                    xC++;


                }
                else
                {
                    rCodigoControl += "-" + CodigoControl[i];
                    xC = 1;
                }

            }

            #endregion

            return rCodigoControl;

        }


        private static int SumatoriaParcialASCII(int pNumero, string Cadena, int Sec)
        {
            int SumAscii = 0;
            for (int i = pNumero; i < Cadena.Count(); i = i + Sec)
            {
                SumAscii += (int)Cadena[i];
            }

            return SumAscii;

        }
    }
}
