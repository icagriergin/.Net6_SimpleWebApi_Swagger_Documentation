namespace MovieApi.Models;

public class ServiceResponse<T> where  T:class
{
    public bool Result { get; set; }
    
    public string Message { get; set; }
    
    public T? Response { get; set; }
}