﻿#region --- License ---
/* Licensed under the MIT/X11 license.
 * Copyright (c) 2006-2008 the OpenTK team.
 * This notice may not be removed.
 * See license.txt for licensing detailed licensing details.
 */
#endregion

using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace OpenTK.Graphics
{
    /// <summary>Contains information regarding a monitor's display resolution.</summary>
    public class DisplayResolution
    {
        int width, height;
        int bits_per_pixel;
        float refresh_rate;

        #region --- Constructors ---

        #region public DisplayResolution(int width, int height, int bitsPerPixel, float refreshRate)

        /// <summary>
        /// Creates a new DisplayResolution object for the primary DisplayDevice.
        /// </summary>
        /// <param name="width">The requested width in pixels.</param>
        /// <param name="height">The requested height in pixels.</param>
        /// <param name="bitsPerPixel">The requested bits per pixel in bits.</param>
        /// <param name="refreshRate">The requested refresh rate in Herz.</param>
        /// <remarks>OpenTK will select the closest match between all available resolutions on the primary DisplayDevice.</remarks>
        internal DisplayResolution(int width, int height, int bitsPerPixel, float refreshRate)
        {
            // Refresh rate may be zero, since this information may not be available on some platforms.
            if (width <= 0) throw new ArgumentOutOfRangeException("width", "Must be greater than zero.");
            if (height <= 0) throw new ArgumentOutOfRangeException("height", "Must be greater than zero.");
            if (bitsPerPixel <= 0) throw new ArgumentOutOfRangeException("bitsPerPixel", "Must be greater than zero.");
            if (refreshRate < 0) throw new ArgumentOutOfRangeException("refreshRate", "Must be greater than, or equal to zero.");

            this.width = width;
            this.height = height;
            this.bits_per_pixel = bitsPerPixel;
            this.refresh_rate = refreshRate;
        }

        #endregion

        #region public DisplayResolution(int width, int height, int bitsPerPixel, float refreshRate, DisplayDevice device)

#if false

        /// <summary>
        /// Creates a new DisplayResolution object for the specified DisplayDevice.
        /// </summary>
        /// <param name="width">The requested width in pixels.</param>
        /// <param name="height">The requested height in pixels.</param>
        /// <param name="bitsPerPixel">The requested bits per pixel in bits.</param>
        /// <param name="refreshRate">The requested refresh rate in Herz.</param>
        /// <remarks>OpenTK will select the closest match between all available resolutions on the specified DisplayDevice.</remarks>
        /// 
        public DisplayResolution(int width, int height, int bitsPerPixel, float refreshRate, DisplayDevice device)
        {
            // Refresh rate may be zero, since this information may not be available on some platforms.
            if (width <= 0) throw new ArgumentOutOfRangeException("width", "Must be greater than zero.");
            if (height <= 0) throw new ArgumentOutOfRangeException("height", "Must be greater than zero.");
            if (bitsPerPixel <= 0) throw new ArgumentOutOfRangeException("bitsPerPixel", "Must be greater than zero.");
            if (refreshRate < 0) throw new ArgumentOutOfRangeException("refreshRate", "Must be greater than, or equal to zero.");
            if (device == null) throw new ArgumentNullException("DisplayDevice", "Must be a valid DisplayDevice");

            DisplayResolution res = device.SelectResolution(width, height, bitsPerPixel, refreshRate);

            this.width = res.width;
            this.height = res.height;
            this.bits_per_pixel = res.bits_per_pixel;
            this.refresh_rate = res.refresh_rate;
        }
#endif
        #endregion

        #endregion

        #region --- Public Methods ---

        #region public int Width

        /// <summary>Gets a System.Int32 that contains the width of this display in pixels.</summary>
        public int Width { get { return width; } }

        #endregion

        #region public int Height

        /// <summary>Gets a System.Int32 that contains the height of this display in pixels.</summary>
        public int Height { get { return height; } }

        #endregion

        #region public int BitsPerPixel

        /// <summary>Gets a System.Int32 that contains number of bits per pixel of this display. Typical values include 8, 16, 24 and 32.</summary>
        public int BitsPerPixel { get { return bits_per_pixel; } }

        #endregion

        #region public float RefreshRate

        /// <summary>
        /// Gets a System.Single representing the vertical refresh rate of this display.
        /// </summary>
        public float RefreshRate
        {
            get { return refresh_rate; }
        }

        #endregion

        #endregion

        #region --- Overrides ---

        #region public override string ToString()

        /// <summary>
        /// Returns a System.String representing this DisplayResolution.
        /// </summary>
        /// <returns>A System.String representing this DisplayResolution.</returns>
        public override string ToString()
        {
            return String.Format("{0}x{1}x{2}@{3}Hz", width, height, bits_per_pixel, refresh_rate);
        }

        #endregion

        #region public override bool Equals(object obj)

        /// <summary>Determines whether the specified resolutions are equal.</summary>
        /// <param name="obj">The System.Object to check against.</param>
        /// <returns>True if the System.Object is an equal DisplayResolution; false otherwise.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (this.GetType() == obj.GetType())
            {
                DisplayResolution res = (DisplayResolution)obj;
                return
                    Width == res.Width &&
                    Height == res.Height &&
                    BitsPerPixel == res.BitsPerPixel &&
                    RefreshRate == res.RefreshRate;
            }

            return false;
        }

        #endregion

        #region public override int GetHashCode()

        /// <summary>Returns a unique hash representing this resolution.</summary>
        /// <returns>A System.Int32 that may serve as a hash code for this resolution.</returns>
        public override int GetHashCode()
        {
            return width ^ height ^ bits_per_pixel ^ (int)refresh_rate;
        }

        #endregion

        #endregion

        #region --- Operator Overloads ---

        public static bool operator== (DisplayResolution left, DisplayResolution right)
        {
            if (((object)left) == null && ((object)right) == null)
                return true;
            else if ((((object)left) == null && ((object)right) != null) ||
                     (((object)left) != null && ((object)right) == null))
                return false;
            return left.Equals(right);
        }

        public static bool operator !=(DisplayResolution left, DisplayResolution right)
        {
            return !(left == right);
        }

        #endregion
    }
}
