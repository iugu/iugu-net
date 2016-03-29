namespace iugu.net.Response
{
    public class PaggedResponseMessage<T> where T : class, new()
    {
        public int TotalItems { get; set; }
        public T[] Items { get; set; }
    }
}
