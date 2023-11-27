/*
ScPl - A plotting library for .NET

LabelAxis.cs
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
$Id: LabelAxis.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Collections;
using System.Drawing;

namespace SampleClients.ScPl
{
	public class LabelAxis : Axis
	{
		/// <summary>
		/// Deep copy of LinearAxis.
		/// </summary>
		/// <returns>A copy of the LinearAxis Class</returns>
		public override object Clone()
		{
			LabelAxis a = new LabelAxis();
			// ensure that this isn't being called on a derived type. If it is, then oh no!
			if (GetType() != a.GetType())
			{
				throw new System.Exception( "Clone not defined in derived type. Help!" );
			}
			DoClone( this, a );
			return a;
		}

		/// <summary>
		/// Helper method for Clone.
		/// </summary>
		protected static void DoClone( LabelAxis b, LabelAxis a )
		{
			Axis.DoClone( b, a );

			a.labels_ = (ArrayList)b.labels_.Clone();
			a.numbers_ = (ArrayList)b.numbers_.Clone();

			// a_.property = this.property
		}

		private void init()
		{
			labels_ = new ArrayList();
			numbers_ = new ArrayList();
		}

		public LabelAxis( Axis a )
			: base( a )
		{
			init();
		}

		public LabelAxis()
			: base()
		{
			init();
		}

		public LabelAxis( double worldMin, double worldMax )
			: base( worldMin, worldMax )
		{
			init();
		}

		public void AddLabel( string name, double val )
		{
			labels_.Add( name );
			numbers_.Add( val );
		}

		private ArrayList DrawTicks( Graphics g, PointF physicalMin, PointF physicalMax )
		{
			PointF offset = new PointF( 0.0f, 0.0f );
			object bb = null;

			for (int i=0; i<labels_.Count; ++i)
			{
				if ((double)numbers_[i] > WorldMin && (double)numbers_[i] < WorldMax)
				{

					ArrayList r = DrawTick( g, (double)numbers_[i], LargeTickSize, (string)labels_[i],
						new Point(0,0), physicalMin, physicalMax );

					// determining largest label offset.
					PointF o = (PointF)r[0];
					double norm1 = Math.Sqrt( offset.X*offset.X + offset.Y*offset.Y );
					double norm2 = Math.Sqrt( o.X*o.X + o.Y*o.Y );
					if (norm1<norm2)
					{
						offset = o;
					}
					// determining bounding box.
					RectangleF b = (RectangleF)r[1];
					if (bb == null)
					{
						bb = b;
					}
					else
					{
						bb = RectangleF.Union( (RectangleF)bb, b );
					}

				}
			}

			ArrayList toRet = new ArrayList();
			toRet.Add( offset );
			toRet.Add( bb );

			return toRet;
		}

		#region LargeTickPositions
		public override ArrayList LargeTickPositions
		{
			get
			{
				ArrayList toRet = new ArrayList();
				for (int i=0; i<labels_.Count; ++i)
				{
					if ((double)numbers_[i] > WorldMin && (double)numbers_[i] < WorldMax)
					{
						toRet.Add( numbers_[i] );
					}
				}

				return toRet;
			}
		}
		#endregion

		public override object Draw( System.Drawing.Graphics g, PointF physicalMin, PointF physicalMax )
		{
			PointF labelOffset;
			RectangleF tickBounds;
			RectangleF baseBB;

			if (!Hidden)
			{
				ArrayList r = DrawTicks( g, physicalMin, physicalMax );
				labelOffset = (PointF)r[0];
				tickBounds = (RectangleF)r[1];
				baseBB = base.DoDraw( g, labelOffset, physicalMin, physicalMax );

				return RectangleF.Union( baseBB, tickBounds );
			}

			return null;
		}

		private ArrayList labels_;
		private ArrayList numbers_;
	}
}
