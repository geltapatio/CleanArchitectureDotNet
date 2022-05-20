using AutoMapper;
using CleanArchitecture.DotNet6.Application.Contracts.Persistence;
using MediatR;

namespace CleanArchitecture.DotNet6.Application.Features.Orders.GetOrdersForMonth
{
    public class GetOrdersForMonthQueryHandler : IRequestHandler<GetOrdersForMonthQuery, PagedOrdersForMonthVm>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersForMonthQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task<PagedOrdersForMonthVm> Handle(GetOrdersForMonthQuery request, CancellationToken cancellationToken)
        {
            List<Domain.Entities.Order>? list = await _orderRepository.GetPagedOrdersForMonth(request.Date, request.Page, request.Size);
            List<OrdersForMonthDto>? orders = _mapper.Map<List<OrdersForMonthDto>>(list);

            int count = await _orderRepository.GetTotalCountOfOrdersForMonth(request.Date);
            return new PagedOrdersForMonthVm() { Count = count, OrdersForMonth = orders, Page = request.Page, Size = request.Size };
        }
    }
}
