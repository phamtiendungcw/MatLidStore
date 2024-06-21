using MediatR;
using MLS.Application.DTO.OrderDetail;

namespace MLS.Application.Features.OrderDetail.Commands.UpdateOrderDetailCommand
{
    public class UpdateOrderDetailCommand : IRequest<Unit>
    {
        public UpdateOrderDetailDto OrderDetail { get; set; } = null!;
    }
}