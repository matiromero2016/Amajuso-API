using Amajuso.Domain.Entities;
using Amajuso.Domain.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Amajuso.Infra.Mapping {
    public class UserMap<T> : BaseMap<T> where T : User
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);
            
            builder.HasData(
                new User { Id = 1, Name =  "Admin", LastName="Amajuso", Email = "admin@amajuso.com", Password="aqapsWNmq/CU6eh2dFWIR/wsPZ6QKLACwi8oiDJCZbo=", Gender="Masculino", Role = Role.Administrator },
                new User { Id = 2, Name =  "Visitante", LastName="Amajuso", Email = "visitor@amajuso.com", Password="aqapsWNmq/CU6eh2dFWIR/wsPZ6QKLACwi8oiDJCZbo=", Gender="Masculino", Role = Role.Visitor }
                );
        }
    }
}