using CsvHelper.Configuration.Attributes;

namespace GorgesMusic.Data;

internal record CsvLine([Index(8)]string Song,[Index(10)] string AudioLink,[Index(19)]string ImageLink);
