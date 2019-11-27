using System;
using System.Security.Cryptography;
using System.Text;

namespace BangBangFuli.H5.API.Core.Utils
{
    public static class Extension
    {
        public static bool YNConvert(this string obj)
        {
            return !string.IsNullOrEmpty(obj) && obj.Equals(AppConst.YNStruct.Yes, StringComparison.OrdinalIgnoreCase);
        }

        public static string YNConvert(this bool obj)
        {
            return obj ? AppConst.YNStruct.Yes : AppConst.YNStruct.No;
        }

        public static string AsString(this string obj)
        {
            return string.IsNullOrWhiteSpace(obj) ? string.Empty : obj;
        }

        public static string MD5Encrypt(this string obj)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            byte[] hashedDataBytes = md5Hasher.ComputeHash(Encoding.GetEncoding("gb2312").GetBytes(obj));

            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte i in hashedDataBytes)
            {
                stringBuilder.Append(i.ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
