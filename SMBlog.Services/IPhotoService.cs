﻿using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;

namespace SMBlog.Services
{
    public interface IPhotoService
    {
        public Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        public Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}