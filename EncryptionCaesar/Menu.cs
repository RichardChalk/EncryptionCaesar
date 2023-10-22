namespace EncryptionCaesar
{
    public class Menu
    {
        private bool Keeprunning { get; set; } = true;
        public void ShowMenu()
        {
            while (Keeprunning)
            {
                Console.Clear();
                Console.WriteLine("Välkommen");
                Console.WriteLine("1: Enkryptera ett meddelande");
                Console.WriteLine("2: Dekryptera ett meddelande");
                Console.WriteLine("3: Dekryptera ett meddelande (UTAN NYCKEL!)");
                Console.WriteLine("0: Exit");
                var userResponse = Console.ReadLine();
                GetUserInput(userResponse);
            }
        }

        private void GetUserInput(string userResponse)
        {
            switch (userResponse)
            {
                case "1":
                    var encrypt = new EncryptClass();
                    encrypt.GetEncryptionMessage();
                    break;
                case "2":
                    var decrypt = new DecryptClass();
                    decrypt.GetDecryptionMessage();
                    break;
                case "3":
                    var decryptNoKey = new DecryptClass();
                    decryptNoKey.GetDecryptionMessageNoKey();
                    break;
                case "0":
                    Keeprunning = false;
                    break;
                default:
                    break;
            }
        }
    }
}