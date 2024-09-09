using EfCore.Core.DbContexts;
using EfCore.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfCore.Core.StoreProcedures
{
    public class StoreProcedureService
    {
        public static void CreateStoreProcedureForPerson(CustomContext context)
        {
            var createSleepRoutine = @"
CREATE PROCEDURE CreatePerson(IN Id CHAR(36), IN DreamId INT, IN PersonName VARCHAR(50))
BEGIN
    INSERT INTO peoples(Id, DreamId, Name) VALUES (Id, DreamId, PersonName);
END";

            context.Database.ExecuteSqlRaw(createSleepRoutine);
        }

        public static void AddNameForPersonUsingExistingProcedure(CustomContext context)
        {
            context.Database.ExecuteSqlRaw("CALL CreatePerson({0}, {1}, {2})", Guid.NewGuid(), 1, "Very Cool Name");
        }
    }
}
