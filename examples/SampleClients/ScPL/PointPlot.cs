/*
ScPl - A plotting library for .NET

PointPlot.cs
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

$Id: PointPlot.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;

namespace SampleClients.ScPl
{
	public class PointPlot : IPlot
	{
		private Marker marker_;

		#region Constructors
		public PointPlot( ISequenceAdapter data )
		{
			marker_=new Marker();
			Data = data;
		}
		public PointPlot( ISequenceAdapter data, Marker marker)
		{
			marker_=marker;
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
		private ISequenceAdapter data_;
		#endregion

		#region Draw
		public void Draw( Graphics g, PhysicalAxis xAxis, PhysicalAxis yAxis )
		{
			for (int i=0; i<data_.Count; ++i)
			{
				// clipping is now handled assigning a clip region in the
				// graphic object before this call
				PointF xPos = xAxis.WorldToPhysical( data_[i].X, false);
				PointF yPos = yAxis.WorldToPhysical( data_[i].Y, false);
				marker_.Draw(g,(int)xPos.X, (int)yPos.Y);
			}
		}
		#endregion

		#region SuggestXAxis
		public Axis SuggestXAxis()
		{
			return data_.SuggestXAxis();
		}
		#endregion

		#region SuggestYAxis
		public Axis SuggestYAxis()
		{
			return data_.SuggestYAxis();
		}
		#endregion

		private string label_ = "";
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

		public void DrawLegendLine( Graphics g, RectangleF startEnd )
		{
			marker_.Draw( g, (int)startEnd.Left+4, (int)((startEnd.Top + startEnd.Bottom)/2.0f) );
			marker_.Draw( g, (int)startEnd.Right-4, (int)((startEnd.Top + startEnd.Bottom)/2.0f) );

		}

		#region get/set Marker
		public Marker Marker
		{
			set
			{
				marker_ = value;
			}
			get
			{
				return marker_;
			}
		}
		#endregion
	}
}