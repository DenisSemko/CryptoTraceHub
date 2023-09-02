namespace CryptoAgent.CoinAPI.Models.Enums;

public enum CryptocurrencyType
{
    [EnumMember(Value = "all")]
    All,
    [EnumMember(Value = "coins")]
    Coins,
    [EnumMember(Value = "tokens")]
    Tokens
}