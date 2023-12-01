/*
ScPl - A plotting library for .NET

Bitmap.PlotSurface2D.cs
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

$Id: Bitmap.PlotSurface2D.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SampleClients.ScPl
{
	namespace Bitmap
	{
		public class PlotSurface2D
		{
			#region Constructors
			/// <summary>
			/// </summary>
			/// <param name="xSize">width of the bitmap</param>
			/// <param name="ySize">height of the bitmap</param>
			public PlotSurface2D( int xSize, int ySize )
			{
				b_ = new System.Drawing.Bitmap( xSize, ySize );
				ps_ = new SampleClients.ScPl.PlotSurface2D();	
			}

			public PlotSurface2D( System.Drawing.Bitmap b )
			{
				b_ = b;
				ps_ = new SampleClients.ScPl.PlotSurface2D();	
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
			public int Padding
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

			#region get Width
			public int Width 
			{
				get
				{
					return b_.Width;
				}
			}
			#endregion
			#region get Height
			public int Height 
			{
				get 
				{
					return b_.Height;
				}
			}
			#endregion

			/*
			#region ToBrowser
			public void ToBrowser( System.Web.UI.Page br ) 
			{
				MemoryStream stream = new MemoryStream();
				ps_.Render(Graphics.FromImage(b_),new System.Drawing.Rectangle(0,0,b_.Width,b_.Height));
				this.Bitmap.Save(stream, ImageFormat.Png);
				br.Response.Clear();
				br.Response.ContentType = "image/png";
				br.Response.BinaryWrite(stream.ToArray());
			}
			#endregion
			*/

			#region get/set Bitmap
			/// <summary>
			/// get/set the bitmap
			/// </summary>
			public System.Drawing.Bitmap Bitmap 
			{
				get 
				{
					return b_;
				}
				set
				{
					b_ = value;
				}
			}
			#endregion

			#region Refresh
			public void Refresh()
			{
				ps_.Draw( Graphics.FromImage(b_), new System.Drawing.Rectangle(0,0,b_.Width,b_.Height) );
			}
			#endregion

			private SampleClients.ScPl.PlotSurface2D ps_;
			private System.Drawing.Bitmap b_;
		}
	}
}
