/*
ScPl - A plotting library for .NET

Axis.cs
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

$Id: Axis.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System.Drawing.Drawing2D;
using System.Drawing;
using System;
using System.Collections;

namespace SampleClients.ScPl
{
	/// <summary>
	///  Contains all general axis data except the physical extents of the axis.
	/// </summary>
	public class Axis : System.ICloneable
	{
		protected object worldMax_; // boxed so it can be null.
		protected object worldMin_;
		private object ticksAngle_;
		private float largeTickSize_;
		private float smallTickSize_;
		private Font font_;
		private float fontScale_;
		private float tickScale_;
		private bool tickTextNextToAxis_;
		private bool hideTickText_;
		private bool hidden_;
		private System.Collections.ArrayList drawPositions_;
		private string label_;
		private Font labelFont_;
		private Brush labelBrush_;
		private Brush tickTextBrush_;
		private GridType gridDetail_;
		private bool reversed_;

		/*
		private double[] gridMantissas_ = {1.0, 2.0, 2.5, 5.0};
		private int gridlinecount_ = 5;
		private double gridinterval_ = 1.0;
		private double[] mantissaLogs_;
		private double scale_ = 1.0;
		private double offset_ = 0.0;
		*/
		private string numFormat_;

		// remember to add to clone method if add variable here..


		/// <summary>
		/// Deep copy of Axis. Include check to see that this isn't being called by
		/// a derived type... the derived type should provide it's own clone method.
		/// </summary>
		/// <returns>A copy of the Axis Class</returns>
		public virtual object Clone()
		{
			Axis a = new Axis();
			// ensure that this isn't being called on a derived type. If it is, then oh no!
			if (GetType() != a.GetType())
			{
				throw new System.Exception( "Clone not defined in derived type. Help!" );
			}
			DoClone( this, a );
			return a;
		}
		/// <summary>
		/// Helper method for Clone. Does all the copying - can be called by derived
		/// types so they don't need to implement this part of the copying themselves.
		/// also useful in constructor of derived types that takes Axis class.
		/// </summary>
		protected static void DoClone( Axis b, Axis a )
		{

			// copy these boxed values by value if they are set, else set to null.

			if (b.ticksAngle_ != null)
			{
				a.ticksAngle_ = (double)b.ticksAngle_;
			}
			else
			{
				a.ticksAngle_ = null;
			}

			if (b.worldMax_ != null)
			{
				a.worldMax_ = (double)b.worldMax_;
			}
			else
			{
				a.worldMax_ = null;
			}

			if (b.worldMin_ != null)
			{
				a.worldMin_ = (double)b.worldMin_;
			}
			else
			{
				a.worldMin_ = null;
			}

			// copy unboxed values.
			a.largeTickSize_ = b.largeTickSize_;
			a.smallTickSize_ = b.smallTickSize_;
			a.fontScale_ = b.fontScale_;
			a.tickScale_ = b.tickScale_;
			a.tickTextNextToAxis_ = b.tickTextNextToAxis_;
			a.hidden_ = b.hidden_;
			a.hideTickText_ = b.hideTickText_;
			a.gridDetail_ = b.gridDetail_;
			a.reversed_ = b.reversed_;
			a.numFormat_ = b.numFormat_;

			// copy IClonable objects.
			a.font_ = (Font)b.font_.Clone();
			a.drawPositions_ = (System.Collections.ArrayList)b.drawPositions_.Clone();
			a.label_ = (string)b.label_.Clone();
			a.labelFont_ = (Font)b.labelFont_.Clone();
			a.tickTextBrush_ = (Brush)b.tickTextBrush_.Clone();
			a.labelBrush_ = (Brush)b.labelBrush_.Clone();
			a.linePen_ = (Pen)b.linePen_.Clone();
		}

		/// <summary>
		/// Helper function for constructors.
		/// Do initialization here so that Clear() method is handled properly
		/// </summary>
		private void Init()
		{
			worldMax_ = null;
			worldMin_ = null;
			Hidden = false;
			SmallTickSize = 2.0f;
			LargeTickSize = 5.0f;
			fontScale_ = 1.0f;
			tickScale_ = 1.0f;
			tickTextNextToAxis_ = true;
			hideTickText_ = false;
			drawPositions_ = new System.Collections.ArrayList();

			label_ = "" ;
			numFormat_ = "{0:g5}";
			reversed_ = false;

			//UpdateMantissaLogs();

			FontFamily fontFamily = new FontFamily("Arial");
			TickTextFont = new Font(fontFamily, 10, FontStyle.Regular, GraphicsUnit.Pixel);
			LabelFont = new Font(fontFamily, 12, FontStyle.Regular, GraphicsUnit.Pixel);
			LabelBrush = new SolidBrush( Color.Black );
			tickTextBrush_ = new SolidBrush( Color.Black );
			linePen_ = new Pen( Color.Black );
			linePen_.Width = 1.0f;
		}

		/// <summary>
		/// Default Constructor
		/// </summary>
		public Axis( )
		{
			Init();
		}
		/// <summary>
		/// Constructor that takes only world min and max values
		/// </summary>
		/// <param name="worldMin">The minimum world coordinate</param>
		/// <param name="worldMax">The maximum world coordinate</param>
		public Axis( double worldMin, double worldMax )
		{
			Init();
			WorldMin = worldMin;
			WorldMax = worldMax;
		}

		public Axis( Axis a )
		{
			Axis.DoClone( a, this );
		}


		/// <summary>
		/// Determines whether a world value is between WorldMin and WorldMax
		/// </summary>
		/// <param name="coord">the world value to test</param>
		/// <returns>true if within limits, false otherwise</returns>
		public bool OutOfRange( double coord )
		{
			if ( worldMin_ == null || worldMax_ == null )
			{
				return true;
			}

			if (coord > WorldMax || coord < WorldMin)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void setColor( Color c )
		{
			linePen_.Color = c;
			// change color only makes sense for solid brush.
			labelBrush_ = new SolidBrush(c);
			tickTextBrush_ = new SolidBrush(c);
		}

		public void LUB( Axis a )
		{
			// mins
			if (a.worldMin_ != null)
			{
				if (worldMin_ == null)
				{
					WorldMin = a.WorldMin;
				}
				else
				{
					if (a.WorldMin < WorldMin)
					{
						WorldMin = a.WorldMin;
					}
				}
			}

			// maxs.
			if (a.worldMax_ != null)
			{
				if (worldMax_ == null)
				{
					WorldMax = a.WorldMax;
				}
				else
				{
					if (a.WorldMax > WorldMax)
					{
						WorldMax = a.WorldMax;
					}
				}
			}
		}

		public virtual PointF WorldToPhysical( double coord, PointF physicalMinTmp, PointF physicalMaxTmp, bool clip )
		{
			// inefficient in this important function. oh well.

			PointF physicalMin;
			PointF physicalMax;

			if ( reversed_ == true )
			{
				physicalMin = physicalMaxTmp;
				physicalMax = physicalMinTmp;
			}
			else
			{
				physicalMin = physicalMinTmp;
				physicalMax = physicalMaxTmp;
			}

			// if want clipped value, return extrema if outside range.
			if ( clip )
			{
				if ( coord > WorldMax )
				{
					return physicalMax;
				}
				if ( coord < WorldMin )
				{
					return physicalMin;
				}
			}

			// inside range or don't want to clip.
			double prop = (coord - WorldMin) / (WorldMax - WorldMin);
			PointF offset = new PointF( (float)(prop * (physicalMax.X - physicalMin.X)),
				(float)(prop * (physicalMax.Y - physicalMin.Y) ));

			return new PointF( (float)(physicalMin.X + offset.X), (float)(physicalMin.Y + offset.Y) );
		}

		public virtual double PhysicalToWorld( PointF p, PointF physicalMinTmp, PointF physicalMaxTmp, bool clip )
		{
			// inefficient in this important function. oh well.
			PointF physicalMin;
			PointF physicalMax;

			if ( reversed_ == true )
			{
				physicalMin = physicalMaxTmp;
				physicalMax = physicalMinTmp;
			}
			else
			{
				physicalMin = physicalMinTmp;
				physicalMax = physicalMaxTmp;
			}

			// axis dir vector
			double axisX = ((PointF)physicalMax).X - ((PointF)physicalMin).X;
			double axisY = ((PointF)physicalMax).Y - ((PointF)physicalMin).Y;
			double len = Math.Sqrt( axisX * axisX + axisY * axisY );
			axisX /= len;
			axisY /= len;

			// point relative to axis.
			double pointX = ((PointF)p).X - ((PointF)physicalMin).X;
			double pointY = ((PointF)p).Y - ((PointF)physicalMin).Y;

			// dist of point projection on axis, normalised.
			double prop = (axisX*pointX + axisY*pointY) / len;

			double ret = prop * (WorldMax-WorldMin) + WorldMin;

			// if want clipped value, return extrema if outside range.
			if (clip)
			{
				ret=Math.Max(ret,WorldMin);
				ret=Math.Min(ret,WorldMax);
			}
			return ret;
		}

		/// <summary>
		/// Draw Axis Label
		/// </summary>
		/// <param name="g">The GDI+ drawing surface on which to draw</param>
		/// <param name="offset">offset calculated by derived class that makes sure axis label
		/// misses tick labels.</param>
		/// <param name="axisPhysMin">The minimum physical extent of the axis</param>
		/// <param name="axisPhysMax">The maximum physical extent of the axis</param>
		/// <returns>boxed RectangleF indicating bounding box of label. null if no label printed.</returns>
		public object DrawLabel( Graphics g, PointF offset, PointF axisPhysMin, PointF axisPhysMax )
		{
			if ( label_ != "" )
			{
				// determine angle of axis.
				double theta = (double) System.Math.Atan2(
					axisPhysMax.Y - axisPhysMin.Y,
					axisPhysMax.X - axisPhysMin.X );

				double perpTheta = theta - Math.PI / 2.0f;  // want to move text this way to center on axis.
				double y = Math.Sin(perpTheta);
				double x = Math.Cos(perpTheta);

				PointF average = new PointF(
					(axisPhysMax.X + axisPhysMin.X)/2.0f,
					(axisPhysMax.Y + axisPhysMin.Y)/2.0f );

				g.TranslateTransform( offset.X , offset.Y ); // this is done last.
				g.TranslateTransform( average.X, average.Y );
				theta = theta * 180.0f / Math.PI; // convert to degrees.
				g.RotateTransform((float)theta); // this is done first.

				double lHt = g.MeasureString( label_, FontScaler.scaleFont(labelFont_,FontScale) ).Height;
				double lWd = g.MeasureString( label_, FontScaler.scaleFont(labelFont_,FontScale) ).Width;

				// bb centered around zero.
				RectangleF drawRect = new RectangleF( (float)(-lWd/2.0f), (float)(-lHt/2.0f), (float)lWd, (float)lHt );

				StringFormat drawFormat = new StringFormat();
				drawFormat.Alignment = StringAlignment.Center;
				g.DrawString( label_, FontScaler.scaleFont(LabelFont,FontScale),
					labelBrush_, drawRect, drawFormat);

				// now work out physical bounds of label. and return.
				Matrix m = g.Transform;
				Point[] recPoints = new Point[2];
				recPoints[0] = new Point( (int)(-lWd/2.0f), (int)(-lHt/2.0f) );
				recPoints[1] = new Point( (int)(lWd/2.0f), (int)(lHt/2.0f) );
				m.TransformPoints( recPoints );

				double x1 = Math.Min( recPoints[0].X, recPoints[1].X );
				double x2 = Math.Max( recPoints[0].X, recPoints[1].X );
				double y1 = Math.Min( recPoints[0].Y, recPoints[1].Y );
				double y2 = Math.Max( recPoints[0].Y, recPoints[1].Y );
				RectangleF bounds = new RectangleF( (float)x1, (float)y1, (float)(x2-x1), (float)(y2-y1) );

				g.ResetTransform(); // reset transform before we return.

				return bounds;
			}

			return null;
		}

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
		public virtual ArrayList DrawTick( Graphics g, double w, double size, string text,
			Point textOffset, PointF axisPhysMin, PointF axisPhysMax )
		{

			// determine start point.
			PointF s = WorldToPhysical( w, axisPhysMin, axisPhysMax, true );

			// determine offset from start point.
			PointF dir=AxisNormVector(axisPhysMin,axisPhysMax);

			// rotate clockwise by angle radians.
			double x1 = Math.Cos( -TicksAngle ) * dir.X + Math.Sin( -TicksAngle ) * dir.Y;
			double y1 = -Math.Sin( -TicksAngle ) * dir.X + Math.Cos( -TicksAngle ) * dir.Y;

			// scaling tick.
			dir = new PointF( (float)(TickScale * size * x1), (float)(TickScale * size * y1) );

			// draw it!
			g.DrawLine( linePen_, s.X, s.Y, s.X + dir.X, s.Y + dir.Y );

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
				double lHt = g.MeasureString( text, FontScaler.scaleFont(font_,FontScale) ).Height;
				double lWd = g.MeasureString( text, FontScaler.scaleFont(font_,FontScale) ).Width;

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
					tickTextBrush_, drawRect, drawFormat);

				textCenterX -= s.X;
				textCenterY -= s.Y;
				textCenterX *= 2.3f;
				textCenterY *= 2.3f;

				labelOffset = new PointF((float)textCenterX, (float)textCenterY);

			} // if (text != "" && !HideTickText )

			ArrayList toReturn = new ArrayList();
			toReturn.Add( labelOffset );
			toReturn.Add( bounds );

			return toReturn;
		}

		/// <summary>
		/// Draw the axis
		/// </summary>
		/// <param name="g">The drawing surface on which to draw</param>
		/// <param name="physicalMin">The minimum physical extent of the axis</param>
		/// <param name="physicalMax">The maximum physical extent of the axis</param>
		/// <returns>TODO:fill in.</returns>
		public virtual object Draw( System.Drawing.Graphics g, PointF physicalMin, PointF physicalMax )
		{
			return DoDraw( g, new PointF( 0.0f, 0.0f ), physicalMin, physicalMax );
		}

		protected virtual RectangleF DoDraw( System.Drawing.Graphics g, PointF labelOffset,
			PointF physicalMin, PointF physicalMax )
		{
			double x1 = Math.Min( physicalMin.X, physicalMax.X );
			double x2 = Math.Max( physicalMin.X, physicalMax.X );
			double y1 = Math.Min( physicalMin.Y, physicalMax.Y );
			double y2 = Math.Max( physicalMin.Y, physicalMax.Y );
			RectangleF bounds = new RectangleF( (float)x1, (float)y1, (float)(x2-x1), (float)(y2-y1) );

			if (!Hidden)
			{
				g.DrawLine( linePen_, physicalMin.X, physicalMin.Y, physicalMax.X, physicalMax.Y );

				if (!hideTickText_)
				{
					object labelBounds = DrawLabel(g, labelOffset, physicalMin, physicalMax );
					if (labelBounds != null)
					{
						bounds = RectangleF.Union( bounds, (RectangleF)labelBounds );
					}

				}
			}

			return bounds;

		}


		public enum GridType
		{
			None = 0,
			Coarse = 1,
			Fine = 2
		}

		public float LargeTickSize
		{
			get
			{
				return largeTickSize_;
			}
			set
			{
				largeTickSize_ = value;
			}
		}

		public float SmallTickSize
		{
			get
			{
				return smallTickSize_;
			}
			set
			{
				smallTickSize_ = value;
			}
		}

		public double WorldMax
		{
			get
			{
				if (worldMax_ == null)
				{
					return (double)worldMax_;
				}
				else
				{
					return (double)worldMax_; // unbox.
				}
			}
			set
			{
				worldMax_ = value; // box (or set to null)
			}
		}

		public double WorldMin
		{
			get
			{
				return (double)worldMin_; // un box
			}
			set
			{
				worldMin_ = value; // box (or set to null).
			}
		}

		public Font TickTextFont
		{
			get
			{
				return font_;
			}
			set
			{
				font_ = value;
			}
		}

		public Font LabelFont
		{
			get
			{
				return labelFont_;
			}
			set
			{
				labelFont_ = value;
			}
		}

		public Brush LabelBrush
		{
			get
			{
				return labelBrush_;
			}
			set
			{
				labelBrush_ = value;
			}
		}

		public Brush TickTextBrush
		{
			get
			{
				return tickTextBrush_;
			}
			set
			{
				tickTextBrush_ = value;
			}
		}

		public string Label
		{
			get
			{
				return label_;
			}
			set
			{
				label_ = value;
			}
		}

		public float FontScale
		{
			get
			{
				return fontScale_;
			}
			set
			{
				fontScale_ = value;
			}
		}

		protected PointF AxisNormVector(PointF min,PointF max)
		{
			PointF dir = new PointF( max.X - min.X,max.Y - min.Y );
			double dirNorm = Math.Sqrt(dir.X*dir.X+dir.Y*dir.Y);
			if ( dirNorm > 0.0f)
			{
				dir = new PointF( (float)((1.0f/dirNorm)*dir.X), (float)((1.0f/dirNorm)*dir.Y) ); // normalised axis direction vector
			}
			return dir;
		}

		public float TickScale
		{
			get
			{
				return tickScale_;
			}
			set
			{
				tickScale_ = value;
			}
		}

		/// <summary>
		/// If true, the text associated with the ticks will appear on the opposite side of the axis to the tick.
		/// If false, the text will appear at the end of the tick.
		/// </summary>
		public bool TickTextNextToAxis
		{
			get
			{
				return tickTextNextToAxis_;
			}
			set
			{
				tickTextNextToAxis_ = value;
			}
		}


		public bool Hidden
		{
			get
			{
				return hidden_;
			}
			set
			{
				hidden_ = value;
			}
		}


		/// <summary>
		/// Reverse the display of the axis so that the values are
		/// printed from right to left instead of left to right
		/// </summary>
		public bool Reversed
		{
			get
			{
				return reversed_;
			}
			set
			{
				reversed_ = value;
			}
		}



		public bool HideTickText
		{
			get
			{
				return hideTickText_;
			}
			set
			{
				hideTickText_ = value;
			}
		}

		public System.Drawing.Pen LinePen
		{
			get
			{
				return linePen_;
			}
			set
			{
				linePen_ = value;
			}
		}
		private System.Drawing.Pen linePen_;

		public double TicksAngle
		{
			get
			{
				if (ticksAngle_ == null)
				{
					return (double)(Math.PI / 2.0);
				}
				else
				{
					return (double)ticksAngle_;
				}
			}
			set
			{
				ticksAngle_ = (double)value;
			}
		}

		public virtual ArrayList LargeTickPositions
		{
			get
			{
				return new ArrayList();
			}
		}

		public virtual ArrayList SmallTickPositions
		{
			get
			{
				return new ArrayList();
			}
		}

		public GridType GridDetail
		{
			get
			{
				return gridDetail_;
			}
			set
			{
				gridDetail_ = value;
			}
		}

		/*


		private void UpdateMantissaLogs()
		{
			mantissaLogs_ = new double[gridMantissas_.Length];
			for (int i=0; i < gridMantissas_.Length; i++)
			{
				mantissaLogs_[i] = Math.Log10(gridMantissas_[i]);
			}
		}

		/// <summary>
		/// Specify the values to use for the grid tick marks
		/// The actual GridMantissa used will be the one
		/// that puts the GridLineCount as close as possible to the selected value
		/// </summary>
		public double[] GridMantissas
		{
			get
			{
				return gridMantissas_;
			}
			set
			{
				// Resolve value to between 0 and 10
				for (int i=0; i<value.Length; i++)
				{
					if (value[i] < 0)
					{
						value[i] = - value[i];
					}
					if (value[i] == 0)
					{
						value[i] = 10;
					}
					else if (value[i] > 10)
					{
						double d = Math.Log10(value[i]);
						value[i] = Math.Pow(10, d - (int)d);
					}
				}
				gridMantissas_ = value;
				Array.Sort(gridMantissas_, Comparer.Default);
				UpdateMantissaLogs();
			}
		}

		/// <summary>
		/// Set the approximate number of Grids.
		/// The actual value will depend on the data range and the GridMantissa calculated
		/// so that the GridLineCount is as close as possible to the selected value.
		/// Get returns the actual value in use.
		/// </summary>
		public int GridLineCount
		{
			get
			{
				return gridlinecount_;
			}
			set
			{
				gridlinecount_ = value;
			}
		}

		/// <summary>
		/// Get the calculated grid interval based on the data range, GridLineCount
		/// and GridMantissa used.
		/// </summary>
		public double GridInterval
		{
			get
			{
				return gridinterval_;
			}
		}

		internal double[] MantissaLogs
		{
			get
			{
				return mantissaLogs_;
			}
		}


		/// <summary>
		///
		/// </summary>
		public double Scale
		{
			get
			{
				return scale_;
			}
			set
			{
				scale_ = value;
			}
		}

		/// <summary>
		///
		/// </summary>
		public double Offset
		{
			get
			{
				return offset_;
			}
			set
			{
				offset_ = value;
			}
		}

*/

		/// <summary>
		/// The .NET number format to use for labeling the axis
		/// </summary>
		public string NumberFormat
		{
			get
			{
				return numFormat_;
			}
			set
			{
				numFormat_ = value;
			}
		}


	}
}
