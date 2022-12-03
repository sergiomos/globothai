using globothai.Entities;
using System.Text.RegularExpressions;

namespace globothai.Adapters
{
    public class LineAdapter
    {
        public  GridItemEntity LineToGridItem(string line)
        {
            string regiaoPattern = @"(?<="")\w{2}(?="")";
            Regex regiaoRegex = new Regex(regiaoPattern);

            string nomePattern = @"(?<=""\w{2}""\s"")[\w\s\d]+(?="")";
            Regex nomeRegex = new Regex(nomePattern);

            string timePattern = @"(\d{2}:\d{2})+";
            Regex timeRegex = new Regex(timePattern);

            string regiao = regiaoRegex.Match(line).ToString();
            string name = nomeRegex.Match(line).ToString();
            MatchCollection time = timeRegex.Matches(line);
            string inicio = time[0].ToString();
            string fim = time[1].ToString();

            GridItemEntity item = new GridItemEntity
            {
                Name = name,
                Zone = regiao,
                StartTime = inicio,
                EndTime = fim,
            };

            return item;
        }

        public QueryEntity LineToQuery(string line)
        {
            string timePattern = @"(\d{2}:\d{2})+";
            Regex timeRegex = new Regex(timePattern);

            string regiaoPattern = @"(?<="")\w{2}(?="")";
            Regex regiaoRegex = new Regex(regiaoPattern);

            string time = timeRegex.Match(line).ToString();
            string regiao = regiaoRegex.Match(line).ToString();


            QueryEntity query = new QueryEntity
            {
                Time = time,
                Zone = regiao
            };

            return query;
        }
    }
}
