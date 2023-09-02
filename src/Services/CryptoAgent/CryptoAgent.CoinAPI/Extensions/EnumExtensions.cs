namespace CryptoAgent.CoinAPI.Extensions;

public static class EnumExtensions
{
    public static string GetEnumString<TEnum>(TEnum value) where TEnum : Enum
    {
        Type enumType = typeof(TEnum);
        FieldInfo fieldInfo = enumType.GetField(value.ToString());
        EnumMemberAttribute[] enumMemberAttributes = fieldInfo.GetCustomAttributes(typeof(EnumMemberAttribute), false) as EnumMemberAttribute[];

        if (enumMemberAttributes is not null && enumMemberAttributes.Length > 0)
        {
            return enumMemberAttributes[0].Value;
        }

        return value.ToString();
    }
}