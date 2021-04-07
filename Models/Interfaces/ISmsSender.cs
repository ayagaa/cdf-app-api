﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CDF.API.Models.Interfaces
{
    public interface ISmsSender
    {
        Task SendSmsAsync(ApplicationData application, string message);
    }
}