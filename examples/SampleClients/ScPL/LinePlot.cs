/*
ScPl - A plotting library for .NET

LinePlot.cs
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

$Id: LinePlot.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;
using System.Diagnostics;

namespace SampleClients.ScPl
{
	public class LinePlot : BasePlot, IPlot
	{
		#region Constructor
		public LinePlot( ISequenceAdapter data )
		{
			Data = data;
		}
		#endregion

		#region get/set Data
		public ISequenceAdapter Data
		{
			get
			{
				return data_;
			}
			set
			{
				data_ = value;
			}
		}
		#endregion
		private ISequenceAdapter data_;

		#region Draw
		public void Draw( Graphics g, PhysicalAxis xAxis, PhysicalAxis yAxis )
		{
			int numberPoints = data_.Count;

			Pen	p;
			if (pen_ != null)
			{
				p = (System.Drawing.Pen)pen_;
			}
			else
			{
				p =	new	Pen(color_);
			}

			// clipping is now handled assigning a clip region in the
			// graphic object before this call
			if ( numberPoints == 1 )
			{
				PointD point = data_[0];
				PointF xPos = xAxis.WorldToPhysical(point.X, false);
				PointF yPos = yAxis.WorldToPhysical(point.Y, false);
				g.DrawLine( p ,(float)(xPos.X-0.5f), (float)yPos.Y, (float)xPos.X+0.5f, (float)yPos.Y);
			}
			else
			{
				for ( int i = 1; i < numberPoints; ++i )
				{
					if ( !Double.IsNaN(data_[i-1].X) && !Double.IsNaN(data_[i-1].Y) && 
					  	 !Double.IsNaN(data_[i].X) && !Double.IsNaN(data_[i].Y) )
					{
						PointD point = data_[i-1];
						PointF x1 = xAxis.WorldToPhysical(point.X, false);
						PointF y1 = yAxis.WorldToPhysical(point.Y, false);

						point = data_[i];
						PointF x2 = xAxis.WorldToPhysical(point.X, false);
						PointF y2 = yAxis.WorldToPhysical(point.Y, false);
					
						g.DrawLine(p, (float)x1.X, (float)y1.Y, (float)x2.X, (float)y2.Y);
					}
				}
			}
		}
		#endregion

		#region Axis suggestion
		public Axis SuggestXAxis()
		{
			return data_.SuggestXAxis();
		}
		public Axis SuggestYAxis()
		{
			return data_.SuggestYAxis();
		}
		#endregion

	}
}
