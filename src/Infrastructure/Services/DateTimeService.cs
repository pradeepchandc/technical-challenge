﻿using BookCart.Application.Common.Interfaces;

namespace BookCart.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
