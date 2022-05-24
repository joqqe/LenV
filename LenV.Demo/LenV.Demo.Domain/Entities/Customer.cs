using LenV.Demo.Domain.Enums;

namespace LenV.Demo.Domain.Entities
{
    public class Customer
    {
        public int? Id { get; set; }
        public string FullName { get; set; }
        public CustomerTypes Type { get; set; }
    }
}
