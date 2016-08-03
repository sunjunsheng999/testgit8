using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Insus.NET.Utilities
{
    public class CharacterUtility
    {
        static Random _random = new Random();

        public static Char LowerAlpha
        {
            get
            {
                int num = _random.Next(0, 26);
                char c = (char)('a' + num);
                return c;
            }
        }

        public static Char UpperAlpha
        {
            get
            {
                int num = _random.Next(0, 26);
                char c = (char)('A' + num);
                return c;
            }
        }

        public static char Numeric
        {
            get
            {
                int num = _random.Next(0, 10);
                char c = (char)('0' + num);
                return c;
            }
        }

        public static char Special
        {
            get
            {
                string sc = "~!@#$%^&*?"; //你可以定义
                char c = (char)sc[_random.Next(sc.Length)];
                return c;
            }
        }

        public static string GenerateRandomString()
        {
            int length = 8;
            string randomString = "";
            bool hasSpecialCharacter = false;

            char r;
            char r1;
            char r2;

            int len = 1;
            while (len <= length)
            {
                if (len == 1) //随机首字符只能为小或大写字母
                {
                    r = (char)('0' + _random.Next(0, 2));

                    if (r == '0')
                        randomString += LowerAlpha.ToString();

                    if (r == '1')
                        randomString += LowerAlpha.ToString();
                }
                else
                {
                    if (len == length && hasSpecialCharacter == false) // 如果前七位随机数都没有产生
                                                                       // 有特殊字符，最后一次产生之      
                    {
                        randomString += Special.ToString();
                        hasSpecialCharacter = true;
                    }
                    else
                    {
                        r1 = (char)('0' + _random.Next(0, 4));

                        if (r1 == '0')
                            randomString += LowerAlpha.ToString();

                        if (r1 == '1')
                            randomString += UpperAlpha.ToString();

                        if (r1 == '2')
                            randomString += Numeric.ToString();

                        if (r1 == '3')
                        {
                            if (hasSpecialCharacter == false) //随机数中，只需要一位特殊字符
                            {
                                randomString += Special.ToString();
                                hasSpecialCharacter = true;
                            }
                            else
                            {
                                r2 = (char)('0' + _random.Next(0, 3));

                                if (r2 == '0')
                                    randomString += LowerAlpha.ToString();

                                if (r2 == '1')
                                    randomString += UpperAlpha.ToString();

                                if (r2 == '2')
                                    randomString += Numeric.ToString();
                            }
                        }

                    }
                }

                len += 1;
            }

            return randomString;
        }
    }
}