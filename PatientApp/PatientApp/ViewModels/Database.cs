using PatientApp.Models;
using SQLite;
using Syncfusion.SfCalendar.XForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using Xamarin.Forms.Core;

namespace PatientApp
{
    public class Database
    {
        private SQLiteAsyncConnection _database;
        private readonly string _databasePath;




        public async Task Init()
        {
            if (_database != null)
            {
                return;
            }
            _database = new SQLiteAsyncConnection(_databasePath);
            await _database.CreateTableAsync<Models.Temperature>();
            await _database.CreateTableAsync<Models.Pressure>();
            await _database.CreateTableAsync<Models.Sugar>();
            await _database.CreateTableAsync<Models.Measurement>();
        }
        public Database(string dbPath)
        {

            _databasePath = dbPath;

        }
        public async Task<List<Models.Temperature>> GetAllTemperature()
        {
            await Init();
            return await _database.Table<Models.Temperature>().ToListAsync();
        }

        public async Task<int> SaveTemperature(Models.Temperature temp)
        {
            await Init();
            return await _database.InsertAsync(temp);
        }

        public async Task<int> DeleteAllTemperatures<T>()
        {
            await Init();
            return await _database.DeleteAllAsync<Models.Temperature>();
        }

        public async Task<int> DeleteTemperature<T>(int tempereture)
        {
            await Init();
            return await _database.DeleteAsync<Models.Temperature>(tempereture);
        }

        public Task<List<Models.Temperature>> FiltrTemperature(string stan)
        {
            return _database.Table<Models.Temperature>().Where(x => x.info == stan).ToListAsync();
        }

        public async Task<List<Models.Pressure>> GetAllPressure()
        {
            await Init();
            return await _database.Table<Models.Pressure>().ToListAsync();
        }

        public async Task<int> SavePressure(Models.Pressure press)
        {
            await Init();
            return await _database.InsertAsync(press);
        }

        public async Task<int> DeleteAllPressure<T>()
        {
            await Init();
            return await _database.DeleteAllAsync<Models.Pressure>();
        }

        public async Task<int> DeletePressure<T>(int press)
        {
            await Init();
            return await _database.DeleteAsync < Models.Pressure>(press);
        }

        public Task<List<Models.Pressure>> FiltrPress(string stan)
        {
            return _database.Table<Models.Pressure>().Where(x => x.press_info == stan).ToListAsync();
        }

        public async Task<Models.Pressure> GetPress(int id)
        {
            return await _database.Table<Models.Pressure>().FirstOrDefaultAsync(s => s.press_id == id);
        }

        public object PressDetail(int id)
        {
             return _database.QueryAsync<Models.Pressure>("SELECT * FROM Pressure WHERE press_id < "+id+"");
        }



        public async Task<List<Models.Sugar>> GetAllSugar()
        {
            await Init();
            return await _database.Table<Models.Sugar>().ToListAsync();
        }

        public async Task<int> SaveSugar(Models.Sugar sug)
        {
            await Init();
            return await _database.InsertAsync(sug);
        }

        public async Task<int> DeleteAllSugar<T>()
        {
            await Init();
            return await _database.DeleteAllAsync<Models.Sugar>();
        }

        public async Task<int> DeleteSugar<T>(int sug)
        {
            await Init();
            return await _database.DeleteAsync<Models.Sugar>(sug);
        }

        public async Task<List<Models.Measurement>> GetAllMeasurement()
        {
            await Init();
            return await _database.Table<Models.Measurement>().ToListAsync();
        }

        public async Task<int> SaveMeasurement(Models.Measurement meas)
        {
            await Init();
            return await _database.InsertAsync(meas);
        }

        public async Task<int> DeleteAllMeasurement<T>()
        {
            await Init();
            return await _database.DeleteAllAsync<Models.Measurement>();
        }

        public async Task<int> DeleteMeasurement<T>(int meas)
        {
            await Init();
            return await _database.DeleteAsync<Models.Measurement>(meas);
        }


       

     
    }

}

