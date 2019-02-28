namespace Common.Constants
{
    public static class Config
    {
#if DEBUG
        
        public const string ChannelHost = "localhost";
        
#else
        //prod
        public const string ChannelHost = "";
#endif
    }
}
