using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Translate
{
    enum TranslateService { Yandex = 0, Bing, NotSet };
    enum TranslateFromTo { EnRu = 0, RuEn, NotSet };

    public class OperationResult<ObjectType>
    {
        public string Error;
        public ObjectType Value;

        public OperationResult(ObjectType ObjectValue, string OperationError)
        {
            Value = ObjectValue;
            Error = OperationError;
        }
    }
}
