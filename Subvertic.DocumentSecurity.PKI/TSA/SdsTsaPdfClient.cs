using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.log;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.security;

namespace Subvertic.DocumentSecurity.PKI.TSA
{
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // CLASS SDS TSA DEFAULT CLIENT                                                                                                         //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    /// 
    /// </summary>
    public class SdsTsaPdfClient
    {

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // CLASS PRIVATE ATTRIBUTES                                                                                                         //
        // -------------------------------------------------------------------------------------------------------------------------------- //

        /// <summary>
        /// 
        /// </summary>
        private ITSAClient tsaClient;

        /// <summary>
        ///     Stores the credentials to connect to the TimeStamp Authority
        /// </summary>
        private readonly TsaCredentials tsaCredentials;


        /// <summary>
        ///     Credentials Properties
        /// </summary>
        public TsaCredentials Credentials => tsaCredentials;

        // -------------------------------------------------------------------------------------------------------------------------------- //
        // CONSTRUCTOR METHOD                                                                                                               //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        /// 
        /// </summary>
        /// <param name="credentials"></param>
        public SdsTsaPdfClient(TsaCredentials credentials)
        {
            if (credentials != null)
            {
                tsaCredentials = credentials;
                tsaClient = new TSAClientBouncyCastle(Credentials.TsaUrl, Credentials.UserId, Credentials.Password, 3000, Credentials.TimeStampDigestAlg);
            } // IF ENDS
            else
            {
                throw new ArgumentNullException(nameof(credentials));
            } // ELSE ENDS
        } // CONSTRUCTOR METHOD ENDS ------------------------------------------------------------------------------------------------------ //



    } // CLASS SDS TSA DEFAULT CLIENT ENDS ------------------------------------------------------------------------------------------------ //
}
