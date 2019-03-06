using System;
using System.IO;
using System.Reflection;
using PdfSharpCore.Fonts;

namespace FileService.Helpers
{
    public class FontResolver : IFontResolver
    {
        public string DefaultFontName => throw new NotImplementedException();

        public byte[] GetFont(string faceName)
        {
            switch (faceName)
            {
                case "segoe ui":
                    return FontHelper.Segoe;

                case "segoe ui#b":
                    return FontHelper.SegoeBold;

                case "segoe ui#i":
                    return FontHelper.SegoeItalic;

                case "segoe ui#bi":
                    return FontHelper.SegoeBoldItalic;
            }

            return null;
        }

        public FontResolverInfo ResolveTypeface(string familyName, bool isBold, bool isItalic)
        {
            var name = familyName.ToLower().TrimEnd('#');

            switch (name)
            {
                case "segoe ui":
                    if (isBold)
                    {
                        if (isItalic)
                            return new FontResolverInfo("segoe ui#bi");
                        
                        return new FontResolverInfo("segoe ui#b");
                    }
                    if (isItalic)
                        return new FontResolverInfo("segoe ui#i");
                    
                    return new FontResolverInfo("segoe ui");
            }

            return PlatformFontResolver.ResolveTypeface(familyName, isBold, isItalic);
        }
    }

    public static class FontHelper
    {
        public static byte[] Segoe
        {
            get { return LoadFontData("FileService.Fonts.SegoeUI.ttf"); }
        }

        public static byte[] SegoeItalic
        {
            get { return LoadFontData("FileService.Fonts.Segoe UI Italic.ttf"); }
        }

        public static byte[] SegoeBold
        {
            get { return LoadFontData("FileService.Fonts.Segoe UI Bold.ttf"); }
        }

        public static byte[] SegoeBoldItalic
        {
            get { return LoadFontData("FileService.Fonts.Segoe UI Bold.ttf"); }
        }

        static byte[] LoadFontData(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();

            using (Stream stream = assembly.GetManifestResourceStream(name))
            {
                if (stream == null)
                    throw new ArgumentException("No resource with name " + name);

                int count = (int)stream.Length;
                byte[] data = new byte[count];
                stream.Read(data, 0, count);
                return data;
            }
        }
    }
}
