﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ludo.Application.Commands.UpdateAdvertisement
{
    public class UpdateAdvertisementCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal TotalCost { get; set; }
    }
}
