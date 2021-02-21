using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp2.Data.Entities;

namespace WebApp2.Data.Configurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.Property(n => n.Title).HasMaxLength(50).IsRequired();
            builder.Property(n => n.Body).IsRequired().HasColumnType("ntext");
            builder.Property(n => n.datetime).HasDefaultValueSql("GETDATE()");
        }
    }
}
