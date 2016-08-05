using System.Collections.Generic;
using WebApplication16.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebApplication16
{
    public  static class  Utils
    {
        public static ModelView<T> CreateViewFor<T>(IEnumerable<T>  data) where T : class
        {
            int count=data.Count();
            return new ModelView<T>() { Count = count, Items = data.ToList() };

        }

        public static IEnumerable<T> TakeSkip<T>(this IEnumerable<T> sortedData,int take,int skip){
            return sortedData.Skip(skip).Take(take);
        }
        public static IEnumerable<T> Sort<T>(this IEnumerable<T> model,Func<T,dynamic> key,bool order)where T:class{
            return order?model.OrderBy(key):model.OrderByDescending(key);

        }
        public static Func<NavLink,dynamic> GetKeyForNavLink(string prop){
                Func<NavLink, dynamic> key;

            switch (prop)
            {
                case "id":
                    key = (p) => p.NavLinkId;
                    break;
                case "title":
                    key = (p) => p.Title;
                    break;
                case "page":
                    key = (p) => p.Page.UrlName;
                    break;
                case "parentlinkid":
                    key = (p) => p.ParentLinkID;
                    break;
                case "pageid":
                    key = (p) => p.PageId;
                    break;
                default:
                    key = (p) => p.NavLinkId;
                    break;
            }
            return key;
        }
        public static Func<Page, dynamic> GetKeyForPageSorting(string prop)
        {
            Func<Page, dynamic> key;

            switch (prop)
            {
                case "id":
                    key = (p) => p.PageId.ToString();
                    break;
                case "title":
                    key = (p) => p.Title;
                    break;
                case "content":
                    key = (p) => p.Content;
                    break;
                case "urlname":
                    key = (p) => p.UrlName;
                    break;
                case "description":
                    key = (p) => p.Description;
                    break;
                case "addedDate":
                    key = (p) => new {p.AddedDate.Year,p.AddedDate.Month,p.AddedDate.Day};
                    break;
                default:
                    key = (p) => p.PageId.ToString();
                    break;
            }
            return key;
        }
    }



    public class ModelView<T>
    {
        public int Count { get; set; }
        public List<T> Items { get; set; }
    }
}