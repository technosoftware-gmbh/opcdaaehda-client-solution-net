/*
ScPl - A plotting library for .NET

PlotSurface2D.cs
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

$Id: PlotSurface2D.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

// This can be used for "graphical debugging of the
// plot construction. If needed define the symbol
#undef _IWANNASEE_

using System;
using System.Drawing;
using System.Diagnostics;

namespace SampleClients.ScPl
{
	#region enum XAxisPosition
	public enum XAxisPosition
	{
		Top = 1,
		//Center = 2,
		Bottom = 3,
	}
	#endregion
	#region enum YAxisPosition
	public enum YAxisPosition
	{
		Left = 1,
		// Center
		Right = 3,
	}
	#endregion

	/// <summary>
	/// Graphics g
	/// </summary>
	public class PlotSurface2D
	{
		private Font titleFont_;
		private string title_;
		private Brush titleBrush_;
		private int padding_;
		private Axis xAxis1_;
		private Axis yAxis1_;
		private Axis xAxis2_;
		private Axis yAxis2_;
		private PhysicalAxis pXAxis1Cache_;
		private PhysicalAxis pYAxis1Cache_;
		private PhysicalAxis pXAxis2Cache_;
		private PhysicalAxis pYAxis2Cache_;
		private bool autoScale_;
		private object plotAreaBoundingBoxCache_;
		private object plotBackColor_;
		private float legendOffsetX_;
		private float legendOffsetY_;
		private XAxisPosition legendOffsetXAxis_;
		private YAxisPosition legendOffsetYAxis_;
		private Legend.BorderType legendBorderStyle_;
		private Legend.Placement horizontalEdgeLegendPlacement_;
		private Legend.Placement verticalEdgeLegendPlacement_;

		// TODO: also, should define and store BoundingBoxes for other entities
		// (e.g. Title, ...)


		internal Rectangle PlotAreaBoundingBoxCache
		{
			get
			{
				return (Rectangle)plotAreaBoundingBoxCache_;
			}
		}

		#region get Axes
		#region XAxis1
		public Axis XAxis1
		{
			get
			{
				return xAxis1_;
			}
			set
			{
				xAxis1_ = value;
			}
		}
		#endregion
		#region YAxis1
		public Axis YAxis1
		{
			get
			{
				return yAxis1_;
			}
			set
			{
				yAxis1_ = value;
			}
		}
		#endregion
		#region XAxis2
		public Axis XAxis2
		{
			get
			{
				return xAxis2_;
			}
			set
			{
				xAxis2_ = value;
			}
		}
		#endregion
		#region YAxis2
		public Axis YAxis2
		{
			get
			{
				return yAxis2_;
			}
			set
			{
				yAxis2_ = value;
			}
		}
		#endregion
		#endregion
		#region get PhysicalAxis Caches
		public PhysicalAxis PhysicalXAxis1Cache
		{
			get
			{
				return pXAxis1Cache_;
			}
		}

		public PhysicalAxis PhysicalYAxis1Cache
		{
			get
			{
				return pYAxis1Cache_;
			}
		}

		public PhysicalAxis PhysicalXAxis2Cache
		{
			get
			{
				return pXAxis2Cache_;
			}
		}

		public PhysicalAxis PhysicalYAxis2Cache
		{
			get
			{
				return pYAxis2Cache_;
			}
		}
		#endregion
		#region gets
		/// <summary>
		/// get/set the plot title.
		/// </summary>
		public string Title
		{
			get
			{
				return title_;
			}
			set
			{
				title_ = value;
			}
		}

		/// <summary>
		/// get/set the plot title font.
		/// </summary>
		public Font TitleFont
		{
			get
			{
				return titleFont_;
			}
			set
			{
				titleFont_ = value;
			}
		}

		public int Padding
		{
			get
			{
				return padding_;
			}
			set
			{
				padding_ = value;
			}
		}

		public bool AutoScale
		{
			get
			{
				return autoScale_;
			}
			set
			{
				autoScale_ = value;
			}
		}

		public Brush TitleBrush
		{
			get
			{
				return titleBrush_;
			}
			set
			{
				titleBrush_ = value;
			}
		}

		public System.Drawing.Pen MajorGridPen
		{
			get
			{
				return majorGridPen_;
			}
			set
			{
				majorGridPen_ = value;
			}
		}
		private Pen majorGridPen_;

		public System.Drawing.Pen MinorGridPen
		{
			get
			{
				return minorGridPen_;
			}
			set
			{
				minorGridPen_ = value;
			}
		}
		private Pen minorGridPen_;
		#endregion

		private void Init()
		{
			plots_ = new System.Collections.ArrayList();
			xAxisPositions_ = new System.Collections.ArrayList();
			yAxisPositions_ = new System.Collections.ArrayList();

			FontFamily fontFamily = new FontFamily("Arial");
			TitleFont = new Font(fontFamily, 14, FontStyle.Regular, GraphicsUnit.Pixel);
			padding_ = 10;
			title_ = "";
			autoScale_ = true;
			minorGridPen_ = new Pen( Color.LightGray );
			float[] pattern = {1.0f, 2.0f};
			minorGridPen_.DashPattern = pattern;
			majorGridPen_ = new Pen( Color.LightGray );
			xAxis1_ = null;
			xAxis2_ = null;
			yAxis1_ = null;
			yAxis2_ = null;
			pXAxis1Cache_ = null;
			pYAxis1Cache_ = null;
			pXAxis2Cache_ = null;
			pYAxis2Cache_ = null;
			titleBrush_ = new SolidBrush( Color.Black );
			plotBackColor_ = Color.White;
			showLegend_ = false;

			legendOffsetXAxis_ = XAxisPosition.Top;
			legendOffsetYAxis_ = YAxisPosition.Right;
			legendOffsetX_ = 10.0f;
			legendOffsetY_ = 1.0f;
			legendBorderStyle_ = Legend.BorderType.Shadow;
			verticalEdgeLegendPlacement_ = Legend.Placement.Outside;
			horizontalEdgeLegendPlacement_ = Legend.Placement.Inside;
		}

		/// <summary>
		/// Default Constructor.
		/// </summary>
		public PlotSurface2D()
		{
			Init();
		}

		private double DetermineScaleFactor( double w, double h )
		{
			if ( !autoScale_ )
			{
				return 1.0f;
			}

			// calculate plot area diagonal
			double t1 = w * w;
			double t2 = h * h;
			double diag = Math.Sqrt(t1+t2);

			diag /= 1400.0f;
			diag *= 2.4f;  // these determined through random playing about.
			if ( diag > 1.0f )
			{
				return diag;
			}
			else
			{
				return 1.0f;
			}
		}

		public void Add( IPlot p )
		{
			Add( p, XAxisPosition.Bottom, YAxisPosition.Left);
		}


		// param specify reference or name of axis.
		public void Add( IPlot p, XAxisPosition xp, YAxisPosition yp )
		{
			plots_.Add( p );
			xAxisPositions_.Add( xp );
			yAxisPositions_.Add( yp );
			UpdateAxes();
		}


		private void UpdateAxes()
		{
			// make sure our lists exist
			if (plots_.Count==0 || xAxisPositions_.Count==0 || yAxisPositions_.Count==0)
			{
				throw new System.Exception("UpdateAxes called from function other than Add.");
			}
			int last = plots_.Count - 1;
			if ( last != xAxisPositions_.Count-1 || last != yAxisPositions_.Count-1 )
			{
				throw new System.Exception( "plots and axis position arrays our of sync" );
			}

			IPlot p = (IPlot)plots_[last];
			XAxisPosition xap = (XAxisPosition)xAxisPositions_[last];
			YAxisPosition yap = (YAxisPosition)yAxisPositions_[last];

			if ( xap == XAxisPosition.Bottom )
			{
				if (xAxis1_ == null)
				{
					xAxis1_ = p.SuggestXAxis();
					xAxis1_.TicksAngle = -Math.PI/2.0f;
				}
				else
				{
					xAxis1_.LUB( p.SuggestXAxis() );
				}
			}

			if ( xap == XAxisPosition.Top )
			{
				if (xAxis2_ == null)
				{
					xAxis2_ = p.SuggestXAxis();
					xAxis2_.TicksAngle = Math.PI/2.0f;
				}
				else
				{
					xAxis2_.LUB( p.SuggestXAxis() );
				}
			}

			if ( yap == YAxisPosition.Left )
			{
				if ( yAxis1_ == null )
				{
					yAxis1_ = p.SuggestYAxis();
					yAxis1_.TicksAngle = Math.PI/2.0f;
				}
				else
				{
					yAxis1_.LUB( p.SuggestYAxis() );
				}
			}

			if ( yap == YAxisPosition.Right )
			{
				if (yAxis2_ == null )
				{
					yAxis2_ = p.SuggestYAxis();
					yAxis2_.TicksAngle = -Math.PI/2.0f;
				}
				else
				{
					yAxis2_.LUB( p.SuggestYAxis() );
				}
			}
		}


		private void DrawGridLines( Graphics g, PhysicalAxis axis, PhysicalAxis orthogonalAxis,
			System.Collections.ArrayList a, bool horizontal, Pen p )
		{
			for (int i=0; i<a.Count; ++i)
			{
				PointF p1 = axis.WorldToPhysical((double)a[i], true);
				PointF p2 = p1;
				PointF p3 = orthogonalAxis.PhysicalMax;
				PointF p4 = orthogonalAxis.PhysicalMin;
				if (horizontal)
				{
					p1.Y = p4.Y;
					p2.Y = p3.Y;
				}
				else
				{
					p1.X = p4.X;
					p2.X = p3.X;
				}
				g.DrawLine( p, p1, p2 );
			}
		}

		private void DrawGrid( Graphics g, PhysicalAxis pXAxis1, PhysicalAxis pYAxis1,
			PhysicalAxis pXAxis2, PhysicalAxis pYAxis2 )
		{
			// Small Grid.
			if (pXAxis1.Axis.GridDetail == Axis.GridType.Fine)
			{
				System.Collections.ArrayList a = pXAxis1.Axis.SmallTickPositions;
				DrawGridLines( g, pXAxis1, pYAxis1, a, true, MinorGridPen );
			}

			if (pXAxis2.Axis.GridDetail == Axis.GridType.Fine)
			{
				System.Collections.ArrayList a = pXAxis2.Axis.SmallTickPositions;
				DrawGridLines( g, pXAxis2, pYAxis1, a, true, MinorGridPen );
			}

			if (pYAxis1.Axis.GridDetail == Axis.GridType.Fine)
			{
				System.Collections.ArrayList a = pYAxis1.Axis.SmallTickPositions;
				DrawGridLines( g, pYAxis1, pXAxis1, a, false, MinorGridPen );
			}

			if (pYAxis2.Axis.GridDetail == Axis.GridType.Fine)
			{
				System.Collections.ArrayList a = pYAxis2.Axis.SmallTickPositions;
				DrawGridLines( g, pYAxis2, pXAxis1, a, false, MinorGridPen );
			}


			// Small Grid.
			if (pXAxis1.Axis.GridDetail != Axis.GridType.None)
			{
				System.Collections.ArrayList a = pXAxis1.Axis.LargeTickPositions;
				DrawGridLines( g, pXAxis1, pYAxis1, a, true, MajorGridPen );
			}

			if (pXAxis2.Axis.GridDetail != Axis.GridType.None)
			{
				System.Collections.ArrayList a = pXAxis2.Axis.LargeTickPositions;
				DrawGridLines( g, pXAxis2, pYAxis1, a, true, MajorGridPen );
			}

			if (pYAxis1.Axis.GridDetail != Axis.GridType.None)
			{
				System.Collections.ArrayList a = pYAxis1.Axis.LargeTickPositions;
				DrawGridLines( g, pYAxis1, pXAxis1, a, false, MajorGridPen );
			}

			if (pYAxis2.Axis.GridDetail != Axis.GridType.None)
			{
				System.Collections.ArrayList a = pYAxis2.Axis.LargeTickPositions;
				DrawGridLines( g, pYAxis2, pXAxis1, a, false, MajorGridPen );
			}

		}

		/// <summary>
		/// Draw the plot on the drawing surface
		/// </summary>
		/// <param name="g">The GDI+ drawing surface on which to render.</param>
		/// <param name="bounds">The bounding rectangle on the drawing surface to be considered the plot area.</param>
		public void Draw( Graphics g, Rectangle bounds )
		{

			if ( plots_.Count == 0 )
			{
				return;
				// TODO: better output in this case.
			}

			float scale = (float)DetermineScaleFactor( bounds.Width, bounds.Height );

			if (xAxis1_ == null)
			{
				xAxis1_ = (Axis)xAxis2_.Clone();
				xAxis1_.HideTickText = true;
				xAxis1_.TicksAngle = -Math.PI/2.0f;
			}

			if (xAxis2_ == null)
			{
				xAxis2_ = (Axis)xAxis1_.Clone();
				xAxis2_.HideTickText = true;
				xAxis2_.TicksAngle = Math.PI/2.0f;
			}

			if (yAxis1_ == null)
			{
				yAxis1_ = (Axis)yAxis2_.Clone();
				yAxis1_.HideTickText = true;
				yAxis1_.TicksAngle = Math.PI/2.0f;
			}

			if (yAxis2_ == null)
			{
				yAxis2_ = (Axis)yAxis1_.Clone();
				yAxis2_.HideTickText = true;
				yAxis2_.TicksAngle = -Math.PI/2.0f;
			}

			// TODO: fix this so these not automatically overwritten.
			xAxis1_.TickScale = scale;
			xAxis1_.FontScale = scale;
			yAxis1_.TickScale = scale;
			yAxis1_.FontScale = scale;
			xAxis2_.TickScale = scale;
			xAxis2_.FontScale = scale;
			yAxis2_.TickScale = scale;
			yAxis2_.FontScale = scale;

			// now have axes world info. set physical limits.
			// first guess axes positions, then find bounding box, then change
			// to align nicely with side of control.
			System.Drawing.Rectangle cb = bounds;
			RectangleF bb;

			// guess physical x axis (bottom). Put it at the bottom of the plot
			PhysicalAxis pXAxis1 = new PhysicalAxis( xAxis1_,
				new Point( cb.Left, cb.Bottom ), new Point( cb.Right, cb.Bottom ) );
			int bottomIndent = (int)(padding_);
			if (!pXAxis1.Axis.Hidden) 
			{
				// evaluate its bounding box
				bb = pXAxis1.GetBoundingBox();
				// finally determine its indentation from the bottom
				bottomIndent = (int)(bottomIndent + bb.Bottom-cb.Bottom);
			}

			// guess physical y axis (left). Put it at the left side.
			PhysicalAxis pYAxis1 = new PhysicalAxis( yAxis1_,
				new Point( cb.Left, cb.Bottom ), new Point( cb.Left, cb.Top ) );
			int leftIndent = (int)(padding_);
			if (!pYAxis1.Axis.Hidden) 
			{
				// evaluate its bounding box
				bb = pYAxis1.GetBoundingBox();
				// finally determine its indentation from the left
				leftIndent = (int)(leftIndent - bb.Left + cb.Left);
			}

			// guess secondary x axis (top).
			PhysicalAxis pXAxis2 = new PhysicalAxis( xAxis2_,
				new Point( cb.Left, cb.Top), new Point( cb.Right, cb.Top) );
			int topIndent = (int)(padding_);
			double titleHeight = FontScaler.scaleFont(titleFont_, scale).Height;
			if (!pXAxis2.Axis.Hidden)  
			{
				// evaluate its bounding box
				bb = pXAxis2.GetBoundingBox();
				topIndent = (int)(topIndent - bb.Top + cb.Top);

				// finally determine its indentation from the top
				// correct top indendation to take into account plot title
				if (title_ != "" )
				{
					topIndent += (int)((double)titleHeight * 1.3f);
				}
			}

			// guess secondary y axis (right). Put it at the right side.
			PhysicalAxis pYAxis2 = new PhysicalAxis( yAxis2_,
				new Point( cb.Right, cb.Bottom ), new Point( cb.Right, cb.Top ) );
			int rightIndent = (int)(padding_);
			if (!pYAxis2.Axis.Hidden) 
			{
				// evaluate its bounding box
				bb = pYAxis2.GetBoundingBox();

				// finally determine its indentation from the right
				rightIndent = (int)(rightIndent + bb.Right-cb.Right);
			}

			// now determine if legend should change any of these (legend should be fully 
			// visible at all times), and draw legend.
			Legend legend = null;
			float lXPos = 0.0f;
			float lYPos = 0.0f;
			if ( showLegend_ )
			{
				legend = new Legend();
				legend.BorderStyle = LegendBorderStyle;
				RectangleF legendWidthHeight = legend.GetBoundingBox(0,0,plots_,scale);

				// calculate legend position.

				lYPos = legendOffsetY_;
				
				if ( legendOffsetXAxis_ == XAxisPosition.Bottom )
				{
					lYPos += cb.Bottom-bottomIndent;
					if ( horizontalEdgeLegendPlacement_ == Legend.Placement.Inside )
					{
						lYPos -= legendWidthHeight.Height;
					}
				}
				else
				{
					lYPos += cb.Top+topIndent;
					if ( horizontalEdgeLegendPlacement_ == Legend.Placement.Outside )
					{
						lYPos -= legendWidthHeight.Height;
					}
				}
				
				lXPos = legendOffsetX_;
				
				if ( legendOffsetYAxis_ == YAxisPosition.Left )
				{
					if ( verticalEdgeLegendPlacement_ == Legend.Placement.Outside ) 
					{
						lXPos -= legendWidthHeight.Width;
					}
					lXPos += cb.Left + leftIndent;
				}
				else
				{
					if ( verticalEdgeLegendPlacement_ == Legend.Placement.Inside )
					{
						lXPos -= legendWidthHeight.Width;
					}
					lXPos += cb.Right-rightIndent;
				}

				// update axes positions if need to for legend position.

				if ( lXPos < padding_ )
				{
					int changeAmount = -(int)lXPos + padding_;
					// only allow axes to move away from bounds.
					if ( changeAmount > 0 )					
					{
						leftIndent += changeAmount;
					}
					lXPos += changeAmount;
				}

				if ( lXPos + legendWidthHeight.Width > bounds.Right - padding_ )
				{
					int changeAmount = ((int)lXPos - bounds.Right + (int)legendWidthHeight.Width + padding_ );
					// only allow axes to move away from bounds.
					if ( changeAmount > 0 ) 
					{
						rightIndent += changeAmount;
					}
					lXPos -= changeAmount;
				}

				if ( lYPos < padding_ )
				{
					int changeAmount = -(int)lYPos + padding_;
					// only allow axes to move away from bounds.
					if ( changeAmount > 0 )					
					{
						topIndent += changeAmount;
					}
					lYPos += changeAmount;
				}

				if ( lYPos + legendWidthHeight.Height > bounds.Bottom - padding_ )
				{
					int changeAmount = ((int)lYPos - bounds.Bottom + (int)legendWidthHeight.Height + padding_ );
					// only allow axes to move away from bounds.
					if ( changeAmount > 0 ) 
					{
						bottomIndent += changeAmount;
					}
					lYPos -= changeAmount;
				}
			}


			// now we have all the positions and we can proceed to "move" the axes to their
			// right places
			// primary axes (bottom, left)
			pXAxis1.PhysicalMin = new Point( cb.Left+leftIndent, cb.Bottom-bottomIndent );
			pXAxis1.PhysicalMax = new Point( cb.Right-rightIndent, cb.Bottom-bottomIndent );
			pYAxis1.PhysicalMin = new Point( cb.Left+leftIndent, cb.Bottom-bottomIndent);
			pYAxis1.PhysicalMax = new Point( cb.Left+leftIndent, cb.Top+topIndent );
			// secondary axes (top, right)
			pXAxis2.PhysicalMin = new Point( cb.Left+leftIndent, cb.Top+topIndent);
			pXAxis2.PhysicalMax = new Point( cb.Right-rightIndent, cb.Top+topIndent);
			pYAxis2.PhysicalMin = new Point( cb.Right-rightIndent, cb.Bottom-bottomIndent);
			pYAxis2.PhysicalMax = new Point( cb.Right-rightIndent, cb.Top+topIndent );


			// now we are ready to define the bounding box for the plot area (to use in clipping
			// operations.

			plotAreaBoundingBoxCache_ = new Rectangle( cb.Left+leftIndent,cb.Top+topIndent,
				cb.Width-leftIndent-rightIndent,
				cb.Height-topIndent-bottomIndent);

#if _IWANNASEE_
			bb = pXAxis1.GetBoundingBox();
			g.DrawRectangle( new Pen(Color.Orange), bb.X, bb.Y, bb.Width, bb.Height );
			bb = pXAxis2.GetBoundingBox();
			g.DrawRectangle( new Pen(Color.Orange), bb.X, bb.Y, bb.Width, bb.Height );
			bb = pYAxis1.GetBoundingBox();
			g.DrawRectangle( new Pen(Color.Orange), bb.X, bb.Y, bb.Width, bb.Height );
			bb = pYAxis2.GetBoundingBox();
			g.DrawRectangle( new Pen(Color.Orange), bb.X, bb.Y, bb.Width, bb.Height );
			g.DrawRectangle(new Pen(Color.Red,5.0F),plotAreaBoundingBox_);
#endif


			// Fill in the background. 
			if ( plotBackColor_ != null )
			{
				g.FillRectangle( new System.Drawing.SolidBrush( (Color)plotBackColor_ ), 
					pYAxis1.PhysicalMin.X,
					pXAxis2.PhysicalMax.Y,
					pXAxis1.PhysicalMax.X - pXAxis1.PhysicalMin.X,
					pYAxis1.PhysicalMin.Y - pYAxis1.PhysicalMax.Y );
			}

			// draw title
			StringFormat drawFormat = new StringFormat();
			drawFormat.Alignment = StringAlignment.Center;
			g.DrawString( title_, FontScaler.scaleFont(titleFont_,scale),
				titleBrush_,
				new PointF((pXAxis2.PhysicalMax.X + pXAxis2.PhysicalMin.X)/2.0f, cb.Top + padding_),
				drawFormat );

			// now draw grid.
			DrawGrid( g, pXAxis1, pYAxis1, pXAxis2, pYAxis2 );

			// now draw axes.
			pXAxis1.Draw( g );
			pXAxis2.Draw( g );
			pYAxis1.Draw( g );
			pYAxis2.Draw( g );

			// draw plots.
			for ( int i = 0; i < plots_.Count; ++i )
			{
				IPlot plot = (IPlot)plots_[i];
				XAxisPosition xap = (XAxisPosition)xAxisPositions_[i];
				YAxisPosition yap = (YAxisPosition)yAxisPositions_[i];

				PhysicalAxis xAxis;
				PhysicalAxis yAxis;

				if ( xap == XAxisPosition.Bottom )
				{
					xAxis = pXAxis1;
				}
				else
				{
					xAxis = pXAxis2;
				}

				if ( yap == YAxisPosition.Left )
				{
					yAxis = pYAxis1;
				}
				else
				{
					yAxis = pYAxis2;
				}

				// set the clipping region.. (necessary for zoom)
				g.Clip = new Region((Rectangle)plotAreaBoundingBoxCache_);
				// plot..
				plot.Draw( g, xAxis, yAxis );
				// reset it..
				g.ResetClip();

				// cache the physical axes we used on this draw;
				pXAxis1Cache_ = pXAxis1;
				pYAxis1Cache_ = pYAxis1;
				pXAxis2Cache_ = pXAxis2;
				pYAxis2Cache_ = pYAxis2;
			}

			if ( legend != null )
			{
				legend.Draw(g, (int)lXPos, (int)lYPos, plots_, scale );
			}

		}

		public void Clear()
		{
			Init();
		}

		private System.Collections.ArrayList plots_;
		private System.Collections.ArrayList xAxisPositions_;
		private System.Collections.ArrayList yAxisPositions_;

		#region Save Methods
		private System.Drawing.Imaging.ImageFormat imageFormat_ = System.Drawing.Imaging.ImageFormat.Png;

		/// <summary>
		/// get/set the File Format to use for the default.
		/// </summary>
		public System.Drawing.Imaging.ImageFormat ImageFormatDefault
		{
			get
			{
				return imageFormat_;
			}
			set
			{
				imageFormat_ = value;
			}
		}

		/// <summary>
		/// Save Methods
		/// </summary>
		public bool SaveAsFile( string strFilePath, int width, int height,
			System.Drawing.Imaging.ImageFormat imageFormat )
		{
			if ( (null == strFilePath) || ("" == strFilePath) )
			{
				return false;
			}
			if (strFilePath.IndexOf('.') == -1)
			{
				strFilePath = strFilePath + "." + imageFormat.ToString();
			}
			System.Drawing.Rectangle MyRect = new System.Drawing.Rectangle(0, 0, width, height);
			System.Drawing.Bitmap MyBitmap = new System.Drawing.Bitmap(width, height);
			Draw(Graphics.FromImage(MyBitmap), MyRect);
			MyBitmap.Save(strFilePath, imageFormat);
			return true;
		}

		public bool SaveAsFile( string strFilePath, int width, int height )
		{
			return SaveAsFile(strFilePath, width, height, imageFormat_);
		}
		#endregion

		public System.Drawing.Color PlotBackColor
		{
			get
			{
				return (Color)plotBackColor_;
			}
			set
			{
				plotBackColor_ = value;
			}
		}

		public bool ShowLegend
		{
			get
			{
				return showLegend_;
			}
			set
			{
				showLegend_ = value;
			}
		}
		private bool showLegend_;

		public float LegendXOffset
		{
			get
			{
				return legendOffsetX_;
			}
			set
			{
				legendOffsetX_ = value;
			}
		}

		public float LegendYOffset
		{
			get
			{
				return legendOffsetY_;
			}
			set
			{
				legendOffsetY_ = value;
			}
		}

		public Legend.Placement VerticalEdgeLegendPlacement
		{
			get
			{
				return verticalEdgeLegendPlacement_;
			}
			set
			{
				verticalEdgeLegendPlacement_ = value;
			}
		}

		public Legend.Placement HorizontalEdgeLegendPlacement
		{
			get
			{
				return horizontalEdgeLegendPlacement_;
			}
			set
			{
				horizontalEdgeLegendPlacement_ = value;
			}
		}

		public void LegendAttachTo( XAxisPosition xa, YAxisPosition ya )
		{
			legendOffsetXAxis_ = xa;
			legendOffsetYAxis_ = ya; 
		}

		public Legend.BorderType LegendBorderStyle
		{
			get
			{
				return legendBorderStyle_;
			}
			set
			{
				legendBorderStyle_ = value;
			}
		}

	} 
} 


