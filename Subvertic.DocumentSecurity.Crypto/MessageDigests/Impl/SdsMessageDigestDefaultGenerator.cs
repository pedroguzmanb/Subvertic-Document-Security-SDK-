using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Subvertic.DocumentSecurity.Crypto.MessageDigests;

namespace Subvertic.DocumentSecurity.Crypto.MessageDigests.Impl
{

    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // SDS MESSAGE DIGEST DEFAULT GENERATOR                                                                                                 //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    ///     Used to compute hash values from byte arrays or string data. 
    ///     <author>Pedro Guzmán (pedro@subvertic.com)</author>
    /// </summary>
    public class SdsMessageDigestDefaultGenerator : ISdsMessageDigestGenerator
    {


        // -------------------------------------------------------------------------------------------------------------------------------- //
        // CLASS CONSTANT DECLARATIONS                                                                                                      //
        // -------------------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        ///     Minimun allowed length for salt bytes when used automatically salted hashes
        /// </summary>
        public const int MinSaltLength = 8;

        /// <summary>
        ///     Maximun allowed length for the salt bytes when used in automatically salted operations
        /// </summary>
        public const int MaxSaltLength = 24;



        public string Compute(string plainData, SdsMessageDigestAlgorithm algorithm)
        {
            throw new NotImplementedException();
        }

        public byte[] Compute(byte[] plainData, SdsMessageDigestAlgorithm algorithm)
        {
            throw new NotImplementedException();
        }

        public string Compute(string plainData, SdsMessageDigestAlgorithm algorithm, byte[] saltaBytes)
        {
            throw new NotImplementedException();
        }

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // METHOD COMPUTE                                                                                                                   //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Computes the hash value using given algorithm and provided data as a byte array.
        /// </summary>
        /// <param name="plainData"> Data to be hashed</param>
        /// <param name="algorithm"> Digest algorithm to be used</param>
        /// <param name="saltaBytes"> Salt bytes to be used in the operation </param>
        /// <returns>byte[] with the computed value of the digest</returns>
        public byte[] Compute(byte[] plainData, SdsMessageDigestAlgorithm algorithm, byte[] saltaBytes)
        {
            throw new NotImplementedException();
        } // METHOD CMOPUTE ENDS ---------------------------------------------------------------------------------------------------------- //

        public byte[] NewSalt(int maxSaltSize)
        {
            throw new NotImplementedException();
        }

        public bool Verify(byte[] plainData, byte[] messageDigest, SdsMessageDigestAlgorithm algorithm)
        {
            throw new NotImplementedException();
        }

        public bool Verify(string plainData, string messageDigest, SdsMessageDigestAlgorithm algorithm)
        {
            throw new NotImplementedException();
        }
    }
}
