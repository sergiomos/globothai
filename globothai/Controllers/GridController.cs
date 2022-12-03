using globothai.Adapters;
using globothai.Entities;
using globothai.Repositorie;
using globothai.Utils;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace globothai.Controllers
{
    public class GridController
    {
        private GridRepositorie _gridRepositorie { get; set; }
        private LineAdapter _lineAdapter { get; set; }
        private TimeUtils _timeUtils { get; set; }

        public GridController(
            GridRepositorie gridRepositorie, 
            LineAdapter lineAdapter,
            TimeUtils timeUtils)
        {
            this._gridRepositorie = gridRepositorie;
            this._lineAdapter = lineAdapter;
            this._timeUtils = timeUtils;
        }
        public void InsertGridLine(string line)
        {
            GridItemEntity gridItem = _lineAdapter.LineToGridItem(line);
            _gridRepositorie.AddGridItem(gridItem);
        }

        public void Query(string line)
        {
            QueryEntity query = _lineAdapter.LineToQuery(line);
            List<GridItemEntity>? grid = _gridRepositorie.GetGrid();

            GridItemEntity? localProgram = grid?
                .Where((GridItemEntity item) => item.Zone == query.Zone && _timeUtils.TimeBetween(query.Time, item.StartTime, item.EndTime))
                .FirstOrDefault();

            GridItemEntity? globalProgram = grid?
                .Where((GridItemEntity item) => item.Zone == "BR" && _timeUtils.TimeBetween(query.Time, item.StartTime, item.EndTime))
                .FirstOrDefault();

            if (localProgram != null)
            {
                Console.WriteLine($"A {query.Zone} {query.Time} {localProgram.Zone} {localProgram.Name}");

            }
            else if (globalProgram != null)
            {
                Console.WriteLine($"A {query.Zone} {query.Time} {globalProgram.Zone} {globalProgram.Name}");

            }
            else
            {
                Console.WriteLine($"A {query.Zone} {query.Time} noise");
            }
        }
    }
}
