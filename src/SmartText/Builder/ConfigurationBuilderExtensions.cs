﻿using System;

namespace SmartText.Builder
{
    public static class ConfigurationBuilderExtensions
    {
        public static IConfigurationBuilder FilePath(this IConfigurationBuilder builder, string filePath)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (filePath is null)
            {
                throw new ArgumentNullException(nameof(filePath));
            }

            builder.FilePath = filePath;

            return builder;
        }

        public static IConfigurationBuilder AutoLoadFile(this IConfigurationBuilder builder, bool autoLoad = false)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            builder.AutoLoadFile = autoLoad;

            return builder;
        }

        public static IConfigurationBuilder UseFileReader(this IConfigurationBuilder builder, IContentReader reader)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (reader is null)
            {
                throw new ArgumentNullException(nameof(reader));
            }

            builder.ContentReader = reader;

            return builder;
        }

        public static IConfigurationBuilder AddSection<T>(this IConfigurationBuilder builder, Action<ISectionBuilder<T>> sectionConfiguration)
            where T : class, new()
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (sectionConfiguration is null)
            {
                throw new ArgumentNullException(nameof(sectionConfiguration));
            }

            var section = new Section(typeof(T));
            builder.Sections.Add(section);
            sectionConfiguration(new SectionBuilder<T>(section));

            return builder;
        }
    
        public static IConfigurationBuilder UseSectionReader<T>(this IConfigurationBuilder builder, Func<SectionReaderContext, ISectionReader<T>> factory)
            where T : class, new()
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            builder.SetSectionReader(factory);

            return builder;
        }

        public static IConfigurationBuilder UseSectionWriter<T>(this IConfigurationBuilder builder, Func<SectionWriterContext, ISectionWriter<T>> factory)
        {
            if (builder is null)
            {
                throw new ArgumentNullException(nameof(builder));
            }

            if (factory is null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            builder.SetSectionWriter(factory);

            return builder;
        }
    }
}
