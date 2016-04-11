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
    ///     <author>Pedro Guzmán (pedro@subvertic.com)</author>
    /// </summary>
    public class SdsMessageDigestDefaultGenerator : ISdsMessageDigestGenerator
    {

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

        public byte[] Compute(byte[] plainData, SdsMessageDigestAlgorithm algorithm, byte[] saltaBytes)
        {
            throw new NotImplementedException();
        }

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
