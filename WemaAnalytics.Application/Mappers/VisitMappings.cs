//namespace WemaAnalytics.Application.Mappers
//{
//    public class VisitMappings : Profile
//    {
//        public VisitMappings()
//        {
//            CreateMap<Visit, VisitModel>().ReverseMap();
//            CreateMap<Visit, CreateVisitCommand>().ReverseMap()
//                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => UtilityHelper.ShouldMapMember(srcMember)));
//            CreateMap<Visit, UpdateVisitCommand>().ReverseMap()
//                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => UtilityHelper.ShouldMapMember(srcMember)));
//        }
//    }
//}