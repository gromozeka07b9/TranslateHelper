using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Translate.BL;

namespace Translate.Models
{
    /// <summary>
    /// класс с результатом перевода
    /// </summary>
    public class TranslatedStrings
    {
        List<string> listWords = new List<string>();
        TranslateDirections direction = new TranslateDirections(DAL.Services.TranslateDirectionEnum.Empty);
        //массив с переведенными словами
        public List<string> ListWords
        {
            get
            {
                return listWords;
            }
            set
            {
                listWords = value;
            }
        }

        //направление перевода для данного экземпляра класса
        public TranslateDirections Direction
        {
            get
            {
                return direction;
            }
        }

        public TranslatedStrings(TranslateDirections translateDirection)
        {
            direction = translateDirection;
        }
    }
}
