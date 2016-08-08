using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.OData;

namespace BureauAppServiceService.Infrastructure
{
    public class CustomEntityDomainManager<TData, TModel, TKey> : MappedEntityDomainManager<TData, TModel>
        where TData : class, ITableData, new()
        where TModel : class
    {
        Func<TKey, Expression<Func<TModel, bool>>> _lookupPredicateFactory;

        public CustomEntityDomainManager(DbContext context, HttpRequestMessage request, Func<TKey, Expression<Func<TModel, bool>>> lookupPredicateFactory)
        : base(context, request)
        {
            _lookupPredicateFactory = lookupPredicateFactory;
        }
        public override Task<bool> DeleteAsync(string id)
        {
            return DeleteItemAsync(GetKey<TKey>(id));
        }

        public override SingleResult<TData> Lookup(string id)
        {
            var key = GetKey<TKey>(id);
            var predicate = _lookupPredicateFactory(key);
            return LookupEntity(predicate);
        }

        public override Task<TData> UpdateAsync(string id, Delta<TData> patch)
        {
            return UpdateEntityAsync(patch, GetKey<TKey>(id));
        }

        public override Task<TData> InsertAsync(TData data)
        {
            data.Id = "1";
            return base.InsertAsync(data);
        }
    }
}