using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;

namespace Mishkasta.Csv.CsvHelper;

public class CsvHelperCsvService : ICsvService
{
    public async Task<IReadOnlyCollection<T>> ReadFromStreamAsync<T>(Stream stream)
    {
        using (var reader = new StreamReader(stream))
        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
        {
            return await csv.GetRecordsAsync<T>().ToListAsync();
        }
    }
}