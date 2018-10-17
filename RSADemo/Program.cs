using System;
using System.Text;

namespace RSADemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //秘钥
            string public_key = "-----BEGIN PUBLIC KEY-----MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQC+2YhTMpKGgjc0hZ7Xt+EawtQWup6XXDiD4i9aa77JUjQkT2NNFgjrNQAdlRY1eD1xDK46boXYmIh7m/5CRCMN1oE/OY4/LGIwR6S4tNG3w3aWv9iIXmZ6cq5Z1tss+bFKX+7XNLZA3bMW+KYaigxFuQHhcWFFwTndwWVrn2zo/wIDAQAB-----END PUBLIC KEY-----";
            string private_key = "-----BEGIN RSA PRIVATE KEY-----MIICXQIBAAKBgQC+2YhTMpKGgjc0hZ7Xt+EawtQWup6XXDiD4i9aa77JUjQkT2NNFgjrNQAdlRY1eD1xDK46boXYmIh7m/5CRCMN1oE/OY4/LGIwR6S4tNG3w3aWv9iIXmZ6cq5Z1tss+bFKX+7XNLZA3bMW+KYaigxFuQHhcWFFwTndwWVrn2zo/wIDAQABAoGBALV7RhdXT954lOZs6c9YG8bG3cd/Tq/AEj3XKBBjxNjMQqkElPkIqxJ/I8z9qFDQNhz6YfNOhhihc6eXfwCkqm8luXaFYPoJBlAGSBKO1wXg0MnVwRtvVheMOZfV0tHYyHV56zvB92/9MNJE4IavOhJGDWmvQakecHW7y16JcFIBAkEA/kC50VHg5mfF8N/jCVhXDLqIkxBqk+i7rfNeVDcIjUxWwvN18H6YOVPzJxDV4JW9XseQDbBruQcjmF2/f9cujwJBAMApRREedzU3gLMUZEPq3bDsYqu3z8XzKwItybFk0Tu3HYlC7nS1pWcL7xVmbJ+7ibtv0cO8Dmonu+JvvSBg1pECQGlQUieb7LZDQcA2XIpgZx5EnZGc+Shu/F5fMjFb4lT0y/NQeQe2yELmvQ7vcEfoflol+0tQSi6IAHx6SHohnY0CQHVYfnHezeM0mqZBPJ1xDqJdKEA+xmXWghwZhAKNU2yI/UN2GRIyXuhXlE/YNVsx9gD9XvaNn6vZydWUcMUV/dECQQD7D3we/oO6RyDjMt4QHFkBY7bTzb+lfWtTD41Xef+BN4DXiJB8jLxot4byw737N/H1XOAqmgjOU165Y39lAutM-----END RSA PRIVATE KEY-----";
            private_key = private_key.Replace("-----BEGIN RSA PRIVATE KEY-----", "").Replace("-----END RSA PRIVATE KEY-----", "");
            public_key = public_key.Replace("-----BEGIN PUBLIC KEY-----", "").Replace("-----END PUBLIC KEY-----", "");

            //请输入要加密的串   
            Console.WriteLine("请输入要加密的字符串：");
            string inputStr=Console.ReadLine();

            RSACryptService rsa = new RSACryptService(private_key, public_key);
            //加密
            string StrAfterEncrypt = rsa.Encrypt(inputStr);
            Console.WriteLine("加密后的字符串：{0}",StrAfterEncrypt);
            Console.WriteLine("加密后的字符长度：{0}",StrAfterEncrypt.Length);

            //解密
            string StrAfterDecrypt = rsa.Decrypt(StrAfterEncrypt);
            Console.WriteLine("解密后的字符串：{0}",StrAfterDecrypt);

            //
            byte[] input = Encoding.UTF8.GetBytes(inputStr.ToCharArray());
            string words= Convert.ToBase64String(input);

            Console.WriteLine("ToBase64后的字符串：{0}", words);
            Console.WriteLine("ToBase64后的字符长度：{0}", words.Length);

            //byte[] input = Convert.FromBase64String(inputStr);
            //string words = Encoding.UTF8.GetString(input);


            Console.ReadKey();
        }
    }
}
