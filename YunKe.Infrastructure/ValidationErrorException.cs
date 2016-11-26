using System;
namespace YunKe.Infrastructure
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class ValidationErrorException : Exception
    {
        public ValidationErrorException(string message)
            : base(message)
        {

        }
    }
}
