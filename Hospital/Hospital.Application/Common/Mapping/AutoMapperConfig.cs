using System;

namespace Hospital.Application.Common.Mapping
{
    public class AutoMapperConfig
    {
        public static Type[] RegisterMappings()
        {
            return new[]
            {
                typeof(DomainToViewModelMappingProfile),
                typeof(ViewModelToDomainMappingProfile),
            };
        }
    }
}
