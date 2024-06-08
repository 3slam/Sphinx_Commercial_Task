namespace Sphinx_Commercial_Task.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public char Class { get; set; }
        public string State { get; set; }
        public virtual ICollection<ClientProduct> ClientProducts { get; set; }
    }
}
