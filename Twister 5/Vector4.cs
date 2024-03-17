/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 3/08/2008
 * Time: 3:42 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of Vector4.
	/// </summary>
	public class Vector4
	{
		float[] values;
		
		public Vector4()
		{
			values = new float[4];
		}
		
		public float getValue(int x)
		{
			try {
				return values[x];
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
				return 0;
			}
		}
		
		public void setValue(int x, float v)
		{
			try {
				values[x] = v;
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public override string ToString()
		{
			return "[" + values[0] + " " + values[1] + " " + values[2] + " " + values[3] + "]";
		}
		
		public string ToString(bool b)
		{
			return "[ " + values[0] + " " + values[1] + " " + values[2] + " " + values[3] + " ]";
		}
	}
}
