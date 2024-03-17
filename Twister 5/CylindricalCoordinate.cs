/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 18/07/2008
 * Time: 10:55 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of CylindricalCoordinate.
	/// </summary>
	public class CylindricalCoordinate
	{
		private float angle;
		private float distance;
		private float height;
		
		public CylindricalCoordinate()
		{
		}
		
		public float getAngle()
		{
			return angle;
		}
		
		public float getDistance()
		{
			return distance;
		}
		
		public float getHeight()
		{
			return height;
		}
		
		public void setAngle(float a)
		{
			this.angle = a;
		}
		
		public void setDistance(float d)
		{
			this.distance = d;
		}
		
		public void setHeight(float h)
		{
			this.height = h;
		}
	}
}
