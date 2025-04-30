public abstract class Error { }

public abstract class ApiResult<TD, TE> where TE : Error
{
    public class Success : ApiResult<TD, TE>
    {
        public TD Data { get; private set; }

        public Success(TD data)
        {
            Data = data;
        }
    }

    public class Failure : ApiResult<TD, TE>
    {
        public TE Error { get; private set; }

        public Failure(TE error)
        {
            Error = error;
        }
    }
}

[System.Serializable]
public class ApiError : Error
{
    public string error;
    public string message;
}