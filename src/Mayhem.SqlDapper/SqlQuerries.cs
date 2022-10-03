namespace Mayhem.SqlDapper
{
    public static class SqlQuerries
    {
        public const string GetItemWhereIdSql = "select Id from [nft].[Item] where id = @id";
        public const string GetGameUserWhereWalletAddressSql = "select Id from [dbo].[GameUser] where WalletAddress = @WalletAddress";
        public const string UpdateItemWhereUserIdSql = "update [nft].[Item] set UserId = @UserId where id = @id";
        public const string UpdateItemWhereUserIdNullSql = "update [nft].[Item] set UserId = null where id = @id";

        public const string UpdateLandUserIdSql = "update [nft].[Land] set UserId = @UserId where id = @id";
        public const string GetLandWhereIdSql = "select id from [nft].[Land] where id = @id";
        public const string UpdateLandUserIdNullSql = "update [nft].[Land] set UserId = null where id = @id";

        public const string GetTopOneNotificationWhereIdSql = "SELECT TOP (1) [Id], [Email], [WalletAddress]  FROM [dbo].[Notification] WHERE Id = @Id;";
        public const string UpdateNotificationSql = "UPDATE [dbo].[Notification] SET WasSent = 1, LastModificationDate = GETUTCDATE() WHERE  Id = @Id";

        public const string GetNpcIdWhereIdSql = "select Id from [nft].[Npc] where id = @id";
        public const string UpdateNpcUserIdSql = "update [nft].[Npc] set UserId = @UserId where id = @id";
        public const string UpdateNpcUserIdNullSql = "update [nft].[Npc] set UserId = null where id = @id";

        public const string GetTopOneBlockWhereeBlobkTypeIdSql = "SELECT TOP 1 * FROM dbo.Block WHERE BlockTypeId = @BlockTypeId;";
        public const string UpdateBlockWhereLasBlockSql = "UPDATE dbo.Block set LastBlock = @LastBlock, LastModificationDate = GETUTCDATE() where BlockTypeId = @BlockTypeId";

        public const string GetDicoveryMissionsWhereFinishDateSql = "SELECT * FROM mission.DiscoveryMission WHERE FinishDate < GETUTCDATE() order by FinishDate";
        public const string DeleteDiscoveryMissionWhereIdSql = "delete from mission.DiscoveryMission where Id = @Id";

        public const string GetExploreMissionsWhereFinishDateSql = "SELECT * FROM mission.ExploreMission WHERE FinishDate < GETUTCDATE() order by FinishDate";
        public const string DeleteExploreMissionWhereIdSql = "delete from mission.ExploreMission where Id = @Id";

        public const string GetLandWithNpcSql = "select distinct n.UserId as NpcUserId, ul.UserId as LandUserId, ul.Owned from UserLand as ul left join nft.Npc as n on ul.LandId = n.LandId where ul.LandId = @Id";

        public static string GetOldNotSentNotyficationsSql(int olderNotificationThenInMinutes) => $"select Id, Attempts, Email, WalletAddress from dbo.Notification where WasSent = 0 and CreationDate < DATEADD(minute, -{olderNotificationThenInMinutes}, GETUTCDATE());";
        public const string UpdateNotyficationAttemptSql = "update dbo.Notification set attempts = attempts + 1, LastModificationDate = GETUTCDATE() where Id = @Id";

        public const string GetNpcWhereIdSql = "SELECT Id, UserId, LandId FROM nft.Npc WHERE Id = @Id";
        public const string UpdateNpcLandSql = "update nft.npc set LandId = @LandId, LastModificationDate = GETUTCDATE() where Id = @Id";
        public const string UpdateNpcStatusSql = "update nft.npc set NpcStatusId = @NpcStatusId, LastModificationDate = GETUTCDATE() where Id = @Id";

        public const string AddTravelSql = "insert into Travel(NpcId, LandFromId, LandToId, FinishDate, CreationDate) values(@NpcId, @LandFromId, @LandToId, @FinishDate, GETUTCDATE())";
        public const string GetTravelsSql = "SELECT * FROM dbo.Travel WHERE FinishDate < GETUTCDATE() order by FinishDate";
        public const string GetTravelWhereNpcIdSql = "SELECT * FROM dbo.Travel WHERE NpcId = @NpcId order by FinishDate";
        public const string DeleteTravelWhereIdSql = "delete FROM dbo.Travel WHERE Id = @Id";
        public const string DeleteTravelWhereNpcIdSql = "delete FROM dbo.Travel WHERE NpcId = @NpcId";

        public const string GetUserLandWhereUserIdAndLandIdSql = "select * from dbo.UserLand where UserId = @UserId and LandId = @LandId";
        public const string UpdateUserLandStatusSql = "update dbo.UserLand set Status = @Status where Id = @Id";
        public const string AddUserLandSql = "insert into dbo.UserLand(LandId, UserId, Status, HasFog, Owned, OnSale) values (@LandId, @UserId, @Status, @HasFog, @Owned, @OnSale)";

        public const string GetUserLandsFromUserPerspectiveSql = "select l.Id, l.PositionX, l.PositionY from UserLand as ul left join nft.Land as l on l.Id = ul.LandId left join nft.Npc as n on n.LandId = ul.LandId where ul.Status != 1 and ul.UserId = @UserId and (ul.HasFog = 1 or (ul.HasFog = 0 and (n.UserId = @UserId or n.UserId is NULL))) except select l.Id, l.PositionX, l.PositionY from UserLand as ul left join nft.Land as l on l.Id = ul.LandId left join nft.Npc as n on n.LandId = ul.LandId where ul.UserId != @UserId and ul.UserId is not null and ul.owned = 1";

        public static class Procedures
        {
            public const string AddFogToLandsProcedure = nameof(AddFogToLandsProcedure);
            public const string RemoveFogFromLandsProcedure = nameof(RemoveFogFromLandsProcedure);
        }
    }
}