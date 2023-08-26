using EL.MAUI.BlackList.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EL.MAUI.BlackList.Services
{
    public class DTBlackListService
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (Database is not null)
                return;

            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var resultUserBase = await Database.CreateTableAsync<UserBase>();
            var result = await Database.CreateTableAsync<UserBaseTokenModel>();
        }

        //public async Task<List<UserBase>> GetItemsNotDoneAsync()
        //{
        //    await Init();
        //    return await Database.Table<UserBase>().Where(t => t.UserID).ToListAsync();

        //    // SQL queries are also possible
        //    //return await Database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Done] = 0");
        //}
        #region UserBase
        public async Task<UserBase> GetUserNameAsync()
        {
            await Init();
            return await Database.Table<UserBase>().FirstOrDefaultAsync();
        }
        public async Task<UserBase> GetUserBaseAsync()
        {
            await Init();
            return await Database.Table<UserBase>().FirstOrDefaultAsync();
        }

        public async Task<int> GetPinCodeUserBaseAsync()
        {
            await Init();
            var result = await Database.Table<UserBase>().FirstOrDefaultAsync();
            if(result == null)
                return await Task.Run(() => 0);
            return await Task.Run(()=>result.PinCode);
        }

        public async Task<int> SaveUserBaseAsync(UserBase item)
        {
            await Init();
            if (!string.IsNullOrEmpty(item.UserID))
                return await Database.UpdateAsync(item);
            else
                return await Database.InsertAsync(item);
        }

        public async Task<int> DeleteUserBaseAsync(UserBase item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }
        public async Task DropUserBaseAsync()
        {
            await Init();
            await Database.DropTableAsync<UserBase>();
        }
        #endregion

        #region UserBaseTokenModel

        public async Task<UserBaseTokenModel> GetUserBaseTokenModelAsync()
        {
            await Init();
            var r= await Database.Table<UserBaseTokenModel>().FirstOrDefaultAsync();
            return await Database.Table<UserBaseTokenModel>().FirstOrDefaultAsync();
        }

        public async Task<int> SaveUserBaseTokenModelAsync(UserBaseTokenModel item)
        {
            await Init();
            try
            {
                var rezult = await Database.Table<UserBaseTokenModel>().CountAsync();
                if (rezult > 0)
                    return await Database.UpdateAsync(item);
                else
                    return await Database.InsertAsync(item);
            }
            catch (Exception e)
            {
                //await Init();
                return await Database.InsertAsync(item);
            }
        }

        public async Task<int> DeleteUserBaseTokenModelAsync(UserBaseTokenModel item)
        {
            await Init();
            return await Database.DeleteAsync(item);
        }

        public async Task DropUserBaseTokenModelAsync()
        {
            await Init();
            await Database.DropTableAsync<UserBaseTokenModel>();
        }
        #endregion
    }
}
