using AutoMapper;
using CleanArchitecture.DotNet6.Application.Features.Categories.Commands.CreateCateogry;
using CleanArchitecture.DotNet6.Application.Features.Categories.Queries.GetCategoriesList;
using CleanArchitecture.DotNet6.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using CleanArchitecture.DotNet6.Application.Features.Events.Commands.CreateEvent;
using CleanArchitecture.DotNet6.Application.Features.Events.Commands.UpdateEvent;
using CleanArchitecture.DotNet6.Application.Features.Events.Queries.GetEventDetail;
using CleanArchitecture.DotNet6.Application.Features.Events.Queries.GetEventsList;
using CleanArchitecture.DotNet6.Application.Features.Orders.GetOrdersForMonth;
using CleanArchitecture.DotNet6.Domain.Entities;

namespace CleanArchitecture.DotNet6.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>().ReverseMap();

            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Category, CreateCategoryCommand>();
            CreateMap<Category, CreateCategoryDto>();

            CreateMap<Order, OrdersForMonthDto>();
        }
    }
}
