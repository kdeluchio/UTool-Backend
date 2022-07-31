using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UTools.Application.Dtos;

namespace UTools.Application.Interfaces
{
    public interface IBaseAppService<TParam, TResult>
    {
        Task<ResponseDTO<TResult>> ExecuteAsync(TParam parameters);
    }

    public interface IBaseAppService<TParam>
    {
        Task<ResponseDTO> ExecuteAsync(TParam parameters);
    }
}
