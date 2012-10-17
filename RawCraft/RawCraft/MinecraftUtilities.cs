using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using SharpLauncher;

namespace RawCraft
{
    public static class MinecraftUtilities
    {
        public static string LastLoginFile
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft/lastlogin");
            }
        }

        public static string DotMinecraft
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), ".minecraft");
            }
        }

        private static readonly byte[] LastLoginSalt = new byte[] { 0x0c, 0x9d, 0x4a, 0xe4, 0x1e, 0x83, 0x15, 0xfc };
        private const string LastLoginPassword = "passwordfile";
        public static LastLogin GetLastLogin()
        {
            try
            {
                byte[] encryptedLogin = File.ReadAllBytes(LastLoginFile);
                PKCSKeyGenerator crypto = new PKCSKeyGenerator(LastLoginPassword, LastLoginSalt, 5, 1);
                ICryptoTransform cryptoTransform = crypto.Decryptor;
                byte[] decrypted = cryptoTransform.TransformFinalBlock(encryptedLogin, 0, encryptedLogin.Length);
                short userLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(decrypted, 0));
                byte[] user = decrypted.Skip(2).Take(userLength).ToArray();
                short passLength = IPAddress.HostToNetworkOrder(BitConverter.ToInt16(decrypted, userLength + 2));
                byte[] password = decrypted.Skip(4 + userLength).ToArray();
                LastLogin result = new LastLogin();
                result.Username = System.Text.Encoding.UTF8.GetString(user);
                result.Password = System.Text.Encoding.UTF8.GetString(password);
                return result;
            }
            catch
            {
                return null;
            }
        }

        public static void SetLastLogin(LastLogin login)
        {
            byte[] decrypted = BitConverter.GetBytes(IPAddress.NetworkToHostOrder((short)login.Username.Length))
                .Concat(System.Text.Encoding.UTF8.GetBytes(login.Username))
                .Concat(BitConverter.GetBytes(IPAddress.NetworkToHostOrder((short)login.Password.Length)))
                .Concat(System.Text.Encoding.UTF8.GetBytes(login.Password)).ToArray();

            PKCSKeyGenerator crypto = new PKCSKeyGenerator(LastLoginPassword, LastLoginSalt, 5, 1);
            ICryptoTransform cryptoTransform = crypto.Encryptor;
            byte[] encrypted = cryptoTransform.TransformFinalBlock(decrypted, 0, decrypted.Length);
            if (File.Exists(LastLoginFile))
                File.Delete(LastLoginFile);
            using (Stream stream = File.Create(LastLoginFile))
                stream.Write(encrypted, 0, encrypted.Length);
        }
    }

    public class LastLogin
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class Session
    {
        public Session(string Error)
        {
            this.Error = Error;
        }

        public Session(string Username, string SessionID)
        {
            this.Username = Username;
            this.SessionID = SessionID;
        }

        public Session(string Username, string SessionID, string Version)
            : this(Username, SessionID)
        {
            this.Version = Version;
        }

        public string Username { get; set; }
        public string SessionID { get; set; }
        public string Version { get; set; }
        public string Error { get; set; }
    }

    public class FileDownload
    {
        public FileDownload()
        {
        }

        public FileDownload(Uri DownloadUri, string Destination)
        {
            this.DownloadUri = DownloadUri;
            this.Destination = Destination;
        }

        public Uri DownloadUri { get; set; }
        public string Destination { get; set; }
        public int Size { get; set; }
    }
}