using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
using System.Text.Unicode;

namespace KeyPairApp;

class Program
{
    static void Main()
    {
        var alice = new Person();
        var bob = new Person();

        // alice send message to bob
        var aliceMessage = "this message to bob";
        var aliceMessageBytes = Encoding.UTF8.GetBytes(aliceMessage);
        var aliceMessageEncript = alice.EncriptyMessage(aliceMessageBytes, bob.GetPublicKey());


        var bobMessageBytes = bob.DecriptyMessage(aliceMessageEncript);
        var bobMessage = Encoding.UTF8.GetString(bobMessageBytes);

        if (aliceMessage == bobMessage)
        {
            Console.WriteLine("verify -> ok");
        }
    }
}