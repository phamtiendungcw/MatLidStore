﻿using MediatR;
using MLS.Application.DTO.Comment;

namespace MLS.Application.Features.Comment.Commands.UpdateCommentCommand;

public class UpdateCommentCommand : IRequest<Unit>
{
    public UpdateCommentDto Comment { get; set; } = null!;
}