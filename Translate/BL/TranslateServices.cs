using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.DAL.Services;

namespace Translate.BL
{
    public class TranslateService
    {
        TranslateServiceEnum service = TranslateServiceEnum.Empty;

        public TranslateServiceEnum Service
        {
            get
            {
                return service;
            }
        }

        public TranslateService(TranslateServiceEnum translateService)
        {
            service = translateService;
        }
    }
}
