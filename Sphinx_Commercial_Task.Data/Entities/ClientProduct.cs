namespace Sphinx_Commercial_Task.Data.Entities
{
    public class ClientProduct
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string License { get; set; }
    }

}
