namespace e_Estoque.Infra.Mail
{
    public interface IEmailService
    {
        Task Send(string from, string to, string subject, string body);
    }
}