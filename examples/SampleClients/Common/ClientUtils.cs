#region Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved
// Web: https://technosoftware.com  
// 
// Purpose: 
// 
//
// The Software is subject to the Technosoftware GmbH Source Code License Agreement, 
// which can be found here:
// https://technosoftware.com/documents/Source_License_Agreement.pdf
// 
// The Software is based on the OPC .NET API Sample Code.
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2022 Technosoftware GmbH. All rights reserved

#region Using Directives

using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

#endregion

namespace SampleClients.Common
{
    /// <summary>
    /// A class that provide various common utility functions and shared resources.
    /// </summary>
    public partial class ClientUtils : UserControl
    {
        #region Nested type: NativeMethods

        private static class NativeMethods
        {
            [DllImport("user32.dll", CharSet = CharSet.Unicode)]
            static extern internal IntPtr LoadIcon(IntPtr hInstance, string lpIconName);

            [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
            static extern internal IntPtr LoadLibrary(string lpFileName);
        }

        #endregion

        #region Constructors, Destructor, Initialization

        /// <summary>
        /// Initializes a new instance of the <see cref="ClientUtils"/> class.
        /// </summary>
        public ClientUtils()
        {
            InitializeComponent();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Returns the application icon.
        /// </summary>
        public static Icon GetAppIcon()
        {
            string fileName = Assembly.GetEntryAssembly().Location;
            IntPtr hLibrary = NativeMethods.LoadLibrary(fileName);

            if (hLibrary != IntPtr.Zero)
            {
                IntPtr hIcon = NativeMethods.LoadIcon(hLibrary, "#32512");

                if (hIcon != IntPtr.Zero)
                {
                    return Icon.FromHandle(hIcon);
                }
            }

            return null;
        }

        #endregion
    }
}