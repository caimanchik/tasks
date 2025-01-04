using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using Domain.Tasks.Abstracts.Existing;

namespace Domain.Tasks.Utils;

public class ArtefactsJsonTypeInfoResolver(IEnumerable<Type> derivedTypes) : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        var typeInfo = base.GetTypeInfo(type, options);
        if (typeInfo.Type == typeof(TaskArtefactsBase))
        {
            typeInfo.PolymorphismOptions = new JsonPolymorphismOptions
            {
                IgnoreUnrecognizedTypeDiscriminators = true,
                UnknownDerivedTypeHandling = JsonUnknownDerivedTypeHandling.FallBackToBaseType,
            };

            foreach (var derivedType in derivedTypes) 
                typeInfo.PolymorphismOptions.DerivedTypes.Add(new JsonDerivedType(derivedType, derivedType.Name));
        }
        
        return typeInfo;
    }
}