using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace Locky.Shared
{
    public class Passwords
    {
        public static MobileServiceClient client = new MobileServiceClient(
            "https://locky.azure-mobile.net/",
            "NTQGKcMPyPeNfBDRyQgAyKUbtXSRRD87"
        );

        public Passwords()
        {
            
        }

        public static async Task<bool> addPassword(Password password)
        {
            try
            {
                await client.GetTable<Password>().InsertAsync(password);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static async Task<List<Password>> readPasswords()
        {
            try
            {
                List<Password> passwords = await client.GetTable<Password>().ToListAsync();

                return passwords;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

