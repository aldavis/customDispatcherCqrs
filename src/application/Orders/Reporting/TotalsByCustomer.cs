using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using application.Infrastructure.Request;
using Dapper;

namespace application.Orders.Reporting
{
    public class TotalsByCustomerRequest : IRequest
    {
        public TotalsByCustomerRequest(int customerId)
        {
            CustomerId = customerId;
        }

        public int CustomerId { get; }

    }

    public class TotalsByCustomerResult : IRequestResult
    {
        public int TotalUnits { get; set; }

        public string CustomerName { get; set; }

        public string TotalSales { get; set; }

    }

    public class TotalsByCustomerHandler:RequestHandler,IRequestHandler<TotalsByCustomerRequest,TotalsByCustomerResult>
    {
        public TotalsByCustomerResult Execute(TotalsByCustomerRequest request)
        {
            var result = new TotalsByCustomerResult();

            var sql =
                "select  c.Name as CustomerName  ," +
                       " Sum(p.Price) as TotalSales ," +
                       " Sum(o.Quantity) as TotalUnits " +
                "from    dbo.Orders o " +
                        " inner join dbo.Products p on p.Id = o.Product_Id " +
                        " inner join dbo.Customers c on c.Id = o.Customer_Id " +
                        " where o.Customer_Id = @CustomerId " +
                        " group by c.Name";

            sql = sql.Replace("@CustomerId", request.CustomerId.ToString());

            using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString()))
            {
                connection.Open();

                result = connection.Query<TotalsByCustomerResult>(sql).FirstOrDefault();
            }

            return result;
        }
    }
}
