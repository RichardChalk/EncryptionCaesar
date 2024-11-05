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

            // Enkrypterar en bokstav i taget
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
            // Den här raden ser till att endast bokstäver mellan A och Z behandlas.
            // Om bokstaven letter inte är inom detta intervall,
            // returneras bokstaven som den är utan förändring.
            if (letter < 'A' || letter > 'Z') { return letter; }

            // Klura ut vilken bokstav det är
            // Här omvandlas bokstaven till en siffra som är lättare att jobba med.
            // Genom att subtrahera 'A' från letter, får vi en siffra mellan 0 och 25
            // där A motsvarar 0, B motsvarar 1, och så vidare.
            // Om letter är "I", får vi siffran 8
            // (eftersom "I" är den nionde bokstaven i alfabetet, men vi börjar räkna från 0).
            int letterAsNumber = (int)letter - 'A';

            // Här utförs krypteringen.
            // Genom att lägga till nyckeln (key) till letterAsNumber, förskjuts bokstaven
            // framåt i alfabetet. Sedan används % 26 för att "wrap-around" när vi kommer
            // till slutet av alfabetet (detta håller oss inom intervallet 0-25).
            // För "I" (värde 8) och en nyckel på 3, blir resultatet (8 + 3) % 26 = 11,
            // vilket motsvarar "L".
            int encryptedLetter = (letterAsNumber + key) % 26;

            // Här omvandlas det krypterade talet tillbaka till en bokstav.
            // Genom att lägga till 'A' till encryptedLetter får vi rätt bokstav
            // i ASCII-tabellen.
            // För 11 blir det alltså "L".
            return (char)(encryptedLetter + 'A');
        }
    }
}