using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Tables;
using System;
using System.Data.Entity;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.OData;
using AutoMapper.QueryableExtensions;

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


        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Response is disposed by caller.")]
        protected override TKey GetKey<TKey>(string id, CultureInfo culture)
        {
            if (id == null)
            {
                throw new ArgumentNullException("id");
            }

            if (culture == null)
            {
                throw new ArgumentNullException("culture");
            }

                return (TKey)((IConvertible)id).ToType(typeof(TKey), culture);
        }

        public override IQueryable<TData> Query()
        {
            IQueryable<TData> query = this.Context.Set<TModel>().ProjectTo<TData>();
            return query;
        }

        public override Task<bool> DeleteAsync(string id)
        {
            return DeleteItemAsync(GetKey<TKey>(id));
        }

        public override SingleResult<TData> Lookup(string id)
        {
            var key = GetKey<TKey>(id);
            var predicate = _lookupPredicateFactory(key);
            IQueryable<TData> query = this.Context.Set<TModel>().Where(predicate).ProjectTo<TData>();
            return SingleResult.Create(query);
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