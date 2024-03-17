/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 13/07/2008
 * Time: 3:04 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;

namespace Twister_5
{
	/// <summary>
	/// Description of Displacement.
	/// </summary>
	public class Displacement
	{
		float width;
		float length;
		float height;
		float xstart;
		float ystart;
		float zstart;
		int power;
		int dispside;
		int reso;
		int resolution;
		float[,] xpoints;
		float[,] ypoints;
		float[,] zpoints;
		string[] planes;
		string[] vaxis;
		string[] uaxis;
		string[] triplanes;
		string[] trivaxis;
		string[] triuaxis;
		int id;
		int displacementnumber;
		
		public Displacement(float w, float l, float h, int pow, float xs, float ys, float zs)
		{
			width = w;
			length = l;
			height = h;
			xstart = xs;
			ystart = ys;
			zstart = zs;
			power = pow;
			dispside = 1;
			reso = (int)Math.Pow(2,pow);
			resolution = reso+1;
			//---
			xpoints = new float[resolution,resolution];
			ypoints = new float[resolution,resolution];
			zpoints = new float[resolution,resolution];
			xpoints.Initialize();
			ypoints.Initialize();
			zpoints.Initialize();
			//---
			planes = new String[6];
			planes.Initialize();
			vaxis = new String[6];
			vaxis.Initialize();
			uaxis = new String[6];
			uaxis.Initialize();
			triplanes = new string[4];
			triplanes.Initialize();
			trivaxis = new String[4];
			trivaxis.Initialize();
			triuaxis = new String[4];
			triuaxis.Initialize();
			//---
			/*planes[0] = "(0 0 0) (0 " + l + " 0) (" + w + " " + l + " 0)";
			planes[1] = "(0 " + l + " " + h + ") (0 0 " + h + ") (" + w + " 0 " + h + ")";
			planes[2] = "(0 0 " + h + ") (0 " + l + " " + h + ") (0 " + l + " 0)";
			planes[3] = "(" + w + " " + l + " " + h + ") (" + w + " 0 " + h + ") (" + w + " 0 0)";
			planes[4] = "(0 " + l + " " + h + ") (" + w + " " + l + " " + h + ") (" + w + " " + l + " 0)";
			planes[5] = "(" + w + " 0 " + h + ") (0 0 " + h + ") (0 0 0)";*/
			//---
			float lys = l + ys;
			float wxs = w + xs;
			planes[0] = "(" + xs + " " + ys + " 0) (" + xs + " " + lys + " 0) (" + wxs + " " + lys + " 0)";
			planes[1] = "(" + xs + " " + lys + " " + h + ") (" + xs + " " + ys + " " + h + ") (" + wxs + " " + ys + " " + h + ")";
			planes[2] = "(" + xs + " " + ys + " " + h + ") (" + xs + " " + lys + " " + h + ") (" + xs + " " + lys + " 0)";
			planes[3] = "(" + wxs + " " + lys + " " + h + ") (" + wxs + " " + ys + " " + h + ") (" + wxs + " " + ys + " 0)";
			planes[4] = "(" + xs + " " + lys + " " + h + ") (" + wxs + " " + lys + " " + h + ") (" + wxs + " " + lys + " 0)";
			planes[5] = "(" + wxs + " " + ys + " " + h + ") (" + xs + " " + ys + " " + h + ") (" + xs + " " + ys + " 0)";
			//---
			vaxis[0] = "[0 -1 0 0]";
			vaxis[1] = "[0 -1 0 0]";
			vaxis[2] = "[0 0 -1 0]";
			vaxis[3] = "[0 0 -1 0]";
			vaxis[4] = "[0 0 -1 0]";
			vaxis[5] = "[0 0 -1 0]";
			//---
			uaxis[0] = "[1 0 0 0]";
			uaxis[1] = "[1 0 0 0]";
			uaxis[2] = "[0 1 0 0]";
			uaxis[3] = "[0 1 0 0]";
			uaxis[4] = "[1 0 0 0]";
			uaxis[5] = "[1 0 0 0]";
			//---
			trivaxis[0] = "[0 -1 0 0]";
			trivaxis[1] = "[0 0 -1 0]";
			trivaxis[2] = "[0 0 -1 0]";
			trivaxis[3] = "[0 0 -1 0]";
			//---
			triuaxis[0] = "[1 0 0 0]";
			triuaxis[1] = "[0 1 0 0]";
			triuaxis[2] = "[0 1 0 0]";
			triuaxis[3] = "[1 0 0 0]";
			//---
			id = 0;
		}
		
