namespace CryptoAgent.CoinAPI.Common;

public class Constants
{
    private class Version
    {
        public const string V1 = "v1";
        public const string V2 = "v2";
    }

    public class Cryptocurrency
    {
        public const string ApiKeyHeader = "X-CMC_PRO_API_KEY";
        
        public static class Listing
        {
            public const string Latest  = $"{Version.V1}/cryptocurrency/listings/latest";
            public const string Historical  = $"{Version.V1}/cryptocurrency/listings/historical";
            public const string New  = $"{Version.V1}/cryptocurrency/listings/new";
        }
        
        public static class Quotes
        {
            public const string Historical  = $"{Version.V2}/cryptocurrency/quotes/historical";
            public const string Latest  = $"{Version.V2}/cryptocurrency/quotes/latest";
        }
    }

    public class Tools
    {
        public static class PriceConversion
        {
            public const string Url = $"{Version.V2}/tools/price-conversion";
        }
    }
}