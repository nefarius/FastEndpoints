﻿using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace FastEndpoints;

static class ConfigExtensions
{
    internal static void IgnoreToHeaderAttributes(this JsonSerializerOptions opts)
    {
        opts.TypeInfoResolver = opts.TypeInfoResolver?.WithAddedModifier(
            ti =>
            {
                if (ti.Kind != JsonTypeInfoKind.Object)
                    return;

                for (var i = 0; i < ti.Properties.Count; i++)
                {
                    var pi = ti.Properties[i];

                    if (pi.AttributeProvider?.IsDefined(Types.ToHeaderAttribute, true) is true)
                    {
                        // ReSharper disable once RedundantLambdaParameterType
                        pi.ShouldSerialize = (object _, object? __) => false;
                    }
                }
            });
    }

    internal static void EnableJsonIgnoreAttributesOnRequiredProps(this JsonSerializerOptions opts)
    {
        opts.TypeInfoResolver = opts.TypeInfoResolver?.WithAddedModifier(
            ti =>
            {
                if (ti.Kind != JsonTypeInfoKind.Object)
                    return;

                for (var i = 0; i < ti.Properties.Count; i++)
                {
                    var pi = ti.Properties[i];
                    if (pi.AttributeProvider?.IsDefined(Types.JsonIgnoreAttribute, true) is true)
                        pi.IsRequired = false;
                }
            });
    }
}