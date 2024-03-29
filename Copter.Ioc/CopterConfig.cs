﻿using System;
using System.Configuration;
using System.Xml;

namespace Copter.Ioc
{
    /// <summary>
    /// 配置文件
    /// </summary>
    public class CopterConfig : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            CopterConfig config = new CopterConfig();

            var startupNode = section.SelectSingleNode("Startup");
            if (startupNode != null && startupNode.Attributes != null)
            {
                var attribute = startupNode.Attributes["IgnoreStartupTasks"];
                if (attribute != null)
                    config.IgnoreStartupTasks = Convert.ToBoolean(attribute.Value);
            }

            var redisCachingNode = section.SelectSingleNode("RedisCaching");
            if (redisCachingNode != null && redisCachingNode.Attributes != null)
            {
                var enabledAttribute = redisCachingNode.Attributes["Enabled"];
                if (enabledAttribute != null)
                    config.RedisCachingEnabled = Convert.ToBoolean(enabledAttribute.Value);

                var connectionStringAttribute = redisCachingNode.Attributes["ConnectionString"];
                if (connectionStringAttribute != null)
                    config.RedisCachingConnectionString = connectionStringAttribute.Value;
            }

            var userAgentStringsNode = section.SelectSingleNode("UserAgentStrings");
            if (userAgentStringsNode != null && userAgentStringsNode.Attributes != null)
            {
                var attribute = userAgentStringsNode.Attributes["databasePath"];
                if (attribute != null)
                    config.UserAgentStringsPath = attribute.Value;
            }

            var supportPreviousVersionsNode = section.SelectSingleNode("SupportPreviousVersions");
            if (supportPreviousVersionsNode != null && supportPreviousVersionsNode.Attributes != null)
            {
                var attribute = supportPreviousVersionsNode.Attributes["Enabled"];
                if (attribute != null)
                    config.SupportPreviousVersions = Convert.ToBoolean(attribute.Value);
            }

            var webFarmsNode = section.SelectSingleNode("WebFarms");
            if (webFarmsNode != null && webFarmsNode.Attributes != null)
            {
                var multipleInstancesEnabledAttribute = webFarmsNode.Attributes["MultipleInstancesEnabled"];
                if (multipleInstancesEnabledAttribute != null)
                    config.MultipleInstancesEnabled = Convert.ToBoolean(multipleInstancesEnabledAttribute.Value);

                var runOnAzureWebsitesAttribute = webFarmsNode.Attributes["RunOnAzureWebsites"];
                if (runOnAzureWebsitesAttribute != null)
                    config.RunOnAzureWebsites = Convert.ToBoolean(runOnAzureWebsitesAttribute.Value);
            }

            var azureBlobStorageNode = section.SelectSingleNode("AzureBlobStorage");
            if (azureBlobStorageNode != null && azureBlobStorageNode.Attributes != null)
            {
                var azureConnectionStringAttribute = azureBlobStorageNode.Attributes["ConnectionString"];
                if (azureConnectionStringAttribute != null)
                    config.AzureBlobStorageConnectionString = azureConnectionStringAttribute.Value;

                var azureContainerNameAttribute = azureBlobStorageNode.Attributes["ContainerName"];
                if (azureContainerNameAttribute != null)
                    config.AzureBlobStorageContainerName = azureContainerNameAttribute.Value;

                var azureEndPointAttribute = azureBlobStorageNode.Attributes["EndPoint"];
                if (azureEndPointAttribute != null)
                    config.AzureBlobStorageEndPoint = azureEndPointAttribute.Value;

            }

            var installationNode = section.SelectSingleNode("Installation");
            if (installationNode != null && installationNode.Attributes != null)
            {
                var disableSampleDataDuringInstallationAttribute = installationNode.Attributes["DisableSampleDataDuringInstallation"];
                if (disableSampleDataDuringInstallationAttribute != null)
                    config.DisableSampleDataDuringInstallation = Convert.ToBoolean(disableSampleDataDuringInstallationAttribute.Value);

                var useFastInstallationServiceAttribute = installationNode.Attributes["UseFastInstallationService"];
                if (useFastInstallationServiceAttribute != null)
                    config.UseFastInstallationService = Convert.ToBoolean(useFastInstallationServiceAttribute.Value);

                var pluginsIgnoredDuringInstallationAttribute = installationNode.Attributes["PluginsIgnoredDuringInstallation"];
                if (pluginsIgnoredDuringInstallationAttribute != null)
                    config.PluginsIgnoredDuringInstallation = pluginsIgnoredDuringInstallationAttribute.Value;
            }

            return config;
        }

        #region 字段/属性
        /// <summary>
        /// Indicates whether we should ignore startup tasks
        /// </summary>
        public bool IgnoreStartupTasks { get; private set; }

        /// <summary>
        /// Path to database with user agent strings
        /// </summary>
        public string UserAgentStringsPath { get; private set; }



        /// <summary>
        /// Indicates whether we should use Redis server for caching (instead of default in-memory caching)
        /// </summary>
        public bool RedisCachingEnabled { get; private set; }
        /// <summary>
        /// Redis connection string. Used when Redis caching is enabled
        /// </summary>
        public string RedisCachingConnectionString { get; private set; }



        /// <summary>
        /// Indicates whether we should support previous versions (it can slightly improve performance)
        /// </summary>
        public bool SupportPreviousVersions { get; private set; }



        /// <summary>
        /// A value indicating whether the site is run on multiple instances (e.g. web farm, Windows Azure with multiple instances, etc).
        /// Do not enable it if you run on Azure but use one instance only
        /// </summary>
        public bool MultipleInstancesEnabled { get; private set; }

        /// <summary>
        /// A value indicating whether the site is run on Windows Azure Websites
        /// </summary>
        public bool RunOnAzureWebsites { get; private set; }

        /// <summary>
        /// Connection string for Azure BLOB storage
        /// </summary>
        public string AzureBlobStorageConnectionString { get; private set; }
        /// <summary>
        /// Container name for Azure BLOB storage
        /// </summary>
        public string AzureBlobStorageContainerName { get; private set; }
        /// <summary>
        /// End point for Azure BLOB storage
        /// </summary>
        public string AzureBlobStorageEndPoint { get; private set; }


        /// <summary>
        /// A value indicating whether a store owner can install sample data during installation
        /// </summary>
        public bool DisableSampleDataDuringInstallation { get; private set; }
        /// <summary>
        /// By default this setting should always be set to "False" (only for advanced users)
        /// </summary>
        public bool UseFastInstallationService { get; private set; }
        /// <summary>
        /// A list of plugins ignored during  installation
        /// </summary>
        public string PluginsIgnoredDuringInstallation { get; private set; }
        #endregion
    }
}
