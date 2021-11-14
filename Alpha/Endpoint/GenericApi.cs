namespace Alpha.Endpoint
{
    public static class GenericApi
    {
        public static void Map(IEndpointRouteBuilder endpoints)
        {
            endpoints.MapGet("/", () => "Hello friend!");
        }
    }
}
