using System;
using System.Collections.Generic;
using System.Text;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;



namespace BMICalculator
{
    public class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://bmicalculatormad-b0148-default-rtdb.asia-southeast1.firebasedatabase.app/");

        public async Task AddRecord(string dt, double w, double br, string bs)
        {
            await firebase
                .Child("BmiRecords")
                .PostAsync(new BmiRecord() { DateRecorded = dt, Weight = w, BmiResult = br, BmiStatus = bs });
        }

        public async Task<List<BmiRecord>> GetAllBmiRecord()
        {
            return (await firebase
                .Child("BmiRecords")
                .OnceAsync<BmiRecord>()).Select(item => new BmiRecord
                {
                    DateRecorded = item.Object.DateRecorded,
                    Weight = item.Object.Weight,
                    BmiResult = item.Object.BmiResult,
                    BmiStatus = item.Object.BmiStatus
                }).ToList();
        }

        public async Task<List<BmiRecord>> GetFindRecord(string bmistatus)
        {
            var allBmiRecord = await GetAllBmiRecord();
            await firebase
              .Child("BmiRecords")
              .OnceAsync<BmiRecord>();
            return allBmiRecord.Where(a => a.BmiStatus == bmistatus).ToList();
        }



    }



}
