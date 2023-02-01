using System.IO;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Mishkasta.Csv;

public interface ICsvService
{
    Task<IReadOnlyCollection<T>> ReadFromStreamAsync<T>(Stream stream);
}