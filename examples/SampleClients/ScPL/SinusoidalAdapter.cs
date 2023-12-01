/*
ScPl - A plotting library for .NET

SinusoidalAdapter.cs
Copyright (C) 2003
Matt Howlett

Redistribution and use in source and binary forms, with or without
modification, are permitted provided that the following conditions
are met:

1. Redistributions of source code must retain the above copyright
   notice, this list of conditions and the following disclaimer.
   
2. Redistributions in binary form must reproduce the following text in 
   the documentation and / or other materials provided with the 
   distribution: 
   
   "This product includes software developed as part of 
   the ScPl plotting library project available from: 
   http://www.netcontrols.org/scpl/" 

------------------------------------------------------------------------

THIS SOFTWARE IS PROVIDED BY THE AUTHOR ``AS IS'' AND ANY EXPRESS OR
IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES
OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED.
IN NO EVENT SHALL THE AUTHOR BE LIABLE FOR ANY DIRECT, INDIRECT,
INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT
NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE,
DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY
THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT
(INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF
THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

$Id: SinusoidalAdapter.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;

namespace SampleClients.ScPl
{
	/// <summary>
	/// Simple Data Adapter for making Sinusoidal Data
	/// expand... just enough for an example.
	/// </summary>
	public class SinusoidalAdapter : ISequenceAdapter
	{

		private int numberPoints_ = 50;
		private double phase_ = 0.0f;
		private double omega_ = (double)(Math.PI * 2.0);
		private double amplitude_ = 1.0f;
		private double sampleSpacing_ = (double)(Math.PI * 2.0)/100.0f;

		public SinusoidalAdapter()
		{
		}

		public SinusoidalAdapter( double amplitude, double omega, double phase, int numberPoints, double sampleSpacing )
		{
			omega_ = (double)omega;
			phase_ = (double)phase;
			amplitude_ = (double)amplitude;
			numberPoints_ = numberPoints;
			sampleSpacing_ = sampleSpacing;
		}

		public int Count
		{
			get
			{
				return numberPoints_;
			}
			set
			{
				numberPoints_ = value;
			}
		}

		public double Phase
		{
			get
			{
				return phase_;
			}
			set
			{
				phase_ = value;
			}
		}

		public PointD this[int i]
		{
			get
			{
				double pos = sampleSpacing_ * (double)i;
				return new PointD( pos,
					(double)(amplitude_ * Math.Sin( omega_ * pos + phase_)) );
			}
		}

		public Axis SuggestXAxis()
		{
			// implement a circular axis, and suggest that.
			return new LinearAxis(0.0,(double)sampleSpacing_*(numberPoints_-1));
		}

		public Axis SuggestYAxis()
		{
			return new LinearAxis( -amplitude_*1.1, amplitude_*1.1 );
		}

	}
}
