using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;
using System.Runtime.InteropServices;

// Source: http://download.csdn.net/download/laviewpbt/4900954
// Author: http://download.csdn.net/user/laviewpbt

namespace PrimeLib
{
    public enum DitherType
    {
        DitherTypeNone = 0,
        DitherTypeSolid = 1,
        DitherTypeOrdered4x4 = 2,
        DitherTypeOrdered8x8 = 3,
        DitherTypeOrdered16x16 = 4,
        DitherTypeSpiral4x4 = 5,
        DitherTypeSpiral8x8 = 6,
        DitherTypeDualSpiral4x4 = 7,
        DitherTypeDualSpiral8x8 = 8,
        DitherTypeErrorDiffusion = 9,
        DitherTypeMax = 10
    }
    public enum PaletteType
    {
        PaletteTypeCustom = 0,
        PaletteTypeOptimal = 1,
        PaletteTypeFixedBW = 2,
        PaletteTypeFixedHalftone8 = 3,
        PaletteTypeFixedHalftone27 = 4,
        PaletteTypeFixedHalftone64 = 5,
        PaletteTypeFixedHalftone125 = 6,
        PaletteTypeFixedHalftone216 = 7,
        PaletteTypeFixedHalftone252 = 8,
        PaletteTypeFixedHalftone256 = 9
    }

    public static class GdipEffect
    {
        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int GdipInitializePalette(ref GdiPalette Pal, int palettetype, int optimalColors,
            int useTransparentColor, IntPtr bitmap);

        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int GdipInitializePalette(int[] Pal, PaletteType palettetype, int optimalColors,
            int useTransparentColor, IntPtr bitmap);

        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int GdipBitmapConvertFormat(IntPtr bitmap, int pixelFormat, DitherType dithertype,
            PaletteType palettetype, ref GdiPalette Pal, float alphaThresholdPercent);

        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int GdipBitmapConvertFormat(IntPtr bitmap, int pixelFormat, DitherType dithertype,
            PaletteType palettetype, int[] Pal, float alphaThresholdPercent);

        [DllImport("gdiplus.dll", SetLastError = true, ExactSpelling = true, CharSet = CharSet.Unicode)]
        private static extern int GdipBitmapConvertFormat(IntPtr bitmap, int pixelFormat, DitherType dithertype,
            PaletteType palettetype, IntPtr Pal, float alphaThresholdPercent);

        public static void ChangeTo8bppIndexed(this Bitmap Bmp, PaletteType palettetype = PaletteType.PaletteTypeOptimal,
            DitherType ditherType = DitherType.DitherTypeErrorDiffusion, int optimalColors = 256)
        {
            int Entries;
            // http://msdn.microsoft.com/en-us/library/ms534159(v=vs.85).aspx
            switch (palettetype)
            {
                case PaletteType.PaletteTypeFixedBW:
                    Entries = 2;
                    break;
                case PaletteType.PaletteTypeFixedHalftone8:
                    Entries = 16;
                    break;
                case PaletteType.PaletteTypeFixedHalftone27:
                    Entries = 36;
                    break;
                case PaletteType.PaletteTypeFixedHalftone64:
                    Entries = 73;
                    break;
                case PaletteType.PaletteTypeFixedHalftone125:
                    Entries = 134;
                    break;
                case PaletteType.PaletteTypeFixedHalftone216:
                    Entries = 225;
                    break;
                case PaletteType.PaletteTypeFixedHalftone252:
                    Entries = 253;
                    break;
                case PaletteType.PaletteTypeFixedHalftone256:
                    Entries = 256;
                    break;
                case PaletteType.PaletteTypeOptimal:
                    if (optimalColors <= 0 || optimalColors > 256)
                        throw new ArgumentOutOfRangeException(
                            "Colors should be between 0 (inclusive) and 256 (exclusive)");
                    Entries = optimalColors;
                    break;
                default:
                    throw new ArgumentException("Error");
            }
            var Pal = new int[2 + Entries];
            Pal[0] = (int) PaletteFlags.GrayScale; // Flag
            Pal[1] = Entries; // Count
            if (palettetype == PaletteType.PaletteTypeOptimal)
                GdipInitializePalette(Pal, palettetype, Entries, 0, Bmp.NativeHandle());
            else
                GdipInitializePalette(Pal, palettetype, Entries, 0, IntPtr.Zero);
            if (palettetype == PaletteType.PaletteTypeOptimal)
                if (ditherType != DitherType.DitherTypeNone && ditherType != DitherType.DitherTypeSolid &&
                    ditherType != DitherType.DitherTypeErrorDiffusion)
                    throw new ArgumentException("Arguments error");
            GdipBitmapConvertFormat(Bmp.NativeHandle(), Convert.ToInt32(PixelFormat.Format8bppIndexed), ditherType,
                palettetype, Pal, 50f);
        }

