using System;
using System.IO;
using System.Reflection;

namespace HtmlLocalization
{
    public static class EmbeddedFileUtil
    {
        public static string ReadEmbeded(Assembly assembly, string resourceName)
        {
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }

        public static string ReadEmbeded(Type type, string resourceName)
        {
            return ReadEmbeded(type.Assembly, resourceName);
        }
    }
}
