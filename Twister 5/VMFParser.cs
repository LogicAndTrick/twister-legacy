/*
 * Created by SharpDevelop.
 * User: Dan
 * Date: 31/07/2008
 * Time: 8:35 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Text.RegularExpressions;

namespace Twister_5
{
	/// <summary>
	/// Description of VMFParser.
	/// </summary>
	public class VMFParser
	{
		string content;
		
		public VMFParser(string s)
		{
			content = s;
		}
		
		//Function to count no.of occurences of Substring in string
		public static int CharCount(String strSource,String strToCount)
		{
			int iCount=0;
			int iPos=strSource.IndexOf(strToCount);
			while(iPos!=-1)
			{
				iCount++;
				strSource=strSource.Substring(iPos+1);
				iPos=strSource.IndexOf(strToCount);
			}
			return iCount;
		}
		
		private Map parse()
		{
			Map m = new Map();
			//System.Windows.Forms.MessageBox.Show("debug");
			string match;
			Regex regexObj = new Regex(@"solid(?:.*?)\{((?:(?:.*?)side(?:.*?)\{(?:.*?)\})*?(?:.*?)editor(?:.*?)\{(?:.*?)\}(?:.*?))\}", RegexOptions.Singleline);
			Match matchResults = regexObj.Match(content);
			while (matchResults.Success) {
				match = matchResults.Value;
				Group g = matchResults.Groups[1];
				if (g.Success) match = g.Value;
				int sidenum = CharCount(match,"side");
				Brush bsh = new Brush(sidenum);
				Regex cofind = new Regex(@"\(([^ ]+?) ([^ ]+?) ([^ ]+?)\)", RegexOptions.Singleline);
				Match comatch = cofind.Match(match);
				while (comatch.Success) {
					Coordinate co1 = new Coordinate(float.Parse(comatch.Groups[1].Value),float.Parse(comatch.Groups[2].Value),float.Parse(comatch.Groups[3].Value));
					bsh.addCorner(co1);
					comatch = comatch.NextMatch();
				}
				Regex re = new Regex(string.Format("{0}(?>[^{0}{1}]+|{0} (?<Depth>)|{1} (?<-Depth>))*(?(Depth)(?!)){1}", "\\{", "\\}"),System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace);
				Match matc = re.Match(match);
				while (matc.Success) {
					//do something with the side (more regexes)
					string side = matc.Value;
					if (side.Contains("color")) break;
					//get the id
					int id = int.Parse(Regex.Match(side, "\"id\" \"(.+?)\"", RegexOptions.Singleline).Groups[1].Value);
					//get the three plane coordinates
					Match planematch = Regex.Match(side, @"\""plane\"" \""\(([^ ]+?) ([^ ]+?) ([^ ]+?)\) \(([^ ]+?) ([^ ]+?) ([^ ]+?)\) \(([^ ]+?) ([^ ]+?) ([^ ]+?)\)\""", RegexOptions.Singleline);
					Coordinate p1 = new Coordinate(float.Parse(planematch.Groups[1].Value),float.Parse(planematch.Groups[2].Value),float.Parse(planematch.Groups[3].Value));
					Coordinate p2 = new Coordinate(float.Parse(planematch.Groups[4].Value),float.Parse(planematch.Groups[5].Value),float.Parse(planematch.Groups[6].Value));
					Coordinate p3 = new Coordinate(float.Parse(planematch.Groups[7].Value),float.Parse(planematch.Groups[8].Value),float.Parse(planematch.Groups[9].Value));
					Plane sideplane = new Plane(p1,p2,p3);
					//get the material
					string material = Regex.Match(side, "\"material\" \"(.+?)\"", RegexOptions.Singleline).Groups[1].Value;
					//get the uaxis and scale
					Match uaxismatch = Regex.Match(side, @"\""uaxis\"" \""\[(.+?) (.+?) (.+?) (.+?)\] (.+?)\""", RegexOptions.Singleline);
					Vector4 uaxis = new Vector4();
					for (int i = 0; i < 3; i++) uaxis.setValue(i,float.Parse(uaxismatch.Groups[i+1].Value));
					float uscale = float.Parse(uaxismatch.Groups[5].Value);
					//get the vaxis and scale
					Match vaxismatch = Regex.Match(side, @"\""vaxis\"" \""\[(.+?) (.+?) (.+?) (.+?)\] (.+?)\""", RegexOptions.Singleline);
					Vector4 vaxis = new Vector4();
					for (int i = 0; i < 3; i++) vaxis.setValue(i,float.Parse(vaxismatch.Groups[i+1].Value));
					float vscale = float.Parse(vaxismatch.Groups[5].Value);
					//get the rotation
					float rotation = float.Parse(Regex.Match(side, "\"rotation\" \"(.+?)\"", RegexOptions.Singleline).Groups[1].Value);
					//get the lightmapscale
					int lightmapscale = int.Parse(Regex.Match(side, "\"lightmapscale\" \"(.+?)\"", RegexOptions.Singleline).Groups[1].Value);
					//get the smoothing groups
					int smoothinggroups = int.Parse(Regex.Match(side, "\"smoothing_groups\" \"(.+?)\"", RegexOptions.Singleline).Groups[1].Value);
					//get the dispinfo
					bool isdisp = false;
					int power = 0;
					Coordinate startpos = null;
					int elevation = 0;
					int subdiv = 0;
					string normals = "";
					string distances = "";
					string offset = "";
					string offsetnormals = "";
					string alphas = "";
					string tritags = "";
					Match dispinfo = Regex.Match(side, @"dispinfo.+?\{.+?""power"" ""(2|3|4)"".+?""startposition"" ""\[([^ ]+?) ([^ ]+?) ([^ ]+?)\]"".+?""elevation"" ""(.+?)"".+?""subdiv"" ""(.+?)"".+?normals.+?\{(.+?)\}.+?distances.+?\{(.+?)\}.+?offsets.+?\{(.+?)\}.+?offset_normals.+?\{(.+?)\}.+?alphas.+?\{(.+?)\}.+?triangle_tags.+?\{(.+?)\}.+?allowed_verts.+?\{(.+?)\}.+?\}", RegexOptions.Singleline);
					if (dispinfo.Success)
					{
						//we have a displacement
						isdisp = true;
						//get the power
						power = int.Parse(dispinfo.Groups[1].Value);
						//get the start position
						startpos = new Coordinate(float.Parse(dispinfo.Groups[2].Value),float.Parse(dispinfo.Groups[3].Value),float.Parse(dispinfo.Groups[4].Value));
						//get the elevation
						elevation = int.Parse(dispinfo.Groups[5].Value);
						//get the subdiv
						subdiv = int.Parse(dispinfo.Groups[6].Value);
						//get the normals
						normals = dispinfo.Groups[7].Value;
						//get the distances
						distances = dispinfo.Groups[8].Value;
						//get the offsets
						offset = dispinfo.Groups[9].Value;
						//get the offset normals
						offsetnormals = dispinfo.Groups[10].Value;
						//get the alphas
						alphas = dispinfo.Groups[11].Value;
						//get the triangle tags
						tritags = dispinfo.Groups[12].Value;
					}
					Side s;
					if (isdisp) s = new Disp(power,startpos);
					else s = new Side();
					//set side properties (must be set first)
					s.setPlane(sideplane);
					s.setMaterial(material);
					s.setUAxis(uaxis);
					s.setUScale(uscale);
					s.setVAxis(vaxis);
					s.setVScale(vscale);
					s.setRotation(rotation);
					s.setLightmapScale(lightmapscale);
					s.setSmoothingGroups(smoothinggroups);
					//set disp properties, if side is a disp
					if (isdisp) {
						//we need to get the 4th point of the displacement.
						//theoretically it would have to be calculated from the planes, but
						//luckily we should have the point SOMEWHERE because of how hammer saves.
						//If we don't, TFB. for now.
						System.Collections.Generic.List<Coordinate> brushcorners = bsh.getCorners();
						Coordinate fourthcorner = null;
						//start search
						foreach (Coordinate c in brushcorners.ToArray()) {
							if (!sideplane.containsCorner(c))
							{
								//plane doesn't already have this corner
								//is it on the plane?
								//if so, we have found the corner we are looking for
								if (Math.Abs(sideplane.onPlane(c)) < 1000) { //FIXME: this is a massive bug leak.
									fourthcorner = c;
									break;
								}
							}
						}
						if (fourthcorner == null)
						{
							//oh dear, we haven't found it.
							//let's kill this map.
							m.fail();
							//am i dooming myself here? how many people will this fail for?
							System.Windows.Forms.MessageBox.Show("There has been an error in loading a displacement. Please send this VMF to me.","OH NOES");
							matc = matc.NextMatch();
							break;
						}
						//else, we have an additional corner! yay.
						((Disp)s).addLastCorner(fourthcorner);
						//end search
						//now we start setting displacement-specific properties, since we have such an awesome side
						((Disp)s).setElevation(elevation);
						((Disp)s).setSubdiv(subdiv);
						//process all normals
						//process all distances
						//okay, we're about to start a shortcut that absolutely NEEDS the displacement syntax
						//to be EXTREMELY MEGA valid. otherwise we'll get a crash.
						//NOTE: the exceptions aren't caught, be very wary of this.
						//TODO: add support for malformed displacements.
						Regex rowmatcher = new Regex("\"row([0-9]{1,2})\" \"(.*?)\"", RegexOptions.Singleline);
						Match rownorms = rowmatcher.Match(normals);
						Match rowdists = rowmatcher.Match(distances);
						Match rowoffs = rowmatcher.Match(offset);
						Match rowoffnorms = rowmatcher.Match(offsetnormals);
						//wait, we probably bypassed it. yay :)
						while (rownorms.Success && rowdists.Success) {
							//no counter nescessary! the row is already given.
							//i suppose now we can parse VMFs with out of order rows? yay?
							int rownum = int.Parse(rownorms.Groups[1].Value);
							string normstr = rownorms.Groups[2].Value;
							string diststr = rowdists.Groups[2].Value;
							string offstr = rowoffs.Groups[2].Value;
							string offnormstr = rowoffnorms.Groups[2].Value;
							//now we have the indivual values for a row.
							//let's match the 3 normals to the one distance,
							//then give to the displacement for processing.
							Regex normals3 = new Regex("([^ ]+) ([^ ]+) ([^ ]+)", RegexOptions.Singleline);
							Match norm3 = normals3.Match(normstr);
							Regex distances3 = new Regex("([^ ]+)", RegexOptions.Singleline);
							Match dist3 = distances3.Match(diststr);
							Regex offsets3 = new Regex("([^ ]+) ([^ ]+) ([^ ]+)", RegexOptions.Singleline);
							Match offs3 = offsets3.Match(offstr);
							Regex offsetnormals3 = new Regex("([^ ]+) ([^ ]+) ([^ ]+)", RegexOptions.Singleline);
							Match offnorm3 = offsetnormals3.Match(offnormstr);
							int column = 0;
							while (norm3.Success && dist3.Success && offs3.Success && offnorm3.Success) {
								//get the normals from the original values, as well as the offset values
								float xnorm = float.Parse(norm3.Groups[1].Value);
								float ynorm = float.Parse(norm3.Groups[2].Value);
								float znorm = float.Parse(norm3.Groups[3].Value);
								float xnormoff = float.Parse(offnorm3.Groups[1].Value);
								float ynormoff = float.Parse(offnorm3.Groups[2].Value);
								float znormoff = float.Parse(offnorm3.Groups[3].Value);
								//throw the 3 normals into an arbitrary data structure
								float[] pointnorms = {xnorm,ynorm,znorm};
								float[] pointnormoffs = {xnormoff,ynormoff,znormoff};
								//we also have the distance
								float pointdist = float.Parse(dist3.Groups[1].Value);
								//System.Windows.Forms.MessageBox.Show("row"+rownum.ToString()+",col"+column.ToString()+": "+pointdist);
								//now all we have to do is supply these two pieces of data,
								//along with the row and column numbers, to the displacement object.
								((Disp)s).vectorToSetPoint(rownum,column,pointdist,pointnorms,pointnormoffs);
								//finally we add the offsets to the points
								float xoff = float.Parse(offs3.Groups[1].Value);
								float yoff = float.Parse(offs3.Groups[2].Value);
								float zoff = float.Parse(offs3.Groups[3].Value);
								((Disp)s).addToPoint(rownum,column,new Coordinate(xoff,yoff,zoff));
								//then go along one column
								column++;
								norm3 = norm3.NextMatch();
								dist3 = dist3.NextMatch();
								offs3 = offs3.NextMatch();
								offnorm3 = offnorm3.NextMatch();
							}
							rownorms = rownorms.NextMatch();
							rowdists = rowdists.NextMatch();
							rowoffs = rowoffs.NextMatch();
							rowoffnorms = rowoffnorms.NextMatch();
						}
						//TODO: process all alphas
						//TODO: process all tritags
						//convert displacement now for testing
						((Disp)s).toBrush(ref m);
					}
					bsh.addSide(s);
					//end
					matc = matc.NextMatch();
				}
				m.addBrush(bsh);
				matchResults = matchResults.NextMatch();
			}
			return m;
		}
		
		public Map toMap()
		{
			return parse();
		}
	}
}
