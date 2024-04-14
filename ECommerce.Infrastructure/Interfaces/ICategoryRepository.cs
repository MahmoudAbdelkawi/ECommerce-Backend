﻿using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Infrastructure.Interfaces
{
    public interface ICategoryRepository : IGenericRepository<Category>
    {
    }
}
