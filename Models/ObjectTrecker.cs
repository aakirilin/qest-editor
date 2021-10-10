using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;

namespace editor.Models
{
    public class ObjectTrecker
    {
        private string lastHash;

        private object observedObject
        {
            get
            {
                return selector.Invoke();
            }
        }

        private readonly Func<object> selector;

        public ObjectTrecker(Func<object> selector)
        {
            this.selector = selector;
        }

        private string HashObservedObject
        {
            get
            {
                using (System.Security.Cryptography.SHA512 SHA512 = System.Security.Cryptography.SHA512.Create())
                {
                    var json = JsonSerializer.Serialize(observedObject);
                    var bytes = Encoding.Default.GetBytes(json);
                    var hash = SHA512.ComputeHash(bytes);
                    return Convert.ToBase64String(hash);
                }
            }
        }

        public bool IsChanged
        {
            get
            {
                var newHash = HashObservedObject;
                var result =  newHash.Equals(lastHash);
                lastHash = newHash;
                return result;
            }
        }
    }
}