//Created By محمد تقدسی in 1387-10-8
//All Rights reserved
//This Class Puts a Bit to the LPT Port
//Mohammad.Taghadosi@Gmail.Com

using System;
using System.Runtime.InteropServices;

    class PortAccess
    {
        /// <summary>
        /// ارسال داده به پورت
        /// </summary>
        /// <param name="address">آدرس پورتی که باید به روی ان اطلاعات ریخته شود</param>
        /// <param name="value">مقدار ارسالی بر روی پورت</param>
        [DllImport("inpout32.dll", EntryPoint = "Out32")]
        public static extern void output (int address, int value);
        
        /// <summary>
        /// خواندن داده از پورت
        /// </summary>
        /// <param name="address">آدرس پورتی که داده از آن خوانده شود</param>
        /// <returns>داده ی خوانده شده را بر می گرداند</returns>
        [DllImport("inpout32.dll", EntryPoint = "Inp32")]
        public static extern int input (int address);

        /// <summary>
        /// مقدار دهدهی را به مبنای 16 تبدیل می کند
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public static string Int2Hex(int number)
        {
            string str = "";
            int _mod = 0;
            while (number > 0)
            {
                _mod = number % 16;
                switch (_mod)
                {
                    case 10: str += "A";
                        break;
                    case 11: str += "B";
                        break;
                    case 12: str += "C";
                        break;
                    case 13: str += "D";
                        break;
                    case 14: str += "E";
                        break;
                    case 15: str += "F";
                        break;
                    default:
                        str += _mod.ToString();
                        break;
                }
                number /= 16;
            }
            char[] _s = str.ToCharArray();
            Array.Reverse(_s);
            str = "0x";
            foreach (char ch in _s)
            {
                str += ch;
            }
            
            return str;
        }
    }