        public static void ChangeToSpecialIndexed(this Bitmap Bmp, PaletteType palettetype = PaletteType.PaletteTypeOptimal,
           DitherType ditherType = DitherType.DitherTypeErrorDiffusion, int optimalColors = 256)
        {
            int Entries;
            // http://msdn.microsoft.com/en-us/library/ms534159(v=vs.85).aspx
            switch (palettetype)
            {
                case PaletteType.PaletteTypeFixedBW:
                    Entries = 2;
                    break;
                case PaletteType.PaletteTypeFixedHalftone8:
                    Entries = 16;
                    break;
                case PaletteType.PaletteTypeFixedHalftone27:
                    Entries = 36;
                    break;
                case PaletteType.PaletteTypeFixedHalftone64:
                    Entries = 73;
                    break;
                case PaletteType.PaletteTypeFixedHalftone125:
                    Entries = 134;
                    break;
                case PaletteType.PaletteTypeFixedHalftone216:
                    Entries = 225;
                    break;
                case PaletteType.PaletteTypeFixedHalftone252:
                    Entries = 253;
                    break;
                case PaletteType.PaletteTypeFixedHalftone256:
                    Entries = 256;
                    break;
                case PaletteType.PaletteTypeOptimal:
                    if (optimalColors <= 0 || optimalColors > 256)
                        throw new ArgumentOutOfRangeException(
                            "Colors should be between 0 (inclusive) and 256 (exclusive)");
                    Entries = optimalColors;
                    break;
                default:
                    throw new ArgumentException("Error");
            }
            var Pal = new int[2 + Entries];
            Pal[0] = (int)PaletteFlags.GrayScale; // Flag
            Pal[1] = Entries; // Count
            if (palettetype == PaletteType.PaletteTypeOptimal)
                GdipInitializePalette(Pal, palettetype, Entries, 0, Bmp.NativeHandle());
            else
                GdipInitializePalette(Pal, palettetype, Entries, 0, IntPtr.Zero);
            if (palettetype == PaletteType.PaletteTypeOptimal)
                if (ditherType != DitherType.DitherTypeNone && ditherType != DitherType.DitherTypeSolid &&
                    ditherType != DitherType.DitherTypeErrorDiffusion)
                    throw new ArgumentException("Arguments error");
            GdipBitmapConvertFormat(Bmp.NativeHandle(), Convert.ToInt32(PixelFormat.Format16bppArgb1555), ditherType,
                palettetype, Pal, 50f);
        }

