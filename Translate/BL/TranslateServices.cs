using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.DAL.Services;

namespace Translate.BL
{
    public class TranslateService
    {
        readonly TranslateServiceEnum _service;

        public TranslateServiceEnum Service
        {
            get
            {
                return _service;
            }
        }

        public TranslateService(TranslateServiceEnum translateService)
        {
            _service = translateService;
        }
    }
}
