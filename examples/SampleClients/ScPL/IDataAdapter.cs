/*
ScPl - A plotting library for .NET

IDataAdapter.cs
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

$Id: IDataAdapter.cs 1 2015-06-16 02:54:00Z thomasjohannhson $

*/

using System;

namespace SampleClients.ScPl
{
	public interface IDataAdapter
	{
		// All Data Adapters can hint at the axis they would prefer to have
		// their data plotted with. The data may not necessarily be plotted
		// with the provided axis. The PlotSurface object will employ probably
		// quite envolved heuristics to determine the actual axis used. The
		// actual axis can also be specified
		//
		// Note, the Data Adapter class is not supposed to provide the user
		// with an interface that has anything to do with axes. The user
		// deals with axes info only when dealing with PlotSurface class.
		//
		// These hint functions provide a way of passing data type (ie label,
		// time, number) info between dataadapters and axes. Otherwise no
		// other way, or extra type info objects needed.
		Axis SuggestXAxis();
		Axis SuggestYAxis();
	}
}
