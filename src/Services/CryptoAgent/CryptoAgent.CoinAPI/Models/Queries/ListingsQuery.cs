using Tag = CryptoAgent.CoinAPI.Models.Enums.Tag;

namespace CryptoAgent.CoinAPI.Models.Queries;

public sealed class ListingsQuery
{
    [JsonProperty("start")]
    public int Start { get; set; } = 1;
    [JsonProperty("limit")]
    public int Limit { get; set; } = 100;
    [JsonProperty("price_min")]
    public double? PriceMin { get; set; }
    [JsonProperty("price_max")]
    public double? PriceMax { get; set; }
    [JsonProperty("market_cap_min")]
    public double? MarketCapMin { get; set; }
    [JsonProperty("market_cap_max")]
    public double? MarketCapMax { get; set; }
    [JsonProperty("volume_24h_min")]
    public double? Volume24Min { get; set; }
    [JsonProperty("volume_24h_max")]
    public double? Volume24Max { get; set; }
    [JsonProperty("circulating_supply_min")]
    public double? CirculatingSupplyMin { get; set; }
    [JsonProperty("circulating_supply_max")]
    public double? CirculatingSupplyMax { get; set; }
    [JsonProperty("percent_change_24h_min")]
    public double? PercentChange24HMin { get; set; }
    [JsonProperty("percent_change_24h_max")]
    public double? PercentChange24HMax { get; set; }
    [JsonProperty("convert")]
    public string? Convert { get; set; }
    [JsonProperty("convert_id")]
    public string? ConvertId { get; set; }
    [JsonProperty("sort")]
    [JsonConverter(typeof(StringEnumConverter))]
    public SortListingLatest Sort { get; set; } = SortListingLatest.MarketCap;
    [JsonProperty("sort_dir")]
    [JsonConverter(typeof(StringEnumConverter))]
    public SortDirection SortDir { get; set; } = SortDirection.Descending;
    [JsonProperty("cryptocurrency_type")]
    [JsonConverter(typeof(StringEnumConverter))]
    public CryptocurrencyType CryptocurrencyType { get; set; } = Enums.CryptocurrencyType.All;
    [JsonProperty("tag")]
    [JsonConverter(typeof(StringEnumConverter))]
    public Tag Tag { get; set; } = Tag.All;
    [JsonProperty("aux")]
    public string? Aux { get; set; }
}