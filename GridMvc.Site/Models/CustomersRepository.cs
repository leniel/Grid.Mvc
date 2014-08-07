using System.Linq;

namespace GridMvc.Site.Models
{
    public class CustomersRepository : SqlRepository<Customer>
    {
        public CustomersRepository()
            : base(new NorthwindDbContext())
        {
        }

        public override IOrderedQueryable<Customer> GetAll()
        {
            return base.GetAll().OrderBy(o => o.CompanyName);
        }

        public override Customer GetById(object id)
        {
            return GetAll().FirstOrDefault(c => c.CustomerID == (string)id);
        }
    }
}