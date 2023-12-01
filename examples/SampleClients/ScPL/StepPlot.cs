/*
ScPl - A plotting library for .NET

StepPlot.cs
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

$Id: StepPlot.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;

namespace SampleClients.ScPl
{
	public class StepPlot : BasePlot, IPlot
	{
		public StepPlot( ISequenceAdapter data )
		{
			Data = data;
			Center = false;
		}

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
		private ISequenceAdapter data_;
		#endregion

		#region Draw
		public virtual void Draw( Graphics g, PhysicalAxis xAxis, PhysicalAxis yAxis )
		{
			Pen	p;
			if ( pen_ != null )
			{
				p = (System.Drawing.Pen)pen_;
			}
			else
			{
				p =	new	Pen( color_ );
			}

			for ( int i=0; i<data_.Count; ++i )
			{
				PointD p1 = data_[i];
				if ( !Double.IsNaN(p1.X) && !Double.IsNaN(p1.Y) )
				{
					// TODO: probably should check for p2, p3 too.
					PointD p2;
					PointD p3;
					if (i+1 != data_.Count)
					{
						p2 = data_[i+1];
						p2.Y = p1.Y;
						p3 = data_[i+1];
					}
					else
					{
						p2 = data_[i-1];
						double offset = p1.X - p2.X;
						p2.X = p1.X + offset;
						p2.Y = p1.Y;
						p3 = p2;
					}

					if ( center_ )
					{
						double offset = ( p2.X - p1.X ) / 2.0f;
						p1.X -= offset;
						p2.X -= offset;
						p3.X -= offset;
					}

					PointF xPos1 = xAxis.WorldToPhysical( p1.X, false );
					PointF yPos1 = yAxis.WorldToPhysical( p1.Y, false );
					PointF xPos2 = xAxis.WorldToPhysical( p2.X, false );
					PointF yPos2 = yAxis.WorldToPhysical( p2.Y, false );
					PointF xPos3 = xAxis.WorldToPhysical( p3.X, false );
					PointF yPos3 = yAxis.WorldToPhysical( p3.Y, false );

					g.DrawLine( p, xPos1.X, yPos1.Y, xPos2.X, yPos2.Y );
					g.DrawLine( p, xPos2.X, yPos2.Y, xPos3.X, yPos3.Y );
				}
			}
		}
		#endregion

		#region SuggestXAxis
		public Axis SuggestXAxis()
		{
			if (data_.Count < 2)
			{
				return data_.SuggestXAxis();
			}

			// else

			Axis a = data_.SuggestXAxis();

			PointD p1 = data_[0];
			PointD p2 = data_[1];
			PointD p3 = data_[data_.Count-2];
			PointD p4 = data_[data_.Count-1];

			double offset1;
			double offset2;

			if (!center_)
			{
				offset1 = 0.0f;
				offset2 = p4.X - p3.X;
			}
			else
			{
				offset1 = (p2.X - p1.X)/2.0f;
				offset2 = (p4.X - p3.X)/2.0f;
			}

			a.WorldMin -= offset1;
			a.WorldMax += offset2;

			return a;
		}
		#endregion

		#region SuggestXAxis
		public Axis SuggestYAxis()
		{
			return data_.SuggestYAxis();
		}
		#endregion

		#region Center
		public bool Center
		{
			set
			{
				center_ = value;
			}
			get
			{
				return center_;
			}
		}
		#endregion
		private bool center_;
	}
}
