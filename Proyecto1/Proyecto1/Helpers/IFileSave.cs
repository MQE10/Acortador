﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto1.Helpers
{
    public interface IFileSave
    {
        Task SaveAS(string filename, string data, string type = "text/plain;charset-uft-8");
    }
}
