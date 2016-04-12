using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subvertic.DocumentSecurity.PKI.TSA
{

    // ------------------------------------------------------------------------------------------------------------------------------------ //
    // CLASS TSA CREDENTIALS                                                                                                                //
    // ------------------------------------------------------------------------------------------------------------------------------------ //
    /// <summary>
    ///     This class is used to hold credentials required to use a Time Stamp Authority (TSA) Service
    /// </summary>
    public class TsaCredentials
    {
        public string UserId { set; get; }
        public string Password { set; get; }
        public string TsaUrl { set; get; }
        public string TimeStampDigestAlg { set; get; }
        public int TokenSizeEstimate { set; get; }


        // -------------------------------------------------------------------------------------------------------------------------------- //
        // CONSTRUCTOR                                                                                                                      //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Creates instances of TSA Credentials
        /// </summary>
        public TsaCredentials()
        {
            
        } // DEFAULT CONSTRUCTOR ENDS ----------------------------------------------------------------------------------------------------- //
        
        // -------------------------------------------------------------------------------------------------------------------------------- //
        // CONSTRUCTOR METHOD                                                                                                               //
        // -------------------------------------------------------------------------------------------------------------------------------- //
        /// <summary>
        ///     Creates Instances of TSA Credentials with given parameters
        /// </summary>
        /// <param name="userId">Username or id used to connect to TSA</param>
        /// <param name="password">Password associated to the TSA </param>
        /// <param name="tsaUrl">Base Url of the TSA Service</param>
        /// <param name="tsDigestAlg">Algorithm Used as TimeStamp Hash</param>
        public TsaCredentials(string userId, string password, string tsaUrl, string tsDigestAlg, int tSzEstimate)
        {
            UserId = userId;
            Password = password;
            TsaUrl = tsaUrl;
            TimeStampDigestAlg = tsDigestAlg;
            TokenSizeEstimate = tSzEstimate;
        } // CONSTRUCTOR METHOS ENDS ------------------------------------------------------------------------------------------------------ //

    } // CLASS TSA CREDENTIALS ENDS ------------------------------------------------------------------------------------------------------- //
}
