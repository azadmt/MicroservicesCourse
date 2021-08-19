namespace Shopping.Model
{
    public class Customer : EntityBase
    {
        public string Name { get; set; }
        public CustomerType Type { get; set; }
    }
}