        public static void ChangeTo4bppIndexed(this Bitmap Bmp, PaletteType palettetype = PaletteType.PaletteTypeOptimal,
            DitherType ditherType = DitherType.DitherTypeErrorDiffusion, int optimalColors = 16)
        {
            int Entries;
            // http://msdn.microsoft.com/en-us/library/ms534159(v=vs.85).aspx
            switch (palettetype)
            {
                case PaletteType.PaletteTypeFixedBW:
                    Entries = 2;
                    break;
                case PaletteType.PaletteTypeFixedHalftone8:
                    Entries = 16;
                    break;
                case PaletteType.PaletteTypeOptimal:
                    if (optimalColors <= 0 || optimalColors > 16)
                        throw new ArgumentOutOfRangeException("Colors should be between 0 (inclusive) and 16 (exclusive)");
                    Entries = optimalColors;
                    break;
                default:
                    throw new ArgumentException("Error");
            }
            var Pal = new int[2 + Entries];
            Pal[0] = (int) PaletteFlags.GrayScale; // Flag
            Pal[1] = Entries; // Count
            if (palettetype == PaletteType.PaletteTypeOptimal)
                GdipInitializePalette(Pal, palettetype, Entries, 0, Bmp.NativeHandle());
            else
                GdipInitializePalette(Pal, palettetype, Entries, 0, IntPtr.Zero);
            if (palettetype == PaletteType.PaletteTypeOptimal)
                if (ditherType != DitherType.DitherTypeNone && ditherType != DitherType.DitherTypeSolid &&
                    ditherType != DitherType.DitherTypeErrorDiffusion)
                    throw new ArgumentException("Arguments error");
            GdipBitmapConvertFormat(Bmp.NativeHandle(), Convert.ToInt32(PixelFormat.Format4bppIndexed), ditherType,
                palettetype, Pal, 50f);
        }

        public static void ChangeTo1bppIndexed(this Bitmap Bmp,
            DitherType ditherType = DitherType.DitherTypeErrorDiffusion)
        {
            if (ditherType != DitherType.DitherTypeSolid && ditherType != DitherType.DitherTypeErrorDiffusion)
                throw new ArgumentException("Arguments error.");
            var Pal = new int[4];
            Pal[0] = (int) PaletteFlags.GrayScale; // Flag
            Pal[1] = 2; // Count
            GdipInitializePalette(Pal, PaletteType.PaletteTypeFixedBW, 2, 0, IntPtr.Zero);
            GdipBitmapConvertFormat(Bmp.NativeHandle(), Convert.ToInt32(PixelFormat.Format1bppIndexed), ditherType,
                PaletteType.PaletteTypeFixedBW, Pal, 50f);
        }

        public static void ChangeTo16bppRgb555(this Bitmap Bmp,
            DitherType ditherType = DitherType.DitherTypeErrorDiffusion)
        {
            GdipBitmapConvertFormat(Bmp.NativeHandle(), Convert.ToInt32(PixelFormat.Format16bppRgb555), ditherType,
                PaletteType.PaletteTypeCustom, IntPtr.Zero, 50f);
        }

        public static void ChangeTo24bppRgb(this Bitmap Bmp)
        {
            GdipBitmapConvertFormat(Bmp.NativeHandle(), Convert.ToInt32(PixelFormat.Format24bppRgb),
                DitherType.DitherTypeNone, PaletteType.PaletteTypeCustom, IntPtr.Zero, 50f);
        }

        public static void ChangeTo32bppARGB(this Bitmap Bmp)
        {
            GdipBitmapConvertFormat(Bmp.NativeHandle(), Convert.ToInt32(PixelFormat.Format32bppArgb),
                DitherType.DitherTypeNone, PaletteType.PaletteTypeCustom, IntPtr.Zero, 50f);
        }

        internal static TResult GetPrivateField<TResult>(this object obj, string fieldName)
        {
            if (obj == null) return default(TResult);
            Type ltType = obj.GetType();
            FieldInfo lfiFieldInfo = ltType.GetField(fieldName,
                BindingFlags.GetField | BindingFlags.Instance | BindingFlags.NonPublic);
            if (lfiFieldInfo != null)
                return (TResult) lfiFieldInfo.GetValue(obj);
            throw new InvalidOperationException(
                string.Format("Instance field '{0}' could not be located in object of type '{1}'.", fieldName,
                    obj.GetType().FullName));
        }

        public static IntPtr NativeHandle(this Bitmap Bmp)
        {
            return Bmp.GetPrivateField<IntPtr>("nativeImage");
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct GdiPalette
        {
            internal readonly PaletteFlags Flag;
            internal readonly int Count;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1024)] internal readonly byte[] Entries;
        }
    }
}