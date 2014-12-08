using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Translate.Models
{
    public enum TranslateDirectionEnum
    {
        Ru_En = 0, En_Ru, Empty = 999
    }

    public class TranslateDirection
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

        public TranslateDirection(TranslateDirectionEnum translateDirection)
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
