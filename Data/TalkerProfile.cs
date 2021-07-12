using AutoMapper;
using CoreCodeCamp.Models;

namespace CoreCodeCamp.Data
{
    public class TalkerProfile : Profile
    {
        public TalkerProfile()
        {
            CreateMap<Talk, TalkModel>()
                .ReverseMap()
                .ForMember(t => t.Camp, opt => opt.Ignore())
                .ForMember(s => s.Speaker, opt => opt.Ignore());
                
        }       
    }
}
