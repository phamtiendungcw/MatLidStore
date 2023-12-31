﻿using MediatR;

namespace MLS.Application.Features.Promotion.Commands.DeletePromotionCommand
{
    public class DeletePromotionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}