namespace YunKe.Infrastructure.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class CommandResult
    {
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="CommandResult"/> is success.
        /// </summary>
        /// <value>
        ///   <c>true</c> if success; otherwise, <c>false</c>.
        /// </value>
        public bool Success { get; set; }

        /// <summary>
        /// Performs an implicit conversion from <see cref="System.Boolean"/> to <see cref="CommandResult"/>.
        /// </summary>
        /// <param name="x">if set to <c>true</c> [x].</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator CommandResult(bool x)
        {
            return new Commands.CommandResult() { Success = x };
        }

        /// <summary>
        /// Performs an implicit conversion from <see cref="CommandResult"/> to <see cref="System.Boolean"/>.
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>
        /// The result of the conversion.
        /// </returns>
        public static implicit operator bool(CommandResult result)
        {
            return result?.Success == true;
        }
    }
}