		public void setID(int id)
		{
			displacementnumber = id;
		}
		
		public int getID()
		{
			return displacementnumber;
		}
		
		public void setDispSide(int s)
		{
			dispside = s;
		}
		
		public int getResolution()
		{
			return (int)Math.Pow(2,power);
		}
		
		public float getLength()
		{
			return length;
		}
		
		public float getWidth()
		{
			return width;
		}
		
		public void setPoint(int row, int column, float xval, float yval, float zval)
		{
			try {
				xpoints[row,column] = (float)Math.Round(xval);
				ypoints[row,column] = (float)Math.Round(yval);
				zpoints[row,column] = (float)Math.Round(zval);
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public float[] getPoint(int row, int col)
		{
			try {
				float[] ret = new float[3];
				ret[0] = xpoints[row,col];
				ret[1] = ypoints[row,col];
				ret[2] = zpoints[row,col];
				return ret;
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
				return new float[3];
			}
		}
		
		public void setStandardPoints()
		{
			float res = (float)Math.Pow(2,power);
			for (int i = 0; i <= res; i++) {
				for (int j = 0; j <= res; j++) {
					this.setPoint(i,j,xstart+(width/res*(float)j),ystart+(length/res*(float)i),0);
				}
			}
		}
		
		public void setHeight(int row, int column, float zval)
		{
			try {
				zpoints[row,column] = (float)Math.Round(zval);
			}
			catch (Exception e) {
				System.Windows.Forms.MessageBox.Show("ERROR: "+e.Message,"OH NOES");
			}
		}
		
		public float getHeight(int row, int column)
		{
			return zpoints[row,column];
		}
		
		private string normalsAt(int row, int column)
		{
			// az = absolute zero
			float xaz, yaz, zaz;
			if (dispside == 3) {
				xaz = 0;
				yaz = (float)(ystart + (column * (length / (resolution - 1))));
				zaz = (float)(zstart + ((row) * (height / (resolution - 1))));
			}
			else {
				xaz = (float)(xstart + (column * (width / (resolution - 1))));
				yaz = (float)(ystart + (row * (length / (resolution - 1))));
				zaz = 0;
			}
			// ao = absolute offset
			float xao = xpoints[row,column];
			float yao = ypoints[row,column];
			float zao = zpoints[row,column];
			// ro = relative offset
			float xro = xao - xaz;
			float yro = yao - yaz;
			float zro = zao - zaz;
			// get distance
			float dist = distanceAt(row,column);
			//get normals
			float xnorm = (float)Math.Round(xro / dist,8);
			float ynorm = (float)Math.Round(yro / dist,8);
			float znorm = (float)Math.Round(zro / dist,8);
			// format normals
			string norm = xnorm + " " + ynorm + " " + znorm;
			if (norm == "NaN NaN NaN") norm = "0 0 0";
			return norm;
		}
		
		private float distanceAt(int row, int column)
		{
			// az = relative zero
			float xaz, yaz, zaz;
			if (dispside == 3) {
				xaz = 0;
				yaz = (float)(ystart + (column * (length / (resolution - 1))));
				zaz = (float)(zstart + ((row) * (height / (resolution - 1))));
			}
			else {
				xaz = (float)(xstart + (column * (width / (resolution - 1))));
				yaz = (float)(ystart + (row * (length / (resolution - 1))));
				zaz = 0;
			}
			// ao = absolute offset
			float xao = xpoints[row,column];
			float yao = ypoints[row,column];
			float zao = zpoints[row,column];
			// ro = relative offset
			float xro = xao - xaz;
			float yro = yao - yaz;
			float zro = zao - zaz;
			// get distance
			float dist = (float)Math.Sqrt(Math.Pow(xro,2) + Math.Pow(yro,2) + Math.Pow(zro,2));
			return dist;
		}
		
		private string normalsToString()
		{
			string str = "";
			str += "				normals\r\n				{\r\n";
			for (int i = 0; i < resolution; i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j < resolution; j++)
				{
					str += normalsAt(i,j) + " ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string distancesToString()
		{
			string str = "";
			str += "				distances\r\n				{\r\n";
			for (int i = 0; i < resolution; i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j < resolution; j++)
				{
					str += distanceAt(i,j) + " ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string offsetsToString()
		{
			string str = "";
			str += "				offsets\r\n				{\r\n";
			for (int i = 0; i < resolution; i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j < resolution; j++)
				{
					str += "0 0 0 ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string offsetNormalsToString()
		{
			string str = "";
			str += "				offset_normals\r\n				{\r\n";
			for (int i = 0; i < resolution; i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j < resolution; j++)
				{
					str += "0 0 1 ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string alphasToString()
		{
			string str = "";
			str += "				alphas\r\n				{\r\n";
			for (int i = 0; i < resolution; i++)
			{
				str += "					\"row" + i + "\" \"";
				for (int j = 0; j < resolution; j++)
				{
					str += "0 ";
				}
				str = str.Substring(0,str.Length-1);
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string triangleTagsToString()
		{
			string str = "";
			str += "				triangle_tags\r\n				{\r\n";
			for (int i = 0; i < resolution-1; i++)
			{
				str += "					\"row" + i + "\" \"";
				if (power == 2) str += "0 0 0 0 0 0 0 0"; 
				if (power == 3) str += "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0"; 
				if (power == 4) str += "0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0 0"; 
				str += "\"\r\n";
			}
			str += "				}\r\n";
			return str;
		}
		
		private string allowedVertsToString()
		{
			string str = "";
			str += 
				"				allowed_verts\r\n" +
				"				{\r\n" +
				"					\"10\" \"-1 -1 -1 -1 -1 -1 -1 -1 -1 -1\"\r\n" +
				"				}\r\n";
			return str;
		}
		
		private string dispToString()
		{
			string str = "";
			str +=
				"			dispinfo\r\n" +
				"			{\r\n" +
				"				\"power\" \"" + power + "\"\r\n" +
				"				\"startposition\" \"[" + xstart + " " + ystart + " " + zstart + "]\"\r\n" +
				"				\"flags\" \"0\"\r\n" +
				"				\"elevation\" \"0\"\r\n" +
				"				\"subdiv\" \"0\"\r\n" +
				normalsToString() +
				distancesToString() +
				offsetsToString() +
				offsetNormalsToString() +
				alphasToString() +
				triangleTagsToString() +
				allowedVertsToString() +
				"			}\r\n";
			return str;
		}
		
		private string sidesToString()
		{
			string str = "";
			str += "		\"id\" \"2\"\r\n";
			for (int i = 1; i <= 6; i++) {
				str +=
					"		side\r\n" +
					"		{\r\n" +
					"			\"id\" \"" + i + "\"\r\n" +
					"			\"plane\" \"" + planes[i-1] + "\"\r\n" +
					"			\"material\" \"CONCRETE/CONCRETEFLOOR005A\"\r\n" +
					"			\"uaxis\" \"" + uaxis[i-1] + " 0.25\"\r\n" +
					"			\"vaxis\" \"" + vaxis[i-1] + " 0.25\"\r\n" +
					"			\"rotation\" \"0\"\r\n" +
					"			\"lightmapscale\" \"16\"\r\n" +
					"			\"smoothing_groups\" \"0\"\r\n";
				if (i==dispside) str += dispToString();
				str +=
					"		}\r\n";
			}
			return str;
		}
		
		private float[] normalPosition(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			float[] norm = new float[3];
			
			float xcent = (xpoints[x1,y1] + xpoints[x2,y2] + xpoints[x3,y3]) / 3;
			float ycent = (ypoints[x1,y1] + ypoints[x2,y2] + ypoints[x3,y3]) / 3;
			float zcent = (zpoints[x1,y1] + zpoints[x2,y2] + zpoints[x3,y3]) / 3;
			
			float a1 = xpoints[x2,y2] - xpoints[x1,y1];
			float b1 = ypoints[x2,y2] - ypoints[x1,y1];
			float c1 = zpoints[x2,y2] - zpoints[x1,y1];
			
			float a2 = xpoints[x3,y3] - xpoints[x1,y1];
			float b2 = ypoints[x3,y3] - ypoints[x1,y1];
			float c2 = zpoints[x3,y3] - zpoints[x1,y1];
			
			float icom = (b1 * c2) - (c1 * b2);
			float jcom = ((a1 * c2) - (c1 * a2)) * -1;
			float kcom = (a1 * b2) - (b1 * a2);
			
			float vect = (float)Math.Sqrt(Math.Pow(icom,2) + Math.Pow(jcom,2) + Math.Pow(kcom,2));
			
			float xend = (float)Math.Round(xcent + (icom / vect) * 10, 2);
			float yend = (float)Math.Round(ycent + (jcom / vect) * 10, 2);
			float zend = (float)Math.Round(zcent + (kcom / vect) * 10, 2);
			
			norm[0] = xend;
			norm[1] = yend;
			norm[2] = zend;
			
			return norm;
		}
		
		private string triangleToMap(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			float[] norm = normalPosition(x1,y1,x2,y2,x3,y3);
			string pointa = "( " + (int)Math.Round(xpoints[x1,y1]) + " " + (int)Math.Round(ypoints[x1,y1]) + " " + (int)Math.Round(zpoints[x1,y1]) + " )";
			string pointb = "( " + (int)Math.Round(xpoints[x2,y2]) + " " + (int)Math.Round(ypoints[x2,y2]) + " " + (int)Math.Round(zpoints[x2,y2]) + " )";
			string pointc = "( " + (int)Math.Round(xpoints[x3,y3]) + " " + (int)Math.Round(ypoints[x3,y3]) + " " + (int)Math.Round(zpoints[x3,y3]) + " )";
			string pointd = "( " + (int)Math.Round(norm[0]) + " " + (int)Math.Round(norm[1]) + " " + (int)Math.Round(norm[2]) + " )";
			triplanes[0] = pointa + " " + pointb + " " + pointc;
			triplanes[1] = pointb + " " + pointd + " " + pointc;
			triplanes[2] = pointc + " " + pointd + " " + pointa;
			triplanes[3] = pointb + " " + pointa + " " + pointd;
			//---
			string str = "";
			str += "{\r\n";
			string mat = " NULL ";
			for (int i = 1; i <= 4; i++) {
				if (i == 1) mat = " AAATRIGGER ";
				str += triplanes[i-1] + mat + triuaxis[i-1].Replace("[","[ ").Replace("]"," ]") + " " + trivaxis[i-1].Replace("[","[ ").Replace("]"," ]") + " 0 1 1 \r\n";
				mat = " NULL ";
			}
			str += "}\r\n";
			return str;
		}
		
		private string triangleToBrush(int x1, int y1, int x2, int y2, int x3, int y3)
		{
			float[] norm = normalPosition(x1,y1,x2,y2,x3,y3);
			string pointa = "(" + (int)Math.Round(xpoints[x1,y1]) + " " + (int)Math.Round(ypoints[x1,y1]) + " " + (int)Math.Round(zpoints[x1,y1]) + ")";
			string pointb = "(" + (int)Math.Round(xpoints[x2,y2]) + " " + (int)Math.Round(ypoints[x2,y2]) + " " + (int)Math.Round(zpoints[x2,y2]) + ")";
			string pointc = "(" + (int)Math.Round(xpoints[x3,y3]) + " " + (int)Math.Round(ypoints[x3,y3]) + " " + (int)Math.Round(zpoints[x3,y3]) + ")";
			string pointd = "(" + (int)Math.Round(norm[0]) + " " + (int)Math.Round(norm[1]) + " " + (int)Math.Round(norm[2]) + ")";
			triplanes[0] = pointa + " " + pointb + " " + pointc;
			triplanes[1] = pointa + " " + pointc + " " + pointd;
			triplanes[2] = pointa + " " + pointd + " " + pointb;
			triplanes[3] = pointb + " " + pointd + " " + pointc;
			//---
			string str = "";
			id++;
			str +=
				"	solid\r\n" +
				"	{\r\n" +
				"		\"id\" \"" + id + "\"\r\n";
			for (int i = 1; i <= 4; i++) {
				id++;
				str +=
					"		side\r\n" +
					"		{\r\n" +
					"			\"id\" \"" + id + "\"\r\n" +
					"			\"plane\" \"" + triplanes[i-1] + "\"\r\n" +
					"			\"material\" \"CONCRETE/CONCRETEFLOOR005A\"\r\n" +
					"			\"uaxis\" \"" + triuaxis[i-1] + " 0.25\"\r\n" +
					"			\"vaxis\" \"" + trivaxis[i-1] + " 0.25\"\r\n" +
					"			\"rotation\" \"0\"\r\n" +
					"			\"lightmapscale\" \"16\"\r\n" +
					"			\"smoothing_groups\" \"0\"\r\n" +
					"		}\r\n";
			}
			str +=
				"		editor\r\n" +
				"		{\r\n" +
				"			\"color\" \"0 173 190\"\r\n" +
				"			\"visgroupshown\" \"1\"\r\n" +
				"			\"visgroupautoshown\" \"1\"\r\n" +
				"		}\r\n" +
				"	}\r\n";
			return str;
		}
		
		private string blocksToMap()
		{
			string str = "";
			for (int i = 0; i < reso; i++) {
				for (int j = 0; j < reso; j++) {
					str += triangleToMap(i,j,i+1,j,i+1,j+1);
					str += triangleToMap(i,j,i+1,j+1,i,j+1);
				}
			}
			return str;
		}
		
		private string blocksToBrush()
		{
			id = 1;
			string str = "";
			for (int i = 0; i < reso; i++) {
				for (int j = 0; j < reso; j++) {
					str += triangleToBrush(i,j,i+1,j,i+1,j+1);
					str += triangleToBrush(i,j,i+1,j+1,i,j+1);
				}
			}
			return str;
		}
		
		public string doABarrelRoll()
		{
			//lol
			string s = "";
			for (int i = 0; i < resolution; i++)
			{
				for (int j = 0; j < resolution; j++)
				{
					s += "(" + xpoints[i,j] + " " + ypoints[i,j] + " " + zpoints[i,j] + ") ";
					//s += distanceAt(i,j) + " ";
				}
				s += "\n";
			}
			System.Windows.Forms.MessageBox.Show(s);
			return this.toString();
		}
		
		public string toMap()
		{
			return blocksToMap();
		}
		
		public string toBrush()
		{
			return blocksToBrush();
		}
		
		public string toString()
		{
			string str = "";
			str +=
				"	solid\r\n" +
				"	{\r\n" +
				sidesToString() +
				"		editor\r\n" +
				"		{\r\n" +
				"			\"color\" \"0 173 190\"\r\n" +
				"			\"visgroupshown\" \"1\"\r\n" +
				"			\"visgroupautoshown\" \"1\"\r\n" +
				"		}\r\n" +
				"	}\r\n";
			return str;
		}
	}
}
