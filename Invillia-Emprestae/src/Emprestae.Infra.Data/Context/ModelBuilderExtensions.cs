using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

namespace Emprestae.Infra.Data.Context
{
    public static class ModelBuilderExtensions
    {
        public static void RemovePluralizingTableNameConvention(this ModelBuilder modelBuilder)
        {
            foreach (IMutableEntityType entity in modelBuilder.Model.GetEntityTypes())
            {
                entity.SetTableName(entity.DisplayName());

                var properties = entity.GetProperties();

                foreach (var prop in properties)
                {
                    if(prop.ClrType == typeof(string))
                    {
                        prop.SetColumnType("nvarchar");
                        prop.SetMaxLength(100);
                    }
                }
            }
        }
    }
}
