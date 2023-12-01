/*
ScPl - A plotting library for .NET

MainForm.cs
Copyright (C) 2003
Paolo Pierini, Matt Howlett

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

$Id: Marker.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/
using System;
using System.Drawing;

namespace SampleClients.ScPl
{
	/// <summary>
	/// Enumeration for the Marker Types
	/// </summary>
	public enum MarkerType
	{
		/// <summary>
		/// A simple cross marker (x).
		/// </summary>
		Cross1,
		/// <summary>
		/// Another simple cross marker (+).
		/// </summary>
		Cross2,
		/// <summary>
		/// A circle marker.
		/// </summary>
		Circle,
		/// <summary>
		/// A square marker.
		/// </summary>
		Square,
		/// <summary>
		/// A triangle marker.
		/// </summary>
		Triangle,
		/// <summary>
		/// A filled circle
		/// </summary>
		FilledCircle,
		/// <summary>
		/// A filled square
		/// </summary>
		FilledSquare,
		/// <summary>
		/// A filled triangle
		/// </summary>
		FilledTriangle
	}
	/// <summary>
	/// Summary description for Marker.
	/// </summary>
	public class Marker
	{

		// Private Members of the Marker Class
		private MarkerType markerType_;
		private int size_;
		private int h_;
		private System.Drawing.Color color_;
		private System.Drawing.Pen pen_;

		#region get/set properties
		/// <summary>
		/// Get/Set the Marker Type
		/// </summary>
		public MarkerType Type
		{
			get
			{
				return markerType_;
			}
			set
			{
				markerType_=value;
			}
		}
		public int Size
		{
			get
			{
				return size_;
			}
			set
			{
				size_=value;
				h_=size_/2;
			}
		}
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
		public System.Drawing.Pen Pen
		{
			set
			{
				pen_ = value;
			}
		}
		#endregion

		#region Constructors
		public Marker()
		{
			markerType_=MarkerType.Square;
			Size=4;
			color_=Color.Black;
			pen_=new Pen(Color.Black);
		}
		public Marker(MarkerType markertype)
		{
			markerType_=markertype;
			Size=4;
			color_=Color.Black;
			pen_=new Pen(Color.Black);
		}
		public Marker(MarkerType markertype,int size)
		{
			markerType_=markertype;
			Size=size;
			color_=Color.Black;
			pen_=new Pen(Color.Black);
		}
		public Marker(MarkerType markertype,int size,Color color)
		{
			markerType_=markertype;
			Size=size;
			color_=color;
			pen_=new Pen(color);
		}
		public Marker(MarkerType markertype,int size,Pen pen)
		{
			markerType_=markertype;
			Size=size;
			pen_=pen;
			color_=pen.Color;
		}

		#endregion

		internal void Draw( Graphics g, int x, int y)
		{
			Pen p;
			if (pen_ != null)
			{
				p = pen_;
			}
			else
			{
				p =	new	Pen(color_);
			}

			// Instance a new SolidBrush for filling
			SolidBrush b = new SolidBrush(p.Color);
			// the path used for the marker
			PointF[] path;
			switch(markerType_)
			{
			case MarkerType.Cross1:
				g.DrawLine(p,x-h_,y+h_,x+h_,y-h_);
				g.DrawLine(p,x+h_,y+h_,x-h_,y-h_);
				break;
			case MarkerType.Cross2:
				g.DrawLine(p,x,y-h_,x,y+h_);
				g.DrawLine(p,x-h_,y,x+h_,y);
				break;
			case MarkerType.Circle:
				g.DrawEllipse(p,x-h_,y-h_,size_,size_);
				break;
			case MarkerType.Square:
				g.DrawLine(p,x-h_,y-h_,x+h_,y-h_);
				g.DrawLine(p,x-h_,y+h_,x+h_,y+h_);
				g.DrawLine(p,x-h_,y-h_,x-h_,y+h_);
				g.DrawLine(p,x+h_,y-h_,x+h_,y+h_);
				break;
			case MarkerType.Triangle:
				g.DrawLine(p,x-h_,y-h_,x,y+h_);
				g.DrawLine(p,x,y+h_,x+h_,y-h_);
				g.DrawLine(p,x-h_,y-h_,x+h_,y-h_);
				break;
			case MarkerType.FilledCircle:
				g.FillEllipse(b,x-h_,y-h_,size_,size_);
				break;
			case MarkerType.FilledSquare:
				path=new PointF[] {new PointF(x-h_,y-h_),new PointF(x-h_,y+h_),
									  new PointF(x+h_,y+h_),new PointF(x+h_,y-h_),
									  new PointF(x-h_,y-h_)};
				g.FillPolygon(b, path, System.Drawing.Drawing2D.FillMode.Winding );
				break;
			case MarkerType.FilledTriangle:
				path=new PointF[] {new PointF(x-h_,y-h_),new PointF(x,y+h_),
									  new PointF(x+h_,y-h_),new PointF(x-h_,y-h_)};
				g.FillPolygon(b, path, System.Drawing.Drawing2D.FillMode.Winding );
				break;
			}
		}

	}
}
