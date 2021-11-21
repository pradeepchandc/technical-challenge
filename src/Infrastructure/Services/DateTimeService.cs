using BookCart.Application.Common.Interfaces;
using System;

namespace BookCart.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}