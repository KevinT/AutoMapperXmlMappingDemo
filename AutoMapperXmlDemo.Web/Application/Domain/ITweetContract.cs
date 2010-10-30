namespace AutoMapperXmlDemo.Web.Application.Domain
{
    public interface ITweetContract
    {
        ulong Id { get; set; }  // id is larger than an int32 can handle
        string Name { get; set; }
        string UserName { get; set; }
        string Body { get; set; }
        string ProfileImageUrl { get; set; }
        string Created { get; set; }
    }
}