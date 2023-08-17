using System.Security.Cryptography;

namespace TerraVillageAPI.Utils
{
    public static class SecretKeyGenerator
    {
        public static byte[] GenerateRandomSecretKey(int keySizeInBytes)
        {

            byte[] secretKey = new byte[keySizeInBytes];

            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(secretKey);
            }

            return secretKey;
        }
    }
}
