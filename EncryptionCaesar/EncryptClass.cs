namespace EncryptionCaesar
{
    public class EncryptClass
    {
        public void GetEncryptionMessage()
        {
            // PART 1: Basic encryption
            string message = "I love doughnuts!";
            int key = 3;

            string encrypted = RunEncryption(message, key);
            Console.WriteLine(encrypted);
            Console.WriteLine("Tryck på valfri tangent");
            Console.ReadLine();

        }

        /// <summary>
        /// Encrypts a complete message using a Caesar cipher with a given key.
        /// </summary>
        private static string RunEncryption(string message, int key)
        {
            message = message.ToUpper();

            string encryptedMessage = "";

            for (int index = 0; index < message.Length; index++)
            {
                char encryptedLetter = RunEncryption(message[index], key);
                encryptedMessage += encryptedLetter;
            }

            return encryptedMessage;
        }

        /// <summary>
        /// Encrypts a single letter with the given key using a Caesar cipher.
        /// </summary>
        private static char RunEncryption(char letter, int key)
        {
            // Vi tittar endast på A-Z
            if (letter < 'A' || letter > 'Z') { return letter; }

            // Klura ut vilken bokstav det är
            int letterAsNumber = (int)letter - 'A';

            // Gör själva decryption.
            int encryptedLetter = (letterAsNumber + key) % 26;

            // Konvertera tillbaks till en bokstav
            return (char)(encryptedLetter + 'A');
        }
    }
}