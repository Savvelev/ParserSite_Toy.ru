namespace ToyShopParser
{
    /// <summary>
    /// The class contains fields for Header request.
    /// </summary>
    sealed class HeaderConstants
    {
        public string[] Accept { get; } = new string[]
        {   "text/html",
            "application/xhtml+xml",
            "application/xml;q=0.9",
            "image/avif", "image/webp",
            "image/apng",
            "*/*;q=0.8",
            "application/signed-exchange;v=b3;q=0.9"
        };
        public string Connection { get; } = "keep-alive";
        public string CacheControl { get; } = "max-age=0";
        public string Cookie { get; } = "ssss_id=s_id_625fda25fbe771.58069040; PHPSESSID=62tl1a6mrms00830u85mn8li93; ipp_uid=1650448932044/1ta6oY9uwJgOLEml/mRmqh9EGbChsr9ILIuQowA==; rerf=AAAAAGJf2iSkAaoRBB5XAg==; rrpvid=605010307388501; BITRIX_SM_country=; BITRIX_SM_country_city=; BITRIX_SM_country_name=; BITRIX_SM_country_zip=; BITRIX_SM_country_fias=; BITRIX_SM_city=77000000000; BITRIX_SM_SALE_UID=175894178";
        public string Host { get; } = "www.toy.ru";
        public string[] SecChUa { get; } = new string[] 
        {  "\" Not A;Brand\";v=\"99\"",
           "\"Chromium\";v=\"100\"",
           "\"Google Chrome\";v=\"100\"" 
        };
        public string SecChUaPlatform { get; } = "\"Windows\"";

        public string SecFetchDest { get; } = "document";
        public string SecFetchMode { get; } = "navigate";
        public string SecFetchSite { get; } = "same-origin";
        public string SecFetchUser { get; } = "?1";
        public string UpgradeInsecureRequests { get; } = "1";
        public string UserAgent { get; } = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/100.0.4896.127 Safari/537.36";
    }
}
