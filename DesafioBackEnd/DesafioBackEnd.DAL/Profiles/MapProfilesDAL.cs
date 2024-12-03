using AutoMapper;

namespace DesafioBackEnd.DAL.Profiles
{
    public class MapProfilesDAL : Profile
    {
        public MapProfilesDAL()
        {
            CreateMap<BLL.Models.DataBaseModels.Item, Models.Item>();
            CreateMap<BLL.Models.DataBaseModels.Pedido, Models.Pedido>();
            CreateMap<Models.Item, BLL.Models.DataBaseModels.Item>();
            CreateMap<Models.Pedido, BLL.Models.DataBaseModels.Pedido>();
        }
    }
}
