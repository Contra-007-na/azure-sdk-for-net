// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Maintenance
{
    /// <summary>
    /// A class representing a collection of <see cref="MaintenanceConfigurationResource"/> and their operations.
    /// Each <see cref="MaintenanceConfigurationResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="MaintenanceConfigurationCollection"/> instance call the GetMaintenanceConfigurations method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class MaintenanceConfigurationCollection : ArmCollection, IEnumerable<MaintenanceConfigurationResource>, IAsyncEnumerable<MaintenanceConfigurationResource>
    {
        private readonly ClientDiagnostics _maintenanceConfigurationClientDiagnostics;
        private readonly MaintenanceConfigurationsRestOperations _maintenanceConfigurationRestClient;
        private readonly ClientDiagnostics _maintenanceConfigurationMaintenanceConfigurationsForResourceGroupClientDiagnostics;
        private readonly MaintenanceConfigurationsForResourceGroupRestOperations _maintenanceConfigurationMaintenanceConfigurationsForResourceGroupRestClient;

        /// <summary> Initializes a new instance of the <see cref="MaintenanceConfigurationCollection"/> class for mocking. </summary>
        protected MaintenanceConfigurationCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="MaintenanceConfigurationCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal MaintenanceConfigurationCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _maintenanceConfigurationClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Maintenance", MaintenanceConfigurationResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MaintenanceConfigurationResource.ResourceType, out string maintenanceConfigurationApiVersion);
            _maintenanceConfigurationRestClient = new MaintenanceConfigurationsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, maintenanceConfigurationApiVersion);
            _maintenanceConfigurationMaintenanceConfigurationsForResourceGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Maintenance", MaintenanceConfigurationResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(MaintenanceConfigurationResource.ResourceType, out string maintenanceConfigurationMaintenanceConfigurationsForResourceGroupApiVersion);
            _maintenanceConfigurationMaintenanceConfigurationsForResourceGroupRestClient = new MaintenanceConfigurationsForResourceGroupRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, maintenanceConfigurationMaintenanceConfigurationsForResourceGroupApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create or Update configuration record
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceName"> Maintenance Configuration Name. </param>
        /// <param name="data"> The configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<MaintenanceConfigurationResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string resourceName, MaintenanceConfigurationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _maintenanceConfigurationRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceName, data, cancellationToken).ConfigureAwait(false);
                var uri = _maintenanceConfigurationRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, resourceName, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MaintenanceArmOperation<MaintenanceConfigurationResource>(Response.FromValue(new MaintenanceConfigurationResource(Client, response), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Create or Update configuration record
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="resourceName"> Maintenance Configuration Name. </param>
        /// <param name="data"> The configuration. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<MaintenanceConfigurationResource> CreateOrUpdate(WaitUntil waitUntil, string resourceName, MaintenanceConfigurationData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _maintenanceConfigurationRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, resourceName, data, cancellationToken);
                var uri = _maintenanceConfigurationRestClient.CreateCreateOrUpdateRequestUri(Id.SubscriptionId, Id.ResourceGroupName, resourceName, data);
                var rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                var operation = new MaintenanceArmOperation<MaintenanceConfigurationResource>(Response.FromValue(new MaintenanceConfigurationResource(Client, response), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get Configuration record
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceName"> Maintenance Configuration Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        public virtual async Task<Response<MaintenanceConfigurationResource>> GetAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationCollection.Get");
            scope.Start();
            try
            {
                var response = await _maintenanceConfigurationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MaintenanceConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get Configuration record
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceName"> Maintenance Configuration Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        public virtual Response<MaintenanceConfigurationResource> Get(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationCollection.Get");
            scope.Start();
            try
            {
                var response = _maintenanceConfigurationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resourceName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new MaintenanceConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get Configuration records within a subscription and resource group
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurationsForResourceGroup_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MaintenanceConfigurationResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MaintenanceConfigurationResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _maintenanceConfigurationMaintenanceConfigurationsForResourceGroupRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new MaintenanceConfigurationResource(Client, MaintenanceConfigurationData.DeserializeMaintenanceConfigurationData(e)), _maintenanceConfigurationMaintenanceConfigurationsForResourceGroupClientDiagnostics, Pipeline, "MaintenanceConfigurationCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Get Configuration records within a subscription and resource group
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurationsForResourceGroup_List</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MaintenanceConfigurationResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MaintenanceConfigurationResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _maintenanceConfigurationMaintenanceConfigurationsForResourceGroupRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new MaintenanceConfigurationResource(Client, MaintenanceConfigurationData.DeserializeMaintenanceConfigurationData(e)), _maintenanceConfigurationMaintenanceConfigurationsForResourceGroupClientDiagnostics, Pipeline, "MaintenanceConfigurationCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceName"> Maintenance Configuration Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationCollection.Exists");
            scope.Start();
            try
            {
                var response = await _maintenanceConfigurationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceName"> Maintenance Configuration Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        public virtual Response<bool> Exists(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationCollection.Exists");
            scope.Start();
            try
            {
                var response = _maintenanceConfigurationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resourceName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceName"> Maintenance Configuration Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        public virtual async Task<NullableResponse<MaintenanceConfigurationResource>> GetIfExistsAsync(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _maintenanceConfigurationRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, resourceName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<MaintenanceConfigurationResource>(response.GetRawResponse());
                return Response.FromValue(new MaintenanceConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourcegroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>MaintenanceConfigurations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2023-09-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="MaintenanceConfigurationResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="resourceName"> Maintenance Configuration Name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="resourceName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="resourceName"/> is null. </exception>
        public virtual NullableResponse<MaintenanceConfigurationResource> GetIfExists(string resourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(resourceName, nameof(resourceName));

            using var scope = _maintenanceConfigurationClientDiagnostics.CreateScope("MaintenanceConfigurationCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _maintenanceConfigurationRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, resourceName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<MaintenanceConfigurationResource>(response.GetRawResponse());
                return Response.FromValue(new MaintenanceConfigurationResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<MaintenanceConfigurationResource> IEnumerable<MaintenanceConfigurationResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<MaintenanceConfigurationResource> IAsyncEnumerable<MaintenanceConfigurationResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
