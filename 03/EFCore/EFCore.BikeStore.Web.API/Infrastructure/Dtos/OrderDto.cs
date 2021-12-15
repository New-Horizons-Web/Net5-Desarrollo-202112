using System;

namespace EFCore.BikeStore.Web.API.Infrastructure.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public byte OrderStatus { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        public int StoreId { get; set; }
        public int StaffId { get; set; }

        public string CustomerName { get; set; }
        public string StoreName { get; set; }
        public string StaffName { get; set; }

    }
}
