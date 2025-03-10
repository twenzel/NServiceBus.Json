﻿using System.Text.Json;
using NServiceBus.Configuration.AdvancedExtensibility;
using NServiceBus.Serialization;
using NServiceBus.Settings;
using NServiceBus.Json;

namespace NServiceBus;

/// <summary>
/// Extensions for <see cref="SerializationExtensions{T}"/> to manipulate how messages are serialized via System.Text.Json.
/// </summary>
public static class SystemJsonConfigurationExtensions
{
    /// <summary>
    /// Configures the <see cref="JsonReaderOptions"/> to use.
    /// </summary>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="options">The <see cref="JsonReaderOptions"/> to use.</param>
    public static void ReaderOptions(this SerializationExtensions<SystemJsonSerializer> config, JsonReaderOptions options)
    {
        var settings = config.GetSettings();
        settings.Set(options);
    }

    /// <summary>
    /// Configures the <see cref="JsonWriterOptions"/> to use.
    /// </summary>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="options">The <see cref="JsonWriterOptions"/> to use.</param>
    public static void WriterOptions(this SerializationExtensions<SystemJsonSerializer> config, JsonWriterOptions options)
    {
        var settings = config.GetSettings();
        settings.Set(options);
    }

    /// <summary>
    /// Configures the <see cref="JsonSerializerOptions"/> to use.
    /// </summary>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="options">The <see cref="JsonSerializerOptions"/> to use.</param>
    public static void Options(this SerializationExtensions<SystemJsonSerializer> config, JsonSerializerOptions options)
    {
        var settings = config.GetSettings();
        settings.Set(options);
    }

    internal static JsonSerializerOptions GetOptions(this ReadOnlySettings settings) =>
        settings.GetOrDefault<JsonSerializerOptions>();

    internal static JsonReaderOptions GetReaderOptions(this ReadOnlySettings settings) =>
        settings.GetOrDefault<JsonReaderOptions>();

    internal static JsonWriterOptions GetWriterOptions(this ReadOnlySettings settings) =>
        settings.GetOrDefault<JsonWriterOptions>();

    /// <summary>
    /// Configures string to use for <see cref="Headers.ContentType"/> headers.
    /// </summary>
    /// <remarks>
    /// Defaults to <see cref="ContentTypes.Json"/>.
    /// This setting is required when this serializer needs to co-exist with other json serializers.
    /// </remarks>
    /// <param name="config">The <see cref="SerializationExtensions{T}"/> instance.</param>
    /// <param name="contentTypeKey">The content type key to use.</param>
    public static void ContentTypeKey(this SerializationExtensions<SystemJsonSerializer> config, string contentTypeKey)
    {
        Guard.AgainstEmpty(contentTypeKey, nameof(contentTypeKey));
        var settings = config.GetSettings();
        settings.Set("NServiceBus.SystemJson.ContentTypeKey", contentTypeKey);
    }

    internal static string GetContentTypeKey(this ReadOnlySettings settings) =>
        settings.GetOrDefault<string>("NServiceBus.SystemJson.ContentTypeKey");
}