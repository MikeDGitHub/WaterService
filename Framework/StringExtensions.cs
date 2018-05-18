using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace YuanXin.Framework
{
    public static class StringExtensions
    {
        /// <summary>
        /// 判断字符串是否为空
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNull(this string input)
        {
            return String.IsNullOrEmpty(input);
        }

        /// <summary>
        /// 验证是否是邮箱地址
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsEmail(this string input)
        {
            return Regex.IsMatch(input, @"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
        }

        /// <summary>
        /// 验证是不是URL
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsUrl(this string input)
        {
            return Regex.IsMatch(input, @"^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?$");
        }

        /// <summary>
        /// 判断是不是数字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsNumber(this string input)
        {
            return Regex.IsMatch(input, @"^[0-9]*$");
        }

        /// <summary>
        /// 判断是否合法身份证号
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsIDcard(this string input)
        {
            return Regex.IsMatch(input, @"(^\d{18}$)|(^\d{15}$)");

        }

        /// <summary>
        /// 验证是否是电话号码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsTelephone(this string input)
        {
            return Regex.IsMatch(input, @"^(\d{3,4}-)?\d{6,8}$");
        }

        /// <summary>
        /// 验证是否是手机号码
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static bool IsMobileNumber(this string input)
        {
            return Regex.IsMatch(input, @"^[1]+[0-9]+\d{9}");
        }

        /// <summary>
        /// 验证密码强度
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool PasswordComplexity(this string password)
        {
            // var regex = new Regex(@"(=.*[0-9]) (?=.*[a-zA-Z])(?=([\x21-\x7e]+)[^a-zA-Z0-9]).{6,30}", RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            var regex = new Regex(@"^.{6,16}$", RegexOptions.Multiline | RegexOptions.IgnorePatternWhitespace);
            return regex.IsMatch(password);
        }
        /// <summary>
        ///  将字符串Hash得到结果
        /// </summary>
        /// <param name="input">字符串本身</param>
        /// <returns>hash 后的字符串</returns>
        public static string GetHash(this string input)
        {
            var hashAlgorithm = IncrementalHash.CreateHash(HashAlgorithmName.SHA256);

            byte[] byteValue = System.Text.Encoding.UTF8.GetBytes(input);

            hashAlgorithm.AppendData(byteValue);
            byte[] byteHash = hashAlgorithm.GetHashAndReset();
            return Convert.ToBase64String(byteHash);
        }

        /// <summary>
        /// 将字符串转换成MD5值
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMD5(this string input)
        {
            var hasher = IncrementalHash.CreateHash(HashAlgorithmName.MD5);
            var data = new UnicodeEncoding().GetBytes(input);
            hasher.AppendData(data);
            var result = hasher.GetHashAndReset();
            return BitConverter.ToString(result);
        }
        public static string UrlEncode(this string input)
        {
            StringBuilder sb = new StringBuilder();
            byte[] byStr = Encoding.UTF8.GetBytes(input); //默认是System.Text.Encoding.Default.GetBytes(str)
            foreach (byte t in byStr)
            {
                sb.Append(@"%" + Convert.ToString(t, 16));
            }

            return sb.ToString();
        }
    }
}
