using FordApi.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirdApi.Service.Base;

public interface IBaseService<Dto, TEntity>
{
    BaseResponse<Dto> GetById(int id);
    BaseResponse<bool> Insert(Dto insertResource);
    BaseResponse<bool> Remove(int id);
    BaseResponse<bool> Update(int id, Dto updateResource);
    BaseResponse<List<Dto>> GetAll();
}
