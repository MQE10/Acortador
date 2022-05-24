using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AcortadorApi.Helpers
{
    public class Base64
    {
        static string[] diccionario = new string[64] {

"0", "1", "2", "3", "4", "5","6","7","8","9","A","B","C","D","E","F","G","H","I","J","K" ,"L","M","N","O","P","Q","R","S","T","U","V" ,"W","X","Y","Z","a","b","c","d","e","f","g" ,"h","i","j","k","l","m","n","o","p","q","r" ,"s","t","u","v","w","x","y","z","+","/"

};

        public static string base64(int numero)
        {
            int cociente = 1; int resto; string palabra = "";
            while (cociente > 0)
            {
                cociente = numero / 64;
                resto = numero % 64;
                palabra = diccionario[resto] + palabra;
                numero = cociente;

            }
            return (palabra);
        }
    }
}
