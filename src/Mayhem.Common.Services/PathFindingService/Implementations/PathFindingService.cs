using System.Collections.Generic;
using Mayhem.Common.Services.PathFindingService.Dtos;
using Mayhem.Common.Services.PathFindingService.Interfaces;
using System.Linq;
using System;
using Mayhem.Common.Services.PathFindingService.Enums;
using System.Collections.ObjectModel;

namespace Mayhem.Common.Services.PathFindingService.Implementations
{
    public class PathFindingService : IPathFindingService
    {
        private readonly int[,] neighborsOdd = new int[,]
        {
            { 0, -1 }, { 1, -1 }, { -1, 0 }, { 1, 0 }, { 0, 1 }, { 1, 1 }
        };

        private readonly int[,] neighborsEven = new int[,]
        {
            { -1, -1 }, { 0, -1 }, { -1, 0 }, { 1, 0 }, { -1, 1 }, { 0, 1 }
        };

        private int[,] grid;

        public List<PathLand> Calculate(int[,] grid, PathLand from, PathLand to)
        {
            int maxX = grid.GetLength(0);
            int maxY = grid.GetLength(1);
            this.grid = grid;

            OrderedHashSet<PathLand> closed = new();
            OrderedHashSet<PathLand> open = new() { from };

            Dictionary<PathLand, PathLand> path = new();

            Dictionary<PathLand, double> gScore = new();
            gScore[from] = 0;

            Dictionary<PathLand, double> fScore = new();
            fScore[from] = Math.Abs(from.X - to.X) + Math.Abs(from.Y - to.Y);

            while (open.Any())
            {
                PathLand current = open.First();
                if (current == to)
                {
                    return ReconstructPath(path, current);
                }

                open.Remove(current);
                closed.Add(current);

                foreach (PathLand neighbor in GetNeighbors(current, maxX, maxY))
                {
                    if (closed.Contains(neighbor) || IsBlocked(neighbor))
                    {
                        continue;
                    }

                    double tentativeG = gScore[current] + 1;


                    if (!open.Contains(neighbor))
                    {
                        open.Add(neighbor);
                    }
                    else if (tentativeG >= gScore[neighbor])
                    {
                        continue;
                    }

                    path[neighbor] = current;

                    gScore[neighbor] = tentativeG;
                    fScore[neighbor] = gScore[neighbor] + Math.Abs(neighbor.X - to.X) + Math.Abs(neighbor.Y - to.Y);
                }
            }

            return null;
        }

        private bool IsBlocked(PathLand neighbor)
        {
            try
            {
                return grid[neighbor.X, neighbor.Y] == (int)PathFindingLandsType.WALL;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private List<PathLand> ReconstructPath(IDictionary<PathLand, PathLand> path, PathLand current)
        {
            List<PathLand> totalPath = new() { current };

            while (path.ContainsKey(current))
            {
                current = path[current];
                totalPath.Add(current);
            }

            totalPath.Reverse();
            totalPath.RemoveAt(0);

            return totalPath.ToList();
        }

        private IEnumerable<PathLand> GetNeighbors(PathLand tile, int maxX, int maxY)
        {
            List<PathLand> result = new();

            if (tile.Y % 2 == 1)
            {
                for (int i = 0; i < neighborsOdd.GetLongLength(0); i++)
                {
                    int x = tile.X + neighborsOdd[i, 0];
                    int y = tile.Y + neighborsOdd[i, 1];
                    CalculateNeighbor(maxX, maxY, result, x, y);
                }
            }
            else
            {
                for (int i = 0; i < neighborsEven.GetLongLength(0); i++)
                {
                    int x = tile.X + neighborsEven[i, 0];
                    int y = tile.Y + neighborsEven[i, 1];
                    CalculateNeighbor(maxX, maxY, result, x, y);
                }
            }

            return result;
        }

        private void CalculateNeighbor(int maxX, int maxY, List<PathLand> result, int x, int y)
        {
            if (x < 0 && y < 0)
            {
                result.Add(new PathLand(x + maxX, y + maxY));
            }
            else if (x < 0 && (y >= 0 && y < maxY))
            {
                result.Add(new PathLand(x + maxX, y));
            }
            else if ((x >= 0 && x < maxX) && y < 0)
            {
                result.Add(new PathLand(x, y + maxY));
            }
            else if ((x >= 0 && x < maxX) && (y >= 0 && y < maxY))
            {
                result.Add(new PathLand(x, y));
            }
            else if (x >= maxX && y >= maxY)
            {
                result.Add(new PathLand(x - maxX, y - maxY));
            }
            else if (x < maxX && y >= maxY)
            {
                result.Add(new PathLand(x, y - maxY));
            }
            else if (x >= maxX && y < maxY)
            {
                result.Add(new PathLand(x - maxX, y));
            }
            else if (x < maxX && y < maxY)
            {
                result.Add(new PathLand(x, y));
            }
        }
    }

    public class OrderedHashSet<T> : KeyedCollection<T, T>
    {
        protected override T GetKeyForItem(T item)
        {
            return item;
        }
    }
}
