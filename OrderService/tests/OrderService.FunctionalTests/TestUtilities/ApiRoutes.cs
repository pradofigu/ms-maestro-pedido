namespace OrderService.FunctionalTests.TestUtilities;
public class ApiRoutes
{
    public const string Base = "api";
    public const string Health = Base + "/health";

    // new api route marker - do not delete

    public static class OrderPayments
    {
        public static string GetList => $"{Base}/orderPayments";
        public static string GetAll => $"{Base}/orderPayments/all";
        public static string GetRecord(Guid id) => $"{Base}/orderPayments/{id}";
        public static string Delete(Guid id) => $"{Base}/orderPayments/{id}";
        public static string Put(Guid id) => $"{Base}/orderPayments/{id}";
        public static string Create => $"{Base}/orderPayments";
        public static string CreateBatch => $"{Base}/orderPayments/batch";
    }

    public static class OrderItems
    {
        public static string GetList => $"{Base}/orderItems";
        public static string GetAll => $"{Base}/orderItems/all";
        public static string GetRecord(Guid id) => $"{Base}/orderItems/{id}";
        public static string Delete(Guid id) => $"{Base}/orderItems/{id}";
        public static string Put(Guid id) => $"{Base}/orderItems/{id}";
        public static string Create => $"{Base}/orderItems";
        public static string CreateBatch => $"{Base}/orderItems/batch";
    }

    public static class Orders
    {
        public static string GetList => $"{Base}/orders";
        public static string GetAll => $"{Base}/orders/all";
        public static string GetRecord(Guid id) => $"{Base}/orders/{id}";
        public static string Delete(Guid id) => $"{Base}/orders/{id}";
        public static string Put(Guid id) => $"{Base}/orders/{id}";
        public static string Create => $"{Base}/orders";
        public static string CreateBatch => $"{Base}/orders/batch";
    }
}
