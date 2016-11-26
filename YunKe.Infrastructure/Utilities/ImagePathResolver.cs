namespace YunKe.Infrastructure.Utilities
{
    public class ImagePathResolver
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="imgUrl"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static string ResolveAbsImagePath(string imgUrl, IMediaSourceProvider provider)
        {
            var lower = imgUrl.ToLower();

            if (!lower.StartsWith("http"))
            {
                return provider.MediaSourceServerPath.TrimEnd('/') + lower;
            }

            return lower;
        }
    }
}