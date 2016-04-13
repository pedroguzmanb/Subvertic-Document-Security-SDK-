using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Subvertic.DocumentSecurity.Crypto.Entropy
{
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // CLASS RNG RANDOM DATA                                                                                                                //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    ///     Contains a set of functions used to generate cryptographically secure random data
    ///     <author>Pedro Guzmán (pedro@subvertic.com)</author>
    /// </summary>
    public class RngRandomData
    {

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // CHARACTERS MAP                                                                                                                   //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Valid characters map
        /// </summary>
        static readonly char[] Map = {

            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
            'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '-', '_', '!',
            '@', '#', '$', '%', '&', '*', '(', ')', '=', '+', '{', '}', '[',
            ']', '|', '<', '>', '?'

        }; // CHARACTER MAP ENDS ---------------------------------------------------------------------------------------------------------- //

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD NEXT  STRING                                                                                                              //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Generates secure random strings with the given length
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string NextString(int length)
        {
            var randomSeed = new byte[length];   // Will store the entropy bytes used to generate the random bytes
            var randString = new char[length];   // Will store the equivalent character translated using the Map

            // Verify the length is > 0 to prevent crypto exceptions in RNG
            if (length > 0)
            {
                using (var rng = new RNGCryptoServiceProvider())
                {
                    rng.GetBytes(randomSeed); // Fill the byte[] with entropy bytes
                } // USING ENDS

                for (var idx = 0; idx < randString.Length; ++idx)
                {
                    var relPosition = randomSeed[idx] % Map.Length;
                    randString[idx] = Map[relPosition];
                } // FOR ENDS 
            } // IF ENDS
            return new string(randString);
        } // METHOD NEXT ENDS ------------------------------------------------------------------------------------------------------------- //

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD NEXT BYTES                                                                                                                //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Generates a random byte array with variable length within a given threshold. 
        /// </summary>
        /// <param name="minLength">Minimun permited size fot the array</param>
        /// <param name="maxLength">Maximun allowed size for the array</param>
        /// <returns></returns>
        public static byte[] NextBytes(int minLength, int maxLength)
        {
            var random = new Random();
            var arrayLength = random.Next(minLength, maxLength);
            var entropyArray = new byte[arrayLength];
            var crng = new RNGCryptoServiceProvider();
            crng.GetNonZeroBytes(entropyArray);
            return entropyArray;
        } // METHOD NEXT BYTES ENDS ------------------------------------------------------------------------------------------------------- //



    } // CLASS RNG RANDOM DATA ENDS ------------------------------------------------------------------------------------------------------- //
}
