﻿using MLS.Application.DTO.Comment;
using MLS.Application.DTO.Notification;
using MLS.Application.DTO.Order;
using MLS.Application.DTO.ProductReview;
using MLS.Application.DTO.WishList;

namespace MLS.Application.DTO.User;

public class UserDetailsDto : UserDto
{
    public List<OrderDto> Orders { get; set; } = new();
    public List<ProductReviewDto> ProductReviews { get; set; } = new();
    public List<WishListDto> WishLists { get; set; } = new();
    public List<CommentDto> Comments { get; set; } = new();
    public List<NotificationDto> Notifications { get; set; } = new();
}