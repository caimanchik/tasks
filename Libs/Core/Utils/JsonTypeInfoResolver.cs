using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace Core.Utils;

public class JsonTypeInfoResolver<T>(IEnumerable<Type> derivedTypes) : DefaultJsonTypeInfoResolver
{
    public override JsonTypeInfo GetTypeInfo(Type type, JsonSerializerOptions options)
    {
        var typeInfo = base.GetTypeInfo(type, options);
        if (typeInfo.Type is T)
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