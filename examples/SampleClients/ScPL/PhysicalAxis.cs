/*
ScPl - A plotting library for .NET

PhysicalAxis.cs
Copyright (C) 2003
Matt Howlett, Paolo Pierini

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

$Id: PhysicalAxis.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace SampleClients.ScPl
{
	/// <summary>
	/// Unfortunately, C# doesn't have templates. If it did, I would derive PhysicalAxis from
	/// the templated Axis type (LinearAxis etc). Instead, use a has-a relationship with an
	/// Axis superclass.
	/// </summary>
	public class PhysicalAxis
	{
		#region init
		/// <summary>
		/// helper function for constructors
		/// </summary>
		private void init()
		{
			axis_ = null;
			physicalMax_ = null;
			physicalMin_ = null;
		}
		#endregion
		#region constructors
		public PhysicalAxis()
		{
			init();
		}

		public PhysicalAxis( Axis a, PointF physicalMin, PointF physicalMax )
		{
			axis_ = a;
			physicalMin_ = physicalMin;
			physicalMax_ = physicalMax;
		}
		#endregion
		#region GetBoundingBox
		public virtual RectangleF GetBoundingBox( )
		{
			System.Drawing.Bitmap b = new System.Drawing.Bitmap(1,1);
			Graphics g = Graphics.FromImage(b);
			return (RectangleF)Draw(g);
		}
		#endregion
		#region Draw
		public virtual object Draw( System.Drawing.Graphics g )
		{
			return axis_.Draw( g, (PointF)physicalMin_, (PointF)physicalMax_ );
		}
		#endregion
		#region WorldToPhysical
		public PointF WorldToPhysical( double coord, bool clip )
		{
			return axis_.WorldToPhysical( coord, (PointF)physicalMin_, (PointF)physicalMax_, clip );
		}
		#endregion
		#region PhysicalToWorld
		public double PhysicalToWorld( PointF p, bool clip )
		{
			return axis_.PhysicalToWorld(p, (PointF)physicalMin_, (PointF)physicalMax_, clip );
		}
		#endregion
		#region get/set PhysicalMin
		public PointF PhysicalMin
		{
			get
			{
				return (PointF)physicalMin_; // unbox.
			}
			set
			{
				physicalMin_ = value; // box.
			}
		}
		#endregion
		#region get/set PhysicalMax
		public PointF PhysicalMax
		{
			get
			{
				return (PointF)physicalMax_; // unbox.
			}
			set
			{
				physicalMax_ = value; // box.
			}
		}
		#endregion
		#region get/set Axis
		public Axis Axis
		{
			get
			{
				return axis_;
			}
			set
			{
				axis_ = value;
			}
		}
		#endregion

		private Axis axis_;
		protected object physicalMin_;  // Boxed. Defaults to null.
		protected object physicalMax_;
	}
}
