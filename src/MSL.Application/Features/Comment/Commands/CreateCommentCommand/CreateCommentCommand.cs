﻿using MediatR;
using MLS.Application.DTO.Comment;

namespace MLS.Application.Features.Comment.Commands.CreateCommentCommand
{
    public abstract class CreateCommentCommand : IRequest<int>
    {
        public CreateCommentDto Comment { get; set; }
    }
}