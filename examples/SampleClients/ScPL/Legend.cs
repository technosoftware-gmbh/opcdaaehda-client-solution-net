/*
ScPl - A plotting library for .NET

Legend.cs
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

$Id: Legend.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;

namespace SampleClients.ScPl
{
	/// <summary>
	/// Summary description for Legend.
	/// </summary>
	public class Legend
	{
		public Legend()
		{
			Font = new Font(new FontFamily("Arial"), 10, FontStyle.Regular, GraphicsUnit.Pixel);
		}

		public RectangleF GetBoundingBox( int xPos, int yPos, ArrayList plots, float scale )
		{
			System.Drawing.Bitmap b = new System.Drawing.Bitmap(1,1);
			Graphics g = Graphics.FromImage(b);
			return Draw( g, xPos, yPos, plots, scale );
		}

		public RectangleF Draw( Graphics g, int xPos, int yPos, ArrayList plots, float scale )
		{	

			// determine max width and max height of label strings.
			float maxHt = 0.0f;
			float maxWd = 0.0f;
			for (int i=0; i<plots.Count; ++i)
			{
				IPlot p = (IPlot)plots[i];
				float lHt = g.MeasureString( p.Label, FontScaler.scaleFont(font_,scale) ).Height;
				float lWd = g.MeasureString( p.Label, FontScaler.scaleFont(font_,scale) ).Width;
				if ( lHt > maxHt )
				{
					maxHt = lHt;
				}
				if ( lWd > maxWd )
				{
					maxWd = lWd;
				}
			}

			float lineLength = 20.0f;
			float lineHeight = maxHt;
			float hSpacing = 5.0f * scale;
			float vSpacing = 3.0f * scale; 
			float boxWidth = hSpacing * 3.0f + lineLength + maxWd;
			float boxHeight = vSpacing * (float)(plots.Count+1) + maxHt * (float)plots.Count;

			float totalWidth = boxWidth;
			float totalHeight = boxHeight;

			// draw box..
			if ( BorderStyle == BorderType.Line )
			{
				g.FillRectangle( new SolidBrush( Color.White ), xPos, yPos, boxWidth, boxHeight );
				g.DrawRectangle( new Pen( Color.Black ), xPos, yPos, boxWidth, boxHeight );
			}
			else if ( BorderStyle == BorderType.Shadow )
			{
				float offset = 4.0f * (float)scale;
				g.FillRectangle( new SolidBrush( Color.LightGray ), xPos+offset, yPos+offset, boxWidth, boxHeight );
				g.FillRectangle( new SolidBrush( Color.White ), xPos, yPos, boxWidth, boxHeight );
				g.DrawRectangle( new Pen( Color.Black ), xPos, yPos, boxWidth, boxHeight );

				totalWidth += offset;
				totalHeight += offset;
			}
			/*
			else if ( this.BorderStyle == BorderType.Curved )
			{
				// TODO. make this nice.
			} 
			*/
			else
			{
				// do nothing.
			}

			// now draw entries in box..
			int unnamedCount = 0;
			for (int i=0; i<plots.Count; ++i)
			{
				IPlot p = (IPlot)plots[i];
				float lineXPos = xPos + hSpacing;
				float lineYPos = yPos + vSpacing + (float)i*(vSpacing+maxHt);
				p.DrawLegendLine( g, new RectangleF( lineXPos, lineYPos, lineLength, lineHeight ) );
				float textXPos = lineXPos + hSpacing + lineLength;
				float textYPos = lineYPos;
				string label = p.Label;
				if (label == "")
				{
					unnamedCount += 1;
					label = "Series " + unnamedCount.ToString();
				}
				g.DrawString( label, FontScaler.scaleFont(Font,scale),
					new SolidBrush( Color.Black ), textXPos, textYPos );
			}

			return new RectangleF( xPos, yPos, totalWidth, totalHeight );
		}

		public Font Font
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
		private Font font_;

		public enum BorderType
		{
			None = 0,
			Line = 1,
			Shadow = 2
			//Curved = 3
		}

		public enum Placement
		{
			Inside = 0,
			Outside
		}

		public BorderType BorderStyle
		{
			get
			{
				return borderStyle_;
			}
			set
			{
				borderStyle_ = value;
			}
		}
		BorderType borderStyle_ = BorderType.Line;

	}
}
