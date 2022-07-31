using System.Threading.Tasks;

namespace UTools.Domain.Interfaces.Commands
{
    public interface IBaseCommand<BaseEntity>
    {
        public string MessageError { get; set; }
        Task<bool> ExecuteAsync(BaseEntity entity);

    }

}
