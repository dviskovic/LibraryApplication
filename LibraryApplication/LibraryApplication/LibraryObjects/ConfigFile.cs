using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace LibraryApplication.LibraryObjects
{
    class ConfigFile
    {
        private static SHA512 SHA512 = SHA512.Create();
        public static byte[] Hash(string password) => SHA512.ComputeHash(Encoding.UTF8.GetBytes(password));

        public string DataLocation;

        [JsonProperty()]
        private string _Password;

        [JsonIgnore]
        public string Password
        {
            get
            {
                return _Password;
            }

            set
            {
                if (string.IsNullOrEmpty(value)) _Password = string.Empty;

                _Password = Encoding.UTF8.GetString(ConfigFile.Hash(value));
            }
        }
    }
}
