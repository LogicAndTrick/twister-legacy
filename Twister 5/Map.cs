/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 31/07/2008
 * Time: 7:51 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of Map.
	/// </summary>
	public class Map
	{
		System.Collections.Generic.List<Brush> brushes;
		int cbid;
		int dispconvs;
		bool success;
		
		public Map()
		{
			brushes = new System.Collections.Generic.List<Brush>();
			cbid = 1;
			dispconvs = 0;
			success = true;
		}
		
		public void incDisp()
		{
			dispconvs++;
		}
		
		public int numDisp()
		{
			return dispconvs;
		}
		
		public void addBrush(Brush b)
		{
			b.setID(cbid);
			cbid++;
			brushes.Add(b);
		}
		
		public int numBrushes()
		{
			return brushes.Count;
		}
		
		public Brush[] ToArray()
		{
			return brushes.ToArray();
		}
		
		public override string ToString()
		{
			string str = "";
			foreach (Brush b in brushes.ToArray()) {
				str += b.ToString();
			}
			return str;
		}
		
		public void fail()
		{
			success = false;
		}
		
		public bool isFail()
		{
			return success;
		}
	}
}
