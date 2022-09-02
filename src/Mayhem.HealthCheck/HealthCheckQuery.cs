namespace Mayhem.HealthCheck
{
    public class HealthCheckQuery
    {
        public static readonly string DataBaseCRUDQuery = $"INSERT INTO [hc].[HealthCheck] ([CreationDate], [LastModificationDate]) VALUES (GETUTCDATE(), GETUTCDATE()); " +
                $"UPDATE [hc].[HealthCheck] SET [LastModificationDate] = GETUTCDATE() WHERE [hc].[HealthCheck].ID = SCOPE_IDENTITY(); " +
                $"SELECT * FROM [hc].[HealthCheck] WHERE [hc].[HealthCheck].ID = SCOPE_IDENTITY(); " +
                $"DELETE [hc].[HealthCheck] WHERE [hc].[HealthCheck].ID = SCOPE_IDENTITY();";
    }
}
