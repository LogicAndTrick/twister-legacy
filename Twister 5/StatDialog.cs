/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 22/08/2008
 * Time: 3:55 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace Twister_5
{
	/// <summary>
	/// Description of StatDialog.
	/// </summary>
	public class StatDialog
	{
		string[] keys;
		string[] values;
		public StatDialog(int cap)
		{
			keys = new string[cap];
			values = new string[cap];
		}
		
		public void addStat(int n, string key, string val)
		{
			keys[n] = key;
			values[n] = val;
		}
		
		public string[] getStat(int n)
		{
			string[] r =  {keys[n],values[n]};
			return r;
		}
	}
}
