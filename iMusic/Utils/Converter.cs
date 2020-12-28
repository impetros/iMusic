using System;
namespace iMusic.Utils
{
    public class Converter
    {
        public static string GetStringFromByteArray(Byte[] buffer)
        {
            if (buffer == null) return String.Empty;
            return System.Text.Encoding.UTF8.GetString(buffer, 0, buffer.Length);
        }

        public static Byte[] GetByteArrayFromString(string convert)
        {
            if (String.IsNullOrEmpty(convert)) return null;
            return System.Text.Encoding.UTF8.GetBytes(convert);
        }
    }
}
