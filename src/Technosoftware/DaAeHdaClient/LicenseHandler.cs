#region Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
// Web: https://technosoftware.com  
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved

#region Using Directives

using System;
using System.Linq;

using Technosoftware.DaAeHdaClient.Utilities;

#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// Manages the license to enable the different product versions.
    /// </summary>
    public class LicenseHandler
    {
        #region Nested Enums

        /// <summary>
        /// The possible products.
        /// </summary>
        [Flags]
        public enum ProductLicense : uint
        {
            /// <summary>
            /// No product selected
            /// </summary>
            None = 0,

            /// <summary>
            /// OPC UA Client .NET
            /// </summary>
            Client = 1,

            /// <summary>
            /// OPC UA Server .NET
            /// </summary>
            Server = 2,

            /// <summary>
            /// Evaluation
            /// </summary>
            Evaluation = 4,

            /// <summary>
            /// Expired Evaluation or License
            /// </summary>
            Expired = 8,
        }

        /// <summary>
        /// The possible products.
        /// </summary>
        [Flags]
        public enum ProductFeature : uint
        {
            /// <summary>
            /// Basic OPC UA Features enabled
            /// </summary>
            None = 0,

            /// <summary>
            /// OPC UA DataAccess enabled
            /// </summary>
            DataAccess = 1,

            /// <summary>
            /// OPC UA Alarms and Conditions enabled
            /// </summary>
            AlarmsConditions = 2,

            /// <summary>
            /// OPC UA Historical Access and Historical Events enabled
            /// </summary>
            HistoricalAccess = 4,

            /// <summary>
            /// All supported OPC UA Features enabled
            /// </summary>
            AllFeatures = uint.MaxValue,
        }


        #endregion

        #region Constants

        /// <summary>
        /// License Validation Parameters String for the OPC UA Solution .NET
        /// </summary> 
        const string LicenseParameter =
            @"";

        #endregion

        #region Private Fields
        internal static bool LicenseTraceDone;
        #endregion

        #region Properties

        /// <summary>
        /// Returns whether the product is a licensed product.
        /// </summary>
        /// <returns>Returns true if the product is licensed; false if it is used in evaluation mode or license is expired.</returns>
        public static bool IsLicensed
        {
            get
            {
                if ((LicensedProduct == ProductLicense.None) ||
                    ((LicensedProduct & ProductLicense.Expired) == ProductLicense.Expired) ||
                    ((LicensedProduct & ProductLicense.Evaluation) == ProductLicense.Evaluation))
                {
                    return false;
                }
                return true;
            }
        }

        /// <summary>
        /// Returns whether the product is an evaluation version.
        /// </summary>
        /// <returns>Returns true if the product is an evaluation; false if it is a product or license is expired.</returns>
        public static bool IsEvaluation
        {
            get
            {
                if ((LicensedProduct & ProductLicense.Evaluation) == ProductLicense.Evaluation)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Indicates whether the evaluation period and a restart is required or not.
        /// </summary>
        public static bool IsExpired => !Check();

        /// <summary>
        /// Returns the Version of the product.
        /// </summary>
        public static string Version
        {
            get
            {
                var version = (typeof(LicenseHandler).Assembly.GetName().Version);

                var major = version.Major;
                var minor = version.Minor;
                var build = version.Build;
                var revision = version.Revision;

                var versionString = revision == 0 ? $"{major}.{minor} ( Build {build} )" : $"{major}.{minor} ( Build {build}.{revision} )";
                return versionString;
            }
        }

        /// <summary>
        /// Returns the licensed products.
        /// </summary>
        public static ProductLicense LicensedProduct { get; set; } = ProductLicense.Client;

        /// <summary>
        /// Returns the licensed OPC UA Features.
        /// </summary>
        public static ProductFeature LicensedFeatures { get; set; } = ProductFeature.AllFeatures;

        /// <summary>
        /// Returns the licensed product name.
        /// </summary>
        public static string Product
        {
            get
            {
                var product = "Expired Evaluation or License";

                if ((LicensedProduct & ProductLicense.Expired) == ProductLicense.Expired)
                {
                    // It's an expired evaluation or license
                    if (((LicensedProduct & ProductLicense.Client) == ProductLicense.Client) &&
                        ((LicensedProduct & ProductLicense.Server) == ProductLicense.Server))
                    {
                        product = "Expired OPC UA Bundle .NET license";
                    }
                    else if ((LicensedProduct & ProductLicense.Client) == ProductLicense.Client)
                    {
                        product = "Expired OPC UA Client .NET license";
                    }
                    else if ((LicensedProduct & ProductLicense.Server) == ProductLicense.Server)
                    {
                        product = "Expired OPC UA Server .NET license";
                    }
                    else if ((LicensedProduct & ProductLicense.Evaluation) == ProductLicense.Evaluation)
                    {
                        product = "Expired OPC UA Bundle .NET Evaluation";
                    }
                    return product;
                }

                // It's a license or evaluation
                if (((LicensedProduct & ProductLicense.Client) == ProductLicense.Client) &&
                     ((LicensedProduct & ProductLicense.Server) == ProductLicense.Server))
                {
                    product = "OPC UA Bundle .NET";
                }
                else if ((LicensedProduct & ProductLicense.Client) == ProductLicense.Client)
                {
                    product = "OPC UA Client .NET";
                }
                else if ((LicensedProduct & ProductLicense.Server) == ProductLicense.Server)
                {
                    product = "OPC UA Server .NET";
                }
                else if ((LicensedProduct & ProductLicense.Evaluation) == ProductLicense.Evaluation)
                {
                    product = "OPC UA Bundle .NET Evaluation";
                }

                return product;
            }
        }

        /// <summary>
        /// Returns the product information.
        /// </summary>
        public static string ProductInformation
        {
            get
            {
                if (IsLicensed)
                {
                    return Product;
                }
                if (!Check())
                {
                    return Product + " EVALUATION EXPIRED !!!";
                }
                return Product + " EVALUATION";
            }
        }

        internal static bool Checked { get; private set; }

        #endregion

        #region Public Methods
        /// <summary>
        /// Validate the license.
        /// </summary>
        /// <param name="serialNumber">Serial Number</param>
        public static bool Validate(string serialNumber)
        {
            return CheckLicense(serialNumber);
        }
        #endregion
        
        #region Protected Methods
        /// <summary>
        /// Validate the license.
        /// </summary>
        /// <param name="serialNumber">Serial Number</param>
        protected static bool CheckLicense(string serialNumber)
        {
            var check = false;

            check = CheckLicenseClient(serialNumber);
            CheckProductFeature(serialNumber);

            if (check)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Check if the licensed product provided through ValidateLicense qualifies for the given application type and license edition.
        /// </summary>
        /// <returns>True if the license qualifies for the requested application and edition or if the evaluation period is still running; otherwise False.</returns>
        protected static bool CheckLicense()
        {
            if (Checked && LicensedProduct == ProductLicense.None)
            {
                return false;
            }

            if (Checked &&
               ((LicensedProduct & ProductLicense.Client) == ProductLicense.Client))
            {
                return true;
            }
            CheckProductFeature("");
            return Check();
        }

        #endregion

        #region Internal Methods
        /// <summary>
        /// Core Feature validation
        /// </summary>
        /// <returns>True if valid; false otherwise</returns>
        /// <exception cref="BadInternalErrorException"></exception>
        internal static void ValidateFeatures(ProductFeature requiredProductFeature = ProductFeature.None)
        {
            var valid = CheckLicense();

            if (!LicenseTraceDone)
            {
                LicenseTraceDone = true;
                Utils.Trace("Used Product = {0}, Features = {1}, Version = {2}.", Product, LicensedFeatures, Version);
            }

            if (!valid && !IsLicensed)
            {
                throw new BadInternalErrorException("Evaluation time expired! You need to restart the application.");
            }
            if (!valid)
            {
                throw new BadInternalErrorException("License required! You can't use this feature.");
            }

            if (requiredProductFeature != ProductFeature.None && LicensedFeatures != ProductFeature.AllFeatures)
            {
                if ((requiredProductFeature & LicensedFeatures) != requiredProductFeature)
                {
                    var message =
                        $"Feature {requiredProductFeature} required but only {LicensedFeatures} licensed! You can't use this feature.";
                    throw new BadInternalErrorException(message);
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Validate the license.
        /// </summary>
        /// <param name="licenseKey">The license key</param>
        protected static void CheckProductFeature(string licenseKey)
        {
        }

        /// <summary>
        /// Validate the license.
        /// </summary>
        /// <param name="licenseKey">The license key</param>
        protected static bool CheckLicenseClient(string licenseKey)
        {
            return true;
        }

        internal static bool Check()
        {
            return true;
        }
        #endregion
    }
}
