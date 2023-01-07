#region Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved
// Web: https://technosoftware.com 
// 
// License: 
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:

// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.

// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//
// SPDX-License-Identifier: MIT
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2023 Technosoftware GmbH. All rights reserved

#region Using Directives
using System;
using Technosoftware.DaAeHdaClient;
using Technosoftware.DaAeHdaClient.Da;
using Technosoftware.DaAeHdaClient.Hda;
#endregion

namespace Technosoftware.HdaConsole
{
    /// <summary>
	/// Simple OPC HDA Client Application
	/// </summary>
	public class OpcSample
	{
        #region Event Handlers

		/// <summary>
		/// Called when a read request completes.
		/// </summary>
		public void OnReadComplete(IOpcRequest request, TsCHdaItemValueCollection[] results)
		{
			Console.WriteLine("OnReadComplete():");

		}

		#endregion

		#region OPC Sample Functionality

		public void Run()
		{
			try
			{
				const string serverUrl = "opchda://localhost/OPCSample.OpcHdaServer";

				Console.WriteLine();
				Console.WriteLine("Simple OPC HDA Client based on the OPC DA/AE/HDA Solution .NET");
				Console.WriteLine("--------------------------------------------------------------");
				Console.Write("   Press <Enter> to connect to "); Console.WriteLine(serverUrl);
				Console.ReadLine();
				Console.WriteLine("   Please wait...");

                // Get the server object
                TsCHdaServer myHdaServer = GetServerForUrl(serverUrl);


				myHdaServer.Connect();

				Console.WriteLine("   Connected, press <Enter> to add a trend.");
				Console.ReadLine();

                // Add a trend and set the properties for reading
                TsCHdaTrend trend = new TsCHdaTrend(myHdaServer) { StartTime = new TsCHdaTime(new DateTime(2004, 01, 01, 00, 00, 00)), EndTime = new TsCHdaTime(new DateTime(2004, 01, 01, 06, 00, 00)), IncludeBounds = true, MaxValues = 1000 };

				OpcItem itemId = new OpcItem("Static Data/Ramp [15 min]");

                trend.Timestamps.Add(new DateTime(2016, 01, 01, 00, 00, 00));

                trend.ReadRaw(new OpcItem[] { trend.AddItem(itemId) }, null, OnReadComplete, out _);

				// read the historic data of the specified item
				TsCHdaItemValueCollection[] items = trend.ReadRaw(new[] { trend.AddItem(itemId) });
				foreach (TsCHdaItemValueCollection item in items)
				{
					Console.WriteLine($"{item.ItemName}");

					foreach (TsCHdaItemValue val in item)
					{
						if ((val.Quality.GetCode() & (int)TsDaQualityMasks.QualityMask) != (int)TsDaQualityBits.Good)
							Console.WriteLine($"      {val.Timestamp}, {val.Quality}");
						else
							Console.WriteLine($"      {val.Timestamp}, {val.Value}");
					}
				}

                trend.Timestamps.Add(new DateTime(2016, 01, 01, 00, 00, 00));
                items = trend.ReadAtTime(new[] { trend.AddItem(itemId) });
                foreach (TsCHdaItemValueCollection item in items)
                {
                    Console.WriteLine($"{item.ItemName}");


                    foreach (TsCHdaItemValue val in item)
                    {
                        if ((val.Quality.GetCode() & (int)TsDaQualityMasks.QualityMask) != (int)TsDaQualityBits.Good)
                            Console.WriteLine($"      {val.Timestamp}, {val.Quality}");
                        else
                            Console.WriteLine($"      {val.Timestamp}, {val.Value}");
                    }
                }
                Console.WriteLine("   Historical Data Trend read, press <Enter> to disconnect from the server.");
				myHdaServer.Disconnect(); 
                myHdaServer.Dispose();
				Console.ReadLine();
				Console.WriteLine("   Disconnected from the server.");
				Console.WriteLine();

			}
			catch (OpcResultException e)
			{
				Console.WriteLine("   " + e.Message);
				Console.ReadLine();
            }
			catch (Exception e)
			{
				Console.WriteLine("   " + e.Message);
				Console.ReadLine();
            }
		}

        #endregion

        #region Helper Methods
        /// <summary>
        /// Creates a server object for the specified URL.
        /// </summary>
        public static TsCHdaServer GetServerForUrl(string url)
        {
            if (url == null)
            {
                throw new ArgumentNullException(nameof(url));
            }

            OpcUrl opcUrl = new OpcUrl(url);

            TsCHdaServer server = null;

            // create an unconnected server object for COM based servers.
            // HDA
            if (opcUrl.Scheme == OpcUrlScheme.HDA)
            {
                server = new TsCHdaServer(new DaAeHdaClient.Com.Factory(), opcUrl);
            }

            // Other specifications not supported in this example.
            else
            {
                throw new NotSupportedException(opcUrl.Scheme);
            }

            return server;
        }
        #endregion

    }
}
