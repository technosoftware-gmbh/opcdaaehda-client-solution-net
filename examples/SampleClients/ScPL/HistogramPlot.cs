/*
ScPl - A plotting library for .NET

HistogramPlot.cs
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

$Id: HistogramPlot.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;

namespace SampleClients.ScPl
{
	public class HistogramPlot : StepPlot
	{
		public HistogramPlot( ISequenceAdapter data )
			: base(data)
		{
			Center = true;
		}

		#region Draw
		public override void Draw( Graphics g, PhysicalAxis xAxis, PhysicalAxis yAxis )
		{
			base.Draw( g, xAxis, yAxis );

			Pen	p;
			if (pen_ != null)
			{
				p = (System.Drawing.Pen)pen_;
			}
			else
			{
				p =	new	Pen(color_);
			}

			for (int i=0; i<Data.Count; ++i)
			{
				PointD p1 = Data[i];
				PointD p2;

				if (i+1 != Data.Count)
				{
					p2 = Data[i+1];
					p2.Y = p1.Y;
				}
				else
				{
					p2 = Data[i-1];
					double offset = p1.X - p2.X;
					p2.X = p1.X+offset;
					p2.Y = p1.Y;
				}

				if (Center)
				{
					double offset = (p2.X-p1.X)/2.0f;
					p1.X -= offset;
					p2.X -= offset;
				}

				PointF xPos1 = xAxis.WorldToPhysical( p1.X, false );
				PointF yPos1 = yAxis.WorldToPhysical( p1.Y, false);
				PointF xPos2 = xAxis.WorldToPhysical( p2.X, false );
				PointF yPos2 = yAxis.WorldToPhysical( p2.Y, false );

				g.DrawLine( p, xPos1.X, yPos1.Y, xPos1.X, yAxis.WorldToPhysical( 0.0f, false ).Y );
				g.DrawLine( p, xPos2.X, yPos2.Y, xPos2.X, yAxis.WorldToPhysical( 0.0f, false ).Y );

			}
		}
		#endregion


	}
}
