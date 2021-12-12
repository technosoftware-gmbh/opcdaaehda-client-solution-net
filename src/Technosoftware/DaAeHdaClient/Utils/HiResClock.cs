#region Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
//-----------------------------------------------------------------------------
// Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved
// Web: https://www.technosoftware.com 
// 
// The source code in this file is covered under a dual-license scenario:
//   - Owner of a purchased license: SCLA 1.0
//   - GPL V3: everybody else
//
// SCLA license terms accompanied with this source code.
// See SCLA 1.0://technosoftware.com/license/Source_Code_License_Agreement.pdf
//
// GNU General Public License as published by the Free Software Foundation;
// version 3 of the License are accompanied with this source code.
// See https://technosoftware.com/license/GPLv3License.txt
//
// This source code is distributed in the hope that it will be useful, but
// WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
// or FITNESS FOR A PARTICULAR PURPOSE.
//-----------------------------------------------------------------------------
#endregion Copyright (c) 2011-2021 Technosoftware GmbH. All rights reserved

#region Using Directives
using System;
using System.Diagnostics;
#endregion

namespace Technosoftware.DaAeHdaClient
{
    /// <summary>
    /// Produces high resolution timestamps.
    /// </summary>
    public class HiResClock
    {
        /// <summary>
        /// Returns the current UTC time with a high resolution.
        /// </summary>
        /// <remarks>
        /// This Utc time does not change if the system time is changed.
        /// It returns the Utc time elapsed since the application started.
        /// </remarks>
        public static DateTime UtcNow
        {
            get
            {
                if (s_Default.m_disabled)
                {
                    return DateTime.UtcNow;
                }
                long counter = Stopwatch.GetTimestamp();
                decimal ticks = (counter - s_Default.m_baseline) * s_Default.m_ratio;
                return new DateTime((long)ticks + s_Default.m_offset);
            }
        }

        /// <summary>
        /// Returns a monotonic increasing tick count in milliseconds.
        /// </summary>
        public static long TickCount64
        {
            get
            {
                if (s_Default.m_disabled)
                {
                    return (long)(DateTime.UtcNow.Ticks / TimeSpan.TicksPerMillisecond);
                }
                return (long)(Stopwatch.GetTimestamp() / s_Default.m_ticksPerMillisecond);
            }
        }

        /// <summary>
        /// Return the frequency of the ticks.
        /// </summary>
        public static long Frequency => s_Default.m_disabled ?
            TimeSpan.TicksPerSecond : s_Default.m_frequency;

        /// <summary>
        /// Return the number of ticks per millisecond.
        /// </summary>
        public static double TicksPerMillisecond => s_Default.m_disabled ?
            TimeSpan.TicksPerMillisecond : s_Default.m_ticksPerMillisecond;

        /// <summary>
        /// Disables the hires clock.
        /// </summary>
        public static bool Disabled
        {
            get
            {
                return s_Default.m_disabled;
            }

            set
            {
                // do not enable if unsupported
                if (Stopwatch.IsHighResolution)
                {
                    // check if already initialized.
                    if (!s_Default.m_initialized)
                    {
                        if (s_Default.m_disabled && !value)
                        {
                            // reset baseline
                            s_Default = new HiResClock();
                        }
                        else
                        {
                            s_Default.m_disabled = value;
                        }

                        s_Default.m_initialized = true;
                    }
                    else
                    {
                        // do not allow to set the value multiple times since 
                        // it affects the notifications for existing monitored items.
                    }
                }
            }
        }

        /// <summary>
        /// Reset the baseline and allow a new initialization.
        /// </summary>
        public static void Reset()
        {
            // reset baseline
            s_Default = new HiResClock();
        }

        /// <summary>
        /// Constructs a HiRes clock class.
        /// </summary>
        private HiResClock()
        {
            m_initialized = false;
            m_offset = DateTime.UtcNow.Ticks;
            if (!Stopwatch.IsHighResolution)
            {
                m_frequency = TimeSpan.TicksPerSecond;
                m_ticksPerMillisecond = TimeSpan.TicksPerMillisecond;
                m_baseline = m_offset;
                m_disabled = true;
            }
            else
            {
                m_baseline = Stopwatch.GetTimestamp();
                m_frequency = Stopwatch.Frequency;
                m_ticksPerMillisecond = m_frequency / 1000.0;
            }
            m_ratio = ((decimal)TimeSpan.TicksPerSecond) / m_frequency;
        }

        /// <summary>
        /// Defines a global instance.
        /// </summary>
        private static HiResClock s_Default = new HiResClock();

        private long m_frequency;
        private long m_baseline;
        private long m_offset;
        private double m_ticksPerMillisecond;
        private decimal m_ratio;
        private bool m_disabled;
        private bool m_initialized;
    }

}
