using System.Security.Cryptography;

namespace KeyPairApp;

public class Person
{
    private readonly string privateKey;
    private readonly string publicKey;

    public Person()
    {
        using var rsa = RSA.Create();
        this.privateKey = rsa.ToXmlString(includePrivateParameters: true);
        this.publicKey = rsa.ToXmlString(includePrivateParameters: false);
    }

    public string GetPublicKey() => this.publicKey;

    public byte[] EncriptyMessage(byte[] chipterData, string publicKeyOfReciver)
    {
        using var rsa = RSA.Create();
        rsa.FromXmlString(publicKeyOfReciver);
        return rsa.Encrypt(chipterData, RSAEncryptionPadding.Pkcs1);
    }

    public byte[] DecriptyMessage(byte[] messageEncript)
    {
        using var rsa = RSA.Create();
        rsa.FromXmlString(this.privateKey);
        return rsa.Decrypt(messageEncript, RSAEncryptionPadding.Pkcs1);
    }
}