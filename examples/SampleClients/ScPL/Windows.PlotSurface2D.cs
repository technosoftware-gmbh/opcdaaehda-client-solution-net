/*
ScPl - A plotting library for .NET

Windows.PlotSurface2d.cs
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

$Id: Windows.PlotSurface2D.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace SampleClients.ScPl
{
	namespace Windows 
	{
		/// <summary>
		/// PlotSurface2D Windows Control.
		/// </summary>
		public class PlotSurface2D : System.Windows.Forms.UserControl
		{
			/// <summary> 
			/// Required designer variable.
			/// </summary>
			private System.ComponentModel.Container components = null;

			#region mouse interaction functionality.
			
			private bool allowSelection_=false;
			
			[
			Category("Behavior"),
			Description("Allows the scpl control to respond to mouse events.")
			]
			public bool AllowSelection
			{
				get
				{
					return allowSelection_;
				}
				set
				{
					allowSelection_=value;
					// this is probably not needed, but
					// it's probably a good practice to redraw 
					// the control when a property changed
					Invalidate();
				}
			}
			#endregion

			public PlotSurface2D()
			{
				// This call is required by the Windows.Forms Form Designer.
				InitializeComponent();

				// double buffer, and update when resize.
				base.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
				base.SetStyle(ControlStyles.DoubleBuffer, true);
				base.SetStyle(ControlStyles.UserPaint, true);
				base.ResizeRedraw = true;

				ps_ = new SampleClients.ScPl.PlotSurface2D();
			}

			/// <summary> 
			/// Clean up any resources being used.
			/// </summary>
			protected override void Dispose( bool disposing )
			{
				if( disposing )
				{
					if(components != null)
					{
						components.Dispose();
					}
				}
				base.Dispose( disposing );
			}

			#region Component Designer generated code
			/// <summary> 
			/// Required method for Designer support - do not modify 
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				// 
				// PlotSurface2D
				// 
				BackColor = System.Drawing.SystemColors.ControlLightLight;
				Name = "PlotSurface2D";
			}
			#endregion

			#region OnPaint override
			// override method for the OnPaint method
			protected override void OnPaint( PaintEventArgs pe )
			{
				Graphics g = pe.Graphics;
				Rectangle border = new Rectangle(0,0,Width,Height);
				ps_.Draw( g, border );
				base.OnPaint(pe);
			}
			#endregion

			#region Draw
			public void Draw( Graphics g, Rectangle bounds )
			{
				ps_.Draw( g, bounds );
			}
			#endregion
			#region Clear
			public void Clear()
			{
				xAxis1Cache_ = null;
				yAxis1Cache_ = null;
				xAxis2Cache_ = null;
				yAxis2Cache_ = null;
				ps_.Clear();
			}
			#endregion
			#region Add(IPlot p) 
			/// <summary>
			/// Add a plot to the plot surface.
			/// </summary>
			/// <param name="p">the plot to add.</param>
			public void Add( IPlot p )
			{
				ps_.Add( p );
			}
			#endregion
			#region Add( IPlot, XAxisPosition, YAxisPosition ) 
			public void Add( IPlot p, XAxisPosition xp, YAxisPosition yp )
			{
				ps_.Add( p, xp, yp );
			}
			#endregion
			#region get/set Title 
			/// <summary>
			/// get/set the plot title string.
			/// </summary>
			public string Title
			{
				get 
				{
					return ps_.Title;
				}
				set 
				{
					ps_.Title = value;
				}
			}
			#endregion
			#region get/set TitleFont 
			/// <summary>
			/// get/set the plot title font.
			/// </summary>
			public Font TitleFont 
			{
				get 
				{
					return ps_.TitleFont;
				}
				set 
				{
					ps_.TitleFont = value;
				}
			}
			#endregion
			#region get/set Padding 
			public new int Padding
			{
				get
				{
					return ps_.Padding;
				}
				set
				{
					ps_.Padding = value;
				}
			}
			#endregion
			#region get/set XAxis1 
			public Axis XAxis1
			{
				get
				{
					return ps_.XAxis1;
				}
				set
				{
					ps_.XAxis1 = value;
				}
			}
			#endregion
			#region get/set YAxis1 
			public Axis YAxis1
			{
				get
				{
					return ps_.YAxis1;
				}
				set
				{
					ps_.YAxis1 = value;
				}
			}
			#endregion
			#region get/set XAxis2 
			public Axis XAxis2
			{
				get
				{
					return ps_.XAxis2;
				}
				set
				{
					ps_.XAxis2 = value;
				}
			}
			#endregion
			#region get/set YAxis2 
			public Axis YAxis2
			{
				get
				{
					return ps_.YAxis2;
				}
				set
				{
					ps_.YAxis2 = value;
				}
			}
			#endregion
			#region get PhysicalXAxis1Cache
			public PhysicalAxis PhysicalXAxis1Cache
			{
				get
				{
					return ps_.PhysicalXAxis1Cache;
				}
			}
			#endregion
			#region get PhysicalYAxis1Cache
			public PhysicalAxis PhysicalYAxis1Cache
			{
				get
				{
					return ps_.PhysicalYAxis1Cache;
				}
			}
			#endregion
			#region get PhysicalXAxis2Cache
			public PhysicalAxis PhysicalXAxis2Cache
			{
				get
				{
					return ps_.PhysicalXAxis2Cache;
				}
			}
			#endregion
			#region get PhysicalYAxis2Cache
			public PhysicalAxis PhysicalYAxis2Cache
			{
				get
				{
					return ps_.PhysicalYAxis2Cache;
				}
			}
			#endregion
			#region get/set MajorGridPen 
			public Pen MajorGridPen
			{
				get
				{
					return ps_.MajorGridPen;
				}
				set
				{
					ps_.MajorGridPen = value;
				}
			}
			#endregion
			#region get/set MinorGridPen 
			public Pen MinorGridPen
			{
				get
				{
					return ps_.MinorGridPen;
				}
				set
				{
					ps_.MinorGridPen = value;
				}
			}
			#endregion
			#region get/set PlotBackColor
			public System.Drawing.Color PlotBackColor
			{
				get
				{
					return ps_.PlotBackColor;
				}
				set
				{
					ps_.PlotBackColor = value;
				}
			}
			#endregion
			#region get/set ShowLegend
			public bool ShowLegend
			{
				get
				{
					return ps_.ShowLegend;
				}
				set
				{
					ps_.ShowLegend = value;
				}
			}
			#endregion
			#region get/set LegendXOffset
			public float LegendXOffset
			{
				get
				{
					return ps_.LegendXOffset;
				}
				set
				{
					ps_.LegendXOffset = value;
				}
			}
			#endregion
			#region get/set LegendYOffset
			public float LegendYOffset
			{
				get
				{
					return ps_.LegendYOffset;
				}
				set
				{
					ps_.LegendYOffset = value;
				}
			}
			#endregion
			#region get/set LegendBorderStyle
			public Legend.BorderType LegendBorderStyle
			{
				get
				{
					return ps_.LegendBorderStyle;
				}
				set
				{
					ps_.LegendBorderStyle = value;
				}
			}
			#endregion
			#region LegendAttachTo( .. )
			public void LegendAttachTo( XAxisPosition xa, YAxisPosition ya )
			{
				ps_.LegendAttachTo( xa, ya );
			}
			#endregion
			#region get/set VerticalEdgeLegendPlacement
			public Legend.Placement VerticalEdgeLegendPlacement
			{
				get
				{
					return ps_.VerticalEdgeLegendPlacement;
				}
				set
				{
					ps_.VerticalEdgeLegendPlacement = value;
				}
			}
			#endregion
			#region get/set HorizontalEdgeLegendPlacement
			public Legend.Placement HorizontalEdgeLegendPlacement
			{
				get
				{
					return ps_.HorizontalEdgeLegendPlacement;
				}
				set
				{
					ps_.HorizontalEdgeLegendPlacement = value;
				}
			}
			#endregion

			private SampleClients.ScPl.PlotSurface2D ps_;

			// Mouse interaction
			#region Mouse Events routines and associated variables
			private bool mouseActionInitiated_ = false;
			private Point startPoint_ = new Point(-1,-1);
			private Point endPoint_ = new Point(-1,-1);
			// this is the condition for an unset point
			private Point unset_ = new Point(-1,-1);
			private Axis xAxis1Cache_;
			private Axis yAxis1Cache_;
			private Axis xAxis2Cache_;
			private Axis yAxis2Cache_;

			protected override void OnMouseDown(MouseEventArgs e)
			{
				if (e.Button==MouseButtons.Left && allowSelection_)
				{
					// keep track of the start point and signal that we
					// have initiated a mouse action
					mouseActionInitiated_ = true;
					startPoint_.X = e.X;
					startPoint_.Y = e.Y;
					// it's a good idea to invalidate the end point
					endPoint_.X = -1;
					endPoint_.Y = -1;
				}
				// don't fail to call the base method!
				base.OnMouseDown(e);
			}
			
			protected override void OnMouseMove(MouseEventArgs e)
			{
				// we do this only if we can select AND we
				// have initiated a mouse action (pressing the button)
				if ( e.Button==MouseButtons.Left && allowSelection_ && mouseActionInitiated_ )
				{
					// we are here
					Point here = new Point( e.X, e.Y );
					// ok, we can delete the previous box
					if ( endPoint_ != unset_ )
					{
						DrawRubberBand( startPoint_, endPoint_ );
					}
					endPoint_ = here;
					// and redraw the last one
					DrawRubberBand( startPoint_, here );
				}
				// don't fail to call the base method!
				base.OnMouseMove( e );
			}
			
			protected override void OnMouseUp(MouseEventArgs e)
			{
				if (e.Button==MouseButtons.Left && allowSelection_)
				{
					endPoint_.X=e.X;
					endPoint_.Y=e.Y;
					// terminate mouse action
					mouseActionInitiated_=false;
					if(endPoint_ != unset_)
					{
						DrawRubberBand(startPoint_,endPoint_);
					}
					
					Point minPoint = new Point( 0, 0 );
					minPoint.X = Math.Min( startPoint_.X, endPoint_.X );
					minPoint.Y = Math.Min( startPoint_.Y, endPoint_.Y );

					Point maxPoint = new Point( 0, 0 );
					maxPoint.X = Math.Max( startPoint_.X, endPoint_.X );
					maxPoint.Y = Math.Max( startPoint_.Y, endPoint_.Y );

					Rectangle r=ps_.PlotAreaBoundingBoxCache;
					if(minPoint !=maxPoint && (r.Contains(minPoint) || r.Contains(maxPoint)))
					{
						if ( xAxis1Cache_ == null )
						{
							xAxis1Cache_ = (Axis)XAxis1.Clone();
							xAxis2Cache_ = (Axis)XAxis2.Clone();
							yAxis1Cache_ = (Axis)YAxis1.Clone();
							yAxis2Cache_ = (Axis)YAxis2.Clone();
						}

						// TODO: these bugger up if min/max point reversed.
						// think this implies can't have axes directed wrong way.
						// check out later.
					
						// middle wheel will be controlling zoom in future. left mouse may
						// be drag => stack zoom out not long term solution, so just make 
						// zoom out go right out at this stage.

						if (XAxis1 != null)
						{
							double tempMin = 
								PhysicalXAxis1Cache.PhysicalToWorld(minPoint,true);
							
							XAxis1.WorldMax = 
								PhysicalXAxis1Cache.PhysicalToWorld(maxPoint,true);

							XAxis1.WorldMin = tempMin;
						}
					
						if (XAxis2 != null)
						{
							double tempMin = 
								PhysicalXAxis2Cache.PhysicalToWorld(minPoint,true);
							
							XAxis2.WorldMax = 
								PhysicalXAxis2Cache.PhysicalToWorld(maxPoint,true);
							
							XAxis2.WorldMin = tempMin;
						}

						if (YAxis1 != null)
						{

							double tempMin = 
								PhysicalYAxis1Cache.PhysicalToWorld(maxPoint,true);

							YAxis1.WorldMax = 
								PhysicalYAxis1Cache.PhysicalToWorld(minPoint,true);
							
							YAxis1.WorldMin = tempMin;
						}
				
						if (YAxis2 != null)
						{
							double tempMin =
								PhysicalYAxis2Cache.PhysicalToWorld(maxPoint,true);

							YAxis2.WorldMax = 
								PhysicalYAxis2Cache.PhysicalToWorld(minPoint,true);
							
							YAxis2.WorldMin = tempMin;
						}

						// reset the start/end points
						startPoint_ = unset_;
						endPoint_ = unset_;

						Refresh();
					}
				}
				else if (e.Button == MouseButtons.Right)
				{
					if ( xAxis1Cache_ != null )
					{
						XAxis1 = xAxis1Cache_;
						XAxis2 = xAxis2Cache_;
						YAxis1 = yAxis1Cache_;
						YAxis2 = yAxis2Cache_;

						xAxis1Cache_ = null;
						xAxis2Cache_ = null;
						yAxis1Cache_ = null;
						yAxis2Cache_ = null;
					}					

					Refresh();
				}
				
				// don't fail to call the base method!
				base.OnMouseUp(e);
			}

			private void DrawRubberBand(Point start, Point end)
			{
				Rectangle rect = new Rectangle();
				// the clipping rectangle in screen coordinates
				Rectangle clip = RectangleToScreen( ps_.PlotAreaBoundingBoxCache );
				// convert to screen coords
				start = PointToScreen( start );
				end = PointToScreen( end );
				// now, "normalize" the rectangle
				if ( start.X < end.X )
				{
					rect.X = start.X;
					rect.Width = end.X - start.X;
				}
				else
				{
					rect.X = end.X;
					rect.Width = start.X - end.X;
				}
				if ( start.Y < end.Y )
				{
					rect.Y = start.Y;
					rect.Height = end.Y - start.Y;
				}
				else
				{
					rect.Y = end.Y;
					rect.Height = start.Y - end.Y;
				}
				rect = Rectangle.Intersect( rect, clip );
				ControlPaint.DrawReversibleFrame( rect, Color.White, FrameStyle.Dashed );
			}
			#endregion

			#region Save Methods
			public bool SaveAsFile( string strFilePath, int width, int height,
				System.Drawing.Imaging.ImageFormat imageFormat) 
			{
				return ps_.SaveAsFile(strFilePath, width, height, imageFormat);
			}

			public bool SaveAsFile( string strFilePath, System.Drawing.Imaging.ImageFormat imageFormat ) 
			{
				return ps_.SaveAsFile(strFilePath, Width, Height, imageFormat);
			}

			public bool SaveAsFile( string strFilePath ) 
			{
				return ps_.SaveAsFile(strFilePath, Width, Height);
			}

			#endregion

		}
	}
}
