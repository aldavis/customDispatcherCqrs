namespace domain.Model
{
    public class Customer:IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal AllowedDiscountAmount { get; set; }
    }
}
