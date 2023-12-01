/*
ScPl - A plotting library for .NET

ArrayAdapter.cs
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

$Id: ArrayAdapter.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System.Drawing;
using System.Diagnostics;

namespace SampleClients.ScPl
{

	public class ArrayAdapter : ISequenceAdapter
	{

		#region get Count
		public int Count
		{
			get
			{
				return YValues.Length;
			}
		}
		#endregion

		#region PointD this[int i]
		public PointD this[int i]
		{	
			get
			{
				if ( xValues_ == null )
				{
					double xPos = Start + i*Step;
					return new PointD( (double)xPos, (double)yValues_[i] );
				}
				else
				{
					return new PointD( (double)xValues_[i], (double)yValues_[i] );
				}
			}
		}
		#endregion

		#region Constructors
		public ArrayAdapter( float[] xs, float[] ys )
		{
			if ( xs.Length != ys.Length )
			{
				throw new System.Exception( "xs and ys not same length." );
			}
			double[] xsd = new double[xs.Length];
			double[] ysd = new double[ys.Length];
			for ( int i=0; i < xs.Length; ++i ) 
			{
				xsd[i] = xs[i];
				ysd[i] = ys[i];
			}
			yValues_ = ysd;
			xValues_ = xsd;
			step_ = null;
			start_ = null;
			ArrayMinMax( xValues_, out xValuesMin_, out xValuesMax_);
			ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);
		}

		/// <summary>
		/// Causes the data to be replicated if DoClone is true. 
		/// Otherwise the original data is used. if DoClone is false and the data changes
		/// or goes out of scope before the plot is drawn, results are unpredictable.
		/// </summary>
		public ArrayAdapter( double[] xs, double[] ys, bool DoClone ) : this(xs, ys, DoClone, DoClone)
		{
		}

		/// <summary>
		/// Causes the data to be replicated if DoClone is true. 
		/// Otherwise the original data is used. if DoClone is false and the data changes
		/// or goes out of scope before the plot is drawn, results are unpredictable.
		/// </summary>
		public ArrayAdapter( double[] xs, double[] ys, bool DoCloneX, bool DoCloneY )
		{
			if ( xs.Length != ys.Length )
			{
				throw new System.Exception( "xs and ys not same length." );
			}
			if (DoCloneX) 
			{
				xValues_ = (double[])xs.Clone();
			} 
			else 
			{
				xValues_ = xs;
			}
			if (DoCloneY) 
			{
				yValues_ = (double[])ys.Clone();
			} 
			else 
			{
				yValues_ = ys;
			}
			step_ = null;
			start_ = null;
			ArrayMinMax( xValues_, out xValuesMin_, out xValuesMax_);
			ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);
		}

		public ArrayAdapter( double[] xs, double[] ys )
		{
			if ( xs.Length != ys.Length )
			{
				throw new System.Exception( "xs and ys not same length." );
			}
			yValues_ = ys;
			xValues_ = xs;
			step_ = null;
			start_ = null;
			ArrayMinMax( xValues_, out xValuesMin_, out xValuesMax_);
			ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);
		}

		public ArrayAdapter( float[] ys )
		{
			double[] ysd = new double[ys.Length];
			for ( int i = 0; i<ys.Length; ++i )
			{
				ysd[i] = ys[i];
			}
			yValues_ = ysd; 
			start_ = 0.0;
			step_ = 1.0;
			xValues_ = null;
			ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);
		}

		public ArrayAdapter( double[] ys )
		{
			yValues_ = ys; 
			start_ = 0.0;
			step_ = 1.0;
			xValues_ = null;
			ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);
		}

		public ArrayAdapter( float[] ys, float start, float step )
		{
			double[] ysd = new double[ys.Length];
			for ( int i=0; i<ys.Length; ++i ) 
			{
				ysd[i] = ys[i];
			}
			yValues_ = ysd;
			start_ = (double)start;
			step_ = (double)step;
			xValues_ = null;
			ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);
		}

		public ArrayAdapter( double[] ys, double start, double step )
		{
			yValues_ = ys;
			start_ = start;
			step_ = step;
			xValues_ = null;
			ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);
		}
		#endregion

		#region Suggest Axes
		public Axis SuggestXAxis()
		{
			// Array data would be nicely drawn using a linear axis, that just includes all data points.
			if ( xValues_ == null )
			{
				if ( yValues_ == null )
				{
					return new LinearAxis( Start, 1.0 );
				}
				else
				{
					return new LinearAxis( Start, Start + Step * (yValues_.Length - 1) );
				}
			}
			else
			{
				double range = XValuesMax - XValuesMin;
				
				if ( range > 0.0F )
				{
					range *= 0.08F;
				}
				else 
				{
					range = 0.01F;
				}

				return new LinearAxis( XValuesMin - range, XValuesMax + range);
			}
		}
		
		public Axis SuggestYAxis()
		{
			// Array data would be nicely drawn using a linear axis, that just includes all data points.
			double range = YValuesMax - YValuesMin;
			
			if ( range > 0.0F )
			{
				range *= 0.08F;
			}
			else
			{
				range = 0.01F;
			}

			return new LinearAxis( YValuesMin - range, YValuesMax + range);
		}

		#endregion

		#region ArrayMinMax
		/// <summary>
		/// double[] is a reference type and can be null, if it is then I reckon the best
		/// values for min and max are also null. double is a value type so can't be set
		///	to null. So min an max return object, and we understand that if it is not null
		/// it is a boxed double (same trick I use lots elsewhere in the lib). The 
		/// wonderful comment I didn't write at the top should explain everything.
		/// </summary>
		public bool ArrayMinMax( double[] a, out object min, out object max )
		{
			if ( a == null || a.Length == 0 )
			{
				min = null;
				max = null;
				return false;
			}

			min = a[0];
			max = a[0];
			foreach ( double e in a ) 
			{
			
				if (e < (double)min)
				{
					min = e;
				}
			
				if (e > (double)max) 
				{
					max = e;
				}
			}
			return true;

		}
		#endregion

		#region get/set YValues
		public double[] YValues
		{
			get
			{
				return yValues_;
			}
			set
			{
				yValues_ = value;
			}
		}
		#endregion
		#region get/set XValues
		public double[] XValues
		{
			get
			{
				return xValues_;
			}
			set
			{
				xValues_ = value;
			}
		}
		#endregion
		#region get/set Start
		public double Start
		{
			get
			{
				if (start_ != null)
				{
					return (double)start_;
				}
				throw new System.Exception( "start_ not set." );
			}
			set
			{
				start_ = value;
			}
		}

		#endregion
		#region get/set Step
		public double Step
		{
			get
			{
				if ( step_ != null )
				{
					return (double)step_;
				}
				throw new System.Exception( "step_ not set." );
			}
			set
			{
				step_ = value;
			}
		}
		#endregion

		private double[] xValues_;
		private double[] yValues_;
		private object start_;
		private object step_;

		#region get/set XValuesMin, XValuesMax, YValuesMin, YValuesMax

		private object xValuesMin_ = null;
		private object xValuesMax_ = null;
		private object yValuesMin_ = null;
		private object yValuesMax_ = null;

		public double XValuesMin
		{
			get
			{
				if ( xValues_ == null ) 
				{
					throw new System.Exception( "xValueMin not set." );
				}
				if ( xValuesMin_ == null ) 
				{
					ArrayMinMax( xValues_, out xValuesMin_, out xValuesMax_);				
				}
				return (double)xValuesMin_;
			}
		}

		public double XValuesMax
		{
			get
			{
				if ( xValues_ == null ) 
				{
					throw new System.Exception( "xValueMax not set." );
				}
				if ( xValuesMax_ == null ) 
				{
					ArrayMinMax( xValues_, out xValuesMin_, out xValuesMax_);				
				}
				return (double)xValuesMax_;
			}
		}

		public double YValuesMin
		{
			get
			{
				if ( yValues_ == null ) 
				{
					throw new System.Exception( "yValueMin not set." );
				}
				if ( yValuesMin_ == null ) 
				{
					ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);				
				}
				return (double)yValuesMin_;
			}
		}

		public double YValuesMax
		{
			get
			{
				if ( yValues_ == null ) 
				{
					throw new System.Exception( "yValueMax not set." );
				}
				if ( yValuesMax_ == null ) 
				{
					ArrayMinMax( yValues_, out yValuesMin_, out yValuesMax_);				
				}
				return (double)yValuesMax_;
			}
		}

		#endregion
		
	} 

} 
