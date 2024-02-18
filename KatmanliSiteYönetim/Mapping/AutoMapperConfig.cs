using AutoMapper;
using DTOLayer.DTOs.BlokDTOs;
using DTOLayer.DTOs.DaireDTOs;
using DTOLayer.DTOs.EvSahibiDTOs;
using DTOLayer.DTOs.GiderDTOs;
using DTOLayer.DTOs.SiteDTOs;
using DTOLayer.DTOs.SiteYoneticisiDTOs;
using DTOLayer.DTOs.UserDTOs;
using EntityLayer.Concrete;

namespace KatmanliSiteYonetim.Mapping
{
    public class AutoMapperConfig : Profile

    {
       public AutoMapperConfig() {

            CreateMap<Site, SiteAddDTO>();
            CreateMap<SiteAddDTO, Site>();

            CreateMap<Blok, BlokAddDTO>().ReverseMap();


            CreateMap<Daire, DaireAddDTO>().ReverseMap();


            CreateMap<EvSahibiKiraci, EvSahibiAddDTO>().ReverseMap();


            CreateMap<Gider, GiderAddDTO>().ReverseMap();


            CreateMap<SiteYoneticisi, SiteYoneticisAddiDTO>().ReverseMap();


            CreateMap<User, UserAddDTO>().ReverseMap();
        }
        
    }
}
