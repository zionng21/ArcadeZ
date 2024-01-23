namespace ArcadeZ.Client.Static
{
	public static class Endpoints
	{
		private static readonly string Prefix = "api";

		public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
		public static readonly string CustEnquiriesEndpoint = $"{Prefix}/custEnquiries";
		public static readonly string CustomersEndpoint = $"{Prefix}/customers";
		public static readonly string PaymentsEndpoint = $"{Prefix}/payments";
		public static readonly string CustOrdersEndpoint = $"{Prefix}/custOrders";
		public static readonly string CustOrderItemsEndpoint = $"{Prefix}/custOrderItems";
		public static readonly string ProductHardwaresEndpoint = $"{Prefix}/productHardwares";
		public static readonly string ProductSoftwaresEndpoint = $"{Prefix}/productSoftwares";
		public static readonly string EnterprisesEndpoint = $"{Prefix}/enterprises";

	}
}
