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
                var dataToEncrypt =  "Data to Encrypt";


                var en = encript(dataToEncrypt);

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
            var key = UTF8Encoding.UTF8.GetBytes("1.4M.Joy3r0.N3t");
            var iv = UTF8Encoding.UTF8.GetBytes("V3CTor");

            Array.Resize(ref key, 32);
            Array.Resize(ref iv, 16);

            // Crear una instancia del algoritmo de Rijndael
            Rijndael rijndael = Rijndael.Create();

            // Establecer un flujo en memoria para el cifrado
            MemoryStream memoryStream = new MemoryStream();

            // Crear un flujo de cifrado basado en el flujo de los datos
            CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(key, iv), CryptoStreamMode.Write);

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
    }
}