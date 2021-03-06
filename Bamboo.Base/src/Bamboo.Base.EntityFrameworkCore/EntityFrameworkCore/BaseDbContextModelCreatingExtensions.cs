﻿using System;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace Bamboo.Base.EntityFrameworkCore
{
    public static class BaseDbContextModelCreatingExtensions
    {
        public static void ConfigureBase(
            this ModelBuilder builder,
            Action<BaseModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BaseModelBuilderConfigurationOptions(
                BaseDbProperties.DbTablePrefix,
                BaseDbProperties.DbSchema
            );

            optionsAction?.Invoke(options);

            /* Configure all entities here. Example:

            builder.Entity<Question>(b =>
            {
                //Configure table & schema name
                b.ToTable(options.TablePrefix + "Questions", options.Schema);
            
                b.ConfigureByConvention();
            
                //Properties
                b.Property(q => q.Title).IsRequired().HasMaxLength(QuestionConsts.MaxTitleLength);
                
                //Relations
                b.HasMany(question => question.Tags).WithOne().HasForeignKey(qt => qt.QuestionId);

                //Indexes
                b.HasIndex(q => q.CreationTime);
            });
            */
#if HAS_DB_POSTGRESQL
            builder.UseSerialColumns();
            builder.StringSize();
            builder.PostgreSQLDataType();
            builder.SnakeCase();
            // Change to lower case:
            // https://github.com/abpframework/abp/issues/2131
#endif
        }
    }
}