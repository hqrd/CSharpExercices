using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CS.Impl._03_Linq
{
    public class Linq
    {
        public IEnumerable<string> FindStringsWhichStartsAndEndsWithSpecificCharacter(string startCharacter, string endCharacter, IEnumerable<string> strings)
        {
            return strings.Where(s => s.StartsWith(startCharacter) && s.EndsWith(endCharacter));
        }

        public IEnumerable<int> GetGreaterNumbers(int limit, IEnumerable<int> numbers)
        {
            return numbers.Where(n => n > limit);
        }

        public IEnumerable<int> GetTopNRecords(int limit, IEnumerable<int> numbers)
        {
            return numbers.OrderByDescending(n => n).Take(limit);
        }

        public IDictionary<string, int> GetFileCountByExtension(IEnumerable<string> files)
        {
            return files
                .GroupBy(f => Path.GetExtension(f.ToLower()).Replace(".", ""))
                .Select(f => new KeyValuePair<string, int>(f.Key, f.Distinct().Count()))
                .ToDictionary(x => x.Key, x => x.Value); ;
        }

        public IEnumerable<Tuple<string, string, int, double>> GetFinalReceipe(List<Item> items, List<Client> clients, List<Purchase> purchases)
        {
            return purchases
                   .Join(clients, p => p.ClientId, c => c.Id, (p, c) => new { p.ItemId, Client = c.Name, p.Quantity })
                   .Join(items, p => p.ItemId, i => i.Id, (p, i) => new Tuple<string, string, int, double>(p.Client, i.Label, p.Quantity, i.Price));
        }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public double Price { get; set; }
    }

    public class Purchase
    {
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public int ClientId { get; set; }
    }

    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
