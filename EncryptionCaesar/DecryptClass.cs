namespace EncryptionCaesar
{
    public class DecryptClass
    {
        public void GetDecryptionMessage()
        {
            // DEL 1: Basic decryption
            // "I Love Doughnuts!"
            string message = "L ORYH GRXJKQXWV!";
            int key = 3;

            string decrypted = RunDecryption(message, key);
            Console.WriteLine(decrypted);
            Console.WriteLine("Tryck på valfri tangent");
            Console.ReadLine();
        }

        public void GetDecryptionMessageNoKey()
        {
            // PART 2: Vi ska lösa Caesar cipher trots att vi inte har nyckeln!
            // Vi testar ALLA 26 möjliga keys!.
            // Endast ett meddelande kommer att kunna läsas!
            // Alla övriga kommer att vara rappakalja!

            // "Richard should get paid more!"
            string encryptedMessageToHack = "ULFKDUG VKRXOG JHW SDLG PRUH!";
            for (int index = 0; index <= 26; index++)
            {
                Console.WriteLine(RunDecryption(encryptedMessageToHack, index));
            }
            Console.WriteLine("Tryck på valfri tangent");
            Console.ReadLine();
        }

        /// <summary>
        /// Decrypts a complete message using a Caesar cipher with a given key.
        /// </summary>
        private static string RunDecryption(string message, int key)
        {
            // För att slippa bekymmer med Case.
            message = message.ToUpper();

            // Vi börjar med ett tomt meddelande
            string encryptedMessage = "";

            // Konvertera en bokstav i taget (tillbaks till rätt bokstav)
            // ... och klistra in den längst bak i vårt meddelande
            for (int index = 0; index < message.Length; index++)
            {
                char encryptedLetter = RunDecryption(message[index], key);
                encryptedMessage += encryptedLetter;
            }

            return encryptedMessage;
        }

        /// <summary>
        /// Decrypts a single letter, using a Caesar cipher with the given
        /// key.
        /// </summary>
        private static char RunDecryption(char letter, int key)
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

            // Gör själva decryption.
            // Beroende på bokstaven och nyckeln...
            // skulle detta kunna returnera ett negativt nummer.
            // För att undvika detta addera vi 26 (nummer av bokstäver i alfabetet).
            int encryptedLetter = (letterAsNumber - key + 26) % 26;

            // Här omvandlas det krypterade talet tillbaka till en bokstav.
            // Genom att lägga till 'A' till encryptedLetter får vi rätt bokstav
            // i ASCII-tabellen.
            // För 11 blir det alltså "L".

            return (char)(encryptedLetter + 'A');
        }
    }
}