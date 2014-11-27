using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using Translate.TranslateDataSetTableAdapters;

namespace Translate
{
    abstract class TranslateClass
    {
        TranslateService _Service = TranslateService.NotSet;
        TranslateFromTo _FromTo = TranslateFromTo.NotSet;
        SqlCeConnection connSql = new SqlCeConnection(@"Data Source=C:\projects\Translate\Translate\Translate.sdf");

        public TranslateService Service
        {
            get
            {
                return _Service;
            }
            set
            {
                _Service = value;
            }
        }

        public TranslateFromTo FromTo
        {
            get
            {
                return _FromTo;
            }
            set
            {
                _FromTo = value;
            }
        }

        public TranslateClass()
        {
        }

        public OperationResult<List<string>> Test()
        {
            string TestString = "test";
            OperationResult<string> result = new OperationResult<string>(string.Empty, string.Empty);
            return Translate(TestString);
        }

        public OperationResult<List<string>> GetTranslatedStrinsFormLocalDB(string ToTranslateString)
        {
            OperationResult<List<string>> result = new OperationResult<List<string>>(new List<string>(), "");
            return result;
            LangServicesTableAdapter LangServices = new LangServicesTableAdapter();
            var getServiceIdResult = LangServices.GetServiceId(_Service.ToString());
            if (getServiceIdResult.Count == 1)
            {
                DestinationTableAdapter Destination = new DestinationTableAdapter();
                var getDestinationResult = Destination.GetId(_FromTo.ToString(), getServiceIdResult[0].Id);
                if (getDestinationResult.Count == 1)
                {
                    DestinationTableAdapter s = new DestinationTableAdapter();
                    TranslateCacheTableAdapter d = new TranslateCacheTableAdapter();
                    /*TranslatedStringsTableAdapter TranslatedStrings = new TranslatedStringsTableAdapter();
                    var getTranslateCacheResult = TranslatedStrings.GetTranslatedStrings(ToTranslateString);
                    if (getTranslateCacheResult.Count > 0)
                    {
                        foreach (var item in getTranslateCacheResult)
                        {
                            result.Value.Add(_Service.ToString() + ": " + item.Text);
                        }
                    }*/
                }
                else
                {
                    result.Error = "Не определено направление перевода [" + _FromTo.ToString() + "]";
                }
            }
            else
            {
                result.Error = "Не определен сервис [" + _Service.ToString() + "]";
            }
            return result;
        }

        public OperationResult<bool> SaveTranslatedWordToCache(string OriginalString, string TranslatedString)
        {
            OperationResult<bool> result = new OperationResult<bool>(false, string.Empty);
            LangServicesTableAdapter LangServices = new LangServicesTableAdapter();
            var getServiceIdResult = LangServices.GetServiceId(_Service.ToString());
            if (getServiceIdResult.Count == 1)
            {
                DestinationTableAdapter Destination = new DestinationTableAdapter();
                var getDestinationResult = Destination.GetId(_FromTo.ToString(), getServiceIdResult[0].Id);
                if (getDestinationResult.Count == 1)
                {
                    if (connSql.State == System.Data.ConnectionState.Closed) connSql.Open();

                    SqlCeCommand cmdInsertTC= new SqlCeCommand("insert into TranslateCache (StringSource,Destination) values(@StringSource, @Destination)", connSql);
                    cmdInsertTC.Parameters.Add("StringSource", OriginalString);
                    cmdInsertTC.Parameters.Add("Destination", getDestinationResult[0].Id);
                    int Inserted = cmdInsertTC.ExecuteNonQuery();
                    if (Inserted > 0)
                    {
                        TranslateCacheTableAdapter TranslateCache = new TranslateCacheTableAdapter();
                        var getTranslateCacheResult = TranslateCache.GetLine(OriginalString);
                        if (getTranslateCacheResult.Count == 1)
                        {
                            SqlCeCommand cmdInsertT = new SqlCeCommand("insert into Translated (Text,Source) values(@Text, @SourceId)", connSql);
                            cmdInsertT.Parameters.Add("Text", TranslatedString);
                            cmdInsertT.Parameters.Add("SourceId", getTranslateCacheResult[0].Id);
                            Inserted = cmdInsertT.ExecuteNonQuery();
                            if (Inserted < 1)
                            {
                                result.Error = "Строка в Translated не добавлена";
                            }
                        }
                        else result.Error = "Ошибка чтения добавленного значения в TranslateCache";
                    }
                    else
                    {
                        result.Error = "Строка в TranslateCache не добавлена";
                    }
                }
                else
                {
                    result.Error = "Не определено направление перевода [" + _FromTo.ToString() + "]";
                }
            }
            else
            {
                result.Error = "Не определен сервис [" + _Service.ToString() + "]";
            }
            return result;
        }

        public abstract OperationResult<List<string>> Translate(string ToTranslateString);
    }
}
