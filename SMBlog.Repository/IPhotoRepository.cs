using SMBlog.Models.Photo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMBlog.Repository
{
    public interface IPhotoRepository
    {
        public Task<Photo> InsertAsync(PhotoCreate photo, int applicationUserId);
        public Task<Photo> GetAsync(int photoId);
        public Task<List<Photo>> GetAllByUserIdAsync(int applicationUserId);
        public Task<int> DeleteAsync(int photoId);

    }
}
