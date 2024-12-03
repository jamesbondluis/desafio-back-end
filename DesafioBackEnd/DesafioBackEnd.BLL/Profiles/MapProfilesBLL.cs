using AutoMapper;
using DesafioBackEnd.BLL.Models.DataBaseModels;
using DesafioBackEnd.BLL.Models.DTOModels;

namespace DesafioBackEnd.BLL.Profiles
{
    public class MapProfilesBLL : Profile
    {
        public MapProfilesBLL()
        {
            CreateMap<Pedido, BuscarPedidoResponse>()
                .ForMember(resp => resp.Pedido, orig => orig.MapFrom(o => o.NumeroPedido));
            CreateMap<Item, BuscarPedidoItemResponse>()
                .ForMember(resp => resp.Qtd, orig => orig.MapFrom(o => o.Quantidade));
            CreateMap<ItemCriarPedidoRequest, Item>()
                .ForMember(resp => resp.Quantidade, orig => orig.MapFrom(o => o.Qtd));
            CreateMap<ItemAlterarPedidoRequest, Item>()
                .ForMember(resp => resp.Quantidade, orig => orig.MapFrom(o => o.Qtd));
        }
    }
}
