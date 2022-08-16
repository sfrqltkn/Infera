namespace Infera_WebApi.Helpers
{
    public interface ISoftDelete
    {
        //Softdelete metodunu kullanmamızın amacı kullanıcının
        //silineni görmeyip veritabanında görünülür kılamak
        public bool IsDeleted { get; set; }
    }
}
