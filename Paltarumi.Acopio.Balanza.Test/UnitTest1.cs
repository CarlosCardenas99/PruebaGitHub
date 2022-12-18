using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Security.Cryptography;
using System.Text;
using System;
using System.IO;

namespace Paltarumi.Acopio.Balanza.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                //Create a UnicodeEncoder to convert between byte array and string.
                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                //Create byte arrays to hold original, encrypted, and decrypted data.
                var dataToEncrypt =  "0123456789";

                var data = Encoding.UTF8.GetBytes(dataToEncrypt);
                var salt = new byte[] { 0, 1, 3};
                var iv = new byte[] { 0, 1, 3, 4, 0, 1, 3, 4, 0, 1, 3, 4, 0, 1, 3, 4 };

                var en = encript(dataToEncrypt);
                var enc = Encrypt(data, "V3CTor", salt, iv);
                var verenc = Convert.ToBase64String(enc);

                Console.WriteLine("Decrypted plaintext: {0}", en);

            }
            catch (ArgumentNullException)
            {
                //Catch this exception in case the encryption did
                //not succeed.
                Console.WriteLine("Encryption failed.");
            }
        }
        private string encript(String plainText)
        {
            var key = UTF8Encoding.UTF8.GetBytes("N3t");
            var iv = UTF8Encoding.UTF8.GetBytes("V3CTor");

            Array.Resize(ref key, 16);
            Array.Resize(ref iv, 16);

            // Crear una instancia del algoritmo de Rijndael
            Rijndael rijndael = Rijndael.Create();
            rijndael.KeySize = 128;
            // Establecer un flujo en memoria para el cifrado
            MemoryStream memoryStream = new MemoryStream();

            // Crear un flujo de cifrado basado en el flujo de los datos
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(), CryptoStreamMode.Write);

            // Obtener la representación en bytes de la información a cifrar
            byte[] plainMessageBytes = UTF8Encoding.UTF8.GetBytes(plainText);

            // Cifrar los datos enviándolos al flujo de cifrado
            cryptoStream.Write(plainMessageBytes, 0, plainMessageBytes.Length);
            cryptoStream.FlushFinalBlock();

            // Obtener los datos datos cifrados como un arreglo de bytes
            byte[] cipherTextBytes = memoryStream.ToArray();

            // Cerrar los flujos utilizados
            memoryStream.Close();
            cryptoStream.Close();

            // Retornar la representación de texto de los datos cifrados
            return Convert.ToBase64String(cipherTextBytes);
        }

        public static byte[] Encrypt(byte[] data, string password, byte[] salt, byte[] iv)
        {
            var KEYSIZE = 256;

            using var rij = new RijndaelManaged()
            {
                KeySize = KEYSIZE,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            using var rfc = new Rfc2898DeriveBytes(password, salt);
            rij.Key = rfc.GetBytes(KEYSIZE / 8);
            rij.IV = iv;

            using var ms = new MemoryStream();
            using var cs = new CryptoStream(ms, rij.CreateEncryptor(), CryptoStreamMode.Write);

            using (var bw = new BinaryWriter(cs))
            {
                bw.Write(data);
            }

            return ms.ToArray();
        }
    }
}