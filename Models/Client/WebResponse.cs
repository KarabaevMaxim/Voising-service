namespace Models.Client
{
  public readonly struct WebResponse<T> where T : class?
  {
    public int HttpStatus { get; }
    
    public string? HttpError { get; }
    
    public T Model { get; }
    
    public static WebResponse<T> Default => new WebResponse<T>();
    
    public WebResponse(int httpStatus, string? httpError, T model)
    {
      HttpStatus = httpStatus;
      Model = model;
      HttpError = httpError;
    }
  }
}