/*
ScPl - A plotting library for .NET

BasePlot.cs
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

$Id: BasePlot.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;

namespace SampleClients.ScPl
{
	/// <summary>
	/// Summary description for BasePlot.
	/// </summary>
	public class BasePlot
	{
		public BasePlot()
		{
		}

		public virtual void DrawLegendLine( Graphics g, RectangleF startEnd )
		{
			Pen	p;
			if ( pen_ != null )
			{
				p = (System.Drawing.Pen)pen_;
			}
			else
			{
				p =	new	Pen(color_);
			}

			g.DrawLine( p, startEnd.Left, (startEnd.Top + startEnd.Bottom)/2.0f, 
				startEnd.Right, (startEnd.Top + startEnd.Bottom)/2.0f );
		}

		#region set Pen
		public System.Drawing.Pen Pen
		{
			set
			{
				pen_ = value;
			}
		}
		#endregion
		protected System.Drawing.Pen pen_;

		#region get/set Color
		public System.Drawing.Color Color
		{
			set
			{
				color_ = value;
			}
			get
			{
				return color_;
			}
		}
		#endregion
		protected System.Drawing.Color color_ = Color.Black;

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

	}
}
