﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.Models;

namespace Translate.BL
{
    interface ITranslateManager
    {
        WordColocation Translate(string textOriginal);
    }
}
