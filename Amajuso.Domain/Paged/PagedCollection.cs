using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Amajuso.Domain.Paged
{
    public class PagedCollection<T> where T : class
    {
        private string Url = string.Empty;

        public PagedCollection() { }

        public PagedCollection(string url) { Url = url; }

        /// <summary>
        /// Objeto de retorno da paginação
        /// </summary>
        public IEnumerable<T> Items { get; set; }

        /// <summary>
        /// Quantidade total de itens
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Número da página atual
        /// </summary>
        public int CurrentPage { get; set; }

        /// <summary>
        /// Quantidade de itens por página
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// Número total de páginas
        /// </summary>
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        /// <summary>
        /// Url da próxima página
        /// </summary>
        public Uri NextPage
        {
            get
            {
                return (CurrentPage * PageSize < Count) ? CreateUrl(CurrentPage + 1) : null;
            }
        }

        /// <summary>
        /// Url da página anterior
        /// </summary>
        public Uri PreviousPage
        {
            get
            {
                return (CurrentPage > 1 && Items.Count() > 0) ? CreateUrl(CurrentPage - 1) : null;
            }
        }

        public void SetPages(string url)
        {
            Url = url;
        }

        private Uri CreateUrl(int page)
        {
            var uri = new Uri(Url);
            var query = QueryHelpers.ParseQuery(uri.Query);
            var items = query.SelectMany(x => x.Value, (col, value) => new KeyValuePair<string, string>(col.Key, value)).ToList();

            items.RemoveAll(x => x.Key == "page");
            items.Add(new KeyValuePair<string, string>("page", page.ToString()));

            return new Uri(QueryHelpers.AddQueryString($"{uri.Scheme}://{uri.Authority}{uri.AbsolutePath}", items.ToDictionary(x => x.Key, x => x.Value)));
        }
    }
}
