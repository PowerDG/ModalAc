using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Research.Authorization
{
    /// <summary>
    /// https://www.cnblogs.com/alby/p/10035813.html
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ApplicationModels.IApplicationModelProvider" />
    public class PermissionAuthorizationApplicationModelProvider : IApplicationModelProvider
    {
        public int Order => throw new NotImplementedException();

        public static AuthorizeFilter GetFilter(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizeData> authData)
        {
            // The default policy provider will make the same policy for given input, so make it only once.
            // This will always execute synchronously.
            if (policyProvider.GetType() == typeof(DefaultAuthorizationPolicyProvider))
            {
                var policy = CombineAsync(policyProvider, authData).GetAwaiter().GetResult();
                return new AuthorizeFilter(policy);
            }
            else
            {
                return new AuthorizeFilter(policyProvider, (IEnumerable<Microsoft.AspNetCore.Authorization.IAuthorizeData>)authData);
            }
        }
        private static async Task<AuthorizationPolicy> CombineAsync(IAuthorizationPolicyProvider policyProvider, IEnumerable<IAuthorizeData> authorizeData)
        {
            if (policyProvider == null)
            {
                throw new ArgumentNullException(nameof(policyProvider));
            }
            if (authorizeData == null)
            {
                throw new ArgumentNullException(nameof(authorizeData));
            }
            var policyBuilder = new AuthorizationPolicyBuilder();
            var any = false;
            foreach (var authorizeDatum in authorizeData)
            {
                any = true;
                var useDefaultPolicy = true;
                if (!string.IsNullOrWhiteSpace(authorizeDatum.Policy))
                {
                    var policy = await policyProvider.GetPolicyAsync(authorizeDatum.Policy);
                    if (policy == null)
                    {
                        //throw new InvalidOperationException(Resources.FormatException_AuthorizationPolicyNotFound(authorizeDatum.Policy));
                        throw new InvalidOperationException(nameof(authorizeDatum.Policy));
                    }
                    policyBuilder.Combine(policy);
                    useDefaultPolicy = false;
                }
                var rolesSplit = authorizeDatum.Roles?.Split(',');
                if (rolesSplit != null && rolesSplit.Any())
                {
                    var trimmedRolesSplit = rolesSplit.Where(r => !string.IsNullOrWhiteSpace(r)).Select(r => r.Trim());
                    policyBuilder.RequireRole(trimmedRolesSplit);
                    useDefaultPolicy = false;
                }
                if (authorizeDatum is IPermissionAuthorizeData permissionAuthorizeDatum)
                {
                    var groupsSplit = permissionAuthorizeDatum.Groups?.Split(',');
                    if (groupsSplit != null && groupsSplit.Any())
                    {
                        var trimmedGroupsSplit = groupsSplit.Where(r => !string.IsNullOrWhiteSpace(r)).Select(r => r.Trim());
                        policyBuilder.RequireClaim("Group", trimmedGroupsSplit); // TODO: 注意硬编码
                        useDefaultPolicy = false;
                    }
                    var permissionsSplit = permissionAuthorizeDatum.Permissions?.Split(',');
                    if (permissionsSplit != null && permissionsSplit.Any())
                    {
                        var trimmedPermissionsSplit = permissionsSplit.Where(r => !string.IsNullOrWhiteSpace(r)).Select(r => r.Trim());
                        policyBuilder.RequireClaim("Permission", trimmedPermissionsSplit);// TODO: 注意硬编码
                        useDefaultPolicy = false;
                    }
                }
                var authTypesSplit = authorizeDatum.AuthenticationSchemes?.Split(',');
                if (authTypesSplit != null && authTypesSplit.Any())
                {
                    foreach (var authType in authTypesSplit)
                    {
                        if (!string.IsNullOrWhiteSpace(authType))
                        {
                            policyBuilder.AuthenticationSchemes.Add(authType.Trim());
                        }
                    }
                }
                if (useDefaultPolicy)
                {
                    policyBuilder.Combine(await policyProvider.GetDefaultPolicyAsync());
                }
            }
            return any ? policyBuilder.Build() : null;
        }

        public void OnProvidersExecuted(ApplicationModelProviderContext context)
        {
            throw new NotImplementedException();
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context)
        {
            throw new NotImplementedException();
        }
    }
}