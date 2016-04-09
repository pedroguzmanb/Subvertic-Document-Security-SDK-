﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Subvertic.DocumentSecurity.Crypto.MessageDigests
{
    /// <summary>
    ///     <description>Defines a common interface for message</description>
    ///     <author>Pedro Guzmán (pedro@subvertic.com)</author>
    /// </summary>
    public interface ISdiMessageDigestGenerator
    {


        // ------------------------------------------------------------------------------------------------------------------------- //
        // METHOD NEW SALT                                                                                                           //
        // ------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Generates a set of random bytes that can be used as salt bytes in order to prevent dictionary attacks using rainbow
        ///     tables.
        /// </summary>
        /// <returns>byte[] of randomly generated bytes</returns>
        byte[] NewSalt(int maxSaltSize);

        // ------------------------------------------------------------------------------------------------------------------------- //
        // METHOD COMPUTE                                                                                                            //
        // ------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="plainData"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        byte[] Compute(byte[] plainData, SdsMessageDigestAlgorithm algorithm);

        // ------------------------------------------------------------------------------------------------------------------------- //
        // METHOD COMPUTE                                                                                                            //
        // ------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     
        /// </summary>
        /// <param name="plainData"></param>
        /// <param name="algorithm"></param>
        /// <param name="saltaBytes"></param>
        /// <returns></returns>
        byte[] Compute(byte[] plainData, SdsMessageDigestAlgorithm algorithm, byte[] saltaBytes);

        // ------------------------------------------------------------------------------------------------------------------------- //
        // METHOD COMPUTE                                                                                                            //
        // ------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Computes the corresponding hash value of a given string with the specified algorithm
        /// </summary>
        /// <param name="plainData"></param>
        /// <param name="algorithm"></param>
        /// <returns></returns>
        string Compute(string plainData, SdsMessageDigestAlgorithm algorithm);

        // ------------------------------------------------------------------------------------------------------------------------- //
        // METHOD COMPUTE                                                                                                            //
        // ------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Computes the corresponding hash value of a given string with provided salt-bytes
        /// </summary>
        /// <param name="plainData"></param>
        /// <param name="algorithm"></param>
        /// <param name="saltaBytes"></param>
        /// <returns></returns>
        string Compute(string plainData, SdsMessageDigestAlgorithm algorithm, byte[] saltaBytes);


        // ------------------------------------------------------------------------------------------------------------------------- //
        // METHOD NEW SALT                                                                                                           //
        // ------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Verifies if a given message digest value and a given digest algorithm is valid for a given set of data.
        /// </summary>
        /// <param name="plainData">Plain data</param>
        /// <param name="messageDigest">Value of the message digest to be verified</param>
        /// <param name="algorithm">algorithm to be used during the verification process</param>
        /// <returns></returns>
        bool Verify(string plainData, string messageDigest, SdsMessageDigestAlgorithm algorithm);

        // ------------------------------------------------------------------------------------------------------------------------- //
        // METHOD NEW SALT                                                                                                           //
        // ------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Verifies if a given message digest value and a given digest algorithm is valid for a given set of data.
        /// </summary>
        /// <param name="plainData">Plain data</param>
        /// <param name="messageDigest">Value of the message digest to be verified</param>
        /// <param name="algorithm">algorithm to be used during the verification process</param>
        /// <returns></returns>
        bool Verify(byte[] plainData, byte[] messageDigest, SdsMessageDigestAlgorithm algorithm);


    }
}
