/*
ScPl - A plotting library for .NET

LinearAxis.cs
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

$Id: LinearAxis.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System.Drawing;
using System.Collections;
using System;
using System.Text;
using System.Diagnostics;

namespace SampleClients.ScPl
{
	/// <summary>
	/// Linear Axis class
	/// </summary>
	public class LinearAxis : Axis, System.ICloneable
	{
		#region Clone Implementation
		/// <summary>
		/// Deep copy of LinearAxis.
		/// </summary>
		/// <returns>A copy of the LinearAxis Class</returns>
		public override object Clone()
		{
			LinearAxis a = new LinearAxis();
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
		protected void DoClone( LinearAxis b, LinearAxis a )
		{
			Axis.DoClone( b, a );

			a.numberSmallTicks_ = b.numberSmallTicks_;
			a.largeTickValue_ = b.largeTickValue_;
			a.largeTickStep_ = b.largeTickStep_;
		}
		#endregion

		#region Constructors
		public LinearAxis( Axis a )
			: base( a )
		{
		}

		public LinearAxis()
			: base()
		{
		}

		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="worldMin">the minimum world coordinate</param>
		/// <param name="worldMax">the maximum world coordinate</param>
		public LinearAxis( double worldMin, double worldMax )
			: base( worldMin, worldMax )
		{
		}
		#endregion

		#region Draw Method
		/// <summary>
		/// Draw the axis
		/// </summary>
		/// <param name="g">The drawing surface on which to draw</param>
		/// <param name="physicalMin">The minimum physical extent of the axis</param>
		/// <param name="physicalMax">The maximum physical extent of the axis</param>
		/// <returns>The bounding box of the axis. Currently ignores tick marks.</returns>
		public override object Draw( System.Drawing.Graphics g, PointF physicalMin, PointF physicalMax )
		{
			PointF labelOffset;
			RectangleF tickBounds;
			RectangleF baseBB;
			RectangleF BB;

			if (!Hidden)
			{
				ArrayList r = DrawTicks( g, physicalMin, physicalMax );
				labelOffset = (PointF)r[0];
				tickBounds = (RectangleF)r[1];
				baseBB = base.DoDraw( g, labelOffset, physicalMin, physicalMax );

				BB= RectangleF.Union( baseBB, tickBounds );
				return BB;
			}

			return null;
		}
		#endregion

		// TODO: change this to return values using out's.
		#region DrawTicks
		/// <summary>
		/// Draw the ticks
		/// </summary>
		/// <param name="g">The drawing surface on which to draw</param>
		/// <param name="physicalMin"> </param>
		/// <param name="physicalMax"> </param>
		/// <returns> An ArrayList containing the offset from the axis required for an axis label
		/// to miss this tick, followed by a bounding rectangle for the tick and tickLabel drawn </returns>
		private ArrayList DrawTicks( Graphics g, PointF physicalMin, PointF physicalMax )
		{
			// large ticks X position is in l1
			ArrayList l1 = LargeTickPositions;
			double dOffset = 0;	//this.Offset;
			double dScale = 1;	//this.Scale;
			string strFormat = NumberFormat;

			PointF offset = new PointF( 0.0f, 0.0f );
			object bb = null;
			if (l1.Count == 0) 
			{
				StringBuilder label = new StringBuilder();
				double dVal = ((double)l1[0] * dScale) + dOffset;

				// do google search for "format specifier writeline" for help on this.
				label.AppendFormat(strFormat, dVal);
				ArrayList r = DrawTick( g, (double)l1[0], LargeTickSize, label.ToString(),
					new Point(0,0), physicalMin, physicalMax );

				// determining largest label offset.
				PointF o = (PointF)r[0];
				double norm1 = Math.Sqrt( (offset.X * offset.X) + (offset.Y * offset.Y) );
				double norm2 = Math.Sqrt( (o.X * o.X) + (o.Y * o.Y) );
				if (norm1 < norm2)
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
			else 
			{
				for (int i = 0; i < l1.Count; ++i)
				{
					StringBuilder label = new StringBuilder();
					double dVal = ((double)l1[i] * dScale) + dOffset;

					// do google search for "format specifier writeline" for help on this.
					label.AppendFormat(strFormat, dVal);

					ArrayList r = DrawTick( g, (double)l1[i], LargeTickSize, label.ToString(),
						new Point(0,0), physicalMin, physicalMax );

					// determining largest label offset.
					PointF o = (PointF)r[0];
					double norm1 = Math.Sqrt( (offset.X * offset.X) + (offset.Y * offset.Y) );
					double norm2 = Math.Sqrt( (o.X * o.X) + (o.Y * o.Y) );
					if (norm1 < norm2)
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

			ArrayList stp = SmallTickPositions;

			for (int i = 0; i < stp.Count; ++i)
			{
				ArrayList r = DrawTick( g, (double)stp[i], SmallTickSize,
					"", new Point(0,0), physicalMin, physicalMax );
				// ignore r for now - assume bb unchanged by small tick bounds.
			}

			ArrayList toRet = new ArrayList();
			toRet.Add( offset );
			toRet.Add( bb );

			return toRet;
		}
		#endregion

		#region SmallTickPositions
		public override ArrayList SmallTickPositions
		{
			get
			{
				ArrayList toRet = new ArrayList();

				ArrayList l1 = LargeTickPositions;

				double bigTickSpacing = DetermineTickSpacing();
				int nSmall = DetermineNumberSmallTicks( bigTickSpacing );
				double smallTickSpacing = bigTickSpacing / nSmall;

				// if there is at least one big tick
				if (l1.Count > 0)
				{
					double pos1 = (double)l1[0];
					while (pos1 > WorldMin)
					{
						pos1 -= smallTickSpacing;
						toRet.Add(pos1);
					}
				}

				for (int i = 0; i < l1.Count; ++i )
				{
					for (int j = 1; j < nSmall; ++j )
					{
						double pos = (double)l1[i] + ((double)j) * smallTickSpacing;
						if (pos <= WorldMax)
						{
							toRet.Add( pos );
						}
					}
				}
				return toRet;
			}
		}
		#endregion
		#region LargeTickPositions
		public override ArrayList LargeTickPositions
		{
			get
			{
				if ( (worldMin_ == null) || (worldMax_ == null) )
				{
					throw new System.Exception( "world extent of axis not set." );
				}

				ArrayList res = new ArrayList();
				double roundTickDist;

				// now determine first tick position.
				double first = 0.0f;

				// if the user hasn't specified a large tick position.
				if (largeTickStep_ != null)
				{
					roundTickDist = (double)largeTickStep_;
					first = roundTickDist;

					// TODO: check here not too much different.
					// could result in long loop.
					while (first < WorldMin)
					{
						first += roundTickDist;
					}

					while (first >= (WorldMin + roundTickDist))
					{
						first -= roundTickDist;
					}
				}
				else if (largeTickValue_ != null) 
				{
					roundTickDist = (double)largeTickValue_;
					first = roundTickDist;

					// TODO: check here not too much different.
					// could result in long loop.
					while (first < WorldMin)
					{
						first += roundTickDist;
					}

					while (first >= (WorldMin + roundTickDist))
					{
						first -= roundTickDist;
					}
				}
				else
				{
					roundTickDist = DetermineTickSpacing( );
					if( WorldMin > 0.0 )
					{
						double nToFirst = Math.Floor(WorldMin / roundTickDist) + 1.0f;
						first = nToFirst * roundTickDist;
					}
					else
					{
						double nToFirst = Math.Floor(-WorldMin/roundTickDist) - 1.0f;
						first = -nToFirst * roundTickDist;
					}

					// could miss one, if first is just below zero.
					if ((first - roundTickDist) >= WorldMin)
					{
						first -= roundTickDist;
					}
				}
					// the user has specified one place they would like a large tick placed.

				double mark = first;
				double worldMax = (double)worldMax_;
				double worldMin = (double)worldMin_;
				if (mark < worldMax)
				{
					// Range test in case the User's Tick value (largeTickValue_, largeTickStep_) is out of range
					while ((mark <= worldMax ) && (mark >= worldMin))
					{
						res.Add(mark);
						mark += roundTickDist;
					}
				}
				else
				{
					while ((mark >= worldMax) && (mark <= worldMin))
					{
						res.Add(mark);
						mark += roundTickDist;
					}
				}

				return res;
			}
		}
		#endregion
		#region DetermineTickSpacing
		private double DetermineTickSpacing( )
		{
			if ( worldMin_ == null || worldMax_ == null )
			{
				throw new System.Exception( "world extent of axis not set." );
			}

			if (largeTickStep_ != null)
			{
				if ( (double)largeTickStep_ <= 0.0f )
				{
					throw new System.Exception( "can't have negative tick step - reverse WorldMin WorldMax instead." );
				}

				return (double)largeTickStep_;
			}

			double range = WorldMax - WorldMin;

			if ( range > 0.0 )
			{
				// the 3.0 is magic enough that I'll hard code it here for now.
				double approxTickDist = range / 3.0f;

				// normalize tick distance down to value between 0.1 -> 1.0.
				int tenMulCount = 0;
				while( approxTickDist >= 1.0f )
				{
					approxTickDist /= 10.0f;
					tenMulCount -= 1;
				}
				while( approxTickDist < 0.1f )
				{
					approxTickDist *= 10.0f;
					tenMulCount += 1;
				}

				// now calulate a nice round tick dist.
				double roundTickDist = 0.0f;

				if( approxTickDist < 0.2f )
				{
					roundTickDist = 0.1f;
				}
				else if (approxTickDist < 0.5f)
				{
					roundTickDist = 0.2f;
				}
				else
				{
					roundTickDist = 0.5f;
				}

				// now renormalize..
				if ( tenMulCount > 0 )
				{
					for( int i=0; i<tenMulCount; ++i )
					{
						roundTickDist /= 10.0f;
					}
				}
				else if (tenMulCount < 0)
				{
					for( int i=0; i<-tenMulCount; ++i )
					{
						roundTickDist *= 10.0f;
					}
				}
				return roundTickDist;
			}
			else
			{
				return 0.0f;
			}
		}
		#endregion
		#region DetermineNumberSmallTicks
		private int DetermineNumberSmallTicks( double bigTickDist )
		{
			if (numberSmallTicks_ != null)
			{
				return (int)numberSmallTicks_+1;
			}

			if( bigTickDist>0.0f)
			{
				while( bigTickDist >= 1.0f )
				{
					bigTickDist /= 10.0f;
				}
				while( bigTickDist < 0.1f )
				{
					bigTickDist *= 10.0f;
				}

				if( bigTickDist < 0.15f )
				{
					return 5;
				}
				else if( bigTickDist < 0.3f )
				{
					return 2;
				}
				else
				{
					return 5;
				}
			}
			else
			{
				return 0;
			}
		}
		#endregion

		// properties to box/unbox the private members
		#region LargeTickStep
		public double LargeTickStep
		{
			set
			{
				largeTickStep_ = value;
			}
			get
			{
				return (double)largeTickStep_;
			}
		}
		#endregion
		#region LargeTickValue
		public double LargeTickValue
		{
			set
			{
				largeTickValue_ = value;
			}
			get
			{
				return (double)largeTickValue_;
			}
		}
		#endregion
		#region NumberSmallTicks
		public int NumberSmallTicks
		{
			set
			{
				numberSmallTicks_ = value;
			}
			get
			{
				return (int)numberSmallTicks_;
			}
		}
		#endregion

		private object numberSmallTicks_;
		private object largeTickValue_;
		private object largeTickStep_;

	}
}
