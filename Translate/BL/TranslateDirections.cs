using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Translate.DAL.Services;
using Translate.Models;

namespace Translate.BL
{
    public class TranslateDirections
    {
        TranslateDirectionEnum direction = TranslateDirectionEnum.Empty;
        string from = string.Empty;
        string to = string.Empty;

        public TranslateDirectionEnum Direction
        {
            get
            {
                return direction;
            }
        }

        public string From
        {
            get
            {
                return from;
            }
        }

        public string To
        {
            get
            {
                return to;
            }
        }

        public TranslateDirections(TranslateDirectionEnum translateDirection)
        {
            direction = translateDirection;
            switch(direction)
            {
                case TranslateDirectionEnum.En_Ru:
                {
                    from = "En";
                    to = "Ru";
                };break;
                case TranslateDirectionEnum.Ru_En:
                {
                    from = "Ru";
                    to = "En";
                };break;
                default:
                {

                };break;
            }
        }
    }
}
