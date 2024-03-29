﻿using Domain.Entities;

namespace Domain.Interfaces.Repositories
{
    public interface IColorRepository : IGenericRepository<Color>
    {
        Task<Color> GetColorBySlug(string slug);
        Task<bool> AddOrUpdateColor(Color category);
        Task<bool> DeleteColor(int id);
    }
}
