/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 1/08/2008
 * Time: 4:47 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;

namespace Twister_5
{
	/// <summary>
	/// Description of PerlinNoise.
	/// </summary>
	public class PerlinNoise
	{
		static Random r;
		int r1;
		int r2;
		int r3;
		
		double cfrequency;
		double cpersistence;
		double coctaves;
		double camplitude;
		double ccoverage;
		double cdensity;
		
		public PerlinNoise(double f, double p, double o, double a, double c, double d)
		{
			r = new Random();
			r1 = r.Next(1000, 10000);
			r2 = r.Next(100000, 1000000);
			r3 = r.Next(1000000000, 2000000000);
			cfrequency = f;
			cpersistence = p;
			coctaves = o;
			camplitude = a;
			ccoverage = c;
			cdensity = d;
		}
		
		public double PerlinNoise2d(int x, int y)
		{
			double total = 0.0;
			
			double frequency = cfrequency;
			double persistence = cpersistence;
			double octaves = coctaves;
			double amplitude = camplitude;
    
			double cloudCoverage = ccoverage;
			double cloudDensity = cdensity;
			
			for(int lcv = 0; lcv < octaves; lcv++)
			{
				total = total + Smooth(x * frequency, y * frequency) * amplitude;
				frequency = frequency * 2;
				amplitude = amplitude * persistence;
			}
			
			total = (total + cloudCoverage) * cloudDensity;
			
			if(total < 0) total = 0.0;
			if(total > 1) total = 1.0;
			
			return total;
		}
		
		double Smooth(double x, double y)
		{
			double n1 = Noise((int)x, (int)y);
			double n2 = Noise((int)x + 1, (int)y);
			double n3 = Noise((int)x, (int)y + 1);
			double n4 = Noise((int)x + 1, (int)y + 1);
			
			double i1 = Interpolate(n1, n2, x - (int)x);
			double i2 = Interpolate(n3, n4, x - (int)x);
			
			return Interpolate(i1, i2, y - (int)y);
		}
		
		double Noise(int x, int y)
		{
			int n = x + y * 57;
			n = (n<<13) ^ n;
			
			return ( 1.0 - ( (n * (n * n * r1 + r2) + r3) & 0x7fffffff) / 1073741824.0);
		}
		
		double Interpolate(double x, double y, double a)
		{
			double val = (1 - Math.Cos(a * Math.PI)) * .5;
			return  x * (1 - val) + y * val;
		}
	}
}
