using System.Threading.Tasks;
using Models;
using Models.Client;
using Models.ServerDTO;
using RestSharp;

namespace Core.Services
{
  /// <summary>
  /// Сервис для работы с нашим веб сервисом.
  /// </summary>
  public class BackService
  {
    private const string ServerAddress = "test.ru";

    private readonly LoginService _loginService;

    public async Task<WebResponse<SendBookResponse>> SendBookRequest(BookFile book)
    {
      if (_loginService.AuthorizedUser == null)
        return WebResponse<SendBookResponse>.Default;
      
      var client = new RestClient(ServerAddress);
      var request = new RestRequest("/upload-book", Method.POST);
      request.AddParameter("userId", _loginService.AuthorizedUser.Id);
      request.AddFile(book.FileName, book.Bytes, book.FileName, "application/zip");
      var response = await client.ExecuteAsync<SendBookResponse>(request);
      return new WebResponse<SendBookResponse>((int)response.StatusCode, response.ErrorMessage, response.Data);
      
    }
    
    public BackService(LoginService loginService)
    {
      _loginService = loginService;
    }
  }
}