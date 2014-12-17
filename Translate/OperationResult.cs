namespace Translate
{
    public class OperationResult<TObjectType>
    {
        public string Error;
        public TObjectType Value;

        public OperationResult(TObjectType objectValue, string operationError)
        {
            Value = objectValue;
            Error = operationError;
        }
    }
}