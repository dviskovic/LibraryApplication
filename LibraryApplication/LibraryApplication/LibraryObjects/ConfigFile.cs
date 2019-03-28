using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace LibraryApplication.LibraryObjects
{
    public class ConfigFile
    {
        public static byte[] Hash(string password) => SHA512.ComputeHash(Encoding.UTF8.GetBytes(password));

        public string DataLocation;

        public double LateFee;

        private static SHA512 SHA512 = SHA512.Create();

        [JsonProperty]
        private string _password;

        [JsonIgnore]
        public string Password
        {
            get
            {
                return this._password;
            }

            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    this._password = string.Empty;
                }

                this._password = Encoding.UTF8.GetString(ConfigFile.Hash(value));
            }
        }
    }
}
