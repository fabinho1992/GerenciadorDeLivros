﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManager.Application.Dtos.ViewModels
{
    public record UserResponse(int id, string? Name, string? Email);
}
