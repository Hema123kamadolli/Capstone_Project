namespace MVCBlogTracker
{
    public class GlobalVar
    {
        public static HttpClient WebApiClient = new HttpClient();
        static GlobalVar()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:39719/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
