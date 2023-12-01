/*
ScPl - A plotting library for .NET

LogAxis.cs
Copyright (C) 2003
Paolo Pierini, Matt Howlett

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

$Id: LogAxis.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;
using System.Collections;
using System.Text;

namespace SampleClients.ScPl
{
	public class LogAxis : Axis
	{
		#region Clone implementation
		/// <summary>
		/// Deep Copy of the LogAxis
		/// </summary>
		/// <returns>A Copy of the LogAxis Class</returns>
		public override object Clone()
		{
			LogAxis a = new LogAxis();
			if (GetType() != a.GetType())
			{
				throw new System.Exception("Clone not defined in derived type. Help!");
			}
			DoClone( this, a );
			return a;
		}
		/// <summary>
		/// Helper method for Clone (actual implementation)
		/// </summary>
		/// <param name="a"></param>
		/// <param name="b"></param>
		protected void DoClone(LogAxis b, LogAxis a)
		{
			Axis.DoClone(b,a);
			// add specific elemtents of the class for the deep copy of the object
			a.numberSmallTicks_ = b.numberSmallTicks_;
			a.largeTickValue_ = b.largeTickValue_;
			a.largeTickStep_ = b.largeTickStep_;
		}
		#endregion

		#region Constructors
		public LogAxis()
			: base()
		{
		}

		public LogAxis(Axis a)
			: base(a)
		{
		}

		public LogAxis(double worldMin, double worldMax)
			: base(worldMin,worldMax)
		{
		}
		#endregion

		#region Draw Method
		public override object Draw(System.Drawing.Graphics g, PointF physicalMin, PointF physicalMax)
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
		#endregion
		#region DrawTicks
		/// <summary>
		/// Draw the ticks
		/// </summary>
		/// <param name="g">The drawing surface on which to draw</param>
		/// <param name="physicalMin">The minimum physical extent of the axis</param>
		/// <param name="physicalMax">The maximum physical extent of the axis</param>
		/// <returns> An ArrayList containing the offset from the axis required for an axis label
		/// to miss this tick, followed by a bounding rectangle for the tick and tickLabel drawn </returns>
		private ArrayList DrawTicks( Graphics g, PointF physicalMin, PointF physicalMax )
		{
			double dOffset = 0;	//this.Offset;
			double dScale = 1;	//this.Scale;
			string strFormat = NumberFormat;

			// large ticks X position is in l1
			// Log values are in the returned arraylist!
			ArrayList l1 = LargeTickPositions;

			PointF offset = new PointF( 0.0f, 0.0f );
			object bb = null;
			// Missed this protection
			if(l1.Count>0)
			{
				for (int i=0; i<l1.Count; ++i)
				{
					StringBuilder label = new StringBuilder();
					// do google search for "format specifier writeline" for help on this.
					double dVal = ((double)l1[i] * dScale) + dOffset;
					label.AppendFormat(strFormat, dVal);
					ArrayList r = DrawTick( g, (double)l1[i], LargeTickSize, label.ToString(),
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
			else
			{
				// just get the axis bounding box)
				PointF dir=AxisNormVector(physicalMin,physicalMax);
				RectangleF rr=new RectangleF( physicalMin.X,
					(physicalMax.X-physicalMin.X)*dir.X,
					physicalMin.Y,
					(physicalMax.Y-physicalMin.Y)*dir.Y);
				bb=rr;
			}
			ArrayList stp = SmallTickPositions;

			// missed protection for zero ticks
			if(stp.Count>0)
			{
				for (int i=0; i<stp.Count; ++i)
				{
					ArrayList r = DrawTick( g, (double)stp[i], SmallTickSize,
						"", new Point(0,0), physicalMin, physicalMax );
					// ignore r for now - assume bb unchanged by small tick bounds.
				}
			}

			ArrayList toRet = new ArrayList();
			toRet.Add( offset );
			toRet.Add( bb );

			return toRet;
		}
		#endregion

		#region SmallTickPositions
		/// <summary>
		/// Determine the small tick positions for the Log Axis.
		/// </summary>
		public override ArrayList SmallTickPositions
		{
			get
			{
				ArrayList toRet = new ArrayList();

				ArrayList l1 = LargeTickPositions;

				// retrieve the spacing of the big ticks. Remember this is decades!
				double bigTickSpacing = DetermineTickSpacing();
				int nSmall = DetermineNumberSmallTicks( bigTickSpacing );

				// now we have to set the ticks
				// let us start with the easy case where the major tick distance
				// is larger than a decade
				if (bigTickSpacing>1.0F)
				{
					if(l1.Count>0)
					{
						// deal with the smallticks preceding the
						// first big tick
						double pos1 = (double)l1[0];
						while (pos1> WorldMin)
						{
							pos1=pos1/10.0F;
							toRet.Add(pos1);
						}
						// now go on for all other Major ticks
						for (int i=0; i<l1.Count; ++i )
						{
							double pos=(double)l1[i];
							for (int j=1; j<=nSmall; ++j )
							{
								pos=pos*10.0F;
								// check to see if we are still in the range
								if (pos < WorldMax)
								{
									toRet.Add( pos );
								}
							}
						}
					}
				}
				else
				{
					// guess what...
					double [] m={2.0F,3.0F,4.0F,5.0F,6.0F,7.0F,8.0F,9.0F};
					// Then we deal with the other ticks
					if(l1.Count>0)
					{
						// first deal with the smallticks preceding the first big tick
						// positioning before the first tick
						double pos1=(double)l1[0]/10.0F;
						for (int i=0; i<m.Length; i++)
						{
							double pos=pos1*m[i];
							if (pos>WorldMin)
							{
								toRet.Add(pos);
							}
						}
						// now go on for all other Major ticks
						for (int i=0; i<l1.Count; ++i )
						{
							pos1=(double)l1[i];
							for (int j=0; j<m.Length; ++j )
							{
								double pos=pos1*m[j];
								// check to see if we are still in the range
								if (pos < WorldMax)
								{
									toRet.Add( pos );
								}
							}
						}
					}
					else
					{
						// probably a minor tick would anyway fall in the range
						// find the decade preceding the minimum
						double dec=Math.Floor(Math.Log10(WorldMin));
						double pos1=Math.Pow(10.0,dec);
						for (int i=0; i<m.Length; i++)
						{
							double pos=pos1*m[i];
							if (pos>WorldMin && pos< WorldMax )
							{
								toRet.Add(pos);
							}
						}
					}
				}
				return toRet;
			}
		}
		#endregion
		#region LargeTickPositions

		/// <summary>
		///
		/// </summary>
		private static double m_d5Log = -Math.Log10(0.5);   // .30103
		private static double m_d5RegionPos = Math.Abs(m_d5Log + ((1 - m_d5Log) / 2)); //	   ' .6505
		private static double m_d5RegionNeg = Math.Abs(m_d5Log / 2); //	   '.1505
		private void CalcGrids
			( double dLenAxis
			, int nNumDivisions
			, ref double dDivisionInterval)
		{
			double dMyInterval  = dLenAxis / nNumDivisions;
			double dPower = Math.Log10(dMyInterval);
			dDivisionInterval = 10 ^ (int)dPower;
			double dFixPower = dPower - (int)dPower;
			double d5Region = Math.Abs(dPower - dFixPower);
			double dMyMult;
			if (dPower < 0)
			{
				d5Region = -(dPower - dFixPower);
				dMyMult = 0.5;
			}
			else
			{
				d5Region = 1 - (dPower - dFixPower);
				dMyMult = 5;
			}
			if ((d5Region >= m_d5RegionNeg) && (d5Region <= m_d5RegionPos))
			{
				dDivisionInterval = dDivisionInterval * dMyMult;
			}
		}
		/// <summary>
		/// Override for the logic of the large ticks for the log axis
		/// </summary>
		public override ArrayList LargeTickPositions
		{
			get
			{
				if ( worldMin_ == null || worldMax_ == null )
				{
					throw new System.Exception( "world extent of axis not set." );
				}

				ArrayList res = new ArrayList();
				double roundTickDist = DetermineTickSpacing( );

				// now determine first tick position.
				double first = 0.0f;

				// if the user hasn't specified a large tick position.
				if (largeTickValue_ == null)
				{
					if( WorldMin > 0.0 )
					{

						double nToFirst = Math.Floor(Math.Log10(WorldMin) / roundTickDist)+1.0f;
						first = nToFirst * roundTickDist;
					}

					// could miss one, if first is just below zero.
					if (first-roundTickDist >= Math.Log10(WorldMin))
					{
						first -= roundTickDist;
					}
				}
					// the user has specified one place they would like a large tick placed.
				else
				{
					first = Math.Log10(LargeTickValue);

					// TODO: check here not too much different.
					// could result in long loop.
					while (first < Math.Log10(WorldMin))
					{
						first += roundTickDist;
					}

					while (first > Math.Log10(WorldMin)+roundTickDist)
					{
						first -= roundTickDist;
					}
				}

				double mark = first;
				while( mark <= Math.Log10(WorldMax))
				{
					// up to here only logs are dealt with, but I want to return
					// a real value in the arraylist
					double val;
					val=Math.Pow(10.0,mark);
					res.Add(val);
					mark += roundTickDist;
				}

				return res;
			}
		}
		#endregion
		#region DetermineTickSpacing
		/// <summary>
		/// Override to determine the tick spacing for the LogAxis class
		/// </summary>
		/// <returns>The tick spacing (in decades!)</returns>
		private double DetermineTickSpacing( )
		{
			if ( worldMin_ == null || worldMax_ == null )
			{
				throw new System.Exception( "world extent of axis not set." );
			}

			// if largeTickStep has been set, it is used
			if (largeTickStep_!= null)
			{
				if ( (double)largeTickStep_ <= 0.0f )
				{
					throw new System.Exception( "can't have negative tick step - reverse WorldMin WorldMax instead." );
				}

				return (double)largeTickStep_;
			}

			double MagRange = (double)(Math.Floor(Math.Log10(WorldMax)) - Math.Floor(Math.Log10(WorldMin))+1.0);

			if ( MagRange > 0.0 )
			{
				// for now, a simple logic
				// start with a major tick every order of magnitude, and
				// increment if in order not to have more than 10 ticks in
				// the plot.
				double roundTickDist=1.0F;
				int nticks=(int)(MagRange/roundTickDist);
				while (nticks > 10)
				{
					roundTickDist++;
					nticks=(int)(MagRange/roundTickDist);
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
			// if the big ticks is more than one decade, the
			// small ticks are every decade, I don't let the user set it.
			if (numberSmallTicks_ != null && bigTickDist==1.0F)
			{
				return (int)numberSmallTicks_+1;
			}

			// if we are plotting every decade, we have to
			// put the log ticks. As a start, I put every
			// small tick (.2,.3,.4,.5,.6,.7,.8,.9)
			if( bigTickDist==1.0F)
			{
				return 8;
			}
				// easy, put a tick every missed decade
			else if (bigTickDist>1.0F)
			{
				return (int)bigTickDist-1;
			}
			else
			{
				throw new Exception("Wrong Major tick distance setting");
			}
		}
		#endregion

		// properties to box/unbox the private members
		// The LargeTickStep is in decades.
		// i.e. =1 for a tick every decades, =2 for a tick every 2 decades
		#region LargeTickStep
		/// <summary>
		/// Accessors for the Step in the large ticks.
		/// The step is expressed in decades for the Log scale.
		/// </summary>
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
		/// <summary>
		/// Position for a large tick.
		/// </summary>
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
		}
		#endregion

		// Private members
		private object numberSmallTicks_;
		private object largeTickValue_;
		private object largeTickStep_;

		// Overridden methods to provide log scale specificities
		#region DrawTick
		/// <summary>
		/// Draws a tick on the axis
		/// </summary>
		/// <param name="g">The drawing surface</param>
		/// <param name="w">The tick position in world coordinates</param>
		/// <param name="size">The size of the tick (in pixels)</param>
		/// <param name="text">The text associated with the tick</param>
		/// <param name="textOffset">The Offset to draw from the auto calculated position</param>
		/// <param name="axisPhysMin">The minimum physical extent of the axis</param>
		/// <param name="axisPhysMax">The maximum physical extent of the axis</param>
		/// <returns> An ArrayList containing the offset from the axis required for an axis label
		/// to miss this tick, followed by a bounding rectangle for the tick and tickLabel drawn </returns>
		public override ArrayList DrawTick(Graphics g, double w, double size, string text, Point textOffset,
			PointF axisPhysMin, PointF axisPhysMax )
		{

			// determine start point.
			PointF s = WorldToPhysical( w, axisPhysMin, axisPhysMax, true );

			// determine offset from start point.
			// examine axis normalized direction vector
			PointF dir=AxisNormVector(axisPhysMin,axisPhysMax);

			// rotate clockwise by angle radians.
			double x1 = Math.Cos( -TicksAngle ) * dir.X + Math.Sin( -TicksAngle ) * dir.Y;
			double y1 = -Math.Sin( -TicksAngle ) * dir.X + Math.Cos( -TicksAngle ) * dir.Y;

			// scaling tick.
			dir = new PointF( (float)(TickScale * size * x1), (float)(TickScale * size * y1) );

			// draw it!
			g.DrawLine( LinePen, s.X, s.Y, s.X + dir.X, s.Y + dir.Y );

			// calculate bounds.
			double minx = Math.Min(s.X,s.X+dir.X);
			double miny = Math.Min(s.Y,s.Y+dir.Y);
			double maxx = Math.Max(s.X,s.X+dir.X);
			double maxy = Math.Max(s.Y,s.Y+dir.Y);
			RectangleF bounds = new RectangleF( (float)minx, (float)miny, (float)(maxx-minx), (float)(maxy-miny) );
			PointF labelOffset = new PointF( 0.0f, 0.0f );

			// now draw associated text.
			if (text != "" && !HideTickText )
			{
				double lHt = g.MeasureString( text, FontScaler.scaleFont(TickTextFont ,FontScale) ).Height;
				double lWd = g.MeasureString( text, FontScaler.scaleFont(TickTextFont ,FontScale) ).Width;

				double textCenterX;
				double textCenterY;

				// if text is at pointy end of tick.
				if (!TickTextNextToAxis)
				{
					// offset due to tick.
					textCenterX = s.X + dir.X*1.2f;
					textCenterY = s.Y + dir.Y*1.2f;

					// offset due to text box size.
					textCenterX += 0.5f * x1 * lWd;
					textCenterY += 0.5f * y1 * lHt;
				}
					// else it's next to the axis.
				else
				{
					// start location.
					textCenterX = s.X;
					textCenterY = s.Y;

					// offset due to text box size.
					textCenterX -= 0.5f * x1 * lWd;
					textCenterY -= 0.5f * y1 * lHt;

					// bring text away from the axis a little bit.
					textCenterX -= x1*(2.0f+FontScale);
					textCenterY -= y1*(2.0f+FontScale);
				}

				double bx1 = textCenterX-lWd/2.0f;
				double by1 = textCenterY-lHt/2.0f;
				double bx2 = lWd;
				double by2 = lHt;

				RectangleF drawRect = new RectangleF( (float)bx1, (float)by1, (float)bx2, (float)by2 );

				// g.DrawRectangle( new Pen(Color.Green),bx1, by1, bx2, by2 );

				bounds = RectangleF.Union( bounds, drawRect );

				// g.DrawRectangle( new Pen(Color.Purple), bounds.X, bounds.Y, bounds.Width, bounds.Height );

				StringFormat drawFormat = new StringFormat();
				drawFormat.Alignment = StringAlignment.Center;
				g.DrawString( text, FontScaler.scaleFont(TickTextFont,FontScale),
					TickTextBrush , drawRect, drawFormat);

				textCenterX -= s.X;
				textCenterY -= s.Y;
				textCenterX *= 2.3f;
				textCenterY *= 2.3f;

				labelOffset = new PointF((float)textCenterX, (float)textCenterY);
			}

			ArrayList toReturn = new ArrayList();
			toReturn.Add( labelOffset );
			toReturn.Add( bounds );

			return toReturn;
		}
		#endregion
		#region WorldToPhysical
		public override PointF WorldToPhysical( double coord, PointF physicalMin, PointF physicalMax, bool clip )
		{
			// if want clipped value, return extrema if outside range.
			if (clip)
			{
				if (coord > WorldMax)
				{
					return physicalMax;
				}
				if (coord < WorldMin)
				{
					return physicalMin;
				}
			}
			if (coord<0.0F)
			{
				throw new Exception("Cannot have negative values for data using Log Axis");
			}
			// inside range or don't want to clip.
			double lrange=(double)(Math.Log10(WorldMax) - Math.Log10(WorldMin));
			double prop = (double)((Math.Log10(coord) - Math.Log10(WorldMin)) / lrange);
			PointF offset = new PointF( (float)(prop * (physicalMax.X - physicalMin.X)),
				(float)(prop * (physicalMax.Y - physicalMin.Y)) );

			return new PointF( physicalMin.X + offset.X, physicalMin.Y + offset.Y );
		}

		#endregion
		#region PhysicalToWorld
		public override double PhysicalToWorld( PointF p, PointF physicalMin, PointF physicalMax, bool clip )
		{
			// use the base method to do the projection on the axis.
			double t = base.PhysicalToWorld( p, physicalMin, physicalMax, clip );

			// now reconstruct phys dist prop along this assuming linear scale as base method did.
			double v = (t-WorldMin) / (WorldMax-WorldMin);

			double ret = WorldMin*Math.Pow(WorldMax/WorldMin,v);

			// if want clipped value, return extrema if outside range.
			if (clip)
			{
				ret=Math.Max(ret,WorldMin);
				ret=Math.Min(ret,WorldMax);
			}
			return ret;

		}
		#endregion
		#region WorldMin/WorldMax
		public new double WorldMin
		{
			get
			{
				return (double)base.WorldMin;
			}
			set
			{
				if (value>0.0F)
				{
					base.WorldMin = value;
				}
				else
				{
					throw new Exception("Cannot have negative values in Log Axis");
				}
			}
		}
		public new double WorldMax
		{
			get
			{
				return (double)base.WorldMax;
			}
			set
			{
				if (value>0.0F)
				{
					base.WorldMax = value;
				}
				else
				{
					throw new Exception("Cannot have negative values in Log Axis");
				}
			}
		}
		#endregion
	}
}
