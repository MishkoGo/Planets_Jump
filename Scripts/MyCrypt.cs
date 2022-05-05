using UnityEngine;
using BayatGames.SaveGameFree;
using BayatGames.SaveGameFree.Serializers;


public class MyCrypt : MonoBehaviour
{
    public bool needCrypt;
    public string encodePassword;
    public string add1;
    public string add2;

   // private string addCrypt1 = "";
   // private string addCrypt2 = "";
    
    private string addCrypt1 = "35xfLntFkq/KkZeeyVJtGcjVvKNTe3xj1185DXowZ8YBTRdWJwFFu1GXPG9YaXsHYgsJ9bkz+v5iLf+JFjKQrZ/lNw87dSC7fw5q7lcQRq2+8WZAVCXrlEZaqpKaR7sC";
    private string addCrypt2 = "6w1SxqyThs6ViVON6I91ximpdLQlz1ZpiQyQs7pybslA5ZlyMYx6iPjDR3upjsXcEErzFTxwIqQ8ncCKLlVeQM4n51ZVMqdX3AdappNarqz6LR1nwfcDYhFICXokEH64YohdP2eUkf1su+fzdZR1Gah80oBWap6QzZKYzL18zdX2bJcFEbOarxlGsgRZXjKwo+UtQmbPaV2O2zzORf/rgA==";
   
   
    private void Awake()
    {
        SaveGame.EncodePassword = encodePassword;
        SaveGame.Encode = true;
        SaveGame.Serializer = new SaveGameJsonSerializer();

        if (needCrypt)
            Encode();
    }
    private void Encode()
    {
        add1 = SaveGame.Encoder.Encode(add1, encodePassword);
        add2 = SaveGame.Encoder.Encode(add2, encodePassword);
    }
    public string GetAdd1()
    {
        return SaveGame.Encoder.Decode(addCrypt1, encodePassword);
    }
    public string GetAdd2()
    {
        return SaveGame.Encoder.Decode(addCrypt2, encodePassword);
    }
}
