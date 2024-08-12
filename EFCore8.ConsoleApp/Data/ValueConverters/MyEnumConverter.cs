using EFCore8.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EFCore8.ConsoleApp.Data.ValueConverters
{
	public class MyEnumConverter : ValueConverter<BookType, string>
	{
        //public MyEnumConverter(Expression<Func<BookType, string>> convertToProviderExpression, Expression<Func<string, BookType>> convertFromProviderExpression, ConverterMappingHints? mappingHints = null) : base(convertToProviderExpression, convertFromProviderExpression, mappingHints)
        //{
        //}
        public MyEnumConverter():base(v => v.ToString(), vv => (BookType)Enum.Parse(typeof(BookType), vv))
        {
            
        }

    }
}
