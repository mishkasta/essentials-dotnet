using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using System;
using CsvHelper.Configuration;

namespace Mishkasta.Csv.CsvHelper;

public class CsvHelperCsvService : ICsvService
{
    public async Task<IReadOnlyCollection<T>> ReadFromStreamAsync<T>(Stream stream, Action<CsvOptions> optionsBuilder)
    {
        var options = new CsvOptions();
        optionsBuilder?.Invoke(options);

        var config = new CsvConfiguration(CultureInfo.InvariantCulture);
        if (options.AreFieldsLowercase)
        {
            config.PrepareHeaderForMatch = args => args.Header.ToLower();
        }

        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, config))
        {
            return await csv.GetRecordsAsync<T>().ToListAsync();
        }
    }
}