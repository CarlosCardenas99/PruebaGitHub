using Paltarumi.Acopio.Balanza.Repository.Abstractions.Transactions;

namespace Paltarumi.Acopio.Balanza.Repository.Transactions
{
    public class ExecutionResult : IExecutionResult
    {
        public bool IsSuccessful { get; }

        public ExecutionResult(bool isSuccessful) => IsSuccessful = isSuccessful;
    }

    public class ExecutionResult<TResult> : ExecutionResult, IExecutionResult<TResult>
    {
        public TResult Result { get; }

        public ExecutionResult(bool isSuccessful, TResult result) : base(isSuccessful) => Result = result;
    }
}
