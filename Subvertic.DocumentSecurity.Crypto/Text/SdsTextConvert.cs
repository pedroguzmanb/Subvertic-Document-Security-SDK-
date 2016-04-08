using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Subvertic.DocumentSecurity.Crypto.Text
{
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // CLASS SDS CONVERT                                                                                                                    //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    ///     <author>Pedro Guzmán (pedro@subvertic.com)</author>
    /// </summary>
    public class SdsTextConvert
    {
        /// <summary>
        /// This class is not ment to be instantiated so no public constructors are defined
        /// </summary>
        private SdsTextConvert()
        {
            
        } // CONSTRUCTOR ENDS ------------------------------------------------------------------------------------------------------------- //

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD TO HEX STRING                                                                                                             //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Converts a given byte array into a its equivalent hex string
        /// </summary>
        /// <param name="origin">byte[] to be converted</param>
        /// <returns>hexadecimal string representation</returns>
        public static string ToHexString(byte[] origin)
        {
            if (origin != null && origin.Length > 0)
            {
                var hex = new StringBuilder(origin.Length*2);
                foreach (var b in origin)
                    hex.AppendFormat("{0:x2}", b);
                return hex.ToString();
            } // IF ENDS
            else
            {
                throw new ArgumentNullException(nameof(origin));
            } // ELSE ENDS
        } // METHOD TO HEX STRING ENDS ---------------------------------------------------------------------------------------------------- //


        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD BYTES FROM HEX STRING                                                                                                     //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="origin"></param>
        /// <returns></returns>
        public static byte[] BytesFromHexString(string origin)
        {
            var numberChars = origin.Length;
            var bytes = new byte[numberChars / 2];
            for (var i = 0; i < numberChars; i += 2)
                bytes[i / 2] = Convert.ToByte(origin.Substring(i, 2), 16);
            return bytes;
        } // METHOD BYTES FROM HEX STRING ENDS -------------------------------------------------------------------------------------------- //


    }
}
