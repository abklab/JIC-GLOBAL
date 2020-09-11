using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web.Services.Description;

namespace LMS.Contracts
{
    public interface IRepository<T> where T:class
    {
        //add transaction 
        T AddAsync(T t);

        //add list of Transactions
        int Add_ListAsync(IEnumerable<T> list);

        //update Transaction
        bool Update_Transaction(T t);

        //Delete Transaction
        bool Delete_Transaction(int id);

        //get all Transactions
        IEnumerable<T> GetAll_Transactions();

        //Get transaction by id
        T Get_Transaction(int id);

        //Search Transactions by Filter
        IEnumerable<T> Search_Trancations(Expression<Func<T,bool>> expression);
    }
}
