using globothai.Entities;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;



namespace globothai.Repositorie
{
    public class GridRepositorie
    {
        private string _dbPath { get; set; }

        public GridRepositorie(string dbPath)
        {
            this._dbPath = dbPath;
        }

        public void AddGridItem(GridItemEntity item)
        {
            List<GridItemEntity> grid = GetGrid();
            grid.Add(item);

            string jsonData = JsonSerializer.Serialize(grid);
            File.WriteAllText(_dbPath, jsonData);
        }


        private string ReadOrCreate(string path) {
            try
            {
                string file = File.ReadAllText(path);
                return file;

            }
            catch
            {
             return JsonSerializer.Serialize(new List<GridItemEntity> { });
            }

        }
        public List<GridItemEntity>? GetGrid()
        {
            string file = ReadOrCreate(_dbPath);

            List<GridItemEntity>? grid = JsonSerializer.Deserialize<List<GridItemEntity>>(file);
            bool hasItens = grid.Any();

            return hasItens ? grid : new List<GridItemEntity> { };
        }
    }
}
