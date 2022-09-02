using Mayhem.Common.Services.PathFindingService.Dtos;
using System.Collections.Generic;

namespace Mayhem.Common.Services.PathFindingService.Interfaces
{
    public interface IPathFindingService
    {
        List<PathLand> Calculate(int[,] grid, PathLand from, PathLand to);
    }
}
