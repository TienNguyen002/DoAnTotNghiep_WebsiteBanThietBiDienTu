﻿namespace Application.Media
{
    public interface IMediaManager
    {
        Task<string> SaveFileAsync(
            Stream buffer,
            string originalFileName,
            string contentType,
            CancellationToken cancellationToken = default);
        Task<string> SaveImgFileAsync(
            Stream buffer,
            string originalFileName,
            string contentType,
            CancellationToken cancellationToken = default);
        Task<bool> DeleteFileAsync(
            string filePath,
            CancellationToken cancellationToken = default);
    }
}