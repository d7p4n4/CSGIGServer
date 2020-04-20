using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CSGIGServer
{
    class Generator
    {
        public string GuidGenerator()
        {
            return BitConverter.ToString(new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(Guid.NewGuid().ToString()))).Replace("-", String.Empty);

        }

        public int CheckDataGenerator()
        {
            return new Random().Next(0, 10000000);
        }
    }
}
